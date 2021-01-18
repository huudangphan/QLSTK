using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;

namespace BUS
{
    public class baocaongayBUS
    {
        private static baocaongayBUS instance;

        public static baocaongayBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new baocaongayBUS();
                return instance;
            }
        }
        private baocaongayBUS() { }
        public bool baocao(string ngay)
        {
            return baocaongayDAO.Instance.baocao(ngay);
        }
        public DataTable getbaocao()
        {
            return baocaongayDAO.Instance.getbaocao();
        }
    }
}
