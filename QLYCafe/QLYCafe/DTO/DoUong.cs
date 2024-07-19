using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DTO
{
    internal class DoUong
    {
        public DoUong(int id, string name, int iddanhmuc, float dongia)
        {
            this.ID = id;
            this.Name = name;
            this.IDDanhMuc = iddanhmuc;
            this.Dongia = dongia;
        }

        public DoUong(DataRow row)
        {
            this.ID = (int)row["id"];
            this.Name = row["TenDoUong"].ToString();
            this.IDDanhMuc = (int)row["idDanhMuc"];
            this.Dongia = (float)Convert.ToDouble(row["DonGia"].ToString());
        }

        private int iD;
        private string name;
        private int iDdanhmuc;
        private float dongia;

        public int ID { get { return iD; } set { iD = value; } }
        public string Name { get { return name; } set { name = value; } }
        public float Dongia { get { return dongia; } set { dongia = value; } }
        public int IDDanhMuc { get { return iDdanhmuc; } set { iDdanhmuc = value; } }

    }
}
