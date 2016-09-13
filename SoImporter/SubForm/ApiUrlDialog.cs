using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SoImporter.SubForm
{
    public partial class ApiUrlDialog : DevExpress.XtraEditors.XtraForm
    {
        public string api_url = string.Empty;
        public string api_key = string.Empty;
        private MainForm main_form;

        public ApiUrlDialog()
        {
            InitializeComponent();
        }

        public ApiUrlDialog(MainForm main_form) : this()
        {
            this.main_form = main_form;
        }

        private void ApiUrlDialog_Load(object sender, EventArgs e)
        {
            if (this.main_form != null)
            {
                this.txtUrl.Text = this.main_form.config.ApiUrl;
                this.txtKey.Text = this.main_form.config.ApiKey;
            }
        }

        private void ApiUrlDialog_Shown(object sender, EventArgs e)
        {
            this.txtUrl.SelectionStart = this.txtUrl.Text.Length;
            this.txtKey.SelectionStart = this.txtKey.Text.Length;
        }

        private void txtUrl_TextChanged(object sender, EventArgs e)
        {
            this.api_url = ((TextEdit)sender).Text;
        }

        private void txtKey_TextChanged(object sender, EventArgs e)
        {
            this.api_key = ((TextEdit)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}