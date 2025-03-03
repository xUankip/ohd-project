using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Authentication;

namespace AspnetCoreMvcStarter.Controllers
{
    public class AuthController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
          return View();
        }


        [HttpGet]
        public IActionResult Login()
        {

            if (HttpContext.Session.TryGetValue("UserId", out _))
            {
                return RedirectToAction("Index", "Home");
            }


            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string email, string password)
        {
            // Thêm các header để ngăn cache
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                if (string.IsNullOrWhiteSpace(email))
                    ModelState.AddModelError("Email", "Email không được để trống.");
                if (string.IsNullOrWhiteSpace(password))
                    ModelState.AddModelError("Password", "Mật khẩu không được để trống.");

                return View();
            }

            // Tìm kiếm người dùng và lấy thông tin vai trò
            var user = await _context.Users
                .Include(u => u.Role) // Đảm bảo lấy thông tin vai trò
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác.");
                return View();
            }

            if (!VerifyPassword(password, user.PasswordHash))
            {
                ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác.");
                return View();
            }

            // Đăng nhập thành công -> Lưu thông tin vào session
            HttpContext.Session.SetString("UserId", user.UserId.ToString());
            HttpContext.Session.SetString("UserName", user.FullName ?? user.Email);
            HttpContext.Session.SetString("UserEmail", user.Email);

            // Lưu RoleId vào session - quan trọng cho việc kiểm tra quyền
            HttpContext.Session.SetInt32("RoleId", user.RoleId);

            // Nếu có tên vai trò, lưu vào session
            if (user.Role != null)
            {
                HttpContext.Session.SetString("RoleName", user.Role.RoleName);
            }

            // Cũng lưu vào Claims để sử dụng trong các tính năng yêu cầu xác thực
            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim("UserId", user.UserId.ToString()),
                new System.Security.Claims.Claim("Email", user.Email),
                new System.Security.Claims.Claim("RoleId", user.RoleId.ToString())
            };

            var identity = new System.Security.Claims.ClaimsIdentity(claims, "CustomAuthType");
            var principal = new System.Security.Claims.ClaimsPrincipal(identity);

            // Đăng nhập người dùng vào hệ thống
            await HttpContext.SignInAsync("CustomAuthScheme", principal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear(); // Xóa toàn bộ session khi logout

            // Đăng xuất từ hệ thống xác thực
            await HttpContext.SignOutAsync("CustomAuthScheme");

            // Thêm các header để ngăn cache
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            // Thêm response header để ngăn chặn nút quay lại
            Response.Headers["Location"] = Url.Action("Login", "Auth");

            return RedirectToAction("Login");
        }

        private bool VerifyPassword(string inputPassword, string storedHash)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] inputBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(inputPassword));
                byte[] storedBytes = Enumerable.Range(0, storedHash.Length / 2)
                    .Select(i => Convert.ToByte(storedHash.Substring(i * 2, 2), 16))
                    .ToArray();

                return CryptographicOperations.FixedTimeEquals(inputBytes, storedBytes);
            }
        }
    }
}
