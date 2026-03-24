using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class RecipeDAO
    {
        private static RecipeDAO instance;
        public static RecipeDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RecipeDAO();
                }
                return instance;
            }
            private set { instance = value; }
        }
        private RecipeDAO() { }

        //1. Lấy công thức theo món + size
        public DataTable GetRecipeByFood(int foodId, string size)
        {
            string query = @"
                SELECT 
                    R.RecipeId,
                    I.IngredientId,
                    I.IngredientName,
                    R.Amount,
                    I.Unit
                FROM Recipe R
                JOIN Ingredient I ON R.IngredientId = I.IngredientId
                WHERE R.FoodId = @foodId AND R.Size = @size";

            return DataProvider.Instance.ExecuteQuery(query,
                new object[] { foodId, size });
        }

        //2. Thêm công thức
       public bool InsertRecipe(int foodId, int ingredientId, double amount, string size)
        {
            if (CheckRecipeExists(foodId, ingredientId, size))
                return false;
            string query = "INSERT INTO Recipe (FoodId, IngredientId, Amount, Size) VALUES ( @foodId , @ingredientId , @amount , @size )";
            
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodId, ingredientId, amount, size });
            return result > 0;
        }

        // 3. Cập nhật công thức
        public bool UpdateRecipe(int recipeId, int foodId, int ingredientId, double amount, string size)
        {
            string query = "UPDATE Recipe SET FoodId = @foodId , IngredientId = @ingredientId , Amount = @amount , Size = @size WHERE RecipeId = @recipeId ";
            
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodId, ingredientId, amount, size, recipeId });
            return result > 0;
        }

        //4. Xóa công thức
        public bool DeleteRecipe(int recipeId)
        {
            string query = "DELETE FROM Recipe WHERE RecipeId = @recipeId";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { recipeId });
            return result > 0;
        }

        //5. Kiểm tra công thức đã tồn tại chưa
        public bool CheckRecipeExists(int foodId, int ingredientId, string size)
        {
            string query = @"
                SELECT COUNT(*) 
                FROM Recipe 
                WHERE FoodId = @foodId AND IngredientId = @ingredientId AND Size = @size";
            object result = DataProvider.Instance.ExecuteScalar(query,
                new object[] { foodId, ingredientId, size });
            return Convert.ToInt32(result) > 0;
        }

        //6. Xóa toàn bộ công thức của món
        public bool DeleteRecipeByFoodId(int foodId)
        {
            string query = "DELETE FROM Recipe WHERE FoodId = @foodId";
            int result = DataProvider.Instance.ExecuteNonQuery(query, new object[] { foodId });
            return result > 0;
        }
        //7. Loat công thức theo (Admin)
        public DataTable GetAllRecipe()
        {
            string query = @"
                SELECT 
                    R.RecipeId,
                    F.FoodName,
                    R.Size,
                    I.IngredientName,
                    R.Amount,
                    I.Unit
                FROM Recipe R
                JOIN Food F ON R.FoodId = F.FoodId
                JOIN Ingredient I ON R.IngredientId = I.IngredientId";

            return DataProvider.Instance.ExecuteQuery(query);
        }
    }

}
