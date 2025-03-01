using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcStarter.Models
{
    public class Request
    {
        [Key]
        public int RequestId { get; set; }
        public int? RequestorId { get; set; }

        public User Requestor { get; set; }
        public int? FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int? ItemId { get; set; }
        public FacilityItem FacilityItem { get; set; }
        public int QuantityRequested { get; set; }
        public DateTime RequestDate { get; set; } = DateTime.UtcNow;
        public string SeverityLevel { get; set; }
        public string Description { get; set; }
        public string Status { get; set; } = "Open";
        public string Remarks { get; set; }
        public DateTime? ClosedDate { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }  // This should store the UserId of the creator
        public string ClosureReason { get; set; }
        public virtual Comment? Comments { get; set; }
    }
}
