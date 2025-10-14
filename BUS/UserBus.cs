using DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class UserBUS
    {
        UserDAO dao = new UserDAO();

        public (string MaNV, string HoTen)? Login(string username, string password)
        {
            return dao.CheckLogin(username, password);
        }
    }
}