using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.Data.SqlClient;

namespace DAL
{
    public class DALProduct
    {
        public static List<Product> GetAllProducts()
        {
            try
            {
                SqlConnection conn = DBHelper.GetConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("sp_GetAllProducts", conn);
                cmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<Product> products = new List<Product>();
                while (reader.Read())
                {
                    Product product = new Product();
                    product.Id = Convert.ToInt32(reader["Id"]);
                    product.Name = reader["Name"].ToString();
                    product.Image = reader["Image"].ToString();
                    product.Price = Convert.ToInt32(reader["Price"]);
                    products.Add(product);
                }
                conn.Close();
                return products;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return new List<Product>();
            }

        }
        public static Product GetProductById(int id)
        {
            Product product = null;

            using (SqlConnection conn = DBHelper.GetConnection())
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("sp_GetProductById", conn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@product_id", id);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            product = new Product
                            {
                                Id = Convert.ToInt32(reader["Id"]),
                                Name = reader["name"].ToString(),
                                Image = reader["image"].ToString(),
                                Price = Convert.ToSingle(reader["price"]),
                                CreatedAt = Convert.ToDateTime(reader["created_at"])
                            };
                        }
                    }
                }
            }

            return product;
        }
        public static void AddProduct(Product product)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_AddProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@image", product.Image);
            cmd.Parameters.AddWithValue("@Price", product.Price);
           
            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void UpdateProduct(Product product) {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_UpdateProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", product.Id);
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@image", product.Image);
            cmd.Parameters.AddWithValue("@Price", product.Price);

            cmd.ExecuteNonQuery();
            conn.Close();
        }
        public static void DeleteProduct(int id)
        {
            SqlConnection conn = DBHelper.GetConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("sp_DeleteProduct", conn);
            cmd.CommandType = System.Data.CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.ExecuteNonQuery();
            conn.Close();

        }
    }
}
