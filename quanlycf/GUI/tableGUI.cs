using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.GUI
{
    public partial class tableGUI : DevExpress.XtraEditors.XtraUserControl
    {
        public tableGUI()
        {
            InitializeComponent();
            LoadTableList();
        }

        // 1. Hàm đổ dữ liệu Bàn
        void LoadTableList()
        {
            List<TableFoodDTO> listTable = TableFoodBUS.Instance.GetListTable();
            gridControl1.DataSource = new BindingList<TableFoodDTO>(listTable);
            gridView1.Columns["TableID"].OptionsColumn.AllowEdit = false;
            gridView1.Columns["TableStatus"].OptionsColumn.AllowEdit = false;
        }

        // 2. Nút Refresh
        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LoadTableList();
        }

        // 3. Nút Xóa
        private void btnXoa_Click(object sender, EventArgs e)
        {
            TableFoodDTO selectedTable = gridView1.GetFocusedRow() as TableFoodDTO;

            if (selectedTable != null && selectedTable.TableID != 0)
            {
                if (selectedTable.TableStatus == "Có người")
                {
                    MessageBox.Show("Không thể xóa bàn đang có khách ngồi!", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                if (MessageBox.Show($"Bạn có chắc chắn muốn xóa: {selectedTable.TableName}?",
                                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        if (TableFoodBUS.Instance.DeleteTable(selectedTable.TableID))
                        {
                            LoadTableList();
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Xóa bàn thất bại! Bàn này có thể đã từng có hóa đơn.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một bàn để xóa!", "Thông báo");
            }
        }
        private void gridView1_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            TableFoodDTO table = e.Row as TableFoodDTO;
            if (table == null) return;

            if (table.TableID == 0)
            {
                if (TableFoodBUS.Instance.InsertTable(table.TableName))
                {
                    LoadTableList();
                }
                else
                {
                    MessageBox.Show("Thêm bàn thất bại!", "Lỗi");
                }
            }
            else
            {
                if (!TableFoodBUS.Instance.UpdateTable(table.TableID, table.TableName))
                {
                    MessageBox.Show("Sửa tên bàn thất bại!", "Lỗi");
                }
            }
        }
        private void panelControl1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}