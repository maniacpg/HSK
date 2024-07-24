using CrystalDecisions.CrystalReports.Engine;
using QLYCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLYCafe
{
    public partial class fAdmin : Form
    {
        //string connectionString = "Data Source=MANIAC\\SQLEXPRESS;Initial Catalog=QLyQuanCafe1;Integrated Security=True";

        public fAdmin()
        {
            InitializeComponent();
            Load_AccList();
            Load_DoUongList();
            Load_DanhMucDoUongList();
            Load_BanList();
            LoadDanhMucDoUongIntoComboBox();

            // Khởi tạo combobox trạng thái
            cbTableStatus.Items.Add("Trống");
            cbTableStatus.Items.Add("Đầy");
            cbTableStatus.Items.Add("Không sử dụng");
            cbTableStatus.Items.Add("Đang sửa");
            cbTableStatus.SelectedIndex = 0;    // Mặc định chọn "Trống"

            // Đăng ký sự kiện cho các nút
            btnAddFood.Click += btnAddFood_Click;
            btnEditFood.Click += btnEditFood_Click;
            btnDelFood.Click += btnDelFood_Click;

            // Đăng ký sự kiện cho DataGridView
            dtgvDoUong.CellContentClick += dtgvFood_CellContentClick;
            dtgvCategory.CellContentClick += dtgvCategory_CellContentClick;
        }
        #region method
        private void fAdmin_Load(object sender, EventArgs e)
        {

        }
        private void AddAccForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Load_AccList(); // Load lại dữ liệu sau khi form AddAcc đã đóng
        }
        public void Load_AccList()
        {


            string query = "Select_All_TaiKhoan";

            dgvAcc.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        public void Load_BanList()
        {
            try
            {
                string query = "SELECT id AS 'ID', name AS 'Số bàn', TrangThai AS 'Trạng thái' FROM Ban";
                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                if (data != null && data.Rows.Count > 0)
                {
                    dgvTable.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách bàn: " + ex.Message);
            }
        }

        public void Load_DoUongList()
        {
            try
            {
                // Câu lệnh SQL sử dụng JOIN để kết hợp bảng DoUong và DanhmucDoUong
                string query = @"
            SELECT 
                d.id AS 'ID', 
                d.TenDoUong AS 'Tên đồ uống', 
                c.TenDanhMuc AS 'Danh mục', 
                d.DonGia AS 'Đơn giá'
            FROM DoUong d
            JOIN DanhmucDoUong c ON d.idDanhMuc = c.id";

                DataTable data = DataProvider.Instance.ExecuteQuery(query);

                if (data != null && data.Rows.Count > 0)
                {
                    dtgvDoUong.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Không có dữ liệu để hiển thị.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải danh sách đồ uống: " + ex.Message);
            }
        }


        public void Load_DanhMucDoUongList()
        {
            string query = "SELECT id AS 'ID danh mục', TenDanhMuc AS 'Tên danh mục' FROM DanhmucDoUong";

            dtgvCategory.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        void LoadListByDate(DateTime checkIn, DateTime checkOut)
        {
            dtgvBill.DataSource = HoaDonDAO.Instance.LayDSHoaDonTheoNgay(checkIn, checkOut);
        }
        #endregion



        #region events
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            // Kiểm tra giá trị ID hợp lệ
            if (!int.TryParse(txbFoodID.Text, out int id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            // Lấy các giá trị từ các điều khiển giao diện người dùng
            string tenDoUong = txbFoodName.Text.Trim();
            if (string.IsNullOrEmpty(tenDoUong))
            {
                MessageBox.Show("Tên đồ uống không được để trống!");
                return;
            }

            if (!int.TryParse(cbxFoodCategory.SelectedValue.ToString(), out int idDanhMuc))
            {
                MessageBox.Show("Danh mục đồ uống không hợp lệ!");
                return;
            }

            float donGia = (float)nmFoodPrice.Value;

            // Câu lệnh SQL để cập nhật thông tin đồ uống
            string query = "UPDATE DoUong SET TenDoUong = @TenDoUong, idDanhMuc = @idDanhMuc, DonGia = @DonGia WHERE id = @id";

            // Định nghĩa các tham số SQL
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id },
        new SqlParameter("@TenDoUong", SqlDbType.NVarChar) { Value = tenDoUong },
        new SqlParameter("@idDanhMuc", SqlDbType.Int) { Value = idDanhMuc },
        new SqlParameter("@DonGia", SqlDbType.Float) { Value = donGia }
            };

            try
            {
                // Thực thi câu lệnh SQL
                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật đồ uống thành công!");
                    Load_DoUongList(); // Load lại danh sách đồ uống sau khi cập nhật
                }
                else
                {
                    MessageBox.Show("Cập nhật đồ uống thất bại!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }

        private void txbSearchFoodName_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txbFoodName_TextChanged(object sender, EventArgs e)
        {

        }

        private void dtgvFood_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra nếu chỉ số hàng là hợp lệ
            if (e.RowIndex >= 0)
            {
                try
                {
                    DataGridViewRow row = this.dtgvDoUong.Rows[e.RowIndex];

                    // Kiểm tra và lấy giá trị ID
                    if (row.Cells["ID"].Value != DBNull.Value)
                        txbFoodID.Text = row.Cells["ID"].Value.ToString();
                    else
                        txbFoodID.Text = string.Empty;

                    // Kiểm tra và lấy tên đồ uống
                    if (row.Cells["Tên đồ uống"].Value != DBNull.Value)
                        txbFoodName.Text = row.Cells["Tên đồ uống"].Value.ToString();
                    else
                        txbFoodName.Text = string.Empty;

                    // Kiểm tra và lấy danh mục đồ uống
                    if (row.Cells["Danh mục"].Value != DBNull.Value)
                    {
                        int categoryId;
                        if (int.TryParse(row.Cells["Danh mục"].Value.ToString(), out categoryId))
                            cbxFoodCategory.SelectedValue = categoryId;
                    }

                    // Kiểm tra và lấy đơn giá
                    if (row.Cells["Đơn giá"].Value != DBNull.Value)
                    {
                        decimal price;
                        if (decimal.TryParse(row.Cells["Đơn giá"].Value.ToString(), out price))
                            nmFoodPrice.Value = price;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi lấy dữ liệu từ DataGridView: " + ex.Message);
                }
            }
        }


        public void LoadDanhMucDoUongIntoComboBox()
        {
            string query = "SELECT id, TenDanhMuc FROM DanhmucDoUong";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            cbxFoodCategory.DataSource = data;
            cbxFoodCategory.DisplayMember = "TenDanhMuc"; // Cột hiển thị
            cbxFoodCategory.ValueMember = "id"; // Giá trị thực
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvAcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }



        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            AddAcc f = new AddAcc();
            f.FormClosed += AddAccForm_FormClosed;
            f.ShowDialog();

        }
        private void btnDelAcc_Click(object sender, EventArgs e)
        {

            DelAcc f = new DelAcc();
            f.FormClosed += AddAccForm_FormClosed;
            f.ShowDialog();
        }


        private void dtgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnViewBill_Click(object sender, EventArgs e)
        {
            LoadListByDate(dtpFrom.Value, dtpTo.Value);
        }

        #endregion

        private bool IsIdExists(int id)
        {
            string query = "SELECT COUNT(*) FROM DoUong WHERE id = @id";
            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            int count = (int)DataProvider.Instance.ExecuteScalar(query, parameters);
            return count > 0;
        }


        private void btnAddFood_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txbFoodID.Text, out id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            if (IsIdExists(id))
            {
                //MessageBox.Show("ID đã tồn tại trong cơ sở dữ liệu!");
                return;
            }

            string tenDoUong = txbFoodName.Text.Trim();
            if (string.IsNullOrEmpty(tenDoUong))
            {
                MessageBox.Show("Tên đồ uống không được để trống!");
                return;
            }

            int idDanhMuc = (int)cbxFoodCategory.SelectedValue;
            float donGia = (float)nmFoodPrice.Value;

            string query = "INSERT INTO DoUong (id, TenDoUong, idDanhMuc, DonGia) VALUES (@id, @TenDoUong, @idDanhMuc, @DonGia)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id },
        new SqlParameter("@TenDoUong", SqlDbType.NVarChar) { Value = tenDoUong },
        new SqlParameter("@idDanhMuc", SqlDbType.Int) { Value = idDanhMuc },
        new SqlParameter("@DonGia", SqlDbType.Float) { Value = donGia }
            };

            try
            {
                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Thêm đồ uống thành công!");
                    Load_DoUongList(); // Load lại danh sách đồ uống sau khi thêm
                }
                else
                {
                    //MessageBox.Show("Thêm đồ uống thất bại!");
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show("Lỗi cơ sở dữ liệu: " + ex.Message);
            }
        }


        private void btnDelFood_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txbFoodID.Text, out id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            string query = "DELETE FROM DoUong WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            if (result > 0)
            {
                MessageBox.Show("Xóa đồ uống thành công!");
                Load_DoUongList(); // Load lại danh sách đồ uống sau khi xóa
            }
            else
            {
                //MessageBox.Show("Xóa đồ uống thất bại!");
            }
        }

        private void btnShowTable_Click(object sender, EventArgs e)
        {

        }

        private void nmFoodPrice_ValueChanged(object sender, EventArgs e)
        {

        }

        private void cbxFoodCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dgvTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dgvTable.Rows[e.RowIndex];

                tbTableID.Text = row.Cells["ID"].Value.ToString();
                tbTableName.Text = row.Cells["Số bàn"].Value.ToString();
                cbTableStatus.SelectedValue = row.Cells["Trạng thái"].Value;
            }
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(tbTableID.Text, out id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            string tenBan = tbTableName.Text.Trim();
            if (string.IsNullOrEmpty(tenBan))
            {
                MessageBox.Show("Tên bàn không được để trống!");
                return;
            }

            string trangThai = cbTableStatus.SelectedItem.ToString();

            string query = "INSERT INTO Ban (id, name, TrangThai) VALUES (@id, @name, @TrangThai)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id },
        new SqlParameter("@name", SqlDbType.NVarChar) { Value = tenBan },
        new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = trangThai }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            if (result > 0)
            {
                MessageBox.Show("Thêm bàn thành công!");
                Load_BanList(); // Load lại danh sách bàn sau khi thêm
            }
            else
            {
                MessageBox.Show("Thêm bàn thất bại!");
            }
        }

        private void btnEditTable_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(tbTableID.Text, out id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            string tenBan = tbTableName.Text.Trim();
            if (string.IsNullOrEmpty(tenBan))
            {
                MessageBox.Show("Tên bàn không được để trống!");
                return;
            }

            string trangThai = cbTableStatus.SelectedItem.ToString();

            string query = "UPDATE Ban SET name = @name, TrangThai = @TrangThai WHERE id = @id";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id },
        new SqlParameter("@name", SqlDbType.NVarChar) { Value = tenBan },
        new SqlParameter("@TrangThai", SqlDbType.NVarChar) { Value = trangThai }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            if (result > 0)
            {
                MessageBox.Show("Cập nhật bàn thành công!");
                Load_BanList(); // Load lại danh sách bàn sau khi cập nhật
            }
            else
            {
                MessageBox.Show("Cập nhật bàn thất bại!");
            }
        }

        private void btnDelTable_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(tbTableID.Text, out id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            // Xác nhận xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa bàn này?", "Xác nhận", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string query = "DELETE FROM Ban WHERE id = @id";

                SqlParameter[] parameters = new SqlParameter[]
                {
            new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa bàn thành công!");
                    Load_BanList(); // Load lại danh sách bàn sau khi xóa
                }
                else
                {
                    MessageBox.Show("Xóa bàn thất bại!");
                }
            }
        }

        private void cbTableStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dtgvCategory_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = this.dtgvCategory.Rows[e.RowIndex];

                txbCategoryID.Text = row.Cells["ID danh mục"].Value.ToString();
                txbCategoryName.Text = row.Cells["Tên danh mục"].Value.ToString();
            }
        }

        private void btnEditCate_Click(object sender, EventArgs e)
        {
            {
                int id;
                if (!int.TryParse(txbCategoryID.Text, out id))
                {
                    MessageBox.Show("ID không hợp lệ!");
                    return;
                }

                string tenDanhMuc = txbCategoryName.Text.Trim();
                if (string.IsNullOrEmpty(tenDanhMuc))
                {
                    MessageBox.Show("Tên danh mục không được để trống!");
                    return;
                }

                string query = "UPDATE DanhmucDoUong SET TenDanhMuc = @TenDanhMuc WHERE id = @id";

                SqlParameter[] parameters = new SqlParameter[]
                {
        new SqlParameter("@id", SqlDbType.Int) { Value = id },
        new SqlParameter("@TenDanhMuc", SqlDbType.NVarChar) { Value = tenDanhMuc }
                };

                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Cập nhật danh mục đồ uống thành công!");
                    Load_DanhMucDoUongList(); // Load lại danh sách danh mục đồ uống sau khi cập nhật
                }
                else
                {
                    MessageBox.Show("Cập nhật danh mục đồ uống thất bại!");
                }
            }
        }

        private void btnDelCate_Click(object sender, EventArgs e)
        {
            {
                int id;
                if (!int.TryParse(txbCategoryID.Text, out id))
                {
                    MessageBox.Show("ID không hợp lệ!");
                    return;
                }

                string query = "DELETE FROM DanhmucDoUong WHERE id = @id";

                SqlParameter[] parameters = new SqlParameter[]
                {
        new SqlParameter("@id", SqlDbType.Int) { Value = id }
                };

                int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

                if (result > 0)
                {
                    MessageBox.Show("Xóa danh mục đồ uống thành công!");
                    Load_DanhMucDoUongList(); // Load lại danh sách danh mục đồ uống sau khi xóa
                }
                else
                {
                    MessageBox.Show("Xóa danh mục đồ uống thất bại!");
                }
            }
        }

        private void btnAddCate_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txbCategoryID.Text, out id))
            {
                MessageBox.Show("ID không hợp lệ!");
                return;
            }

            string tenDanhMuc = txbCategoryName.Text.Trim();
            if (string.IsNullOrEmpty(tenDanhMuc))
            {
                MessageBox.Show("Tên danh mục không được để trống!");
                return;
            }

            string query = "INSERT INTO DanhmucDoUong (id, TenDanhMuc) VALUES (@id, @TenDanhMuc)";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@id", SqlDbType.Int) { Value = id },
        new SqlParameter("@TenDanhMuc", SqlDbType.NVarChar) { Value = tenDanhMuc }
            };

            int result = DataProvider.Instance.ExecuteNonQuery(query, parameters);

            if (result > 0)
            {
                MessageBox.Show("Thêm danh mục đồ uống thành công!");
                Load_DanhMucDoUongList(); // Load lại danh sách danh mục đồ uống sau khi thêm
            }
            else
            {
                MessageBox.Show("Thêm danh mục đồ uống thất bại!");
            }
        }

        private void txbCategoryName_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem ID đã được nhập hay chưa
            if (string.IsNullOrEmpty(txbSearchFoodName.Text))
            {
                MessageBox.Show("Vui lòng nhập ID để tìm kiếm.");
                Load_DoUongList();
                return;
            }

            // Xử lý ID nhập vào
            if (!int.TryParse(txbSearchFoodName.Text, out int searchID))
            {
                MessageBox.Show("ID không hợp lệ.");
                return;
            }

            // Thực hiện truy vấn tìm kiếm
            string query = "SELECT d.id AS 'ID', d.TenDoUong AS 'Tên đồ uống', c.TenDanhMuc AS 'Danh mục', d.DonGia AS 'Đơn giá' " +
                           "FROM DoUong d " +
                           "JOIN DanhmucDoUong c ON d.idDanhMuc = c.id " +
                           "WHERE d.id = @searchID";

            SqlParameter[] parameters = new SqlParameter[]
            {
        new SqlParameter("@searchID", SqlDbType.Int) { Value = searchID }
            };

            try
            {
                DataTable data = DataProvider.Instance.ExecuteQuery(query, parameters);

                if (data != null && data.Rows.Count > 0)
                {
                    dtgvDoUong.DataSource = data;
                }
                else
                {
                    MessageBox.Show("Không tìm thấy đồ uống với ID này.");
                    dtgvDoUong.DataSource = null; // Xóa dữ liệu cũ
                    Load_DoUongList();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tìm kiếm đồ uống: " + ex.Message);
            }
        }

        private void btnInHD_Click(object sender, EventArgs e)
        {
            try
            {
                using (FormInHD formInHD = new FormInHD())
                {
                    // Cung cấp các tham số cần thiết cho phương thức ShowReport
                    formInHD.ShowReport("InHD.rpt", "Select_HoaDonBan", null);
                    formInHD.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi in hóa đơn: " + ex.Message);
            }
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
