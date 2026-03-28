using DevExpress.XtraEditors;
using QuanLyQuanCafe.DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucWasteLog : DevExpress.XtraEditors.XtraUserControl
    {
        public ucWasteLog()
        {
            InitializeComponent();
            LoadListWasteLog();
            gridView1.RowUpdated += gridView1_RowUpdated;
        }
        // 1. TẢI DANH SÁCH THẤT THOÁT
        void LoadListWasteLog()
        {
            gridControl1.DataSource = WasteLogDAO.Instance.GetListWasteLog();
            if (gridView1.Columns["ID"] != null)
            {
                gridView1.Columns["ID"].Caption = "Mã Số";
                gridView1.Columns["ID"].OptionsColumn.AllowEdit = false;

                gridView1.Columns["FoodName"].Caption = "Tên Món Hỏng/Hủy";
                gridView1.Columns["Quantity"].Caption = "Số Lượng";
                gridView1.Columns["LossValue"].Caption = "Giá Trị Thiệt Hại";
                gridView1.Columns["Reason"].Caption = "Lý Do Hủy";
                gridView1.Columns["StaffName"].Caption = "Người Báo Cáo";

                gridView1.Columns["CreatedAt"].Caption = "Ngày Ghi Nhận";
                gridView1.Columns["CreatedAt"].OptionsColumn.AllowEdit = false;
            }
        }
        // 2. NÚT LÀM MỚI
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadListWasteLog();
        }
        // 3. SỰ KIỆN THÊM/SỬA
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView rowView = e.Row as DataRowView;
            if (rowView == null) return;
            string foodName = rowView["FoodName"] == DBNull.Value ? "" : rowView["FoodName"].ToString().Trim();
            int qty = rowView["Quantity"] == DBNull.Value ? 1 : Convert.ToInt32(rowView["Quantity"]);
            float lossValue = rowView["LossValue"] == DBNull.Value ? 0 : Convert.ToSingle(rowView["LossValue"]);
            string reason = rowView["Reason"] == DBNull.Value ? "" : rowView["Reason"].ToString();
            string staff = rowView["StaffName"] == DBNull.Value ? "Admin" : rowView["StaffName"].ToString();
            int id = rowView["ID"] == DBNull.Value ? 0 : Convert.ToInt32(rowView["ID"]);

            if (id == 0)
            {
                if (WasteLogDAO.Instance.InsertWaste(foodName, qty, lossValue, reason, staff))
                {
                    LoadListWasteLog();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                }
            }
            else
                if (!WasteLogDAO.Instance.UpdateWaste(id, foodName, qty, lossValue, reason, staff))
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi");
                }
            }
        // 4. NÚT XÓA BÁO CÁO THẤT THOÁT
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView rowView = gridView1.GetFocusedRow() as DataRowView;

            if (rowView != null && rowView["ID"] != DBNull.Value)
            {
                int id = Convert.ToInt32(rowView["ID"]);
                string foodName = rowView["FoodName"].ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa báo cáo thất thoát của món: [{foodName}] không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (WasteLogDAO.Instance.DeleteWaste(id))
                    {
                        LoadListWasteLog();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xóa!", "Thông báo");
            }
        }
    }
}