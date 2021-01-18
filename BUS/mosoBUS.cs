using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DAO;

namespace BUS
{
     public class mosoBUS
    {
        private static mosoBUS instance;

        public static mosoBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new mosoBUS();
                return instance;
            }
        }
        private mosoBUS() { }
        public DataTable getmoso()
        {
            return mosoDAO.Instance.getmoso();
        }
        public bool moso(string mastk, string maloai, string ngaymoso, string makh, int sotiengui,string nguoimo)
        {
            return mosoDAO.Instance.moso(mastk, maloai, ngaymoso, makh,  sotiengui,nguoimo);
        }
        public bool addkh(string makh, string tenkh, string diachi, string cmnd)
        {
            return mosoDAO.Instance.addkh(makh, tenkh, diachi, cmnd);
        }
        public bool moso6(string mastk,string maloai,string ngaymoso,string makh,int sotiengui,string nguoimo)
        {
            return mosoDAO.Instance.moso6(mastk, maloai, ngaymoso, makh, sotiengui, nguoimo);
        }
        public bool moso0(string mastk, string maloai, string ngaymoso, string makh, int sotiengui, string nguoimo)
        {
            return mosoDAO.Instance.moso0(mastk, maloai, ngaymoso, makh, sotiengui, nguoimo);
        }
        public bool update()
        {
            return mosoDAO.Instance.update();
        }

    }
}
