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
    class ServiceDAO
    {
        private static ServiceDAO instance;

        internal static ServiceDAO Instance
        {
            get { if (instance == null) instance = new ServiceDAO(); return instance; }
            private set { instance = value; }
        }
        public List<Service> GetAll()
        {
            List<Service> list = new List<Service>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Proc_GetAllService");
            foreach (DataRow item in data.Rows)
            {
                Service entry = new Service(item);
                list.Add(entry);
            }
            return list;
        }
        public bool Insert(Service service)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Proc_InsertService @nameService , @price ", new object[] { service.NameService, service.Price });
            return result > 0;
        }
        public bool Update(Service service)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Proc_UpdateService @serviceId , @nameService , @price ", new object[] { service.ServiceId, service.NameService, service.Price });
            return result > 0;
        }

        public bool Delete(int serviceId)
        {
            int result = DataProvider.Instance.ExecuteNonQuery("Proc_DeleteService @serviceId", new object[] { serviceId });

            return result > 0;
        }


        public List<Service> Search(string searchValue)
        {
            List<Service> list = new List<Service>();
            DataTable data = DataProvider.Instance.ExecuteQuery("Proc_SeacrchService @searchValue ", new object[] { searchValue });
            foreach (DataRow item in data.Rows)
            {
                Service entry = new Service(item);
                list.Add(entry);
            }
            return list;
        }
    }
}
