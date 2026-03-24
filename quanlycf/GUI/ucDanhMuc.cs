using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucDanhMuc : DevExpress.XtraEditors.XtraUserControl
    {
        public ucDanhMuc()
        {
            InitializeComponent();
            LoadCategory();
        }
        void LoadCategory()
        {
            List<FoodCategoryDTO> listCategory = FoodCategoryBUS.Instance.GetListCategory();
            gridControl1.DataSource = new System.ComponentModel.BindingList<FoodCategoryDTO>(listCategory);
        }
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadCategory();
        }
        private void btnXoa_Click(object sender, EventArgs e)
        {
            FoodCategoryDTO selectedCategory = gridView1.GetFocusedRow() as FoodCategoryDTO;
            if (selectedCategory != null && selectedCategory.CategoryId != 0)
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa danh mục: {selectedCategory.CategoryName}?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                {
                    try
                    {
                        if (FoodCategoryBUS.Instance.DeleteCategory(selectedCategory.CategoryId))
                        {
                            MessageBox.Show("Xóa thành công!", "Thông báo");
                            LoadCategory();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Không thể xóa! Danh mục này đang chứa món ăn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng click chọn một danh mục hợp lệ trên bảng để xóa!", "Thông báo");
            }
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            FoodCategoryDTO category = e.Row as FoodCategoryDTO;
            if (category == null) return;
            if (category.CategoryId == 0)
            {
                if (FoodCategoryBUS.Instance.InsertCategory(category.CategoryName))
                {
                    LoadCategory();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại!", "Lỗi");
                }
            }
            else
            {
                if (!FoodCategoryBUS.Instance.UpdateCategory(category.CategoryId, category.CategoryName))
                {
                    MessageBox.Show("Sửa thất bại!", "Lỗi");
                }
            }
        }
    }
}