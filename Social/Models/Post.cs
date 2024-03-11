using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Social.Models
{
    public class Post
    {
        [Key]
        public int PostId { get; set; }

        [Required]
        public string Contents { get; set; }

        public DateTime PostedAt { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }
    }
}