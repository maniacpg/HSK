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
    }
}
