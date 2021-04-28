using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_NHOM1.Models
{
    class Room
    {
        public int id { set; get; }
        public string NameRoom { set; get; }
     
        public int Status { set; get; }
       
        public int idRoomType { set; get; }
      
        public Room() { }
        public Room(DataRow dataRow)
        {
            this.id = Int32.Parse(dataRow["id"].ToString());
            this.NameRoom = dataRow["NameRoom"].ToString();
            this.Status = Int32.Parse(dataRow["Status"].ToString());
            this.idRoomType = Int32.Parse(dataRow["idRoomType"].ToString());
        }
    }
}
