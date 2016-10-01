namespace SoImporter.SubForm
{
    partial class StpriAddEditDialog
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtPriceCode = new DevExpress.XtraEditors.TextEdit();
            this.cbTabPr = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtDescription = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtDisc1 = new DevExpress.XtraEditors.TextEdit();
            this.cbDisc1Perc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.cbDisc2Perc = new DevExpress.XtraEditors.ComboBoxEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.txtDisc2 = new DevExpress.XtraEditors.TextEdit();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTabPr.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDisc1Perc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDisc2Perc.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Location = new System.Drawing.Point(122, 29);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "รหัส";
            // 
            // txtPriceCode
            // 
            this.txtPriceCode.Location = new System.Drawing.Point(152, 26);
            this.txtPriceCode.Name = "txtPriceCode";
            this.txtPriceCode.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtPriceCode.Properties.Appearance.Options.UseFont = true;
            this.txtPriceCode.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtPriceCode.Properties.MaxLength = 20;
            this.txtPriceCode.Size = new System.Drawing.Size(137, 22);
            this.txtPriceCode.TabIndex = 0;
            this.txtPriceCode.EditValueChanged += new System.EventHandler(this.txtPriceCode_EditValueChanged);
            this.txtPriceCode.Enter += new System.EventHandler(this.textEdit_Enter);
            // 
            // cbTabPr
            // 
            this.cbTabPr.Location = new System.Drawing.Point(152, 76);
            this.cbTabPr.Name = "cbTabPr";
            this.cbTabPr.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbTabPr.Properties.Appearance.Options.UseFont = true;
            this.cbTabPr.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbTabPr.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbTabPr.Size = new System.Drawing.Size(137, 22);
            this.cbTabPr.TabIndex = 2;
            this.cbTabPr.SelectedIndexChanged += new System.EventHandler(this.cbTabPr_SelectedIndexChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl2.Location = new System.Drawing.Point(93, 54);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(51, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "คำอธิบาย";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(152, 51);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDescription.Properties.Appearance.Options.UseFont = true;
            this.txtDescription.Properties.MaxLength = 50;
            this.txtDescription.Size = new System.Drawing.Size(340, 22);
            this.txtDescription.TabIndex = 1;
            this.txtDescription.EditValueChanged += new System.EventHandler(this.txtDescription_EditValueChanged);
            this.txtDescription.Enter += new System.EventHandler(this.textEdit_Enter);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl3.Location = new System.Drawing.Point(67, 79);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(77, 16);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "ใช้ราคาขายที่?";
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl4.Location = new System.Drawing.Point(66, 104);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(78, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "ส่วนลดตามเป้า";
            // 
            // txtDisc1
            // 
            this.txtDisc1.Location = new System.Drawing.Point(151, 101);
            this.txtDisc1.Name = "txtDisc1";
            this.txtDisc1.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDisc1.Properties.Appearance.Options.UseFont = true;
            this.txtDisc1.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDisc1.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDisc1.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtDisc1.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDisc1.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtDisc1.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDisc1.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtDisc1.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDisc1.Properties.DisplayFormat.FormatString = "n2";
            this.txtDisc1.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDisc1.Properties.EditFormat.FormatString = "n2";
            this.txtDisc1.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDisc1.Properties.Mask.EditMask = "n2";
            this.txtDisc1.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDisc1.Properties.MaxLength = 12;
            this.txtDisc1.Size = new System.Drawing.Size(138, 22);
            this.txtDisc1.TabIndex = 3;
            this.txtDisc1.EditValueChanged += new System.EventHandler(this.txtDisc1_EditValueChanged);
            this.txtDisc1.Enter += new System.EventHandler(this.decimalEdit_Enter);
            this.txtDisc1.Leave += new System.EventHandler(this.txtDisc1_Leave);
            // 
            // cbDisc1Perc
            // 
            this.cbDisc1Perc.Location = new System.Drawing.Point(295, 101);
            this.cbDisc1Perc.Name = "cbDisc1Perc";
            this.cbDisc1Perc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbDisc1Perc.Properties.Appearance.Options.UseFont = true;
            this.cbDisc1Perc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDisc1Perc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbDisc1Perc.Size = new System.Drawing.Size(84, 22);
            this.cbDisc1Perc.TabIndex = 4;
            this.cbDisc1Perc.SelectedIndexChanged += new System.EventHandler(this.cbDisc1Perc_SelectedIndexChanged);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl5.Location = new System.Drawing.Point(38, 129);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(106, 16);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "ส่วนลดตัวแทน ตจว.";
            // 
            // cbDisc2Perc
            // 
            this.cbDisc2Perc.Location = new System.Drawing.Point(295, 126);
            this.cbDisc2Perc.Name = "cbDisc2Perc";
            this.cbDisc2Perc.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbDisc2Perc.Properties.Appearance.Options.UseFont = true;
            this.cbDisc2Perc.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbDisc2Perc.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbDisc2Perc.Size = new System.Drawing.Size(84, 22);
            this.cbDisc2Perc.TabIndex = 6;
            this.cbDisc2Perc.SelectedIndexChanged += new System.EventHandler(this.cbDisc2Perc_SelectedIndexChanged);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(164, 171);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(93, 31);
            this.btnOK.TabIndex = 7;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(263, 171);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(93, 31);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            // 
            // txtDisc2
            // 
            this.txtDisc2.Location = new System.Drawing.Point(151, 126);
            this.txtDisc2.Name = "txtDisc2";
            this.txtDisc2.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDisc2.Properties.Appearance.Options.UseFont = true;
            this.txtDisc2.Properties.Appearance.Options.UseTextOptions = true;
            this.txtDisc2.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDisc2.Properties.AppearanceDisabled.Options.UseTextOptions = true;
            this.txtDisc2.Properties.AppearanceDisabled.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDisc2.Properties.AppearanceFocused.Options.UseTextOptions = true;
            this.txtDisc2.Properties.AppearanceFocused.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDisc2.Properties.AppearanceReadOnly.Options.UseTextOptions = true;
            this.txtDisc2.Properties.AppearanceReadOnly.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Far;
            this.txtDisc2.Properties.DisplayFormat.FormatString = "n2";
            this.txtDisc2.Properties.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDisc2.Properties.EditFormat.FormatString = "n2";
            this.txtDisc2.Properties.EditFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.txtDisc2.Properties.Mask.EditMask = "n2";
            this.txtDisc2.Properties.Mask.MaskType = DevExpress.XtraEditors.Mask.MaskType.Numeric;
            this.txtDisc2.Properties.MaxLength = 12;
            this.txtDisc2.Size = new System.Drawing.Size(138, 22);
            this.txtDisc2.TabIndex = 5;
            this.txtDisc2.EditValueChanged += new System.EventHandler(this.txtDisc2_EditValueChanged);
            this.txtDisc2.Enter += new System.EventHandler(this.decimalEdit_Enter);
            this.txtDisc2.Leave += new System.EventHandler(this.txtDisc2_Leave);
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // StpriAddEditDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 216);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.cbDisc2Perc);
            this.Controls.Add(this.cbDisc1Perc);
            this.Controls.Add(this.cbTabPr);
            this.Controls.Add(this.txtDisc2);
            this.Controls.Add(this.txtDisc1);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPriceCode);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StpriAddEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "เพิ่ม/แก้ไข ตารางราคา";
            this.Load += new System.EventHandler(this.StpriAddEditDialog_Load);
            this.Shown += new System.EventHandler(this.StpriAddEditDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txtPriceCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbTabPr.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDescription.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDisc1Perc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbDisc2Perc.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtDisc2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtPriceCode;
        private DevExpress.XtraEditors.ComboBoxEdit cbTabPr;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtDescription;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtDisc1;
        private DevExpress.XtraEditors.ComboBoxEdit cbDisc1Perc;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.ComboBoxEdit cbDisc2Perc;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.TextEdit txtDisc2;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}