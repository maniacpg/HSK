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
    internal class HoaDonDAO
    {
        private Account loginAcc;

        

        
        public static HoaDonDAO instance;

        public static HoaDonDAO Instance
        {
            get { if (instance == null) instance = new HoaDonDAO(); return HoaDonDAO.instance; }
            set { instance = value; }
        }
        private HoaDonDAO() { }

        public int LayIDHoaDonChuaThanhToan(int id)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from HoaDonBan where idBan = " + id + " and status = 0");
            if (data.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(data.Rows[0]);
                return hd.Id;
            }
            return -1;
        }
        public void InsertHoaDon(int id)
        {
            DataProvider.Instance.ExecuteNonQuery("Insert_HoaDonBan @idBan", new object[] { id });
            
        }

        public int GetMaxIdHoaDon()
        {
            try
            {
                object result = DataProvider.Instance.ExecuteScalar("SELECT MAX(id) FROM HoaDonBan");

                if (result != DBNull.Value && result != null)
                {
                    return Convert.ToInt32(result);
                }
                else
                {
                    // Xử lý khi không có id nào
                    return 0;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
                return -1;
            }
        }

        public void CheckOut(int id, int giamgia, float thanhTien, float tongTien, string tenTK)
        {
            // Truy vấn SQL để lấy id của nhân viên dựa vào tên tài khoản
            string queryGetIdNhanVien = "SELECT idNhanVien FROM TaiKhoan WHERE TenTK = @tenTK";
            int idNhanVien = (int)DataProvider.Instance.ExecuteScalar(queryGetIdNhanVien, new object[] { tenTK });

            // Cập nhật hóa đơn
            string query = "UPDATE HoaDonBan SET DateCheckOut = GETDATE(), status = 1, thanhTien = @thanhTien, GiamGia = @giamgia, tongTien = @tongTien, idNhanVien = @idNhanVien WHERE id = @id";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { thanhTien, giamgia, tongTien, idNhanVien, id });
        }



        public DataTable LayDSHoaDonTheoNgay(DateTime checkIn, DateTime checkOut)
        {
           return DataProvider.Instance.ExecuteQuery("exec ThongKeDSHoaDonTheoNgay @checkIn, @checkOut", new object[] { checkIn, checkOut });
        }
    }
}
