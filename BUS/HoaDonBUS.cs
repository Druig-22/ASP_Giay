using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class HoaDonBUS
    {
        HoaDonDAO dao = new HoaDonDAO();
        public bool Insert(HoaDon h) => dao.Insert(h);
        public DataTable GetAll()
        {
            return dao.GetAllHoaDon();
        }
        public string TaoMaHoaDonMoi()
        {
            return dao.TaoMaHoaDonMoi();
        }

        public string TaoMaKhachHangMoi()
        {
            return dao.TaoMaKhachHangMoi();
        }
    }
}
