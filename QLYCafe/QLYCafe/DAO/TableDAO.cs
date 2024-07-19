using QLYCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DAO
{
    internal class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return instance; }
            private set { instance = value; }
        }


        public static int TableWidth = 100;
        public static int TableHeight = 100;

        private TableDAO() { }
        public List<Table> LoadTableList()
        {

            List<Table> list = new List<Table>();
            DataTable dt = DataProvider.Instance.ExecuteQuery("Select_Ban");
            foreach (DataRow item in dt.Rows)
            {
                Table table = new Table(item);
                list.Add(table);
            }
            return list;
        }
        public void ChuyenBan(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("ChuyenBan @idBan1, @idBan2", new object[] {id1, id2});
        }
    }
}
