namespace SoImporter.SubForm
{
    partial class DlvProfileAddEditDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DlvProfileAddEditDialog));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridViewDlvByRemain = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRemainId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainTypCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainAbbrTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRemainTypDesTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnOut = new DevExpress.XtraEditors.SimpleButton();
            this.btnIn = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl2 = new DevExpress.XtraEditors.PanelControl();
            this.gridControl2 = new DevExpress.XtraGrid.GridControl();
            this.gridViewDlvBySelected = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSelectedId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelectedTypCod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSelectedTypDesTh = new DevExpress.XtraGrid.Columns.GridColumn();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl7 = new DevExpress.XtraEditors.LabelControl();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            this.panelControl3 = new DevExpress.XtraEditors.PanelControl();
            this.txtTypDesEn = new DevExpress.XtraEditors.TextEdit();
            this.txtAbbrEn = new DevExpress.XtraEditors.TextEdit();
            this.txtTypDesTh = new DevExpress.XtraEditors.TextEdit();
            this.txtAbbrTh = new DevExpress.XtraEditors.TextEdit();
            this.txtTypcod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDlvByRemain)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).BeginInit();
            this.panelControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDlvBySelected)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).BeginInit();
            this.panelControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypDesEn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbrEn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypDesTh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbrTh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypcod.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridViewDlvByRemain;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(342, 236);
            this.gridControl1.TabIndex = 15;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDlvByRemain});
            // 
            // gridViewDlvByRemain
            // 
            this.gridViewDlvByRemain.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRemainId,
            this.colRemainTypCod,
            this.colRemainAbbrTh,
            this.colRemainTypDesTh});
            this.gridViewDlvByRemain.GridControl = this.gridControl1;
            this.gridViewDlvByRemain.Name = "gridViewDlvByRemain";
            this.gridViewDlvByRemain.OptionsBehavior.Editable = false;
            this.gridViewDlvByRemain.OptionsBehavior.ReadOnly = true;
            this.gridViewDlvByRemain.OptionsSelection.MultiSelect = true;
            this.gridViewDlvByRemain.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewDlvByRemain.OptionsView.ShowGroupPanel = false;
            this.gridViewDlvByRemain.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewDlvByRemain_RowCellClick);
            this.gridViewDlvByRemain.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewDlvByRemain_SelectionChanged);
            // 
            // colRemainId
            // 
            this.colRemainId.Caption = "Id";
            this.colRemainId.FieldName = "Id";
            this.colRemainId.Name = "colRemainId";
            // 
            // colRemainTypCod
            // 
            this.colRemainTypCod.Caption = "รหัส";
            this.colRemainTypCod.FieldName = "TypCod";
            this.colRemainTypCod.MaxWidth = 80;
            this.colRemainTypCod.MinWidth = 80;
            this.colRemainTypCod.Name = "colRemainTypCod";
            this.colRemainTypCod.Visible = true;
            this.colRemainTypCod.VisibleIndex = 1;
            this.colRemainTypCod.Width = 80;
            // 
            // colRemainAbbrTh
            // 
            this.colRemainAbbrTh.Caption = "ชื่อย่อ (ไทย)";
            this.colRemainAbbrTh.FieldName = "AbbreviateTh";
            this.colRemainAbbrTh.Name = "colRemainAbbrTh";
            // 
            // colRemainTypDesTh
            // 
            this.colRemainTypDesTh.Caption = "ชื่อเต็ม (ไทย)";
            this.colRemainTypDesTh.FieldName = "TypDesTh";
            this.colRemainTypDesTh.Name = "colRemainTypDesTh";
            this.colRemainTypDesTh.Visible = true;
            this.colRemainTypDesTh.VisibleIndex = 2;
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 176);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(346, 240);
            this.panelControl1.TabIndex = 15;
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(292, 429);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(90, 33);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "บันทึก <F9>";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(388, 429);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(90, 33);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            // 
            // btnOut
            // 
            this.btnOut.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOut.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOut.Appearance.Options.UseFont = true;
            this.btnOut.Enabled = false;
            this.btnOut.Image = ((System.Drawing.Image)(resources.GetObject("btnOut.Image")));
            this.btnOut.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleLeft;
            this.btnOut.Location = new System.Drawing.Point(364, 253);
            this.btnOut.Name = "btnOut";
            this.btnOut.Size = new System.Drawing.Size(42, 33);
            this.btnOut.TabIndex = 4;
            this.btnOut.Click += new System.EventHandler(this.btnOut_Click);
            // 
            // btnIn
            // 
            this.btnIn.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnIn.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnIn.Appearance.Options.UseFont = true;
            this.btnIn.Enabled = false;
            this.btnIn.Image = ((System.Drawing.Image)(resources.GetObject("btnIn.Image")));
            this.btnIn.ImageLocation = DevExpress.XtraEditors.ImageLocation.MiddleRight;
            this.btnIn.Location = new System.Drawing.Point(364, 292);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(42, 33);
            this.btnIn.TabIndex = 4;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // panelControl2
            // 
            this.panelControl2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl2.Controls.Add(this.gridControl2);
            this.panelControl2.Location = new System.Drawing.Point(412, 176);
            this.panelControl2.Name = "panelControl2";
            this.panelControl2.Size = new System.Drawing.Size(346, 240);
            this.panelControl2.TabIndex = 15;
            // 
            // gridControl2
            // 
            this.gridControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl2.Location = new System.Drawing.Point(2, 2);
            this.gridControl2.MainView = this.gridViewDlvBySelected;
            this.gridControl2.Name = "gridControl2";
            this.gridControl2.Size = new System.Drawing.Size(342, 236);
            this.gridControl2.TabIndex = 15;
            this.gridControl2.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewDlvBySelected});
            // 
            // gridViewDlvBySelected
            // 
            this.gridViewDlvBySelected.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSelectedId,
            this.colSelectedTypCod,
            this.colSelectedTypDesTh});
            this.gridViewDlvBySelected.GridControl = this.gridControl2;
            this.gridViewDlvBySelected.Name = "gridViewDlvBySelected";
            this.gridViewDlvBySelected.OptionsBehavior.Editable = false;
            this.gridViewDlvBySelected.OptionsBehavior.ReadOnly = true;
            this.gridViewDlvBySelected.OptionsSelection.MultiSelect = true;
            this.gridViewDlvBySelected.OptionsSelection.MultiSelectMode = DevExpress.XtraGrid.Views.Grid.GridMultiSelectMode.CheckBoxRowSelect;
            this.gridViewDlvBySelected.OptionsView.ShowGroupPanel = false;
            this.gridViewDlvBySelected.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridViewDlvBySelected_RowCellClick);
            this.gridViewDlvBySelected.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.gridViewDlvBySelected_SelectionChanged);
            // 
            // colSelectedId
            // 
            this.colSelectedId.Caption = "Id";
            this.colSelectedId.FieldName = "Id";
            this.colSelectedId.Name = "colSelectedId";
            // 
            // colSelectedTypCod
            // 
            this.colSelectedTypCod.Caption = "รหัส";
            this.colSelectedTypCod.FieldName = "TypCod";
            this.colSelectedTypCod.MaxWidth = 80;
            this.colSelectedTypCod.MinWidth = 80;
            this.colSelectedTypCod.Name = "colSelectedTypCod";
            this.colSelectedTypCod.Visible = true;
            this.colSelectedTypCod.VisibleIndex = 1;
            this.colSelectedTypCod.Width = 80;
            // 
            // colSelectedTypDesTh
            // 
            this.colSelectedTypDesTh.Caption = "ชื่อเต็ม (ไทย)";
            this.colSelectedTypDesTh.FieldName = "TypDesTh";
            this.colSelectedTypDesTh.Name = "colSelectedTypDesTh";
            this.colSelectedTypDesTh.Visible = true;
            this.colSelectedTypDesTh.VisibleIndex = 2;
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl6.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.labelControl6.Location = new System.Drawing.Point(12, 158);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(130, 16);
            this.labelControl6.TabIndex = 0;
            this.labelControl6.Text = "วิธีการขนส่งที่ไม่ได้เลือก";
            // 
            // labelControl7
            // 
            this.labelControl7.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl7.Appearance.ForeColor = System.Drawing.Color.Green;
            this.labelControl7.Location = new System.Drawing.Point(412, 158);
            this.labelControl7.Name = "labelControl7";
            this.labelControl7.Size = new System.Drawing.Size(181, 16);
            this.labelControl7.TabIndex = 0;
            this.labelControl7.Text = "วิธีการขนส่งที่เลือกไว้สำหรับกลุ่มนี้";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // panelControl3
            // 
            this.panelControl3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl3.Controls.Add(this.txtTypDesEn);
            this.panelControl3.Controls.Add(this.txtAbbrEn);
            this.panelControl3.Controls.Add(this.txtTypDesTh);
            this.panelControl3.Controls.Add(this.txtAbbrTh);
            this.panelControl3.Controls.Add(this.txtTypcod);
            this.panelControl3.Controls.Add(this.labelControl5);
            this.panelControl3.Controls.Add(this.labelControl3);
            this.panelControl3.Controls.Add(this.labelControl4);
            this.panelControl3.Controls.Add(this.labelControl2);
            this.panelControl3.Controls.Add(this.labelControl1);
            this.panelControl3.Location = new System.Drawing.Point(12, 12);
            this.panelControl3.Name = "panelControl3";
            this.panelControl3.Size = new System.Drawing.Size(744, 130);
            this.panelControl3.TabIndex = 0;
            // 
            // txtTypDesEn
            // 
            this.txtTypDesEn.Location = new System.Drawing.Point(125, 90);
            this.txtTypDesEn.Name = "txtTypDesEn";
            this.txtTypDesEn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTypDesEn.Properties.Appearance.Options.UseFont = true;
            this.txtTypDesEn.Size = new System.Drawing.Size(472, 22);
            this.txtTypDesEn.TabIndex = 4;
            this.txtTypDesEn.EditValueChanged += new System.EventHandler(this.txtTypDesEn_EditValueChanged);
            // 
            // txtAbbrEn
            // 
            this.txtAbbrEn.Location = new System.Drawing.Point(409, 40);
            this.txtAbbrEn.Name = "txtAbbrEn";
            this.txtAbbrEn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAbbrEn.Properties.Appearance.Options.UseFont = true;
            this.txtAbbrEn.Size = new System.Drawing.Size(188, 22);
            this.txtAbbrEn.TabIndex = 2;
            this.txtAbbrEn.EditValueChanged += new System.EventHandler(this.txtAbbrEn_EditValueChanged);
            // 
            // txtTypDesTh
            // 
            this.txtTypDesTh.Location = new System.Drawing.Point(125, 65);
            this.txtTypDesTh.Name = "txtTypDesTh";
            this.txtTypDesTh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTypDesTh.Properties.Appearance.Options.UseFont = true;
            this.txtTypDesTh.Size = new System.Drawing.Size(472, 22);
            this.txtTypDesTh.TabIndex = 3;
            this.txtTypDesTh.EditValueChanged += new System.EventHandler(this.txtTypDesTh_EditValueChanged);
            // 
            // txtAbbrTh
            // 
            this.txtAbbrTh.Location = new System.Drawing.Point(125, 40);
            this.txtAbbrTh.Name = "txtAbbrTh";
            this.txtAbbrTh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAbbrTh.Properties.Appearance.Options.UseFont = true;
            this.txtAbbrTh.Size = new System.Drawing.Size(188, 22);
            this.txtAbbrTh.TabIndex = 1;
            this.txtAbbrTh.EditValueChanged += new System.EventHandler(this.txtAbbrTh_EditValueChanged);
            // 
            // txtTypcod
            // 
            this.txtTypcod.Location = new System.Drawing.Point(125, 15);
            this.txtTypcod.Name = "txtTypcod";
            this.txtTypcod.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTypcod.Properties.Appearance.Options.UseFont = true;
            this.txtTypcod.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypcod.Size = new System.Drawing.Size(100, 22);
            this.txtTypcod.TabIndex = 0;
            this.txtTypcod.EditValueChanged += new System.EventHandler(this.txtTypcod_EditValueChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl5.Location = new System.Drawing.Point(40, 93);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 16);
            this.labelControl5.TabIndex = 2;
            this.labelControl5.Text = "ชื่อเต็ม (Eng.)";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl3.Location = new System.Drawing.Point(327, 43);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 16);
            this.labelControl3.TabIndex = 3;
            this.labelControl3.Text = "ชื่อย่อ (Eng.)";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl4.Location = new System.Drawing.Point(41, 68);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 16);
            this.labelControl4.TabIndex = 4;
            this.labelControl4.Text = "ชื่อเต็ม (ไทย)";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl2.Location = new System.Drawing.Point(45, 43);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 16);
            this.labelControl2.TabIndex = 5;
            this.labelControl2.Text = "ชื่อย่อ (ไทย)";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Location = new System.Drawing.Point(69, 18);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(46, 16);
            this.labelControl1.TabIndex = 6;
            this.labelControl1.Text = "รหัสกลุ่ม";
            // 
            // DlvProfileAddEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(770, 479);
            this.Controls.Add(this.panelControl3);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnIn);
            this.Controls.Add(this.btnOut);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.panelControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.labelControl7);
            this.Controls.Add(this.labelControl6);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DlvProfileAddEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Dlv Profile";
            this.Load += new System.EventHandler(this.DlvProfileAddEditDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDlvByRemain)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl2)).EndInit();
            this.panelControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewDlvBySelected)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl3)).EndInit();
            this.panelControl3.ResumeLayout(false);
            this.panelControl3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypDesEn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbrEn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypDesTh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbrTh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypcod.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDlvByRemain;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnOut;
        private DevExpress.XtraEditors.SimpleButton btnIn;
        private DevExpress.XtraEditors.PanelControl panelControl2;
        private DevExpress.XtraGrid.GridControl gridControl2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewDlvBySelected;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.LabelControl labelControl7;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.PanelControl panelControl3;
        private DevExpress.XtraEditors.TextEdit txtTypDesEn;
        private DevExpress.XtraEditors.TextEdit txtAbbrEn;
        private DevExpress.XtraEditors.TextEdit txtTypDesTh;
        private DevExpress.XtraEditors.TextEdit txtAbbrTh;
        private DevExpress.XtraEditors.TextEdit txtTypcod;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainId;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainTypCod;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainAbbrTh;
        private DevExpress.XtraGrid.Columns.GridColumn colRemainTypDesTh;
        private DevExpress.XtraGrid.Columns.GridColumn colSelectedId;
        private DevExpress.XtraGrid.Columns.GridColumn colSelectedTypCod;
        private DevExpress.XtraGrid.Columns.GridColumn colSelectedTypDesTh;
    }
}