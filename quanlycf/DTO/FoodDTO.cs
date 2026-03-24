using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class FoodDTO
    {
        public int FoodId { get; set; }
        public string FoodName { get; set; }
        public int CategoryId { get; set; }
        public decimal Price { get; set; }
        public string Size { get; set; }

        public FoodDTO() { }

        public FoodDTO(DataRow row)
        {
            this.FoodId = (int)row["FoodId"];
            this.FoodName = row["FoodName"].ToString();
            this.CategoryId = (int)row["CategoryId"];
            this.Price = (decimal)row["Price"];
            this.Size = row["Size"] == DBNull.Value ? "" : row["Size"].ToString();
        }
        public override string ToString()
        {
            return this.FoodName;
        }
    }
}

