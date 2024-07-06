using QLYCafe.DAO;
using QLYCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Menu = QLYCafe.DTO.Menu;

namespace QLYCafe
{
    public partial class fTableManager : Form
    {
        public fTableManager()
        {
            InitializeComponent();
            LoadTable();
        }
        #region Method
        public void LoadTable()
        {
            List<Table> list = TableDAO.Instance.LoadTableList();
            foreach (Table item in list)
            {
                Button btn = new Button() { Width = TableDAO.TableWidth, Height = TableDAO.TableHeight };
                btn.Text = item.Name + Environment.NewLine + item.TrangThai;
                btn.Click += Btn_Click;
                btn.Tag = item;

                switch (item.TrangThai)
                {
                    case "Trống": btn.BackColor = Color.Aqua; break;
                    default: btn.BackColor = Color.IndianRed; break;
                }
                flpTable.Controls.Add(btn);
                
            }
        }

        public void ShowHoaDon(int id)
        {
            lsvBill.Items.Clear();
            List<Menu> listChiTietHD = MenuDAO.LayMenu(id);
            float thanhTien = 0;
            foreach(DTO.Menu item in listChiTietHD)
            {
                ListViewItem lsvItem = new ListViewItem(item.TenDoUong.ToString());
                lsvItem.SubItems.Add(item.SoLuong.ToString());
                lsvItem.SubItems.Add(item.DonGia.ToString());
                lsvItem.SubItems.Add(item.ThanhTien.ToString());
                thanhTien += item.ThanhTien;
                lsvBill.Items.Add(lsvItem);
            }
            txbTongTien.Text = thanhTien.ToString("c");
        }

        #endregion

        #region Events

        private void Btn_Click(object sender, EventArgs e)
        {
            int tableID = ((sender as Button).Tag as Table).ID;
            ShowHoaDon(tableID);
        }

        private void lsvBill_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            f.ShowDialog();
        }

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fAdmin f = new fAdmin();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void quảnLýNhậpHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fNhapHang f = new fNhapHang();
            f.ShowDialog();
        }

        private void tàiKhoảnToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void fTableManager_Load(object sender, EventArgs e)
        {

        }

        #endregion

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {

        }
    }
}
