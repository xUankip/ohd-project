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

        // ✅ Handle Request Creation (POST: /Requests/Create)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Request request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    request.RequestDate = DateTime.UtcNow; // Set request date
                    request.CreatedAt = DateTime.UtcNow;   // Set creation timestamp
                    request.CreatedBy = 1; // Placeholder for actual user
                    request.Status = "Open"; // Default status

                    _context.Requests.Add(request);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log exception
                    Console.WriteLine($"Exception: {ex.Message}");
                    ModelState.AddModelError("", "Error saving request. " + ex.Message);
                }
            }
            else
            {
                var errors = string.Join("; ", ModelState.Values
                    .SelectMany(x => x.Errors)
                    .Select(x => x.ErrorMessage));

                Console.WriteLine($"Validation errors: {errors}");
            }

            LoadDropdowns();
            return View(request);
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
            ViewBag.Items = items.Any() ? new SelectList(items, "ItemId", "ItemName") : null;
        }
    }
}
