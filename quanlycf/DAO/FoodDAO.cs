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
            get
            {
                if (instance == null)
                {
                    instance = new FoodDAO();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private FoodDAO() { }
        // Lấy toàn bộ menu
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

        // Lấy món theo loại
        public List<FoodDTO> GetFoodByCategoryId(int categoryId)
        {
            List<FoodDTO> list = new List<FoodDTO>();

            string query = "SELECT * FROM Food WHERE CategoryId = @categoryId";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                        new object[] { categoryId });

            foreach (DataRow row in data.Rows)
            {
                FoodDTO food = new FoodDTO(row);
                list.Add(food);
            }

            return list;
        }

        // Thêm món
        public bool InsertFood(string foodName, int categoryId, decimal price, string size)
        {
            size = string.IsNullOrEmpty(size) ? "M" : size;
            string query = "INSERT INTO Food(FoodName, CategoryId, Price, Size) VALUES(@foodName, @categoryId, @price, @size)";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                        new object[] { foodName, categoryId, price, size });

            return result > 0;
        }

        // Sửa món
        public bool UpdateFood(int foodId, string foodName, int categoryId, decimal price, string size)
        {
            size = string.IsNullOrEmpty(size) ? "M" : size;
            string query = "UPDATE Food SET FoodName = @foodName, CategoryId = @categoryId, Price = @price, Size = @size WHERE FoodId = @foodId";

            int result = DataProvider.Instance.ExecuteNonQuery(query,
                        new object[] { foodName, categoryId, price, size, foodId });

            return result > 0;
        }
        // Xóa món (tránh lỗi khóa ngoại)
        public bool IsFoodUsed(int foodId)
        {
            string query = "SELECT COUNT(*) FROM BillInfo WHERE FoodId = @foodId";

            int count = (int)DataProvider.Instance.ExecuteScalar(query, new object[] { foodId });

            return count > 0;
        }

        //Lấy món theo CategoryId và Size
        public List<FoodDTO> GetFoodByCategoryAndSize(int categoryId, string size)
        {
            List<FoodDTO> list = new List<FoodDTO>();

            string query = "SELECT * FROM Food WHERE CategoryId = @categoryId AND (Size = @size OR Size IS NULL)";

            DataTable data = DataProvider.Instance.ExecuteQuery(query,
                        new object[] { categoryId, size });

            foreach (DataRow row in data.Rows)
            {
                list.Add(new FoodDTO(row));
            }

            return list;
        }
        public bool DeleteFood(int foodId)
        {
            string query = "DELETE FROM Food WHERE FoodId = @foodId";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodId });
            return result > 0;
        }
    }
}
