using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DTO
{
    public class Account
    {
        private string username;
        private int iDnv;
        private string password;
        private int type;

        public Account(string username, int type, int idNV, string password = null)
        {
            this.Username = username;
            this.IDnv = idNV;
            this.Password = password;
            this.Type = type;
        }
            
        public Account(DataRow row)
        {
            this.IDnv = (int)row["idNhanVien"];
            this.Username = row["TenTK"].ToString();
            this.Password = row["MatKhau"].ToString();
            this.Type = (int)row["type"];
        }
        private Account() { }
        public string Username
        {
            get { return username; }
            set { username = value; }
        }
        public int IDnv { get { return iDnv; } set { iDnv = value; } }
        public string Password { get { return password; } set { password = value; } }
        public int Type {  get { return type; } set {  type = value; } }
    }
}
