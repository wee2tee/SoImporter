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
    public partial class OesoConfirmDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private Oeso oeso;
        private Armas armas;
        private int? dealer_type;

        public OesoConfirmDialog()
        {
            InitializeComponent();
        }

        public OesoConfirmDialog(MainForm main_form, Oeso oeso, Armas armas, int? dealer_type) : this()
        {
            this.main_form = main_form;
            this.oeso = oeso;
            this.armas = armas;
            this.dealer_type = dealer_type;
        }

        private void OesoConfirmDialog_Load(object sender, EventArgs e)
        {
            if (this.dealer_type == (int)DEALER_TYPE.สำนักงานบัญชีไฮเทค)
            {
                this.btnArmas.Enabled = true;
            }
        }

        private void txtRemark_EditValueChanged(object sender, EventArgs e)
        {
            this.oeso.youref = ((TextEdit)sender).Text;
        }

        private void btnArmas_Click(object sender, EventArgs e)
        {
            ArMasDialog ar = new ArMasDialog(this.main_form, this.armas);
            if (ar.ShowDialog() == DialogResult.OK)
            {
                this.oeso.cuscod = ar.armas.cuscod;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.oeso.cuscod == null || this.oeso.cuscod.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาเพิ่มรายละเอียดลูกค้าก่อน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if (keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if (keyData == Keys.Enter && !(this.btnOK.Focused || this.btnCancel.Focused || this.btnArmas.Focused))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);

        }
    }
}