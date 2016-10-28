using ASP.NET_Project;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public class BlogDBRepository : IDataEntityRepository<BlogPost>
    {
        public BlogPost Get(int id)
        {
            BlogPost post = new BlogPost();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Blog WHERE ID=@ID";
                    command.Parameters.AddWithValue("@ID", id);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            post.ID = (int)reader["ID"];
                            post.Title = reader["Title"].ToString();
                            post.Content = reader["Content"].ToString();
                            post.Author = reader["Author"].ToString();
                            post.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                        }
                    }
                    command.Connection.Close();
                }
            }
            return post;
        }

        public List<BlogPost> GetList()
        {
            List<BlogPost> list = new List<BlogPost>();
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandText = "SELECT * FROM Blog";
                    //command.Parameters.AddWithValue("@ID", id);
                    command.Connection.Open();
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            BlogPost post = new BlogPost();
                            post.ID = (int)reader["ID"];
                            post.Title = reader["Title"].ToString();
                            post.Content = reader["Content"].ToString();
                            post.Author = reader["Author"].ToString();
                            post.Timestamp = DateTime.Parse(reader["Timestamp"].ToString());
                            list.Add(post);
                        }
                    }
                    command.Connection.Close();
                }
            }
            return list;
        }

        public void Save(BlogPost entity)
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand command = new SqlCommand())
                {
                    command.Connection = connection;
                    command.CommandType = System.Data.CommandType.Text;
                    
                    if (entity.ID > 0)
                    {
                        // needs to update
                        command.CommandText="UPDATE Blog SET Content = @Content, Author=@Author, Title=@Title WHERE ID = @ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    else
                    {
                        //needs to insert
                        command.CommandText ="INSERT INTO Blog(Author, Title, Content) VALUES (@Author, @Title, @Content)";
                        
                    }

                    command.Parameters.AddWithValue("@Author", entity.Author);
                    command.Parameters.AddWithValue("@Title", entity.Title);
                    command.Parameters.AddWithValue("@Content", entity.Content);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    //command.Connection.Close();
                }
            }
        }
    }
}