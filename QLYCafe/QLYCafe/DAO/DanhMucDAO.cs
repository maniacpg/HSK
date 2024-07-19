using QLYCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DAO
{
    internal class DanhMucDAO
    {
        private static DanhMucDAO instance;
        public static DanhMucDAO Instance
        {
            get { if (instance == null) instance = new DanhMucDAO(); return DanhMucDAO.instance; }
            private set { DanhMucDAO.instance = value; }
        }
        public DanhMucDAO() { }

        public List<DanhMuc> GetListDanhMuc()
        {
            List<DanhMuc> listdm = new List<DanhMuc>();
            string query = "select * from DanhmucDoUong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow item in data.Rows)
            {
                DanhMuc danhmuc = new DanhMuc(item);
                listdm.Add(danhmuc);
            }
            return listdm;
        }
    }
}
