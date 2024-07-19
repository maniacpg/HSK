using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLYCafe.DTO;
using Menu = QLYCafe.DTO.Menu;

namespace QLYCafe.DAO
{
    internal class MenuDAO
    {
        private static MenuDAO instance;
        public static MenuDAO Instance
        {
            get { if (instance == null) instance = new MenuDAO(); return instance; }
            private set { instance = value; }

        }
        public MenuDAO() { }

        public static List<Menu> LayMenu(int id)
        {
            List<Menu> list = new List<Menu>();
            string query = "select du.TenDoUong,ct.count, du.DonGia, du.DonGia*ct.count as ThanhTien  from ChiTietHoaDonBan as ct, HoaDonBan as hd, DoUong as du \r\nwhere ct.idHoaDon = hd.id and ct.idDoUong = du.id and hd.status = 0 and hd.idBan = " + id;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow row in data.Rows)
            {
                Menu menu = new Menu(row);
                list.Add(menu);
            }
            
            return list;
        }
    }
}
