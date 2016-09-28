namespace SoImporter.SubForm
{
    partial class DealerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DealerDialog));
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewDealer = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DealerType = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSerNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_FullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_Addr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_TelAndFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPriceCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_DlvProfile = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDealer)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridViewDealer;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1159, 401);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDealer});
            // 
            // gridViewDealer
            // 
            this.gridViewDealer.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDealerCode,
            this.col_DealerType,
            this.colSerNum,
            this.col_FullName,
            this.col_Addr,
            this.colTaxId,
            this.col_TelAndFax,
            this.colEmail,
            this.colPriceCode,
            this.col_DlvProfile,
            this.colStatus});
            this.gridViewDealer.GridControl = this.gridControl1;
            this.gridViewDealer.Name = "gridViewDealer";
            this.gridViewDealer.OptionsBehavior.Editable = false;
            this.gridViewDealer.OptionsBehavior.ReadOnly = true;
            this.gridViewDealer.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDealer_FocusedRowChanged);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colDealerCode
            // 
            this.colDealerCode.Caption = "รหัสตัวแทนฯ";
            this.colDealerCode.FieldName = "DealerCode";
            this.colDealerCode.MaxWidth = 90;
            this.colDealerCode.MinWidth = 90;
            this.colDealerCode.Name = "colDealerCode";
            this.colDealerCode.Visible = true;
            this.colDealerCode.VisibleIndex = 0;
            this.colDealerCode.Width = 90;
            // 
            // col_DealerType
            // 
            this.col_DealerType.Caption = "ประเภทตัวแทนฯ";
            this.col_DealerType.FieldName = "_DealerType";
            this.col_DealerType.MaxWidth = 120;
            this.col_DealerType.MinWidth = 120;
            this.col_DealerType.Name = "col_DealerType";
            this.col_DealerType.Visible = true;
            this.col_DealerType.VisibleIndex = 1;
            this.col_DealerType.Width = 120;
            // 
            // colSerNum
            // 
            this.colSerNum.Caption = "S/N";
            this.colSerNum.FieldName = "SerNum";
            this.colSerNum.MaxWidth = 90;
            this.colSerNum.MinWidth = 90;
            this.colSerNum.Name = "colSerNum";
            this.colSerNum.Visible = true;
            this.colSerNum.VisibleIndex = 2;
            this.colSerNum.Width = 90;
            // 
            // col_FullName
            // 
            this.col_FullName.Caption = "ชื่อ";
            this.col_FullName.FieldName = "_FullName";
            this.col_FullName.MinWidth = 130;
            this.col_FullName.Name = "col_FullName";
            this.col_FullName.Visible = true;
            this.col_FullName.VisibleIndex = 3;
            this.col_FullName.Width = 130;
            // 
            // col_Addr
            // 
            this.col_Addr.Caption = "ที่อยู่";
            this.col_Addr.FieldName = "_Addr";
            this.col_Addr.MinWidth = 170;
            this.col_Addr.Name = "col_Addr";
            this.col_Addr.Visible = true;
            this.col_Addr.VisibleIndex = 4;
            this.col_Addr.Width = 170;
            // 
            // colTaxId
            // 
            this.colTaxId.Caption = "เลขประจำตัวผู้เสียภาษี";
            this.colTaxId.FieldName = "TaxId";
            this.colTaxId.MaxWidth = 110;
            this.colTaxId.MinWidth = 110;
            this.colTaxId.Name = "colTaxId";
            this.colTaxId.Visible = true;
            this.colTaxId.VisibleIndex = 5;
            this.colTaxId.Width = 110;
            // 
            // col_TelAndFax
            // 
            this.col_TelAndFax.Caption = "โทรศัพท์/โทรสาร(Fax.)";
            this.col_TelAndFax.FieldName = "_TelAndFax";
            this.col_TelAndFax.MinWidth = 110;
            this.col_TelAndFax.Name = "col_TelAndFax";
            this.col_TelAndFax.Visible = true;
            this.col_TelAndFax.VisibleIndex = 6;
            this.col_TelAndFax.Width = 110;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "อีเมล์";
            this.colEmail.FieldName = "UserName";
            this.colEmail.MinWidth = 110;
            this.colEmail.Name = "colEmail";
            this.colEmail.Visible = true;
            this.colEmail.VisibleIndex = 7;
            this.colEmail.Width = 110;
            // 
            // colPriceCode
            // 
            this.colPriceCode.Caption = "ตารางราคา";
            this.colPriceCode.FieldName = "PriceCode";
            this.colPriceCode.MaxWidth = 80;
            this.colPriceCode.MinWidth = 80;
            this.colPriceCode.Name = "colPriceCode";
            this.colPriceCode.Visible = true;
            this.colPriceCode.VisibleIndex = 8;
            this.colPriceCode.Width = 80;
            // 
            // col_DlvProfile
            // 
            this.col_DlvProfile.Caption = "กลุ่มวิธีการจัดส่ง";
            this.col_DlvProfile.FieldName = "_DlvProfile";
            this.col_DlvProfile.MaxWidth = 80;
            this.col_DlvProfile.MinWidth = 80;
            this.col_DlvProfile.Name = "col_DlvProfile";
            this.col_DlvProfile.Visible = true;
            this.col_DlvProfile.VisibleIndex = 9;
            this.col_DlvProfile.Width = 80;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "สถานะ";
            this.colStatus.FieldName = "Status";
            this.colStatus.MaxWidth = 40;
            this.colStatus.MinWidth = 40;
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 10;
            this.colStatus.Width = 40;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 45);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(1163, 405);
            this.panelControl1.TabIndex = 1;
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(1020, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(153, 27);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "ดูรายละเอียด / แก้ไข";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // DealerDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1187, 462);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DealerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ตัวแทนจำหน่าย";
            this.Load += new System.EventHandler(this.DealerDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDealer)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDealer;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colDealerCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_DealerType;
        private DevExpress.XtraGrid.Columns.GridColumn colSerNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_FullName;
        private DevExpress.XtraGrid.Columns.GridColumn col_Addr;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxId;
        private DevExpress.XtraGrid.Columns.GridColumn col_TelAndFax;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colPriceCode;
        private DevExpress.XtraGrid.Columns.GridColumn col_DlvProfile;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
    }
}