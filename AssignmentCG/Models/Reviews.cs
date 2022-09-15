using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AssignmentCG.Models
{
    public class Reviews
    {
        public int Id { get; set; }
        public Consultation Consultation { get; set; }
        public ApplicationUser GP { get; set; }
        [Required]
        public double Rate { get; set; }
        [Required]
        public string Comment { get; set; }

    }
}