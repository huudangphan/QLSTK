using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace DAO
{
    public class baocaothangDAO
    {
        
            private static baocaothangDAO instance;

            public static baocaothangDAO Instance
            {
                get
                {
                    if (instance == null)
                        instance = new baocaothangDAO();
                    return instance;
                }
            }
            private baocaothangDAO() { }
        public DataTable getbcthang()
        {
            return DataProvider.Instance.ExecuteQuery("select thang as[Tháng], tongthu as[Tổng thu],tongchi as[Tổng chi],chenhlech as [Chênh lệch] from bcthang");
        }
        public bool baocao(string thang,string nam)
        {
            string query = string.Format("update bcthang set tongthu = (select sum(pg.sotiengui) from phieugui pg" +
                " where MONTH(pg.ngaygui) = N'{0}' and YEAR(pg.ngaygui) = N'{1}'), tongchi = (select sum(pr.sotienrut)" +
                " from phieuruttien pr where year(pr.ngayrut) = N'{1}' and MONTH(pr.ngayrut)= N'{0}'), chenhlech = tongthu - tongchi,thang = N'{0}'", thang,nam);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        
    }
}
