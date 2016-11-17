using ASP.NET_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public static class BlogRepositoryExtensions
    {
        public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> blog, string filter)
        {
            List<BlogPost> output = new List<BlogPost>();
            output.AddRange(blog.GetList().Where(Model => Model.Content.Contains(filter) || Model.Title.Contains(filter) || Model.Author.Contains(filter)));
            return output;
        }
    }
}