using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAO;
using DTO;


namespace BUS
{
    public class CategoryBUS
    {
        CategoryDAO dao = new CategoryDAO();

        public List<Category> GetData()
        {
            return dao.GetData();
        }

        public bool Insert(Category c)
        {
            return dao.Insert(c);
        }

        public bool Update(Category c)
        {
            return dao.Update(c);
        }

        public bool Delete(string ma)
        {
            return dao.Delete(ma);
        }
        public bool Exists(string maLoaiGiay)
        {
            return dao.Exists(maLoaiGiay);
        }
    }
}
