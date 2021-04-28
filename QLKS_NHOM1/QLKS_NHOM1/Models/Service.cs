using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_NHOM1.Models
{
    class Service
    {
        public int id { set; get; }
        public string NameService { set; get; }
        public int Price { set; get; }
       

        public Service() { }
        public Service(DataRow dataRow)
        {
            this.id = Int32.Parse(dataRow["id"].ToString());
            this.NameService = dataRow["NameService"].ToString();
            this.Price = Int32.Parse(dataRow["Price"].ToString());
           
        }
    }
}
