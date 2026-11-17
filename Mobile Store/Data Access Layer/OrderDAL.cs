using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Models;

namespace Data_Access_Layer
{
    public class OrderDAL
    {
        private SqlConnection connection = GetConnectionFromDbConnection();

        public static SqlConnection GetConnectionFromDbConnection()
        {
            DbConnection conn = new DbConnection();
            return conn.GetConnection();
        }

        public int AddOrderInDatabase(Product prd, Customer cust, Order o, OrderDetails od)
        {
            using (connection)
            {
                connection.Open();
                string query = "DECLARE @latest_order_id INT INSERT INTO sales.orders (customer_id, total_amount, order_date) VALUES (@customer_id, @total_amount, GETDATE()) SET @latest_order_id = SCOPE_IDENTITY(); INSERT INTO sales.order_details (order_id, product_id, quantity, unit_price) VALUES (@latest_order_id, @product_id, @quantity, @unit_price);";

                SqlCommand cmd = new SqlCommand(query, connection);             
                cmd.Parameters.AddWithValue("@customer_id", cust.Customer_Id);
                cmd.Parameters.AddWithValue("@total_amount", o.Total_Amount);
                cmd.Parameters.AddWithValue("@product_id", prd.Product_Id);
                cmd.Parameters.AddWithValue("@quantity", od.Quantity);
                cmd.Parameters.AddWithValue("@unit_price", od.Unit_Price);

                int rows = cmd.ExecuteNonQuery();
                return rows;

            }
        }


        public List<Order> GetOrdersList()
        {
            using (connection)
            {
                connection.Open();
                string query = "SELECT * FROM sales.orders";
                List<Order> orders = new List<Order>();

                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Order ord = new Order();
                    ord.Order_Id = Convert.ToInt32(reader["Order_Id"]);
                    ord.Customer_Id = Convert.ToInt32(reader["Customer_Id"]);
                    ord.Total_Amount = Convert.ToDecimal(reader["Total_Amount"]);
                    ord.Order_Date = Convert.ToDateTime(reader["Order_Date"]);

                    orders.Add(ord);
                }

                return orders;
            }
        }

    }
}
