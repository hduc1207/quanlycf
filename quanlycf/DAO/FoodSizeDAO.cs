using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;

namespace QuanLyQuanCafe.DAO
{
    public class FoodSizeDAO
    {
        private static FoodSizeDAO instance;

        public static FoodSizeDAO Instance
        {
            get { if (instance == null) instance = new FoodSizeDAO(); return FoodSizeDAO.instance; }
            private set { FoodSizeDAO.instance = value; }
        }

        private FoodSizeDAO() { }
        public List<FoodSizeDTO> GetListSizeByFoodID(int foodID)
        {
            List<FoodSizeDTO> list = new List<FoodSizeDTO>();

            string query = "SELECT * FROM FoodSize WHERE FoodID = " + foodID;
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                FoodSizeDTO size = new FoodSizeDTO(item);
                list.Add(size);
            }

            return list;
        }
    }
}