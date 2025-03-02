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

    //login
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
      // Lấy ReturnUrl từ Session
      string? returnUrl = HttpContext.Session.GetString("ReturnUrl");

      if (!string.IsNullOrEmpty(returnUrl))
      {
        HttpContext.Session.Remove("ReturnUrl"); // Xóa ReturnUrl sau khi dùng
        return Redirect(returnUrl);
      }
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

    //HashPassword
    private string HashPassword(string password)
    {
      using (SHA256 sha256 = SHA256.Create())
      {
        byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
        return BitConverter.ToString(bytes).Replace("-", "").ToLower();
      }
    }

  //change password
  [HttpGet]
  public IActionResult ChangePassword()
  {
    return View();
  }
  [HttpPost]
  public async Task<IActionResult> ChangePassword(string currentPassword, string newPassword, string confirmPassword)
  {
    // Kiểm tra đăng nhập
    string userId = HttpContext.Session.GetString("UserId");
    if (string.IsNullOrEmpty(userId))
    {
      return RedirectToAction("Login");
    }

    // Lấy thông tin người dùng từ database
    var user = await _context.Users.FirstOrDefaultAsync(u => u.UserId.ToString() == userId);
    if (user == null)
    {
      return RedirectToAction("Login");
    }

    // Kiểm tra mật khẩu cũ
    if (!VerifyPassword(currentPassword, user.PasswordHash))
    {
      ModelState.AddModelError("", "Mật khẩu hiện tại không đúng.");
      return View();
    }

    // Kiểm tra mật khẩu mới có khớp với xác nhận mật khẩu không
    if (newPassword != confirmPassword)
    {
      ModelState.AddModelError("", "Mật khẩu mới và xác nhận mật khẩu không khớp.");
      return View();
    }

    // Cập nhật mật khẩu mới
    user.PasswordHash = HashPassword(newPassword);
    _context.Users.Update(user);
    await _context.SaveChangesAsync();

    ViewBag.Message = "Thay đổi mật khẩu thành công!";
    return View();
  }

  //Lưu giữ session
}
