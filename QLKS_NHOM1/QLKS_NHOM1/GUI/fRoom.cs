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
    public partial class fRoom : Form
    {
        BindingSource PhongList = new BindingSource();
        public fRoom()
        {
            InitializeComponent();
            LoadFirstTime();
            EditDataGridView();
            LoadCombobox();
            BindingDataToFrom();
        }
        private void EditDataGridView()
        {
            dgvRoom.Columns["RoomId"].HeaderText = "Mã phòng";
            dgvRoom.Columns["NameRoom"].HeaderText = "Tên phòng";
            dgvRoom.Columns["Status"].HeaderText = "Trạng thái";
            dgvRoom.Columns["RoomTypeId"].HeaderText = "Mã loại phòng";
          
        }
        private void BindingDataToFrom()
        {
            txtRoomId.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "RoomId", true, DataSourceUpdateMode.Never));
            txtNameRoom.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "NameRoom", true, DataSourceUpdateMode.Never));
            txtStatus.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "Status", true, DataSourceUpdateMode.Never));
            cbxRoomTypeId.DataBindings.Add(new Binding("Text", dgvRoom.DataSource, "RoomTypeId", true, DataSourceUpdateMode.Never));
        }
        private void LoadCombobox()
        {
            cbxRoomTypeId.DataSource = RoomTypeDAO.Instance.GetAll();
            cbxRoomTypeId.DisplayMember = "RoomTypeId";
        }


        private void LoadFirstTime()
        {
            dgvRoom.DataSource = PhongList;
            LoadListPhong();
        }


        private void LoadListPhong()
        {
            PhongList.DataSource = RoomDAO.Instance.GetAll();
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            string NameRoom = txtNameRoom.Text;
            int Status;
            Int32.TryParse(txtStatus.Text, out Status);
            int RoomTypeId;
            Int32.TryParse(cbxRoomTypeId.Text, out RoomTypeId);


            try
            {
                if (NameRoom == "" )
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    return;
                }
                RoomDAO.Instance.Insert(NameRoom, Status, RoomTypeId);
                MessageBox.Show("Thêm thành công");
                LoadListPhong();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListPhong();
            }
        }
        private void btnEdit_Click(object sender, EventArgs e)
        {
            int RoomId;
            Int32.TryParse(txtRoomId.Text, out RoomId);
            string NameRoom = txtNameRoom.Text;
            int Status;
            Int32.TryParse(txtStatus.Text, out Status);
            int RoomTypeId;
            Int32.TryParse(cbxRoomTypeId.Text, out RoomTypeId);

            try
            {
                if (NameRoom == "" )
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin");
                    return;
                }

                RoomDAO.Instance.Update(RoomId,NameRoom, Status, RoomTypeId);
                MessageBox.Show("Sửa thành công");
                LoadListPhong();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListPhong();
            }
        }


        private void btnDelete_Click(object sender, EventArgs e)
        {
            int RoomId = 0;
            Int32.TryParse(txtRoomId.Text.Trim(), out RoomId);
            try
            {
                RoomDAO.Instance.Delete(RoomId);
                MessageBox.Show("Xóa thành công");
                LoadListPhong();
            }
            catch (Exception err)
            {
                MessageBox.Show("Có lỗi xảy ra" + err.ToString());
                LoadListPhong();
            }
        }



        private void btnSearch_Click(object sender, EventArgs e)
        {
            string str = txtSearch.Text.Trim();
            if (str == "")
            {
                MessageBox.Show("Chưa nhập thông tin tìm kiếm");
                return;
            }
            PhongList.DataSource = RoomDAO.Instance.Search(str);
        }

        private void fRoom_Load(object sender, EventArgs e)
        {

        }
    }
}
