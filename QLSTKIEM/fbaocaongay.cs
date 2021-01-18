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
    public partial class fbaocaongay : Form
    {
        BindingSource listbaocao = new BindingSource();
        public fbaocaongay()
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


            
            
            txtchi.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Tổng chi"));
            txtthu.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Tổng thu"));
            txtchecnhlech.DataBindings.Add(new Binding("Text", dataGridView1.DataSource, "Chênh lệch"));



        }
        void loadctbd()
        {
                       
            listbaocao.DataSource = baocaongayBUS.Instance.getbaocao();
        }
        public void baocao(string ngay)
        {
            if (baocaongayBUS.Instance.baocao(ngay))
                
            loadctbd();

        }
        private void btnbaocao_Click(object sender, EventArgs e)
        {
            DateTime date = dateTimePicker1.Value;

            string d = date.Day.ToString();
            string m = date.Month.ToString();
            string y = date.Year.ToString();
            string ngay = y + "-" + m + "-" + d;
            baocao(ngay);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
