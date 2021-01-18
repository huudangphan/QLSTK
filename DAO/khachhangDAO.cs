using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class khachhangDAO
    {
        private static khachhangDAO instance;

        public static khachhangDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new khachhangDAO();
                return instance;
            }
        }
        private khachhangDAO() { }
        public DataTable getkhachhang()
        {
            return DataProvider.Instance.ExecuteQuery("select makh as[mã khách hàng],tenkh as [tên khách hàng],diachi as [địa chỉ],cmnd from KhachHang");


        }
        public bool sua(string makh,string tenkh,string diachi,string cmnd)
        {
            string query = string.Format(" update KhachHang set tenkh = N'{0}', diachi = N'{1}', cmnd = N'{2}'where maKH = N'{3}' ",tenkh,diachi,cmnd,makh);


            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool xoa(string makh)
        {
            string query = string.Format("delete from  SoTietKiem where makh=N'{0}'delete from KhachHang where makh = N'{0}'", makh);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //public DataTable timkiem(string info)
        //{          
           
        //    return DataProvider.Instance.ExecuteQuery("select makh as[mã khách hàng],tenkh as [tên khách hàng],diachi as [địa chỉ],cmnd from KhachHang " +
        //        "where tenkh like N'%{0}%' or makh like N'%{0}%'", info);
        //    //int result = DataProvider.Instance.ExecuteNonQuery(query);
        //    //return result > 0;
        //}
        public DataTable timkiem(string info)
        {                     

            return DataProvider.Instance.ExecuteQuery("select makh as[mã khách hàng],tenkh as [tên khách hàng],diachi as [địa chỉ],cmnd from KhachHang where tenkh like N'%"+info+"%' or makh like N'%"+info+"%'");
        }
        
    }
}
