using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DTO
{
    internal class NhanVien
    {
        private int iD;
        private string tenNv;
        private string sdtNv;
        private string emailNv;
        private bool gioiTinh;
        private DateTime ngaySinh;

        public NhanVien(int iD, string tenNv, string sdtNv, string emailNv, bool gioiTinh, DateTime ngaySinh)
        {
            this.ID = iD;
            this.TenNv = tenNv;
            this.SdtNv = sdtNv;
            this.EmailNv = emailNv;
            this.GioiTinh = gioiTinh;
            this.NgaySinh = ngaySinh;
            
        }
        public NhanVien(DataRow row)
        {
            this.iD = (int)row["id"];
            this.TenNv = row["TenNV"].ToString();
            this.EmailNv = row["emailNV"].ToString();
            this.SdtNv = row["SDTNV"].ToString() ;
            this.GioiTinh = (bool)row["GioiTinh"];

            this.NgaySinh = (DateTime)row["NgaySinh"];
        }

        private NhanVien() { }
        public int ID { get { return iD; } set { iD = value; } }
        public string TenNv { get {  return tenNv; } set {  tenNv = value; } }
        public string SdtNv { get { return sdtNv; } set {  sdtNv = value; } }
        public string EmailNv { get { return emailNv; } set {  emailNv = value; } }
        public bool GioiTinh { get {  return gioiTinh; } set {  gioiTinh = value; } }
        public DateTime NgaySinh { get { return ngaySinh; } set { ngaySinh = value; } }
    }
}
