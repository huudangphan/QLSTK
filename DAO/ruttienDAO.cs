using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAO
{
    public class ruttienDAO
    {
        private static ruttienDAO instance;

        public static ruttienDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new ruttienDAO();
                return instance;
            }
        }
        private ruttienDAO() { }
        public DataTable getruttien()
        {
            return DataProvider.Instance.ExecuteQuery("select maphieurut as [mã phiếu rút],maSTK as [mã STK],ngayrut as [ngày rút]," +
                "sotienrut as[số tiền rút] from phieuruttien");

        }
        public bool ruttien( string mastk, string ngayrut, int sotienrut,string nguoirut)
        {
            string query = string.Format("insert phieuruttien(maSTK,ngayrut,sotienrut,nguoirut) " +
                "values(N'{0}',N'{1}',N'{2}',N'{3}')  ", mastk, ngayrut, sotienrut,nguoirut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool rut(string mastk,int sotienrut)
        {
            string query = string.Format(" update SoTietKiem set sotiengui = s.sotiengui- N'{1}'" +
                " from SotietKiem s where s.mastk=N'{0}' ", mastk, sotienrut);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        //public bool checkruttien(string mastk)
        //{
        //    string query = string.Format("select * from SoTietKiem s, phieuruttien pr where  s.mastk=N'{0}' and pr.sotienrut <= s.sotiengui",mastk);
        //    int result = DataProvider.Instance.ExecuteNonQuery(query);
        //    return result > 0;
        //}
        public bool checkactive(string mastk)
        {
            string query = string.Format("update SoTietKiem  set trangthai = 'unactive' from SoTietKiem s, phieuruttien pr where s.mastk = N'{0}' and s.sotiengui < 0", mastk);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool checkruttien(string mastk)
        {
            string query = "select * from SoTietKiem s, phieuruttien pr  where  s.mastk='"+ mastk +"' and pr.sotienrut <= s.sotiengui";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }
        public DataTable timkiem(string info)
        {

            return DataProvider.Instance.ExecuteQuery("select maphieurut as [mã phiếu rút],maSTK as [mã STK],ngayrut as [ngày rút],sotienrut as[số tiền rút] from phieuruttien where maSTK like N'%" + info + "%' or ngayrut like N'%" + info + "%'");
        }
    }
}
