using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace DAO
{
    public class DataProvider
    {
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
        public bool Exists(string maLoaiGiay)
        {
            try
            {
                Connect();
                string sql = "SELECT COUNT(*) FROM LOAIGIAY WHERE MaLoaiGiay = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maLoaiGiay);

                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi kiểm tra mã loại giày: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

    }
}
