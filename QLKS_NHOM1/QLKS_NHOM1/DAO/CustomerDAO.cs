using QLKS_NHOM1.DataAccessLayer;
using QLKS_NHOM1.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_NHOM1.DAO
{
    class CustomerDAO
    {
        private static CustomerDAO instance;

        internal static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set { instance = value; }
        }
        public List<Customer> GetAll()
        {
            List<Customer> list = new List<Customer>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Proc_GetAllCustomer");
            foreach (DataRow item in data.Rows)
            {
                Customer entry = new Customer(item);
                list.Add(entry);
            }
            return list;
        }
    }
}
