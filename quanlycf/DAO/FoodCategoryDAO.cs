using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodCategoryDAO
    {
        private static FoodCategoryDAO instance;
        public static FoodCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new FoodCategoryDAO();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private FoodCategoryDAO() { }
        //Lấy danh sách
        public List<FoodCategoryDTO> GetListCategory()
        {
            List<FoodCategoryDTO> list = new List<FoodCategoryDTO>();
            string query = "SELECT * FROM FoodCategory";

            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                FoodCategoryDTO foodCategory = new FoodCategoryDTO(row);
                list.Add(foodCategory);
            }
            
            return list;
        }

        //Get by id
        public FoodCategoryDTO GetCategoryById(int categoryId)
        {
            string query = "SELECT * FROM FoodCategory WHERE CategoryId = @categoryId";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                        new object[] { categoryId });

            if (data.Rows.Count > 0)
            {
                return new FoodCategoryDTO(data.Rows[0]);
            }

            return null;
        }

        // Thêm loại món
        public bool InsertCategory(string categoryName)
        {
            string query = "INSERT INTO FoodCategory(CategoryName) VALUES(@categoryName)";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                        new object[] { categoryName });

            return result > 0;
        }

        // Sửa loại món
        public bool UpdateCategory(int categoryId, string categoryName)
        {
            string query = "UPDATE FoodCategory SET CategoryName = @categoryName WHERE CategoryId = @categoryId";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                        new object[] { categoryName, categoryId });

            return result > 0;
        }
        // Xóa loại món
        public bool DeleteCategory(int categoryId)
        {
            string query = "DELETE FROM FoodCategory WHERE CategoryId = @categoryId";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                        new object[] { categoryId });

            return result > 0;
        }
    }
}
