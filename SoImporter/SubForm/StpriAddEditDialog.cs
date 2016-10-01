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
using Newtonsoft.Json;

namespace SoImporter.SubForm
{
    public partial class StpriAddEditDialog : DevExpress.XtraEditors.XtraForm
    {
        private enum FORM_MODE
        {
            ADD,
            EDIT
        }

        private MainForm main_form;
        private StpriDialog stpri_dialog;
        private FORM_MODE form_mode;
        private StpriVM stpri;

        /** Add mode no need stpri to passing;
         *  Edit mode stpri is needed **/
        public StpriAddEditDialog(StpriDialog stpri_dialog, StpriVM stpri = null)
        {
            InitializeComponent();

            this.stpri_dialog = stpri_dialog;
            this.main_form = stpri_dialog.main_form;
            this.stpri = stpri;
            this.form_mode = stpri == null ? FORM_MODE.ADD : FORM_MODE.EDIT;
        }

        private void StpriAddEditDialog_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            foreach (var item in this.GetTabPrObject())
            {
                this.cbTabPr.Properties.Items.Add(item);
            }

            foreach (var item in this.GetIsPercentObject())
            {
                this.cbDisc1Perc.Properties.Items.Add(item);
                this.cbDisc2Perc.Properties.Items.Add(item);
            }

            if (this.form_mode == FORM_MODE.ADD)
            {
                this.Text = "เพิ่มตารางราคา";
                this.stpri = new StpriVM()
                {
                    PriceCode = string.Empty,
                    Description = string.Empty,
                    TabPr = 0,
                    Disc1 = 0,
                    DiscPerc1 = false,
                    Disc2 = 0,
                    DiscPerc2 = false,
                    CreBy = this.main_form.logedin_user.Id
                };
            }

            if (this.form_mode == FORM_MODE.EDIT)
            {
                this.Text = "แก้ไขตารางราคา";
                this.txtPriceCode.Enabled = false;
                this.stpri = this.stpri_dialog.LoadSingleStpriFromServer(this.stpri.Id);

                if(this.stpri == null)
                {
                    this.DialogResult = DialogResult.Cancel;
                    this.Close();
                }
                else
                {
                    this.stpri.ChgBy = this.main_form.logedin_user.Id;
                }
            }
            this.txtPriceCode.Text = this.stpri.PriceCode;
            this.txtDescription.Text = this.stpri.Description;
            this.txtDisc1.Text = this.stpri.Disc1.HasValue ? String.Format("{0:#,#0.00}", this.stpri.Disc1.Value) : "0.00";
            this.txtDisc2.Text = this.stpri.Disc2.HasValue ? String.Format("{0:#,#0.00}", this.stpri.Disc2.Value) : "0.00";
            this.cbTabPr.SelectedIndex = this.cbTabPr.Properties.Items.IndexOf(this.cbTabPr.Properties.Items.Cast<TabPrObj>().Where(t => t.Value == this.stpri.TabPr).FirstOrDefault());
            this.cbDisc1Perc.SelectedIndex = this.cbDisc1Perc.Properties.Items.IndexOf(this.cbDisc1Perc.Properties.Items.Cast<IsPercentObj>().Where(d => d.Value == this.stpri.DiscPerc1).FirstOrDefault());
            this.cbDisc2Perc.SelectedIndex = this.cbDisc2Perc.Properties.Items.IndexOf(this.cbDisc2Perc.Properties.Items.Cast<IsPercentObj>().Where(d => d.Value == this.stpri.DiscPerc2).FirstOrDefault());

            this.splashScreenManager1.CloseWaitForm();
        }

        private void StpriAddEditDialog_Shown(object sender, EventArgs e)
        {
            if (this.form_mode == FORM_MODE.EDIT)
                this.txtDescription.SelectionStart = this.txtDescription.Text.Length;
        }

        private void textEdit_Enter(object sender, EventArgs e)
        {
            ((TextEdit)sender).BeginInvoke(new MethodInvoker(delegate
            {
                ((TextEdit)sender).SelectionStart = ((TextEdit)sender).Text.Length;
            }));
        }

