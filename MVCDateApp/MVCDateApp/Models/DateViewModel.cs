using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MVCDateApp.Models
{
    public class DateViewModel
    {
        [Required]
        public string StartDate { get; set; }
        [Required]
        public string EndDate { get; set; }
        public int Difference { get; set; }
        public string ErrorMessage { get; set; }
    }
}
