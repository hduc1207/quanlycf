using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.GUI
{
    public partial class manhinhchinh : DevExpress.XtraEditors.XtraUserControl
    {
        private TableFoodDTO banHienTai = null;
        private decimal tongTienGoc = 0;
        public manhinhchinh()
        {
            InitializeComponent();
            LoadTable();
            LoadCategory();
            LoadTableCombo();
            LoadSizeCombo();
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
            cbbSIze.Properties.Items.Clear();
            cbbSIze.Properties.Items.Add("S");
            cbbSIze.Properties.Items.Add("M");
            cbbSIze.Properties.Items.Add("L");
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
            if (banHienTai == null) return;
            int idBill = BillBUS.Instance.GetUncheckBillByTableID(banHienTai.TableID);
            int giamGia = (int)spnGiamGia.Value;

            if (idBill != -1)
            {
                if (MessageBox.Show($"Bạn có chắc thanh toán hóa đơn cho {banHienTai.TableName}?\nTổng tiền cần thu: {txtTongTien.Text}",
                                    "Xác nhận thanh toán", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
                {
                    BillBUS.Instance.CheckOut(idBill, giamGia);
                    IngredientBUS.Instance.TruNguyenLieuTuHoaDon(idBill);
                    ShowBill(banHienTai.TableID);
                    LoadTable();
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
                MessageBox.Show("Vui lòng click chọn 1 Bàn trước khi thêm món!", "Thông báo");
                return;
            }

            // 2. Kiểm tra xem đã chọn đồ uống chưa?
            if (cbbdouong.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng chọn món cần thêm!", "Thông báo");
                return;
            }

            // 3. Lấy thông tin món và size
            FoodDTO monDuocChon = cbbdouong.SelectedItem as FoodDTO;
            string size = cbbSIze.SelectedItem != null ? cbbSIze.SelectedItem.ToString() : "M";
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
    }
}