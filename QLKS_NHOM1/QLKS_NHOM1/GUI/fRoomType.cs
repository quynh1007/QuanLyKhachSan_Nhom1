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
    public partial class fRoomType : Form
    {
        BindingSource ListRoomType = new BindingSource();
        public fRoomType()
        {
            InitializeComponent();
            LoadFirstTime();
            EditDataGridView();
            BindingDataToFrom();
        }
        private void EditDataGridView()
        {
            dgvRoomType.Columns["RoomTypeId"].HeaderText = "Mã loại phòng";
            dgvRoomType.Columns["NameType"].HeaderText = "Tên loại phòng";
            dgvRoomType.Columns["Price"].HeaderText = "Giá";

        }
        private void BindingDataToFrom()
        {
            txtRoomTypeId.DataBindings.Add(new Binding("Text", dgvRoomType.DataSource, "RoomTypeId", true, DataSourceUpdateMode.Never));
            txtNameType.DataBindings.Add(new Binding("Text", dgvRoomType.DataSource, "NameType", true, DataSourceUpdateMode.Never));
            txtPrice.DataBindings.Add(new Binding("Text", dgvRoomType.DataSource, "Price", true, DataSourceUpdateMode.Never));

        }



        private void LoadFirstTime()
        {
            dgvRoomType.DataSource = ListRoomType;
            LoadListReaders();
        }


        private void LoadListReaders()
        {
            ListRoomType.DataSource = RoomTypeDAO.Instance.GetAll();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {

            string NameType = txtNameType.Text;
            int Price;
            Int32.TryParse(txtPrice.Text, out Price);

            try
            {
                if (NameType == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    return;
                }
                RoomTypeDAO.Instance.Insert(NameType, Price);
                MessageBox.Show("Thêm thành công");
                LoadListReaders();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListReaders();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            int RoomTypeId = -1;
            Int32.TryParse(txtRoomTypeId.Text, out RoomTypeId);
            string NameType = txtNameType.Text;
            int Price;
            Int32.TryParse(txtPrice.Text, out Price);

            try
            {
                if (RoomTypeId == -1 || NameType == "")
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    return;
                }
                RoomTypeDAO.Instance.Update(RoomTypeId, NameType, Price);
                MessageBox.Show("Sửa thành công");
                LoadListReaders();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListReaders();
            }
        }


        private void btnXoa_Click(object sender, EventArgs e)
        {
            int RoomTypeId = -1;
            Int32.TryParse(txtRoomTypeId.Text, out RoomTypeId);
            try
            {
                RoomTypeDAO.Instance.Delete(RoomTypeId);
                MessageBox.Show("Xóa thành công");
                LoadListReaders();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListReaders();
            }
        }



        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string str = txtSearch.Text.Trim();
            if (str == "")
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm");
                return;
            }
            ListRoomType.DataSource = RoomTypeDAO.Instance.Search(str);
        }


    }
}
