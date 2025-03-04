using System.Collections.Generic;

namespace AspnetCoreMvcStarter.Models
{
  public class DashboardViewModel
  {
    // Request status distribution data
    public List<RequestStatsViewModel> RequestStats { get; set; } = new List<RequestStatsViewModel>();

    // Monthly request trends data
    public List<MonthlyRequestStatsViewModel> MonthlyRequests { get; set; } = new List<MonthlyRequestStatsViewModel>();

    // Quick statistics
    public int TotalRequests { get; set; }
    public int OpenRequests { get; set; }
    public int ApprovedRequests { get; set; }
    public int PendingRequests { get; set; }
    public int InProgressRequests { get; set; }
    public int RejectedRequests { get; set; }

    // Top requested items (optional, can be populated in controller)
    public List<TopRequestedItemViewModel> TopRequestedItems { get; set; } = new List<TopRequestedItemViewModel>();
  }

  // Optional ViewModel for top requested items
  public class TopRequestedItemViewModel
  {
    public string ItemName { get; set; }
    public int RequestCount { get; set; }
  }

}
