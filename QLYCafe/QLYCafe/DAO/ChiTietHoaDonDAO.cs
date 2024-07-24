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
    internal class ChiTietHoaDonDAO
    {
        private static ChiTietHoaDonDAO instance;
        public static ChiTietHoaDonDAO Instance
        {
            get { if (instance == null) instance = new ChiTietHoaDonDAO(); return ChiTietHoaDonDAO.instance; }
            private set { ChiTietHoaDonDAO.instance = value; }
        }

        private ChiTietHoaDonDAO() { }

        public List<ChiTietHoaDon> LayDSCTHD(int id)
        {
            List<ChiTietHoaDon> listChiTietHoaDon = new List<ChiTietHoaDon>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM ChiTietHoaDonBan where idHoaDon = " + id);
            foreach (DataRow item in data.Rows)
            {
                ChiTietHoaDon chitiet = new ChiTietHoaDon(item);
                listChiTietHoaDon.Add(chitiet);
            }
            return listChiTietHoaDon;
        }
        public void InsertChitiet(int idHoaDon, int idDoUong, int count)
        {
            try
            {
                string query = "Insert_ChitietHoaDon @idHoaDon, @idDoUong, @count";
                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@idHoaDon", SqlDbType.Int) { Value = idHoaDon },
            new SqlParameter("@idDoUong", SqlDbType.Int) { Value = idDoUong },
            new SqlParameter("@count", SqlDbType.Int) { Value = count }
                };

                DataProvider.Instance.ExecuteNonQuery(query, parameters);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message);
            }
        }



    }
}
