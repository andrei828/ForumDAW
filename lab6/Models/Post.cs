using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Post
    {
        
        [Required(ErrorMessage = "Missing field")]
        public int PostId { get; set; }

        [StringLength(502)]
        [Required(ErrorMessage = "Missing field")]
        public string Content { get; set; }

        [Required(ErrorMessage = "Missing field")]
        public int Views { get; set; }

        // Many to one
        [Required(ErrorMessage = "Missing field")]
        public virtual Topic Topic { get; set; }

        // One to Many
        public virtual ICollection<Comment> Comments { get; set; }

        public Post()
        {
            this.Views = 0;
        }
    }
}