using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Data;
using System;
using System.Collections.Generic;
using System.Linq;

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

        // ✅ Show Create Request Form (GET: /Requests/Create)
        public IActionResult Create()
        {
            LoadDropdowns();
            return View();
        }

        // ✅ Handle Create Request Form Submission (POST: /Requests/Create)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Request request, string commentText)
        {
            if (!ModelState.IsValid)
            {
                LoadDropdowns();
                return View(request);
            }

            try
            {
                // Validate Foreign Keys before saving
                if (!_context.Users.Any(u => u.UserId == request.RequestorId) ||
                    !_context.Facilities.Any(f => f.FacilityId == request.FacilityId) ||
                    !_context.FacilityItems.Any(i => i.ItemId == request.ItemId))
                {
                    ModelState.AddModelError("", "Invalid selection for Requestor, Facility, or Item.");
                    LoadDropdowns();
                    return View(request);
                }

                // Assign default values for missing fields
                request.Status = "Open";
                request.RequestDate = DateTime.UtcNow;

                _context.Requests.Add(request);
                _context.SaveChanges();

                // Save comment if provided
                if (!string.IsNullOrEmpty(commentText))
                {
                    var comment = new Comment
                    {
                        RequestId = request.RequestId,
                        UserId = request.RequestorId,
                        CommentText = commentText,
                        CreatedAt = DateTime.UtcNow
                    };

                    _context.Comments.Add(comment);
                    _context.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error saving request: " + ex.Message);
                ModelState.AddModelError("", "An error occurred while saving the request.");
                LoadDropdowns();
                return View(request);
            }
        }

        // ✅ Assign a Request to a User
        public IActionResult Assign(int id)
        {
            var request = _context.Requests
                .Include(r => r.Requestor)
                .FirstOrDefault(r => r.RequestId == id);

            if (request == null)
            {
                return NotFound();
            }

            var assignees = _context.Users.Where(u => u.IsActive).ToList();
            ViewBag.Assignees = new SelectList(assignees, "UserId", "FullName");

            return View(request);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Assign(int id, int RequestorId)
        {
            var request = _context.Requests.Find(id);
            if (request == null) return NotFound();

            if (!_context.Users.Any(u => u.UserId == RequestorId))
            {
                ModelState.AddModelError("", "Invalid Requestor selected.");
                LoadDropdowns();
                return View(request);
            }

            request.RequestorId = RequestorId;
            request.Status = "Assigned";
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // ✅ Update Request Status
        public IActionResult UpdateStatus(int id)
        {
            var request = _context.Requests.Find(id);
            if (request == null) return NotFound();

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult UpdateStatus(int id, string status)
        {
            var request = _context.Requests.Find(id);
            if (request == null) return NotFound();

            request.Status = status;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        // ✅ Generate Report (GET: /Requests/Report)
        public IActionResult Report()
        {
            var totalRequests = _context.Requests.Count();

            var requestsByMonth = _context.Requests
                .GroupBy(r => r.RequestDate.Month)
                .Select(g => new { Month = g.Key, Count = g.Count() })
                .ToDictionary(g => g.Month, g => g.Count);

            var requestsByStatus = _context.Requests
                .GroupBy(r => r.Status)
                .Select(g => new { Status = g.Key, Count = g.Count() })
                .ToDictionary(g => g.Status, g => g.Count);





            var report = new ReportViewModel
            {
                TotalRequests = totalRequests,
                RequestsByMonth = requestsByMonth,
                RequestsByStatus = requestsByStatus,

            };

            return View(report);
        }

        // ✅ Load dropdown data
        private void LoadDropdowns()
        {
            ViewBag.Users = new SelectList(_context.Users.Where(u => u.IsActive), "UserId", "FullName");
            ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName");
            ViewBag.Items = new SelectList(_context.FacilityItems, "ItemId", "ItemName");
        }
    }
}
