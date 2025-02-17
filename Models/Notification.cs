using System.ComponentModel.DataAnnotations;
using AspnetCoreMvcStarter.Models.Enums;

namespace AspnetCoreMvcStarter.Models
{
  public class Notification
  {
    [Key]
    public int NotificationID { get; set; }

    [Required]
    public int UserID { get; set; }

    [Required]
    public string Message { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int? CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int? DeletedBy { get; set; }

    public bool IsRead { get; set; } = false;

    // Navigation properties
    public virtual User User { get; set; }
  }
}
