using System.ComponentModel.DataAnnotations;
using AspnetCoreMvcStarter.Models.Enums;

namespace AspnetCoreMvcStarter.Models
{

  public class User
  {
    [Key]
    public int UserID { get; set; }

    [Required]
    [StringLength(50)]
    public string Username { get; set; }

    [Required]
    [StringLength(255)]
    public string PasswordHash { get; set; }

    [Required]
    [StringLength(100)]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    public UserRole RoleID { get; set; }

    [Required]
    [StringLength(100)]
    public string FullName { get; set; }

    [StringLength(15)]
    public string Phone { get; set; }

    public bool IsActive { get; set; } = true;

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }

    // Navigation properties
    public virtual ICollection<Facility> ManagedFacilities { get; set; }
    public virtual ICollection<User_Facility> UserFacilities { get; set; }
    public virtual ICollection<BorrowedItem> BorrowedItems { get; set; }
    public virtual ICollection<Request> Requests { get; set; }
    public virtual ICollection<Notification> Notifications { get; set; }
  }
}

