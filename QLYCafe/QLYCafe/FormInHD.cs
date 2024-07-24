using CrystalDecisions.CrystalReports.Engine;
using CrystalDecisions.Windows.Forms;
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

namespace QLYCafe
{
    public partial class FormInHD : Form
    {
        public FormInHD()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=QLCF2;Integrated Security=True";
        public void ShowReport(string tenBC, string tenProc, string reportFilter)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = tenProc;
                        cmd.CommandType = CommandType.StoredProcedure;

                        QLCF2DataSet dataSet = new QLCF2DataSet();
                        string tableName = "select_HoaDonBan";

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.Fill(dataSet, tableName);

                            if (dataSet.Tables[tableName].Rows.Count == 0)
                            {
                                MessageBox.Show("Không có dữ liệu để hiển thị.");
                                return;
                            }

                            ReportDocument report = new ReportDocument();
                            string path = "D:\\C#\\HSK-master\\QLYCafe\\QLYCafe\\InHD.rpt";

                            try
                            {
                                report.Load(path);
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Lỗi khi tải báo cáo: " + ex.Message);
                                return;
                            }

                            report.SetDataSource(dataSet);

                            if (!string.IsNullOrEmpty(reportFilter))
                            {
                                report.RecordSelectionFormula = reportFilter;
                            }

                            crystalReportViewer1.ReportSource = report;
                            crystalReportViewer1.Refresh();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }






        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {

        }
    }
}
