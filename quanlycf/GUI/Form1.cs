using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace QuanLyQuanCafe
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            MoManHinhChinh();
        }

        private void ribbonControl1_Click(object sender, EventArgs e) { }
        private void ribbonControl1_Click_1(object sender, EventArgs e) { }
        private void MoManHinhChinh()
        {
            tabHienThi.TabPages.Clear();
            GUI.manhinhchinh uc = new GUI.manhinhchinh();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Màn hình chính";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }
        private void bbtnTacVU_Click(object sender, EventArgs e)
        {
            MoManHinhChinh();
        }
        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e) { }
        private void barButtonItem_DanhMuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucDanhMuc uc = new GUI.ucDanhMuc();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Quản lý Danh Mục";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }
        private void barButtonItem_ThucDon_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucThucDon uc = new GUI.ucThucDon();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Quản lý Thực Đơn";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }
        private void barButtonItem_Ban_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.tableGUI uc = new GUI.tableGUI();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Quản lý Bàn";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }
        private void barButtonItem_TaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucTaiKhoan uc = new GUI.ucTaiKhoan();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Quản lý Tài Khoản";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }
        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
        private void barButtonItem_Kho_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucKho uc = new GUI.ucKho();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Quản lý Kho";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }
    }
}
