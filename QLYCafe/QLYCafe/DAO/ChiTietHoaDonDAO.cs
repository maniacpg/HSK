using QLYCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
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
                DataProvider.Instance.ExecuteNonQuery("Insert_ChitietHoaDon @idHoaDon, @idDoUong, @count", new object[] { idHoaDon, idDoUong, count });
            }
            catch (Exception e) {
                MessageBox.Show("Lỗi: " + e.Message);
            }
        }



    }
}
