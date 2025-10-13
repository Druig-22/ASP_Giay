using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class Category
    {
        public string MaLoaiGiay { get; set; }
        public string TenLoaiGiay { get; set; }

        public Category() { }

        public Category(string maLoaiGiay, string tenLoaiGiay)
        {
            MaLoaiGiay = maLoaiGiay;
            TenLoaiGiay = tenLoaiGiay;
        }
    }
}
