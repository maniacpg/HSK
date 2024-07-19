using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DTO
{
    internal class DanhMuc
    {
        public DanhMuc(int id, string name)
        {
            this.ID = id;
            this.Name = name;
        }

        public DanhMuc(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["TenDanhMuc"].ToString();
        }
        

        private int iD;
        private string name;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
    }
}
