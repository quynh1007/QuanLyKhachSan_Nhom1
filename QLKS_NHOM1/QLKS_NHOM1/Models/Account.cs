using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_NHOM1.Models
{
    class Account
    {

        public string UserName { set; get; }
        public string DisplayName { set; get; }
        public string PassWord { set; get; }
        public int Type { set; get; }




        public Account() { }
        public Account(DataRow dataRow)
        {
            this.UserName = dataRow["UserName"].ToString();
            this.DisplayName = dataRow["DisplayName"].ToString();
            this.PassWord = dataRow["PassWord"].ToString();

            this.Type = Int32.Parse(dataRow["Type"].ToString());

        }
    }
}