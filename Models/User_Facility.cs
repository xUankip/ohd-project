using System.ComponentModel.DataAnnotations;
using AspnetCoreMvcStarter.Models.Enums;

namespace AspnetCoreMvcStarter.Models
{
  public class User_Facility
  {
    public int UserID { get; set; }
    public int FacilityID { get; set; }

    // Navigation properties
    public virtual User User { get; set; }
    public virtual Facility Facility { get; set; }
  }
}

