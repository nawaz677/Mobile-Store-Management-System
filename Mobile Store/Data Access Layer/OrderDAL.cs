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

        public bool AddOrderInDatabase(Order order, Decimal grand_total)
        {
            using (connection)
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // STEP 1:
                    string order_query = @"INSERT INTO sales.orders (customer_id, total_amount, order_date)
                                           VALUES (@customer_id, @total_amount, GETDATE())
                                           SELECT CAST(SCOPE_IDENTITY() AS INT)";

                    SqlCommand order_cmd = new SqlCommand(order_query, connection, transaction);

                    order_cmd.Parameters.AddWithValue("@customer_id", order.Customer_Id);
                    order_cmd.Parameters.AddWithValue("@total_amount", grand_total);


                    int latest_order_id = (int)order_cmd.ExecuteScalar();

                    // STEP 2:
                    string details_query = @"INSERT INTO sales.order_details (order_id, product_id, quantity, unit_price)
                                             VALUES (@order_id, @product_id, @quantity, @unit_price);";

                    SqlCommand details_cmd = new SqlCommand(details_query, connection, transaction);                 

                    details_cmd.Parameters.AddWithValue("@order_id", latest_order_id);
                    details_cmd.Parameters.AddWithValue("@product_id", 0);
                    details_cmd.Parameters.AddWithValue("@quantity", 0);
                    details_cmd.Parameters.AddWithValue("@unit_price", 0m);

                    for (int i = 0; i < order.order_details.Count(); i++)
                    {
                        details_cmd.Parameters["@product_id"].Value = order.order_details[i].Product_Id;
                        details_cmd.Parameters["@quantity"].Value = order.order_details[i].Quantity;
                        details_cmd.Parameters["@unit_price"].Value = order.order_details[i].Unit_Price;

                        details_cmd.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    return true;

                }

                catch
                {
                    transaction.Rollback();
                    throw;
                }

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
