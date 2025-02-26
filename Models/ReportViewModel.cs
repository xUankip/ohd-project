using System.Collections.Generic;

namespace AspnetCoreMvcStarter.Models
{
  public class ReportViewModel
  {
    public int TotalRequests { get; set; }
    public Dictionary<int, int> RequestsByMonth { get; set; } = new Dictionary<int, int>();
    public Dictionary<string, int> RequestsByStatus { get; set; } = new Dictionary<string, int>();
    public double AverageProcessingTime { get; set; }
  }
}
