using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLYCafe.DAO
{
    internal class DataProvider
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["CafeDatabase"].ConnectionString;

        private static DataProvider instance;

        internal static DataProvider Instance
        {
            get { if (instance == null) instance = new DataProvider(); return DataProvider.instance; }
            private set { DataProvider.instance = value; }
        }

        private DataProvider() { }

        public DataTable ExecuteQuery(string query)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandText = query;
                        //cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            adapter.SelectCommand = cmd;
                            using (DataTable dt = new DataTable())
                            {
                                adapter.Fill(dt);
                                return dt;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return new DataTable();
            }
        }

        public int ExecuteNonQuery(string query)
        {
            int data = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandText = query;
                        //cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            data = cmd.ExecuteNonQuery();
                            return data;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

        public object ExecuteScaLar(string query, object[] parameter = null)
        {
            object data = 0;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.CommandText = query;
                        //cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            if (parameter != null)
                            {
                                string[] listPara = query.Split(' ');
                                int i = 0;
                                foreach (string item in listPara)
                                {
                                    if (item.Contains("@"))
                                    {
                                        cmd.Parameters.AddWithValue(item, parameter);
                                        i++;
                                    }
                                }
                            }
                            data = cmd.ExecuteScalar();
                        }
                        
                    }
                }
                return data;
            }
            catch (Exception ex)
            {

                return -1;
            }
        }

    }
}
