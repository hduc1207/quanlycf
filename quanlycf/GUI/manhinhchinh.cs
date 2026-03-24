using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace quanlycf.GUI
{
    public partial class manhinhchinh : DevExpress.XtraEditors.XtraUserControl
    {
        public manhinhchinh()
        {
            InitializeComponent();
            TaoSoDoBan(20); // Tạo sơ đồ bàn với 20 bàn
        }
        private void TaoSoDoBan(int soLuongBan)
        {
            flpDanhSachBan.Controls.Clear();

            for (int i = 1; i <= soLuongBan; i++)
            {
                DevExpress.XtraEditors.SimpleButton btnBan = new DevExpress.XtraEditors.SimpleButton();
                btnBan.Text = "Bàn " + i;
                btnBan.Width = 80;
                btnBan.Height = 80;
                btnBan.Margin = new System.Windows.Forms.Padding(5);
                btnBan.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular);
                btnBan.Click += BtnBan_Click;
                flpDanhSachBan.Controls.Add(btnBan);
            }
        }
        private void BtnBan_Click(object sender, EventArgs e)
        {
            // Lấy ra đúng cái bàn mà thu ngân vừa click vào
            DevExpress.XtraEditors.SimpleButton banDuocChon = sender as DevExpress.XtraEditors.SimpleButton;

            // 1. Cập nhật dòng chữ ở góc dưới bên trái
            lbldangchon.Text = "Đang chọn: " + banDuocChon.Text;
        }

        private void manhinhchinh_Load(object sender, EventArgs e)
        {

        }

        private void labelControl3_Click(object sender, EventArgs e)
        {

        }

        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {

        }
    }
}
