using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace QLYCafe
{
    public partial class DelAcc : Form
    {
        //string connectionString = "Data Source=MANIAC\\SQLEXPRESS;Initial Catalog=QLyQuanCafe1;Integrated Security=True";
        string connectionString = ConfigurationManager.ConnectionStrings["CafeDatabase"].ConnectionString;
        public string InputValue { get; private set; }

        public DelAcc()
        {
            InitializeComponent();
        }

        
        private void btnOK_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào
            if (string.IsNullOrEmpty(txbInput.Text))
            {
                MessageBox.Show("Vui lòng nhập tên tài khoản cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string queryDelete = "Delete_TaiKhoan";

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(queryDelete, conn))
                    {
                        cmd.CommandText = queryDelete;
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@TenTK", txbInput.Text);

                        conn.Open();
                        int result = Convert.ToInt32(cmd.ExecuteScalar()); // Thực hiện lệnh xóa và lấy kết quả về

                        if (result == 1)
                        {
                            MessageBox.Show("Xóa tài khoản thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close(); // Đóng form sau khi xóa thành công
                            
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy tài khoản để xóa hoặc có lỗi xảy ra!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi xóa tài khoản: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }




        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
        

    }
}
