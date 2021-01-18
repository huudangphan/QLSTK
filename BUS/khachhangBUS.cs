using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAO;

namespace BUS
{
    public class khachhangBUS
    {
        private static khachhangBUS instance;

        public static khachhangBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new khachhangBUS();
                return instance;
            }
        }
        private khachhangBUS() { }
        public DataTable getkhachhang()
        {
            return khachhangDAO.Instance.getkhachhang();
        }
        public bool sua(string makh,string tenkh,string diachi,string cmnd)
        {
            return khachhangDAO.Instance.sua(makh, tenkh, diachi, cmnd);
        }
        public bool xoa(string makh)
        {
            return khachhangDAO.Instance.xoa(makh);
        }
        public DataTable timkiem(string info)
        {
            return khachhangDAO.Instance.timkiem(info);
        }
    }
   
}
