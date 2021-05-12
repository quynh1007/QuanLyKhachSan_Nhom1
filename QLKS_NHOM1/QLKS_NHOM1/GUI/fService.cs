using QLKS_NHOM1.DAO;
using QLKS_NHOM1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLKS_NHOM1.GUI
{
    public partial class fService : Form
    {
        BindingSource ListService = new BindingSource();
        public fService()
        {
            InitializeComponent();
            LoadFirstTime();
            EditDataGridView();
            BindingDataToFrom();
        }
        private void EditDataGridView()
        {
            dgv_DanhSachDV.Columns["ServiceId"].HeaderText = "Mã dịch vụ";
            dgv_DanhSachDV.Columns["NameService"].HeaderText = "Tên dịch vụ";
            dgv_DanhSachDV.Columns["Price"].HeaderText = "Giá dịch vụ";
        }
        private void BindingDataToFrom()
        {
            txt_ServiceId.DataBindings.Add(new Binding("Text", dgv_DanhSachDV.DataSource, "ServiceId", true, DataSourceUpdateMode.Never));
            txt_NameService.DataBindings.Add(new Binding("Text", dgv_DanhSachDV.DataSource, "NameService", true, DataSourceUpdateMode.Never));
            txt_Price.DataBindings.Add(new Binding("Text", dgv_DanhSachDV.DataSource, "Price", true, DataSourceUpdateMode.Never));
          
        }

        private void LoadFirstTime()
        {
            dgv_DanhSachDV.DataSource = ListService;
            LoadListService();
        }


        private void LoadListService()
        {
            ListService.DataSource = ServiceDAO.Instance.GetAll();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            service.Price = Int32.Parse(txt_Price.Text);
            service.NameService = txt_NameService.Text;
            try
            {
                if (txt_NameService.Text == "" || txt_Price.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    return;
                }
                ServiceDAO.Instance.Insert(service);
                MessageBox.Show("Thêm thành công");
                LoadListService();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListService();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            int serviceId = int.Parse(txt_ServiceId.Text);
            try
            {
                ServiceDAO.Instance.Delete(serviceId);
                MessageBox.Show("Xóa thành công");
                LoadListService();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListService();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            Service service = new Service();
            service.Price = int.Parse(txt_Price.Text);
            service.NameService = txt_NameService.Text;
            service.ServiceId = int.Parse(txt_ServiceId.Text);
            try
            {
                if (txt_NameService.Text == "" || txt_Price.Text == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    return;
                }
                ServiceDAO.Instance.Update(service);
                MessageBox.Show("Sửa thành công");
                LoadListService();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListService();
            }
        }

        private void btn_TimKiem_Click(object sender, EventArgs e)
        {
            string str = txt_Search.Text.Trim();
            if (str == "")
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm");
                return;
            }
            ListService.DataSource = ServiceDAO.Instance.Search(str);
        }
    }
}
