using DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
                SqlCommand cmd = new SqlCommand("sp_Insert_CTHoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaHD", d.MaHD);
                cmd.Parameters.AddWithValue("@MaGiay", d.MaGiay);
                cmd.Parameters.AddWithValue("@SoLuongBan", d.SoLuongBan);
                cmd.Parameters.AddWithValue("@DonGiaBan", d.DonGiaBan);
                cmd.Parameters.AddWithValue("@GiamGia", d.GiamGia);

                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm chi tiết hóa đơn (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public DataTable GetByMaHD(string maHD)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_GetChiTiet_HoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHD", maHD);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn chi tiết hóa đơn: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool DeleteByMaHD(string maHD)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_Delete_CTHoaDon_ByMaHD", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHD", maHD);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi xóa chi tiết hóa đơn (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

    }
}
