using QLKS_NHOM1.DAO;
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
    public partial class fBillInfo : Form
    {
        BindingSource listBillInfo = new BindingSource();
        public fBillInfo()
        {
            InitializeComponent();
            LoadData();
            BindingDataToForm();
        }

        private void BindingDataToForm()
        {
            txtMaHD.DataBindings.Add(new Binding("Text", dgvBillInfo.DataSource, "BillId", true, DataSourceUpdateMode.Never));
            txtTongTien.DataBindings.Add(new Binding("Text", dgvBillInfo.DataSource, "IntCount", true, DataSourceUpdateMode.Never));
            cbbMaDV.DataBindings.Add(new Binding("Text", dgvBillInfo.DataSource, "ServiceId", true, DataSourceUpdateMode.Never));
            dtNgayPV.DataBindings.Add(new Binding("Text", dgvBillInfo.DataSource, "DateService", true, DataSourceUpdateMode.Never));
        }

        private void LoadData()
        {
            dgvBillInfo.DataSource = listBillInfo;
            LoadBillInfo();
            EditDataGridViewHeader();
            LoadComboboxService();
        }

        private void LoadComboboxService()
        {
            cbbMaDV.DataSource = ServiceDAO.Instance.GetAll();
            cbbMaDV.DisplayMember = "ServiceId";
        }

        private void EditDataGridViewHeader()
        {
            dgvBillInfo.Columns["BillInfoId"].HeaderText = "Mã chi tiết hoá đơn";
            dgvBillInfo.Columns["BillId"].HeaderText = "Mã hoá đơn";
            dgvBillInfo.Columns["ServiceId"].HeaderText = "Mã dịch vụ";
            dgvBillInfo.Columns["IntCount"].HeaderText = "Tổng thanh toán";
            dgvBillInfo.Columns["DateService"].HeaderText = "Ngày phục vụ";
        }

        private void LoadBillInfo()
        {
            listBillInfo.DataSource = BillInfoDAO.Instance.GetAll();
        }


        private void btnEdit_Click(object sender, EventArgs e)
        {
            int row = dgvBillInfo.CurrentCell.RowIndex;
            int billInfoId;
            Int32.TryParse(dgvBillInfo.Rows[row].Cells[0].Value.ToString().Trim(), out billInfoId);

            int serviceId = Int32.Parse(cbbMaDV.Text);
            DateTime serviceDate = dtNgayPV.Value;

            try
            {
                BillInfoDAO.Instance.Update(billInfoId, serviceId, serviceDate);
                MessageBox.Show("Sửa thành công!");
                LoadBillInfo();


            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadBillInfo();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string search = txtTimKiem.Text.Trim();
            if (search.Equals(""))
            {
                MessageBox.Show("Mời bạn nhập thông tin tìm kiếm!");
                return;
            }
            else
            {
                listBillInfo.DataSource = BillInfoDAO.Instance.Search(search);
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
