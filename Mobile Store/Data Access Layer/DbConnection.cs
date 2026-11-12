using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Data.SqlClient;
using Models;

namespace Data_Access_Layer
{
    public class DbConnection
    {
        private string connection_string = "Server=HPElitebook;Database=mobile_store;Integrated Security =True;TrustServerCertificate=True";
        
        public SqlConnection GetConnection()
        {
            SqlConnection connection = new SqlConnection(connection_string);
            return connection;
        }

    }
}
