using ASP.NET_Project;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace ASP.Net_Project.Code.Repositories
{
    public class BlogFileRepository : IDataEntityRepository<BlogPost>
    {
        public BlogPost Get(int id)
        {
            BlogPost post = new BlogPost();
            string path = HttpContext.Current.Server.MapPath("/App_data/data_file.json");
            var reader = new StreamReader(path);
            var serial = new JavaScriptSerializer();

            var posts = serial.Deserialize<List<BlogPost>>(reader.ReadToEnd());
            reader.Close();

            foreach (BlogPost bp in posts)
            {
                if(id == bp.ID)
                {
                    post = bp;
                }
            }

            return post;
        }

        public List<BlogPost> GetList()
        {
            string path = HttpContext.Current.Server.MapPath("/App_data/data_file.json");
            var reader = new StreamReader(path);
            var serial = new JavaScriptSerializer();
            List<BlogPost> posts = new List<BlogPost>();

            string temp = reader.ReadToEnd();
            reader.Close();

            if (temp != null)
            {
                posts = serial.Deserialize<List<BlogPost>>(temp);
            }
            
            return posts;
        }

        public void Save(BlogPost entity)
        {
            string path = HttpContext.Current.Server.MapPath("/App_data/data_file.json");
            
            //var reader = new StreamReader(path);
            var serial = new JavaScriptSerializer();
            //List<BlogPost> posts = new List<BlogPost>();

            List<BlogPost> posts = GetList();

            if(posts == null)
            {
                posts = new List<BlogPost>();
            }

            if(entity.ID > 0)
            {
                //needs to update
                //posts[entity.ID - 1] = entity;
                BlogPost Temp =  posts.Where(s => s.ID == entity.ID).First();
                int index = posts.IndexOf(Temp);
                if (index > 0)
                {
                    posts[index] = entity;
                }
            }
            else
            {
                //new entity
                entity.ID = id_count;
                entity.Timestamp = DateTime.UtcNow;
                posts.Add(entity);
                id_count++;
            }
            var writer = new StreamWriter(path);
            writer.Write(serial.Serialize(posts));
            writer.Close();
        }
        private static int id_count = 1; 
    }
}