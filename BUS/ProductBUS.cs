using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;

namespace BUS
{
    public class ProductBUS
    {
        ProductDAO dao = new ProductDAO();

        public List<Product> GetData() => dao.GetData();

        public bool Insert(Product p)
        {
            if (dao.Exists(p.MaGiay)) return false;
            return dao.Insert(p);
        }
        public bool UpdateStock(string maGiay, int soLuongBan)
        {
            return dao.UpdateStock(maGiay, soLuongBan);
        }

        public bool Update(Product p) => dao.Update(p);
        public bool Delete(string ma) => dao.Delete(ma);

    }
    
}
