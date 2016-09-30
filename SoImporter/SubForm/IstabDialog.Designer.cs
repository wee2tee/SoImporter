namespace SoImporter.SubForm
{
    partial class IstabDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IstabDialog));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewIstab = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbbreviateTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAbbreviateEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypDesTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTypDesEn = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIstab)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridViewIstab;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(770, 262);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewIstab});
            // 
            // gridViewIstab
            // 
            this.gridViewIstab.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colTypCod,
            this.colAbbreviateTh,
            this.colAbbreviateEn,
            this.colTypDesTh,
            this.colTypDesEn});
            this.gridViewIstab.GridControl = this.gridControl1;
            this.gridViewIstab.Name = "gridViewIstab";
            this.gridViewIstab.OptionsBehavior.Editable = false;
            this.gridViewIstab.OptionsBehavior.ReadOnly = true;
            this.gridViewIstab.OptionsView.ShowGroupPanel = false;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colTypCod
            // 
            this.colTypCod.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypCod.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypCod.Caption = "รหัส";
            this.colTypCod.FieldName = "TypCod";
            this.colTypCod.MaxWidth = 90;
            this.colTypCod.MinWidth = 90;
            this.colTypCod.Name = "colTypCod";
            this.colTypCod.Visible = true;
            this.colTypCod.VisibleIndex = 0;
            this.colTypCod.Width = 90;
            // 
            // colAbbreviateTh
            // 
            this.colAbbreviateTh.AppearanceHeader.Options.UseTextOptions = true;
            this.colAbbreviateTh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAbbreviateTh.Caption = "ชื่อย่อ (ไทย)";
            this.colAbbreviateTh.FieldName = "AbbreviateTh";
            this.colAbbreviateTh.MaxWidth = 150;
            this.colAbbreviateTh.MinWidth = 150;
            this.colAbbreviateTh.Name = "colAbbreviateTh";
            this.colAbbreviateTh.Visible = true;
            this.colAbbreviateTh.VisibleIndex = 1;
            this.colAbbreviateTh.Width = 150;
            // 
            // colAbbreviateEn
            // 
            this.colAbbreviateEn.AppearanceHeader.Options.UseTextOptions = true;
            this.colAbbreviateEn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colAbbreviateEn.Caption = "ชื่อย่อ (Eng.)";
            this.colAbbreviateEn.FieldName = "AbbreviateEn";
            this.colAbbreviateEn.MaxWidth = 150;
            this.colAbbreviateEn.MinWidth = 150;
            this.colAbbreviateEn.Name = "colAbbreviateEn";
            this.colAbbreviateEn.Visible = true;
            this.colAbbreviateEn.VisibleIndex = 2;
            this.colAbbreviateEn.Width = 150;
            // 
            // colTypDesTh
            // 
            this.colTypDesTh.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypDesTh.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypDesTh.Caption = "ชื่อเต็ม (ไทย)";
            this.colTypDesTh.FieldName = "TypDesTh";
            this.colTypDesTh.MinWidth = 180;
            this.colTypDesTh.Name = "colTypDesTh";
            this.colTypDesTh.Visible = true;
            this.colTypDesTh.VisibleIndex = 3;
            this.colTypDesTh.Width = 180;
            // 
            // colTypDesEn
            // 
            this.colTypDesEn.AppearanceHeader.Options.UseTextOptions = true;
            this.colTypDesEn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.colTypDesEn.Caption = "ชื่อเต็ม (Eng.)";
            this.colTypDesEn.FieldName = "TypDesEn";
            this.colTypDesEn.MinWidth = 180;
            this.colTypDesEn.Name = "colTypDesEn";
            this.colTypDesEn.Visible = true;
            this.colTypDesEn.VisibleIndex = 4;
            this.colTypDesEn.Width = 180;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 46);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(774, 266);
            this.panelControl1.TabIndex = 1;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(585, 12);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(63, 28);
            this.btnAdd.TabIndex = 2;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(654, 12);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(63, 28);
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
            this.btnDelete.Location = new System.Drawing.Point(723, 12);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(63, 28);
            this.btnDelete.TabIndex = 2;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // IstabDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 324);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.panelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "IstabDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Istab";
            this.Load += new System.EventHandler(this.IstabDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewIstab)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewIstab;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colTypCod;
        private DevExpress.XtraGrid.Columns.GridColumn colAbbreviateTh;
        private DevExpress.XtraGrid.Columns.GridColumn colAbbreviateEn;
        private DevExpress.XtraGrid.Columns.GridColumn colTypDesTh;
        private DevExpress.XtraGrid.Columns.GridColumn colTypDesEn;
    }
}