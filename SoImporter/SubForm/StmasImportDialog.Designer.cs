namespace SoImporter.SubForm
{
    partial class StmasImportDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewStmas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colStkCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkdes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkdes2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnBeginImport = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.lblStmasPath = new DevExpress.XtraEditors.LabelControl();
            this.lblTotalSelected = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStmas)).BeginInit();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 34);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1092, 307);
            this.panelControl1.TabIndex = 0;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridViewStmas;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1088, 303);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStmas});
            // 
            // gridViewStmas
            // 
            this.gridViewStmas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colStkCod,
            this.colStkdes,
            this.colStkdes2,
            this.colSellpr1,
            this.colSellpr2,
            this.colSellpr3,
            this.colSellpr4,
            this.colSellpr5});
            this.gridViewStmas.GridControl = this.gridControl1;
            this.gridViewStmas.Name = "gridViewStmas";
            this.gridViewStmas.OptionsBehavior.Editable = false;
            this.gridViewStmas.OptionsBehavior.ReadOnly = true;
            this.gridViewStmas.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewStmas.OptionsSelection.MultiSelect = true;
            this.gridViewStmas.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewStmas.OptionsView.ShowGroupPanel = false;
            this.gridViewStmas.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewStmas_SelectionChanged);
            // 
            // colStkCod
            // 
            this.colStkCod.AppearanceHeader.Options.UseTextOptions = true;
            this.colStkCod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStkCod.Caption = "รหัสสินค้า";
            this.colStkCod.FieldName = "stkcod";
            this.colStkCod.MaxWidth = 140;
            this.colStkCod.MinWidth = 140;
            this.colStkCod.Name = "colStkCod";
            this.colStkCod.Visible = true;
            this.colStkCod.VisibleIndex = 1;
            this.colStkCod.Width = 140;
            // 
            // colStkdes
            // 
            this.colStkdes.AppearanceHeader.Options.UseTextOptions = true;
            this.colStkdes.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStkdes.Caption = "ชื่อไทย";
            this.colStkdes.FieldName = "stkdes";
            this.colStkdes.MinWidth = 100;
            this.colStkdes.Name = "colStkdes";
            this.colStkdes.Visible = true;
            this.colStkdes.VisibleIndex = 2;
            this.colStkdes.Width = 250;
            // 
            // colStkdes2
            // 
            this.colStkdes2.AppearanceHeader.Options.UseTextOptions = true;
            this.colStkdes2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStkdes2.Caption = "ชื่ออังกฤษ";
            this.colStkdes2.FieldName = "stkdes2";
            this.colStkdes2.MinWidth = 100;
            this.colStkdes2.Name = "colStkdes2";
            this.colStkdes2.Visible = true;
            this.colStkdes2.VisibleIndex = 3;
            this.colStkdes2.Width = 240;
            // 
            // colSellpr1
            // 
            this.colSellpr1.AppearanceCell.Options.UseTextOptions = true;
            this.colSellpr1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr1.AppearanceHeader.Options.UseTextOptions = true;
            this.colSellpr1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr1.Caption = "ราคาขายที่ 1";
            this.colSellpr1.DisplayFormat.FormatString = "#,#0.00";
            this.colSellpr1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellpr1.FieldName = "sellpr1";
            this.colSellpr1.MaxWidth = 90;
            this.colSellpr1.MinWidth = 90;
            this.colSellpr1.Name = "colSellpr1";
            this.colSellpr1.Visible = true;
            this.colSellpr1.VisibleIndex = 4;
            this.colSellpr1.Width = 90;
            // 
            // colSellpr2
            // 
            this.colSellpr2.AppearanceCell.Options.UseTextOptions = true;
            this.colSellpr2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr2.AppearanceHeader.Options.UseTextOptions = true;
            this.colSellpr2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr2.Caption = "ราคาขายที่ 2";
            this.colSellpr2.DisplayFormat.FormatString = "#,#0.00";
            this.colSellpr2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellpr2.FieldName = "sellpr2";
            this.colSellpr2.MaxWidth = 90;
            this.colSellpr2.MinWidth = 90;
            this.colSellpr2.Name = "colSellpr2";
            this.colSellpr2.Visible = true;
            this.colSellpr2.VisibleIndex = 5;
            this.colSellpr2.Width = 90;
            // 
            // colSellpr3
            // 
            this.colSellpr3.AppearanceCell.Options.UseTextOptions = true;
            this.colSellpr3.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr3.AppearanceHeader.Options.UseTextOptions = true;
            this.colSellpr3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr3.Caption = "ราคาขายที่ 3";
            this.colSellpr3.DisplayFormat.FormatString = "#,#0.00";
            this.colSellpr3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellpr3.FieldName = "sellpr3";
            this.colSellpr3.MaxWidth = 90;
            this.colSellpr3.MinWidth = 90;
            this.colSellpr3.Name = "colSellpr3";
            this.colSellpr3.Visible = true;
            this.colSellpr3.VisibleIndex = 6;
            this.colSellpr3.Width = 90;
            // 
            // colSellpr4
            // 
            this.colSellpr4.AppearanceCell.Options.UseTextOptions = true;
            this.colSellpr4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr4.AppearanceHeader.Options.UseTextOptions = true;
            this.colSellpr4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr4.Caption = "ราคาขายที่ 4";
            this.colSellpr4.DisplayFormat.FormatString = "#,#0.00";
            this.colSellpr4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellpr4.FieldName = "sellpr4";
            this.colSellpr4.MaxWidth = 90;
            this.colSellpr4.MinWidth = 90;
            this.colSellpr4.Name = "colSellpr4";
            this.colSellpr4.Visible = true;
            this.colSellpr4.VisibleIndex = 7;
            this.colSellpr4.Width = 90;
            // 
            // colSellpr5
            // 
            this.colSellpr5.AppearanceCell.Options.UseTextOptions = true;
            this.colSellpr5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr5.AppearanceHeader.Options.UseTextOptions = true;
            this.colSellpr5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.colSellpr5.Caption = "ราคาขายที่ 5";
            this.colSellpr5.DisplayFormat.FormatString = "#,#0.00";
            this.colSellpr5.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colSellpr5.FieldName = "sellpr5";
            this.colSellpr5.MaxWidth = 90;
            this.colSellpr5.MinWidth = 90;
            this.colSellpr5.Name = "colSellpr5";
            this.colSellpr5.Visible = true;
            this.colSellpr5.VisibleIndex = 8;
            this.colSellpr5.Width = 90;
            // 
            // btnBeginImport
            // 
            this.btnBeginImport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnBeginImport.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnBeginImport.Appearance.Options.UseFont = true;
            this.btnBeginImport.Location = new System.Drawing.Point(12, 347);
            this.btnBeginImport.Name = "btnBeginImport";
            this.btnBeginImport.Size = new System.Drawing.Size(99, 35);
            this.btnBeginImport.TabIndex = 1;
            this.btnBeginImport.Text = "เริ่มนำเข้าข้อมูล";
            this.btnBeginImport.Click += new System.EventHandler(this.btnBeginImport_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Location = new System.Drawing.Point(16, 10);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(94, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "นำเข้าข้อมูลจาก :";
            // 
            // lblStmasPath
            // 
            this.lblStmasPath.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblStmasPath.Location = new System.Drawing.Point(116, 10);
            this.lblStmasPath.Name = "lblStmasPath";
            this.lblStmasPath.Size = new System.Drawing.Size(68, 16);
            this.lblStmasPath.TabIndex = 2;
            this.lblStmasPath.Text = "Stmas_Path";
            // 
            // lblTotalSelected
            // 
            this.lblTotalSelected.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTotalSelected.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblTotalSelected.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.lblTotalSelected.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblTotalSelected.Location = new System.Drawing.Point(908, 10);
            this.lblTotalSelected.Name = "lblTotalSelected";
            this.lblTotalSelected.Size = new System.Drawing.Size(193, 16);
            this.lblTotalSelected.TabIndex = 2;
            this.lblTotalSelected.Text = "[รายการที่เลือก : 0/0]";
            // 
            // StmasImportDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 394);
            this.Controls.Add(this.lblTotalSelected);
            this.Controls.Add(this.lblStmasPath);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.btnBeginImport);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(570, 230);
            this.Name = "StmasImportDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "นำเข้าข้อมูลจาก Express";
            this.Load += new System.EventHandler(this.StmasImportDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStmas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStmas;
        private DevExpress.XtraEditors.SimpleButton btnBeginImport;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn colStkCod;
        private DevExpress.XtraGrid.Columns.GridColumn colStkdes;
        private DevExpress.XtraGrid.Columns.GridColumn colStkdes2;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr1;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr2;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr3;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr4;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr5;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.LabelControl lblStmasPath;
        private DevExpress.XtraEditors.LabelControl lblTotalSelected;
    }
}