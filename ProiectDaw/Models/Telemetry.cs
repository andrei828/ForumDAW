using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace lab6.Models
{
    [Table("Telemetry")]
    public class Telemetry
    {
        [Key]
        public int TelemetryId { get; set; }

        [StringLength(502)]
        public string Region { get; set; }

        [Range(0, 9999, ErrorMessage = "Not good")]
        public int TotalTopics { get; set; }

        [Range(0, 999999, ErrorMessage = "Not good")]
        public int TotalPosts { get; set; }

        [Range(0, 9999999, ErrorMessage = "Not good")]
        public int TotalComments { get; set; }
    }
}