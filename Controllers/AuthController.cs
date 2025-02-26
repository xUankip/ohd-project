using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;

public class AuthController : Controller
{
    private readonly ApplicationDbContext _context;

    public AuthController(ApplicationDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Login()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Login(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            if (string.IsNullOrWhiteSpace(email))
                ModelState.AddModelError("Email", "Email không được để trống.");
            if (string.IsNullOrWhiteSpace(password))
                ModelState.AddModelError("Password", "Mật khẩu không được để trống.");

            return View();
        }

        var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
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

        // Đăng nhập thành công -> Lưu UserId vào session
        HttpContext.Session.SetString("UserId", user.UserId.ToString());

        return RedirectToAction("Index", "Home");
    }

    [HttpGet]
    public IActionResult Logout()
    {
        HttpContext.Session.Clear(); // Xóa toàn bộ session khi logout
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
