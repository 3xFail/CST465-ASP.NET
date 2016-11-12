using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


//should only allow 100 character responses
namespace ASP.Net_Project.Models.Test
{
    public class ShortAnswerQuestion: TestQuestion
    {
        [Required]
        [StringLength(100)]
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