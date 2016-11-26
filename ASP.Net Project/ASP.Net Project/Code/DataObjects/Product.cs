using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public class Product: IProductEntity
    {
        public int ID { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }
        public int CategoryID { get; set; }
        public string ProductDescription { get; set; }
        public byte[] ProductImage { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }

    }
}