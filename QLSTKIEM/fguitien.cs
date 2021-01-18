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
    public partial class fguitien : Form
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

        BindingSource listguitien = new BindingSource();
        public fguitien(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            loadData();

            //List<Account> list = AccountBUS.Instance.getlist();
            //comboBox1.DataSource = list; 

        }
        void changeAccount(Account acc)
        {
            
            txtnguoirut.Text= loginAccount.Name;

        }
        public void loadData()
        {

            dtgvphieugui.DataSource = listguitien;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {

            txtmastk.DataBindings.Add(new Binding("Text", dtgvphieugui.DataSource, "Mã STK"));
            txtmaphieugui.DataBindings.Add(new Binding("Text", dtgvphieugui.DataSource, "mã phiếu gửi"));
            txtsotiengui.DataBindings.Add(new Binding("Text", dtgvphieugui.DataSource, "số tiền gửi"));
            txtnguoirut.DataBindings.Add(new Binding("Text", dtgvphieugui.DataSource, "người gửi"));
            //txtngaygui.DataBindings.Add(new Binding("Text", dtgvphieugui.DataSource, "ngày gửi"));


        }
        void loadctbd()
        {
            listguitien.DataSource = guitienBUS.Instance.getguitien();
        }
        public void guitien(string mastk, string ngaygui, int sotiengui,string nguoigui)
        {
            if (guitienBUS.Instance.guitien(mastk,  ngaygui, sotiengui,nguoigui))
                MessageBox.Show("Gui tien thanh cong");
            else
                MessageBox.Show("Gui tien that bai");
            loadctbd();
        }
        private void btnguitien_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;

            string d = date.Day.ToString();
            string m = date.Month.ToString();
            string y = date.Year.ToString();

            string mastk = txtmastk.Text;
            string maphieugui = txtmaphieugui.Text;
            string ngaygui = y + "-" + m + "-" + d;
            int sotiengui = Int32.Parse(txtsotiengui.Text);
            string nguoigui = txtnguoirut.Text;
            if (sotiengui < 100000)
                MessageBox.Show("so tien gui them >100.000");
            else
                guitien(mastk,  ngaygui, sotiengui, nguoigui);
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        public void timkiem(string info)
        {
            
            listguitien.DataSource = guitienBUS.Instance.timkiem(info);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            string info = textBox1.Text;
            timkiem(info);
        }

        private void txtsotiengui_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Khong duoc nhap ki tu");
            }
        }
    }
}
