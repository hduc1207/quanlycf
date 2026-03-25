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
    public partial class ucAccountInfo : DevExpress.XtraEditors.XtraUserControl
    {
        private AccountDTO loginAccount;
        public ucAccountInfo(AccountDTO acc)
        {
            InitializeComponent();
            this.loginAccount = acc;
            LoadAccountInfo();
        }

        // Hàm đổ dữ liệu lên giao diện
        void LoadAccountInfo()
        {
            txtTenDangNhap.Text = loginAccount.UserName;
            txtTenHienThi.Text = loginAccount.DisplayName;
        }
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            string userName = txtTenDangNhap.Text;
            string displayName = txtTenHienThi.Text;
            string password = txtMatKhau.Text;
            string newPassword = txtMatKhauMoi.Text;
            string reEnterPass = txtNhapLaiMK.Text;

            // Kiểm tra tính hợp lệ
            if (string.IsNullOrEmpty(password))
            {
                XtraMessageBox.Show("Vui lòng nhập mật khẩu hiện tại để xác nhận!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtMatKhau.Focus();
                return;
            }

            if (!string.IsNullOrEmpty(newPassword) && newPassword != reEnterPass)
            {
                XtraMessageBox.Show("Mật khẩu mới và Nhập lại mật khẩu không khớp!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtNhapLaiMK.Focus();
                return;
            }
            if (AccountBUS.Instance.UpdateAccount(userName, displayName, password, newPassword))
            {
                XtraMessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Cập nhật lại mật khẩu/tên mới vào biến tạm
                if (!string.IsNullOrEmpty(newPassword))
                {
                    // Xóa trắng các ô mật khẩu cho an toàn
                    txtMatKhau.Text = "";
                    txtMatKhauMoi.Text = "";
                    txtNhapLaiMK.Text = "";
                }
            }
            else
            {
                XtraMessageBox.Show("Mật khẩu hiện tại không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // SỰ KIỆN NÚT HỦY (Xóa trắng các ô nhập lại từ đầu)
        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadAccountInfo();
            txtMatKhau.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMK.Text = "";
        }
    }
}