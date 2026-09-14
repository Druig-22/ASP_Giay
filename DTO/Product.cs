using System;

namespace DTO
{
    public class Product
    {
        public string MaGiay { get; set; }
        public string TenGiay { get; set; }
        public string MaLoaiGiay { get; set; }
        public string MaTH { get; set; }
        public string TenTH { get; set; }
        public int Size { get; set; }
        public string MauSac { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        public Product() { }

        // ✅ Constructor chuẩn (đầy đủ TenTH)
        public Product(string maGiay, string tenGiay, string maLoaiGiay, string maTH,
                       int size, string mauSac, decimal donGia, int soLuongTon, string tenTH)
        {
            MaGiay = maGiay;
            TenGiay = tenGiay;
            MaLoaiGiay = maLoaiGiay;
            MaTH = maTH;
            Size = size;
            MauSac = mauSac;
            DonGia = donGia;
            SoLuongTon = soLuongTon;
            TenTH = tenTH;
        }

        // ✅ Constructor rút gọn (không có TenTH – dùng cho SP cũ)
        public Product(string maGiay, string tenGiay, string maLoaiGiay, string maTH,
                       int size, string mauSac, decimal donGia, int soLuongTon)
        {
            MaGiay = maGiay;
            TenGiay = tenGiay;
            MaLoaiGiay = maLoaiGiay;
            MaTH = maTH;
            Size = size;
            MauSac = mauSac;
            DonGia = donGia;
            SoLuongTon = soLuongTon;
        }
    }
}
