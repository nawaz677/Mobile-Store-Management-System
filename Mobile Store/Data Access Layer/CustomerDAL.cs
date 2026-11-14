using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Models;

namespace Data_Access_Layer
{
    public class CustomerDAL
    {
        public SqlConnection connection = GetConnectionFromDbConnection();
        public static SqlConnection GetConnectionFromDbConnection()
        {
            DbConnection conn = new DbConnection();
            return conn.GetConnection();
        }

        public List<Customer> ViewCustomers()
        {
            string query = "SELECT * FROM production.customers";
            using (connection)
            {
                connection.Open();
                SqlCommand cmd = new SqlCommand(query, connection);
                SqlDataReader reader = cmd.ExecuteReader();
                List<Customer> customers = new List<Customer>();

                while (reader.Read())
                {
                    Customer cust = new Customer();
                    cust.customer_id = (int)reader["customer_id"];
                    cust.first_name = (string)reader["first_name"];
                    cust.last_name = (string)reader["last_name"];
                    cust.age = (int)reader["age"];
                    cust.phone_number = (string)reader["phone_number"];
                    cust.address = (string)reader["address"];

                    customers.Add(cust);
                }

                return customers;
            }
        }

        public int AddCustomer(Customer cust)
        {
            
            using (connection)
            {
                connection.Open();
                string query = "INSERT INTO production.customers (first_name, last_name, age, phone_number, address) VALUES (@first_name, @last_name, @age, @phone_number, @address)";

                SqlCommand cmd = new SqlCommand(query, connection);      

                cmd.Parameters.AddWithValue("@first_name", cust.first_name);
                cmd.Parameters.AddWithValue("@last_name", cust.last_name);
                cmd.Parameters.AddWithValue("@age", cust.age);
                cmd.Parameters.AddWithValue("@phone_number", cust.phone_number);
                cmd.Parameters.AddWithValue("@address", cust.address);

                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
            
        }
        
        public int DeleteCustomer(Customer cust)
        {
            using (connection)
            {
                connection.Open();
                string query = "DELETE FROM production.customers WHERE customer_id = @customer_id";

                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@customer_id", cust.customer_id);

                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
        }

        public int UpdateCustomerDetails(Customer cust)
        {
            using (connection)
            {
                connection.Open();
                string query = "UPDATE production.customers SET first_name = @first_name, last_name = @last_name, age = @age, phone_number = @phone_number, address = @address WHERE customer_id = @customer_id";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.AddWithValue("@first_name", cust.first_name);
                cmd.Parameters.AddWithValue("@last_name", cust.last_name);
                cmd.Parameters.AddWithValue("@age", cust.age);
                cmd.Parameters.AddWithValue("@phone_number", cust.phone_number);
                cmd.Parameters.AddWithValue("@address", cust.address);
                cmd.Parameters.AddWithValue("@customer_id", cust.customer_id);

                int rows = cmd.ExecuteNonQuery();
                return rows;
            }
        }
    }
}
