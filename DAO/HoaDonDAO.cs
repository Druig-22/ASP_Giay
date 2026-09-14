using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
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
                SqlCommand cmd = new SqlCommand("sp_Insert_HoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaHD", h.MaHD);
                cmd.Parameters.AddWithValue("@NgayLap", h.NgayLap);
                cmd.Parameters.AddWithValue("@MaNV", h.MaNV);
                cmd.Parameters.AddWithValue("@MaKH", h.MaKH);
                cmd.Parameters.AddWithValue("@TongTien", h.TongTien);


                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm hóa đơn (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public DataTable GetAllHoaDon()
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_GetAll_HoaDon", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn hóa đơn (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public DataTable GetChiTietHoaDon(string maHD)
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
                throw new Exception("Lỗi truy vấn chi tiết hóa đơn (SP): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
        public string TaoMaHoaDonMoi()
        {
            string query = "SELECT TOP 1 MaHD FROM HOADON ORDER BY MaHD DESC";

            
            DataProvider dp = new DataProvider();
            DataTable dt = dp.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["MaHD"].ToString(); // HD00023
                int number = int.Parse(lastID.Substring(2));   // 23
                return "HD" + (number + 1).ToString("D4");     // HD00024
            }
            else
            {
                return "HD0001"; // Nếu chưa có hóa đơn nào
            }
        }

        public string TaoMaKhachHangMoi()
        {
            string query = "SELECT TOP 1 MaKH FROM KHACHHANG ORDER BY MaKH DESC";
            DataProvider dp = new DataProvider();
            DataTable dt = dp.ExecuteQuery(query);

            if (dt.Rows.Count > 0)
            {
                string lastID = dt.Rows[0]["MaKH"].ToString(); // Ví dụ KH00027
                int number = int.Parse(lastID.Substring(2)) + 1;
                return "KH" + number.ToString("D4"); // KH00028
            }
            else
            {
                return "KH0001";
            }
        }

    }
}
