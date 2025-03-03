using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcStarter.Models
{
  public class Request
  {
    [Key]
    public int RequestId { get; set; }

    // ✅ Requestor (User who submitted the request)
    public int? RequestorId { get; set; }
    public virtual User? Requestor { get; set; }

    // ✅ Facility (Related facility)
    public int? FacilityId { get; set; }
    public virtual Facility? Facility { get; set; }

    // ✅ Facility Item (Requested item)
    public int? FacilityItemId { get; set; }
    public virtual FacilityItem? FacilityItem { get; set; }

    // ✅ Requested quantity
    [Required]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
    public int QuantityRequested { get; set; }

    // ✅ Request metadata
    public DateTime RequestDate { get; set; } = DateTime.UtcNow;
    public string? SeverityLevel { get; set; }
    public string? Description { get; set; }
    public string Status { get; set; } = "Open";

    // ✅ Additional remarks
    public string? Remarks { get; set; }

    // ✅ Closure information
    public DateTime? ClosedDate { get; set; }
    public string? ClosureReason { get; set; }

    // ✅ Comments (Allow multiple comments per request)
    public virtual ICollection<Comment>? Comments { get; set; } = new List<Comment>();
  }
}
