using System.ComponentModel.DataAnnotations;
using AspnetCoreMvcStarter.Models.Enums;

namespace AspnetCoreMvcStarter.Models
{
  public class BorrowedItem
  {
    [Key]
    public int BorrowID { get; set; }

    [Required]
    public int UserID { get; set; }

    [Required]
    public int ItemID { get; set; }

    [Required]
    public int FacilityID { get; set; }

    [Required]
    public int QuantityBorrowed { get; set; }

    public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
    public DateTime? ReturnDate { get; set; }

    [Required]
    public string Status { get; set; } = "Borrowed";

    // Navigation properties
    public virtual User User { get; set; }
    public virtual Item Item { get; set; }
    public virtual Facility Facility { get; set; }
  }
}
