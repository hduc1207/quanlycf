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
        public ucOrder()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            LoadTableCombo();
            LoadSizeCombo();
            lkeSize.Properties.NullText = "--Size--";
        }
        void LoadSizeByFoodID(int foodID)
        {
            List<FoodSizeDTO> listSize = FoodSizeDAO.Instance.GetListSizeByFoodID(foodID);

            lkeSize.Properties.DataSource = listSize;
            lkeSize.Properties.DisplayMember = "SizeName";
            lkeSize.Properties.ValueMember = "Price";
            lkeSize.Properties.PopulateColumns();

            if (lkeSize.Properties.Columns.Count > 0)
            {
                // 1. Ẩn 2 cột không cần thiết đi
                lkeSize.Properties.Columns["ID"].Visible = false;
                lkeSize.Properties.Columns["FoodID"].Visible = false;

                // 2. Viết hóa tiêu đề cột cho đẹp
                lkeSize.Properties.Columns["SizeName"].Caption = "Size";
                lkeSize.Properties.Columns["Price"].Caption = "Giá tiền (VNĐ)";

                // 3. Format cột giá tiền cho dễ nhìn (ví dụ: 15,000)
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

        void LoadCategory()
        {
            List<FoodCategoryDTO> listCategory = FoodCategoryBUS.Instance.GetListCategory();
            ccbdanhmuc.Properties.Items.Clear();
            foreach (var item in listCategory)
            {
                ccbdanhmuc.Properties.Items.Add(item);
            }
        }
        void LoadFoodListByCategoryID(int categoryID)
        {
            List<FoodDTO> listFood = FoodBUS.Instance.GetFoodByCategoryID(categoryID);
            cbbdouong.Properties.Items.Clear();
            foreach (var item in listFood)
            {
                cbbdouong.Properties.Items.Add(item);
            }
        }
        // 3. Hàm load danh sách Bàn
        void LoadTableCombo()
        {
            List<TableFoodDTO> tableList = TableFoodBUS.Instance.GetListTable();

            cbbBan.Properties.Items.Clear();
            foreach (var item in tableList)
            {
                cbbBan.Properties.Items.Add(item);
            }
        }
        void LoadSizeCombo()
        {
          
        }
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
        void TinhTienSauGiamGia()
        {
            decimal giamGia = spnGiamGia.Value;
            decimal tongTienThanhToan = tongTienGoc - (tongTienGoc * giamGia / 100);
            txtTongTien.Text = tongTienThanhToan.ToString("c0", new System.Globalization.CultureInfo("vi-VN"));
        }
        private void spinEdit1_EditValueChanged(object sender, EventArgs e)
        {
            TinhTienSauGiamGia();
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
                decimal giamGia = spnGiamGia.Value;
                decimal tongTienThanhToan = tongTienGoc - (tongTienGoc * giamGia / 100);
                double tongTien = (double)tongTienThanhToan;
                frmThanhToan f = new frmThanhToan(idHoaDon, tongTien);

                if (f.ShowDialog() == DialogResult.OK)
                {
                    BillBUS.Instance.CheckOut(idHoaDon, (int)giamGia);
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

                            // Đổ dữ liệu Phần Đầu
                            rp.FindControl("lblSoBan", true).Text = banHienTai.TableName;
                            rp.FindControl("lblNgay", true).Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm");
                            rp.FindControl("lblThuNgan", true).Text = "Admin"; // Hoặc tên tài khoản đăng nhập

                            // Đổ dữ liệu Bảng Món Ăn
                            rp.DataSource = listMonIn;
                            rp.FindControl("cellTenMon", true).DataBindings.Add("Text", listMonIn, "TenMon");
                            rp.FindControl("cellSL", true).DataBindings.Add("Text", listMonIn, "SoLuong");
                            rp.FindControl("cellDonGia", true).DataBindings.Add("Text", listMonIn, "DonGia", "{0:n0}");
                            rp.FindControl("cellThanhTien", true).DataBindings.Add("Text", listMonIn, "ThanhTien", "{0:n0}");

                            // Đổ dữ liệu Phần Cuối
                            double tamTinh = listMonIn.Sum(x => x.ThanhTien);
                            rp.FindControl("lblTamTinh", true).Text = tamTinh.ToString("n0");
                            rp.FindControl("lblGiamGia", true).Text = giamGia.ToString() + " %";
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
        private void labelControl3_Click(object sender, EventArgs e) { }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // 1. Kiểm tra xem đã chọn bàn chưa?
            if (banHienTai == null)
            {
                MessageBox.Show("Vui lòng click chọn 1 Bàn trước khi thêm món!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 2. Kiểm tra xem đã chọn đồ uống chưa?
            if (cbbdouong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món cần thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // 3. Lấy thông tin món
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
            // Thêm món vào BillInfo
            BillInfoBUS.Instance.AddFoodToBill(idBill, monDuocChon.FoodId, soLuong, size);

            // Load lại giao diện
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
    }
}