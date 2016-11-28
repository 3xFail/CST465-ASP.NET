using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP.Net_Project
{
    public class CategoryRepo: ICategoryRepo<Category>
    {
        public Category Get(int ID)
        {
            Category cat = new Category();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "EXECUTE Cat_GetID @ID";
                    com.Parameters.AddWithValue("@ID", ID);
                    com.Connection.Open();
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        if(reader.Read())
                        {
                            cat.ID = (int)reader["ID"];
                            cat.CatagoryName = reader["CategoryName"].ToString();
                        }
                    }
                    com.Connection.Close();
                }

            }
            return cat;
        }

        public List<Category> GetList()
        {
            List<Category> list = new List<Category>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "EXECUTE Cat_GetList";
                    com.Connection.Open();
                    using (SqlDataReader read = com.ExecuteReader())
                    {
                        while(read.Read())
                        {
                            Category category = new Category();
                            category.ID = (int)read["ID"];
                            category.CatagoryName = read["CategoryName"].ToString();
                            list.Add(category);
                        }
                    }
                    com.Connection.Close();
                }
            }

                return list;
        }

        public void Save(Category entity)
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
                        command.CommandText = "EXECUTE Cat_Update @ID, @CategoryName";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    else
                    {
                        command.CommandText = "EXECUTE Cat_Add @CategoryName";
                    }

                    command.Parameters.AddWithValue("@CategoryName", entity.CatagoryName);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    command.Connection.Close();
                }
            }
        }

        public void Remove(int ID)
        {

            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "DELETE FROM Category WHERE ID=@ID";
                com.Parameters.AddWithValue("@ID", ID);
                com.Connection.Open();

                try
                {
                    if (com.ExecuteNonQuery() != 1)
                    {
                        //return value is the number of rows affected which should be one
                        throw new Exception("Remove Product Error");
                    }
                    //otherwise executed as expected
                }
                catch
                {

                }
                finally
                {
                    com.Connection.Close();
                }
            }
        }

    }
}