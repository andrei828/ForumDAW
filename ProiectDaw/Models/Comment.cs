using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Comment
    {
        [Key]
        [Required(ErrorMessage = "Missing field")]
        public int CommentId { get; set; }

        [NoBadWords]
        [StringLength(502)]
        [Required(ErrorMessage = "Missing field")]
        public string Content { get; set; }

        // One to One
        // No required validation because of the editing mechanism
        public virtual Engagement Engagement { get; set; }

        // Many to Many
        public virtual ICollection<ApplicationUser> LikedBy { get; set; }

        // One to One
        // No required validation because of the editing mechanism
        public virtual Post Post { get; set; }

        // One to One
        [StringLength(502)]
        public virtual string Author { get; set; }

        
    }
}