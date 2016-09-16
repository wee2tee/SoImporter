namespace SoImporter
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
            DevExpress.XtraGrid.GridLevelNode gridLevelNode1 = new DevExpress.XtraGrid.GridLevelNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colPreName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddr01 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddr02 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAddr03 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colZipCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTelNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFaxNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CustName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CustAddr = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_CustTelFax = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoNum = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSoDat = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvBy = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvDat1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvDat2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemark = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStkDes = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOrdQty = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTrnVal = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVatAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNetAmt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSlipFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTaxFileName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.col_ViewAttachment = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.ribbonPageGroup2 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.repositoryItemTextEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.repositoryItemTextEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemTextEdit();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.repositoryItemButtonEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colPreName,
            this.colName,
            this.colAddr01,
            this.colAddr02,
            this.colAddr03,
            this.colZipCod,
            this.colTelNum,
            this.colFaxNum,
            this.col_CustName,
            this.col_CustAddr,
            this.col_CustTelFax,
            this.colTaxId});
            this.gridView2.GridControl = this.gridControl1;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsBehavior.Editable = false;
            this.gridView2.OptionsBehavior.ReadOnly = true;
            this.gridView2.OptionsDetail.AllowZoomDetail = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            this.gridView2.ViewCaption = "รายละเอียดลูกค้า";
            // 
            // colPreName
            // 
            this.colPreName.Caption = "คำนำหน้าชื่อ";
            this.colPreName.FieldName = "PreName";
            this.colPreName.Name = "colPreName";
            // 
            // colName
            // 
            this.colName.Caption = "ชื่อ";
            this.colName.FieldName = "Name";
            this.colName.Name = "colName";
            // 
            // colAddr01
            // 
            this.colAddr01.Caption = "ที่อยู่ 1";
            this.colAddr01.FieldName = "Addr01";
            this.colAddr01.Name = "colAddr01";
            // 
            // colAddr02
            // 
            this.colAddr02.Caption = "ที่อยู่ 2";
            this.colAddr02.FieldName = "Addr02";
            this.colAddr02.Name = "colAddr02";
            // 
            // colAddr03
            // 
            this.colAddr03.Caption = "ที่อยู่ 3";
            this.colAddr03.FieldName = "Addr03";
            this.colAddr03.Name = "colAddr03";
            // 
            // colZipCod
            // 
            this.colZipCod.Caption = "รหัสไปรษณีย์";
            this.colZipCod.FieldName = "ZipCod";
            this.colZipCod.Name = "colZipCod";
            // 
            // colTelNum
            // 
            this.colTelNum.Caption = "โทรศัพท์";
            this.colTelNum.FieldName = "TelNum";
            this.colTelNum.Name = "colTelNum";
            // 
            // colFaxNum
            // 
            this.colFaxNum.Caption = "โทรสาร (Fax.)";
            this.colFaxNum.FieldName = "FaxNum";
            this.colFaxNum.Name = "colFaxNum";
            // 
            // col_CustName
            // 
            this.col_CustName.Caption = "ชื่อลูกค้า";
            this.col_CustName.FieldName = "_CustName";
            this.col_CustName.MinWidth = 80;
            this.col_CustName.Name = "col_CustName";
            this.col_CustName.Visible = true;
            this.col_CustName.VisibleIndex = 0;
            this.col_CustName.Width = 100;
            // 
            // col_CustAddr
            // 
            this.col_CustAddr.Caption = "ที่อยู่";
            this.col_CustAddr.FieldName = "_CustAddr";
            this.col_CustAddr.MinWidth = 80;
            this.col_CustAddr.Name = "col_CustAddr";
            this.col_CustAddr.Visible = true;
            this.col_CustAddr.VisibleIndex = 1;
            this.col_CustAddr.Width = 120;
            // 
            // col_CustTelFax
            // 
            this.col_CustTelFax.Caption = "โทรศัพท์ / โทรสาร(Fax.)";
            this.col_CustTelFax.FieldName = "_CustTelFax";
            this.col_CustTelFax.MaxWidth = 150;
            this.col_CustTelFax.Name = "col_CustTelFax";
            this.col_CustTelFax.Visible = true;
            this.col_CustTelFax.VisibleIndex = 2;
            this.col_CustTelFax.Width = 90;
            // 
            // colTaxId
            // 
            this.colTaxId.Caption = "เลขประจำตัวผู้เสียภาษี";
            this.colTaxId.FieldName = "TaxId";
            this.colTaxId.MaxWidth = 120;
            this.colTaxId.MinWidth = 120;
            this.colTaxId.Name = "colTaxId";
            this.colTaxId.OptionsColumn.FixedWidth = true;
            this.colTaxId.Visible = true;
            this.colTaxId.VisibleIndex = 3;
            this.colTaxId.Width = 120;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridView2;
            gridLevelNode1.RelationName = "cust";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(0, 143);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.ribbonControl1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemButtonEdit1});
            this.gridControl1.Size = new System.Drawing.Size(1210, 282);
            this.gridControl1.TabIndex = 1;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1,
            this.gridView2});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colSoNum,
            this.colSoDat,
            this.colCreBy,
            this.colDlvBy,
            this.colDlvDat1,
            this.colDlvDat2,
            this.colRemark,
            this.colStkCod,
            this.colStkDes,
            this.colOrdQty,
            this.colTrnVal,
            this.colVatAmt,
            this.colTaxAmt,
            this.colNetAmt,
            this.colCreDate,
            this.colStatus,
            this.colSlipFileName,
            this.colTaxFileName,
            this.col_ViewAttachment});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsSelection.MultiSelect = true;
            this.gridView1.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.OptionsSelection.ShowCheckBoxSelectorInGroupRow = DevExpress.Utils.DefaultBoolean.True;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
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
            this.colSoDat.VisibleIndex = 2;
            this.colSoDat.Width = 70;
            // 
            // colCreBy
            // 
            this.colCreBy.Caption = "ตัวแทนจำหน่าย";
            this.colCreBy.FieldName = "CreBy";
            this.colCreBy.Name = "colCreBy";
            this.colCreBy.Visible = true;
            this.colCreBy.VisibleIndex = 3;
            this.colCreBy.Width = 99;
            // 
            // colDlvBy
            // 
            this.colDlvBy.Caption = "ขนส่งโดย";
            this.colDlvBy.FieldName = "DlvBy";
            this.colDlvBy.Name = "colDlvBy";
            this.colDlvBy.Visible = true;
            this.colDlvBy.VisibleIndex = 4;
            this.colDlvBy.Width = 82;
            // 
            // colDlvDat1
            // 
            this.colDlvDat1.Caption = "วันที่รับของ 1";
            this.colDlvDat1.FieldName = "DlvDat1";
            this.colDlvDat1.Name = "colDlvDat1";
            this.colDlvDat1.Visible = true;
            this.colDlvDat1.VisibleIndex = 5;
            this.colDlvDat1.Width = 56;
            // 
            // colDlvDat2
            // 
            this.colDlvDat2.Caption = "วันที่รับของ 2";
            this.colDlvDat2.FieldName = "DlvDat2";
            this.colDlvDat2.Name = "colDlvDat2";
            this.colDlvDat2.Visible = true;
            this.colDlvDat2.VisibleIndex = 6;
            this.colDlvDat2.Width = 56;
            // 
            // colRemark
            // 
            this.colRemark.Caption = "หมายเหตุ";
            this.colRemark.FieldName = "Remark";
            this.colRemark.Name = "colRemark";
            this.colRemark.Visible = true;
            this.colRemark.VisibleIndex = 7;
            this.colRemark.Width = 67;
            // 
            // colStkCod
            // 
            this.colStkCod.Caption = "รหัสสินค้า";
            this.colStkCod.FieldName = "StkCod";
            this.colStkCod.MaxWidth = 120;
            this.colStkCod.MinWidth = 120;
            this.colStkCod.Name = "colStkCod";
            this.colStkCod.Visible = true;
            this.colStkCod.VisibleIndex = 8;
            this.colStkCod.Width = 120;
            // 
            // colStkDes
            // 
            this.colStkDes.Caption = "รายละเอียดสินค้า";
            this.colStkDes.FieldName = "StkDes";
            this.colStkDes.Name = "colStkDes";
            this.colStkDes.Visible = true;
            this.colStkDes.VisibleIndex = 9;
            this.colStkDes.Width = 97;
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
            this.colOrdQty.VisibleIndex = 10;
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
            this.colTrnVal.VisibleIndex = 11;
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
            this.colVatAmt.VisibleIndex = 12;
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
            this.colTaxAmt.VisibleIndex = 13;
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
            this.colNetAmt.VisibleIndex = 14;
            this.colNetAmt.Width = 80;
            // 
            // colCreDate
            // 
            this.colCreDate.Caption = "วัน/เวลา บันทึก";
            this.colCreDate.FieldName = "CreDate";
            this.colCreDate.Name = "colCreDate";
            this.colCreDate.Width = 20;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "สถานะรายการ";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            // 
            // colSlipFileName
            // 
            this.colSlipFileName.Caption = "หลักฐานการชำระ";
            this.colSlipFileName.FieldName = "SlipFileName";
            this.colSlipFileName.Name = "colSlipFileName";
            // 
            // colTaxFileName
            // 
            this.colTaxFileName.Caption = "หัก ณ ที่จ่าย";
            this.colTaxFileName.FieldName = "TaxFileName";
            this.colTaxFileName.Name = "colTaxFileName";
            // 
            // col_ViewAttachment
            // 
            this.col_ViewAttachment.AppearanceCell.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Underline);
            this.col_ViewAttachment.AppearanceCell.ForeColor = System.Drawing.Color.Blue;
            this.col_ViewAttachment.AppearanceCell.Options.UseFont = true;
            this.col_ViewAttachment.AppearanceCell.Options.UseForeColor = true;
            this.col_ViewAttachment.Caption = "ไฟล์แนบ";
            this.col_ViewAttachment.FieldName = "_ViewAttachment";
            this.col_ViewAttachment.MaxWidth = 60;
            this.col_ViewAttachment.MinWidth = 60;
            this.col_ViewAttachment.Name = "col_ViewAttachment";
            this.col_ViewAttachment.Visible = true;
            this.col_ViewAttachment.VisibleIndex = 15;
            this.col_ViewAttachment.Width = 60;
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
            this.ribbonPageGroup2,
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "จัดการข้อมูล";
            // 
            // ribbonPageGroup2
            // 
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRetrieveData);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnImport);
            this.ribbonPageGroup2.ItemLinks.Add(this.btnRecSO);
            this.ribbonPageGroup2.Name = "ribbonPageGroup2";
            this.ribbonPageGroup2.Text = "จัดการข้อมูล";
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.ItemLinks.Add(this.btnApiUrl);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnDataPath);
            this.ribbonPageGroup1.ItemLinks.Add(this.btnUsers);
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            this.ribbonPageGroup1.Text = "ตั้งค่า";
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
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.Location = new System.Drawing.Point(0, 425);
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            this.ribbonStatusBar1.Size = new System.Drawing.Size(1210, 31);
            // 
            // repositoryItemButtonEdit1
            // 
            this.repositoryItemButtonEdit1.AutoHeight = false;
            this.repositoryItemButtonEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton()});
            this.repositoryItemButtonEdit1.Name = "repositoryItemButtonEdit1";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
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
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemTextEdit3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemButtonEdit1)).EndInit();
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
        private DevExpress.XtraGrid.Columns.GridColumn colCreBy;
        private DevExpress.XtraGrid.Columns.GridColumn colCreDate;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colSlipFileName;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxFileName;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn colPreName;
        private DevExpress.XtraGrid.Columns.GridColumn colName;
        private DevExpress.XtraGrid.Columns.GridColumn colAddr01;
        private DevExpress.XtraGrid.Columns.GridColumn colAddr02;
        private DevExpress.XtraGrid.Columns.GridColumn colAddr03;
        private DevExpress.XtraGrid.Columns.GridColumn colZipCod;
        private DevExpress.XtraGrid.Columns.GridColumn colTelNum;
        private DevExpress.XtraGrid.Columns.GridColumn colFaxNum;
        private DevExpress.XtraGrid.Columns.GridColumn col_CustName;
        private DevExpress.XtraGrid.Columns.GridColumn col_CustAddr;
        private DevExpress.XtraGrid.Columns.GridColumn col_CustTelFax;
        private DevExpress.XtraGrid.Columns.GridColumn colTaxId;
        private DevExpress.XtraGrid.Columns.GridColumn col_ViewAttachment;
        private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repositoryItemButtonEdit1;
    }
}

