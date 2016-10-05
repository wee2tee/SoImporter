namespace SoImporter.SubForm
{
    partial class UsersDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UsersDialog));
            this.splashScreenManager1 = new DevExpress.XtraSplashScreen.SplashScreenManager(this, typeof(global::SoImporter.SubForm.WaitForm), true, true);
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEmail = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPasswordHash = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFullName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepartment = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnAdd = new DevExpress.XtraEditors.SimpleButton();
            this.btnEdit = new DevExpress.XtraEditors.SimpleButton();
            this.btnDelete = new DevExpress.XtraEditors.SimpleButton();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.btnChangePwd = new DevExpress.XtraEditors.SimpleButton();
            this.btnResetPwd = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splashScreenManager1
            // 
            this.splashScreenManager1.ClosingDelay = 500;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(771, 297);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.ColumnPanelRowHeight = 28;
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colUserName,
            this.colEmail,
            this.colPasswordHash,
            this.colFullName,
            this.colDepartment,
            this.colStatus,
            this.colCreDate});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.RowCellClick += new DevExpress.XtraGrid.Views.Grid.RowCellClickEventHandler(this.gridView1_RowCellClick);
            this.gridView1.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.gridView1_FocusedRowChanged);
            // 
            // colId
            // 
            this.colId.Caption = "gridColumn1";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colUserName
            // 
            this.colUserName.Caption = "รหัสผู้ใช้";
            this.colUserName.FieldName = "UserName";
            this.colUserName.Name = "colUserName";
            this.colUserName.Visible = true;
            this.colUserName.VisibleIndex = 0;
            // 
            // colEmail
            // 
            this.colEmail.Caption = "อีเมล์";
            this.colEmail.FieldName = "Email";
            this.colEmail.Name = "colEmail";
            // 
            // colPasswordHash
            // 
            this.colPasswordHash.Caption = "gridColumn1";
            this.colPasswordHash.FieldName = "PasswordHash";
            this.colPasswordHash.Name = "colPasswordHash";
            // 
            // colFullName
            // 
            this.colFullName.Caption = "ชื่อ";
            this.colFullName.FieldName = "FullName";
            this.colFullName.Name = "colFullName";
            this.colFullName.Visible = true;
            this.colFullName.VisibleIndex = 1;
            // 
            // colDepartment
            // 
            this.colDepartment.Caption = "แผนก";
            this.colDepartment.FieldName = "Department";
            this.colDepartment.Name = "colDepartment";
            this.colDepartment.Visible = true;
            this.colDepartment.VisibleIndex = 2;
            // 
            // colStatus
            // 
            this.colStatus.Caption = "สถานะ";
            this.colStatus.FieldName = "Status";
            this.colStatus.Name = "colStatus";
            this.colStatus.Visible = true;
            this.colStatus.VisibleIndex = 3;
            // 
            // colCreDate
            // 
            this.colCreDate.Caption = "สร้างเมือ";
            this.colCreDate.DisplayFormat.FormatString = "dd/MM/yy HH:mm:ss";
            this.colCreDate.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
            this.colCreDate.FieldName = "CreDate";
            this.colCreDate.Name = "colCreDate";
            this.colCreDate.Visible = true;
            this.colCreDate.VisibleIndex = 4;
            // 
            // btnAdd
            // 
            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAdd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnAdd.Appearance.Options.UseFont = true;
            this.btnAdd.Image = ((System.Drawing.Image)(resources.GetObject("btnAdd.Image")));
            this.btnAdd.Location = new System.Drawing.Point(568, 13);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(69, 28);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "เพิ่ม";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEdit.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnEdit.Appearance.Options.UseFont = true;
            this.btnEdit.Enabled = false;
            this.btnEdit.Image = ((System.Drawing.Image)(resources.GetObject("btnEdit.Image")));
            this.btnEdit.Location = new System.Drawing.Point(643, 13);
            this.btnEdit.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(69, 28);
            this.btnEdit.TabIndex = 1;
            this.btnEdit.Text = "แก้ไข";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDelete.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnDelete.Appearance.Options.UseFont = true;
            this.btnDelete.Enabled = false;
            this.btnDelete.Image = ((System.Drawing.Image)(resources.GetObject("btnDelete.Image")));
            this.btnDelete.Location = new System.Drawing.Point(718, 13);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(69, 28);
            this.btnDelete.TabIndex = 1;
            this.btnDelete.Text = "ลบ";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // panelControl1
            // 
            this.panelControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panelControl1.Controls.Add(this.gridControl1);
            this.panelControl1.Location = new System.Drawing.Point(12, 48);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(775, 301);
            this.panelControl1.TabIndex = 2;
            // 
            // btnChangePwd
            // 
            this.btnChangePwd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnChangePwd.Appearance.Options.UseFont = true;
            this.btnChangePwd.Image = global::SoImporter.Properties.Resources.Key;
            this.btnChangePwd.Location = new System.Drawing.Point(14, 13);
            this.btnChangePwd.Name = "btnChangePwd";
            this.btnChangePwd.Size = new System.Drawing.Size(115, 28);
            this.btnChangePwd.TabIndex = 3;
            this.btnChangePwd.Text = "เปลี่ยนรหัสผ่าน";
            this.btnChangePwd.Click += new System.EventHandler(this.btnChangePwd_Click);
            // 
            // btnResetPwd
            // 
            this.btnResetPwd.Appearance.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.btnResetPwd.Appearance.Options.UseFont = true;
            this.btnResetPwd.Image = ((System.Drawing.Image)(resources.GetObject("btnResetPwd.Image")));
            this.btnResetPwd.Location = new System.Drawing.Point(135, 13);
            this.btnResetPwd.Name = "btnResetPwd";
            this.btnResetPwd.Size = new System.Drawing.Size(115, 28);
            this.btnResetPwd.TabIndex = 3;
            this.btnResetPwd.Text = "รีเซ็ตรหัสผ่าน";
            this.btnResetPwd.Click += new System.EventHandler(this.btnResetPwd_Click);
            // 
            // UsersDialog
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(801, 361);
            this.Controls.Add(this.btnResetPwd);
            this.Controls.Add(this.btnChangePwd);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MinimumSize = new System.Drawing.Size(550, 243);
            this.Name = "UsersDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Users";
            this.Load += new System.EventHandler(this.UsersDialog_Load);
            this.Shown += new System.EventHandler(this.UsersDialog_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraSplashScreen.SplashScreenManager splashScreenManager1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.SimpleButton btnAdd;
        private DevExpress.XtraEditors.SimpleButton btnEdit;
        private DevExpress.XtraEditors.SimpleButton btnDelete;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colEmail;
        private DevExpress.XtraGrid.Columns.GridColumn colPasswordHash;
        private DevExpress.XtraGrid.Columns.GridColumn colFullName;
        private DevExpress.XtraGrid.Columns.GridColumn colDepartment;
        private DevExpress.XtraGrid.Columns.GridColumn colCreDate;
        private DevExpress.XtraGrid.Columns.GridColumn colUserName;
        private DevExpress.XtraGrid.Columns.GridColumn colStatus;
        private DevExpress.XtraEditors.SimpleButton btnChangePwd;
        private DevExpress.XtraEditors.SimpleButton btnResetPwd;
    }
}