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
    public partial class fruttien : Form
    {
        private Account loginAccount;

        Account LoginAccount
        {
            get { return loginAccount; }
            set
            {
                loginAccount = value;

                changeAccount(loginAccount);
            }
        }
        BindingSource listruttien = new BindingSource();
        public fruttien(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            loadData();
        }
        void changeAccount(Account acc)
        {

            
            txtnguoirut.Text = loginAccount.Name;

        }
        public void loadData()
        {

            dtgvrut.DataSource = listruttien;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {

            txtmaphieu.DataBindings.Add(new Binding("Text", dtgvrut.DataSource, "mã phiếu rút"));
            txtmastk.DataBindings.Add(new Binding("Text", dtgvrut.DataSource, "mã STK"));
            //txtngayrut.DataBindings.Add(new Binding("Text", dtgvrut.DataSource, "ngày rút"));
            txtsotienrut.DataBindings.Add(new Binding("Text", dtgvrut.DataSource, "số tiền rút"));
            


        }
        void loadctbd()
        {

            listruttien.DataSource = ruttienBUS.Instance.getphieurut();
        }
        public void ruttien(string mastk, string ngayrut, int sotienrut,string nguoirut)
        {
            ruttienBUS.Instance.ruttien(mastk, ngayrut, sotienrut, nguoirut);               
           
           
            loadctbd();
        }
        public void check(string mastk,int tien)
        {
            if (ruttienBUS.Instance.checkruttien(mastk))
            {
                ruttienBUS.Instance.rut(mastk, tien);
                ruttienBUS.Instance.checkactive(mastk);
                MessageBox.Show("Rut tien thanh cong");
            }
            else
                MessageBox.Show("So tien rut phai< so tien du trong tai khoan");

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;

            string d = date.Day.ToString();
            string m = date.Month.ToString();
            string y = date.Year.ToString();
            string mastk = txtmastk.Text;
            int sotienrut = Int32.Parse(txtsotienrut.Text);
            string maphieurut = txtmaphieu.Text;
            string ngayrut = y + "-" + m + "-" + d;
            string nguoirut = txtnguoirut.Text;
            if (sotienrut < 50000)
                MessageBox.Show("So tien rut toi thieu 50.000");
            else
            {
                ruttien(mastk, ngayrut, sotienrut, nguoirut);
                check(mastk, sotienrut);

            }


        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void timkiem(string info)
        {
            listruttien.DataSource = ruttienBUS.Instance.timkiem(info);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string info = textBox1.Text;
            timkiem(info);
        }

        private void txtsotienrut_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Khong duoc nhap ki tu");
            }
        }
    }
}
