using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { instance = value; }
        }
        private FoodDAO() { }

        // 1. Lấy toàn bộ menu
        public List<FoodDTO> GetListFood()
        {
            List<FoodDTO> list = new List<FoodDTO>();
            string query = "SELECT * FROM Food";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                FoodDTO food = new FoodDTO(row);
                list.Add(food);
            }
            return list;
        }

        // 2. Lấy món theo loại
        public List<FoodDTO> GetFoodByCategoryId(int categoryId)
        {
            List<FoodDTO> list = new List<FoodDTO>();
            string query = "SELECT * FROM Food WHERE CategoryId = " + categoryId;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);
            foreach (DataRow row in data.Rows)
            {
                FoodDTO food = new FoodDTO(row);
                list.Add(food);
            }
            return list;
        }

        // 3. Thêm món (Bỏ hẳn Price và Size)
        public bool InsertFood(string foodName, int categoryId)
        {
            string query = "INSERT INTO Food (FoodName, CategoryId) VALUES ( @foodName , @categoryId )";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodName, categoryId });
            return result > 0;
        }

        // 4. Sửa món (Bỏ hẳn Price và Size)
        public bool UpdateFood(int foodId, string foodName, int categoryId)
        {
            // Câu lệnh SQL giờ chỉ Update 2 cột
            string query = "UPDATE Food SET FoodName = @foodName , CategoryId = @categoryId WHERE FoodId = @foodId";

            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodName, categoryId, foodId });
            return result > 0;
        }

        // 5. Kiểm tra xem món đã được dùng chưa (Tránh lỗi khóa ngoại)
        public bool IsFoodUsed(int foodId)
        {
            string query = "SELECT COUNT(*) FROM BillInfo WHERE FoodId = " + foodId;
            int count = (int)DataProvider.Instance.ExecuteScalar(query);
            return count > 0;
        }

        // 6. Xóa món
        public bool DeleteFood(int foodId)
        {
            DataProvider.Instance.ExecuteNonQuery("DELETE FROM FoodSize WHERE FoodID = " + foodId);
            string query = "DELETE FROM Food WHERE FoodId = " + foodId;
            int result = DataProvider.Instance.ExecuteNonQuery(query);

            return result > 0;
        }
    }
}