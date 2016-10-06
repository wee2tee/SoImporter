namespace SoImporter.SubForm
{
    partial class StmasListDialog
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewStmas = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkcod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkDesTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkDesEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSellpr5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStmas)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridViewStmas;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(954, 201);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStmas});
            // 
            // gridViewStmas
            // 
            this.gridViewStmas.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colStkcod,
            this.colStkDesTh,
            this.colStkDesEn,
            this.colSellpr1,
            this.colSellpr2,
            this.colSellpr3,
            this.colSellpr4,
            this.colSellpr5});
            this.gridViewStmas.GridControl = this.gridControl1;
            this.gridViewStmas.Name = "gridViewStmas";
            this.gridViewStmas.OptionsBehavior.Editable = false;
            this.gridViewStmas.OptionsBehavior.FocusLeaveOnTab = true;
            this.gridViewStmas.OptionsBehavior.ReadOnly = true;
            this.gridViewStmas.OptionsNavigation.UseTabKey = false;
            this.gridViewStmas.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewStmas.OptionsView.ShowGroupPanel = false;
            this.gridViewStmas.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewStmas_RowCellClick);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colStkcod
            // 
            this.colStkcod.AppearanceHeader.Options.UseTextOptions = true;
            this.colStkcod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStkcod.Caption = "รหัสสินค้า";
            this.colStkcod.FieldName = "Stkcod";
            this.colStkcod.MaxWidth = 130;
            this.colStkcod.MinWidth = 130;
            this.colStkcod.Name = "colStkcod";
            this.colStkcod.Visible = true;
            this.colStkcod.VisibleIndex = 0;
            this.colStkcod.Width = 130;
            // 
            // colStkDesTh
            // 
            this.colStkDesTh.AppearanceHeader.Options.UseTextOptions = true;
            this.colStkDesTh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStkDesTh.Caption = "รายละเอียด (ไทย)";
            this.colStkDesTh.FieldName = "StkDesTh";
            this.colStkDesTh.MinWidth = 190;
            this.colStkDesTh.Name = "colStkDesTh";
            this.colStkDesTh.Visible = true;
            this.colStkDesTh.VisibleIndex = 1;
            this.colStkDesTh.Width = 190;
            // 
            // colStkDesEn
            // 
            this.colStkDesEn.AppearanceHeader.Options.UseTextOptions = true;
            this.colStkDesEn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colStkDesEn.Caption = "รายละเอียด (Eng.)";
            this.colStkDesEn.FieldName = "StkDesEn";
            this.colStkDesEn.MinWidth = 170;
            this.colStkDesEn.Name = "colStkDesEn";
            this.colStkDesEn.Visible = true;
            this.colStkDesEn.VisibleIndex = 2;
            this.colStkDesEn.Width = 170;
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
            this.colSellpr1.FieldName = "Sellpr1";
            this.colSellpr1.MaxWidth = 80;
            this.colSellpr1.MinWidth = 80;
            this.colSellpr1.Name = "colSellpr1";
            this.colSellpr1.Visible = true;
            this.colSellpr1.VisibleIndex = 3;
            this.colSellpr1.Width = 80;
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
            this.colSellpr2.FieldName = "Sellpr2";
            this.colSellpr2.MaxWidth = 80;
            this.colSellpr2.MinWidth = 80;
            this.colSellpr2.Name = "colSellpr2";
            this.colSellpr2.Visible = true;
            this.colSellpr2.VisibleIndex = 4;
            this.colSellpr2.Width = 80;
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
            this.colSellpr3.FieldName = "Sellpr3";
            this.colSellpr3.MaxWidth = 80;
            this.colSellpr3.MinWidth = 80;
            this.colSellpr3.Name = "colSellpr3";
            this.colSellpr3.Visible = true;
            this.colSellpr3.VisibleIndex = 5;
            this.colSellpr3.Width = 80;
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
            this.colSellpr4.FieldName = "Sellpr4";
            this.colSellpr4.MaxWidth = 80;
            this.colSellpr4.MinWidth = 80;
            this.colSellpr4.Name = "colSellpr4";
            this.colSellpr4.Visible = true;
            this.colSellpr4.VisibleIndex = 6;
            this.colSellpr4.Width = 80;
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
            this.colSellpr5.FieldName = "Sellpr5";
            this.colSellpr5.MaxWidth = 80;
            this.colSellpr5.MinWidth = 80;
            this.colSellpr5.Name = "colSellpr5";
            this.colSellpr5.Visible = true;
            this.colSellpr5.VisibleIndex = 7;
            this.colSellpr5.Width = 80;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 12);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(958, 205);
            this.panelControl1.TabIndex = 1;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(14, 223);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(67, 28);
            this.btnOK.TabIndex = 1;
            this.btnOK.Text = "ตกลง";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(87, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 28);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "ยกเลิก";
            // 
            // StmasListDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(982, 263);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StmasListDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "StmasListDialog";
            this.Load += new System.EventHandler(this.StmasListDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStmas)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStmas;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colStkcod;
        private DevExpress.XtraGrid.Columns.GridColumn colStkDesTh;
        private DevExpress.XtraGrid.Columns.GridColumn colStkDesEn;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr1;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr2;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr3;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr4;
        private DevExpress.XtraGrid.Columns.GridColumn colSellpr5;
    }
}