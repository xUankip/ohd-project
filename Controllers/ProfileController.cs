// ProfileController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using System.Threading.Tasks;

namespace AspnetCoreMvcStarter.Controllers
{
  public class ProfileController : Controller
  {
    private readonly ApplicationDbContext _context;

    public ProfileController(ApplicationDbContext context)
    {
      _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
      // Kiểm tra đăng nhập
      if (!HttpContext.Session.TryGetValue("UserId", out var userIdBytes))
      {
        return RedirectToAction("Login", "Auth");
      }

      int userId = int.Parse(HttpContext.Session.GetString("UserId"));

      // Lấy thông tin người dùng từ database
      var user = await _context.Users
        .Include(u => u.Role)
        .FirstOrDefaultAsync(u => u.UserId == userId);

      if (user == null)
      {
        return NotFound();
      }

      return View(user);
    }
  }
}
