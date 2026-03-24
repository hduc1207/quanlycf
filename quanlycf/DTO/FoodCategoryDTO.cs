using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class FoodCategoryDTO
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }

        public FoodCategoryDTO() { }

        public FoodCategoryDTO(DataRow row)
        {
            this.CategoryId = (int)row["CategoryId"];
            this.CategoryName = row["CategoryName"].ToString();
        }
        public override string ToString()
        {
            return this.CategoryName;
        }
    }
}
