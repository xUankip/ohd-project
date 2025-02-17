using System.ComponentModel.DataAnnotations;
using AspnetCoreMvcStarter.Models.Enums;

namespace AspnetCoreMvcStarter.Models
{
  public class Request
  {
    [Key]
    public int RequestID { get; set; }

    [Required]
    public int RequestorID { get; set; }

    [Required]
    public int FacilityID { get; set; }

    public int? ItemID { get; set; }
    public int? QuantityRequested { get; set; }

    public DateTime RequestDate { get; set; } = DateTime.UtcNow;

    [Required]
    public string SeverityLevel { get; set; }

    [Required]
    public string Description { get; set; }

    [Required]
    public string Status { get; set; } = "Open";

    public string Remarks { get; set; }
    public DateTime? ClosedDate { get; set; }
    public string ClosureReason { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int? DeletedBy { get; set; }

    // Navigation properties
    public virtual User Requestor { get; set; }
    public virtual Facility Facility { get; set; }
    public virtual Item Item { get; set; }
  }
}

