using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public interface ICategoryEntity
    {
        int ID { get; set; }
        string CatagoryName { get; set; }
    }
}