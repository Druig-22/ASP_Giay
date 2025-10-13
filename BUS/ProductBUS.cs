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

        public List<Product> GetData()
        {
            return dao.GetData();
        }
    }
}
