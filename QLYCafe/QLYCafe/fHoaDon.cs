using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using CrystalDecisions.CrystalReports.Engine;

namespace QLYCafe
{

    public partial class fHoaDon : Form
    {
        string connectionString = ConfigurationManager.ConnectionStrings["CafeDatabase"].ConnectionString;
        public fHoaDon()
        {
            InitializeComponent();
        }

        private void fHoaDon_Load(object sender, EventArgs e)
        {

        }
        public void ShowHD( string tenProc, int tableId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = tenProc;
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@idBan", tableId); // Thêm tham số @tableId

                    using (SqlDataAdapter adapter = new SqlDataAdapter())
                    {
                        adapter.SelectCommand = cmd;
                        using (DataTable dt = new DataTable())
                        {
                            adapter.Fill(dt);

                            
                            ReportDocument report = new ReportDocument();
                            string path = "C:\\Users\\Maniac\\Documents\\HSK\\BTL_LTHSK2024\\CF\\HSK\\QLYCafe\\QLYCafe\\Report\\HoaDon.rpt";
                            report.Load(path);

                            report.Database.Tables[0].SetDataSource(dt); 

                            

                            crystalReportViewer1.ReportSource = report;
                            crystalReportViewer1.Refresh();
                        }
                    }
                }
            }
        }

    }
}
