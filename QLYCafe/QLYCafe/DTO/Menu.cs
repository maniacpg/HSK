using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLYCafe.DTO
{
    internal class Menu
    {
        public Menu(string tenDoUong, int soLuong, float donGia, float thanhTien)
        {
            this.SoLuong = soLuong;
            this.TenDoUong = tenDoUong;
            this.DonGia = donGia;
            this.ThanhTien = thanhTien;
        }

        public Menu(DataRow row)
        {
            this.TenDoUong = row["TenDoUong"].ToString();
            this.SoLuong = Convert.ToInt32(row["count"]);
            this.DonGia = Convert.ToSingle(row["DonGia"]);
            this.ThanhTien = Convert.ToSingle(row["ThanhTien"]);
        }
        private string tenDoUong;
        private int soLuong;
        private float donGia;
        private float thanhTien;


        public string TenDoUong { get {  return tenDoUong; } set {  tenDoUong = value; } }
        public int SoLuong { get { return soLuong; } set { soLuong = value; } }
        public float DonGia { get {  return donGia; } set {  donGia = value; } }

        public float ThanhTien { get {  return thanhTien; } set {  thanhTien = value; } }
    }
}
