using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

//should be required to enter something
namespace ASP.Net_Project.Models.Test
{
    public class LongAnswerQuestion: TestQuestion
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
    }
}