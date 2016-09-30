namespace SoImporter.SubForm
{
    partial class StpriDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(StpriDialog));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewStpri = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDesCription = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TabPr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Disc1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Disc2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStpri)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridViewStpri;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(755, 241);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewStpri});
            // 
            // gridViewStpri
            // 
            this.gridViewStpri.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colPriceCode,
            this.colDesCription,
            this.col_TabPr,
            this.col_Disc1,
            this.col_Disc2});
            this.gridViewStpri.GridControl = this.gridControl1;
            this.gridViewStpri.Name = "gridViewStpri";
            this.gridViewStpri.OptionsBehavior.Editable = false;
            this.gridViewStpri.OptionsBehavior.ReadOnly = true;
            this.gridViewStpri.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewStpri_RowCellClick);
            this.gridViewStpri.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewStpri_FocusedRowChanged);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colPriceCode
            // 
            this.colPriceCode.AppearanceHeader.Options.UseTextOptions = true;
            this.colPriceCode.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colPriceCode.Caption = "รหัส";
            this.colPriceCode.FieldName = "PriceCode";
            this.colPriceCode.MaxWidth = 100;
            this.colPriceCode.MinWidth = 100;
            this.colPriceCode.Name = "colPriceCode";
            this.colPriceCode.Visible = true;
            this.colPriceCode.VisibleIndex = 0;
            this.colPriceCode.Width = 100;
            // 
            // colDesCription
            // 
            this.colDesCription.Caption = "คำอธิบาย";
            this.colDesCription.FieldName = "Description";
            this.colDesCription.MinWidth = 90;
            this.colDesCription.Name = "colDesCription";
            this.colDesCription.Visible = true;
            this.colDesCription.VisibleIndex = 1;
            this.colDesCription.Width = 90;
            // 
            // col_TabPr
            // 
            this.col_TabPr.AppearanceHeader.Options.UseTextOptions = true;
            this.col_TabPr.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.col_TabPr.Caption = "ใช้ราคาขายที่?";
            this.col_TabPr.FieldName = "_TabPr";
            this.col_TabPr.MaxWidth = 90;
            this.col_TabPr.MinWidth = 90;
            this.col_TabPr.Name = "col_TabPr";
            this.col_TabPr.Visible = true;
            this.col_TabPr.VisibleIndex = 2;
            this.col_TabPr.Width = 90;
            // 
            // col_Disc1
            // 
            this.col_Disc1.AppearanceCell.Options.UseTextOptions = true;
            this.col_Disc1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Disc1.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Disc1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Disc1.Caption = "ส่วนลดตามเป้า";
            this.col_Disc1.FieldName = "_Disc1";
            this.col_Disc1.MaxWidth = 120;
            this.col_Disc1.MinWidth = 120;
            this.col_Disc1.Name = "col_Disc1";
            this.col_Disc1.Visible = true;
            this.col_Disc1.VisibleIndex = 3;
            this.col_Disc1.Width = 120;
            // 
            // col_Disc2
            // 
            this.col_Disc2.AppearanceCell.Options.UseTextOptions = true;
            this.col_Disc2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Disc2.AppearanceHeader.Options.UseTextOptions = true;
            this.col_Disc2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.col_Disc2.Caption = "ส่วนลดตัวแทน ตจว.";
            this.col_Disc2.FieldName = "_Disc2";
            this.col_Disc2.MaxWidth = 120;
            this.col_Disc2.MinWidth = 120;
            this.col_Disc2.Name = "col_Disc2";
            this.col_Disc2.Visible = true;
            this.col_Disc2.VisibleIndex = 4;
            this.col_Disc2.Width = 120;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 47);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(759, 245);
            this.panelControl1.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(573, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(62, 29);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(641, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(62, 29);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(709, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(62, 29);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // StpriDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(783, 304);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "StpriDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ตารางราคา";
            this.Load += new System.EventHandler(this.StpriDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewStpri)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewStpri;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_TabPr;
        private DevExpress.XtraGrid.Columns.GridColumn col_Disc1;
        private DevExpress.XtraGrid.Columns.GridColumn col_Disc2;
        private DevExpress.XtraGrid.Columns.GridColumn colDesCription;
    }
}