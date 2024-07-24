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
            string query = "SELECT * FROM HoaDonBan WHERE idBan = @idBan AND status = 0";

            // Định nghĩa tham số SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@idBan", SqlDbType.Int) { Value = id }
            };

            // Thực thi câu lệnh SQL và lấy dữ liệu
            DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

            if (data.Rows.Count > 0)
            {
                HoaDon hd = new HoaDon(data.Rows[0]);
                return hd.Id;
            }

            return -1;
        }

        public void InsertHoaDon(int id)
        {
            string query = "Insert_HoaDonBan @idBan";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@idBan", SqlDbType.Int) { Value = id }
            };

            DataProvider.Instance.ExecuteNonQuery(query, parameters);

        }

        public int GetMaxIdHoaDon()
        {
            try
            {
                string query = "SELECT MAX(id) FROM HoaDonBan";

                // Không có tham số cho truy vấn này
                object result = DataProvider.Instance.ExecuteScalar(query, new SqlParameter[] { });

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
            try
            {
                // Truy vấn SQL để lấy id của nhân viên dựa vào tên tài khoản
                string queryGetIdNhanVien = "SELECT idNhanVien FROM TaiKhoan WHERE TenTK = @tenTK";
                SqlParameter[] parametersGetIdNhanVien = new SqlParameter[]
                {
            new SqlParameter("@tenTK", SqlDbType.NVarChar) { Value = tenTK }
                };

                int idNhanVien = (int)DataProvider.Instance.ExecuteScalar(queryGetIdNhanVien, parametersGetIdNhanVien);

                // Cập nhật hóa đơn
                string queryUpdateHoaDon = "UPDATE HoaDonBan SET DateCheckOut = GETDATE(), status = 1, thanhTien = @thanhTien, GiamGia = @giamgia, tongTien = @tongTien, idNhanVien = @idNhanVien WHERE id = @id";
                SqlParameter[] parametersUpdateHoaDon = new SqlParameter[]
                {
            new SqlParameter("@thanhTien", SqlDbType.Float) { Value = thanhTien },
            new SqlParameter("@giamgia", SqlDbType.Int) { Value = giamgia },
            new SqlParameter("@tongTien", SqlDbType.Float) { Value = tongTien },
            new SqlParameter("@idNhanVien", SqlDbType.Int) { Value = idNhanVien },
            new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                DataProvider.Instance.ExecuteNonQuery(queryUpdateHoaDon, parametersUpdateHoaDon);
            }
            catch (Exception e)
            {
                MessageBox.Show("Lỗi: " + e.Message);
            }
        }



        public DataTable LayDSHoaDonTheoNgay(DateTime checkIn, DateTime checkOut)
        {
            // Câu lệnh SQL với tham số
            string query = "exec ThongKeDSHoaDonTheoNgay @checkIn, @checkOut";

            // Định nghĩa các tham số SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@checkIn", SqlDbType.DateTime) { Value = checkIn },
        new SqlParameter("@checkOut", SqlDbType.DateTime) { Value = checkOut }
            };

            try
            {
                // Thực thi câu lệnh SQL và trả về dữ liệu
                return DataProvider.Instance.ExecuteQuery(query, parameters);
            }
            catch (Exception ex)
            {
                // Xử lý lỗi
                MessageBox.Show("Lỗi khi lấy danh sách hóa đơn: " + ex.Message);
                return null;
            }
        }
    }
}
