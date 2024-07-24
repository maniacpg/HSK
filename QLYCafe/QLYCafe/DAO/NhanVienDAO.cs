using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using QLYCafe.DTO;

namespace QLYCafe.DAO
{
    internal class NhanVienDAO
    {
        private Account loginAcc;

        internal Account LoginAcc
        {
            get { return loginAcc; }
            set { loginAcc = value; AccName(loginAcc); }
        }
        public string AccName(Account Acc)
        {
            string tenTK = LoginAcc.Username;
            return tenTK;
        }
        public int GetIDNhanVienByTenTK(string tenTK)
        {
            
            // Sử dụng tham số trong câu lệnh SQL để tránh lỗi SQL Injection
            string query = "SELECT idNhanVien FROM TaiKhoan WHERE TenTK = @tenTK";

            // Sử dụng phương thức ExecuteScalar đúng cách
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { tenTK });

            // Kiểm tra nếu kết quả trả về không phải là null trước khi chuyển đổi
            if (result != null && int.TryParse(result.ToString(), out int idnv))
            {
                
                return idnv;
            }
            else
            {
                throw new Exception("Không tìm thấy nhân viên với tên tài khoản: " + tenTK);
            }
        }


        public string GetNhanVienNameByCurrentAccount(string tenTK)
        {

            int idNV = GetIDNhanVienByTenTK(tenTK);


            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM NhanVien WHERE id = @id", new object[] { idNV });

            foreach (DataRow item in data.Rows)
            {
                NhanVien nhanVien = new NhanVien(item);
                return nhanVien.TenNv;
            }
            return string.Empty;
        }

        private static Account currentAccount;

        // Hàm để lấy tài khoản hiện tại
        private Account GetCurrentAccount()
        {
            return currentAccount;
        }
        private string GetCurrentUsername()
        {
            Account account = GetCurrentAccount();
            return account != null ? account.Username : "Không có tài khoản đăng nhập";
        }
        private static NhanVienDAO instance;

        public static NhanVienDAO Instance
        {
            get { if (instance == null) instance = new NhanVienDAO(); return instance; }
            private set => instance = value;
        }

        private NhanVienDAO()
        {

        }
    }
}
