using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Topic
    {
        [Key]
        [Required(ErrorMessage = "Missing field")]
        public int TopicId { get; set; }

        [NoBadWords]
        [StringLength(502)]
        [Required(ErrorMessage = "Missing field")]
        public string Title { get; set; }

        // Many to Many
        //[Required(ErrorMessage = "Missing field")]
        public virtual ICollection<ApplicationUser> Followers { get; set; }

        // One to Many
        //[Required(ErrorMessage = "Missing field")]
        public virtual ICollection<Post> Posts { get; set; }
    }
}