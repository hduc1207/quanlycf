using System;
using System.Data;

namespace QuanLyQuanCafe.DTO
{
    public class VoucherDTO
    {
        public string VoucherCode { get; set; }
        public string VoucherName { get; set; }
        public int DiscountType { get; set; }
        public float DiscountValue { get; set; }
        public float MaxDiscount { get; set; }
        public float MinBillValue { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int UsageLimit { get; set; }
        public int UsedCount { get; set; }
        public bool Status { get; set; }

        public VoucherDTO(DataRow row)
        {
            this.VoucherCode = row["VoucherCode"].ToString();
            this.VoucherName = row["VoucherName"].ToString();
            this.DiscountType = Convert.ToInt32(row["DiscountType"]);
            this.DiscountValue = Convert.ToSingle(row["DiscountValue"]);
            this.MaxDiscount = row["MaxDiscount"] != DBNull.Value ? Convert.ToSingle(row["MaxDiscount"]) : 0;
            this.MinBillValue = Convert.ToSingle(row["MinBillValue"]);
            this.StartDate = Convert.ToDateTime(row["StartDate"]);
            this.EndDate = Convert.ToDateTime(row["EndDate"]);
            this.UsageLimit = Convert.ToInt32(row["UsageLimit"]);
            this.UsedCount = Convert.ToInt32(row["UsedCount"]);
            this.Status = Convert.ToBoolean(row["Status"]);
        }
    }
}