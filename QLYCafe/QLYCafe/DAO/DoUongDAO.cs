using QLYCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DAO
{
    internal class DoUongDAO
    {
        private static DoUongDAO instance;
        public static DoUongDAO Instance
        {
            get { if (instance == null) instance = new DoUongDAO(); return DoUongDAO.instance; }
            private set { DoUongDAO.instance = value; }
        }

        private DoUongDAO() { }

        public List<DoUong> GetDoUongByIDDanhMuc(int id)
        {
            List<DoUong> list = new List<DoUong>();
            string query = "select * from DoUong where idDanhMuc = "+id;

            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                DoUong douong = new DoUong(item);
                list.Add(douong);
            }

            return list;
        }
    }
}
