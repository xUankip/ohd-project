using System.Security.Cryptography;
using System.Text;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using AspnetCoreMvcStarter.Filters;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace AspnetCoreMvcStarter.Controllers
{
  [AllowRoles(1)]
    public class UserController : Controller
    {
        private readonly ApplicationDbContext _context;

        public UserController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Users
        [HttpGet]
        [Route("User")]
        public async Task<IActionResult> Index(string search = "", int page = 1, int pageSize = 10)
        {
          var query = _context.Users
            .Include(u => u.Role)
            .AsQueryable();

          // Apply search filter if a search term is provided
          if (!string.IsNullOrWhiteSpace(search))
          {
            search = search.ToLower();
            query = query.Where(u =>
              (u.Username != null && u.Username.ToLower().Contains(search)) ||
              (u.Email != null && u.Email.ToLower().Contains(search)) ||
              (u.Role != null && u.Role.RoleName.ToLower().Contains(search)) ||
              (u.Phone != null && u.Phone.Contains(search))
            );
          }

          var totalUsers = await query.CountAsync();
          var users = await query
            .OrderByDescending(u => u.CreatedAt)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

          ViewBag.CurrentPage = page;
          ViewBag.TotalPages = (int)Math.Ceiling((double)totalUsers / pageSize);
          ViewBag.Search = search;

          return View(users);
        }


        // GET: Users/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users.Include(u => u.Role).FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null) return NotFound();

            return View(user);
        }

        // GET: Users/Create
        public IActionResult Create()
        {
            ViewBag.RoleSelectList = new SelectList(_context.UserRoles, "RoleId", "RoleName");
            ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName");
            return View();
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        // POST: Users/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Username,PasswordHash,Email,RoleId,FullName,Phone,IsActive")] User user, int[] selectedFacilities)
          {
              Console.WriteLine("____"+user.RoleId);
              // 🔍 Kiểm tra Username hoặc Email đã tồn tại chưa
              bool isUsernameTaken = await _context.Users.AnyAsync(u => u.Username == user.Username);
              bool isEmailTaken = await _context.Users.AnyAsync(u => u.Email == user.Email);

              if (isUsernameTaken)
              {
                ModelState.AddModelError("Username", "Tên người dùng đã tồn tại. Vui lòng chọn tên khác.");
              }
              if (isEmailTaken)
              {
                ModelState.AddModelError("Email", "Email đã được sử dụng. Vui lòng chọn email khác.");
              }
              // Log ModelState errors
              if (!ModelState.IsValid)
              {
                  foreach (var key in ModelState.Keys)
                  {
                      var errors = ModelState[key].Errors;
                      foreach (var error in errors)
                      {
                          Console.WriteLine($"Key: {key}, Error: {error.ErrorMessage}");
                      }
                  }

                  // Re-populate dropdowns before returning view
                  ViewBag.RoleSelectList = new SelectList(_context.UserRoles, "RoleId", "RoleName");
                  ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName");
                  return View(user);
              }

              try
              {
                  // Get role details
                  var role = await _context.UserRoles.FindAsync(user.RoleId);
                  Console.WriteLine($"User RoleId: {user.RoleId}");
                  if (role == null)
                  {
                      ModelState.AddModelError("RoleId", "Vai trò không tồn tại");
                      ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName");
                      return View(user);
                  }

                  // Hash the password
                  user.PasswordHash = HashPassword(user.PasswordHash);

                  // Set creation timestamp
                  user.CreatedAt = DateTime.UtcNow;

                  // Set role
                  user.Role = role;

                  // Add the user
                  _context.Users.Add(user);
                  await _context.SaveChangesAsync();

                  // Add facility assignments if any were selected
                  if (selectedFacilities != null && selectedFacilities.Length > 0)
                  {
                      foreach (var facilityId in selectedFacilities)
                      {
                          var userFacility = new UserFacility
                          {
                              UserId = user.UserId,
                              FacilityId = facilityId
                          };
                          _context.UserFacilities.Add(userFacility);
                      }
                      await _context.SaveChangesAsync();
                  }

                  return RedirectToAction(nameof(Index));
              }
              catch (Exception ex)
              {
                  ModelState.AddModelError("", "Có lỗi xảy ra khi tạo người dùng: " + ex.Message);
                  Console.WriteLine("Lỗi khi lưu user: " + ex.Message);

                  // Re-populate dropdowns before returning view
                  ViewBag.RoleSelectList = new SelectList(_context.UserRoles, "RoleId", "RoleName");
                  ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName");
                  return View(user);
              }
          }
        // GET: Users/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users.FindAsync(id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: Users/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UserId,Username,Email,FullName,Phone,IsActive")] User user)
        {
          string userIdStr = HttpContext.Session.GetString("UserId");
          int? userId = !string.IsNullOrEmpty(userIdStr) ? int.Parse(userIdStr) : null;

          if (ModelState.IsValid)
          {
            try
            {
              var existingUser = await _context.Users.FindAsync(userId);
              if (existingUser == null)
                return NotFound();

              // Cập nhật các trường từ form
              existingUser.Username = user.Username;
              existingUser.Email = user.Email;
              existingUser.FullName = user.FullName;
              existingUser.Phone = user.Phone;
              existingUser.IsActive = user.IsActive;
              existingUser.UpdatedAt = DateTime.Now;

              _context.Update(existingUser);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
            }
            catch (DbUpdateConcurrencyException)
            {
              if (!UserExists(id))
                return NotFound();
              else
                throw;
            }
          }
          return View(user);
        }

        private bool UserExists(int id)
        {
          return _context.Users.Any(e => e.UserId == id);
        }
        // GET: Users/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();

            var user = await _context.Users.FirstOrDefaultAsync(m => m.UserId == id);
            if (user == null) return NotFound();

            return View(user);
        }

        // POST: Users/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
