using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoImporter.Model;
using SoImporter.MiscClass;

namespace SoImporter.SubForm
{
    public partial class RecIvNoDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private string sonum = string.Empty;
        private string ivnum = string.Empty;
        private DateTime? ivdat;

        public RecIvNoDialog(MainForm main_form, string sonum)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.sonum = sonum;
        }

        private void RecIvNoDialog_Load(object sender, EventArgs e)
        {
            this.txtSoNum.Text = this.sonum;
        }

        private void txtIvNum_EditValueChanged(object sender, EventArgs e)
        {
            this.ivnum = ((TextEdit)sender).Text;
        }

        private void dtIvDat_EditValueChanged(object sender, EventArgs e)
        {
            this.ivdat = ((DateEdit)sender).DateTime;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.ivnum.Trim().Length == 0)
            {
                this.txtIvNum.Focus();
                return;
            }

            if (!this.ivdat.HasValue)
            {
                MessageBox.Show("กรุณาระบุวันที่อินวอยซ์", "", MessageBoxButtons.OK);
                this.dtIvDat.Focus();
                return;
            }

            if(this.main_form.UpdateIvNum2Po(this.sonum, this.ivnum, this.ivdat.Value, this.main_form.logedin_user.Id) == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && !(this.btnOK.Focused || this.btnCancel.Focused))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}