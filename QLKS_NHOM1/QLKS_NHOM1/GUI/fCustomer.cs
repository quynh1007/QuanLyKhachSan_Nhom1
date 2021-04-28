using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QLKS_NHOM1.DAO;

namespace QLKS_NHOM1.GUI
{
    public partial class fCustomer : Form
    {
        BindingSource CustomerList = new BindingSource();
        public fCustomer()
        {
            InitializeComponent();
            LoadData();
            BindingDataToForm();
        }

        private void BindingDataToForm()
        {
            txtHoTen.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "NameCustomer", true, DataSourceUpdateMode.Never));
            dtNgayDat.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "DateTimeCustomer", true, DataSourceUpdateMode.Never));
            cbGioiTinh.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "GenderCustomer", true, DataSourceUpdateMode.Never));
            txtDiaChi.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "AddressCustomer", true, DataSourceUpdateMode.Never));
            txtCCCD.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "IdCardCustomer", true, DataSourceUpdateMode.Never));
            txtSDT.DataBindings.Add(new Binding("Text", dgvCustomer.DataSource, "PhoneNumber", true, DataSourceUpdateMode.Never));
        }

        private void LoadData()
        {
            dgvCustomer.DataSource = CustomerList;
            LoadListCustomer();
            EditDataGridViewHeader();
        }

        private void EditDataGridViewHeader()
        {
            dgvCustomer.Columns["CustomerId"].HeaderText = "Mã Khách Hàng";
            dgvCustomer.Columns["NameCustomer"].HeaderText = "Họ Tên";
            dgvCustomer.Columns["DateTimeCustomer"].HeaderText = "Ngày Đặt";
            dgvCustomer.Columns["GenderCustomer"].HeaderText = "Giới Tính";
            dgvCustomer.Columns["AddressCustomer"].HeaderText = "Địa Chỉ";
            dgvCustomer.Columns["IdCardCustomer"].HeaderText = "CCCD";
            dgvCustomer.Columns["PhoneNumber"].HeaderText = "Số Điện Thoại";
        }

        private void LoadListCustomer()
        {
            CustomerList.DataSource = CustomerDAO.Instance.GetAll();
        }

        private void btnLamTrong_Click(object sender, EventArgs e)
        {
            txtHoTen.Text = "";
            dtNgayDat.Value = DateTime.Now;
            cbGioiTinh.Text = "";
            txtDiaChi.Text = "";
            txtCCCD.Text = "";
            txtSDT.Text = "";
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadListCustomer();
        }
    }
}
