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
    public partial class IstabAddEditDialog : DevExpress.XtraEditors.XtraForm
    {
        public enum FORM_MODE
        {
            ADD,
            EDIT
        }

        private MainForm main_form;
        private IstabDialog istab_dialog;
        private IstabVM istab;
        private FORM_MODE form_mode;
        private ISTAB_TABTYP tabtyp;

        public IstabAddEditDialog(IstabDialog istab_dialog, ISTAB_TABTYP tabtyp, IstabVM istab = null)
        {
            InitializeComponent();
            this.main_form = istab_dialog.main_form;
            this.istab_dialog = istab_dialog;
            this.form_mode = istab != null ? FORM_MODE.EDIT : FORM_MODE.ADD;
            this.istab = istab;
            this.tabtyp = tabtyp;
        }

        private void IstabAddEditDialog_Load(object sender, EventArgs e)
        {
            switch (this.tabtyp)
            {
                case ISTAB_TABTYP.QUCOD:
                    this.txtTypCod.Properties.MaxLength = 2;
                    break;
                case ISTAB_TABTYP.LOCCOD:
                    this.txtTypCod.Properties.MaxLength = 4;
                    break;
                case ISTAB_TABTYP.STKGRP:
                    this.txtTypCod.Properties.MaxLength = 4;
                    break;
                case ISTAB_TABTYP.DLVBY:
                    this.txtTypCod.Properties.MaxLength = 2;
                    break;
                case ISTAB_TABTYP.DEPCOD:
                    this.txtTypCod.Properties.MaxLength = 4;
                    break;
                case ISTAB_TABTYP.YOUREF_AR:
                    this.txtTypCod.Properties.MaxLength = 8;
                    break;
                default:
                    this.txtTypCod.Properties.MaxLength = 2;
                    break;
            }

            if (this.form_mode == FORM_MODE.ADD)
            {
                this.Text = "เพิ่ม" + this.tabtyp.GetDescription();
                this.istab = new IstabVM
                {
                    TabTyp = ((int)this.tabtyp).ToString(),
                    TypCod = string.Empty,
                    AbbreviateEn = string.Empty,
                    AbbreviateTh = string.Empty,
                    TypDesEn = string.Empty,
                    TypDesTh = string.Empty,
                    Rate = 0,
                    CreBy = this.main_form.logedin_user.Id
                };
            }

            if (this.form_mode == FORM_MODE.EDIT)
            {
                this.Text = "แก้ไข" + this.tabtyp.GetDescription();
                this.istab = this.istab_dialog.LoadSingleIstabFromServer(this.istab.Id);
                this.istab.ChgBy = this.main_form.logedin_user.Id;

                this.txtTypCod.Enabled = false;
            }

            this.txtTypCod.Text = this.istab.TypCod;
            this.txtAbbrTh.Text = this.istab.AbbreviateTh;
            this.txtAbbrEn.Text = this.istab.AbbreviateEn;
            this.txtTypDesTh.Text = this.istab.TypDesTh;
            this.txtTypDesEn.Text = this.istab.TypDesEn;
        }

        private void IstabAddEditDialog_Shown(object sender, EventArgs e)
        {
            if (this.form_mode == FORM_MODE.EDIT)
                this.txtAbbrTh.SelectionStart = this.txtAbbrTh.Text.Length;
        }

        private void textEdit_Enter(object sender, EventArgs e)
        {
            ((TextEdit)sender).BeginInvoke(new MethodInvoker(delegate
            {
                ((TextEdit)sender).SelectionStart = ((TextEdit)sender).Text.Length;
            }));
        }

        private void txtTypCod_EditValueChanged(object sender, EventArgs e)
        {
            this.istab.TypCod = ((TextEdit)sender).Text;
        }

        private void txtAbbrTh_EditValueChanged(object sender, EventArgs e)
        {
            this.istab.AbbreviateTh = ((TextEdit)sender).Text;
        }

        private void txtAbbrEn_EditValueChanged(object sender, EventArgs e)
        {
            this.istab.AbbreviateEn = ((TextEdit)sender).Text;
        }

        private void txtTypDesTh_EditValueChanged(object sender, EventArgs e)
        {
            this.istab.TypDesTh = ((TextEdit)sender).Text;
        }

        private void txtTypDesEn_EditValueChanged(object sender, EventArgs e)
        {
            this.istab.TypDesEn = ((TextEdit)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.istab.TypCod.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาป้อนรหัส", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtTypCod.Focus();
                return;
            }

            this.splashScreenManager1.ShowWaitForm();
            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.main_form.config.ApiKey,
                istab = this.istab
            };

            if(this.form_mode == FORM_MODE.ADD)
            {
                APIResult post = APIClient.POST(this.main_form.config.ApiUrl + "Istab/AddIstab", acc);
                if (post.Success)
                {
                    this.splashScreenManager1.CloseWaitForm();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.splashScreenManager1.CloseWaitForm();
                    if(MessageBox.Show(post.ErrorMessage.RemoveBeginAndEndQuote(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnOK.PerformClick();
                    }
                }
            }
            else
            {
                APIResult put = APIClient.PUT(this.main_form.config.ApiUrl + "Istab/UpdateIstab", acc);
                if (put.Success)
                {
                    this.splashScreenManager1.CloseWaitForm();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.splashScreenManager1.CloseWaitForm();
                    if (MessageBox.Show(put.ErrorMessage.RemoveBeginAndEndQuote(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnOK.PerformClick();
                    }
                }
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

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}