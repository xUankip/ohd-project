using System.ComponentModel.DataAnnotations;

namespace AspnetCoreMvcStarter.Models
{
    public class UserRole
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        public string RoleName { get; set; }
    }
}
