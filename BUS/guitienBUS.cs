using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class guitienBUS
    {
        private static guitienBUS instance;

        public static guitienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new guitienBUS();
                return instance;
            }
        }
        private guitienBUS() { }
        public DataTable getguitien()
        {
            return guitienDAO.Instance.getphieugui();
        }
        public bool guitien(string mastk,string ngaygui,int sotiengui,string nguoigui)
        {
            return guitienDAO.Instance.guitien(mastk,  ngaygui, sotiengui,nguoigui);

        }
        public DataTable timkiem(string info)
        {
            return guitienDAO.Instance.timkiem(info);
        }
       
    }
}
