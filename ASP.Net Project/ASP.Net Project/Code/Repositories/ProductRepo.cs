using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
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
                    com.CommandText = "SELECT * FROM Product WHERE ID=@ID";
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
                            prod.ImageContentType = reader["ImageContentType"].ToString();
                            prod.ImageFileName = reader["ImageFileName"].ToString();


                            object img = prod.ProductImage;
                            BinaryFormatter bin = new BinaryFormatter();
                            using (MemoryStream mem = new MemoryStream())
                            {
                                bin.Serialize(mem, img);
                                prod.ProductImage = mem.ToArray();
                            }
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

                            prod.ImageContentType = reader["ImageContentType"].ToString();
                            prod.ImageFileName = reader["ImageFileName"].ToString();


                            object img = prod.ProductImage;
                            BinaryFormatter bin = new BinaryFormatter();
                            using (MemoryStream mem = new MemoryStream())
                            {
                                bin.Serialize(mem, img);
                                prod.ProductImage = mem.ToArray();
                            }

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
                        command.CommandText = "UPDATE Product SET ProductCode = @ProductCode, ProductName = @ProductName, CategoryID = @CategoryID, ProductDescription = @ProductDescription, ProductImage = @ProductImage, Price = @Price, Quantity = @Quantity, ImageContentType = @ImageContentType, ImageFileName = #ImageFileName WHERE ID = @ID";
                        command.Parameters.AddWithValue("@ID", entity.ID);
                    }
                    else
                    {
                        //needs to insert
                        command.CommandText = "INSERT INTO Product(ProductCode, ProductName, CategoryID, ProductDescription, ProductImage, Price, Quantity, ImageFileName, ImageContentType) VALUES(@ProductCode, @ProductName, @CategoryID, @ProductDescription, @ProductImage, @Price, @Quantity, @ImageFileName, @ImageContentType)";

                    }

                    command.Parameters.AddWithValue("@ProductCode", entity.ProductCode);
                    command.Parameters.AddWithValue("@ProductName", entity.ProductName);
                    command.Parameters.AddWithValue("@CategoryID", entity.CategoryID);
                    command.Parameters.AddWithValue("@ProductDescription", entity.ProductDescription);

                    command.Parameters.AddWithValue("@Price", entity.Price);
                    command.Parameters.AddWithValue("@Quantity", entity.Quantity);

                    if (entity.ImageFileName != "null")
                    { 
                        command.Parameters.AddWithValue("@ImageContentType", entity.ImageContentType);
                        command.Parameters.AddWithValue("@ImageFileName", entity.ImageFileName);
                        command.Parameters.AddWithValue("@ProductImage", entity.ProductImage);
                    }
                    else
                    {
                        command.Parameters.AddWithValue("@ImageContentType", "null");
                        command.Parameters.AddWithValue("@ImageFileName", "null");
                        command.Parameters.AddWithValue("@ProductImage", 0);
                    }
                    command.Connection.Open();
                    command.ExecuteNonQuery();
                    //command.Connection.Close();
                }
            }
        }

        public void Remove(int id)
        {
            using (SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["Aura"].ConnectionString))
            {
                ProductRepo inventory = new ProductRepo();
                List<Product> list = inventory.GetList();

                foreach (Product i in list)
                {
                    if (i.CategoryID == id)
                    {
                        inventory.Remove(i.ID);
                    }
                }


                SqlCommand com = new SqlCommand();
                com.Connection = con;
                com.CommandType = System.Data.CommandType.Text;
                com.CommandText = "DELETE FROM Category WHERE ID=@ID";
                com.Parameters.AddWithValue("@ID", id);
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