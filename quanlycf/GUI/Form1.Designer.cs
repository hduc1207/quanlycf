using DevExpress.XtraBars;

namespace QuanLyQuanCafe
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            bbtnlogout = new BarButtonItem();
            bbtninfo = new BarButtonItem();
            bbtnTacVU = new BarButtonItem();
            btnThucDon = new BarButtonItem();
            btnDanhMuc = new BarButtonItem();
            btnBan = new BarButtonItem();
            btnTaiKhoan = new BarButtonItem();
            btnKho = new BarButtonItem();
            btnCongThuc = new BarButtonItem();
            barButtonItem7 = new BarButtonItem();
            barButtonItem8 = new BarButtonItem();
            btnVoucher = new BarButtonItem();
            PageChucNang = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            pageQuanLy = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            pageThongTin = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            tabHienThi = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabHienThi).BeginInit();
            tabHienThi.SuspendLayout();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new BarItem[] { ribbonControl1.ExpandCollapseItem, bbtnlogout, bbtninfo, bbtnTacVU, btnThucDon, btnDanhMuc, btnBan, btnTaiKhoan, btnKho, btnCongThuc, barButtonItem7, barButtonItem8, btnVoucher });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            ribbonControl1.MaxItemId = 17;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 385;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { PageChucNang, pageQuanLy, pageThongTin });
            ribbonControl1.Size = new System.Drawing.Size(860, 213);
            ribbonControl1.ToolbarLocation = DevExpress.XtraBars.Ribbon.RibbonQuickAccessToolbarLocation.Below;
            ribbonControl1.Click += ribbonControl1_Click_1;
            // 
            // bbtnlogout
            // 
            bbtnlogout.Caption = "Đăng xuất";
            bbtnlogout.Id = 1;
            bbtnlogout.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbtnlogout.ImageOptions.SvgImage");
            bbtnlogout.Name = "bbtnlogout";
            bbtnlogout.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            bbtnlogout.ItemClick += bbtnlogout_ItemClick;
            // 
            // bbtninfo
            // 
            bbtninfo.Caption = "Thông tin tài khoản";
            bbtninfo.Id = 2;
            bbtninfo.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbtninfo.ImageOptions.SvgImage");
            bbtninfo.Name = "bbtninfo";
            bbtninfo.ItemClick += btnThongTinTaiKhoan_ItemClick;
            // 
            // bbtnTacVU
            // 
            bbtnTacVU.Caption = "Tác vụ";
            bbtnTacVU.Id = 3;
            bbtnTacVU.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbtnTacVU.ImageOptions.SvgImage");
            bbtnTacVU.Name = "bbtnTacVU";
            bbtnTacVU.ItemClick += bbtnTacVU_Click;
            // 
            // btnThucDon
            // 
            btnThucDon.Caption = "Thực đơn";
            btnThucDon.Id = 4;
            btnThucDon.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnThucDon.ImageOptions.SvgImage");
            btnThucDon.Name = "btnThucDon";
            btnThucDon.ItemClick += barButtonItem_ThucDon_ItemClick;
            // 
            // btnDanhMuc
            // 
            btnDanhMuc.Caption = "Danh mục";
            btnDanhMuc.Id = 8;
            btnDanhMuc.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnDanhMuc.ImageOptions.SvgImage");
            btnDanhMuc.Name = "btnDanhMuc";
            btnDanhMuc.ItemClick += barButtonItem_DanhMuc_ItemClick;
            // 
            // btnBan
            // 
            btnBan.Caption = "Bàn";
            btnBan.Id = 10;
            btnBan.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnBan.ImageOptions.SvgImage");
            btnBan.Name = "btnBan";
            btnBan.ItemClick += barButtonItem_Ban_ItemClick;
            // 
            // btnTaiKhoan
            // 
            btnTaiKhoan.Caption = "Tài khoản";
            btnTaiKhoan.Id = 11;
            btnTaiKhoan.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnTaiKhoan.ImageOptions.SvgImage");
            btnTaiKhoan.Name = "btnTaiKhoan";
            btnTaiKhoan.ItemClick += barButtonItem_TaiKhoan_ItemClick;
            // 
            // btnKho
            // 
            btnKho.Caption = "Kho";
            btnKho.Id = 12;
            btnKho.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnKho.ImageOptions.SvgImage");
            btnKho.Name = "btnKho";
            btnKho.ItemClick += barButtonItem_Kho_ItemClick;
            // 
            // btnCongThuc
            // 
            btnCongThuc.Caption = "Công thức";
            btnCongThuc.Id = 13;
            btnCongThuc.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnCongThuc.ImageOptions.SvgImage");
            btnCongThuc.Name = "btnCongThuc";
            btnCongThuc.ItemClick += btnCongThuc_ItemClick;
            // 
            // barButtonItem7
            // 
            barButtonItem7.Caption = "Doanh thu";
            barButtonItem7.Id = 14;
            barButtonItem7.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem7.ImageOptions.SvgImage");
            barButtonItem7.Name = "barButtonItem7";
            barButtonItem7.ItemClick += btnThuNhap_ItemClick;
            // 
            // barButtonItem8
            // 
            barButtonItem8.Caption = "Thống kê";
            barButtonItem8.Id = 15;
            barButtonItem8.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem8.ImageOptions.SvgImage");
            barButtonItem8.Name = "barButtonItem8";
            barButtonItem8.ItemClick += barButtonItem8_ItemClick;
            // 
            // btnVoucher
            // 
            btnVoucher.Caption = "Voucher";
            btnVoucher.Id = 16;
            btnVoucher.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("btnVoucher.ImageOptions.SvgImage");
            btnVoucher.Name = "btnVoucher";
            btnVoucher.ItemClick += btnVoucher_ItemClick;
            // 
            // PageChucNang
            // 
            PageChucNang.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup2, ribbonPageGroup3 });
            PageChucNang.Name = "PageChucNang";
            PageChucNang.Text = "Chức năng";
            // 
            // ribbonPageGroup2
            // 
            ribbonPageGroup2.ItemLinks.Add(bbtnTacVU);
            ribbonPageGroup2.Name = "ribbonPageGroup2";
            ribbonPageGroup2.Text = "Chức năng";
            // 
            // ribbonPageGroup3
            // 
            ribbonPageGroup3.ItemLinks.Add(bbtninfo);
            ribbonPageGroup3.ItemLinks.Add(bbtnlogout);
            ribbonPageGroup3.Name = "ribbonPageGroup3";
            ribbonPageGroup3.Text = "Hệ thống";
            // 
            // pageQuanLy
            // 
            pageQuanLy.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup4, ribbonPageGroup5 });
            pageQuanLy.Name = "pageQuanLy";
            pageQuanLy.Text = "Quản lý";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.ItemLinks.Add(btnThucDon);
            ribbonPageGroup4.ItemLinks.Add(btnDanhMuc);
            ribbonPageGroup4.ItemLinks.Add(btnBan);
            ribbonPageGroup4.ItemLinks.Add(btnTaiKhoan);
            ribbonPageGroup4.ItemLinks.Add(btnKho);
            ribbonPageGroup4.ItemLinks.Add(btnCongThuc);
            ribbonPageGroup4.ItemLinks.Add(btnVoucher);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "Danh mục";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(barButtonItem7);
            ribbonPageGroup5.ItemLinks.Add(barButtonItem8);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Thống kê";
            // 
            // pageThongTin
            // 
            pageThongTin.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            pageThongTin.Name = "pageThongTin";
            pageThongTin.Text = "Thông tin";
            // 
            // ribbonPageGroup1
            // 
            ribbonPageGroup1.Name = "ribbonPageGroup1";
            ribbonPageGroup1.Text = "ribbonPageGroup1";
            // 
            // tabHienThi
            // 
            tabHienThi.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeader;
            tabHienThi.Dock = System.Windows.Forms.DockStyle.Fill;
            tabHienThi.Location = new System.Drawing.Point(0, 213);
            tabHienThi.Name = "tabHienThi";
            tabHienThi.SelectedTabPage = xtraTabPage1;
            tabHienThi.Size = new System.Drawing.Size(860, 268);
            tabHienThi.TabIndex = 1;
            tabHienThi.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2 });
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new System.Drawing.Size(856, 240);
            xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new System.Drawing.Size(866, 242);
            xtraTabPage2.Text = "xtraTabPage2";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(860, 481);
            Controls.Add(tabHienThi);
            Controls.Add(ribbonControl1);
            Margin = new System.Windows.Forms.Padding(4);
            Name = "Form1";
            Ribbon = ribbonControl1;
            Text = "Form1";
            WindowState = System.Windows.Forms.FormWindowState.Maximized;
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)tabHienThi).EndInit();
            tabHienThi.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageThongTin;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbtnlogout;
        private DevExpress.XtraBars.Ribbon.RibbonPage PageChucNang;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbtninfo;
        private DevExpress.XtraBars.BarButtonItem bbtnTacVU;
        private DevExpress.XtraBars.Ribbon.RibbonPage pageQuanLy;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraTab.XtraTabControl tabHienThi;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraBars.BarButtonItem btnThucDon;
        private DevExpress.XtraBars.BarButtonItem btnDanhMuc;
        private DevExpress.XtraBars.BarButtonItem btnBan;
        private DevExpress.XtraBars.BarButtonItem btnTaiKhoan;
        private DevExpress.XtraBars.BarButtonItem btnKho;
        private DevExpress.XtraBars.BarButtonItem btnCongThuc;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
        private BarButtonItem btnVoucher;
    }
}

