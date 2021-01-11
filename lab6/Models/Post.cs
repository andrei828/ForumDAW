using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Post
    {
        [Key]
        [Required(ErrorMessage = "Missing field")]
        public int PostId { get; set; }

        [NoBadWords]
        [StringLength(502)]
        [Required(ErrorMessage = "Missing field")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Missing field")]
        public int Views { get; set; }

        // Many to one
        // No required validation because of the editing mechanism
        public virtual Topic Topic { get; set; }

        // One to Many
        //[Required(ErrorMessage = "Missing field")]
        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            this.Views = 0;
        }
    }
}