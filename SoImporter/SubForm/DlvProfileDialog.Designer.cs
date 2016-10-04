namespace SoImporter.SubForm
{
    partial class DlvProfileDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlvProfileDialog));
            this.gridViewDlvBy = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDlvId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvTypCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvAbbrTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvAbbrEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvTypDesTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDlvTypDesEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewDlvProfile = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colProfileId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfileTypcod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfileAbbrTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfileAbbrEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfileTypDesTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colProfileTypDesEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDlvBy)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDlvProfile)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridViewDlvBy
            // 
            this.gridViewDlvBy.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDlvId,
            this.colDlvTypCod,
            this.colDlvAbbrTh,
            this.colDlvAbbrEn,
            this.colDlvTypDesTh,
            this.colDlvTypDesEn});
            this.gridViewDlvBy.GridControl = this.gridControl1;
            this.gridViewDlvBy.Name = "gridViewDlvBy";
            this.gridViewDlvBy.OptionsBehavior.Editable = false;
            this.gridViewDlvBy.OptionsBehavior.ReadOnly = true;
            this.gridViewDlvBy.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridViewDlvBy.OptionsView.ShowGroupPanel = false;
            this.gridViewDlvBy.ViewCaption = "ขนส่งโดย";
            this.gridViewDlvBy.GotFocus += new System.EventHandler(this.gridViewDlvBy_GotFocus);
            // 
            // colDlvId
            // 
            this.colDlvId.Caption = "Id";
            this.colDlvId.FieldName = "Id";
            this.colDlvId.Name = "colDlvId";
            // 
            // colDlvTypCod
            // 
            this.colDlvTypCod.AppearanceHeader.Options.UseTextOptions = true;
            this.colDlvTypCod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDlvTypCod.Caption = "รหัส";
            this.colDlvTypCod.FieldName = "TypCod";
            this.colDlvTypCod.MaxWidth = 70;
            this.colDlvTypCod.MinWidth = 70;
            this.colDlvTypCod.Name = "colDlvTypCod";
            this.colDlvTypCod.Visible = true;
            this.colDlvTypCod.VisibleIndex = 0;
            this.colDlvTypCod.Width = 70;
            // 
            // colDlvAbbrTh
            // 
            this.colDlvAbbrTh.AppearanceHeader.Options.UseTextOptions = true;
            this.colDlvAbbrTh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDlvAbbrTh.Caption = "ชื่อย่อ (ไทย)";
            this.colDlvAbbrTh.FieldName = "AbbreviateTh";
            this.colDlvAbbrTh.MaxWidth = 150;
            this.colDlvAbbrTh.MinWidth = 150;
            this.colDlvAbbrTh.Name = "colDlvAbbrTh";
            this.colDlvAbbrTh.Visible = true;
            this.colDlvAbbrTh.VisibleIndex = 1;
            this.colDlvAbbrTh.Width = 150;
            // 
            // colDlvAbbrEn
            // 
            this.colDlvAbbrEn.AppearanceHeader.Options.UseTextOptions = true;
            this.colDlvAbbrEn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDlvAbbrEn.Caption = "ชื่อย่อ (Eng.)";
            this.colDlvAbbrEn.FieldName = "AbbreviateEn";
            this.colDlvAbbrEn.MaxWidth = 150;
            this.colDlvAbbrEn.MinWidth = 150;
            this.colDlvAbbrEn.Name = "colDlvAbbrEn";
            this.colDlvAbbrEn.Width = 150;
            // 
            // colDlvTypDesTh
            // 
            this.colDlvTypDesTh.AppearanceHeader.Options.UseTextOptions = true;
            this.colDlvTypDesTh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDlvTypDesTh.Caption = "ชื่อเต็ม (ไทย)";
            this.colDlvTypDesTh.FieldName = "TypDesTh";
            this.colDlvTypDesTh.MinWidth = 180;
            this.colDlvTypDesTh.Name = "colDlvTypDesTh";
            this.colDlvTypDesTh.Visible = true;
            this.colDlvTypDesTh.VisibleIndex = 2;
            this.colDlvTypDesTh.Width = 194;
            // 
            // colDlvTypDesEn
            // 
            this.colDlvTypDesEn.AppearanceHeader.Options.UseTextOptions = true;
            this.colDlvTypDesEn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colDlvTypDesEn.Caption = "ชื่อเต็ม (Eng.)";
            this.colDlvTypDesEn.FieldName = "TypDesEn";
            this.colDlvTypDesEn.MinWidth = 180;
            this.colDlvTypDesEn.Name = "colDlvTypDesEn";
            this.colDlvTypDesEn.Width = 226;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            gridLevelNode1.LevelTemplate = this.gridViewDlvBy;
            gridLevelNode1.RelationName = "dlv";
            this.gridControl1.LevelTree.Nodes.AddRange(new DevExpress.XtraGrid.GridLevelNode[] {
            gridLevelNode1});
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridViewDlvProfile;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(808, 327);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDlvProfile,
            this.gridViewDlvBy});
            // 
            // gridViewDlvProfile
            // 
            this.gridViewDlvProfile.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colProfileId,
            this.colProfileTypcod,
            this.colProfileAbbrTh,
            this.colProfileAbbrEn,
            this.colProfileTypDesTh,
            this.colProfileTypDesEn});
            this.gridViewDlvProfile.GridControl = this.gridControl1;
            this.gridViewDlvProfile.Name = "gridViewDlvProfile";
            this.gridViewDlvProfile.OptionsBehavior.Editable = false;
            this.gridViewDlvProfile.OptionsBehavior.ReadOnly = true;
            this.gridViewDlvProfile.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewDlvProfile_RowCellClick);
            this.gridViewDlvProfile.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridViewDlvProfile_FocusedRowChanged);
            this.gridViewDlvProfile.GotFocus += new System.EventHandler(this.gridViewDlvProfile_GotFocus);
            // 
            // colProfileId
            // 
            this.colProfileId.Caption = "Id";
            this.colProfileId.FieldName = "Id";
            this.colProfileId.Name = "colProfileId";
            // 
            // colProfileTypcod
            // 
            this.colProfileTypcod.AppearanceHeader.Options.UseTextOptions = true;
            this.colProfileTypcod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProfileTypcod.Caption = "รหัสกลุ่ม";
            this.colProfileTypcod.FieldName = "TypCod";
            this.colProfileTypcod.MaxWidth = 90;
            this.colProfileTypcod.MinWidth = 90;
            this.colProfileTypcod.Name = "colProfileTypcod";
            this.colProfileTypcod.Visible = true;
            this.colProfileTypcod.VisibleIndex = 0;
            this.colProfileTypcod.Width = 90;
            // 
            // colProfileAbbrTh
            // 
            this.colProfileAbbrTh.AppearanceHeader.Options.UseTextOptions = true;
            this.colProfileAbbrTh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProfileAbbrTh.Caption = "ชื่อย่อ (ไทย)";
            this.colProfileAbbrTh.FieldName = "AbbreviateTh";
            this.colProfileAbbrTh.MaxWidth = 150;
            this.colProfileAbbrTh.MinWidth = 150;
            this.colProfileAbbrTh.Name = "colProfileAbbrTh";
            this.colProfileAbbrTh.Visible = true;
            this.colProfileAbbrTh.VisibleIndex = 1;
            this.colProfileAbbrTh.Width = 150;
            // 
            // colProfileAbbrEn
            // 
            this.colProfileAbbrEn.AppearanceHeader.Options.UseTextOptions = true;
            this.colProfileAbbrEn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProfileAbbrEn.Caption = "ชื่อย่อ (Eng.)";
            this.colProfileAbbrEn.FieldName = "AbbreviateEn";
            this.colProfileAbbrEn.MaxWidth = 150;
            this.colProfileAbbrEn.MinWidth = 150;
            this.colProfileAbbrEn.Name = "colProfileAbbrEn";
            this.colProfileAbbrEn.Visible = true;
            this.colProfileAbbrEn.VisibleIndex = 2;
            this.colProfileAbbrEn.Width = 150;
            // 
            // colProfileTypDesTh
            // 
            this.colProfileTypDesTh.AppearanceHeader.Options.UseTextOptions = true;
            this.colProfileTypDesTh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProfileTypDesTh.Caption = "ชื่อเต็ม (ไทย)";
            this.colProfileTypDesTh.FieldName = "TypDesTh";
            this.colProfileTypDesTh.MinWidth = 180;
            this.colProfileTypDesTh.Name = "colProfileTypDesTh";
            this.colProfileTypDesTh.Visible = true;
            this.colProfileTypDesTh.VisibleIndex = 3;
            this.colProfileTypDesTh.Width = 180;
            // 
            // colProfileTypDesEn
            // 
            this.colProfileTypDesEn.AppearanceHeader.Options.UseTextOptions = true;
            this.colProfileTypDesEn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colProfileTypDesEn.Caption = "ชื่อเต็ม (Eng.)";
            this.colProfileTypDesEn.FieldName = "TypDesEn";
            this.colProfileTypDesEn.MinWidth = 180;
            this.colProfileTypDesEn.Name = "colProfileTypDesEn";
            this.colProfileTypDesEn.Visible = true;
            this.colProfileTypDesEn.VisibleIndex = 4;
            this.colProfileTypDesEn.Width = 180;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 46);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(812, 331);
            this.panelControl1.TabIndex = 0;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(608, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(68, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(682, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(68, 28);
            this.btnEdit.TabIndex = 2;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(756, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(68, 28);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // DlvProfileDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 389);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "DlvProfileDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "กลุ่มวิธีการจัดส่ง";
            this.Load += new System.EventHandler(this.DlvProfileDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDlvBy)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDlvProfile)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDlvProfile;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDlvBy;
        private DevExpress.XtraGrid.Columns.GridColumn colProfileId;
        private DevExpress.XtraGrid.Columns.GridColumn colProfileTypcod;
        private DevExpress.XtraGrid.Columns.GridColumn colProfileAbbrTh;
        private DevExpress.XtraGrid.Columns.GridColumn colProfileAbbrEn;
        private DevExpress.XtraGrid.Columns.GridColumn colProfileTypDesTh;
        private DevExpress.XtraGrid.Columns.GridColumn colProfileTypDesEn;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvId;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvTypCod;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvAbbrTh;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvAbbrEn;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvTypDesTh;
        private DevExpress.XtraGrid.Columns.GridColumn colDlvTypDesEn;
    }
}