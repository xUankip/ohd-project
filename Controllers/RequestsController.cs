using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Data;
using System;
using System.Linq;
using System.Collections.Generic;

namespace AspnetCoreMvcStarter.Controllers
{
    public class RequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ Show Request List (GET: /Requests)
        public IActionResult Index()
        {
            var requests = _context.Requests
                .Include(r => r.Requestor)
                .Include(r => r.Facility)
                .Include(r => r.FacilityItem)
                .ToList();
            return View(requests);
        }

        // ✅ Show Request Details (GET: /Requests/Details/{id})
        public IActionResult Details(int id)
        {
            var request = _context.Requests
                .Include(r => r.Requestor)
                .Include(r => r.Facility)
                .Include(r => r.FacilityItem)
                .FirstOrDefault(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // ✅ Create Request (GET: /Requests/Create)
        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Request request)
        {
    try
    {
        // Kiểm tra các trường bắt buộc
        if (request.FacilityId == null)
        {
            ModelState.AddModelError("FacilityId", "Vui lòng chọn cơ sở");
            LoadDropdowns();
            return View(request);
        }

        if (request.FacilityItemId == null)
        {
            ModelState.AddModelError("FacilityItemId", "Vui lòng chọn vật dụng");
            LoadDropdowns();
            return View(request);
        }

        if (request.QuantityRequested <= 0)
        {
            ModelState.AddModelError("QuantityRequested", "Số lượng phải lớn hơn 0");
            LoadDropdowns();
            return View(request);
        }

        if (string.IsNullOrEmpty(request.SeverityLevel))
        {
            ModelState.AddModelError("SeverityLevel", "Vui lòng chọn mức độ ưu tiên");
            LoadDropdowns();
            return View(request);
        }

        // Đặt các giá trị mặc định
        request.RequestDate = DateTime.UtcNow;
        request.RequestorId = 1; // Mặc định là user có id = 1
        request.Status = "Open";

        // Mặc định description nếu không có
        if (string.IsNullOrEmpty(request.Description))
        {
            request.Description = "No description provided";
        }

        // Mặc định remarks nếu không có
        if (string.IsNullOrEmpty(request.Remarks))
        {
            request.Remarks = "";
        }

        _context.Requests.Add(request);
        await _context.SaveChangesAsync();

        TempData["Success"] = "Tạo request thành công!";
        return RedirectToAction(nameof(Index));
    }
    catch (Exception ex)
    {
        // Log chi tiết lỗi
        Console.WriteLine($"Exception when creating request: {ex.Message}");
        Console.WriteLine($"Stack trace: {ex.StackTrace}");

        if (ex.InnerException != null)
        {
            Console.WriteLine($"Inner exception: {ex.InnerException.Message}");
        }

        ModelState.AddModelError("", "Lỗi khi lưu request: " + ex.Message);
        LoadDropdowns();
        return View(request);
    }
}

        // ✅ Assign or Transfer a Request (GET: /Requests/Assign/{id})
        public IActionResult Assign(int id)
        {
            var request = _context.Requests
                .Include(r => r.Requestor)
                .FirstOrDefault(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            // Fetch only active users with RoleId = 3 (Assignees)
            var availableUsers = _context.Users
                .Where(u => u.IsActive && u.RoleId == 3)
                .ToList();

            // Store the currently assigned user separately
            var currentAssignee = request.Requestor;

            // Remove the currently assigned user from the dropdown list
            if (request.RequestorId.HasValue)
            {
                availableUsers = availableUsers
                    .Where(u => u.UserId != request.RequestorId.Value)
                    .ToList();
            }

            ViewBag.Assignees = availableUsers.Any() ? new SelectList(availableUsers, "UserId", "FullName") : null;
            ViewBag.CurrentAssignee = currentAssignee;

            return View(request);
        }

        // ✅ Handle Request Assignment or Transfer (POST: /Requests/Assign/{id})
        [HttpPost]
        public IActionResult Assign(int requestId, int? RequestorId)
        {
            var request = _context.Requests.FirstOrDefault(r => r.RequestId == requestId);

            if (request == null)
            {
                return NotFound();
            }

            if (!RequestorId.HasValue)
            {
                TempData["Error"] = "Please select a valid user for assignment.";
                return RedirectToAction("Assign", new { id = requestId });
            }

            request.RequestorId = RequestorId.Value;
            _context.SaveChanges();

            TempData["Success"] = "Request successfully assigned!";
            return RedirectToAction("Index");
        }

        // ✅ Update Request Status (GET: /Requests/UpdateStatus/{id})
        public IActionResult UpdateStatus(int id)
        {
            var request = _context.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            ViewBag.StatusOptions = new List<SelectListItem>
            {
                new SelectListItem { Text = "New", Value = "New" },
                new SelectListItem { Text = "Pending", Value = "Pending" },
                new SelectListItem { Text = "In Progress", Value = "InProgress" },
                new SelectListItem { Text = "Completed", Value = "Completed" },
                new SelectListItem { Text = "Closed", Value = "Closed" }
            };

            return View(request);
        }

        // ✅ Handle Status Update (POST: /Requests/UpdateStatus/{id})
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string status)
        {
            var request = _context.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            request.Status = status;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // ✅ Revoke a Request (GET: /Requests/Revoke/{id})
        public IActionResult Revoke(int id)
        {
            var request = _context.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

        // ✅ Handle Request Revocation (POST: /Requests/RevokeConfirmed/{id})
        [HttpPost, ActionName("RevokeConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult RevokeConfirmed(int id)
        {
            var request = _context.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            request.RequestorId = null;
            request.Status = "Revoked";
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // ✅ Report Page (GET: /Requests/Report)
        public IActionResult Report()
        {
            var model = new ReportViewModel
            {
                TotalRequests = _context.Requests.Count(),
                RequestsByMonth = _context.Requests
                    .GroupBy(r => r.RequestDate.Month)
                    .ToDictionary(g => g.Key, g => g.Count()),
                RequestsByStatus = _context.Requests
                    .GroupBy(r => r.Status)
                    .ToDictionary(g => g.Key, g => g.Count())
            };

            return View(model);
        }

        // ✅ Load dropdown data
        private void LoadDropdowns()
        {
            var users = _context.Users.Where(u => u.IsActive && u.RoleId == 3).ToList();
            ViewBag.Users = users.Any() ? new SelectList(users, "UserId", "FullName") : null;

            var facilities = _context.Facilities.ToList();
            ViewBag.Facilities = facilities.Any() ? new SelectList(facilities, "FacilityId", "FacilityName") : null;

            var items = _context.FacilityItems.ToList();
            ViewBag.Items = items.Any() ? new SelectList(items, "FacilityItemId", "ItemName") : null;
        }
        [HttpGet]
        public IActionResult GetItemsByFacility(int facilityId)
        {
          var items = _context.FacilityItems
            .Where(i => i.FacilityId == facilityId)
            .Select(i => new { itemId = i.FacilityItemId, itemName = i.ItemName })
            .ToList();

          return Json(items);
        }
    }
}
