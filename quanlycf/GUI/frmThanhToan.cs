using PayOS;
using PayOS.Models;
using PayOS.Models.V2.PaymentRequests;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.GUI
{
    public partial class frmThanhToan : DevExpress.XtraEditors.XtraForm
    {
        private int idHoaDon;
        private double tongTien;
        private int soCham = 0;
        private long orderCode;
        private string clientId = "c1a0e4b0-66b9-4171-8fbf-449f370396c1";
        private string apiKey = "fd60a116-7960-4a99-ab50-c7afa738fa02";
        private string checksumKey = "7e1b78e202034d17706c28ad4b0170f63cb5bf5e5be71ae17a8c90ac00151f58";
        private PayOSClient payOSClient;

        public frmThanhToan(int idHoaDon, double tongTien)
        {
            InitializeComponent();
            this.idHoaDon = idHoaDon;
            this.tongTien = tongTien;
            payOSClient = new PayOSClient(clientId, apiKey, checksumKey);

            lblTongTIen.Text = "Cần thanh toán: " + tongTien.ToString("c0", new System.Globalization.CultureInfo("vi-VN"));
            rdoTienMat.Checked = true;
            picQR.Visible = false;
            lblTrangThai.Visible = false;

            rdoChuyenKhoan.CheckedChanged += rdoChuyenKhoan_CheckedChanged;
            timerKiemTraTien.Tick += timerKiemTraTien_Tick;
        }

        private async void rdoChuyenKhoan_CheckedChanged(object sender, EventArgs e)
        {
            if (rdoChuyenKhoan.Checked)
            {
                picQR.Visible = true;
                lblTrangThai.Visible = true;
                lblTrangThai.Text = "⏳ Đang tạo mã QR siêu tốc...";

                try
                {
                    orderCode = long.Parse(DateTime.Now.ToString("yyMMddHHmmss"));
                    var paymentRequest = new CreatePaymentLinkRequest
                    {
                        OrderCode = orderCode,
                        Amount = (int)tongTien,
                        Description = "Thanh toan cafe",
                        CancelUrl = "https://localhost",
                        ReturnUrl = "https://localhost"
                    };
                    var paymentLink = await payOSClient.PaymentRequests.CreateAsync(paymentRequest);
                    string urlHinhAnhQR = "https://quickchart.io/qr?size=300&text=" + Uri.EscapeDataString(paymentLink.QrCode);
                    picQR.LoadAsync(urlHinhAnhQR);

                    timerKiemTraTien.Start();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi mạng khi tạo QR: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                picQR.Visible = false;
                lblTrangThai.Visible = false;
                timerKiemTraTien.Stop();
            }
        }

        private async void timerKiemTraTien_Tick(object sender, EventArgs e)
        {
            timerKiemTraTien.Stop();

            try
            {
                var paymentInfo = await payOSClient.PaymentRequests.GetAsync(orderCode);
                lblTrangThai.Text = "Trạng thái PayOS: " + paymentInfo.Status;
                if (paymentInfo.Status.ToString().ToUpper() == "PAID")
                {
                    MessageBox.Show("ĐÃ THANH TOÁN THÀNH CÔNG!", "Tuyệt vời", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    return;
                }
            }
            catch (Exception ex)
            {
                lblTrangThai.Text = "Lỗi API: " + ex.Message;
            }

            timerKiemTraTien.Start();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            timerKiemTraTien.Stop();
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
        private void btnHuy_Click(object sender, EventArgs e)
        {
            timerKiemTraTien.Stop();
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}