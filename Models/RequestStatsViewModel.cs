namespace AspnetCoreMvcStarter.Models;

public class RequestStatsViewModel
{
  public string Status { get; set; }
  public int Count { get; set; }
}

public class MonthlyRequestStatsViewModel
{
  public int Year { get; set; }
  public int Month { get; set; }
  public int Count { get; set; }
}
