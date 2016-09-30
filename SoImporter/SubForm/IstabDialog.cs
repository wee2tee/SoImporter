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
    public enum ISTAB_TABTYP : int
    {
        QUCOD = 20,
        LOCCOD = 21,
        STKGRP = 22,
        DLVBY = 41,
        DEPCOD = 50
    }

    public partial class IstabDialog : DevExpress.XtraEditors.XtraForm
    {
        public MainForm main_form;
        private List<IstabVM> istab;
        private BindingSource bs;
        private ISTAB_TABTYP tabtyp;

        public IstabDialog(MainForm main_form, ISTAB_TABTYP tabtyp)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.tabtyp = tabtyp;
        }

        private void IstabDialog_Load(object sender, EventArgs e)
        {
            this.istab = this.LoadIstabFromServer();
            this.bs = new BindingSource();
            this.bs.DataSource = this.istab;
            this.gridControl1.DataSource = this.bs;
        }

        public IstabVM LoadSingleIstabFromServer(int id)
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Istab/GetIstabAt", this.main_form.config.ApiKey, "&id=" + id);
            if (get.Success)
            {
                IstabVM istab = JsonConvert.DeserializeObject<IstabVM>(get.ReturnValue);
                return istab;
            }
            else
            {
                if (MessageBox.Show("", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadSingleIstabFromServer(id);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<IstabVM> LoadIstabFromServer()
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Istab/GetIstab", this.main_form.config.ApiKey, "&tabtyp=" + ((int)this.tabtyp).ToString());
            if (get.Success)
            {
                List<IstabVM> istab = JsonConvert.DeserializeObject<List<IstabVM>>(get.ReturnValue);
                return istab;
            }
            else
            {
                if(MessageBox.Show("", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadIstabFromServer();
                }
                else
                {
                    return null;
                }
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            IstabAddEditDialog add = new IstabAddEditDialog(this, this.tabtyp);
            if(add.ShowDialog() == DialogResult.OK)
            {
                this.istab = this.LoadIstabFromServer();
                this.bs.ResetBindings(true);
                this.bs.DataSource = this.istab;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}