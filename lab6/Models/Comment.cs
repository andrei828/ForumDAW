using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Comment
    {
        [Required(ErrorMessage = "Missing field")]
        public int CommentId { get; set; }

        [StringLength(502)]
        [Required(ErrorMessage = "Missing field")]
        public string Content { get; set; }

        // One to One
        public virtual Engagement Engagement { get; set; }

        // One to One
        [Required(ErrorMessage = "Missing field")]
        public virtual Post Post { get; set; }

        // One to One
        public virtual string Author { get; set; }
    }
}