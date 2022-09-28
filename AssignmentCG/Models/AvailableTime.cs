using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentCG.Models
{
    public class AvailableTime
    {
        public int Id { get; set; }
        [Required]
        public ApplicationUser GP { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm tt}")]
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy hh:mm tt}")]
        public DateTime EndTime { get; set; }   

    }
}