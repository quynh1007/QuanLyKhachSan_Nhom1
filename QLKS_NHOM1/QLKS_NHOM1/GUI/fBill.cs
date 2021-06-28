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
    public partial class fBill : Form
    {
        BindingSource ListBill = new BindingSource();
        public fBill()
        {
            InitializeComponent();
            AddCombobox();
            LoadFirstTime();
            EditDataGridView();
            BindingDataToFrom();
        }
        private void EditDataGridView()
        {
            dgv_DanhSachBill.Columns["BillId"].HeaderText = "Mã hóa đơn";
            dgv_DanhSachBill.Columns["CustomerId"].HeaderText = "Mã khách hàng";
            dgv_DanhSachBill.Columns["DateCheckIn"].HeaderText = "Ngày nhận phòng";
            dgv_DanhSachBill.Columns["DateCheckout"].HeaderText = "Ngày trả phòng";
            dgv_DanhSachBill.Columns["RoomId"].HeaderText = "Mã phòng";
            dgv_DanhSachBill.Columns["Status"].HeaderText = "Trạng thái phòng";
        }
        private void BindingDataToFrom()
        {
            txt_BillId.DataBindings.Add(new Binding("Text", dgv_DanhSachBill.DataSource, "BillId", true, DataSourceUpdateMode.Never));
            cb_Customer.DataBindings.Add(new Binding("Text", dgv_DanhSachBill.DataSource, "CustomerId", true, DataSourceUpdateMode.Never));
            date_Checkin.DataBindings.Add(new Binding("Text", dgv_DanhSachBill.DataSource, "DateCheckIn", true, DataSourceUpdateMode.Never));
            date_Checkout.DataBindings.Add(new Binding("Text", dgv_DanhSachBill.DataSource, "DateCheckout", true, DataSourceUpdateMode.Never));
            cb_Room.DataBindings.Add(new Binding("Text", dgv_DanhSachBill.DataSource, "RoomId", true, DataSourceUpdateMode.Never));
            txt_Status.DataBindings.Add(new Binding("Text", dgv_DanhSachBill.DataSource, "Status", true, DataSourceUpdateMode.Never));

        }
        private void AddComboboxCustomer()
        {
            // lấy dữ liệu 
            var customers = CustomerDAO.Instance.GetAll();

            // Đẩy dữ liệu vào combobox
            foreach (var item in customers)
            {
                cb_Customer.Items.Add(item.CustomerId.ToString());
            }
        }
        private void AddComboboxRoom()
        {
            // lấy dữ liệu 
            var rooms = RoomDAO.Instance.GetAll();

            // Đẩy dữ liệu vào combobox
            foreach (var item in rooms)
            {
                cb_Room.Items.Add(item.RoomId.ToString());
            }
        }


        // Thêm dữ liệu vào combobox
        public void AddCombobox()
        {
            AddComboboxCustomer();
            AddComboboxRoom();
        }

        private void LoadFirstTime()
        {
            dgv_DanhSachBill.DataSource = ListBill;
            LoadListBill();
        }


        private void LoadListBill()
        {
            ListBill.DataSource = BillDAO.Instance.GetAll();
        }

        private void btn_Xoa_Click_1(object sender, EventArgs e)
        {
            int billId = int.Parse(txt_BillId.Text);
            try
            {
                BillDAO.Instance.Delete(billId);
                MessageBox.Show("Xóa thành công");
                LoadListBill();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListBill();
            }
        }

        private void btn_Them_Click_1(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.CustomerId = int.Parse(cb_Customer.SelectedItem.ToString());
            bill.DateCheckIn = DateTime.Parse(date_Checkin.Value.ToString());
            bill.DateCheckIn = DateTime.Parse(date_Checkout.Value.ToString());
            bill.RoomId = int.Parse(cb_Room.SelectedItem.ToString());
            bill.Status = int.Parse(txt_Status.Text);
            try
            {
                if (cb_Customer.SelectedItem.ToString().Trim() == ""
                    || cb_Room.SelectedItem.ToString().Trim() == ""
                    || txt_Status.Text == ""
                    )
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    return;
                }
                BillDAO.Instance.Insert(bill);
                MessageBox.Show("Thêm thành công");
                LoadListBill();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListBill();
            }
        }

        private void btn_Sua_Click_1(object sender, EventArgs e)
        {
            Bill bill = new Bill();
            bill.CustomerId = int.Parse(cb_Customer.SelectedItem.ToString());
            bill.DateCheckIn = date_Checkin.Value;
            bill.DateCheckOut = date_Checkout.Value;
            bill.RoomId = int.Parse(cb_Room.SelectedItem.ToString());
            bill.Status = int.Parse(txt_Status.Text);
            try
            {
                if (cb_Customer.SelectedItem.ToString().Trim() == ""
                    || cb_Room.SelectedItem.ToString().Trim() == ""
                    || txt_Status.Text == ""
                    )
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    return;
                }
                BillDAO.Instance.Update(bill);
                MessageBox.Show("Sửa thành công");
                LoadListBill();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListBill();
            }
        }

        private void btn_TimKiem_Click_1(object sender, EventArgs e)
        {
            string str = txt_Search.Text.Trim();
            if (str == "")
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm");
                return;
            }
            ListBill.DataSource = BillDAO.Instance.Search(str);
        }

        private void btnxem_Click(object sender, EventArgs e)
        {
            fBillInfo frm = new fBillInfo();
            this.Hide();
            frm.ShowDialog();
            this.Show();
        }
    }
}
