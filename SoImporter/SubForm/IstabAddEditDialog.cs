﻿using System;
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
            //this.istab = istab != null ? istab : new IstabVM()
            //{
            //    TypCod = "",
            //    AbbreviateEn = "",
            //    AbbreviateTh = "",
            //    TypDesEn = "",
            //    TypDesTh = "",
            //    Rate = 0
            //};

            //this.istab.TabTyp = tabtyp.ToString();

            
        }

        private void IstabAddEditDialog_Load(object sender, EventArgs e)
        {
            if (this.form_mode == FORM_MODE.ADD)
            {
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if(MessageBox.Show(post.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
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
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    if (MessageBox.Show(put.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnOK.PerformClick();
                    }
                }
            }
        }
    }
}