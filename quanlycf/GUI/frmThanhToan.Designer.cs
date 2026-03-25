namespace QuanLyQuanCafe.GUI
{
    partial class frmThanhToan
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
            components = new System.ComponentModel.Container();
            lblTongTIen = new DevExpress.XtraEditors.LabelControl();
            groupControl1 = new DevExpress.XtraEditors.GroupControl();
            rdoChuyenKhoan = new DevExpress.XtraEditors.CheckEdit();
            rdoTienMat = new DevExpress.XtraEditors.CheckEdit();
            picQR = new System.Windows.Forms.PictureBox();
            btnXacNhan = new DevExpress.XtraEditors.SimpleButton();
            btnHuy = new DevExpress.XtraEditors.SimpleButton();
            lblTrangThai = new DevExpress.XtraEditors.LabelControl();
            timerKiemTraTien = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)groupControl1).BeginInit();
            groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rdoChuyenKhoan.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rdoTienMat.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picQR).BeginInit();
            SuspendLayout();
            // 
            // lblTongTIen
            // 
            lblTongTIen.Appearance.Font = new System.Drawing.Font("Tahoma", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblTongTIen.Appearance.Options.UseFont = true;
            lblTongTIen.Appearance.Options.UseTextOptions = true;
            lblTongTIen.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblTongTIen.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTongTIen.Dock = System.Windows.Forms.DockStyle.Top;
            lblTongTIen.Location = new System.Drawing.Point(0, 0);
            lblTongTIen.Name = "lblTongTIen";
            lblTongTIen.Size = new System.Drawing.Size(440, 34);
            lblTongTIen.TabIndex = 0;
            lblTongTIen.Text = "Cần thanh toán: 0 đ";
            // 
            // groupControl1
            // 
            groupControl1.Controls.Add(rdoChuyenKhoan);
            groupControl1.Controls.Add(rdoTienMat);
            groupControl1.Location = new System.Drawing.Point(0, 40);
            groupControl1.Name = "groupControl1";
            groupControl1.Size = new System.Drawing.Size(440, 78);
            groupControl1.TabIndex = 1;
            groupControl1.Text = "Phương thức thanh toán";
            // 
            // rdoChuyenKhoan
            // 
            rdoChuyenKhoan.Location = new System.Drawing.Point(275, 44);
            rdoChuyenKhoan.Name = "rdoChuyenKhoan";
            rdoChuyenKhoan.Properties.Caption = "Chuyển khoản";
            rdoChuyenKhoan.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            rdoChuyenKhoan.Properties.RadioGroupIndex = 1;
            rdoChuyenKhoan.Size = new System.Drawing.Size(118, 20);
            rdoChuyenKhoan.TabIndex = 1;
            rdoChuyenKhoan.TabStop = false;
            // 
            // rdoTienMat
            // 
            rdoTienMat.EditValue = true;
            rdoTienMat.Location = new System.Drawing.Point(48, 44);
            rdoTienMat.Name = "rdoTienMat";
            rdoTienMat.Properties.Caption = "Tiền mặt";
            rdoTienMat.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            rdoTienMat.Properties.RadioGroupIndex = 1;
            rdoTienMat.Size = new System.Drawing.Size(118, 20);
            rdoTienMat.TabIndex = 0;
            // 
            // picQR
            // 
            picQR.Location = new System.Drawing.Point(95, 124);
            picQR.Name = "picQR";
            picQR.Size = new System.Drawing.Size(250, 250);
            picQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            picQR.TabIndex = 2;
            picQR.TabStop = false;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new System.Drawing.Point(69, 450);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new System.Drawing.Size(118, 36);
            btnXacNhan.TabIndex = 3;
            btnXacNhan.Text = "Xác nhận";
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnHuy
            // 
            btnHuy.Location = new System.Drawing.Point(254, 450);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new System.Drawing.Size(118, 36);
            btnHuy.TabIndex = 4;
            btnHuy.Text = "Hủy";
            btnHuy.Click += btnHuy_Click;
            // 
            // lblTrangThai
            // 
            lblTrangThai.Appearance.Font = new System.Drawing.Font("Tahoma", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, 0);
            lblTrangThai.Appearance.ForeColor = System.Drawing.Color.DarkOrange;
            lblTrangThai.Appearance.Options.UseFont = true;
            lblTrangThai.Appearance.Options.UseForeColor = true;
            lblTrangThai.Appearance.Options.UseTextOptions = true;
            lblTrangThai.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            lblTrangThai.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            lblTrangThai.Location = new System.Drawing.Point(110, 380);
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new System.Drawing.Size(220, 21);
            lblTrangThai.TabIndex = 5;
            lblTrangThai.Text = "⏳ Đang chờ khách quét mã...";
            lblTrangThai.Visible = false;
            // 
            // timerKiemTraTien
            // 
            timerKiemTraTien.Interval = 3000;
            // 
            // frmThanhToan
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(440, 511);
            Controls.Add(lblTrangThai);
            Controls.Add(btnHuy);
            Controls.Add(btnXacNhan);
            Controls.Add(picQR);
            Controls.Add(groupControl1);
            Controls.Add(lblTongTIen);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frmThanhToan";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            Text = "frmThanhToan";
            ((System.ComponentModel.ISupportInitialize)groupControl1).EndInit();
            groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)rdoChuyenKhoan.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)rdoTienMat.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)picQR).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.LabelControl lblTongTIen;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.CheckEdit rdoChuyenKhoan;
        private DevExpress.XtraEditors.CheckEdit rdoTienMat;
        private System.Windows.Forms.PictureBox picQR;
        private DevExpress.XtraEditors.SimpleButton btnXacNhan;
        private DevExpress.XtraEditors.SimpleButton btnHuy;
        private DevExpress.XtraEditors.LabelControl lblTrangThai;
        private System.Windows.Forms.Timer timerKiemTraTien;
    }
}