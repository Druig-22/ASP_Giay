using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class HoaDon
    {
        public string MaHD { get; set; }
        public DateTime NgayLap { get; set; }
        public string MaNV { get; set; }
        public string MaKH { get; set; }
        public decimal TongTien { get; set; }

        public HoaDon(string maHD, DateTime ngayLap, string maNV, string maKH, decimal tongTien)
        {
            MaHD = maHD;
            NgayLap = ngayLap;
            MaNV = maNV;
            MaKH = maKH;
            TongTien = tongTien;
        }

        public HoaDon() { }
    }
}

