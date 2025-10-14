using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class HoaDonDAO : DataProvider
    {
        public bool Insert(HoaDon h)
        {
            try
            {
                Connect();
                string sql = "INSERT INTO HOADON (MaHD, NgayLap, MaNV, MaKH, TongTien) VALUES (@ma, @ngay, @nv, @kh, @tong)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", h.MaHD);
                cmd.Parameters.AddWithValue("@ngay", h.NgayLap);
                cmd.Parameters.AddWithValue("@nv", h.MaNV);
                cmd.Parameters.AddWithValue("@kh", h.MaKH);
                cmd.Parameters.AddWithValue("@tong", h.TongTien);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm hóa đơn: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
