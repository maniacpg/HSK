using QLYCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DAO
{
    internal class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return AccountDAO.instance; }
            private set => instance = value;
        }
        private AccountDAO() { }

        public bool Login(string userName, string passWord)
        {
            string query = "sp_GetTaiKhoanByTenTKAndMatKhau @TenTK = '"+userName+"', @MatKhau = '"+passWord+"';";
            DataTable result = DataProvider.Instance.ExecuteQuery(query);
            return result.Rows.Count > 0;
        }
        public Account GetAccountByUserName(string username)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("select * from TaiKhoan where TenTK = '" + username+"'");

            foreach(DataRow item in data.Rows)
            {
                return new Account(item);
            }
            return null;
        }
        public int GetIdNhanVienByTenTK(string tenTK)
        {
            string query = "SELECT idNhanVien FROM TaiKhoan WHERE TenTK = @TenTK";
            object result = DataProvider.Instance.ExecuteScalar(query, new object[] { tenTK });
            return result != null ? Convert.ToInt32(result) : -1; // Trả về -1 nếu không tìm thấy
        }
    }
}
