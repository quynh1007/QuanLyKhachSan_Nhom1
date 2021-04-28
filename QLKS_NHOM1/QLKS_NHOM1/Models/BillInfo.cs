using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_NHOM1.Models
{
    class BillInfo
    {
        public int id { set; get; }
        public int idBill { set; get; }
        public int idService { set; get; }
        
        public int intCount { set; get; }

        public DateTime DateService { set; get; }
     

        public BillInfo() { }
        public BillInfo(DataRow dataRow)
        {
            this.id = Int32.Parse(dataRow["id"].ToString());
            this.idBill = Int32.Parse(dataRow["idBill"].ToString());
            this.idService = Int32.Parse(dataRow["idService"].ToString());
            this.intCount = Int32.Parse(dataRow["intCount"].ToString());
            this.DateService = DateTime.Parse(dataRow["DateService"].ToString());

        }
    }
}
