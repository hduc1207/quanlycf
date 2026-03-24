using DevExpress.XtraEditors;
using System;
using System.Data;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucKho : DevExpress.XtraEditors.XtraUserControl
    {
        public ucKho()
        {
            InitializeComponent();
            LoadKho();
        }
        void LoadKho()
        {
            DataTable data = IngredientBUS.Instance.GetListIngredient();
            gridControl1.DataSource = data;
            if (gridView1.Columns["IngredientId"] != null)
            {
                gridView1.Columns["IngredientId"].OptionsColumn.AllowEdit = false;
            }
        }

        // 2. Nút Refresh
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadKho();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataRowView rowView = gridView1.GetFocusedRow() as DataRowView;

            if (rowView != null && rowView["IngredientId"] != DBNull.Value)
            {
                int id = Convert.ToInt32(rowView["IngredientId"]);
                string name = rowView["Name"].ToString();
                if (IngredientBUS.Instance.IsIngredientUsed(id))
                {
                    MessageBox.Show($"Không thể xóa [{name}] vì nguyên liệu này đang được dùng trong công thức món ăn!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa nguyên liệu: {name}?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (IngredientBUS.Instance.DeleteIngredient(id))
                    {
                        LoadKho();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại!", "Lỗi");
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một nguyên liệu để xóa!", "Thông báo");
            }
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            DataRowView rowView = e.Row as DataRowView;
            if (rowView == null) return;
            string name = rowView["Name"] == DBNull.Value ? "" : rowView["Name"].ToString();
            string unit = rowView["Unit"] == DBNull.Value ? "kg" : rowView["Unit"].ToString();
            double quantity = rowView["Quantity"] == DBNull.Value ? 0 : Convert.ToDouble(rowView["Quantity"]);
            decimal price = rowView["Price"] == DBNull.Value ? 0 : Convert.ToDecimal(rowView["Price"]);
            double minQty = rowView["MinQuantity"] == DBNull.Value ? 0 : Convert.ToDouble(rowView["MinQuantity"]);

            if (string.IsNullOrEmpty(name)) return;

            int id = rowView["IngredientId"] == DBNull.Value ? 0 : Convert.ToInt32(rowView["IngredientId"]);

            if (id == 0)
            {
                if (IngredientBUS.Instance.InsertIngredient(name, unit, quantity, price, minQty))
                {
                    LoadKho();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                    LoadKho();
                }
            }
            else
            {
                if (!IngredientBUS.Instance.UpdateIngredient(id, name, unit, quantity, price, minQty))
                {
                    MessageBox.Show("Sửa thất bại!", "Lỗi");
                }
            }
        }
    }
}