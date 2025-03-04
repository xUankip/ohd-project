using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Filters;

namespace AspnetCoreMvcStarter.Controllers
{
  [AllowRoles(1,2)]

    public class FacilityController : Controller

    {
        private readonly ApplicationDbContext _context;

        public FacilityController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Danh sách Facility
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
          var totalFacilities = await _context.Facilities.CountAsync();
            var facilities = await _context.Facilities
                .Include(f => f.FacilityHead)
                .Where(f => f.DeletedAt == null)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalFacilities / pageSize);
            return View(facilities);
        }

        // Xem chi tiết Facility
        public async Task<IActionResult> Details(int id)
        {
            var facility = await _context.Facilities
                .Include(f => f.FacilityHead)
                .FirstOrDefaultAsync(f => f.FacilityId == id && f.DeletedAt == null);

            if (facility == null)
            {
                return NotFound();
            }

            // Lấy danh sách các items thuộc facility này
            ViewBag.FacilityItems = await _context.FacilityItems
                .Where(item => item.FacilityId == id && item.DeletedAt == null)
                .ToListAsync();

            return View(facility);
        }

        // Form tạo mới Facility
        public async Task<IActionResult> Create()
        {
            // Lấy danh sách users để chọn facility head
            ViewBag.Users = await _context.Users
                .Where(u => u.DeletedAt == null)
                .ToListAsync();

            return View();
        }

        // Xử lý POST tạo mới Facility
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Facility facility)
        {
            // Loại bỏ validation error cho FacilityHead nếu có
            if (ModelState.ContainsKey("FacilityHead"))
            {
                ModelState.Remove("FacilityHead");
            }

            if (ModelState.IsValid)
            {
                try
                {
                    facility.CreatedAt = DateTime.UtcNow;
                    facility.CreatedBy = 1; // Placeholder

                    _context.Facilities.Add(facility);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log exception
                    Console.WriteLine($"Exception: {ex.Message}");
                    ModelState.AddModelError("", "Không thể lưu dữ liệu. Lỗi: " + ex.Message);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));

                Console.WriteLine($"Validation errors: {errors}");
            }

            // Nếu có lỗi, quay lại form
            ViewBag.Users = await _context.Users
                .Where(u => u.DeletedAt == null)
                .ToListAsync();

            return View(facility);
        }

           // GET: Facility/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var facility = await _context.Facilities
                .FirstOrDefaultAsync(m => m.FacilityId == id && m.DeletedAt == null);

            if (facility == null)
            {
                return NotFound();
            }

            // Populate users for the dropdown
            ViewBag.Users = await _context.Users
                .Where(u => u.DeletedAt == null)
                .ToListAsync();

            return View(facility);
        }

        // POST: Facility/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Facility facility)
        {
          // Cập nhật trực tiếp
          facility.UpdatedAt = DateTime.UtcNow;
          facility.UpdatedBy = 1;

          _context.Entry(facility).State = EntityState.Modified;

          // Không muốn cập nhật CreatedAt và CreatedBy
          _context.Entry(facility).Property(x => x.CreatedAt).IsModified = false;
          _context.Entry(facility).Property(x => x.CreatedBy).IsModified = false;

          try
          {
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
          }
          catch (Exception ex)
          {
            Console.WriteLine($"Lỗi: {ex.Message}");
            ModelState.AddModelError(string.Empty, ex.Message);
          }

          ViewBag.Users = await _context.Users
            .Where(u => u.DeletedAt == null)
            .ToListAsync();

          return View(facility);
        }
        //

        // Form xác nhận xóa Facility
        public async Task<IActionResult> Delete(int id)
        {
            var facility = await _context.Facilities
                .Include(f => f.FacilityHead)
                .FirstOrDefaultAsync(f => f.FacilityId == id && f.DeletedAt == null);

            if (facility == null)
            {
                return NotFound();
            }

            return View(facility);
        }

        // Xử lý POST xóa Facility (soft delete)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facility = await _context.Facilities
                .FirstOrDefaultAsync(f => f.FacilityId == id && f.DeletedAt == null);

            if (facility == null)
            {
                return NotFound();
            }

            facility.DeletedAt = DateTime.UtcNow;
            facility.DeletedBy = 1; // Placeholder: thay bằng userId thực tế từ người dùng đăng nhập

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacilityExists(int id)
        {
            return _context.Facilities
                .Any(f => f.FacilityId == id && f.DeletedAt == null);
        }
    }
}
