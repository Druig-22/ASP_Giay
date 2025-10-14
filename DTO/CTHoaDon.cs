using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CTHoaDon
    {
        public string MaHD { get; set; }
        public string MaGiay { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGiaBan { get; set; }
        public float GiamGia { get; set; }

        public CTHoaDon(string maHD, string maGiay, int soLuong, decimal donGia, float giamGia)
        {
            MaHD = maHD;
            MaGiay = maGiay;
            SoLuong = soLuong;
            DonGiaBan = donGia;
            GiamGia = giamGia;
        }
    }
}

