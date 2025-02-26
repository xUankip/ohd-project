using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using AspnetCoreMvcStarter.Data;

namespace AspnetCoreMvcStarter.Controllers
{
    public class FacilityItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public FacilityItemController(ApplicationDbContext context)
        {
            _context = context;
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
        public async Task<IActionResult> Create(FacilityItem facilityItem)
        {
            if (ModelState.IsValid)
            {
                facilityItem.CreatedAt = DateTime.UtcNow;
                facilityItem.CreatedBy = 1; // Placeholder: thay bằng userId thực tế
                
                _context.FacilityItems.Add(facilityItem);
                await _context.SaveChangesAsync();
                
                return RedirectToAction("Details", "Facility", new { id = facilityItem.FacilityId });
            }
            
            ViewBag.FacilityId = facilityItem.FacilityId;
            return View(facilityItem);
        }

        // Form cập nhật FacilityItem
        public async Task<IActionResult> Edit(int id)
        {
            var facilityItem = await _context.FacilityItems
                .FirstOrDefaultAsync(i => i.ItemId == id && i.DeletedAt == null);
                
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
        public async Task<IActionResult> Edit(int id, FacilityItem facilityItem)
        {
            if (id != facilityItem.ItemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var existingItem = await _context.FacilityItems
                        .FirstOrDefaultAsync(i => i.ItemId == id && i.DeletedAt == null);
                        
                    if (existingItem == null)
                    {
                        return NotFound();
                    }
                    
                    // Cập nhật các thuộc tính
                    existingItem.ItemName = facilityItem.ItemName;
                    existingItem.ItemImage = facilityItem.ItemImage;
                    existingItem.Quantity = facilityItem.Quantity;
                    existingItem.Description = facilityItem.Description;
                    existingItem.UpdatedAt = DateTime.UtcNow;
                    existingItem.UpdatedBy = 1; // Placeholder: thay bằng userId thực tế
                    
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacilityItemExists(facilityItem.ItemId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                
                return RedirectToAction("Details", "Facility", new { id = facilityItem.FacilityId });
            }
            
            ViewBag.FacilityId = facilityItem.FacilityId;
            return View(facilityItem);
        }

        // Form xác nhận xóa FacilityItem
        public async Task<IActionResult> Delete(int id)
        {
            var facilityItem = await _context.FacilityItems
                .FirstOrDefaultAsync(i => i.ItemId == id && i.DeletedAt == null);
                
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
                .FirstOrDefaultAsync(i => i.ItemId == id && i.DeletedAt == null);
                
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
                .FirstOrDefaultAsync(i => i.ItemId == id && i.DeletedAt == null);
                
            if (facilityItem == null)
            {
                return NotFound();
            }

            return View(facilityItem);
        }

        private bool FacilityItemExists(int id)
        {
            return _context.FacilityItems
                .Any(i => i.ItemId == id && i.DeletedAt == null);
        }
    }
}