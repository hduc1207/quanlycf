using DevExpress.XtraEditors;
using QuanLyQuanCafe.DAO;
using System;
using System.Data;
using System.Windows.Forms;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucVoucher : DevExpress.XtraEditors.XtraUserControl
    {
        public ucVoucher()
        {
            InitializeComponent();
            LoadListVoucher();
            gridView1.RowUpdated += gridView1_RowUpdated;
        }

        // 1. Tải danh sách Voucher
        void LoadListVoucher()
        {
            string query = "SELECT * FROM dbo.Voucher";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            gridControl1.DataSource = data;
            if (gridView1.Columns["VoucherCode"] != null)
            {
                gridView1.Columns["VoucherCode"].Caption = "Mã Code";
                gridView1.Columns["VoucherName"].Caption = "Tên Hiển Thị";
                gridView1.Columns["DiscountType"].Caption = "Loại (0:Tiền, 1:%)";
                gridView1.Columns["DiscountValue"].Caption = "Mức Giảm";
                gridView1.Columns["MaxDiscount"].Caption = "Giảm Tối Đa";
                gridView1.Columns["MinBillValue"].Caption = "Đơn Tối Thiểu";
                gridView1.Columns["StartDate"].Caption = "Bắt Đầu";
                gridView1.Columns["EndDate"].Caption = "Kết Thúc";
                gridView1.Columns["UsageLimit"].Caption = "Giới Hạn Lượt";

                gridView1.Columns["UsedCount"].Caption = "Đã Dùng";
                gridView1.Columns["UsedCount"].OptionsColumn.AllowEdit = false;

                gridView1.Columns["Status"].Caption = "Mở (1/0)";
            }
        }

        // 2. Nút Làm Mới
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadListVoucher();
        }

        // 3. Sự kiện Thêm/Sửa
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView rowView = e.Row as DataRowView;
            if (rowView == null) return;
            string code = rowView["VoucherCode"] == DBNull.Value ? "" : rowView["VoucherCode"].ToString().Trim().ToUpper();
            if (string.IsNullOrEmpty(code)) return;

            string name = rowView["VoucherName"] == DBNull.Value ? "" : rowView["VoucherName"].ToString();
            int type = rowView["DiscountType"] == DBNull.Value ? 0 : Convert.ToInt32(rowView["DiscountType"]);
            float val = rowView["DiscountValue"] == DBNull.Value ? 0 : Convert.ToSingle(rowView["DiscountValue"]);
            float max = rowView["MaxDiscount"] == DBNull.Value ? 0 : Convert.ToSingle(rowView["MaxDiscount"]);
            float min = rowView["MinBillValue"] == DBNull.Value ? 0 : Convert.ToSingle(rowView["MinBillValue"]);

            DateTime start = rowView["StartDate"] == DBNull.Value ? DateTime.Now : Convert.ToDateTime(rowView["StartDate"]);
            DateTime end = rowView["EndDate"] == DBNull.Value ? DateTime.Now.AddMonths(1) : Convert.ToDateTime(rowView["EndDate"]);

            int limit = rowView["UsageLimit"] == DBNull.Value ? 100 : Convert.ToInt32(rowView["UsageLimit"]);
            int status = (rowView["Status"] == DBNull.Value || Convert.ToBoolean(rowView["Status"])) ? 1 : 0;
            string checkQuery = $"SELECT COUNT(*) FROM dbo.Voucher WHERE VoucherCode = '{code}'";
            int exists = (int)DataProvider.Instance.ExecuteScalar(checkQuery);

            if (exists == 0)
            {
                if (VoucherDAO.Instance.InsertVoucher(code, name, type, val, max, min, start, end, limit))
                {
                    LoadListVoucher();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                }
            }
            else
            {
                if (!VoucherDAO.Instance.UpdateVoucher(code, name, type, val, max, min, start, end, limit, status))
                {
                    MessageBox.Show("Cập nhật thất bại!", "Lỗi");
                }
            }
        }

        // 4. Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView rowView = gridView1.GetFocusedRow() as DataRowView;

            if (rowView != null && rowView["VoucherCode"] != DBNull.Value)
            {
                string code = rowView["VoucherCode"].ToString();

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa mã Voucher: {code}?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (VoucherDAO.Instance.DeleteVoucher(code))
                    {
                        LoadListVoucher();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một Voucher để xóa!", "Thông báo");
            }
        }
    }
}