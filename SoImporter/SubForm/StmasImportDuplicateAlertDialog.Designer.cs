namespace SoImporter.SubForm
{
    partial class StmasImportDuplicateAlertDialog
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
            this.btnReplace = new DevExpress.XtraEditors.SimpleButton();
            this.lblWarnning = new DevExpress.XtraEditors.LabelControl();
            this.btnSkip = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // btnReplace
            // 
            this.btnReplace.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnReplace.Appearance.Options.UseFont = true;
            this.btnReplace.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnReplace.Location = new System.Drawing.Point(27, 78);
            this.btnReplace.Name = "btnReplace";
            this.btnReplace.Size = new System.Drawing.Size(177, 31);
            this.btnReplace.TabIndex = 0;
            this.btnReplace.Text = "นำข้อมูลใหม่นี้เข้าไปแทนที่";
            // 
            // lblWarnning
            // 
            this.lblWarnning.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.lblWarnning.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Top;
            this.lblWarnning.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblWarnning.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.lblWarnning.Location = new System.Drawing.Point(27, 24);
            this.lblWarnning.Name = "lblWarnning";
            this.lblWarnning.Size = new System.Drawing.Size(394, 48);
            this.lblWarnning.TabIndex = 1;
            this.lblWarnning.Text = "Wanning";
            // 
            // btnSkip
            // 
            this.btnSkip.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnSkip.Appearance.Options.UseFont = true;
            this.btnSkip.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnSkip.Location = new System.Drawing.Point(210, 78);
            this.btnSkip.Name = "btnSkip";
            this.btnSkip.Size = new System.Drawing.Size(210, 31);
            this.btnSkip.TabIndex = 0;
            this.btnSkip.Text = "คงข้อมูลเดิมไว้, ไม่ต้องเปลี่ยนแปลง";
            // 
            // StmasImportDuplicateAlertDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(446, 131);
            this.Controls.Add(this.lblWarnning);
            this.Controls.Add(this.btnSkip);
            this.Controls.Add(this.btnReplace);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "StmasImportDuplicateAlertDialog";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Load += new System.EventHandler(this.StmasImportDuplicateAlertDialog_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton btnReplace;
        private DevExpress.XtraEditors.LabelControl lblWarnning;
        private DevExpress.XtraEditors.SimpleButton btnSkip;
    }
}