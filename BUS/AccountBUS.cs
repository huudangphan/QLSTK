using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAO;
using DTO;
using System.Data;
using DTO;


namespace BUS
{
    public class AccountBUS
    {
        private static AccountBUS instance;

        public static AccountBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new AccountBUS();
                return instance;
            }
        }
        private AccountBUS() { }
        public DataTable getaccount()
        {
            return AccountDAO.Instance.Xem();
            
        }
        public bool login(string name,string pass)
        {
            return AccountDAO.Instance.login(name,pass);
        }
        public Account GetAccountByUserName(string name)
        {
            return AccountDAO.Instance.GetAccountByUserName(name);
        }
        //public List<Account> getlist()
        //{
        //    return AccountDAO.Instance.getlistaccount();
        //}
    }
}
