using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Collections.Generic;

namespace QuanLyQuanCafe.BUS
{
    public class FoodCategoryBUS
    {
        private static FoodCategoryBUS instance;
        public static FoodCategoryBUS Instance
        {
            get { if (instance == null) instance = new FoodCategoryBUS(); return instance; }
            private set { instance = value; }
        }
        private FoodCategoryBUS() { }

        // 1. Lấy danh sách danh mục
        public List<FoodCategoryDTO> GetListCategory()
        {
            return FoodCategoryDAO.Instance.GetListCategory();
        }

        // 2. Thêm danh mục mới
        public bool InsertCategory(string name)
        {
            return FoodCategoryDAO.Instance.InsertCategory(name);
        }

        // 3. Cập nhật/Sửa tên danh mục
        public bool UpdateCategory(int id, string name)
        {
            return FoodCategoryDAO.Instance.UpdateCategory(id, name);
        }

        // 4. Xóa danh mục
        public bool DeleteCategory(int id)
        {
            return FoodCategoryDAO.Instance.DeleteCategory(id);
        }
    }
}