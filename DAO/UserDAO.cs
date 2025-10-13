using DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    using System;
    using System.Data.SqlClient;
    using DTO;

    namespace DAO
    {
        public class UserDAO : DataProvider
        {
            public bool CheckLogin(string username, string password)
            {
                string sql = "SELECT COUNT(*) FROM NguoiDung WHERE TenDangNhap = @user AND MatKhau = @pass";
                try
                {
                    Connect();
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    cmd.Parameters.AddWithValue("@user", username);
                    cmd.Parameters.AddWithValue("@pass", password);

                    int count = (int)cmd.ExecuteScalar();
                    return count > 0;
                }
                catch (SqlException ex)
                {
                    throw new Exception("Lỗi đăng nhập: " + ex.Message);
                }
                finally
                {
                    DisConnect();
                }
            }
        }
    }

}
