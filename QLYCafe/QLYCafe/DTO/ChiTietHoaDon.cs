using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DTO
{
    internal class ChiTietHoaDon
    {
        public ChiTietHoaDon(int id, int idHoaDon, int idDoUong, int count)
        {
            this.ID = id;
            this.IDHoaDon = idHoaDon;
            this.IDDoUong = idDoUong;
            this.Count = count;
        }

        public ChiTietHoaDon(DataRow row)
        {
            this.ID = (int)row["id"];
            this.IDHoaDon = (int)row["idHoaDon"];
            this.IDDoUong = (int)row["idDoUong"];
            this.Count = (int)row["count"];
        }
        private int iD;
        private int iDHoaDon;
        private int iDDoUong;
        private int count;

        public int IDDoUong
        {
            get { return iDDoUong; }
            set { iDDoUong = value; }
        }
        public int IDHoaDon
        {
            get { return iDHoaDon; }
            set { iDHoaDon = value; }
        }
        public int ID
        {
            get { return iD; }
            set { iD = value; }
        }
        public int Count
        {
            get { return count; }
            set { count = value; }
        }
    }
}
