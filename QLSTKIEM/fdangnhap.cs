using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;

namespace QLSTKIEM
{
    public partial class fdangnhap : Form
    {
        public fdangnhap()
        {
            InitializeComponent();
        }

        private void btndangnhap_Click(object sender, EventArgs e)
        {
            string userName = txttaikhoan.Text;
            string passWord = txtmatkhau.Text;
            if (login(userName, passWord))
            {
                Account loginAccount = AccountBUS.Instance.GetAccountByUserName(userName);

                fmain f = new fmain(loginAccount);


                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                MessageBox.Show("Nhập sai tên đăng nhập hoặc mật khẩu");
            }
        }
        bool login(string name, string pass)
        {

            
            return AccountBUS.Instance.login(name, pass);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
