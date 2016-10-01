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
    public partial class DealerEditDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private DealerDialog dealer_dialog;
        private string dealer_id;
        private DealerVM dealer;
        private List<StpriVM> stpri;
        private List<DlvProfileVM> dlvprofile;

        public DealerEditDialog(DealerDialog dealer_dialog, DealerVM dealer, List<StpriVM> stpri, List<DlvProfileVM> dlvprofile)
        {
            InitializeComponent();
            this.main_form = dealer_dialog.main_form;
            this.dealer_dialog = dealer_dialog;
            this.dealer_id = dealer.Id;
            //this.dealer = dealer;
            this.stpri = stpri;
            this.dlvprofile = dlvprofile;
        }

        private void DealerEditDialog_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            this.dealer = this.dealer_dialog.LoadSingerDealerFromServer(this.dealer_id);
            if(this.dealer == null)
            {
                this.DialogResult = DialogResult.Cancel;
                this.Close();
                return;
            }

            foreach (var item in this.GetDealerTypeObject())
            {
                this.cbDealerType.Properties.Items.Add(item);
            }

            foreach (var item in this.GetDealerStatusObject())
            {
                this.cbStatus.Properties.Items.Add(item);
            }

            foreach (var item in this.stpri)
            {
                this.cbPriceCode.Properties.Items.Add(item);
            }

            foreach (var item in this.dlvprofile)
            {
                this.cbDlvProfile.Properties.Items.Add(item);
            }

            /** Display value in each control **/
            this.txtDealerCode.Text = this.dealer.DealerCode;

            this.cbDealerType.SelectedIndex = this.cbDealerType.Properties.Items.IndexOf(this.cbDealerType.Properties.Items.Cast<DealerTypeObj>().Where(d => d.Value == this.dealer.DealerType).FirstOrDefault());

            this.cbPriceCode.SelectedIndex = this.cbPriceCode.Properties.Items.IndexOf(this.cbPriceCode.Properties.Items.Cast<StpriVM>().Where(p => p.PriceCode == this.dealer.PriceCode).FirstOrDefault());

            this.cbDlvProfile.SelectedIndex = this.cbDlvProfile.Properties.Items.IndexOf(this.cbDlvProfile.Properties.Items.Cast<DlvProfileVM>().Where(d => d.Id == this.dealer.DlvProfile).FirstOrDefault());

            this.cbStatus.SelectedIndex = this.cbStatus.Properties.Items.IndexOf(this.cbStatus.Properties.Items.Cast<DealerStatusObj>().Where(d => d.Value == this.dealer.Status).FirstOrDefault());

            this.txtSN.Text = this.dealer.SerNum;
            this.txtPreName.Text = this.dealer.PreName;
            this.txtName.Text = this.dealer.FullName;
            this.txtAddr01.Text = this.dealer.Addr01;
            this.txtAddr02.Text = this.dealer.Addr02;
            this.txtAddr03.Text = this.dealer.Addr03;
            this.txtZipCod.Text = this.dealer.ZipCod;
            this.txtTaxId.Text = this.dealer.TaxId;
            this.txtTelNum.Text = this.dealer.TelNum;
            this.txtFaxNum.Text = this.dealer.FaxNum;
            this.txtEmail.Text = this.dealer.UserName;

            this.splashScreenManager1.CloseWaitForm();
        }

        private void textEdit_Enter(object sender, EventArgs e)
        {
            ((TextEdit)sender).BeginInvoke(new MethodInvoker(delegate
            {
                ((TextEdit)sender).SelectionStart = ((TextEdit)sender).Text.Length;
            }));
        }

        private void txtDealerCode_EditValueChanged(object sender, EventArgs e)
        {
            this.dealer.DealerCode = ((TextEdit)sender).Text;
        }

        private void cbDealerType_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dealer.DealerType = ((DealerTypeObj)((ComboBoxEdit)sender).SelectedItem).Value;
        }

        private void cbPriceCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dealer.PriceCode = ((StpriVM)((ComboBoxEdit)sender).SelectedItem).PriceCode;
        }

        private void cbDlvProfile_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dealer.DlvProfile = ((DlvProfileVM)((ComboBoxEdit)sender).SelectedItem).Id;
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.dealer.Status = ((DealerStatusObj)((ComboBoxEdit)sender).SelectedItem).Value;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.dealer.DealerCode.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาระบุรหัสตัวแทนฯ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtDealerCode.Focus();
                return;
            }
            if(this.dealer.DealerType == null)
            {
                MessageBox.Show("กรุณาระบุประเภทตัวแทนฯ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.cbDealerType.Focus();
                return;
            }
            if(this.dealer.PriceCode.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาระบุตารางราคา", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.cbPriceCode.Focus();
                return;
            }
            if(this.dealer.DlvProfile == null)
            {
                MessageBox.Show("กรุณาระบุกลุ่มวิธีการจัดส่ง", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.cbDlvProfile.Focus();
                return;
            }
            if(this.dealer.Status.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาระบุสถานะ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.cbStatus.Focus();
                return;
            }
                
            this.splashScreenManager1.ShowWaitForm();
            ApiAccessibilities acc = new ApiAccessibilities()
            {
                API_KEY = this.main_form.config.ApiKey,
                dealer = this.dealer
            };

            APIResult put = APIClient.PUT(this.main_form.config.ApiUrl + "Dealers/Update", acc);
            if (put.Success)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                if(MessageBox.Show(put.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    this.btnOK.PerformClick();
                }
            }

            this.splashScreenManager1.CloseWaitForm();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape && !(this.cbDealerType.IsPopupOpen || this.cbPriceCode.IsPopupOpen || this.cbDlvProfile.IsPopupOpen || this.cbStatus.IsPopupOpen))
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && !(this.btnOK.Focused || this.btnCancel.Focused))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            if(keyData == Keys.F6 && (this.cbDealerType.Focused || this.cbDlvProfile.Focused || this.cbPriceCode.Focused || this.cbStatus.Focused))
            {
                SendKeys.Send("{F4}");
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void btnListPriceCode_Click(object sender, EventArgs e)
        {
            StpriDialog stpri = new StpriDialog(this.main_form);
            stpri.ShowDialog();
        }
    }
}