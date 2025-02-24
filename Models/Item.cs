using System.ComponentModel.DataAnnotations;
using AspnetCoreMvcStarter.Models;

namespace AspnetCoreMvcStarter.Models
{
  public class Item
  {
    [Key]
    public int ItemID { get; set; }

    [Required]
    [StringLength(100)]
    public string ItemName { get; set; }

    public string ItemImage { get; set; }

    [Required]
    public int FacilityID { get; set; }

    [Required]
    public int Quantity { get; set; }

    public string Description { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int? DeletedBy { get; set; }

    // Navigation properties
    public virtual Facility Facility { get; set; }
    public virtual ICollection<BorrowedItem> BorrowedItems { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
  }


}

