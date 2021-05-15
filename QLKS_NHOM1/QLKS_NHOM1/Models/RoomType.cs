using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLKS_NHOM1.Models
{
    class RoomType
    {
        public int TypeRoomId { set; get; }
        public string NameType { set; get; }
        public int Price { set; get; }

        public RoomType(DataRow dataRow)
        {
            this.TypeRoomId = Int32.Parse(dataRow["TypeRoomId"].ToString());
            this.NameType = dataRow["NameType"].ToString();
            this.Price = Int32.Parse(dataRow["Price"].ToString());


        }
    }
}