using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DTO
{
    internal class Table
    {
        public Table(int id, string name, string trangthai)
        {
            this.ID = id;
            this.Name = name;
            this.TrangThai = trangthai;
        }

        public Table(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["name"].ToString();
            this.TrangThai = row["TrangThai"].ToString();
        }


        private int iD;
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        private string trangThai;
        public string TrangThai
        {
            get { return trangThai; }
            set { trangThai = value; }
        }

    }
}
