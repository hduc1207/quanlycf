using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucThuNhap : DevExpress.XtraEditors.XtraUserControl
    {
        public ucThuNhap()
        {
            InitializeComponent();
            btnLoc.Click += btnLoc_Click;
            LoadDateTimePickerBill();
            LoadListBillByDate(dtpTuNgay.DateTime, dtpDenNgay.DateTime);
        }
        void LoadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpTuNgay.DateTime = new DateTime(today.Year, today.Month, 1);
            dtpDenNgay.DateTime = dtpTuNgay.DateTime.AddMonths(1).AddDays(-1);
        }
        void LoadListBillByDate(DateTime checkIn, DateTime checkOut)
        {
            DataTable data = BillBUS.Instance.GetBillListByDate(checkIn, checkOut);
            gridControl1.DataSource = data;
            decimal tongDoanhThu = 0;
            if (data != null && data.Rows.Count > 0)
            {
                foreach (DataRow row in data.Rows)
                {
                    if (row["Tổng tiền"] != DBNull.Value)
                    {
                        tongDoanhThu += Convert.ToDecimal(row["Tổng tiền"]);
                    }
                }
            }
            System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-VN");
            txtTongThu.Text = tongDoanhThu.ToString("c0", culture);
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpTuNgay.DateTime, dtpDenNgay.DateTime);
        }
    }
}