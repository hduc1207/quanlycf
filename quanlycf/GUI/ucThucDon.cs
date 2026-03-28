using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucThucDon : DevExpress.XtraEditors.XtraUserControl
    {
        public ucThucDon()
        {
            InitializeComponent();
            LoadFood();
        }
        void LoadFood()
        {
            List<FoodDTO> listFood = FoodBUS.Instance.GetListFood();
            gridControl1.DataSource = new System.ComponentModel.BindingList<FoodDTO>(listFood);
            RepositoryItemLookUpEdit repoCategory = new RepositoryItemLookUpEdit();
            repoCategory.DataSource = FoodCategoryBUS.Instance.GetListCategory();
            repoCategory.DisplayMember = "CategoryName";
            repoCategory.ValueMember = "CategoryId";
            repoCategory.NullText = "-- Chọn danh mục --";

            gridView1.Columns["CategoryId"].ColumnEdit = repoCategory;
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadFood();
        }

        // 3. Nút xóa món ăn
        private void btnXoa_Click(object sender, EventArgs e)
        {
            FoodDTO selectedFood = gridView1.GetFocusedRow() as FoodDTO;

            if (selectedFood != null && selectedFood.FoodId != 0)
            {
                if (FoodBUS.Instance.IsFoodUsed(selectedFood.FoodId))
                {
                    MessageBox.Show("Không thể xóa! Món này đã từng được gọi trong hóa đơn. Bạn chỉ có thể đổi tên.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa món: {selectedFood.FoodName}?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (FoodBUS.Instance.DeleteFood(selectedFood.FoodId))
                    {
                        MessageBox.Show("Xóa thành công!", "Thông báo");
                        LoadFood();
                    }
                    else
                    {
                        MessageBox.Show("Xóa thất bại do lỗi hệ thống!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn một món hợp lệ trên bảng để xóa!", "Thông báo");
            }
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            FoodDTO food = e.Row as FoodDTO;
            if (food == null) return;

            if (food.FoodId == 0)
            {
                if (FoodBUS.Instance.InsertFood(food.FoodName, food.CategoryId))
                {
                    LoadFood();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                }
            }
            else
            {
                if (!FoodBUS.Instance.UpdateFood(food.FoodId, food.FoodName, food.CategoryId))
                {
                    MessageBox.Show("Sửa thất bại!", "Lỗi");
                }
            }
        }
    }
}