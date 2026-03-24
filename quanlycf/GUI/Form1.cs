using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace quanlycf
{
    public partial class Form1 : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Form1()
        {
            InitializeComponent();
            MoManHinhChinh();
        }

        private void ribbonControl1_Click(object sender, EventArgs e)
        {

        }

        private void ribbonControl1_Click_1(object sender, EventArgs e)
        {

        }
        private void MoManHinhChinh()
        {
            // Xóa các tab rỗng mặc định (như xtraTabPage1, 2)
            tabHienThi.TabPages.Clear();

            // Lôi cái màn hình chính từ thư mục GUI ra
            GUI.manhinhchinh uc = new GUI.manhinhchinh();
            uc.Dock = DockStyle.Fill; // Bung to lấp đầy màn hình

            // Tạo một cái Tab mới để chứa nó
            DevExpress.XtraTab.XtraTabPage tabMoi = new DevExpress.XtraTab.XtraTabPage();
            tabMoi.Text = "Màn hình chính";

            // Nhét vào Tab, rồi nhét Tab vào Form
            tabMoi.Controls.Add(uc);
            tabHienThi.TabPages.Add(tabMoi);

            // Hiển thị tab vừa tạo lên trên cùng
            tabHienThi.SelectedTabPage = tabMoi;
        }
        private void bbtnTacVU_Click(object sender, EventArgs e) {
            MoManHinhChinh();
        }
        // Add this method to your Form1 class if it does not already exist:
        private void barButtonItem2_ItemClick_1(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            // TODO: Add your handler logic here
        }
    }
}
