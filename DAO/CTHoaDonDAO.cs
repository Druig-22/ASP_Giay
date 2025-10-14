using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class CTHoaDonDAO : DataProvider
    {
        public bool Insert(CTHoaDon d)
        {
            try
            {
                Connect();
                string sql = "INSERT INTO CTHOADON (MaHD, MaGiay, SoLuong, DonGiaBan, GiamGia) VALUES (@mahd, @magiay, @sl, @dongia, @gg)";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@mahd", d.MaHD);
                cmd.Parameters.AddWithValue("@magiay", d.MaGiay);
                cmd.Parameters.AddWithValue("@sl", d.SoLuong);
                cmd.Parameters.AddWithValue("@dongia", d.DonGiaBan);
                cmd.Parameters.AddWithValue("@gg", d.GiamGia);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
