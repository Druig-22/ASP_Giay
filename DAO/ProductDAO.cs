using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using DTO;

namespace DAO
{
    public class ProductDAO : DataProvider
    {
        public List<Product> GetData()
        {
            List<Product> list = new List<Product>();
            string sql = "SELECT * FROM GIAY";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
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
                        Convert.ToInt32(dr["SoLuongTon"])
                    ));
                }
                dr.Close();
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi truy vấn bảng GIAY: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return list;
        }

        public bool Exists(string ma)
        {
            string sql = "SELECT COUNT(*) FROM GIAY WHERE MaGiay = @ma";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                int count = (int)cmd.ExecuteScalar();
                return count > 0;
            }
            finally
            {
                DisConnect();
            }
        }

        public bool Insert(Product p)
        {
            string sql = @"INSERT INTO GIAY (MaGiay, TenGiay, MaLoaiGiay, MaTH, Size, MauSac, DonGia, SoLuongTon)
                           VALUES (@ma, @ten, @maloai, @math, @size, @mau, @gia, @ton)";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", p.MaGiay);
                cmd.Parameters.AddWithValue("@ten", p.TenGiay);
                cmd.Parameters.AddWithValue("@maloai", p.MaLoaiGiay);
                cmd.Parameters.AddWithValue("@math", p.MaTH);
                cmd.Parameters.AddWithValue("@size", p.Size);
                cmd.Parameters.AddWithValue("@mau", p.MauSac);
                cmd.Parameters.AddWithValue("@gia", p.DonGia);
                cmd.Parameters.AddWithValue("@ton", p.SoLuongTon);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi thêm giày: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }

        public bool Update(Product p)
        {
            string sql = @"UPDATE GIAY SET TenGiay=@ten, MaLoaiGiay=@maloai, MaTH=@math, 
                           Size=@size, MauSac=@mau, DonGia=@gia, SoLuongTon=@ton WHERE MaGiay=@ma";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", p.MaGiay);
                cmd.Parameters.AddWithValue("@ten", p.TenGiay);
                cmd.Parameters.AddWithValue("@maloai", p.MaLoaiGiay);
                cmd.Parameters.AddWithValue("@math", p.MaTH);
                cmd.Parameters.AddWithValue("@size", p.Size);
                cmd.Parameters.AddWithValue("@mau", p.MauSac);
                cmd.Parameters.AddWithValue("@gia", p.DonGia);
                cmd.Parameters.AddWithValue("@ton", p.SoLuongTon);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                DisConnect();
            }
        }

        public bool Delete(string ma)
        {
            string sql = "DELETE FROM GIAY WHERE MaGiay=@ma";
            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", ma);
                return cmd.ExecuteNonQuery() > 0;
            }
            finally
            {
                DisConnect();
            }
        }
        public bool UpdateStock(string maGiay, int soLuongBan)
        {
            try
            {
                Connect();
                string sql = "UPDATE GIAY SET SoLuongTon = SoLuongTon - @soluong WHERE MaGiay = @ma";
                SqlCommand cmd = new SqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("@ma", maGiay);
                cmd.Parameters.AddWithValue("@soluong", soLuongBan);
                return cmd.ExecuteNonQuery() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("Lỗi cập nhật tồn kho: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }
        }
    }
}
