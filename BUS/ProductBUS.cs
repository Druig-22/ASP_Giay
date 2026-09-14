using DAO;
using DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

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
        //public bool UpdateStock(string maGiay, int soLuongBan)
        //{
        //    return dao.UpdateStock(maGiay, soLuongBan);
        //}

        public bool Update(Product p) => dao.Update(p);
        public bool Delete(string ma) => dao.Delete(ma);

        public DataTable GetDataForSale()
        {
            ProductDAO dao = new ProductDAO();
            return dao.GetDataForSale();
        }

    }

}
