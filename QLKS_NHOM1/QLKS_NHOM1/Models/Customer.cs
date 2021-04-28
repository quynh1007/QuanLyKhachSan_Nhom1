using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_NHOM1.Models
{
    class Customer
    {
        public int id { set; get; }
        public string NameCustomer { set; get; }
        public DateTime DateTimeCustomer { set; get; }
        public string GenderCustomer { set; get; }
        public string AddressCustomer { set; get; }
        public string idCardCustomer { set; get; }
        public string PhoneNumber { set; get; }
       

        public Customer() { }
        public Customer(DataRow dataRow)
        {
            this.id = Int32.Parse(dataRow["id"].ToString());
            this.NameCustomer = dataRow["NameCustomer"].ToString();
            this.DateTimeCustomer = DateTime.Parse(dataRow["DateTimeCustomer"].ToString());
            this.GenderCustomer = dataRow["GenderCustomer"].ToString();
            this.AddressCustomer = dataRow["AddressCustomer"].ToString();
            this.idCardCustomer = dataRow["idCardCustomer"].ToString();
            this.PhoneNumber = dataRow["PhoneNumber"].ToString();

        }
    }
}
