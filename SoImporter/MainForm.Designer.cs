﻿namespace SoImporter
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.btnImport = new DevExpress.XtraBars.BarButtonItem();
            this.btnRecSO = new DevExpress.XtraBars.BarButtonItem();
            this.btnDataPath = new DevExpress.XtraBars.BarButtonItem();
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.lblDataPath = new DevExpress.XtraBars.BarStaticItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.btnUsers = new DevExpress.XtraBars.BarButtonItem();
            this.btnApiUrl = new DevExpress.XtraBars.BarButtonItem();
            this.btnRetrieveData = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDealerCode = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustAddr01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustTaxId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustTelNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrdQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrnVal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVatAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            this.colDlvDat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvDat2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkDes = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 425);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1210, 31);
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.btnImport,
            this.btnRecSO,
            this.btnDataPath,
            this.barStaticItem1,
            this.lblDataPath,
            this.barButtonItem1,
            this.btnUsers,
            this.btnApiUrl,
            this.btnRetrieveData});
            this.ribbonControl1.Location = new System.Drawing.Point(0, 0);
            this.ribbonControl1.MaxItemId = 16;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemTextEdit1,
            this.repositoryItemTextEdit2,
            this.repositoryItemTextEdit3});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2010;
            this.ribbonControl1.Size = new System.Drawing.Size(1210, 143);
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            // 
            // btnImport
            // 
            this.btnImport.Caption = "นำเข้าข้อมูลจาก Text File";
            this.btnImport.Enabled = false;
            this.btnImport.Glyph = ((System.Drawing.Image)(resources.GetObject("btnImport.Glyph")));
            this.btnImport.Id = 1;
            this.btnImport.Name = "btnImport";
            this.btnImport.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnImport.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnImport_ItemClick);
            // 
            // btnRecSO
            // 
            this.btnRecSO.Caption = "บันทึกรายการที่เลือก เป็นใบสั่งขาย";
            this.btnRecSO.Enabled = false;
            this.btnRecSO.Glyph = global::SoImporter.Properties.Resources.SAVE_SO;
            this.btnRecSO.Id = 2;
            this.btnRecSO.Name = "btnRecSO";
            this.btnRecSO.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRecSO.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRecSO_ItemClick);
            // 
            // btnDataPath
            // 
            this.btnDataPath.Caption = "กำหนดที่เก็บข้อมูล โปรแกรม Express";
            this.btnDataPath.Glyph = ((System.Drawing.Image)(resources.GetObject("btnDataPath.Glyph")));
            this.btnDataPath.Id = 3;
            this.btnDataPath.Name = "btnDataPath";
            this.btnDataPath.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnDataPath.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnDataPath_ItemClick);
            // 
            // barStaticItem1
            // 
            this.barStaticItem1.Caption = "ที่เก็บข้อมูลโปรแกรม Express :";
            this.barStaticItem1.Id = 4;
            this.barStaticItem1.Name = "barStaticItem1";
            this.barStaticItem1.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // lblDataPath
            // 
            this.lblDataPath.Caption = "[...]";
            this.lblDataPath.Id = 5;
            this.lblDataPath.Name = "lblDataPath";
            this.lblDataPath.TextAlignment = System.Drawing.StringAlignment.Near;
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Test add user";
            this.barButtonItem1.Glyph = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.Glyph")));
            this.barButtonItem1.Id = 8;
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            // 
            // btnUsers
            // 
            this.btnUsers.Caption = "กำหนดรหัสผู้ใช้";
            this.btnUsers.Glyph = ((System.Drawing.Image)(resources.GetObject("btnUsers.Glyph")));
            this.btnUsers.Id = 10;
            this.btnUsers.Name = "btnUsers";
            this.btnUsers.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnUsers.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnUsers_ItemClick);
            // 
            // btnApiUrl
            // 
            this.btnApiUrl.Caption = "ตั้งค่า Web API";
            this.btnApiUrl.Glyph = ((System.Drawing.Image)(resources.GetObject("btnApiUrl.Glyph")));
            this.btnApiUrl.Id = 11;
            this.btnApiUrl.Name = "btnApiUrl";
            this.btnApiUrl.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnApiUrl.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnApiUrl_ItemClick);
            // 
            // btnRetrieveData
            // 
            this.btnRetrieveData.Caption = "ดึงข้อมูล จากเซิร์ฟเวอร์";
            this.btnRetrieveData.Glyph = ((System.Drawing.Image)(resources.GetObject("btnRetrieveData.Glyph")));
            this.btnRetrieveData.Id = 15;
            this.btnRetrieveData.Name = "btnRetrieveData";
            this.btnRetrieveData.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonItemStyles.Large;
            this.btnRetrieveData.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.btnRetrieveData_ItemClick);
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1,
            this.ribbonPageGroup2});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "จัดการข้อมูล";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnApiUrl);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDataPath);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUsers);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ตั้งค่าเริ่มต้น";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRetrieveData);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnImport);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRecSO);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "จัดการ";
            // 
            // repositoryItemTextEdit1
            // 
            this.repositoryItemTextEdit1.AutoHeight = false;
            this.repositoryItemTextEdit1.Name = "repositoryItemTextEdit1";
            // 
            // repositoryItemTextEdit2
            // 
            this.repositoryItemTextEdit2.AutoHeight = false;
            this.repositoryItemTextEdit2.Name = "repositoryItemTextEdit2";
            // 
            // repositoryItemTextEdit3
            // 
            this.repositoryItemTextEdit3.AutoHeight = false;
            this.repositoryItemTextEdit3.Name = "repositoryItemTextEdit3";
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 143);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1210, 282);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colSoNum,
            this.colSoDat,
            this.colDlvBy,
            this.colDlvDat1,
            this.colDlvDat2,
            this.colRemark,
            this.colStkCod,
            this.colStkDes,
            this.colDealerCode,
            this.colCustName,
            this.colCustAddr01,
            this.colCustTaxId,
            this.colCustTelNum,
            this.colOrdQty,
            this.colTrnVal,
            this.colVatAmt,
            this.colTaxAmt,
            this.colNetAmt});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridView1_SelectionChanged);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colSoNum
            // 
            this.colSoNum.Caption = "ใบสั่งซื้อ #";
            this.colSoNum.FieldName = "PoNum";
            this.colSoNum.MaxWidth = 75;
            this.colSoNum.MinWidth = 75;
            this.colSoNum.Name = "colSoNum";
            this.colSoNum.OptionsColumn.FixedWidth = true;
            this.colSoNum.Visible = true;
            this.colSoNum.VisibleIndex = 1;
            // 
            // colSoDat
            // 
            this.colSoDat.Caption = "วันที่ใบสั่งซื้อ";
            this.colSoDat.FieldName = "PoDat";
            this.colSoDat.MaxWidth = 70;
            this.colSoDat.MinWidth = 70;
            this.colSoDat.Name = "colSoDat";
            this.colSoDat.OptionsColumn.FixedWidth = true;
            this.colSoDat.Visible = true;
            this.colSoDat.VisibleIndex = 3;
            this.colSoDat.Width = 70;
            // 
            // colDlvBy
            // 
            this.colDlvBy.Caption = "ขนส่งโดย";
            this.colDlvBy.FieldName = "DlvBy";
            this.colDlvBy.Name = "colDlvBy";
            this.colDlvBy.Visible = true;
            this.colDlvBy.VisibleIndex = 2;
            // 
            // colDealerCode
            // 
            this.colDealerCode.Caption = "รหัสตัวแทนฯ";
            this.colDealerCode.FieldName = "DealerCode";
            this.colDealerCode.MaxWidth = 75;
            this.colDealerCode.MinWidth = 75;
            this.colDealerCode.Name = "colDealerCode";
            this.colDealerCode.OptionsColumn.FixedWidth = true;
            this.colDealerCode.Visible = true;
            this.colDealerCode.VisibleIndex = 7;
            // 
            // colCustName
            // 
            this.colCustName.Caption = "ชื่อลูกค้า";
            this.colCustName.FieldName = "_CustFullName";
            this.colCustName.MinWidth = 120;
            this.colCustName.Name = "colCustName";
            this.colCustName.Visible = true;
            this.colCustName.VisibleIndex = 9;
            this.colCustName.Width = 120;
            // 
            // colCustAddr01
            // 
            this.colCustAddr01.Caption = "ที่อยู่";
            this.colCustAddr01.FieldName = "_CustAddr";
            this.colCustAddr01.MinWidth = 150;
            this.colCustAddr01.Name = "colCustAddr01";
            this.colCustAddr01.Visible = true;
            this.colCustAddr01.VisibleIndex = 10;
            this.colCustAddr01.Width = 150;
            // 
            // colCustTaxId
            // 
            this.colCustTaxId.Caption = "Tax ID";
            this.colCustTaxId.FieldName = "CustTaxId";
            this.colCustTaxId.MaxWidth = 100;
            this.colCustTaxId.MinWidth = 100;
            this.colCustTaxId.Name = "colCustTaxId";
            this.colCustTaxId.OptionsColumn.FixedWidth = true;
            this.colCustTaxId.Visible = true;
            this.colCustTaxId.VisibleIndex = 11;
            this.colCustTaxId.Width = 100;
            // 
            // colCustTelNum
            // 
            this.colCustTelNum.Caption = "โทรศัพท์/แฟกซ์";
            this.colCustTelNum.FieldName = "_CustTelFax";
            this.colCustTelNum.MinWidth = 100;
            this.colCustTelNum.Name = "colCustTelNum";
            this.colCustTelNum.Visible = true;
            this.colCustTelNum.VisibleIndex = 12;
            this.colCustTelNum.Width = 100;
            // 
            // colStkCod
            // 
            this.colStkCod.Caption = "รหัสสินค้า";
            this.colStkCod.FieldName = "StkCod";
            this.colStkCod.MaxWidth = 120;
            this.colStkCod.MinWidth = 120;
            this.colStkCod.Name = "colStkCod";
            this.colStkCod.Visible = true;
            this.colStkCod.VisibleIndex = 13;
            this.colStkCod.Width = 120;
            // 
            // colOrdQty
            // 
            this.colOrdQty.Caption = "จำนวน";
            this.colOrdQty.DisplayFormat.FormatString = "#,#0.00";
            this.colOrdQty.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colOrdQty.FieldName = "OrdQty";
            this.colOrdQty.MaxWidth = 40;
            this.colOrdQty.MinWidth = 40;
            this.colOrdQty.Name = "colOrdQty";
            this.colOrdQty.OptionsColumn.FixedWidth = true;
            this.colOrdQty.Visible = true;
            this.colOrdQty.VisibleIndex = 14;
            this.colOrdQty.Width = 40;
            // 
            // colTrnVal
            // 
            this.colTrnVal.Caption = "จำนวนเงิน";
            this.colTrnVal.DisplayFormat.FormatString = "#,#0.00";
            this.colTrnVal.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTrnVal.FieldName = "TrnVal";
            this.colTrnVal.MaxWidth = 70;
            this.colTrnVal.MinWidth = 70;
            this.colTrnVal.Name = "colTrnVal";
            this.colTrnVal.OptionsColumn.FixedWidth = true;
            this.colTrnVal.Visible = true;
            this.colTrnVal.VisibleIndex = 15;
            this.colTrnVal.Width = 70;
            // 
            // colVatAmt
            // 
            this.colVatAmt.Caption = "Vat.";
            this.colVatAmt.DisplayFormat.FormatString = "#,#0.00";
            this.colVatAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colVatAmt.FieldName = "VatAmt";
            this.colVatAmt.MaxWidth = 60;
            this.colVatAmt.MinWidth = 60;
            this.colVatAmt.Name = "colVatAmt";
            this.colVatAmt.OptionsColumn.FixedWidth = true;
            this.colVatAmt.Visible = true;
            this.colVatAmt.VisibleIndex = 16;
            this.colVatAmt.Width = 60;
            // 
            // colTaxAmt
            // 
            this.colTaxAmt.Caption = "Tax";
            this.colTaxAmt.DisplayFormat.FormatString = "#,#0.00";
            this.colTaxAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colTaxAmt.FieldName = "TaxAmt";
            this.colTaxAmt.MaxWidth = 55;
            this.colTaxAmt.MinWidth = 55;
            this.colTaxAmt.Name = "colTaxAmt";
            this.colTaxAmt.OptionsColumn.FixedWidth = true;
            this.colTaxAmt.Visible = true;
            this.colTaxAmt.VisibleIndex = 17;
            this.colTaxAmt.Width = 55;
            // 
            // colNetAmt
            // 
            this.colNetAmt.Caption = "จำนวนเงินสุทธิ";
            this.colNetAmt.DisplayFormat.FormatString = "#,#0.00";
            this.colNetAmt.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colNetAmt.FieldName = "NetAmt";
            this.colNetAmt.MaxWidth = 80;
            this.colNetAmt.MinWidth = 80;
            this.colNetAmt.Name = "colNetAmt";
            this.colNetAmt.OptionsColumn.FixedWidth = true;
            this.colNetAmt.Visible = true;
            this.colNetAmt.VisibleIndex = 18;
            this.colNetAmt.Width = 80;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // colDlvDat1
            // 
            this.colDlvDat1.Caption = "วันที่รับของ 1";
            this.colDlvDat1.FieldName = "DlvDat1";
            this.colDlvDat1.Name = "colDlvDat1";
            this.colDlvDat1.Visible = true;
            this.colDlvDat1.VisibleIndex = 4;
            // 
            // colDlvDat2
            // 
            this.colDlvDat2.Caption = "วันที่รับของ 2";
            this.colDlvDat2.FieldName = "DlvDat2";
            this.colDlvDat2.Name = "colDlvDat2";
            this.colDlvDat2.Visible = true;
            this.colDlvDat2.VisibleIndex = 5;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "หมายเหตุ";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 6;
            // 
            // colStkDes
            // 
            this.colStkDes.Caption = "รายละเอียดสินค้า";
            this.colStkDes.FieldName = "StkDes";
            this.colStkDes.Name = "colStkDes";
            this.colStkDes.Visible = true;
            this.colStkDes.VisibleIndex = 8;
            // 
            // MainForm
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1210, 456);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(400, 260);
            this.Name = "MainForm";
            this.Ribbon = this.ribbonControl1;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar1;
            this.Text = "SO Importer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colSoNum;
        private DevExpress.XtraGrid.Columns.GridColumn colSoDat;
        private DevExpress.XtraGrid.Columns.GridColumn colDealerCode;
        private DevExpress.XtraGrid.Columns.GridColumn colCustName;
        private DevExpress.XtraGrid.Columns.GridColumn colCustAddr01;
        private DevExpress.XtraGrid.Columns.GridColumn colCustTaxId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustTelNum;
        private DevExpress.XtraGrid.Columns.GridColumn colStkCod;
        private DevExpress.XtraGrid.Columns.GridColumn colOrdQty;
        private DevExpress.XtraGrid.Columns.GridColumn colTrnVal;
        private DevExpress.XtraGrid.Columns.GridColumn colVatAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxAmt;
        private DevExpress.XtraGrid.Columns.GridColumn colNetAmt;
        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.BarButtonItem btnImport;
        private DevExpress.XtraBars.BarButtonItem btnRecSO;
        private DevExpress.XtraBars.BarButtonItem btnDataPath;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem lblDataPath;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem btnUsers;
        private DevExpress.XtraBars.BarButtonItem btnApiUrl;
        private DevExpress.XtraBars.BarButtonItem btnRetrieveData;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit2;
        private DevExpress.XtraEditors.Repository.RepositoryItemTextEdit repositoryItemTextEdit3;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvBy;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvDat1;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvDat2;
        private DevExpress.XtraGrid.Columns.GridColumn colRemark;
        private DevExpress.XtraGrid.Columns.GridColumn colStkDes;
    }
}

