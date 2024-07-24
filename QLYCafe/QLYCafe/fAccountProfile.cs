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

namespace QLYCafe
{
    public partial class fAccountProfile : Form
    {
        private Account loginAcc;

        internal Account LoginAcc
        {
            get { return loginAcc; }
            set { loginAcc = value; RoleAccount(loginAcc); AccName(loginAcc); }
        }
        public fAccountProfile(Account Acc)
        {
            InitializeComponent();
            
            this.LoginAcc = Acc;
            
        }
        private void fAccountProfile_Load(object sender, EventArgs e)
        {
           
        }
        public string AccName(Account Acc)
        {
            string tentk = LoginAcc.Username;
            return tentk;
        }
        void RoleAccount(Account Acc)
        {
            Account account = GetCurrentAccount();
            string tenTK = AccName(account);
            txbUserName.Text = LoginAcc.Username;
            txbDisplayName.Text = NhanVienDAO.Instance.GetNhanVienNameByCurrentAccount(tenTK);

        }
        private static Account currentAccount;
        private Account GetCurrentAccount()
        {
            return currentAccount;
        }

        private void btnExitAcc_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        
    }
}
