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
        public int SoLuongBan { get; set; }        // Đổi tên cho khớp với DB
        public decimal DonGiaBan { get; set; }
        public float GiamGia { get; set; }

        // 
        public decimal ThanhTienBan
        {
            get { return DonGiaBan * SoLuongBan * (decimal)(1 - GiamGia); }
        }

        // Constructor mới khớp với thuộc tính mới
        public CTHoaDon(string maHD, string maGiay, int soLuongBan, decimal donGiaBan, float giamGia)
        {
            MaHD = maHD;
            MaGiay = maGiay;
            SoLuongBan = soLuongBan;
            DonGiaBan = donGiaBan;
            GiamGia = giamGia;
        }
    }
}
