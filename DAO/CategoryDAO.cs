using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using System.Data.SqlClient;

namespace DAO
{
    public class CategoryDAO : DataProvider
    {
        public List<Category> GetData()
        {
            List<Category> list = new List<Category>();
            string sql = "SELECT MaLoaiGiay, TenLoaiGiay FROM LOAIGIAY";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string ma = dr.GetString(0).Trim();
                    string ten = dr.GetString(1).Trim();

                    list.Add(new Category(ma, ten));
                }

                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi truy vấn dữ liệu bảng LOAIGIAY: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return list;
        }
    }
}
