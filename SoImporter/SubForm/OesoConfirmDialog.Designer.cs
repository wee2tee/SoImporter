namespace SoImporter.SubForm
{
    partial class OesoConfirmDialog
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
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.btnArmas = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.cbLocCod = new DevExpress.XtraEditors.ComboBoxEdit();
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            this.cbYouref = new DevExpress.XtraEditors.ComboBoxEdit();
            ((System.ComponentModel.ISupportInitialize)(this.cbLocCod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbYouref.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Location = new System.Drawing.Point(21, 23);
            this.labelControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(91, 16);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "หมายเหตุเพิ่มเติม";
            // 
            // btnOK
            // 
            this.btnOK.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(164, 117);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(91, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(261, 117);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 28);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            // 
            // btnArmas
            // 
            this.btnArmas.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnArmas.Appearance.Options.UseFont = true;
            this.btnArmas.Enabled = false;
            this.btnArmas.Location = new System.Drawing.Point(118, 47);
            this.btnArmas.Name = "btnArmas";
            this.btnArmas.Size = new System.Drawing.Size(379, 28);
            this.btnArmas.TabIndex = 1;
            this.btnArmas.Text = "เพิ่มรายละเอียดลูกค้าในโปรแกรม Express";
            this.btnArmas.Click += new System.EventHandler(this.btnArmas_Click);
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl2.Location = new System.Drawing.Point(23, 84);
            this.labelControl2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(89, 16);
            this.labelControl2.TabIndex = 0;
            this.labelControl2.Text = "ตัดสินค้าจากคลัง";
            // 
            // cbLocCod
            // 
            this.cbLocCod.Location = new System.Drawing.Point(118, 81);
            this.cbLocCod.Name = "cbLocCod";
            this.cbLocCod.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbLocCod.Properties.Appearance.Options.UseFont = true;
            this.cbLocCod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbLocCod.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbLocCod.Size = new System.Drawing.Size(215, 22);
            this.cbLocCod.TabIndex = 2;
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // cbYouref
            // 
            this.cbYouref.Location = new System.Drawing.Point(118, 20);
            this.cbYouref.Name = "cbYouref";
            this.cbYouref.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbYouref.Properties.Appearance.Options.UseFont = true;
            this.cbYouref.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbYouref.Size = new System.Drawing.Size(379, 22);
            this.cbYouref.TabIndex = 6;
            this.cbYouref.TextChanged += new System.EventHandler(this.cbYouref_TextChanged);
            // 
            // OesoConfirmDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 160);
            this.Controls.Add(this.cbYouref);
            this.Controls.Add(this.cbLocCod);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnArmas);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl1);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OesoConfirmDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "แปลงเป็นใบสั่งขาย";
            this.Load += new System.EventHandler(this.OesoConfirmDialog_Load);
            ((System.ComponentModel.ISupportInitialize)(this.cbLocCod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbYouref.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.SimpleButton btnArmas;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.ComboBoxEdit cbLocCod;
        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraEditors.ComboBoxEdit cbYouref;
    }
}