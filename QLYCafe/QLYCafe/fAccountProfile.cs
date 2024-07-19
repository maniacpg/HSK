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

namespace QLYCafe
{
    public partial class fAccountProfile : Form
    {
        private Account loginAcc;

        internal Account LoginAcc
        {
            get { return loginAcc; }
            set { loginAcc = value; RoleAccount(loginAcc); }
        }
        public fAccountProfile(Account Acc)
        {
            InitializeComponent();
            this.LoginAcc = Acc;
        }

        void RoleAccount(Account Acc)
        {
            
            txbUserName.Text = LoginAcc.Username;


        }
        private void btnExitAcc_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
