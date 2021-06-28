
namespace QLKS_NHOM1.GUI
{
    partial class fBill
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txt_BillId = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.date_Checkin = new System.Windows.Forms.DateTimePicker();
            this.date_Checkout = new System.Windows.Forms.DateTimePicker();
            this.cb_Room = new System.Windows.Forms.ComboBox();
            this.cb_Customer = new System.Windows.Forms.ComboBox();
            this.btn_Them = new System.Windows.Forms.Button();
            this.btn_TimKiem = new System.Windows.Forms.Button();
            this.btn_Sua = new System.Windows.Forms.Button();
            this.btn_Xoa = new System.Windows.Forms.Button();
            this.txt_Search = new System.Windows.Forms.TextBox();
            this.dgv_DanhSachBill = new System.Windows.Forms.DataGridView();
            this.txt_Status = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnxem = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachBill)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(45, 28);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "Mã hóa đơn";
            // 
            // txt_BillId
            // 
            this.txt_BillId.AutoSize = true;
            this.txt_BillId.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_BillId.Location = new System.Drawing.Point(152, 28);
            this.txt_BillId.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.txt_BillId.Name = "txt_BillId";
            this.txt_BillId.Size = new System.Drawing.Size(20, 16);
            this.txt_BillId.TabIndex = 1;
            this.txt_BillId.Text = "-1";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(45, 74);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 16);
            this.label3.TabIndex = 2;
            this.label3.Text = "Ngày nhận phòng";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(334, 28);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 3;
            this.label4.Text = "Mã khách hàng";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(334, 73);
            this.label5.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 16);
            this.label5.TabIndex = 4;
            this.label5.Text = "Mã phòng";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(45, 130);
            this.label6.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(96, 16);
            this.label6.TabIndex = 5;
            this.label6.Text = "Ngày trả phòng";
            // 
            // date_Checkin
            // 
            this.date_Checkin.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_Checkin.Location = new System.Drawing.Point(155, 72);
            this.date_Checkin.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.date_Checkin.Name = "date_Checkin";
            this.date_Checkin.Size = new System.Drawing.Size(151, 23);
            this.date_Checkin.TabIndex = 6;
            // 
            // date_Checkout
            // 
            this.date_Checkout.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_Checkout.Location = new System.Drawing.Point(155, 125);
            this.date_Checkout.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.date_Checkout.Name = "date_Checkout";
            this.date_Checkout.Size = new System.Drawing.Size(151, 23);
            this.date_Checkout.TabIndex = 7;
            // 
            // cb_Room
            // 
            this.cb_Room.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Room.FormattingEnabled = true;
            this.cb_Room.Location = new System.Drawing.Point(442, 71);
            this.cb_Room.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_Room.Name = "cb_Room";
            this.cb_Room.Size = new System.Drawing.Size(152, 24);
            this.cb_Room.TabIndex = 8;
            // 
            // cb_Customer
            // 
            this.cb_Customer.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cb_Customer.FormattingEnabled = true;
            this.cb_Customer.Location = new System.Drawing.Point(442, 25);
            this.cb_Customer.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.cb_Customer.Name = "cb_Customer";
            this.cb_Customer.Size = new System.Drawing.Size(152, 24);
            this.cb_Customer.TabIndex = 9;
            // 
            // btn_Them
            // 
            this.btn_Them.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Them.Location = new System.Drawing.Point(632, 25);
            this.btn_Them.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Them.Name = "btn_Them";
            this.btn_Them.Size = new System.Drawing.Size(64, 24);
            this.btn_Them.TabIndex = 10;
            this.btn_Them.Text = "Thêm";
            this.btn_Them.UseVisualStyleBackColor = true;
            this.btn_Them.Click += new System.EventHandler(this.btn_Them_Click_1);
            // 
            // btn_TimKiem
            // 
            this.btn_TimKiem.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_TimKiem.Location = new System.Drawing.Point(770, 121);
            this.btn_TimKiem.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_TimKiem.Name = "btn_TimKiem";
            this.btn_TimKiem.Size = new System.Drawing.Size(70, 24);
            this.btn_TimKiem.TabIndex = 11;
            this.btn_TimKiem.Text = "Tìm kiếm";
            this.btn_TimKiem.UseVisualStyleBackColor = true;
            this.btn_TimKiem.Click += new System.EventHandler(this.btn_TimKiem_Click_1);
            // 
            // btn_Sua
            // 
            this.btn_Sua.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Sua.Location = new System.Drawing.Point(770, 25);
            this.btn_Sua.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Sua.Name = "btn_Sua";
            this.btn_Sua.Size = new System.Drawing.Size(70, 24);
            this.btn_Sua.TabIndex = 12;
            this.btn_Sua.Text = "Sửa";
            this.btn_Sua.UseVisualStyleBackColor = true;
            this.btn_Sua.Click += new System.EventHandler(this.btn_Sua_Click_1);
            // 
            // btn_Xoa
            // 
            this.btn_Xoa.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_Xoa.Location = new System.Drawing.Point(632, 69);
            this.btn_Xoa.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.btn_Xoa.Name = "btn_Xoa";
            this.btn_Xoa.Size = new System.Drawing.Size(64, 24);
            this.btn_Xoa.TabIndex = 13;
            this.btn_Xoa.Text = "Xóa";
            this.btn_Xoa.UseVisualStyleBackColor = true;
            this.btn_Xoa.Click += new System.EventHandler(this.btn_Xoa_Click_1);
            // 
            // txt_Search
            // 
            this.txt_Search.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Search.Location = new System.Drawing.Point(632, 125);
            this.txt_Search.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Search.Multiline = true;
            this.txt_Search.Name = "txt_Search";
            this.txt_Search.Size = new System.Drawing.Size(126, 24);
            this.txt_Search.TabIndex = 14;
            // 
            // dgv_DanhSachBill
            // 
            this.dgv_DanhSachBill.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_DanhSachBill.Location = new System.Drawing.Point(48, 188);
            this.dgv_DanhSachBill.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.dgv_DanhSachBill.Name = "dgv_DanhSachBill";
            this.dgv_DanhSachBill.RowHeadersWidth = 51;
            this.dgv_DanhSachBill.RowTemplate.Height = 24;
            this.dgv_DanhSachBill.Size = new System.Drawing.Size(793, 263);
            this.dgv_DanhSachBill.TabIndex = 15;
            // 
            // txt_Status
            // 
            this.txt_Status.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_Status.Location = new System.Drawing.Point(442, 121);
            this.txt_Status.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.txt_Status.Multiline = true;
            this.txt_Status.Name = "txt_Status";
            this.txt_Status.Size = new System.Drawing.Size(152, 24);
            this.txt_Status.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Times New Roman", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(334, 132);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Trạng thái";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 18;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnxem
            // 
            this.btnxem.Location = new System.Drawing.Point(380, 472);
            this.btnxem.Name = "btnxem";
            this.btnxem.Size = new System.Drawing.Size(86, 23);
            this.btnxem.TabIndex = 19;
            this.btnxem.Text = "Xem chi tiết";
            this.btnxem.UseVisualStyleBackColor = true;
            this.btnxem.Click += new System.EventHandler(this.btnxem_Click);
            // 
            // fBill
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(885, 507);
            this.Controls.Add(this.btnxem);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_Status);
            this.Controls.Add(this.dgv_DanhSachBill);
            this.Controls.Add(this.txt_Search);
            this.Controls.Add(this.btn_Xoa);
            this.Controls.Add(this.btn_Sua);
            this.Controls.Add(this.btn_TimKiem);
            this.Controls.Add(this.btn_Them);
            this.Controls.Add(this.cb_Customer);
            this.Controls.Add(this.cb_Room);
            this.Controls.Add(this.date_Checkout);
            this.Controls.Add(this.date_Checkin);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_BillId);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "fBill";
            this.Text = "fBill";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_DanhSachBill)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label txt_BillId;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker date_Checkin;
        private System.Windows.Forms.DateTimePicker date_Checkout;
        private System.Windows.Forms.ComboBox cb_Room;
        private System.Windows.Forms.ComboBox cb_Customer;
        private System.Windows.Forms.Button btn_Them;
        private System.Windows.Forms.Button btn_TimKiem;
        private System.Windows.Forms.Button btn_Sua;
        private System.Windows.Forms.Button btn_Xoa;
        private System.Windows.Forms.TextBox txt_Search;
        private System.Windows.Forms.DataGridView dgv_DanhSachBill;
        private System.Windows.Forms.TextBox txt_Status;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnxem;
    }
}