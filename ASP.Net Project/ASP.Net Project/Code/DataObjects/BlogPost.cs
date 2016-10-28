using ASP.Net_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public class BlogPost : IDataEntity
    {
        public string Author { get; set; }

        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        public int ID { get; set; }

        public string Title { get; set; }
    }
}