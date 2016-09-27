using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoImporter.MiscClass;
using SoImporter.Model;

namespace SoImporter.SubForm
{
    public partial class RecEmsTrackingDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private string ivnum;
        private string ems;

        public RecEmsTrackingDialog(MainForm main_form, string ivnum)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.ivnum = ivnum;
        }

        private void RecEmsTrackingDialog_Load(object sender, EventArgs e)
        {
            this.txtIvNum.Text = this.ivnum;
        }

        private void txtEms_EditValueChanged(object sender, EventArgs e)
        {
            this.ems = ((TextEdit)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.ems.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาป้อนหมายเลข EMS Tracking", "", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

            if(this.main_form.UpdateEmsTracking(this.ivnum, this.ems) == true)
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