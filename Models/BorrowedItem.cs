using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcStarter.Models
{
    public class BorrowedItem
    {
        [Key]
        public int BorrowId { get; set; }
        public int? UserId { get; set; }
        public User User { get; set; }
        public int? ItemId { get; set; }
        public FacilityItem FacilityItem { get; set; }
        public int? FacilityId { get; set; }
        public Facility Facility { get; set; }
        public int QuantityBorrowed { get; set; }
        public DateTime BorrowDate { get; set; } = DateTime.UtcNow;
        public DateTime? ReturnDate { get; set; }
        public string Status { get; set; } = "Borrowed";
    }
}
