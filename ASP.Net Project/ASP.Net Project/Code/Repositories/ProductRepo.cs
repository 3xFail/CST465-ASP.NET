using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ASP.Net_Project.Code.Repositories
{
    public class ProductRepo: IProductRepo<Product>
    {

        public Product Get(int ID)
        {
            Product prod = new Product();
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = conn;
                    com.CommandText = "EXECUTE Prod_GetID @ID";
                    com.Parameters.AddWithValue("@ID", ID);
                    com.Connection.Open();
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            prod.ID = (int)reader["ID"];
                            prod.ProductCode = reader["ProductCode"].ToString();
                            prod.ProductName = reader["ProductName"].ToString();
                            prod.CategoryID = (int)reader["CategoryID"];
                            prod.ProductDescription = reader["ProductDescription"].ToString();
                            prod.ProductImage = (byte[])reader["ProductImage"];
                            prod.Price = (double)reader["Price"];
                            prod.Quantity = (int)reader["Quantity"];
                        }
                    }
                    com.Connection.Close();
                }

            }
            return prod;
        }

        public List<Product> GetList()
        {
            List<Product> list = new List<Product>();
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                using (SqlCommand com = new SqlCommand())
                {
                    com.Connection = con;
                    com.CommandText = "EXECUTE Prod_GetList";
                    com.Connection.Open();
                    using (SqlDataReader reader = com.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Product prod = new Product();
                            prod.ID = (int)reader["ID"];
                            prod.ProductCode = reader["ProductCode"].ToString();
                            prod.ProductName = reader["ProductName"].ToString();
                            prod.CategoryID = (int)reader["CategoryID"];
                            prod.ProductDescription = reader["ProductDescription"].ToString();
                            prod.ProductImage = (byte[])reader["ProductImage"];
                            prod.Price = (double)reader["Price"];
                            prod.Quantity = (int)reader["Quantity"];
                            list.Add(prod);
                        }
                    }
                    com.Connection.Close();
                }
            }

            return list;
        }

        public void Save(Product entity)
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
                        command.CommandText = "EXECUTE Prod_Update @ID, @ProductCode, @ProductName, @CategoryID, @ProductDescription, @ProductImage, @Price, @Quantity";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    else
                    {
                        //needs to insert
                        command.CommandText = "EXECUTE Prod_Add @ProductCode, @ProductName, @CategoryID, @ProductDescription, @ProductImage, @Price, @Quantity";

                    }

                    command.Parameters.AddWithValue("@ProductCode", entity.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                    command.Parameters.AddWithValue("@CategoryID", entity.CategoryID);
                    command.Parameters.AddWithValue("@ProductDescription", entity.ProductDescription);
                    command.Parameters.AddWithValue("@ProductImage", entity.ProductImage);
                    command.Parameters.AddWithValue("@Price", entity.Price);
                    command.Parameters.AddWithValue("@Quantity", entity.Quantity);
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    //command.Connection.Close();
                }
            }
        }

        public void Remove(int id)
        {

        }

    }
}