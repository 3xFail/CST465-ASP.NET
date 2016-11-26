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
            return;
        }

        public void Save(Category entity)
        {

        }

    }
}