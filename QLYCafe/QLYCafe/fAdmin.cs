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
        }

        private void btnEditFood_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
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

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void dgvAcc_CellContentClick(object sender, DataGridViewCellEventArgs e)
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
        public void Load_DoUongList()
        {
            string query = "select * from DoUong";

            dtgvDoUong.DataSource = DataProvider.Instance.ExecuteQuery(query);
        }

        public void Load_DanhMucDoUongList()
        {
            string query = "select * from DanhmucDoUong";

            dtgvCategory.DataSource = DataProvider.Instance.ExecuteQuery(query);
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
        private void fAdmin_Load(object sender, EventArgs e)
        {

        }

        private void dtgvBill_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
