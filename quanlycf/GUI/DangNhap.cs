using DevExpress.XtraEditors;
using System.Net;
using System.Net.Mail;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
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
        private bool SendEmailResetPassword(string emailNhan, string userName, string matKhauMoi)
        {
            try
            {
                string emailGui = "hduc3357@gmail.com";
                string matKhauApp = "tkoetcoirrxklqld";

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(emailGui, "Hệ thống Quán Cafe");
                mail.To.Add(emailNhan);
                mail.Subject = "THÔNG BÁO: KHÔI PHỤC MẬT KHẨU";
                mail.Body = $"Xin chào,\n\n" +
                            $"Hệ thống nhận được yêu cầu khôi phục mật khẩu cho tài khoản: {userName}.\n\n" +
                            $"Mật khẩu mới của bạn là: {matKhauMoi}\n\n" +
                            $"Vui lòng đăng nhập và đổi mật khẩu ngay lập tức.";

                SmtpClient smtp = new SmtpClient("smtp.gmail.com");
                smtp.EnableSsl = true;
                smtp.Port = 587;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential(emailGui, matKhauApp);

                smtp.Send(mail);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi gửi Email. Vui lòng kiểm tra lại mạng: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void hllblQuenMK_Click(object sender, EventArgs e)
        {
            string userName = DevExpress.XtraEditors.XtraInputBox.Show("Vui lòng nhập Tên đăng nhập của bạn:", "Khôi phục mật khẩu", "");
            if (string.IsNullOrEmpty(userName)) return;

            AccountDTO acc = AccountDAO.Instance.GetAccountByUserName(userName);
            if (acc == null)
            {
                MessageBox.Show("Tên đăng nhập không tồn tại trong hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string emailNhan = AccountDAO.Instance.GetEmailByUserName(userName);
            if (string.IsNullOrEmpty(emailNhan))
            {
                MessageBox.Show($"Tài khoản [{userName}] chưa được liên kết với địa chỉ Email nào.\nVui lòng liên hệ Quản lý để được cấp lại mật khẩu trực tiếp!", "Lỗi bảo mật", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
            string randomPassword = Guid.NewGuid().ToString().Substring(0, 6).ToUpper();
            Cursor.Current = Cursors.WaitCursor;
            bool isSent = SendEmailResetPassword(emailNhan, userName, randomPassword);
            if (isSent)
            {
                bool isUpdated = AccountDAO.Instance.ResetPassword(userName, randomPassword);

                if (isUpdated)
                {
                    string[] mailParts = emailNhan.Split('@');
                    string hiddenMail = mailParts[0].Substring(0, Math.Min(3, mailParts[0].Length)) + "***@" + mailParts[1];

                    MessageBox.Show($"Đã gửi mật khẩu khôi phục về Email bảo mật ({hiddenMail}).\nVui lòng kiểm tra hộp thư!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Lỗi hệ thống! Không thể lưu mật khẩu mới vào cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Gửi Email thất bại. Mật khẩu của bạn vẫn được giữ nguyên!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            Cursor.Current = Cursors.Default;
        }
    }
}