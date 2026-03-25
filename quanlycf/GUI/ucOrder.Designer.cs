namespace QuanLyQuanCafe.GUI
{
    partial class ucOrder
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucOrder));
            alertControl1 = new DevExpress.XtraBars.Alerter.AlertControl(components);
            splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            panelControl2 = new DevExpress.XtraEditors.PanelControl();
            btnThanhToan = new DevExpress.XtraEditors.SimpleButton();
            txtTongTien = new DevExpress.XtraEditors.TextEdit();
            labelControl3 = new DevExpress.XtraEditors.LabelControl();
            spnGiamGia = new DevExpress.XtraEditors.SpinEdit();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            lbldangchon = new DevExpress.XtraEditors.LabelControl();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            cbbSIze = new DevExpress.XtraEditors.ComboBoxEdit();
            ccbdanhmuc = new DevExpress.XtraEditors.ComboBoxEdit();
            btnChuyenBan = new DevExpress.XtraEditors.SimpleButton();
            cbbdouong = new DevExpress.XtraEditors.ComboBoxEdit();
            cbbBan = new DevExpress.XtraEditors.ComboBoxEdit();
            btnThem = new DevExpress.XtraEditors.SimpleButton();
            flpDanhSachBan = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).BeginInit();
            splitContainerControl1.Panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).BeginInit();
            splitContainerControl1.Panel2.SuspendLayout();
            splitContainerControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).BeginInit();
            panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtTongTien.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)spnGiamGia.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)cbbSIze.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)ccbdanhmuc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbdouong.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)cbbBan.Properties).BeginInit();
            SuspendLayout();
            // 
            // splitContainerControl1
            // 
            splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            splitContainerControl1.Location = new System.Drawing.Point(0, 0);
            splitContainerControl1.Name = "splitContainerControl1";
            // 
            // splitContainerControl1.Panel1
            // 
            splitContainerControl1.Panel1.Controls.Add(gridControl1);
            splitContainerControl1.Panel1.Controls.Add(panelControl2);
            splitContainerControl1.Panel1.Controls.Add(panelControl1);
            splitContainerControl1.Panel1.Text = "Panel1";
            // 
            // splitContainerControl1.Panel2
            // 
            splitContainerControl1.Panel2.Controls.Add(flpDanhSachBan);
            splitContainerControl1.Panel2.Text = "Panel2";
            splitContainerControl1.Size = new System.Drawing.Size(1200, 700);
            splitContainerControl1.SplitterPosition = 595;
            splitContainerControl1.TabIndex = 2;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 80);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(595, 540);
            gridControl1.TabIndex = 9;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl2
            // 
            panelControl2.Controls.Add(btnThanhToan);
            panelControl2.Controls.Add(txtTongTien);
            panelControl2.Controls.Add(labelControl3);
            panelControl2.Controls.Add(spnGiamGia);
            panelControl2.Controls.Add(labelControl2);
            panelControl2.Controls.Add(lbldangchon);
            panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelControl2.Location = new System.Drawing.Point(0, 620);
            panelControl2.Name = "panelControl2";
            panelControl2.Size = new System.Drawing.Size(595, 80);
            panelControl2.TabIndex = 8;
            // 
            // btnThanhToan
            // 
            btnThanhToan.Location = new System.Drawing.Point(433, 23);
            btnThanhToan.Name = "btnThanhToan";
            btnThanhToan.Size = new System.Drawing.Size(118, 36);
            btnThanhToan.TabIndex = 5;
            btnThanhToan.Text = "Thanh toán";
            btnThanhToan.Click += btnThanhToan_Click;
            // 
            // txtTongTien
            // 
            txtTongTien.Location = new System.Drawing.Point(334, 30);
            txtTongTien.Name = "txtTongTien";
            txtTongTien.Size = new System.Drawing.Size(84, 23);
            txtTongTien.TabIndex = 4;
            // 
            // labelControl3
            // 
            labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl3.Appearance.Options.UseFont = true;
            labelControl3.Location = new System.Drawing.Point(164, 31);
            labelControl3.Name = "labelControl3";
            labelControl3.Size = new System.Drawing.Size(61, 18);
            labelControl3.TabIndex = 3;
            labelControl3.Text = "Giảm giá:";
            labelControl3.Click += labelControl3_Click;
            // 
            // spnGiamGia
            // 
            spnGiamGia.EditValue = new decimal(new int[] { 0, 0, 0, 0 });
            spnGiamGia.Location = new System.Drawing.Point(231, 29);
            spnGiamGia.Name = "spnGiamGia";
            spnGiamGia.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            spnGiamGia.Size = new System.Drawing.Size(89, 24);
            spnGiamGia.TabIndex = 2;
            spnGiamGia.EditValueChanged += spinEdit1_EditValueChanged;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            labelControl2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("labelControl2.ImageOptions.SvgImage");
            labelControl2.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            labelControl2.Location = new System.Drawing.Point(39, 44);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(83, 24);
            labelControl2.TabIndex = 1;
            labelControl2.Text = "Có người";
            // 
            // lbldangchon
            // 
            lbldangchon.Appearance.Font = new System.Drawing.Font("Tahoma", 9F);
            lbldangchon.Appearance.Options.UseFont = true;
            lbldangchon.ImageAlignToText = DevExpress.XtraEditors.ImageAlignToText.LeftCenter;
            lbldangchon.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("lbldangchon.ImageOptions.SvgImage");
            lbldangchon.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            lbldangchon.Location = new System.Drawing.Point(39, 6);
            lbldangchon.Name = "lbldangchon";
            lbldangchon.Size = new System.Drawing.Size(96, 24);
            lbldangchon.TabIndex = 0;
            lbldangchon.Text = "Đang chọn";
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(cbbSIze);
            panelControl1.Controls.Add(ccbdanhmuc);
            panelControl1.Controls.Add(btnChuyenBan);
            panelControl1.Controls.Add(cbbdouong);
            panelControl1.Controls.Add(cbbBan);
            panelControl1.Controls.Add(btnThem);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            panelControl1.Location = new System.Drawing.Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(595, 80);
            panelControl1.TabIndex = 7;
            // 
            // cbbSIze
            // 
            cbbSIze.EditValue = "--Size--";
            cbbSIze.Location = new System.Drawing.Point(334, 29);
            cbbSIze.Name = "cbbSIze";
            cbbSIze.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbSIze.Size = new System.Drawing.Size(77, 23);
            cbbSIze.TabIndex = 3;
            // 
            // ccbdanhmuc
            // 
            ccbdanhmuc.EditValue = "--Loại--";
            ccbdanhmuc.Location = new System.Drawing.Point(39, 13);
            ccbdanhmuc.Name = "ccbdanhmuc";
            ccbdanhmuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            ccbdanhmuc.Size = new System.Drawing.Size(101, 23);
            ccbdanhmuc.TabIndex = 0;
            ccbdanhmuc.SelectedIndexChanged += ccbdanhmuc_SelectedIndexChanged;
            // 
            // btnChuyenBan
            // 
            btnChuyenBan.Location = new System.Drawing.Point(445, 13);
            btnChuyenBan.Name = "btnChuyenBan";
            btnChuyenBan.Size = new System.Drawing.Size(94, 23);
            btnChuyenBan.TabIndex = 5;
            btnChuyenBan.Text = "Chuyển";
            btnChuyenBan.Click += btnChuyenBan_Click;
            // 
            // cbbdouong
            // 
            cbbdouong.EditValue = "--Đồ uống--";
            cbbdouong.Location = new System.Drawing.Point(39, 42);
            cbbdouong.Name = "cbbdouong";
            cbbdouong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbdouong.Size = new System.Drawing.Size(101, 23);
            cbbdouong.TabIndex = 1;
            // 
            // cbbBan
            // 
            cbbBan.EditValue = "--Bàn--";
            cbbBan.Location = new System.Drawing.Point(445, 42);
            cbbBan.Name = "cbbBan";
            cbbBan.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            cbbBan.Size = new System.Drawing.Size(94, 23);
            cbbBan.TabIndex = 4;
            // 
            // btnThem
            // 
            btnThem.Location = new System.Drawing.Point(190, 25);
            btnThem.Name = "btnThem";
            btnThem.Size = new System.Drawing.Size(93, 27);
            btnThem.TabIndex = 2;
            btnThem.Text = "Thêm";
            btnThem.Click += btnThem_Click;
            // 
            // flpDanhSachBan
            // 
            flpDanhSachBan.Dock = System.Windows.Forms.DockStyle.Fill;
            flpDanhSachBan.Location = new System.Drawing.Point(0, 0);
            flpDanhSachBan.Name = "flpDanhSachBan";
            flpDanhSachBan.Padding = new System.Windows.Forms.Padding(15);
            flpDanhSachBan.Size = new System.Drawing.Size(598, 700);
            flpDanhSachBan.TabIndex = 0;
            // 
            // manhinhchinh
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(splitContainerControl1);
            Name = "manhinhchinh";
            Size = new System.Drawing.Size(1200, 700);
            Load += manhinhchinh_Load;
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel1).EndInit();
            splitContainerControl1.Panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1.Panel2).EndInit();
            splitContainerControl1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerControl1).EndInit();
            splitContainerControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).EndInit();
            panelControl2.ResumeLayout(false);
            panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtTongTien.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)spnGiamGia.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)cbbSIze.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)ccbdanhmuc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbdouong.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)cbbBan.Properties).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraBars.Alerter.AlertControl alertControl1;
        private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
        private DevExpress.XtraEditors.SimpleButton btnThem;
        private DevExpress.XtraEditors.ComboBoxEdit cbbdouong;
        private DevExpress.XtraEditors.ComboBoxEdit ccbdanhmuc;
        private DevExpress.XtraEditors.SimpleButton btnChuyenBan;
        private DevExpress.XtraEditors.ComboBoxEdit cbbBan;
        private DevExpress.XtraEditors.ComboBoxEdit cbbSIze;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl lbldangchon;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SpinEdit spnGiamGia;
        private DevExpress.XtraEditors.SimpleButton btnThanhToan;
        private DevExpress.XtraEditors.TextEdit txtTongTien;
        private System.Windows.Forms.FlowLayoutPanel flpDanhSachBan;
    }
}
