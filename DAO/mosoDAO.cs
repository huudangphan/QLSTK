using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;


namespace DAO
{
    public class mosoDAO
    {
        private static mosoDAO instance;

        public static mosoDAO Instance
        {
            get
            {
                if (instance == null)
                    instance = new mosoDAO();
                return instance;
            }
        }
        private mosoDAO() { }
        public DataTable getmoso()
        {
            return DataProvider.Instance.ExecuteQuery(" select s.mastk as[mã STK],s.sotiengui as [số tiền gửi] ,s.ngaymoso as [ngày mở sổ],s.makh as [mã khách hàng]," +
                "s.daoHan as [đáo hạn],k.tenkh as[tên khách hàng] ,l.kiHan as[loại tiết kiệm],k.cmnd as [CMND] ,k.diachi as [Địa chỉ],s.nguoitao,s.trangthai as [trạng thái] from SoTietKiem s, KhachHang k," +
                " LoaiTietKiem l where s.makh = k.maKH and s.maloai = l.maloai");
        }
        public bool moso(string mastk, string maloai, string ngaymoso, string makh, int sotiengui,string nguoimo)
        {
            string query = string.Format("insert SoTietKiem(mastk,maloai,ngaymoso,makh,daoHan,sotiengui,nguoitao,trangthai,count)" +
                " values(N'{0}', N'{1}', N'{2}', N'{3}',N'{2}', N'{4}', N'{5}',N'active',N'{2}') update SoTietKiem set daoHan = DATEADD(month, 3, N'{2}') where maloai = 002 ", mastk, maloai, ngaymoso, makh, sotiengui, nguoimo);


            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;

        }
        public bool moso0(string mastk, string maloai, string ngaymoso, string makh,  int sotiengui, string nguoimo)
        {
            string query = string.Format("insert SoTietKiem(mastk,maloai,ngaymoso,makh,daoHan,sotiengui,nguoitao,trangthai,count)" +
                " values(N'{0}', N'{1}', N'{2}', N'{3}', N'{2}', N'{4}',N'{5}',N'active',N'{2}') ", mastk, maloai, ngaymoso, makh, sotiengui, nguoimo);


            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;

        }
        public bool moso6(string mastk, string maloai, string ngaymoso, string makh,  int sotiengui, string nguoimo)
        {
            string query = string.Format("insert SoTietKiem(mastk,maloai,ngaymoso,makh,daoHan,sotiengui,nguoitao,trangthai,count)" +
                " values(N'{0}', N'{1}', N'{2}', N'{3}',N'{2}', N'{4}', N'{5}',N'active',N'{2}') update SoTietKiem set daoHan = DATEADD(month, 6, N'{2}') where maloai = 003 ", mastk, maloai, ngaymoso, makh, sotiengui, nguoimo);


            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;

        }
        public bool addkh(string makh, string tenkh, string diachi, string cmnd)
        {
            string query = string.Format("insert KhachHang(makh,tenkh, diachi, cmnd)" +
                " values(N'{0}', N'{1}', N'{2}',N'{3}')  ", makh, tenkh, diachi, cmnd);


            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool update()
        {
            string query = string.Format("update SoTietKiem set sotiengui = sotiengui * 1.15 where maloai = '001'" +
                "update SoTietKiem set sotiengui = sotiengui * 1.5 where maloai = '002' and (MONTH(count) < MONTH(daoHan) or YEAR(count)< YEAR(daohan))" +
                "update SoTietKiem set count = DATEADD(MONTH, 1, count) where maloai = '002'" +
                "update SoTietKiem set sotiengui = sotiengui * 1.55 where maloai = '003' and (MONTH(count) < MONTH(daoHan) or YEAR(count)< YEAR(daohan))" +
                "update SoTietKiem set count = DATEADD(MONTH, 1, count)where maloai = '003'" +
                "delete from SoTietKiem where trangthai='unactive'");
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}
