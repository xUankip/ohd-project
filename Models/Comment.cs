using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AspnetCoreMvcStarter.Models
{
    public class Comment
    {
        [Key]
        public int CommentId { get; set; }
        public int? RequestId { get; set; }
        public int? UserId { get; set; }
        public string CommentText { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        [ForeignKey("RequestId")]
        public virtual Request Request { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}
