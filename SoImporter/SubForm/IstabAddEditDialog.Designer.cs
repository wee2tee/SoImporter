namespace SoImporter.SubForm
{
    partial class IstabAddEditDialog
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
            this.txtTypCod = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.txtAbbrTh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.txtAbbrEn = new DevExpress.XtraEditors.TextEdit();
            this.labelControl4 = new DevExpress.XtraEditors.LabelControl();
            this.txtTypDesTh = new DevExpress.XtraEditors.TextEdit();
            this.labelControl5 = new DevExpress.XtraEditors.LabelControl();
            this.txtTypDesEn = new DevExpress.XtraEditors.TextEdit();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            ((System.ComponentModel.ISupportInitialize)(this.txtTypCod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbrTh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbrEn.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypDesTh.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypDesEn.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Location = new System.Drawing.Point(87, 25);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(22, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "รหัส";
            // 
            // txtTypCod
            // 
            this.txtTypCod.Location = new System.Drawing.Point(122, 22);
            this.txtTypCod.Name = "txtTypCod";
            this.txtTypCod.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTypCod.Properties.Appearance.Options.UseFont = true;
            this.txtTypCod.Properties.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtTypCod.Properties.MaxLength = 8;
            this.txtTypCod.Size = new System.Drawing.Size(80, 22);
            this.txtTypCod.TabIndex = 0;
            this.txtTypCod.EditValueChanged += new System.EventHandler(this.txtTypCod_EditValueChanged);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl2.Location = new System.Drawing.Point(39, 50);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(70, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "ชื่อย่อ (ไทย)";
            // 
            // txtAbbrTh
            // 
            this.txtAbbrTh.Location = new System.Drawing.Point(122, 47);
            this.txtAbbrTh.Name = "txtAbbrTh";
            this.txtAbbrTh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAbbrTh.Properties.Appearance.Options.UseFont = true;
            this.txtAbbrTh.Properties.MaxLength = 20;
            this.txtAbbrTh.Size = new System.Drawing.Size(157, 22);
            this.txtAbbrTh.TabIndex = 1;
            this.txtAbbrTh.EditValueChanged += new System.EventHandler(this.txtAbbrTh_EditValueChanged);
            this.txtAbbrTh.Enter += new System.EventHandler(this.textEdit_Enter);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl3.Location = new System.Drawing.Point(38, 75);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(71, 16);
            this.labelControl3.TabIndex = 0;
            this.labelControl3.Text = "ชื่อย่อ (Eng.)";
            // 
            // txtAbbrEn
            // 
            this.txtAbbrEn.Location = new System.Drawing.Point(122, 72);
            this.txtAbbrEn.Name = "txtAbbrEn";
            this.txtAbbrEn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtAbbrEn.Properties.Appearance.Options.UseFont = true;
            this.txtAbbrEn.Properties.MaxLength = 20;
            this.txtAbbrEn.Size = new System.Drawing.Size(157, 22);
            this.txtAbbrEn.TabIndex = 2;
            this.txtAbbrEn.EditValueChanged += new System.EventHandler(this.txtAbbrEn_EditValueChanged);
            this.txtAbbrEn.Enter += new System.EventHandler(this.textEdit_Enter);
            // 
            // labelControl4
            // 
            this.labelControl4.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl4.Location = new System.Drawing.Point(35, 100);
            this.labelControl4.Name = "labelControl4";
            this.labelControl4.Size = new System.Drawing.Size(74, 16);
            this.labelControl4.TabIndex = 0;
            this.labelControl4.Text = "ชื่อเต็ม (ไทย)";
            // 
            // txtTypDesTh
            // 
            this.txtTypDesTh.Location = new System.Drawing.Point(122, 97);
            this.txtTypDesTh.Name = "txtTypDesTh";
            this.txtTypDesTh.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTypDesTh.Properties.Appearance.Options.UseFont = true;
            this.txtTypDesTh.Properties.MaxLength = 50;
            this.txtTypDesTh.Size = new System.Drawing.Size(373, 22);
            this.txtTypDesTh.TabIndex = 3;
            this.txtTypDesTh.EditValueChanged += new System.EventHandler(this.txtTypDesTh_EditValueChanged);
            this.txtTypDesTh.Enter += new System.EventHandler(this.textEdit_Enter);
            // 
            // labelControl5
            // 
            this.labelControl5.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl5.Location = new System.Drawing.Point(34, 125);
            this.labelControl5.Name = "labelControl5";
            this.labelControl5.Size = new System.Drawing.Size(75, 16);
            this.labelControl5.TabIndex = 0;
            this.labelControl5.Text = "ชื่อเต็ม (Eng.)";
            // 
            // txtTypDesEn
            // 
            this.txtTypDesEn.Location = new System.Drawing.Point(122, 122);
            this.txtTypDesEn.Name = "txtTypDesEn";
            this.txtTypDesEn.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtTypDesEn.Properties.Appearance.Options.UseFont = true;
            this.txtTypDesEn.Properties.MaxLength = 50;
            this.txtTypDesEn.Size = new System.Drawing.Size(373, 22);
            this.txtTypDesEn.TabIndex = 4;
            this.txtTypDesEn.EditValueChanged += new System.EventHandler(this.txtTypDesEn_EditValueChanged);
            this.txtTypDesEn.Enter += new System.EventHandler(this.textEdit_Enter);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(174, 167);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 30);
            this.btnOK.TabIndex = 5;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(267, 167);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 30);
            this.btnCancel.TabIndex = 6;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // IstabAddEditDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 213);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtTypDesEn);
            this.Controls.Add(this.txtTypDesTh);
            this.Controls.Add(this.txtAbbrEn);
            this.Controls.Add(this.txtAbbrTh);
            this.Controls.Add(this.labelControl5);
            this.Controls.Add(this.labelControl4);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtTypCod);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "IstabAddEditDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Add/Edit Istab";
            this.Load += new System.EventHandler(this.IstabAddEditDialog_Load);
            this.Shown += new System.EventHandler(this.IstabAddEditDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txtTypCod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbrTh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtAbbrEn.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypDesTh.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTypDesEn.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTypCod;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.TextEdit txtAbbrTh;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.TextEdit txtAbbrEn;
        private DevExpress.XtraEditors.LabelControl labelControl4;
        private DevExpress.XtraEditors.TextEdit txtTypDesTh;
        private DevExpress.XtraEditors.LabelControl labelControl5;
        private DevExpress.XtraEditors.TextEdit txtTypDesEn;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
    }
}