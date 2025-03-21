using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcStarter.Models
{
    public class Facility
    {
        [Key]
        public int FacilityId { get; set; }

        [Required, MaxLength(100)]
        public string FacilityName { get; set; }

        public string Description { get; set; }

        public int? FacilityHeadId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public int CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public int? DeletedBy { get; set; }

        [ForeignKey("FacilityHeadId")]
        public virtual User FacilityHead { get; set; }
    }
}
