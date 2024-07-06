using QLYCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DAO
{
    internal class HoaDonDAO
    {
        public static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            set { instance = value; }
        }
        private HoaDonDAO() { }

        public int LayIDHoaDonChuaThanhToan(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HoaDon where idBan = "+id+" and status = 0");
            if(data.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(data.Rows[0]);
                return hd.Id;
            }
            return -1;
        }
    }
}
