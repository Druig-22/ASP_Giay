using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class DataProvider
    {
        // ✅ Đổi từ private → protected
        protected SqlConnection conn;

        public DataProvider()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["QLBHConnectionString"].ConnectionString;
            conn = new SqlConnection(connectionString);
        }

        protected void Connect()
        {
            if (conn != null && conn.State != ConnectionState.Open)
                conn.Open();
        }

        protected void DisConnect()
        {
            if (conn != null && conn.State != ConnectionState.Closed)
                conn.Close();
        }
    }
}
