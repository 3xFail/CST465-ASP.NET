﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;



//regulare expression is required to validate true or false
namespace ASP.Net_Project.Models.Test
{
    public class TrueFalseQuestion : TestQuestion
    {
        [Required]
        [RegularExpression("(?i:True|False)")]
        public override string Answer
        {
            get
            {
                return base.Answer;
            }

            set
            {
               
                    base.Answer = value;
                
                
            }
        }
    }
}