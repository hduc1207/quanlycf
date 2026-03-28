using DevExpress.XtraEditors;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucOrder : DevExpress.XtraEditors.XtraUserControl
    {
        private TableFoodDTO banHienTai = null;
        private decimal tongTienGoc = 0;
        private string currentVoucherCode = "";
        private decimal tienGiamVoucher = 0;
        public ucOrder()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            LoadTableCombo();
            LoadSizeCombo();
            LoadVoucherCombo();
            lkeSize.Properties.NullText = "--Size--";
        }
        // 1. Hàm load danh sách Size theo ID đồ uống
        void LoadSizeByFoodID(int foodID)
        {
            List<FoodSizeDTO> listSize = FoodSizeDAO.Instance.GetListSizeByFoodID(foodID);

            lkeSize.Properties.DataSource = listSize;
            lkeSize.Properties.DisplayMember = "SizeName";
            lkeSize.Properties.ValueMember = "Price";
            lkeSize.Properties.PopulateColumns();

            if (lkeSize.Properties.Columns.Count > 0)
            {
                lkeSize.Properties.Columns["ID"].Visible = false;
                lkeSize.Properties.Columns["FoodID"].Visible = false;
                lkeSize.Properties.Columns["SizeName"].Caption = "Size";
                lkeSize.Properties.Columns["Price"].Caption = "Giá tiền (VNĐ)";
                lkeSize.Properties.Columns["Price"].FormatType = DevExpress.Utils.FormatType.Numeric;
                lkeSize.Properties.Columns["Price"].FormatString = "n0";
            }
            if (listSize.Count > 0)
            {
                lkeSize.EditValue = listSize[0].Price;
            }
            else
            {
                lkeSize.EditValue = null;
            }
        }

        // 2. Hàm load danh sách Bàn lên giao diện
        void LoadTable()
        {
            flpDanhSachBan.Controls.Clear();
            List<TableFoodDTO> tableList = TableFoodBUS.Instance.GetListTable();

            foreach (TableFoodDTO item in tableList)
            {
                SimpleButton btnBan = new SimpleButton();
                btnBan.Text = item.TableName + Environment.NewLine + item.TableStatus;
                btnBan.Width = 80;
                btnBan.Height = 80;
                btnBan.Margin = new Padding(5);
                btnBan.Appearance.Font = new Font("Tahoma", 9F, FontStyle.Regular);
                btnBan.Tag = item;

                if (item.TableStatus == "Trống")
                    btnBan.Appearance.BackColor = Color.LightGreen;
                else
                    btnBan.Appearance.BackColor = Color.LightPink;

                btnBan.Click += BtnBan_Click;
                flpDanhSachBan.Controls.Add(btnBan);
            }
        }
        // 3. Hàm load danh sách Loại đồ uống
        void LoadCategory()
        {
            List<FoodCategoryDTO> listCategory = FoodCategoryBUS.Instance.GetListCategory();
            ccbdanhmuc.Properties.Items.Clear();
            foreach (var item in listCategory)
            {
                ccbdanhmuc.Properties.Items.Add(item);
            }
        }
        // 4. Hàm load danh sách Đồ uống theo loại
        void LoadFoodListByCategoryID(int categoryID)
        {
            List<FoodDTO> listFood = FoodBUS.Instance.GetFoodByCategoryID(categoryID);
            cbbdouong.Properties.Items.Clear();
            foreach (var item in listFood)
            {
                cbbdouong.Properties.Items.Add(item);
            }
        }
        // 5. Hàm load danh sách Bàn
        void LoadTableCombo()
        {
            List<TableFoodDTO> tableList = TableFoodBUS.Instance.GetListTable();

            cbbBan.Properties.Items.Clear();
            foreach (var item in tableList)
            {
                cbbBan.Properties.Items.Add(item);
            }
        }
        // 6. Hàm load danh sách Voucher
        void LoadVoucherCombo()
        {
            List<VoucherDTO> listVoucher = VoucherDAO.Instance.GetListVoucher();

            lkeVoucher.Properties.DataSource = listVoucher;
            lkeVoucher.Properties.DisplayMember = "VoucherName";
            lkeVoucher.Properties.ValueMember = "VoucherCode";
            lkeVoucher.Properties.NullText = "-- Chọn mã giảm giá --";

            lkeVoucher.Properties.AllowNullInput = DevExpress.Utils.DefaultBoolean.True;
        }
        void LoadSizeCombo()
        {

        }
        // 7. Hàm hiển thị Bill lên giao diện
        void ShowBill(int id)
        {
            System.Data.DataTable dataBill = BillInfoBUS.Instance.GetListBillInfoByTable(id);
            gridControl1.DataSource = dataBill;
            tongTienGoc = 0;
            foreach (System.Data.DataRow row in dataBill.Rows)
            {
                tongTienGoc += Convert.ToDecimal(row["TotalPrice"]);
            }
            TinhTienSauGiamGia();
        }
        // 8. Hàm tính tiền sau khi đã áp dụng voucher
        void TinhTienSauGiamGia()
        {
            decimal tongTienThanhToan = tongTienGoc - tienGiamVoucher;

            if (tongTienThanhToan < 0) tongTienThanhToan = 0;

            txtTongTien.Text = tongTienThanhToan.ToString("c0", new System.Globalization.CultureInfo("vi-VN"));
        }
        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            if (banHienTai == null)
            {
                MessageBox.Show("Vui lòng chọn một bàn để thanh toán!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            int idHoaDon = BillBUS.Instance.GetUncheckBillByTableID(banHienTai.TableID);

            if (idHoaDon != -1)
            {
                decimal tongTienThanhToan = tongTienGoc - tienGiamVoucher;
                if (tongTienThanhToan < 0) tongTienThanhToan = 0;
                double tongTien = (double)tongTienThanhToan;

                frmThanhToan f = new frmThanhToan(idHoaDon, tongTien);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    BillBUS.Instance.CheckOut(idHoaDon, 0);

                    DialogResult hoiIn = MessageBox.Show("Thanh toán thành công. Bạn có muốn in hóa đơn?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                    if (hoiIn == DialogResult.Yes)
                    {
                        try
                        {
                            List<InHoaDonDTO> listMonIn = new List<InHoaDonDTO>();

                            for (int i = 0; i < gridView1.RowCount; i++)
                            {
                                object tenMonObj = gridView1.GetRowCellValue(i, gridView1.VisibleColumns[0]);

                                if (tenMonObj != null && !string.IsNullOrWhiteSpace(tenMonObj.ToString()))
                                {
                                    InHoaDonDTO item = new InHoaDonDTO();

                                    item.TenMon = tenMonObj.ToString();
                                    item.SoLuong = Convert.ToInt32(gridView1.GetRowCellValue(i, gridView1.VisibleColumns[2]) ?? 0);
                                    item.DonGia = Convert.ToDouble(gridView1.GetRowCellValue(i, gridView1.VisibleColumns[3]) ?? 0);
                                    item.ThanhTien = Convert.ToDouble(gridView1.GetRowCellValue(i, gridView1.VisibleColumns[4]) ?? 0);

                                    listMonIn.Add(item);
                                }
                            }
                            rptHoaDon rp = new rptHoaDon();
                            rp.FindControl("lblSoBan", true).Text = banHienTai.TableName;
                            rp.FindControl("lblNgay", true).Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                            rp.FindControl("lblThuNgan", true).Text = "Admin";
                            rp.DataSource = listMonIn;
                            rp.FindControl("cellTenMon", true).DataBindings.Add("Text", listMonIn, "TenMon");
                            rp.FindControl("cellSL", true).DataBindings.Add("Text", listMonIn, "SoLuong");
                            rp.FindControl("cellDonGia", true).DataBindings.Add("Text", listMonIn, "DonGia", "{0:n0}");
                            rp.FindControl("cellThanhTien", true).DataBindings.Add("Text", listMonIn, "ThanhTien", "{0:n0}");

                            double tamTinh = listMonIn.Sum(x => x.ThanhTien);
                            rp.FindControl("lblTamTinh", true).Text = tamTinh.ToString("n0");
                            rp.FindControl("lblGiamGia", true).Text = tienGiamVoucher > 0 ? "-" + tienGiamVoucher.ToString("n0") + " đ" : "0 đ";
                            rp.FindControl("lblTongCong", true).Text = tongTien.ToString("n0") + " đ";

                            using (DevExpress.XtraReports.UI.ReportPrintTool printTool = new DevExpress.XtraReports.UI.ReportPrintTool(rp))
                            {
                                printTool.ShowPreviewDialog();
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Lỗi khi xuất hóa đơn xịn: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    if (!string.IsNullOrEmpty(currentVoucherCode))
                    {
                        VoucherDAO.Instance.UpdateVoucherUsage(currentVoucherCode);
                    }
                    currentVoucherCode = "";
                    tienGiamVoucher = 0;
                    if (lblTienVoucher != null) lblTienVoucher.Text = "0đ";
                    if (lkeVoucher != null) lkeVoucher.EditValue = null;

                    LoadTable();
                    banHienTai = null;
                    lbldangchon.Text = "Đang chọn: ";
                }
            }
        }
        private void BtnBan_Click(object sender, EventArgs e)
        {
            SimpleButton btnBan = sender as SimpleButton;
            banHienTai = btnBan.Tag as TableFoodDTO;
            lbldangchon.Text = "Đang chọn: " + banHienTai.TableName;
            ShowBill(banHienTai.TableID);
        }
        private void ccbdanhmuc_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBoxEdit cb = sender as ComboBoxEdit;
            if (cb.SelectedItem == null) return;
            FoodCategoryDTO selectedCategory = cb.SelectedItem as FoodCategoryDTO;
            LoadFoodListByCategoryID(selectedCategory.CategoryId);
        }
        private void manhinhchinh_Load(object sender, EventArgs e) { }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (banHienTai == null)
            {
                MessageBox.Show("Vui lòng click chọn 1 Bàn trước khi thêm món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (cbbdouong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            FoodDTO monDuocChon = cbbdouong.SelectedItem as FoodDTO;
            if (lkeSize.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn Size đồ uống!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string size = lkeSize.Text;
            float price = float.Parse(lkeSize.EditValue.ToString());

            int soLuong = 1;
            int idBill = BillBUS.Instance.GetUncheckBillByTableID(banHienTai.TableID);
            if (idBill == -1)
            {
                BillBUS.Instance.InsertBill(banHienTai.TableID);
                idBill = BillBUS.Instance.GetMaxIDBill();
            }
            BillInfoBUS.Instance.AddFoodToBill(idBill, monDuocChon.FoodId, soLuong, size);
            ShowBill(banHienTai.TableID);
            LoadTable();
        }

        private void btnChuyenBan_Click(object sender, EventArgs e)
        {
            if (banHienTai == null) return;
            TableFoodDTO banDich = cbbBan.SelectedItem as TableFoodDTO;
            if (banDich == null)
            {
                MessageBox.Show("Vui lòng chọn bàn muốn chuyển tới trong danh sách!", "Thông báo");
                return;
            }

            if (MessageBox.Show($"Bạn có muốn chuyển hóa đơn từ {banHienTai.TableName} sang {banDich.TableName} không?",
                                "Xác nhận chuyển bàn", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                QuanLyQuanCafe.DAO.TableFoodDAO.Instance.SwitchTable(banHienTai.TableID, banDich.TableID);
                LoadTable();
                ShowBill(banHienTai.TableID);
            }
        }

        private void cbbdouong_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbdouong.SelectedItem == null) return;

            FoodDTO food = cbbdouong.SelectedItem as FoodDTO;

            if (food != null)
            {
                LoadSizeByFoodID(food.FoodId);
            }
        }

        private void lkeSize_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void lkeVoucher_EditValueChanged(object sender, EventArgs e)
        {
            // Nếu thu ngân bấm dấu X (hủy mã) hoặc chưa chọn gì
            if (lkeVoucher.EditValue == null || string.IsNullOrEmpty(lkeVoucher.EditValue.ToString()))
            {
                currentVoucherCode = "";
                tienGiamVoucher = 0;
                lblTienVoucher.Text = "0đ";
                TinhTienSauGiamGia();
                return;
            }

            string code = lkeVoucher.EditValue.ToString();
            VoucherDTO voucher = VoucherDAO.Instance.GetVoucherByCode(code);

            if (voucher != null)
            {
                // Kiểm tra đơn tối thiểu
                if ((float)tongTienGoc < voucher.MinBillValue)
                {
                    MessageBox.Show($"Đơn hàng chưa đủ {voucher.MinBillValue.ToString("N0")}đ để áp mã này!", "Chưa đủ điều kiện", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    // Reset cái combo box về trạng thái trống
                    lkeVoucher.EditValue = null;
                    return;
                }

                // Đủ điều kiện thì tính tiền giảm
                if (voucher.DiscountType == 0) tienGiamVoucher = (decimal)voucher.DiscountValue;
                else
                {
                    tienGiamVoucher = tongTienGoc * (decimal)(voucher.DiscountValue / 100);
                    if (voucher.MaxDiscount > 0 && tienGiamVoucher > (decimal)voucher.MaxDiscount)
                        tienGiamVoucher = (decimal)voucher.MaxDiscount;
                }

                // Áp dụng thành công
                currentVoucherCode = code;
                lblTienVoucher.Text = "-" + tienGiamVoucher.ToString("n0") + "đ";
                TinhTienSauGiamGia();
            }
        }
    }
}