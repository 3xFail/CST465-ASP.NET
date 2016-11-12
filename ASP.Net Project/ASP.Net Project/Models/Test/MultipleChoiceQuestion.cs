using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//required to select one
namespace ASP.Net_Project.Models.Test
{
    public class MultipleChoiceQuestion: TestQuestion
    {
        [Required]
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

        public List<string> Choices { get; set; }
    }
}