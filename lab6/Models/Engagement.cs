using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    public class Engagement
    {
        [Required(ErrorMessage = "Missing field")]
        public int EngagementId { get; set; }

        [Required(ErrorMessage = "Missing field")]
        public int Likes { get; set; }
    }
}