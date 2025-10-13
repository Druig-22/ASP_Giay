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
            string sql = "SELECT MaGiay, TenGiay, MaLoaiGiay, MaTH, Size, MauSac, DonGia, SoLuongTon, HinhAnh FROM Giay";

            try
            {
                Connect();
                SqlCommand cmd = new SqlCommand(sql, conn);
                SqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    string maGiay = dr["MaGiay"].ToString().Trim();
                    string tenGiay = dr["TenGiay"].ToString().Trim();
                    string maLoaiGiay = dr["MaLoaiGiay"].ToString().Trim();
                    string maTH = dr["MaTH"].ToString().Trim();
                    int size = dr["Size"] == DBNull.Value ? 0 : Convert.ToInt32(dr["Size"]);
                    string mauSac = dr["MauSac"].ToString().Trim();
                    double donGia = dr["DonGia"] == DBNull.Value ? 0 : Convert.ToDouble(dr["DonGia"]);
                    int soLuongTon = dr["SoLuongTon"] == DBNull.Value ? 0 : Convert.ToInt32(dr["SoLuongTon"]);
                    string hinhAnh = dr["HinhAnh"] == DBNull.Value ? "" : dr["HinhAnh"].ToString().Trim();

                    list.Add(new Product(maGiay, tenGiay, maLoaiGiay, maTH, size, mauSac, donGia, soLuongTon, hinhAnh));
                }

                dr.Close();
            }
            catch (SqlException ex)
            {
                throw new Exception("Lỗi truy vấn bảng Giay: " + ex.Message);
            }
            finally
            {
                DisConnect();
            }

            return list;
        }
    }
}
