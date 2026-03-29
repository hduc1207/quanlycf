using DevExpress.XtraEditors;
using System;
using System.Windows.Forms;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DAO;

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

        void LoadAccountInfo()
        {
            txtTenDangNhap.Text = loginAccount.UserName;
            txtTenHienThi.Text = loginAccount.DisplayName;
            EmployeeDAO empDAO = new EmployeeDAO();
            EmployeeDTO emp = empDAO.GetEmployeeByUserName(loginAccount.UserName);

            if (emp != null)
            {
                txtHovaTen.Text = emp.FullName;
                txtSDT.Text = emp.PhoneNumber;
                txtEmail.Text = emp.Email;

                if (emp.BirthDate.HasValue)
                    txtNgaySinh.Text = emp.BirthDate.Value.ToString("dd/MM/yyyy");
                else
                    txtNgaySinh.Text = "";
            }
            txtMatKhau.Text = "";
            txtMatKhauMoi.Text = "";
            txtNhapLaiMK.Text = "";

            txtTenDangNhap.ReadOnly = true;
        }

        // NÚT CẬP NHẬT THÔNG TIN
        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            // 1. Lấy dữ liệu từ giao diện
            string userName = txtTenDangNhap.Text;
            string displayName = txtTenHienThi.Text;
            string password = txtMatKhau.Text;
            string newPassword = txtMatKhauMoi.Text;
            string reEnterPass = txtNhapLaiMK.Text;

            string fullName = txtHovaTen.Text;
            string phone = txtSDT.Text;
            string email = txtEmail.Text;

            // 2. Kiểm tra mật khẩu
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

            // 3. Xử lý ngày sinh an toàn
            DateTime? birthDate = null;
            if (!string.IsNullOrEmpty(txtNgaySinh.Text))
            {
                DateTime parsedDate;
                if (DateTime.TryParseExact(txtNgaySinh.Text, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out parsedDate))
                    birthDate = parsedDate;
                else
                {
                    XtraMessageBox.Show("Ngày sinh không hợp lệ! Nhập đúng định dạng dd/MM/yyyy (VD: 15/08/2000)", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
            }

            // 4. GỌI HÀM UPDATE TỪ AccountBUS
            if (AccountBUS.Instance.UpdateAccount(userName, displayName, password, newPassword, fullName, phone, email, birthDate))
            {
                XtraMessageBox.Show("Cập nhật thông tin thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                loginAccount.DisplayName = displayName;

                txtMatKhau.Text = "";
                txtMatKhauMoi.Text = "";
                txtNhapLaiMK.Text = "";
            }
            else
            {
                XtraMessageBox.Show("Cập nhật thất bại! Vui lòng kiểm tra lại mật khẩu hiện tại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            LoadAccountInfo();
        }
    }
}