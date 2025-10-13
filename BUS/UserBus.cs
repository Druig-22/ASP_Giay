using DAO.DAO;
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

        public bool Login(string user, string pass)
        {
            return dao.CheckLogin(user, pass);
        }
    }
}
