using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Account
    {
        private string name;
        private string pass;
        private int type;
        public Account(string name, int type, string pass = null)
        {
            this.name = name;
            this.type = type;
            this.pass = pass;
        }
        public Account(DataRow row)
        {
            this.name = row["name"].ToString();
            this.Type = (int)row["type"];
            this.pass = row["pass"].ToString();
        }

        public string Name { get => name; set => name = value; }
        public string Pass { get => pass; set => pass = value; }
        public int Type { get => type; set => type = value; }
    }
}
