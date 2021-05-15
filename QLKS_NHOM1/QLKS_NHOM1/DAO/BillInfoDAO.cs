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
    class BillInfoDAO
    {
        private static BillInfoDAO instance;

        internal static BillInfoDAO Instance
        {
            get { if (instance == null) instance = new BillInfoDAO(); return instance; }
            private set { instance = value; }
        }
        public List<BillInfo> GetAll()
        {
            List<BillInfo> list = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Proc_GetAllBillInfo");
            foreach (DataRow item in data.Rows)
            {
                BillInfo entry = new BillInfo(item);
                list.Add(entry);
            }
            return list;
        }
        public bool Update(int billInfoId, int serviceId, DateTime dateService)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Proc_UpdateBillInfo @billInfoId , @serviceId , @dateService", new object[] { billInfoId, serviceId, dateService });
            return result > 0;
        }
        public List<BillInfo> Search(string searchValue)
        {
            List<BillInfo> list = new List<BillInfo>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Proc_SearchBillInfo @searchValue", new object[] { searchValue });
            foreach (DataRow item in data.Rows)
            {
                BillInfo entry = new BillInfo(item);
                list.Add(entry);
            }
            return list;
        }
    }
}
