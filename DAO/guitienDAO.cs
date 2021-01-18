using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class guitienDAO
    {
        private static guitienDAO instance;

        public static guitienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new guitienDAO();
                return instance;
            }
        }
        private guitienDAO() { }
        public DataTable getphieugui()
        {
            return DataProvider.Instance.ExecuteQuery("select maSTK as [Mã STK],maphieugui as [mã phiếu gửi],ngaygui as [ngày gửi]," +
                "sotiengui as [số tiền gửi],nguoigui as [người gửi] from phieugui");

        }
       
        public bool guitien(string mastk,  string ngaygui, int sotiengui,string nguoigui)
        {
            string query = string.Format(" insert phieugui(maSTK, ngaygui, sotiengui,nguoigui) " +
                "values(N'{0}', N'{1}', N'{2}', N'{3}') update SoTietKiem set sotiengui = s.sotiengui+ N'{2}' " +
                "from SotietKiem s where s.mastk=N'{0}'", mastk,  ngaygui, sotiengui,nguoigui);


            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable timkiem(string info)
        {

            return DataProvider.Instance.ExecuteQuery("select maSTK as [Mã STK],maphieugui as [mã phiếu gửi],ngaygui as [ngày gửi],sotiengui as [số tiền gửi],nguoigui as [người gửi] from phieugui where maSTK like N'%" + info + "%' or ngaygui like N'%" + info + "%'");
        }

    }
}
