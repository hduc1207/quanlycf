namespace QuanLyQuanCafe.GUI
{
    partial class ucCongThuc
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            labelControl2 = new DevExpress.XtraEditors.LabelControl();
            lkDanhMuc = new DevExpress.XtraEditors.LookUpEdit();
            btnLuu = new DevExpress.XtraEditors.SimpleButton();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            lkDoUong = new DevExpress.XtraEditors.LookUpEdit();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)lkDanhMuc.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)lkDoUong.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(labelControl2);
            panelControl1.Controls.Add(lkDanhMuc);
            panelControl1.Controls.Add(btnLuu);
            panelControl1.Controls.Add(labelControl1);
            panelControl1.Controls.Add(lkDoUong);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            panelControl1.Location = new System.Drawing.Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(1200, 77);
            panelControl1.TabIndex = 0;
            // 
            // labelControl2
            // 
            labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl2.Appearance.Options.UseFont = true;
            labelControl2.Location = new System.Drawing.Point(44, 13);
            labelControl2.Name = "labelControl2";
            labelControl2.Size = new System.Drawing.Size(108, 18);
            labelControl2.TabIndex = 2;
            labelControl2.Text = "Chọn danh mục:";
            // 
            // lkDanhMuc
            // 
            lkDanhMuc.Location = new System.Drawing.Point(158, 12);
            lkDanhMuc.Name = "lkDanhMuc";
            lkDanhMuc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkDanhMuc.Size = new System.Drawing.Size(156, 23);
            lkDanhMuc.TabIndex = 3;
            lkDanhMuc.EditValueChanged += lkeDanhMuc_EditValueChanged;
            // 
            // btnLuu
            // 
            btnLuu.Location = new System.Drawing.Point(358, 15);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new System.Drawing.Size(118, 45);
            btnLuu.TabIndex = 2;
            btnLuu.Text = "Lưu công thức";
            btnLuu.Click += btnLuu_Click;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(44, 42);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(72, 18);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Chọn món:";
            // 
            // lkDoUong
            // 
            lkDoUong.Location = new System.Drawing.Point(158, 41);
            lkDoUong.Name = "lkDoUong";
            lkDoUong.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            lkDoUong.Size = new System.Drawing.Size(156, 23);
            lkDoUong.TabIndex = 0;
            lkDoUong.EditValueChanged += lkDoUong_EditValueChanged;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 77);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(1200, 623);
            gridControl1.TabIndex = 1;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // ucCongThuc
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(panelControl1);
            Name = "ucCongThuc";
            Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)lkDanhMuc.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)lkDoUong.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LookUpEdit lkDoUong;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LookUpEdit lkDanhMuc;
        private DevExpress.XtraEditors.SimpleButton btnLuu;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}
