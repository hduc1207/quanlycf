using DevExpress.XtraBars;

namespace quanlycf
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
            bbtnlogout = new DevExpress.XtraBars.BarButtonItem();
            bbtninfo = new DevExpress.XtraBars.BarButtonItem();
            bbtnTacVU = new DevExpress.XtraBars.BarButtonItem();
            ribbonPage2 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPageGroup3 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage3 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup4 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            tabHienThi = new DevExpress.XtraTab.XtraTabControl();
            xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem5 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem6 = new DevExpress.XtraBars.BarButtonItem();
            ribbonPageGroup5 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            barButtonItem7 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem8 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)ribbonControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)tabHienThi).BeginInit();
            tabHienThi.SuspendLayout();
            SuspendLayout();
            // 
            // ribbonControl1
            // 
            ribbonControl1.EmptyAreaImageOptions.ImagePadding = new System.Windows.Forms.Padding(35, 37, 35, 37);
            ribbonControl1.ExpandCollapseItem.Id = 0;
            ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { ribbonControl1.ExpandCollapseItem, bbtnlogout, bbtninfo, bbtnTacVU, barButtonItem1, barButtonItem2, barButtonItem3, barButtonItem4, barButtonItem5, barButtonItem6, barButtonItem7, barButtonItem8 });
            ribbonControl1.Location = new System.Drawing.Point(0, 0);
            ribbonControl1.Margin = new System.Windows.Forms.Padding(4);
            ribbonControl1.MaxItemId = 16;
            ribbonControl1.Name = "ribbonControl1";
            ribbonControl1.OptionsMenuMinWidth = 385;
            ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] { ribbonPage2, ribbonPage3, ribbonPage1 });
            ribbonControl1.Size = new System.Drawing.Size(884, 213);
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
            // 
            // bbtninfo
            // 
            bbtninfo.Caption = "Thông tin tài khoản";
            bbtninfo.Id = 2;
            bbtninfo.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbtninfo.ImageOptions.SvgImage");
            bbtninfo.Name = "bbtninfo";
            // 
            // bbtnTacVU
            // 
            bbtnTacVU.Caption = "Tác vụ";
            bbtnTacVU.Id = 3;
            bbtnTacVU.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("bbtnTacVU.ImageOptions.SvgImage");
            bbtnTacVU.Name = "bbtnTacVU";
            bbtnTacVU.ItemClick += bbtnTacVU_Click;
            // 
            // ribbonPage2
            // 
            ribbonPage2.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup2, ribbonPageGroup3 });
            ribbonPage2.Name = "ribbonPage2";
            ribbonPage2.Text = "Chức năng";
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
            // ribbonPage3
            // 
            ribbonPage3.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup4, ribbonPageGroup5 });
            ribbonPage3.Name = "ribbonPage3";
            ribbonPage3.Text = "Quản lý";
            // 
            // ribbonPageGroup4
            // 
            ribbonPageGroup4.ItemLinks.Add(barButtonItem1);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem2);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem3);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem4);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem5);
            ribbonPageGroup4.ItemLinks.Add(barButtonItem6);
            ribbonPageGroup4.Name = "ribbonPageGroup4";
            ribbonPageGroup4.Text = "Danh mục";
            // 
            // ribbonPage1
            // 
            ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] { ribbonPageGroup1 });
            ribbonPage1.Name = "ribbonPage1";
            ribbonPage1.Text = "Thông tin";
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
            tabHienThi.Size = new System.Drawing.Size(884, 280);
            tabHienThi.TabIndex = 1;
            tabHienThi.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] { xtraTabPage1, xtraTabPage2 });
            // 
            // xtraTabPage1
            // 
            xtraTabPage1.Name = "xtraTabPage1";
            xtraTabPage1.Size = new System.Drawing.Size(880, 252);
            xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            xtraTabPage2.Name = "xtraTabPage2";
            xtraTabPage2.Size = new System.Drawing.Size(880, 252);
            xtraTabPage2.Text = "xtraTabPage2";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "Thực đơn";
            barButtonItem1.Id = 4;
            barButtonItem1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem1.ImageOptions.SvgImage");
            barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "Danh mục";
            barButtonItem2.Id = 8;
            barButtonItem2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem2.ImageOptions.SvgImage");
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick_1;
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "Bàn";
            barButtonItem3.Id = 10;
            barButtonItem3.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem3.ImageOptions.SvgImage");
            barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            barButtonItem4.Caption = "Tài khoản";
            barButtonItem4.Id = 11;
            barButtonItem4.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem4.ImageOptions.SvgImage");
            barButtonItem4.Name = "barButtonItem4";
            // 
            // barButtonItem5
            // 
            barButtonItem5.Caption = "Kho";
            barButtonItem5.Id = 12;
            barButtonItem5.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem5.ImageOptions.SvgImage");
            barButtonItem5.Name = "barButtonItem5";
            // 
            // barButtonItem6
            // 
            barButtonItem6.Caption = "Công thức";
            barButtonItem6.Id = 13;
            barButtonItem6.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem6.ImageOptions.SvgImage");
            barButtonItem6.Name = "barButtonItem6";
            // 
            // ribbonPageGroup5
            // 
            ribbonPageGroup5.ItemLinks.Add(barButtonItem7);
            ribbonPageGroup5.ItemLinks.Add(barButtonItem8);
            ribbonPageGroup5.Name = "ribbonPageGroup5";
            ribbonPageGroup5.Text = "Thống kê";
            // 
            // barButtonItem7
            // 
            barButtonItem7.Caption = "Doanh thu";
            barButtonItem7.Id = 14;
            barButtonItem7.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem7.ImageOptions.SvgImage");
            barButtonItem7.Name = "barButtonItem7";
            // 
            // barButtonItem8
            // 
            barButtonItem8.Caption = "Thống kê";
            barButtonItem8.Id = 15;
            barButtonItem8.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("barButtonItem8.ImageOptions.SvgImage");
            barButtonItem8.Name = "barButtonItem8";
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(884, 493);
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
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.BarButtonItem bbtnlogout;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup3;
        private DevExpress.XtraBars.BarButtonItem bbtninfo;
        private DevExpress.XtraBars.BarButtonItem bbtnTacVU;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage3;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup4;
        private DevExpress.XtraTab.XtraTabControl tabHienThi;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private DevExpress.XtraBars.BarButtonItem barButtonItem5;
        private DevExpress.XtraBars.BarButtonItem barButtonItem6;
        private DevExpress.XtraBars.BarButtonItem barButtonItem7;
        private DevExpress.XtraBars.BarButtonItem barButtonItem8;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup5;
    }
}

