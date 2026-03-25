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
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.BUS;

namespace QuanLyQuanCafe.GUI
{
    public partial class DangNhap : DevExpress.XtraEditors.XtraForm
    {
        public DangNhap()
        {
            InitializeComponent();
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string userName = txtTaiKhoan.Text;
            string passWord = txtMatKhau.Text;
            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                XtraMessageBox.Show("Vui lòng nhập đầy đủ tài khoản và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (Login(userName, passWord))
            {
                AccountDTO loginAccount = AccountBUS.Instance.GetAccountByUserName(userName);
                Form1 f = new Form1(loginAccount);

                this.Hide();
                f.ShowDialog();
                this.Show();
            }
            else
            {
                XtraMessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Hàm hỗ trợ gọi xuống tầng BUS
        bool Login(string userName, string passWord)
        {
            return AccountBUS.Instance.Login(userName, passWord);
        }
        private void XtraForm1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnDangNhap.PerformClick();
            }
        }
    }
}