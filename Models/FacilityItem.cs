using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcStarter.Models
{
  public class FacilityItem
  {
    [Key]
    public int FacilityItemId { get; set; }

    [Required(ErrorMessage = "Tên thiết bị là bắt buộc")]
    [MaxLength(100, ErrorMessage = "Tên thiết bị không được vượt quá 100 ký tự")]
    public string ItemName { get; set; }

    public string ItemImage { get; set; }
    public int? FacilityId { get; set; }

    [Range(0, int.MaxValue, ErrorMessage = "Số lượng phải là số dương")]
    public int Quantity { get; set; }

    public string Description { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public int CreatedBy { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public int? UpdatedBy { get; set; }
    public DateTime? DeletedAt { get; set; }
    public int? DeletedBy { get; set; }

    [NotMapped]
    public string ImageUploadType { get; set; }
  }
}
