using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public class Category: ICategoryEntity
    {
        public int ID { get; set; }
        public string CatagoryName { get; set; }
    }
}