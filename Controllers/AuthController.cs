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
            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";

            Console.WriteLine($"Login attempt: Email={email}");

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                if (string.IsNullOrWhiteSpace(email))
                    ModelState.AddModelError("Email", "Email không được để trống.");
                if (string.IsNullOrWhiteSpace(password))
                    ModelState.AddModelError("Password", "Mật khẩu không được để trống.");

                return View();
            }


            var user = await _context.Users
                .Include(u => u.Role)
                .FirstOrDefaultAsync(u => u.Email == email);

            if (user == null)
            {
                Console.WriteLine("Login failed: User not found");
                ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác.");
                return View();
            }


            Console.WriteLine($"User found: ID={user.UserId}, Name={user.FullName}, Email={user.Email}");

            if (!VerifyPassword(password, user.PasswordHash))
            {
                Console.WriteLine("Login failed: Password incorrect");
                ModelState.AddModelError("", "Email hoặc mật khẩu không chính xác.");
                return View();
            }

            Console.WriteLine("Login successful, attempting to save session...");

            try
            {
                Console.WriteLine($"Session ID: {HttpContext.Session.Id}");

                HttpContext.Session.SetString("UserId", user.UserId.ToString());
                var userIdCheck = HttpContext.Session.GetString("UserId");
                Console.WriteLine($"UserId saved: {userIdCheck}");

                HttpContext.Session.SetString("UserName", user.FullName ?? user.Email);
                var userNameCheck = HttpContext.Session.GetString("UserName");
                Console.WriteLine($"UserName saved: {userNameCheck}");

                HttpContext.Session.SetString("UserEmail", user.Email);
                var emailCheck = HttpContext.Session.GetString("UserEmail");
                Console.WriteLine($"UserEmail saved: {emailCheck}");

                HttpContext.Session.SetInt32("RoleId", user.RoleId);
                var roleIdCheck = HttpContext.Session.GetInt32("RoleId");
                Console.WriteLine($"RoleId saved: {roleIdCheck}");

                if (user.Role != null)
                {
                    HttpContext.Session.SetString("RoleName", user.Role.RoleName);
                    var roleNameCheck = HttpContext.Session.GetString("RoleName");
                    Console.WriteLine($"RoleName saved: {roleNameCheck}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving session: {ex.Message}");
                Console.WriteLine($"Stack trace: {ex.StackTrace}");
            }


            var claims = new List<System.Security.Claims.Claim>
            {
                new System.Security.Claims.Claim("UserId", user.UserId.ToString()),
                new System.Security.Claims.Claim("Email", user.Email),
                new System.Security.Claims.Claim("RoleId", user.RoleId.ToString())
            };

            var identity = new System.Security.Claims.ClaimsIdentity(claims, "CustomAuthType");
            var principal = new System.Security.Claims.ClaimsPrincipal(identity);

            await HttpContext.SignInAsync("CustomAuthScheme", principal);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            HttpContext.Session.Clear();
            await HttpContext.SignOutAsync("CustomAuthScheme");

            Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
            Response.Headers["Pragma"] = "no-cache";
            Response.Headers["Expires"] = "0";
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
