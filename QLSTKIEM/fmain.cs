using DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSTKIEM
{
    public partial class fmain : Form
    {
        private Account loginAccount;
        Account LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;

            }
        }
        public fmain(Account acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            changeAccount(loginAccount.Type);
        }
        void changeAccount(int type)
        {
            

        }
        

        private void adminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void báoCáoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void báoCáoNgàyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbaocaongay f = new fbaocaongay();
            f.Show();
        }

        private void báoCáoThángToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fbaocaothang f = new fbaocaothang();
            f.Show();
        }

        private void kháchHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void thôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            fkhachhang f = new fkhachhang();
            f.Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            fmoso f = new fmoso(loginAccount);
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fguitien f = new fguitien(loginAccount);
            f.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            fruttien f = new fruttien(loginAccount);
            f.Show();
        }
    }
}
