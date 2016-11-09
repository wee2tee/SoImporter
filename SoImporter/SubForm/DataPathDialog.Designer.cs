namespace SoImporter.SubForm
{
    partial class DataPathDialog
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
            this.txtDataPath = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse2 = new DevExpress.XtraEditors.SimpleButton();
            this.btnOK = new DevExpress.XtraEditors.SimpleButton();
            this.btnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.cbSoNum = new DevExpress.XtraEditors.ComboBoxEdit();
            this.txtProgramPath = new DevExpress.XtraEditors.TextEdit();
            this.btnBrowse1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.txtDataPath.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSoNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDataPath
            // 
            this.txtDataPath.EditValue = "";
            this.txtDataPath.Location = new System.Drawing.Point(169, 47);
            this.txtDataPath.Name = "txtDataPath";
            this.txtDataPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtDataPath.Properties.Appearance.Options.UseFont = true;
            this.txtDataPath.Properties.ReadOnly = true;
            this.txtDataPath.Size = new System.Drawing.Size(326, 22);
            this.txtDataPath.TabIndex = 0;
            this.txtDataPath.TextChanged += new System.EventHandler(this.txtDataPath_TextChanged);
            // 
            // btnBrowse2
            // 
            this.btnBrowse2.Location = new System.Drawing.Point(496, 47);
            this.btnBrowse2.Name = "btnBrowse2";
            this.btnBrowse2.Size = new System.Drawing.Size(30, 22);
            this.btnBrowse2.TabIndex = 1;
            this.btnBrowse2.TabStop = false;
            this.btnBrowse2.Text = "...";
            this.btnBrowse2.Click += new System.EventHandler(this.btnBrowse2_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnOK.Appearance.Options.UseFont = true;
            this.btnOK.Location = new System.Drawing.Point(183, 119);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 30);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "ตกลง <F9>";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnCancel.Appearance.Options.UseFont = true;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Location = new System.Drawing.Point(285, 119);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(84, 30);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "ยกเลิก <Esc>";
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl2.Location = new System.Drawing.Point(38, 80);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(119, 16);
            this.labelControl2.TabIndex = 1;
            this.labelControl2.Text = "เลขที่เอกสารใบสั่งขาย";
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl1.Location = new System.Drawing.Point(38, 50);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(119, 16);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "ที่เก็บข้อมูล (Express)";
            // 
            // cbSoNum
            // 
            this.cbSoNum.Location = new System.Drawing.Point(169, 77);
            this.cbSoNum.Name = "cbSoNum";
            this.cbSoNum.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.cbSoNum.Properties.Appearance.Options.UseFont = true;
            this.cbSoNum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cbSoNum.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
            this.cbSoNum.Size = new System.Drawing.Size(225, 22);
            this.cbSoNum.TabIndex = 2;
            this.cbSoNum.SelectedIndexChanged += new System.EventHandler(this.cbSoNum_SelectedIndexChanged);
            // 
            // txtProgramPath
            // 
            this.txtProgramPath.EditValue = "";
            this.txtProgramPath.Location = new System.Drawing.Point(169, 18);
            this.txtProgramPath.Name = "txtProgramPath";
            this.txtProgramPath.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.txtProgramPath.Properties.Appearance.Options.UseFont = true;
            this.txtProgramPath.Properties.ReadOnly = true;
            this.txtProgramPath.Size = new System.Drawing.Size(326, 22);
            this.txtProgramPath.TabIndex = 0;
            this.txtProgramPath.TextChanged += new System.EventHandler(this.txtProgramPath_TextChanged);
            // 
            // btnBrowse1
            // 
            this.btnBrowse1.Location = new System.Drawing.Point(496, 18);
            this.btnBrowse1.Name = "btnBrowse1";
            this.btnBrowse1.Size = new System.Drawing.Size(30, 22);
            this.btnBrowse1.TabIndex = 1;
            this.btnBrowse1.TabStop = false;
            this.btnBrowse1.Text = "...";
            this.btnBrowse1.Click += new System.EventHandler(this.btnBrowse1_Click);
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelControl3.Location = new System.Drawing.Point(30, 21);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(127, 16);
            this.labelControl3.TabIndex = 1;
            this.labelControl3.Text = "ที่เก็บโปรแกรม Express";
            // 
            // DataPathDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(553, 164);
            this.Controls.Add(this.cbSoNum);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.btnBrowse1);
            this.Controls.Add(this.btnBrowse2);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.txtProgramPath);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.txtDataPath);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "DataPathDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "กำหนดการเชื่อมต่อโปรแกรม Express";
            this.Load += new System.EventHandler(this.DataPathDialog_Load);
            this.Shown += new System.EventHandler(this.DataPathDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.txtDataPath.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbSoNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtProgramPath.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.TextEdit txtDataPath;
        private DevExpress.XtraEditors.SimpleButton btnBrowse2;
        private DevExpress.XtraEditors.SimpleButton btnOK;
        private DevExpress.XtraEditors.SimpleButton btnCancel;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.ComboBoxEdit cbSoNum;
        private DevExpress.XtraEditors.TextEdit txtProgramPath;
        private DevExpress.XtraEditors.SimpleButton btnBrowse1;
        private DevExpress.XtraEditors.LabelControl labelControl3;
    }
}