using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcStarter.Data;
using AspnetCoreMvcStarter.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using AspnetCoreMvcStarter.Filters;

namespace AspnetCoreMvcStarter.Controllers
{
  [AllowRoles(1)]
  public class DashboardController : Controller
  {
    private readonly ILogger<DashboardController> _logger;
    private readonly ApplicationDbContext _context;

    public DashboardController(ILogger<DashboardController> logger, ApplicationDbContext context)
    {
      _logger = logger;
      _context = context;
    }

    public async Task<IActionResult> Index()
    {
      var requestStats = await _context.Requests
        .GroupBy(r => r.Status)
        .Select(g => new RequestStatsViewModel { Status = g.Key, Count = g.Count() })
        .ToListAsync();

      var monthlyRequests = await _context.Requests
        .GroupBy(r => new { r.RequestDate.Year, r.RequestDate.Month })
        .Select(g => new MonthlyRequestStatsViewModel { Year = g.Key.Year, Month = g.Key.Month, Count = g.Count() })
        .OrderBy(g => g.Year).ThenBy(g => g.Month)
        .ToListAsync();

      var topItems = await _context.Requests
        .Where(r => r.FacilityItem != null)
        .GroupBy(r => r.FacilityItem.ItemName)
        .Select(g => new TopRequestedItemViewModel
        {
          ItemName = g.Key,
          RequestCount = g.Count()
        })
        .OrderByDescending(g => g.RequestCount)
        .Take(5)
        .ToListAsync();


      var dashboardViewModel = new DashboardViewModel
      {
        RequestStats = requestStats,
        MonthlyRequests = monthlyRequests,
        TopRequestedItems = topItems,
        TotalRequests = requestStats.Sum(r => r.Count),
        OpenRequests = requestStats.FirstOrDefault(s => s.Status == "Open")?.Count ?? 0,
        ApprovedRequests = requestStats.FirstOrDefault(s => s.Status == "Approved")?.Count ?? 0,
        PendingRequests = requestStats.FirstOrDefault(s => s.Status == "Pending")?.Count ?? 0
      };

      return View(dashboardViewModel);
    }

    public IActionResult Privacy()
    {
      return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
      return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
  }
}
