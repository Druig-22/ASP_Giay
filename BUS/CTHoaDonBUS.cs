using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS
{
    public class CTHoaDonBUS
    {
        CTHoaDonDAO dao = new CTHoaDonDAO();
        public bool Insert(CTHoaDon d) => dao.Insert(d);
    }
}
