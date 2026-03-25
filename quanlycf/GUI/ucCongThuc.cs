using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.GUI
{
    public partial class ucCongThuc : DevExpress.XtraEditors.XtraUserControl
    {
        BindingList<ChiTietCongThuc> danhSachHienThi;

        public ucCongThuc()
        {
            InitializeComponent();
            lkDanhMuc.EditValueChanged += lkeDanhMuc_EditValueChanged;
            lkDoUong.EditValueChanged += lkDoUong_EditValueChanged;
            LoadDanhMuc();
        }

        void LoadDanhMuc()
        {
            lkDanhMuc.Properties.DataSource = FoodCategoryBUS.Instance.GetListCategory();
            lkDanhMuc.Properties.DisplayMember = "CategoryName";
            lkDanhMuc.Properties.ValueMember = "CategoryId";

            lkDanhMuc.Properties.NullText = "-- Chọn danh mục --";
        }

        private void lkeDanhMuc_EditValueChanged(object sender, EventArgs e)
        {
            if (lkDanhMuc.EditValue == null) return;

            int categoryId = Convert.ToInt32(lkDanhMuc.EditValue);

            List<FoodDTO> listFood = FoodBUS.Instance.GetListFood();
            var filteredFoods = listFood.Where(f => f.CategoryId == categoryId).ToList();

            var danhSachMonAn = filteredFoods.Select(f => new
            {
                FoodId = f.FoodId,
                TenHienThi = string.IsNullOrEmpty(f.Size) ? f.FoodName : $"{f.FoodName} (Size {f.Size})"
            }).ToList();

            lkDoUong.Properties.DataSource = danhSachMonAn;
            lkDoUong.Properties.DisplayMember = "TenHienThi";
            lkDoUong.Properties.ValueMember = "FoodId";
            lkDoUong.Properties.NullText = "-- Chọn đồ uống --";
        }

        private void lkDoUong_EditValueChanged(object sender, EventArgs e)
        {
            if (lkDoUong.EditValue != null)
            {
                int foodId = Convert.ToInt32(lkDoUong.EditValue);
                List<FoodDTO> listFood = FoodBUS.Instance.GetListFood();
                FoodDTO monDaChon = listFood.FirstOrDefault(f => f.FoodId == foodId);
                string size = (monDaChon != null && monDaChon.Size != null) ? monDaChon.Size : "";

                LoadBangNguyenLieu(foodId, size);
            }
        }

        void LoadBangNguyenLieu(int foodId, string size)
        {
            List<ChiTietCongThuc> listTemp = new List<ChiTietCongThuc>();
            DataTable dtKho = IngredientBUS.Instance.GetListIngredient();
            DataTable dtRecipe = RecipeBUS.Instance.GetRecipeByFood(foodId, size);

            foreach (DataRow row in dtKho.Rows)
            {
                int ingId = Convert.ToInt32(row["IngredientId"]);
                DataRow[] foundRows = dtRecipe.Select("IngredientId = " + ingId);

                ChiTietCongThuc chiTiet = new ChiTietCongThuc();
                chiTiet.IngredientId = ingId;
                chiTiet.TenNguyenLieu = row["IngredientName"].ToString();
                chiTiet.DonVi = row["Unit"].ToString();

                if (foundRows.Length > 0)
                {
                    DataRow rRow = foundRows[0];
                    chiTiet.Chon = true;
                    chiTiet.RecipeId = Convert.ToInt32(rRow["RecipeId"]);
                    chiTiet.Amount = Convert.ToDouble(rRow["Amount"]);
                }
                else
                {
                    chiTiet.Chon = false;
                    chiTiet.RecipeId = 0;
                    chiTiet.Amount = 0;
                }
                listTemp.Add(chiTiet);
            }

            var sortedList = listTemp.OrderByDescending(x => x.Chon).ThenBy(x => x.TenNguyenLieu).ToList();

            danhSachHienThi = new BindingList<ChiTietCongThuc>(sortedList);
            gridControl1.DataSource = danhSachHienThi;

            if (gridView1.Columns["TenNguyenLieu"] != null)
            {
                gridView1.Columns["TenNguyenLieu"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["DonVi"].OptionsColumn.AllowEdit = false;
                gridView1.Columns["IngredientId"].Visible = false;
                gridView1.Columns["RecipeId"].Visible = false;
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (lkDoUong.EditValue == null)
            {
                MessageBox.Show("Vui lòng chọn món đồ uống trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int foodId = Convert.ToInt32(lkDoUong.EditValue);
            List<FoodDTO> listFood = FoodBUS.Instance.GetListFood();
            FoodDTO monDaChon = listFood.FirstOrDefault(f => f.FoodId == foodId);
            string size = (monDaChon != null && monDaChon.Size != null) ? monDaChon.Size : "";

            gridView1.CloseEditor();
            gridView1.UpdateCurrentRow();

            foreach (var item in danhSachHienThi)
            {
                if (item.Chon == true && item.RecipeId == 0)
                {
                    RecipeBUS.Instance.InsertRecipe(foodId, item.IngredientId, item.Amount, size);
                }
                else if (item.Chon == true && item.RecipeId != 0)
                {
                    RecipeBUS.Instance.UpdateRecipe(item.RecipeId, foodId, item.IngredientId, item.Amount, size);
                }
                else if (item.Chon == false && item.RecipeId != 0)
                {
                    RecipeBUS.Instance.DeleteRecipe(item.RecipeId);
                }
            }

            MessageBox.Show("Lưu công thức thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            LoadBangNguyenLieu(foodId, size);
        }
    }

    public class ChiTietCongThuc
    {
        public bool Chon { get; set; }
        public int RecipeId { get; set; }
        public int IngredientId { get; set; }
        public string TenNguyenLieu { get; set; }
        public string DonVi { get; set; }
        public double Amount { get; set; }
    }
}