using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using AspnetCoreMvcStarter.Models.Enums;

namespace AspnetCoreMvcStarter.Models
{
  public class Facility
  {
    [Key]
    public int FacilityID { get; set; }

    [Required]
    [StringLength(100)]
    public string FacilityName { get; set; }

    public string Description { get; set; }

    [Required]
    public int FacilityHeadID { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int? DeletedBy { get; set; }

    // Navigation properties
    [ForeignKey("FacilityHeadID")]
    public virtual User FacilityHead { get; set; }
    public virtual ICollection<User_Facility> UserFacilities { get; set; }
    public virtual ICollection<Item> Items { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
  }
}
