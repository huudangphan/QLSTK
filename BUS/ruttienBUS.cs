using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;
using System.Data;


namespace BUS
{
    public class ruttienBUS
    {
        private static ruttienBUS instance;

        public static ruttienBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new ruttienBUS();
                return instance;
            }
        }
        private ruttienBUS() { }
        public DataTable getphieurut()
        {
            return ruttienDAO.Instance.getruttien();
        }
        public bool ruttien( string mastk, string ngayrut, int sotienrut,string nguoirut)
        {
            return ruttienDAO.Instance.ruttien( mastk, ngayrut, sotienrut,nguoirut);
        }
        public bool checkactive(string mastk)
        {
            return ruttienDAO.Instance.checkactive(mastk);
        }
        public bool checkruttien(string mastk)
        {
            return ruttienDAO.Instance.checkruttien(mastk);
        }
        public bool rut(string mastk,int tien)
        {
            return ruttienDAO.Instance.rut(mastk, tien);
        }
        public DataTable timkiem(string info)
        {
            return ruttienDAO.Instance.timkiem(info);
        }
    }
}
