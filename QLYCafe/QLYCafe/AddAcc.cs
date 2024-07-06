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
    public partial class AddAcc : Form
    {
        //string connectionString = "Data Source=MANIAC\\SQLEXPRESS;Initial Catalog=QLyQuanCafe1;Integrated Security=True";
        string connectionString = ConfigurationManager.ConnectionStrings["CafeDatabase"].ConnectionString;
        private ErrorProvider errorProvider;
        public AddAcc()
        {
            InitializeComponent();
        }

        private void btnAddAcc_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txbTen.Text) ||
                string.IsNullOrEmpty(txbAccName.Text) ||
                string.IsNullOrEmpty(txbMatKhau.Text) ||
                cbTypeAcc.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin.", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            string queryInsert = "Insert_TaiKhoan";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryInsert, conn))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@Ten", txbTen.Text);
                        cmd.Parameters.AddWithValue("@TenTK", txbAccName.Text);
                        cmd.Parameters.AddWithValue("@MatKhau", txbMatKhau.Text);

                        // Kiểm tra và chuyển đổi giá trị của ComboBox thành int
                        if (int.TryParse(cbTypeAcc.SelectedIndex.ToString(), out int type))
                        {
                            cmd.Parameters.AddWithValue("@Type", type);
                        }
                        else
                        {
                            MessageBox.Show("Lỗi: Loại tài khoản không hợp lệ.", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                        }

                        conn.Open();
                        int result = (int)cmd.ExecuteNonQuery();

                        if (result == 1)
                        {
                            MessageBox.Show("Thêm tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            this.Close(); // Đóng form sau khi thêm thành công
                        }
                        else
                        {
                            MessageBox.Show("Tên tài khoản đã tồn tại. Vui lòng chọn tên khác.", "Cảnh báo!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi thêm tài khoản: " + ex.Message);
            }
        }

        private void AddAcc_Load(object sender, EventArgs e)
        {

        }
    }
}
