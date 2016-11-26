using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public interface IProductEntity
    {
        int ID { get; set; }
        string ProductCode { get; set; }
        string ProductName { get; set; }
        int CategoryID { get; set; }
        string ProductDescription { get; set; }
        byte[] ProductImage { get; set; }
        double Price { get; set; }
        int Quantity { get; set; }
    }
}