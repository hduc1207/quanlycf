using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucTaiKhoan : DevExpress.XtraEditors.XtraUserControl
    {
        public ucTaiKhoan()
        {
            InitializeComponent();
            LoadAccountList();
        }
        void LoadAccountList()
        {
            List<AccountDTO> listAccount = AccountBUS.Instance.GetListAccount();
            gridControl1.DataSource = new BindingList<AccountDTO>(listAccount);
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadAccountList();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            AccountDTO selectedAccount = gridView1.GetFocusedRow() as AccountDTO;

            if (selectedAccount != null && !string.IsNullOrEmpty(selectedAccount.UserName))
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa tài khoản: {selectedAccount.UserName}?",
                                    "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    if (AccountBUS.Instance.DeleteAccount(selectedAccount.UserName))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadAccountList();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại do lỗi hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn một tài khoản trên bảng để xóa!", "Thông báo");
            }
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            AccountDTO acc = e.Row as AccountDTO;
            if (acc == null || string.IsNullOrEmpty(acc.UserName)) return;
            if (AccountBUS.Instance.AdminUpdateAccount(acc.UserName, acc.DisplayName, acc.Type))
            {
            }
            else
            {
                if (AccountBUS.Instance.InsertAccount(acc.UserName, acc.DisplayName, acc.Type, "Chưa cập nhật", "Trống"))
                {
                    LoadAccountList();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại! Tên đăng nhập này có thể đã tồn tại.", "Lỗi");
                    LoadAccountList(); 
                }
            }
        }
    }
}