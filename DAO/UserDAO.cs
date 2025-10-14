using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class UserDAO : DataProvider
    {
        public (string MaNV, string HoTen)? CheckLogin(string username, string password)
        {
            Connect();

            string sql = @"SELECT ND.MaNV, NV.HoTen
                           FROM NguoiDung ND
                           JOIN NHANVIEN NV ON ND.MaNV = NV.MaNV
                           WHERE ND.TenDangNhap = @user AND ND.MatKhau = @pass";

            SqlCommand cmd = new SqlCommand(sql, conn);
            cmd.Parameters.AddWithValue("@user", username);
            cmd.Parameters.AddWithValue("@pass", password);

            SqlDataReader dr = cmd.ExecuteReader();
            (string MaNV, string HoTen)? result = null;

            if (dr.Read())
            {
                result = (dr["MaNV"].ToString(), dr["HoTen"].ToString());
            }

            dr.Close();
            DisConnect();

            return result;
        }
    }
}