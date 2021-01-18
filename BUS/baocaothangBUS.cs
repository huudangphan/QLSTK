using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;
using DAO;
using System.Data;


namespace BUS
{
    public class baocaothangBUS
    {
        private static baocaothangBUS instance;

        public static baocaothangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new baocaothangBUS();
                return instance;
            }
        }
        private baocaothangBUS() { }
        public bool baocaothang(string thang,string nam)
        {
            return baocaothangDAO.Instance.baocao(thang, nam);
        }
        public DataTable getbaocao()
        {
            return baocaothangDAO.Instance.getbcthang();
        }
    }
}
