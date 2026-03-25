using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class FoodSizeDTO
    {
        public int ID { get; set; }
        public int FoodID { get; set; }
        public string SizeName { get; set; }
        public float Price { get; set; }

        public FoodSizeDTO(int id, int foodId, string sizeName, float price)
        {
            this.ID = id;
            this.FoodID = foodId;
            this.SizeName = sizeName;
            this.Price = price;
        }

        public FoodSizeDTO(DataRow row)
        {
            this.ID = (int)row["ID"];
            this.FoodID = (int)row["FoodID"];
            this.SizeName = row["SizeName"].ToString();
            this.Price = (float)Convert.ToDouble(row["Price"].ToString());
        }
    }
}