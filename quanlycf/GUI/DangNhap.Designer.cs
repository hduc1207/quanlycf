namespace QuanLyQuanCafe.GUI
{
    partial class DangNhap
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
            txtTaiKhoan = new DevExpress.XtraEditors.TextEdit();
            txtMatKhau = new DevExpress.XtraEditors.TextEdit();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            btnDangNhap = new DevExpress.XtraEditors.SimpleButton();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            ((System.ComponentModel.ISupportInitialize)txtTaiKhoan.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)txtMatKhau.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            SuspendLayout();
            // 
            // txtTaiKhoan
            // 
            txtTaiKhoan.Location = new System.Drawing.Point(290, 124);
            txtTaiKhoan.Name = "txtTaiKhoan";
            txtTaiKhoan.Size = new System.Drawing.Size(156, 23);
            txtTaiKhoan.TabIndex = 0;
            // 
            // txtMatKhau
            // 
            txtMatKhau.Location = new System.Drawing.Point(290, 164);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Properties.UseSystemPasswordChar = true;
            txtMatKhau.Size = new System.Drawing.Size(156, 23);
            txtMatKhau.TabIndex = 1;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            labelControl1.Appearance.Options.UseBackColor = true;
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(218, 127);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(66, 16);
            labelControl1.TabIndex = 2;
            labelControl1.Text = "Tài khoản:";
            // 
            // labelControl2
            // 
            labelControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold);
            labelControl2.Appearance.Options.UseBackColor = true;
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(218, 167);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(65, 16);
            labelControl2.TabIndex = 3;
            labelControl2.Text = "Mật khẩu:";
            // 
            // btnDangNhap
            // 
            btnDangNhap.Location = new System.Drawing.Point(423, 219);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new System.Drawing.Size(112, 32);
            btnDangNhap.TabIndex = 5;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(labelControl1);
            panelControl1.Controls.Add(txtMatKhau);
            panelControl1.Controls.Add(labelControl2);
            panelControl1.Controls.Add(txtTaiKhoan);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            panelControl1.Location = new System.Drawing.Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(664, 361);
            panelControl1.TabIndex = 6;
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(664, 361);
            Controls.Add(btnDangNhap);
            Controls.Add(panelControl1);
            Name = "DangNhap";
            Text = "XtraForm1";
            ((System.ComponentModel.ISupportInitialize)txtTaiKhoan.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)txtMatKhau.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtTaiKhoan;
        private DevExpress.XtraEditors.TextEdit txtMatKhau;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.SimpleButton btnDangNhap;
        private DevExpress.XtraEditors.PanelControl panelControl1;
    }
}