        private void decimalEdit_Enter(object sender, EventArgs e)
        {
            ((TextEdit)sender).BeginInvoke(new MethodInvoker(delegate
            {
                ((TextEdit)sender).SelectionStart = ((TextEdit)sender).Text.Length - 3;
                ((TextEdit)sender).SelectionLength = 0;
            }));
        }

        private void txtPriceCode_EditValueChanged(object sender, EventArgs e)
        {
            this.stpri.PriceCode = ((TextEdit)sender).Text;
        }

        private void txtDescription_EditValueChanged(object sender, EventArgs e)
        {
            this.stpri.Description = ((TextEdit)sender).Text;
        }

        private void cbTabPr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.stpri.TabPr = ((TabPrObj)((ComboBoxEdit)sender).SelectedItem).Value;
        }

        private void txtDisc1_EditValueChanged(object sender, EventArgs e)
        {
            this.stpri.Disc1 = Convert.ToDecimal(((TextEdit)sender).Text.Replace(",", ""));
        }

        private void cbDisc1Perc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.stpri.DiscPerc1 = ((IsPercentObj)((ComboBoxEdit)sender).SelectedItem).Value;
        }

        private void txtDisc2_EditValueChanged(object sender, EventArgs e)
        {
            this.stpri.Disc2 = Convert.ToDecimal(((TextEdit)sender).Text.Replace(",", ""));
        }

        private void cbDisc2Perc_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.stpri.DiscPerc2 = ((IsPercentObj)((ComboBoxEdit)sender).SelectedItem).Value;
        }

        private void txtDisc1_Leave(object sender, EventArgs e)
        {
            ((TextEdit)sender).Text = String.Format("{0:#,#0.00}", ((TextEdit)sender).Text);
        }

        private void txtDisc2_Leave(object sender, EventArgs e)
        {
            ((TextEdit)sender).Text = String.Format("{0:#,#0.00}", ((TextEdit)sender).Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.stpri.PriceCode.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาป้อนรหัส", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtPriceCode.Focus();
                return;
            }
            if(this.stpri.DiscPerc1.Value == true && this.stpri.Disc1 >= 100m)
            {
                if(MessageBox.Show("ส่วนลดตามเป้า กำหนดไว้มากกว่าหรือเท่ากับ 100%, ทำการการบันทึกข้อมูลต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) != DialogResult.OK)
                {
                    return;
                }
            }
            if(this.stpri.DiscPerc2.Value == true && this.stpri.Disc2 >= 100m)
            {
                if (MessageBox.Show("ส่วนลดตัวเทนฯ ต่างจังหวัด กำหนดไว้มากกว่าหรือเท่ากับ 100%, ทำการการบันทึกข้อมูลต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) != DialogResult.OK)
                {
                    return;
                }
            }

            this.splashScreenManager1.ShowWaitForm();
            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.main_form.config.ApiKey,
                stpri = this.stpri
            };

            if (this.form_mode == FORM_MODE.ADD) // Perform Add
            {
                APIResult post = APIClient.POST(this.main_form.config.ApiUrl + "Stpri/AddStpri", acc);
                if (post.Success)
                {
                    this.splashScreenManager1.CloseWaitForm();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.splashScreenManager1.CloseWaitForm();
                    if (MessageBox.Show(post.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnOK.PerformClick();
                    }
                }
            }
            else // Perform Edit
            {
                APIResult put = APIClient.PUT(this.main_form.config.ApiUrl + "Stpri/UpdateStpri", acc);
                if (put.Success)
                {
                    this.splashScreenManager1.CloseWaitForm();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.splashScreenManager1.CloseWaitForm();
                    if (MessageBox.Show(put.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnOK.PerformClick();
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape && !(this.cbTabPr.IsPopupOpen || this.cbDisc1Perc.IsPopupOpen || this.cbDisc2Perc.IsPopupOpen))
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && !(this.btnOK.Focused || this.btnCancel.Focused))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            if(keyData == Keys.F6 && (this.cbTabPr.Focused || this.cbDisc1Perc.Focused || this.cbDisc2Perc.Focused))
            {
                SendKeys.Send("{F4}");
                return true;
            }

            if (keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}