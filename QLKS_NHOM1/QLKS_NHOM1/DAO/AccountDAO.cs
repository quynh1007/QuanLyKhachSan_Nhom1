using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QLKS_NHOM1.DataAccessLayer;
using System.Data;
namespace QLKS_NHOM1.DAO
{
    class AccountDAO
    {
        private static AccountDAO instance;

        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }

        private AccountDAO() { }

        public bool Login(string userName, string pass)
        {
            string query = "Login @username , @pass";

            DataTable result = DataProvider.Instance.ExecuteQuery(query, new object[] { userName, pass });

            return result.Rows.Count > 0;
        }
    }
}
