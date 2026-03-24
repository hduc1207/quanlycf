using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System.Collections.Generic;

namespace QuanLyQuanCafe.BUS
{
    public class FoodBUS
    {
        private static FoodBUS instance;
        public static FoodBUS Instance
        {
            get { if (instance == null) instance = new FoodBUS(); return instance; }
            private set { instance = value; }
        }
        private FoodBUS() { }

        public List<FoodDTO> GetListFood()
        {
            return FoodDAO.Instance.GetListFood();
        }

        public bool InsertFood(string foodName, int categoryId, decimal price, string size)
        {
            return FoodDAO.Instance.InsertFood(foodName, categoryId, price, size);
        }

        public bool UpdateFood(int foodId, string foodName, int categoryId, decimal price, string size)
        {
            return FoodDAO.Instance.UpdateFood(foodId, foodName, categoryId, price, size);
        }

        public bool IsFoodUsed(int foodId)
        {
            return FoodDAO.Instance.IsFoodUsed(foodId);
        }

        public bool DeleteFood(int foodId)
        {
            return FoodDAO.Instance.DeleteFood(foodId);
        }
    }
}