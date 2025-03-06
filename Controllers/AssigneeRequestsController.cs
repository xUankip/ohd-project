using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Data;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using AspnetCoreMvcStarter.Filters;

namespace AspnetCoreMvcStarter.Controllers
{
  [AllowRoles(3)]
    public class AssigneeRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AssigneeRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Hiển thị danh sách Request được giao cho Assignee
        [Route("AssigneeRequests/Index")]
        public async Task<IActionResult> Index(string search = "", int page = 1, int pageSize = 10)
        {
            // Lấy userId từ session
            string userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                TempData["Error"] = "Vui lòng đăng nhập để xem các yêu cầu được giao.";
                return RedirectToAction("Login", "Account");
            }

            var query = _context.Requests
                .Include(r => r.Requestor)
                .Include(r => r.Facility)
                .Include(r => r.FacilityItem)
                .Where(r => r.AssigneeId == userId) // Chỉ lấy request mà user hiện tại là assignee
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

        // Xem chi tiết Request
        public async Task<IActionResult> Details(int id)
        {
            string userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                TempData["Error"] = "Vui lòng đăng nhập để xem chi tiết yêu cầu.";
                return RedirectToAction("Login", "Account");
            }

            var request = await _context.Requests
                .Include(r => r.Requestor)
                .Include(r => r.Facility)
                .Include(r => r.FacilityItem)
                .Include(r => r.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            // Kiểm tra xem người dùng có quyền xem request này không
            if (request.AssigneeId != userId)
            {
                TempData["Error"] = "Bạn không có quyền xem yêu cầu này.";
                return RedirectToAction(nameof(Index));
            }

            return View(request);
        }

        // Cập nhật trạng thái Request
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

        // Thêm comment vào Request
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddComment(int requestId, string commentText)
        {
            if (string.IsNullOrWhiteSpace(commentText))
            {
                TempData["Error"] = "Nội dung bình luận không được để trống.";
                return RedirectToAction("Details", new { id = requestId });
            }

            string userIdStr = HttpContext.Session.GetString("UserId");
            if (string.IsNullOrEmpty(userIdStr) || !int.TryParse(userIdStr, out int userId))
            {
                TempData["Error"] = "Vui lòng đăng nhập để thêm bình luận.";
                return RedirectToAction("Login", "Account");
            }

            var request = await _context.Requests.FindAsync(requestId);
            if (request == null)
            {
                return NotFound();
            }

            // Kiểm tra xem người dùng có quyền thêm comment vào request này không
            if (request.AssigneeId != userId)
            {
                TempData["Error"] = "Bạn không có quyền thêm bình luận vào yêu cầu này.";
                return RedirectToAction(nameof(Index));
            }

            var comment = new Comment
            {
                RequestId = requestId,
                UserId = userId,
                CommentText = commentText,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Thêm bình luận thành công!";
            return RedirectToAction("Details", new { id = requestId });
        }

        // Class để nhận dữ liệu cập nhật trạng thái
        public class StatusUpdateRequest
        {
            public int RequestId { get; set; }
            public string Status { get; set; }
        }


    }


}
