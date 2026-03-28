using QuanLyQuanCafe.DTO;
using System.Collections.Generic;
using System.Data;
using System;

namespace QuanLyQuanCafe.DAO
{
    public class VoucherDAO
    {
        private static VoucherDAO instance;
        public static VoucherDAO Instance
        {
            get { if (instance == null) instance = new VoucherDAO(); return instance; }
            private set { instance = value; }
        }
        private VoucherDAO() { }

        public VoucherDTO GetVoucherByCode(string code)
        {
            string query = "SELECT * FROM dbo.Voucher WHERE VoucherCode = @code";
            DataTable data = DataProvider.Instance.ExecuteQuery(query, new object[] { code });
            if (data.Rows.Count > 0) return new VoucherDTO(data.Rows[0]);
            return null;
        }

        public void UpdateVoucherUsage(string code)
        {
            string query = "UPDATE dbo.Voucher SET UsedCount = UsedCount + 1 WHERE VoucherCode = @code";
            DataProvider.Instance.ExecuteNonQuery(query, new object[] { code });

        }
        public List<VoucherDTO> GetListVoucher()
        {
            List<VoucherDTO> list = new List<VoucherDTO>();
            string query = "SELECT * FROM dbo.Voucher WHERE Status = 1 AND EndDate >= GETDATE() AND UsedCount < UsageLimit";
            DataTable data = DataProvider.Instance.ExecuteQuery(query);

            foreach (DataRow item in data.Rows)
            {
                VoucherDTO voucher = new VoucherDTO(item);
                list.Add(voucher);
            }
            return list;
        }
        public bool InsertVoucher(string code, string name, int type, float value, float max, float min, System.DateTime start, System.DateTime end, int limit)
        {
            string query = string.Format("INSERT INTO dbo.Voucher (VoucherCode, VoucherName, DiscountType, DiscountValue, MaxDiscount, MinBillValue, StartDate, EndDate, UsageLimit) VALUES ( '{0}', N'{1}', {2}, {3}, {4}, {5}, '{6}', '{7}', {8} )", code, name, type, value, max, min, start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"), limit);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool UpdateVoucher(string code, string name, int type, float value, float max, float min, System.DateTime start, System.DateTime end, int limit, int status)
        {
            string query = string.Format("UPDATE dbo.Voucher SET VoucherName = N'{0}', DiscountType = {1}, DiscountValue = {2}, MaxDiscount = {3}, MinBillValue = {4}, StartDate = '{5}', EndDate = '{6}', UsageLimit = {7}, Status = {8} WHERE VoucherCode = '{9}'", name, type, value, max, min, start.ToString("yyyy-MM-dd HH:mm:ss"), end.ToString("yyyy-MM-dd HH:mm:ss"), limit, status, code);
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
        public bool DeleteVoucher(string code)
        {
            string query = "DELETE dbo.Voucher WHERE VoucherCode = '" + code + "'";
            int result = DataProvider.Instance.ExecuteNonQuery(query);
            return result > 0;
        }
    }
}