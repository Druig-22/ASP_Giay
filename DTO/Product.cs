using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Product
    {
        public string MaGiay { get; set; }
        public string TenGiay { get; set; }
        public string MaLoaiGiay { get; set; }
        public string MaTH { get; set; }
        public int Size { get; set; }
        public string MauSac { get; set; }
        public decimal DonGia { get; set; }
        public int SoLuongTon { get; set; }

        public Product() { }

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


