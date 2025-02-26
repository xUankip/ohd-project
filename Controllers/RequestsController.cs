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
                var requestorExists = _context.Users.Any(u => u.UserId == request.RequestorId);
                var facilityExists = _context.Facilities.Any(f => f.FacilityId == request.FacilityId);
                var itemExists = _context.FacilityItems.Any(i => i.ItemId == request.ItemId);

                if (!requestorExists || !facilityExists || !itemExists)
                {
                    ModelState.AddModelError("", "Invalid selections made.");
                    LoadDropdowns();
                    return View(request);
                }

                request.Status = "Open";
                request.RequestDate = DateTime.UtcNow;

                _context.Requests.Add(request);
                _context.SaveChanges();

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

        // ✅ Assign a Request to a User (GET: /Requests/Assign/{id})
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
            ViewBag.Assignees = assignees.Any() ? new SelectList(assignees, "UserId", "FullName") : null;

            return View(request);
        }

        // ✅ Handle Request Assignment (POST: /Requests/Assign/{id})
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Assign(int id, int RequestorId)
        {
            var request = _context.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

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
            var users = _context.Users.Where(u => u.IsActive).ToList();
            ViewBag.Users = users.Any() ? new SelectList(users, "UserId", "FullName") : null;

            var facilities = _context.Facilities.ToList();
            ViewBag.Facilities = facilities.Any() ? new SelectList(facilities, "FacilityId", "FacilityName") : null;

            var items = _context.FacilityItems.ToList();
            ViewBag.Items = items.Any() ? new SelectList(items, "ItemId", "ItemName") : null;
        }
    }
}
