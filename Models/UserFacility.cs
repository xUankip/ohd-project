using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcStarter.Models
{
    public class UserFacility
    {
        [Key]
        public int? UserId { get; set; }
        public int? FacilityId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        [ForeignKey("FacilityId")]
        public virtual Facility Facility { get; set; }
    }
}
