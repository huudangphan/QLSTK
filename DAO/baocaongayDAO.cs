using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAO
{
    public class baocaongayDAO
    {
        private static baocaongayDAO instance;

        public static baocaongayDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new baocaongayDAO();
                return instance;
            }
        }
        private baocaongayDAO() { }
        public bool baocao(string ngay)
        {
            string query = string.Format("update bcngay set  tongthu = (select sum(pg.sotiengui) from phieugui pg where pg.ngaygui = N'{0}'), " +
                "tongchi = (select sum(pr.sotienrut) from phieuruttien pr where pr.ngayrut = N'{0}'),chenhlech = tongthu - tongchi,ngay = N'{0}'",ngay);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public DataTable getbaocao()
        {
            return DataProvider.Instance.ExecuteQuery("select ngay as[Ngày], tongthu as[Tổng thu],tongchi as[Tổng chi],chenhlech as [Chênh lệch] from bcngay");
        }
    }
}
