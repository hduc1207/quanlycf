using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class RecipeDTO
    {
        public int RecipeId { get; set; }
        public int FoodId { get; set; }
        public int IngredientId { get; set; }
        public float Amount { get; set; }
        public string Size { get; set; }

        public RecipeDTO() { }

        public RecipeDTO(DataRow row)
        {
            this.RecipeId = (int)row["RecipeId"];
            this.FoodId = (int)row["FoodId"];
            this.IngredientId = (int)row["IngredientId"];
            this.Amount = (float)Convert.ToDouble(row["Amount"]);
            this.Size = row["Size"].ToString();
        }
    }
}
