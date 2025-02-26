using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AspnetCoreMvcStarter.Models;
using AspnetCoreMvcStarter.Data;
using System;
using System.Linq;

namespace AspnetCoreMvcStarter.Controllers
{
    public class RequestController : Controller
    {
        private readonly ApplicationDbContext _context;

        public RequestController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Request
        public IActionResult Index()
        {
            var requests = _context.Requests
                .Include(r => r.Requestor)
                .Include(r => r.Facility)
                .Include(r => r.FacilityItem)
                .ToList();
            return View(requests);
        }

        // GET: Request/Create
        public IActionResult Create()
        {
            ViewBag.Users = new SelectList(_context.Users, "UserId", "FullName");
            ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName");
            ViewBag.Items = new SelectList(_context.FacilityItems, "ItemId", "ItemName");
            return View();
        }

        [HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Request request, string commentText)
{
    if (ModelState.IsValid)
    {
        // Ensure all required fields are assigned
        request.Status = "Open";  // Default status
        request.RequestDate = DateTime.UtcNow;  // Set request date

        // ✅ Check if the related entities exist before saving the request
        var requestorExists = _context.Users.Any(u => u.UserId == request.RequestorId);
        var facilityExists = _context.Facilities.Any(f => f.FacilityId == request.FacilityId);
        var itemExists = _context.FacilityItems.Any(i => i.ItemId == request.ItemId);

        if (!requestorExists)
        {
            ModelState.AddModelError("", "Invalid Requestor selected.");
        }
        if (!facilityExists)
        {
            ModelState.AddModelError("", "Invalid Facility selected.");
        }
        if (!itemExists)
        {
            ModelState.AddModelError("", "Invalid Item selected.");
        }

        // If there are validation errors, return the form with errors
        if (!ModelState.IsValid)
        {
            ViewBag.Users = new SelectList(_context.Users, "UserId", "FullName", request.RequestorId);
            ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName", request.FacilityId);
            ViewBag.Items = new SelectList(_context.FacilityItems, "ItemId", "ItemName", request.ItemId);

            return View(request);
        }

        // ✅ Save the request
        _context.Requests.Add(request);
        _context.SaveChanges(); // Ensure RequestId is generated

        // ✅ Save the comment if provided
        if (!string.IsNullOrEmpty(commentText))
        {
            var comment = new Comment
            {
                RequestId = request.RequestId, // Now it has a valid ID
                UserId = request.RequestorId,
                CommentText = commentText,
                CreatedAt = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        return RedirectToAction(nameof(Index));
    }

    // Repopulate dropdowns if validation fails
    ViewBag.Users = new SelectList(_context.Users, "UserId", "FullName", request.RequestorId);
    ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName", request.FacilityId);
    ViewBag.Items = new SelectList(_context.FacilityItems, "ItemId", "ItemName", request.ItemId);

    return View(request);
}


        // GET: Request/Edit/{id}
        public IActionResult Edit(int id)
        {
            var request = _context.Requests.Find(id);
            if (request == null)
            {
                return NotFound();
            }

            ViewBag.Users = new SelectList(_context.Users, "UserId", "FullName", request.RequestorId);
            ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName", request.FacilityId);
            ViewBag.Items = new SelectList(_context.FacilityItems, "ItemId", "ItemName", request.ItemId);

            return View(request);
        }

        // POST: Request/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Request request)
        {
            if (ModelState.IsValid)
            {
                _context.Requests.Update(request);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            // Repopulate dropdowns
            ViewBag.Users = new SelectList(_context.Users, "UserId", "FullName", request.RequestorId);
            ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName", request.FacilityId);
            ViewBag.Items = new SelectList(_context.FacilityItems, "ItemId", "ItemName", request.ItemId);

            return View(request);
        }

        // GET: Request/Details/{id}
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

        // GET: Request/Delete/{id}
        public IActionResult Delete(int id)
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

        // POST: Request/Delete/{id}
        [HttpPost, ActionName("DeleteConfirmed")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var request = _context.Requests.Find(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
