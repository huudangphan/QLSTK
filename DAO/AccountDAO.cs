using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance {
            get
            {
                if (instance == null)
                    instance = new AccountDAO();
                return instance;
            }
        }
        private AccountDAO() { }
        public bool login(string name, string pass)
        {
            string query = "SELECT * FROM dbo.Account WHERE name = N'" + name + "' AND pass = N'" + pass + "' ";

            DataTable result = DataProvider.Instance.ExecuteQuery(query);

            return result.Rows.Count > 0;
        }
        //public List<Account> getlistaccount()
        //{
        //    List<Account> list = new List<Account>();
        //    string query = "select name from Account ";
        //    DataTable data = DataProvider.Instance.ExecuteQuery(query);

        //    foreach (DataRow item in data.Rows)
        //    {
                
        //        Account account = new Account(item);
        //        list.Add(account);
        //    }

        //    return list;
        //}

        public Account GetAccountByUserName(string name)
        {
            DataTable data = DataProvider.Instance.ExecuteQuery("Select * from Account where name = '" + name + "'");

            foreach (DataRow item in data.Rows)
            {
                return new Account(item);
            }

            return null;
        }
        public DataTable Xem()
        {
            return DataProvider.Instance.ExecuteQuery("select name as[Tên tài khoản],type as[Quyền tài khoản] from Account");



        }
    }
}
