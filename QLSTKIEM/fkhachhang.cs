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

namespace QLSTKIEM
{
    public partial class fkhachhang : Form
    {
        BindingSource listkhachhang = new BindingSource();
        public fkhachhang()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {


            dtgvkhachhang.DataSource = listkhachhang;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {


            txtmakh.DataBindings.Add(new Binding("Text", dtgvkhachhang.DataSource, "mã khách hàng"));
            txttenkh.DataBindings.Add(new Binding("Text", dtgvkhachhang.DataSource, "tên khách hàng"));
            txtdiachi.DataBindings.Add(new Binding("Text", dtgvkhachhang.DataSource, "địa chỉ"));
            txtcmnd.DataBindings.Add(new Binding("Text", dtgvkhachhang.DataSource, "cmnd"));



        }
        void loadctbd()
        {
            listkhachhang.DataSource = khachhangBUS.Instance.getkhachhang();
        }
        public void sua(string makh,string tenkh,string diachi,string cmnd)
        {
            if (khachhangBUS.Instance.sua(makh, tenkh, diachi, cmnd))
                MessageBox.Show("Sua thanh cong");
            else
                MessageBox.Show("Sua that bai");
            loadctbd();
        }
        public void xoa(string makh)
        {
            if (khachhangBUS.Instance.xoa(makh))
                MessageBox.Show("Xoa thanh cong");
            else
                MessageBox.Show("Xoa that bai");
            loadctbd();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            string makh = txtmakh.Text;
            xoa(makh);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string makh = txtmakh.Text;
            string tenkh = txttenkh.Text;
            string diachi = txtdiachi.Text;
            string cmnd = txtcmnd.Text;
            sua(makh, tenkh, diachi, cmnd);
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }
        
        public void timkiem(string info)
        {
            listkhachhang.DataSource = khachhangBUS.Instance.timkiem(info);

        }
        private void btntimkiiem_Click(object sender, EventArgs e)
        {
            string info = txttimkiem.Text;
            timkiem(info);

        }
    }
}
