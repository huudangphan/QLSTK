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
    public partial class fmoso : Form
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
        
        BindingSource listmoso = new BindingSource();
        public fmoso(Account acc)
        {
            InitializeComponent();
            LoginAccount = acc;
            loadData();
        }
        void changeAccount(Account acc)
        {
            txtmo.Text = loginAccount.Name;

        }
        public void loadData()
        {
            dtgvmoso.DataSource = listmoso;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {
            
            txtlai.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "Địa chỉ"));
            //txtloai.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "loại tiết kiệm"));
            txtmaso.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "mã STK"));
            txtmo.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "nguoitao"));
            txttrangthai.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "trạng thái"));
            txtten.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "tên khách hàng"));
            txttiengui.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "số tiền gửi"));
            txtcmnd.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "CMND"));
            txtmakh.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "mã khách hàng"));
           
            txttien.DataBindings.Add(new Binding("Text", dtgvmoso.DataSource, "số tiền gửi"));
        }
        void loadctbd()
        {
            listmoso.DataSource = mosoBUS.Instance.getmoso();
        }
        public void moso(string mastk, string maloai, string ngaymoso, string makh,  int sotiengui,string nguoimo)
        {
            if (mosoBUS.Instance.moso(mastk, maloai, ngaymoso, makh, sotiengui,nguoimo))
                MessageBox.Show("Dang ky so tiet kiem thanh cong");
            else
                MessageBox.Show("Dang ky so tiet kiem that bai");
            loadctbd();
        }
        public void moso0(string mastk, string maloai, string ngaymoso, string makh, int sotiengui, string nguoimo)
        {
            if (mosoBUS.Instance.moso0(mastk, maloai, ngaymoso, makh, sotiengui, nguoimo))
                MessageBox.Show("Dang ky so tiet kiem thanh cong");
            else
                MessageBox.Show("Dang ky so tiet kiem that bai");
            loadctbd();
        }
        public void moso6(string mastk, string maloai, string ngaymoso, string makh, int sotiengui, string nguoimo)
        {
            if (mosoBUS.Instance.moso6(mastk, maloai, ngaymoso, makh, sotiengui, nguoimo))
                MessageBox.Show("Dang ky so tiet kiem thanh cong");
            else
                MessageBox.Show("Dang ky so tiet kiem that bai");
            loadctbd();
        }
        public void addkh(string makh, string tenkh, string diachi, string cmnd)
        {
            if (mosoBUS.Instance.addkh(makh, tenkh, diachi, cmnd))
             
            loadctbd();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;
            
            string d = date.Day.ToString();
            string m = date.Month.ToString();
            string y = date.Year.ToString();

            //DateTime date2 = dateTimePicker2.Value;
            //string d2 = date2.Day.ToString();
            //string m2 = date2.Month.ToString();
            //string y2 = date2.Year.ToString();

            string mastk = txtmaso.Text;            
            string ngaymoso = y+"-"+m+"-"+d;            
            string makh = txtmakh.Text;
            //string daohan = y2 + "-" + m2 + "-" + d2;
            string tenkh = txtten.Text;
            int sotiengui = Int32.Parse(txttiengui.Text);
            string diachi = txtlai.Text;
            string cmnd = txtcmnd.Text;
            string maloai = "";
            string nguoimo = txtmo.Text;
            if (sotiengui < 1000000)
                MessageBox.Show("so tien gui > 1.000.000");
            else if (radioButton1.Checked == true)
            {
                maloai = "001";
                moso0(mastk, maloai, ngaymoso, makh, sotiengui, nguoimo);
                addkh(makh, tenkh, diachi, cmnd);


            }

            else if (radioButton2.Checked == true)
            {
                maloai = "002";

                moso(mastk, maloai, ngaymoso, makh, sotiengui, nguoimo);
                addkh(makh, tenkh, diachi, cmnd);

            }
                
           else if (radioButton3.Checked == true)
            {
                maloai = "003";
                moso6(mastk, maloai, ngaymoso, makh, sotiengui, nguoimo);
                addkh(makh, tenkh, diachi, cmnd);


            }






        }
        public void update()
        {
            if (mosoBUS.Instance.update())
                MessageBox.Show("Cap nhat thanh cong");
            else
                MessageBox.Show("Cap nhat that bai");
            loadctbd();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void fmoso_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update();
        }

        private void txttien_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
                MessageBox.Show("Khong duoc nhap ki tu");
            }
        }

        
    }
}
