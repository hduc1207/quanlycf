using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class IngredientDTO
    {
        int IngredientId { get; set; }
        string IngredientName { get; set; }
        string Unit { get; set; }
        float Quantity { get; set; }
        Decimal UnitPrice { get; set; }
        float MinQuantity { get; set; }

        public IngredientDTO() { }

        public IngredientDTO(DataRow row)
        {
            this.IngredientId = (int)row["IngredientId"];
            this.IngredientName = row["IngredientName"].ToString();
            this.Unit = row["Unit"].ToString();
            this.Quantity = (float)Convert.ToDouble(row["Quantity"]);
            this.UnitPrice = (Decimal)row["UnitPrice"];
            this.MinQuantity = (float)Convert.ToDouble(row["MinQuantity"]);
        }
    }
}
