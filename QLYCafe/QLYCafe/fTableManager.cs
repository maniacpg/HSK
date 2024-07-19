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
        private Account loginAcc;

        internal Account LoginAcc
        {
            get { return loginAcc; }
            set { loginAcc = value; RoleAccount(loginAcc.Type); AccName(loginAcc); }
        }
        
        

        public fTableManager(Account Acc)
        {
            InitializeComponent();
            LoadTable();
            LoadDanhMuc();
            LoadCBTable(cbSwitchTable);
            this.LoginAcc = Acc;

        }
        #region Method
        void RoleAccount(int type)
        {
            adminToolStripMenuItem.Enabled = type == 1;
           tàiKhoảnToolStripMenuItem.Text += " (" + LoginAcc.Username + ")";
        }
        public string AccName(Account Acc)
        {
            string tentk = LoginAcc.Username;
            return tentk;
        }
        public void LoadDanhMuc()
        {
            List<DanhMuc> listdm = DanhMucDAO.Instance.GetListDanhMuc();
            cbCategory.DataSource = listdm;
            cbCategory.DisplayMember = "Name";
        }
        public void LoadDoUongByIDDanhMuc(int id)
        {
            List<DoUong> listdu = DoUongDAO.Instance.GetDoUongByIDDanhMuc(id);
            cbFood.DataSource = listdu;
            cbFood.DisplayMember = "Name";
        }

        public void LoadTable()
        {
            flpTable.Controls.Clear();
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
        public void LoadCBTable(ComboBox cb)
        {
            cb.DataSource = TableDAO.Instance.LoadTableList();
            cb.DisplayMember = "Name";
        }
        public void ShowHoaDon(int id)
        {

            lsvBill.Items.Clear();
            List<Menu> listChiTietHD = MenuDAO.LayMenu(id);
            float thanhTien = 0;
            foreach (DTO.Menu item in listChiTietHD)
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
            lsvBill.Tag = (sender as Button).Tag;

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
            fAccountProfile f = new fAccountProfile(loginAcc);
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
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                if (lsvBill.Tag == null)
                {
                    MessageBox.Show("Vui lòng chọn bàn trước khi thanh toán!", "Thông báo", MessageBoxButtons.OK);
                    return;
                }

                Table table = lsvBill.Tag as Table;
                int idHoaDon = HoaDonDAO.Instance.LayIDHoaDonChuaThanhToan(table.ID);
                int giamgia = (int)nmDiscount.Value;
                double thanhTien = Convert.ToDouble(txbTongTien.Text.Split(',')[0]);
                double tongTien = thanhTien - (thanhTien / 100) * giamgia;

                Account account = GetCurrentAccount(); 
                string tenTK = AccName(account);   

                if (idHoaDon != -1)
                {
                    if (MessageBox.Show(string.Format("Bạn có chắc chắn muốn thanh toán hóa đơn cho {0}\n Thành tiền - (Thành tiền / 100) x Giảm giá ={1} - ({1} / 100) x {2} = {3}", table.Name, thanhTien, giamgia, tongTien), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        HoaDonDAO.Instance.CheckOut(idHoaDon, giamgia, (float)thanhTien, (float)tongTien, tenTK);
                        ShowHoaDon(table.ID);
                    }
                }
                else
                {
                    MessageBox.Show(table.Name + " trống!", "Thông báo", MessageBoxButtons.OK);
                }

                LoadTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private static Account currentAccount;

        // Hàm để lấy tài khoản hiện tại
        private Account GetCurrentAccount()
        {
            return currentAccount;
        }

        // Hàm để lấy tên đăng nhập từ tài khoản hiện tại
        private string GetCurrentUsername()
        {
            Account account = GetCurrentAccount();
            return account != null ? account.Username : "Không có tài khoản đăng nhập";
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cb = sender as ComboBox;
            if (cb.SelectedItem == null) { return; }
            DanhMuc selected = cb.SelectedItem as DanhMuc;
            id = selected.ID;
            LoadDoUongByIDDanhMuc(id);
        }
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            if (lsvBill.Tag == null)
            {
                MessageBox.Show("Vui lòng chọn bàn trước khi thêm đồ uống!", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            Table tb = lsvBill.Tag as Table;
            int idHoaDon = HoaDonDAO.Instance.LayIDHoaDonChuaThanhToan(tb.ID);

            int idDoUong = (cbFood.SelectedItem as DoUong).ID;
            int count = (int)nmFoodCount.Value;
            if (idHoaDon == -1)
            {

                HoaDonDAO.Instance.InsertHoaDon(tb.ID);
                int idHD = HoaDonDAO.Instance.GetMaxIdHoaDon();
                ChiTietHoaDonDAO.Instance.InsertChitiet(idHD, idDoUong, count);
            }
            else
            {
                ChiTietHoaDonDAO.Instance.InsertChitiet(idHoaDon, idDoUong, count);
            }
            ShowHoaDon(tb.ID);

            LoadTable();

        }
        private void btnSwitchTable_Click(object sender, EventArgs e)
        {

            int id1 = (lsvBill.Tag as Table).ID;
            int id2 = (cbSwitchTable.SelectedItem as Table).ID;
            if (MessageBox.Show(string.Format("Bạn có muốn chuyển bàn {0} sang bàn {1}", (lsvBill.Tag as Table).Name, (cbSwitchTable.SelectedItem as Table).Name), "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                TableDAO.Instance.ChuyenBan(id1, id2);
                LoadTable();
            }
        }


        #endregion

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
