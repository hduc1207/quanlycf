namespace quanlycf.GUI
{
    partial class ucThucDon
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ucThucDon));
            gridControl1 = new DevExpress.XtraGrid.GridControl();
            gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            panelControl1 = new DevExpress.XtraEditors.PanelControl();
            simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)gridControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).BeginInit();
            panelControl1.SuspendLayout();
            SuspendLayout();
            // 
            // gridControl1
            // 
            gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridControl1.Location = new System.Drawing.Point(0, 40);
            gridControl1.MainView = gridView1;
            gridControl1.Name = "gridControl1";
            gridControl1.Size = new System.Drawing.Size(1200, 660);
            gridControl1.TabIndex = 3;
            gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] { gridView1 });
            // 
            // gridView1
            // 
            gridView1.GridControl = gridControl1;
            gridView1.Name = "gridView1";
            gridView1.OptionsFind.AlwaysVisible = true;
            gridView1.OptionsView.NewItemRowPosition = DevExpress.XtraGrid.Views.Grid.NewItemRowPosition.Top;
            gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // panelControl1
            // 
            panelControl1.Controls.Add(simpleButton2);
            panelControl1.Controls.Add(simpleButton1);
            panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            panelControl1.Location = new System.Drawing.Point(0, 0);
            panelControl1.Name = "panelControl1";
            panelControl1.Size = new System.Drawing.Size(1200, 40);
            panelControl1.TabIndex = 2;
            // 
            // simpleButton2
            // 
            simpleButton2.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton2.ImageOptions.SvgImage");
            simpleButton2.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            simpleButton2.Location = new System.Drawing.Point(96, 11);
            simpleButton2.Name = "simpleButton2";
            simpleButton2.Size = new System.Drawing.Size(80, 20);
            simpleButton2.TabIndex = 1;
            simpleButton2.Text = "Refresh";
            // 
            // simpleButton1
            // 
            simpleButton1.ImageOptions.SvgImage = (DevExpress.Utils.Svg.SvgImage)resources.GetObject("simpleButton1.ImageOptions.SvgImage");
            simpleButton1.ImageOptions.SvgImageSize = new System.Drawing.Size(15, 15);
            simpleButton1.Location = new System.Drawing.Point(10, 11);
            simpleButton1.Name = "simpleButton1";
            simpleButton1.Size = new System.Drawing.Size(80, 20);
            simpleButton1.TabIndex = 0;
            simpleButton1.Text = "Xóa";
            // 
            // ucThucDon
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(gridControl1);
            Controls.Add(panelControl1);
            Name = "ucThucDon";
            Size = new System.Drawing.Size(1200, 700);
            ((System.ComponentModel.ISupportInitialize)gridControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)gridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)panelControl1).EndInit();
            panelControl1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
    }
}
