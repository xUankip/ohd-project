using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Data;
using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;

namespace AspnetCoreMvcStarter.Controllers
{
    public class HistoryController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly EmailService _emailService;

        public HistoryController(ApplicationDbContext context, EmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        [Route("History/Index")]
        public async Task<IActionResult> Index(string search = "", int page = 1, int pageSize = 10)
        {
            string userIdStr = HttpContext.Session.GetString("UserId");
            int? currentUserId = !string.IsNullOrEmpty(userIdStr) ? int.Parse(userIdStr) : null;
            if (!currentUserId.HasValue)
            {
                currentUserId = 14; // Giá trị mặc định
            }

            var query = _context.Requests
                .Include(r => r.Requestor)
                .Include(r => r.Facility)
                .Include(r => r.FacilityItem)
                .AsQueryable();

            query = query.Where(r => r.RequestorId == currentUserId.Value);

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

            var totalRequests = await query.CountAsync();
            var requests = await query
                .OrderByDescending(r => r.RequestDate)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)totalRequests / pageSize);
            ViewBag.Search = search;

            return View(requests);
        }

        public IActionResult Details(int id)
        {
            var request = _context.Requests
                .Include(r => r.Requestor)
                .Include(r => r.Facility)
                .Include(r => r.FacilityItem)
                .Include(r => r.Comments)
                .ThenInclude(c => c.User)
                .FirstOrDefault(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            return View(request);
        }

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

                request.RequestDate = DateTime.UtcNow;

                string userIdStr = HttpContext.Session.GetString("UserId");
                int? userId = !string.IsNullOrEmpty(userIdStr) ? int.Parse(userIdStr) : null;
                if (userId.HasValue)
                {
                  request.RequestorId = userId.Value;
                  request.AssigneeId = userId.Value;
                }
                else
                {
                  request.RequestorId = 1;
                  request.AssigneeId = 1;
                }

                request.AssigneeId = null;

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

                // Gửi email thông báo
                await _emailService.SendEmailAsync(
                    "Thông báo: Yêu cầu mới đã được tạo",
                    $"Một yêu cầu mới đã được tạo bởi người dùng {request.RequestorId}. Chi tiết yêu cầu:\n" +
                    $"Cơ sở: {request.FacilityId}\n" +
                    $"Vật dụng: {request.FacilityItemId}\n" +
                    $"Số lượng: {request.QuantityRequested}\n" +
                    $"Mức độ ưu tiên: {request.SeverityLevel}\n" +
                    $"Mô tả: {request.Description}"
                );

                TempData["Success"] = "Tạo request thành công!";
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
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

          string userIdStr = HttpContext.Session.GetString("UserId");
          int? userId = !string.IsNullOrEmpty(userIdStr) ? int.Parse(userIdStr) : null;

          var comment = new Comment
          {
            RequestId = requestId,
            UserId = userId,
            CommentText = commentText,
            CreatedAt = DateTime.UtcNow
          };

          _context.Comments.Add(comment);
          await _context.SaveChangesAsync();

          TempData["Success"] = "Comment added successfully!";
          return RedirectToAction("Details", new { id = requestId });
        }
        private void LoadDropdowns()
        {
            var users = _context.Users.Where(u => u.IsActive && u.RoleId == 3).ToList();
            ViewBag.Users = users.Any() ? new SelectList(users, "UserId", "FullName") : null;

            var facilities = _context.Facilities.ToList();
            ViewBag.Facilities = facilities.Any() ? new SelectList(facilities, "FacilityId", "FacilityName") : null;

            var items = _context.FacilityItems.ToList();
            ViewBag.Items = items.Any() ? new SelectList(items, "FacilityItemId", "ItemName") : null;
        }
    }
}
