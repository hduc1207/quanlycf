namespace QuanLyQuanCafe.GUI
{
    partial class ucThuNhap
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
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            btnLoc = new DevExpress.XtraEditors.SimpleButton();
            dtpDenNgay = new DevExpress.XtraEditors.DateEdit();
            dtpTuNgay = new DevExpress.XtraEditors.DateEdit();
            panelControl2 = new DevExpress.XtraEditors.PanelControl();
            labelControl1 = new DevExpress.XtraEditors.LabelControl();
            txtTongThu = new DevExpress.XtraEditors.TextEdit();
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            lblThatThoat = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dtpDenNgay.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpDenNgay.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpTuNgay.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dtpTuNgay.Properties.CalendarTimeProperties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).BeginInit();
            panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)txtTongThu.Properties).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            SuspendLayout();
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(label2);
            panelControl1.Controls.Add(label1);
            panelControl1.Controls.Add(btnLoc);
            panelControl1.Controls.Add(dtpDenNgay);
            panelControl1.Controls.Add(dtpTuNgay);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            panelControl1.Location = new System.Drawing.Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(1200, 64);
            panelControl1.TabIndex = 0;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(280, 24);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(66, 16);
            label2.TabIndex = 4;
            label2.Text = "Đến ngày:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(44, 24);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(59, 16);
            label1.TabIndex = 3;
            label1.Text = "Từ ngày:";
            // 
            // btnLoc
            // 
            btnLoc.Location = new System.Drawing.Point(539, 14);
            btnLoc.Name = "btnLoc";
            btnLoc.Size = new System.Drawing.Size(118, 36);
            btnLoc.TabIndex = 2;
            btnLoc.Text = "Lọc";
            // 
            // dtpDenNgay
            // 
            dtpDenNgay.EditValue = null;
            dtpDenNgay.Location = new System.Drawing.Point(351, 21);
            dtpDenNgay.Name = "dtpDenNgay";
            dtpDenNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtpDenNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtpDenNgay.Size = new System.Drawing.Size(156, 23);
            dtpDenNgay.TabIndex = 1;
            // 
            // dtpTuNgay
            // 
            dtpTuNgay.EditValue = null;
            dtpTuNgay.Location = new System.Drawing.Point(109, 21);
            dtpTuNgay.Name = "dtpTuNgay";
            dtpTuNgay.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtpTuNgay.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] { new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo) });
            dtpTuNgay.Size = new System.Drawing.Size(156, 23);
            dtpTuNgay.TabIndex = 0;
            // 
            // panelControl2
            // 
            panelControl2.Controls.Add(lblThatThoat);
            panelControl2.Controls.Add(labelControl1);
            panelControl2.Controls.Add(txtTongThu);
            panelControl2.Dock = System.Windows.Forms.DockStyle.Bottom;
            panelControl2.Location = new System.Drawing.Point(0, 622);
            panelControl2.Name = "panelControl2";
            panelControl2.Size = new System.Drawing.Size(1200, 78);
            panelControl2.TabIndex = 1;
            // 
            // labelControl1
            // 
            labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            labelControl1.Appearance.Options.UseFont = true;
            labelControl1.Location = new System.Drawing.Point(794, 35);
            labelControl1.Name = "labelControl1";
            labelControl1.Size = new System.Drawing.Size(65, 18);
            labelControl1.TabIndex = 1;
            labelControl1.Text = "Tổng thu:";
            // 
            // txtTongThu
            // 
            txtTongThu.Location = new System.Drawing.Point(874, 34);
            txtTongThu.Name = "txtTongThu";
            txtTongThu.Size = new System.Drawing.Size(212, 23);
            txtTongThu.TabIndex = 0;
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 64);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(1200, 558);
            gridControl1.TabIndex = 2;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // lblThatThoat
            // 
            lblThatThoat.Appearance.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            lblThatThoat.Appearance.ForeColor = System.Drawing.Color.Red;
            lblThatThoat.Appearance.Options.UseFont = true;
            lblThatThoat.Appearance.Options.UseForeColor = true;
            lblThatThoat.Location = new System.Drawing.Point(874, 12);
            lblThatThoat.Name = "lblThatThoat";
            lblThatThoat.Size = new System.Drawing.Size(20, 16);
            lblThatThoat.TabIndex = 2;
            lblThatThoat.Text = "0 đ";
            // 
            // ucThuNhap
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(panelControl2);
            Controls.Add(panelControl1);
            Name = "ucThuNhap";
            Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            panelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dtpDenNgay.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpDenNgay.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpTuNgay.Properties.CalendarTimeProperties).EndInit();
            ((System.ComponentModel.ISupportInitialize)dtpTuNgay.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl2).EndInit();
            panelControl2.ResumeLayout(false);
            panelControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)txtTongThu.Properties).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnLoc;
        private DevExpress.XtraEditors.DateEdit dtpDenNgay;
        private DevExpress.XtraEditors.DateEdit dtpTuNgay;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTongThu;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.LabelControl lblThatThoat;
    }
}
