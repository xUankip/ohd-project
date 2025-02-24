using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Rendering;

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
        public async Task<IActionResult> Index()
        {
            var requests = await _context.Requests
                .Include(r => r.Facility)
                .Include(r => r.Requestor)
                .Include(r => r.FacilityItem)
                .ToListAsync();
            return View(requests);
        }

        // GET: Request/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var request = await _context.Requests
                .Include(r => r.Facility)
                .Include(r => r.Requestor)
                .FirstOrDefaultAsync(r => r.RequestId == id);

            if (request == null)
                return NotFound();

            return View(request);
        }

        // GET: Request/Create
        public IActionResult Create()
        {
          ViewBag.Users = new SelectList(_context.Users, "UserId", "FullName");
          ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName");
          ViewBag.FacilityItems = new SelectList(_context.FacilityItems, "ItemId", "ItemName");

          return View();
        }

        // POST: Request/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Request request)
        {
          if (ModelState.IsValid)
          {
            request.Status = "Open";  // Default status
            _context.Requests.Add(request);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
          }

          ViewBag.Users = new SelectList(_context.Users, "UserId", "FullName", request.RequestorId);
          ViewBag.Facilities = new SelectList(_context.Facilities, "FacilityId", "FacilityName", request.FacilityId);
          ViewBag.FacilityItems = new SelectList(_context.FacilityItems, "ItemId", "ItemName", request.ItemId);

          return View(request);
        }

        // GET: Request/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
                return NotFound();

            return View(request);
        }

        // POST: Request/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Request request)
        {
            if (id != request.RequestId)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(request);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(request);
        }

        // GET: Request/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request == null)
                return NotFound();

            return View(request);
        }

        // POST: Request/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var request = await _context.Requests.FindAsync(id);
            if (request != null)
            {
                _context.Requests.Remove(request);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
