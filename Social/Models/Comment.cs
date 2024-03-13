namespace Social.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Comment
    {
        [Key]
        public int CommentId { get; set; }

        [Required]
        public string Contents { get; set; }

        public DateTime? PostedAt { get; set; }

        public int UserId { get; set; }

        public int PostId { get; set; }

        public virtual Post Post { get; set; }

        public virtual User User { get; set; }
    }
}
