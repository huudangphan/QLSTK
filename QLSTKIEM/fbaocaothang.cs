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
    public partial class fbaocaothang : Form
    {
        BindingSource listbaocao = new BindingSource();
        public fbaocaothang()
        {
            InitializeComponent();
            loadData();
        }
        public void loadData()
        {
                       
            dataGridView1.DataSource = listbaocao;
            addctdkBinding();
            loadctbd();
        }
        void addctdkBinding()
        {

                                  
            txttongthu.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Tổng thu"));
            txttongchi.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Tổng chi"));
            txtchenhlech.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Chênh lệch"));



        }
        void loadctbd()
        {


            listbaocao.DataSource = baocaothangBUS.Instance.getbaocao();
        }
        public void baocaothang(string thang,string nam)
        {
            baocaothangBUS.Instance.baocaothang(thang, nam);
            
            loadctbd();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;            
            string m = date.Month.ToString();
            string y = date.Year.ToString();
            string thang = m;
            string nam = y;
            baocaothang(thang, nam);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
