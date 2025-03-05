using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Filters;

namespace AspnetCoreMvcStarter.Controllers

{
   [AllowRoles(1,2)]
    public class FacilityItemController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FacilityItemController(
            ApplicationDbContext context,
            IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            _hostEnvironment = hostEnvironment;
        }

        // Form tạo mới FacilityItem (đã có facilityId)
        public IActionResult Create(int facilityId)
        {
            ViewBag.FacilityId = facilityId;
            return View();
        }

        // Xử lý POST tạo mới FacilityItem
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(FacilityItem facilityItem,
          IFormFile ImageFile,
          string ImageUploadType)
        {
          // Remove ItemImage validation if file is being uploaded
          if (ImageUploadType == "file")
          {
            ModelState.Remove("ItemImage");
          }

          if (ModelState.IsValid)
          {
            // Handle image upload
            if (ImageUploadType == "file" && ImageFile != null && ImageFile.Length > 0)
            {
              // Create unique filename
              string wwwRootPath = _hostEnvironment.WebRootPath;
              string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
              string extension = Path.GetExtension(ImageFile.FileName);
              string uniqueFileName = $"{fileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";
              string path = Path.Combine(wwwRootPath + "/images/facility-items/", uniqueFileName);

              // Ensure directory exists
              Directory.CreateDirectory(Path.Combine(wwwRootPath, "images/facility-items/"));

              // Save file
              using (var fileStream = new FileStream(path, FileMode.Create))
              {
                await ImageFile.CopyToAsync(fileStream);
              }

              // Save relative path to database
              facilityItem.ItemImage = $"/images/facility-items/{uniqueFileName}";
            }

            facilityItem.CreatedAt = DateTime.UtcNow;
            facilityItem.CreatedBy = 1; // Placeholder: replace with actual userId

            _context.FacilityItems.Add(facilityItem);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", "Facility", new { id = facilityItem.FacilityId });
          }

          ViewBag.FacilityId = facilityItem.FacilityId;
          return View(facilityItem);
        }

        // Xử lý POST cập nhật FacilityItem
        // Form chỉnh sửa FacilityItem
public async Task<IActionResult> Edit(int id)
{
    var facilityItem = await _context.FacilityItems
        .FirstOrDefaultAsync(i => i.FacilityItemId == id && i.DeletedAt == null);

    if (facilityItem == null)
    {
        return NotFound();
    }

    ViewBag.FacilityId = facilityItem.FacilityId;
    return View(facilityItem);
}

// Xử lý POST cập nhật FacilityItem
[HttpPost]
[ValidateAntiForgeryToken]
public async Task<IActionResult> Edit(int id, FacilityItem facilityItem, IFormFile ImageFile)
{
    if (id != facilityItem.FacilityItemId)
    {
        return NotFound();
    }

    // Validate model state before processing
    if (!ModelState.IsValid)
    {
        ViewBag.FacilityId = facilityItem.FacilityId;
        return View(facilityItem);
    }

    // Tìm entity trong database
    var existingItem = await _context.FacilityItems
        .FirstOrDefaultAsync(i => i.FacilityItemId == id && i.DeletedAt == null);

    if (existingItem == null)
    {
        return NotFound();
    }

    try
    {
        // Xử lý upload hình ảnh
        if (ImageFile != null && ImageFile.Length > 0)
        {
            string wwwRootPath = _hostEnvironment.WebRootPath;
            string fileName = Path.GetFileNameWithoutExtension(ImageFile.FileName);
            string extension = Path.GetExtension(ImageFile.FileName);
            string uniqueFileName = $"{fileName}_{DateTime.Now.ToString("yyyyMMddHHmmss")}{extension}";
            string path = Path.Combine(wwwRootPath, "images", "facility-items", uniqueFileName);

            // Tạo thư mục nếu chưa tồn tại
            Directory.CreateDirectory(Path.GetDirectoryName(path));

            // Lưu file mới
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await ImageFile.CopyToAsync(fileStream);
            }

            // Xóa file cũ nếu tồn tại
            if (!string.IsNullOrEmpty(existingItem.ItemImage))
            {
                string oldImagePath = Path.Combine(wwwRootPath.TrimEnd('/'), existingItem.ItemImage.TrimStart('/'));
                if (System.IO.File.Exists(oldImagePath))
                {
                    System.IO.File.Delete(oldImagePath);
                }
            }

            existingItem.ItemImage = $"/images/facility-items/{uniqueFileName}";
        }

        // Cập nhật các thuộc tính khác
        existingItem.ItemName = facilityItem.ItemName;
        existingItem.Quantity = facilityItem.Quantity;
        existingItem.Description = facilityItem.Description;

        // Cập nhật thông tin
        existingItem.UpdatedAt = DateTime.UtcNow;
        existingItem.UpdatedBy = 1; // Placeholder: replace with actual userId

        // Lưu thay đổi
        await _context.SaveChangesAsync();

        // Chuyển hướng sau khi lưu thành công
        return RedirectToAction("Details", "Facility", new { id = existingItem.FacilityId });
    }
    catch (Exception ex)
    {
        // Xử lý nếu có lỗi
        ModelState.AddModelError("", "Có lỗi xảy ra khi lưu thay đổi: " + ex.Message);
        ViewBag.FacilityId = facilityItem.FacilityId;
        return View(facilityItem);
    }
}


        // Form xác nhận xóa FacilityItem
        public async Task<IActionResult> Delete(int id)
        {
            var facilityItem = await _context.FacilityItems
                .FirstOrDefaultAsync(i => i.FacilityItemId == id && i.DeletedAt == null);

            if (facilityItem == null)
            {
                return NotFound();
            }

            return View(facilityItem);
        }

        // Xử lý POST xóa FacilityItem (soft delete)
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facilityItem = await _context.FacilityItems
                .FirstOrDefaultAsync(i => i.FacilityItemId == id && i.DeletedAt == null);

            if (facilityItem == null)
            {
                return NotFound();
            }

            var facilityId = facilityItem.FacilityId;

            facilityItem.DeletedAt = DateTime.UtcNow;
            facilityItem.DeletedBy = 1; // Placeholder: thay bằng userId thực tế

            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Facility", new { id = facilityId });
        }

        // Xem chi tiết FacilityItem
        public async Task<IActionResult> Details(int id)
        {
            var facilityItem = await _context.FacilityItems
                .FirstOrDefaultAsync(i => i.FacilityItemId == id && i.DeletedAt == null);

            if (facilityItem == null)
            {
                return NotFound();
            }

            return View(facilityItem);
        }

        private bool FacilityItemExists(int id)
        {
            return _context.FacilityItems
                .Any(i => i.FacilityItemId == id && i.DeletedAt == null);
        }
    }
}
