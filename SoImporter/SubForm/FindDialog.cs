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
    public partial class FindDialog : DevExpress.XtraEditors.XtraForm
    {
        public string key_word = string.Empty;

        private string keyword_label = string.Empty;
        private string default_keyword = string.Empty;

        public FindDialog(string keyword_label, string default_keyword = "")
        {
            InitializeComponent();
            this.keyword_label = keyword_label;
            this.default_keyword = default_keyword;
        }

        private void FindDialog_Load(object sender, EventArgs e)
        {
            this.lblKeyWord.Text = this.keyword_label;
        }

        private void txtKeyWord_EditValueChanged(object sender, EventArgs e)
        {
            this.btnOK.Enabled = ((string)((TextEdit)sender).EditValue).Trim().Length == 0 ? false : true;
            this.key_word = (string)((TextEdit)sender).EditValue;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && !(this.btnCancel.Focused))
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}