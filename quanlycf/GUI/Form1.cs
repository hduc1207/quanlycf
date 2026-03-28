using QuanLyQuanCafe.DTO;
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
        private AccountDTO loginAccount;
        public Form1(AccountDTO acc)
        {
            InitializeComponent();
            MoManHinhChinh();
            this.loginAccount = acc;
            PhanQuyen(this.loginAccount.Type);
        }
        public void PhanQuyen(int loaiTaiKhoan)
        {
            if (loaiTaiKhoan == 0)
            {
                pageQuanLy.Visible = false;
                pageThongTin.Visible = false;
            }
            else
            {
                pageQuanLy.Visible = true;
                pageThongTin.Visible = true;
            }
        }

        private void ribbonControl1_Click(object sender, EventArgs e) { }
        private void ribbonControl1_Click_1(object sender, EventArgs e) { }
        private void MoManHinhChinh()
        {
            tabHienThi.TabPages.Clear();
            GUI.ucOrder uc = new GUI.ucOrder();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Màn hình order";
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

        private void bbtnlogout_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnCongThuc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucCongThuc uc = new GUI.ucCongThuc();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Quản lý Công Thức";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }
        private void btnThuNhap_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucThuNhap uc = new GUI.ucThuNhap();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Thống kê thu nhập";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }

        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucThongKe uc = new GUI.ucThongKe();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Thống kê doanh thu";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }
        private void btnThongTinTaiKhoan_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucAccountInfo uc = new GUI.ucAccountInfo(loginAccount);
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Thông tin tài khoản";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
            tabHienThi.SelectedTabPage = tabMoi;
        }

        private void btnVoucher_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi.TabPages.Clear();
            GUI.ucVoucher uc = new GUI.ucVoucher();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Quản lý Voucher";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
        }

        private void btnThatThoat_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            tabHienThi .TabPages.Clear();
             GUI.ucWasteLog uc = new GUI.ucWasteLog();
            uc.Dock = DockStyle.Fill;
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Thất thoát";
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);
             tabHienThi.SelectedTabPage = tabMoi;
        }
    }
}
