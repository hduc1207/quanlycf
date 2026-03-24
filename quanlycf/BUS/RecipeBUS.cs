using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BUS
{
    public class RecipeBUS
    {
        private static RecipeBUS instance;

        public static RecipeBUS Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecipeBUS();
                }
                return instance;
            }
            private set { instance = value; }
        }

        private RecipeBUS() { }

        // 1. Lấy công thức theo món + size
        public DataTable GetRecipeByFood(int foodId, string size)
        {
            return RecipeDAO.Instance.GetRecipeByFood(foodId, size);
        }

        // 2. Thêm công thức
        public bool InsertRecipe(int foodId, int ingredientId, double amount, string size)
        {
            return RecipeDAO.Instance.InsertRecipe(foodId, ingredientId, amount, size);
        }

        // 3. Cập nhật công thức
        public bool UpdateRecipe(int recipeId, int foodId, int ingredientId, double amount, string size)
        {
            return RecipeDAO.Instance.UpdateRecipe(recipeId, foodId, ingredientId, amount, size);
        }

        // 4. Xóa công thức
        public bool DeleteRecipe(int recipeId)
        {
            return RecipeDAO.Instance.DeleteRecipe(recipeId);
        }

        // 5. Kiểm tra công thức đã tồn tại chưa
        public bool CheckRecipeExists(int foodId, int ingredientId, string size)
        {
            return RecipeDAO.Instance.CheckRecipeExists(foodId, ingredientId, size);
        }

        // 6. Xóa toàn bộ công thức của món
        public bool DeleteRecipeByFoodId(int foodId)
        {
            return RecipeDAO.Instance.DeleteRecipeByFoodId(foodId);
        }

        // 7. Load công thức
        public DataTable GetAllRecipe()
        {
            return RecipeDAO.Instance.GetAllRecipe();
        }
    }
}