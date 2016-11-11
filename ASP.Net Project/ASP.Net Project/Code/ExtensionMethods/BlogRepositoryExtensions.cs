using ASP.NET_Project;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASP.Net_Project.Code.ExtensionMethods
{
    public static class BlogRepositoryExtensions
    {
        public static List<BlogPost> GetListByContent(this IDataEntityRepository<BlogPost> blog, string filter)
        {
            return blog.Where(s => s.Title.contains(filter) || s.Author.Contains(filter) || s.Content.Contains(filter));
        }
    }
}