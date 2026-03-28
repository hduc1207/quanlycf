using DevExpress.XtraCharts;
using System;
using System.Data;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucThongKe : DevExpress.XtraEditors.XtraUserControl
    {
        public ucThongKe()
        {
            InitializeComponent();
            LoadBieuDo();
        }
        void LoadBieuDo()
        {
            DateTime denNgay = DateTime.Now;
            DateTime tuNgay = denNgay.AddDays(-7);

            VeBieuDoTyLe(tuNgay, denNgay);
            VeBieuDoDoanhThu(tuNgay, denNgay);
        }
        void VeBieuDoTyLe(DateTime tuNgay, DateTime denNgay)
        {
            chartTyLe.Series.Clear();
            Series seriesTyLe = new Series("Tỷ lệ bán ra", ViewType.Pie);
            DataTable dt = BillBUS.Instance.GetMonBanChay(tuNgay, denNgay);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    string tenMon = row["TenMon"].ToString();
                    double soLuong = Convert.ToDouble(row["SoLuong"]);
                    seriesTyLe.Points.Add(new SeriesPoint(tenMon, soLuong));
                }
            }
            seriesTyLe.Label.TextPattern = "{A}: {VP:P0}";
            ((PieSeriesLabel)seriesTyLe.Label).Position = PieSeriesLabelPosition.TwoColumns;

            chartTyLe.Series.Add(seriesTyLe);

            ChartTitle title = new ChartTitle();
            title.Text = "TỶ LỆ MÓN ĂN BÁN CHẠY (7 NGÀY QUA)";
            chartTyLe.Titles.Add(title);
        }
        void VeBieuDoDoanhThu(DateTime tuNgay, DateTime denNgay)
        {
            chartDoanhThu.Series.Clear();
            Series seriesDoanhThu = new Series("Doanh thu thực tế (VNĐ)", ViewType.Line);
            DataTable dt = BillBUS.Instance.GetDoanhThuTheoNgay(tuNgay, denNgay);

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow row in dt.Rows)
                {
                    DateTime ngay = Convert.ToDateTime(row["Ngay"]);
                    double doanhThuBan = Convert.ToDouble(row["DoanhThu"]);
                    double tienThatThoat = 0;
                    try
                    {
                        string queryWaste = $"SELECT ISNULL(SUM(LossValue), 0) FROM dbo.WasteLog WHERE CAST(CreatedAt AS DATE) = '{ngay.ToString("yyyy-MM-dd")}'";
                        tienThatThoat = Convert.ToDouble(QuanLyQuanCafe.DAO.DataProvider.Instance.ExecuteScalar(queryWaste));
                    }
                    catch { }
                    double thucThu = doanhThuBan - tienThatThoat;
                    seriesDoanhThu.Points.Add(new SeriesPoint(ngay.ToString("dd/MM"), thucThu));
                }
            }

            ((LineSeriesView)seriesDoanhThu.View).MarkerVisibility = DevExpress.Utils.DefaultBoolean.True;
            seriesDoanhThu.LabelsVisibility = DevExpress.Utils.DefaultBoolean.True;

            chartDoanhThu.Series.Add(seriesDoanhThu);

            ChartTitle title = new ChartTitle();
            title.Text = "BIỂU ĐỒ DOANH THU THỰC TẾ 7 NGÀY GẦN NHẤT";
            chartDoanhThu.Titles.Add(title);
        }
    }
}