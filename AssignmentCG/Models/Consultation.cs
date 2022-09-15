using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentCG.Models
{
    public class Consultation
    {
        public int Id { get; set; }
        [Required]
        public AvailableTime AvailableTime { get; set; }
      
        public ApplicationUser Patient { get; set; }

    }
}