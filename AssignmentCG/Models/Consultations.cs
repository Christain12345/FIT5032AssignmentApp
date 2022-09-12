using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentCG.Models
{
    public class Consultations
    {
        public int Id { get; set; }
        [Required]
        public AvailableTime AvailableTimeId { get; set; }
        [Required]
        public int PatientId { get; set; }

    }
}