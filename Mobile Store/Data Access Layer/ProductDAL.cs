using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Models;

namespace Data_Access_Layer
{
    public class ProductDAL
    {
        string query = "SELECT * FROM production.products";
        SqlConnection connection = GetConnectionFromDbConnection();

        public static SqlConnection GetConnectionFromDbConnection()
        {
            DbConnection conn = new DbConnection();
            return conn.GetConnection();
        }
        
        public List<Product> GetProductsList()
        {
            using (connection)
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        List<Product> products = new List<Product>();
                        while (reader.Read())
                        {
                            Product prd = new Product();
                            prd.product_id = (int)reader["product_id"];
                            prd.company = (string)reader["company"];
                            prd.series = (string)reader["series"];
                            prd.model = (string)reader["model"];
                            prd.stock_quantity = (int)reader["stock_quantity"];
                            prd.current_price = (decimal)reader["current_price"];

                            products.Add(prd);
                        }
                        return products;
                    }
                }
            }
        }


        public int AddProductInDatabase(Product prd)
        {
            using (connection)
            {
                connection.Open();
                string query = "INSERT INTO production.products (company, series, model, stock_quantity, current_price) VALUES (@company, @series, @model, @stock_quantity, @current_price)";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@company", prd.company);
                cmd.Parameters.AddWithValue("@series", prd.series);
                cmd.Parameters.AddWithValue("@model", prd.model);
                cmd.Parameters.AddWithValue("@stock_quantity", prd.stock_quantity);
                cmd.Parameters.AddWithValue("@current_price", prd.current_price);

                int rows = cmd.ExecuteNonQuery();
                return rows;
            }

        }


        public int RemoveProductFromDatabase(Product prd)
        {
            using (connection)
            {
                connection.Open();
                string query = "DELETE FROM production.products WHERE product_id = @product_id";
                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@product_id", prd.product_id);

                int rows = cmd.ExecuteNonQuery();
                return rows;
            }

        }

        public int UpdateProductInDatabase(Product prd)
        {
            using (connection)
            {
                connection.Open();
                string query = "UPDATE production.products SET stock_quantity = @stock_quantity, current_price = @current_price WHERE product_id = @product_id";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@stock_quantity", prd.stock_quantity);
                cmd.Parameters.AddWithValue("@current_price", prd.current_price);
                cmd.Parameters.AddWithValue("@product_id", prd.product_id);

                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
        }



    }
}
