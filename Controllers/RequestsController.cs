using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;

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
        [Route("Requests/Index")]
        public async Task<IActionResult> Index(string search = "", int page = 1, int pageSize = 5)
        {
          var query = _context.Requests
            .Include(r => r.Requestor)
            .Include(r => r.Facility)
            .Include(r => r.FacilityItem)
            .AsQueryable();
          if (!string.IsNullOrWhiteSpace(search))
          {
            search = search.ToLower();
            query = query.Where(r =>
              (r.Requestor.Username != null && r.Requestor.Username.ToLower().Contains(search)) ||
              (r.Facility.FacilityName != null && r.Facility.FacilityName.ToLower().Contains(search)) ||
              (r.FacilityItem.ItemName != null && r.FacilityItem.ItemName.ToLower().Contains(search)) ||
              (r.Status != null && r.Status.ToLower().Contains(search)) ||
              r.QuantityRequested.ToString().Contains(search)
            );
          }

          // Get total count for pagination
          var totalRequests = await query.CountAsync();

          // Apply ordering and pagination
          var requests = await query
            .OrderByDescending(r => r.RequestDate)
            .Skip((page - 1) * pageSize)
            .Take(pageSize)
            .ToListAsync();

          // Set pagination data
          ViewBag.CurrentPage = page;
          ViewBag.TotalPages = (int)Math.Ceiling((double)totalRequests / pageSize);
          ViewBag.Search = search;

          return View(requests);
        }


        // ✅ Show Request Details (GET: /Requests/Details/{id})
        public IActionResult Details(int id)
        {
          var request = _context.Requests
            .Include(r => r.Requestor)
            .Include(r => r.Facility)
            .Include(r => r.FacilityItem)
            .Include(r => r.Comments) // ✅ Include Comments
            .ThenInclude(c => c.User)
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

          // ✅ Removed success message
          TempData["Success"] = "Request successfully assigned!";
          return RedirectToAction("Index");
        }



// ✅ Edit Request (GET)
        public async Task<IActionResult> Edit(int id)
        {
          var request = await _context.Requests.FindAsync(id);
          if (request == null)
          {
            return NotFound();
          }

          LoadDropdowns();
          return View(request);
        }

        // ✅ Handle Request Edit (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Request request)
        {
          if (id != request.RequestId)
          {
            return NotFound();
          }

          if (!ModelState.IsValid)
          {
            LoadDropdowns();
            return View(request);
          }

          try
          {
            _context.Update(request);
            await _context.SaveChangesAsync();
            TempData["Success"] = "Request updated successfully!";
            return RedirectToAction(nameof(Index));
          }
          catch (DbUpdateConcurrencyException)
          {
            if (!_context.Requests.Any(r => r.RequestId == id))
            {
              return NotFound();
            }
            else
            {
              throw;
            }
          }
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

        [HttpPost]
        public async Task<IActionResult> UpdateStatus([FromBody] StatusUpdateRequest request)
        {
          if (request == null || request.RequestId <= 0 || string.IsNullOrEmpty(request.Status))
          {
            return Json(new { success = false, message = "Invalid data" });
          }

          var existingRequest = await _context.Requests.FindAsync(request.RequestId);
          if (existingRequest == null)
          {
            return Json(new { success = false, message = "Request not found" });
          }

          existingRequest.Status = request.Status;
          await _context.SaveChangesAsync();

          return Json(new { success = true, message = "Status updated successfully" });
        }

        public class StatusUpdateRequest
        {
          public int RequestId { get; set; }
          public string Status { get; set; }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int requestId, string commentText)
        {
          if (string.IsNullOrWhiteSpace(commentText))
          {
            TempData["Error"] = "Comment cannot be empty.";
            return RedirectToAction("Details", new { id = requestId });
          }

          var request = await _context.Requests.FindAsync(requestId);
          if (request == null)
          {
            return NotFound();
          }

          var comment = new Comment
          {
            RequestId = requestId,
            UserId = 1, // Replace with the actual logged-in user ID
            CommentText = commentText,
            CreatedAt = DateTime.UtcNow
          };

          _context.Comments.Add(comment);
          await _context.SaveChangesAsync();

          TempData["Success"] = "Comment added successfully!";
          return RedirectToAction("Details", new { id = requestId });
        }

    }
}
