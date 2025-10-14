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
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn LOAIGIAY: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return list;
        }

        public bool Insert(Category c)
        {
            try
            {
                Connect();

                //  Kiểm tra xem mã đã tồn tại chưa
                string checkSql = "SELECT COUNT(*) FROM LOAIGIAY WHERE MaLoaiGiay = @ma";
                SqlCommand checkCmd = new SqlCommand(checkSql, conn);
                checkCmd.Parameters.AddWithValue("@ma", c.MaLoaiGiay);

                int count = (int)checkCmd.ExecuteScalar();
                if (count > 0)
                {
                    // Nếu trùng, ném ngoại lệ rõ ràng
                    throw new Exception("Mã loại giày '" + c.MaLoaiGiay + "' đã tồn tại!");
                }

                // Nếu không trùng, thực hiện thêm
                string sql = "INSERT INTO LOAIGIAY (MaLoaiGiay, TenLoaiGiay) VALUES (@ma, @ten)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", c.MaLoaiGiay);
                cmd.Parameters.AddWithValue("@ten", c.TenLoaiGiay);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                // Thông báo lỗi chi tiết nhưng thân thiện hơn
                throw new Exception("Lỗi thêm loại giày: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }


        public bool Update(Category c)
        {
            string sql = "UPDATE LOAIGIAY SET TenLoaiGiay=@ten WHERE MaLoaiGiay=@ma";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", c.MaLoaiGiay);
                cmd.Parameters.AddWithValue("@ten", c.TenLoaiGiay);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật loại giày: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool Delete(string ma)
        {
            string sql = "DELETE FROM LOAIGIAY WHERE MaLoaiGiay=@ma";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa loại giày: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
