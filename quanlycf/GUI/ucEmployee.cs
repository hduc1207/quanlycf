using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using QuanLyQuanCafe.Utils;
using System.ComponentModel;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucEmployee : DevExpress.XtraEditors.XtraUserControl
    {
        public ucEmployee()
        {
            InitializeComponent();
            LoadEmployee();
        }

        // 1. TẢI DANH SÁCH NHÂN VIÊN
        void LoadEmployee()
        {
            EmployeeDAO empDAO = new EmployeeDAO();
            List<EmployeeDTO> listData = empDAO.GetListEmployee();
            BindingList<EmployeeDTO> bindList = new BindingList<EmployeeDTO>(listData);
            gridControl1.DataSource = bindList;
            if (gridView1.Columns["EmployeeId"] != null)
            {
                gridView1.Columns["EmployeeId"].Caption = "Mã NV";
                gridView1.Columns["EmployeeId"].OptionsColumn.AllowEdit = false;
            }
            if (gridView1.Columns["FullName"] != null) gridView1.Columns["FullName"].Caption = "Tên Nhân Viên";
            if (gridView1.Columns["PhoneNumber"] != null) gridView1.Columns["PhoneNumber"].Caption = "Số Điện Thoại";
            if (gridView1.Columns["Email"] != null) gridView1.Columns["Email"].Caption = "Email";
            if (gridView1.Columns["Address"] != null) gridView1.Columns["Address"].Visible = false;
        }

        // 2. Nút Refresh (Làm mới)
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadEmployee();
        }

        // 3. NÚT XÓA 
        private void btnXoa_Click(object sender, EventArgs e)
        {
            EmployeeDTO emp = gridView1.GetFocusedRow() as EmployeeDTO;

            if (emp != null && emp.EmployeeId > 0)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên: {emp.FullName}?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    string deleteQuery = $"DELETE FROM dbo.Employee WHERE EmployeeId = {emp.EmployeeId}";
                    if (DataProvider.Instance.ExecuteNonQuery(deleteQuery) > 0)
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadEmployee();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa!", "Thông báo");
            }
        }

        // 4. SỰ KIỆN THÊM / SỬA
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            EmployeeDTO emp = e.Row as EmployeeDTO;
            if (emp == null || string.IsNullOrEmpty(emp.FullName)) return;
            string encName = string.IsNullOrEmpty(emp.FullName) ? "" : SecurityHelper.Encrypt(emp.FullName);
            string encPhone = string.IsNullOrEmpty(emp.PhoneNumber) ? "" : SecurityHelper.Encrypt(emp.PhoneNumber);
            string encEmail = string.IsNullOrEmpty(emp.Email) ? "" : SecurityHelper.Encrypt(emp.Email);
            string encAddress = string.IsNullOrEmpty(emp.Address) ? "" : SecurityHelper.Encrypt(emp.Address);
            object objBirthDate = emp.BirthDate.HasValue ? $"'{emp.BirthDate.Value.ToString("yyyy-MM-dd")}'" : "NULL";
            if (emp.EmployeeId == 0)
            {
                string insertQuery = $@"INSERT INTO dbo.Employee (FullName, PhoneNumber, Email, Address, StartDate, BirthDate) 
                                      VALUES ('{encName}', '{encPhone}', '{encEmail}', '{encAddress}', GETDATE(), {objBirthDate})";

                if (DataProvider.Instance.ExecuteNonQuery(insertQuery) > 0)
                {
                    MessageBox.Show("Thêm mới thành công!", "Thông báo");
                    LoadEmployee();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                }
            }
            else
            {
                string updateQuery = $@"UPDATE dbo.Employee 
                                      SET FullName = '{encName}', PhoneNumber = '{encPhone}', Email = '{encEmail}', Address = '{encAddress}', BirthDate = {objBirthDate} 
                                      WHERE EmployeeId = {emp.EmployeeId}";

                if (DataProvider.Instance.ExecuteNonQuery(updateQuery) <= 0)
                {
                    MessageBox.Show("Sửa thất bại!", "Lỗi");
                }
            }
        }
    }
}