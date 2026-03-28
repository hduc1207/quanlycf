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
            // 1. Tải bảng hóa đơn lên
            DataTable data = BillBUS.Instance.GetBillListByDate(checkIn, checkOut);
            gridControl1.DataSource = data;

            decimal tongDoanhThu = 0;

            // 2. Tính tổng tiền từ các hóa đơn
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
            //TÍNH TIỀN THẤT THOÁT ĐỂ TRỪ VÀO THỰC THU
            try
            {
                string queryWaste = $"SELECT ISNULL(SUM(LossValue), 0) FROM dbo.WasteLog WHERE CAST(CreatedAt AS DATE) >= '{checkIn.ToString("yyyy-MM-dd")}' AND CAST(CreatedAt AS DATE) <= '{checkOut.ToString("yyyy-MM-dd")}'";
                decimal tienThatThoat = Convert.ToDecimal(QuanLyQuanCafe.DAO.DataProvider.Instance.ExecuteScalar(queryWaste));
                decimal thucThu = tongDoanhThu - tienThatThoat;
                System.Globalization.CultureInfo culture = new System.Globalization.CultureInfo("vi-VN");
                txtTongThu.Text = thucThu.ToString("c0", culture);
                lblThatThoat.Text = "- " + tienThatThoat.ToString("c0", culture);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tính toán thực thu: " + ex.Message);
            }
        }
        private void btnLoc_Click(object sender, EventArgs e)
        {
            LoadListBillByDate(dtpTuNgay.DateTime, dtpDenNgay.DateTime);
        }
    }
}