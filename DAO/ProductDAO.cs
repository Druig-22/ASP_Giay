using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace DAO
{
    public class ProductDAO : DataProvider
    {
        public DataTable GetDataForSale()
        {
            try
            {
                Connect();
                string sql = @"
            SELECT 
                MaGiay,
                TenGiay,
                TenTH,
                Size,
                MauSac,
                DonGiaNhap,
                DonGiaBan,
                SoLuongTon
            FROM v_Giay_HoaDonBan";

                SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi lấy danh sách giày để bán: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        // Lấy toàn bộ danh sách giày
        public List<Product> GetData()
        {
            List<Product> list = new List<Product>();
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_GetAll_Giay", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    list.Add(new Product(
                        dr["MaGiay"].ToString(),
                        dr["TenGiay"].ToString(),
                        dr["MaLoaiGiay"].ToString(),
                        dr["MaTH"].ToString(),
                        Convert.ToInt32(dr["Size"]),
                        dr["MauSac"].ToString(),
                        Convert.ToDecimal(dr["DonGia"]),
                        Convert.ToInt32(dr["SoLuongTon"]),
                        dr["TenTH"].ToString()
                    ));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn sp_GetAll_Giay: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return list;
        }

        // Thêm sản phẩm
        public bool Insert(Product p)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_Insert_Giay", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGiay", p.MaGiay);
                cmd.Parameters.AddWithValue("@TenGiay", p.TenGiay);
                cmd.Parameters.AddWithValue("@MaLoaiGiay", p.MaLoaiGiay ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaTH", p.MaTH ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TenTH", p.TenTH ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Size", p.Size);
                cmd.Parameters.AddWithValue("@MauSac", p.MauSac ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DonGia", p.DonGia);
                cmd.Parameters.AddWithValue("@SoLuongTon", p.SoLuongTon);

                int rows = cmd.ExecuteNonQuery();
                return rows > 0;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(" Lỗi SQL khi thêm sản phẩm: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(" Lỗi thêm sản phẩm (sp_Insert_Giay): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        // Cập nhật sản phẩm
        public bool Update(Product p)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_Update_Giay", conn);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@MaGiay", p.MaGiay);
                cmd.Parameters.AddWithValue("@TenGiay", p.TenGiay);
                cmd.Parameters.AddWithValue("@MaLoaiGiay", p.MaLoaiGiay ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@MaTH", p.MaTH ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@TenTH", p.TenTH ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@Size", p.Size);
                cmd.Parameters.AddWithValue("@MauSac", p.MauSac ?? (object)DBNull.Value);
                cmd.Parameters.AddWithValue("@DonGia", p.DonGia);
                cmd.Parameters.AddWithValue("@SoLuongTon", p.SoLuongTon);

                int rows = cmd.ExecuteNonQuery();

                if (rows == 0)
                {
                    // Không có dòng nào bị ảnh hưởng → có thể mã giày không tồn tại
                    throw new Exception($" Không có sản phẩm nào được cập nhật (MaGiay = {p.MaGiay})");
                }

                return true;
            }
            catch (SqlException sqlEx)
            {
                throw new Exception(" Lỗi SQL khi cập nhật sản phẩm: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(" Lỗi cập nhật sản phẩm (sp_Update_Giay): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        // Xóa sản phẩm
        public bool Delete(string ma)
        {
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand("sp_Delete_Giay", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@MaGiay", ma);

                int rows = cmd.ExecuteNonQuery();
                if (rows == 0)
                    throw new Exception("⚠ Không có sản phẩm nào được xóa.");

                return true;
            }
            catch (SqlException sqlEx)
            {
                // Ghi rõ lỗi khóa ngoại cho dễ hiểu
                if (sqlEx.Message.Contains("REFERENCE constraint"))
                    throw new Exception(" Không thể xóa vì sản phẩm đang được sử dụng trong bảng khác (ví dụ Hóa đơn).");
                else
                    throw new Exception(" Lỗi SQL khi xóa sản phẩm: " + sqlEx.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(" Lỗi xóa sản phẩm (sp_Delete_Giay): " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
