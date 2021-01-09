using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Topic
    {
        [Required(ErrorMessage = "Missing field")]
        public int TopicId { get; set; }

        [StringLength(502)]
        [Required(ErrorMessage = "Missing field")]
        public string Title { get; set; }

        // One to Many
        public virtual ICollection<ApplicationUser> Followers { get; set; }

        // One to Many
        public virtual ICollection<Post> Posts { get; set; }
    }
}