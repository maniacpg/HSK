using QLYCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
            string query = "ChuyenBan @idBan1, @idBan2";

            // Định nghĩa các tham số SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@idBan1", SqlDbType.Int) { Value = id1 },
        new SqlParameter("@idBan2", SqlDbType.Int) { Value = id2 }
            };

            try
            {
                // Thực thi câu lệnh SQL
                DataProvider.Instance.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
    }
}
