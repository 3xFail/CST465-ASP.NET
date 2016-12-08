using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public class ContactModel
    {
        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(255)]
        public string Comment { get; set; }

        [Required]
        [RegularExpression("(\\(\\d{3}\\)|\\d{3}\\-)\\d{3}\\-\\d{4}", ErrorMessage = "We can't use this number... try another?")]
        public string Phone_Number { get; set; }
    }
}