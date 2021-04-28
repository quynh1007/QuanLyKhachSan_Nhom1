using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_NHOM1.Models
{
    class Bill
    {
        public int id { set; get; }
        public int idCustomer { set; get; }
        public DateTime DateCheckIn { set; get; }

        public DateTime DateCheckOut { set; get; }
        public int idRoom { set; get; }

        public int Status { set; get; }


        public Bill() { }
        public Bill(DataRow dataRow)
        {
            this.id = Int32.Parse(dataRow["id"].ToString());
            this.idCustomer = Int32.Parse(dataRow["idCustomer"].ToString());
            this.DateCheckIn = DateTime.Parse(dataRow["DateCheckIn"].ToString());
            this.DateCheckOut = DateTime.Parse(dataRow["DateCheckOut"].ToString());
            this.idRoom = Int32.Parse(dataRow["idRoom"].ToString());
            this.Status = Int32.Parse(dataRow["Status"].ToString());
           
            
           
        }
    }
}
