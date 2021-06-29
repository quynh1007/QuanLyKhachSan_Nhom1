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
    class BillDAO
    {
        private static BillDAO instance;

        internal static BillDAO Instance
        {
            get { if (instance == null) instance = new BillDAO(); return instance; }
            private set { instance = value; }
        }
        public List<Bill> GetAll()
        {
            List<Bill> list = new List<Bill>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Proc_GetAllBill");
            foreach (DataRow item in data.Rows)
            {
                Bill entry = new Bill(item);
                list.Add(entry);
            }
            return list;
        }
        public bool Insert(Bill bill)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Proc_InsertBill @customerId , @dateCheckIn , @dateCheckOut , @roomId , @status ", new object[] { bill.CustomerId,bill.DateCheckIn,bill.DateCheckOut,bill.RoomId,bill.Status });
            return result > 0;
        }
        public bool Update(Bill bill)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Proc_UpdateBill @billId , @customerId , @dateCheckIn , @dateCheckOut , @roomId , @status ", new object[] {bill.BillId, bill.CustomerId, bill.DateCheckIn, bill.DateCheckOut, bill.RoomId, bill.Status }); 
            return result > 0;
        }

        public bool Delete(int billId)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Proc_DeleteBill @billId", new object[] { billId });
            return result > 0;
        }
        public List<Bill> Search(string searchValue)
        {
            List<Bill> list = new List<Bill>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Proc_SearchBill @searchValue ", new object[] { searchValue });
            foreach (DataRow item in data.Rows)
            {
                Bill entry = new Bill(item);
                list.Add(entry);
            }
            return list;
        }
    }
}
