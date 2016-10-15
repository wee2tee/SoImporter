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
    public partial class StmasImportProgressDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private List<Stmas> stmas;
        private List<Istab> stkgrp;
        private List<Istab> qucod;
        private List<StmasImportVM> stmasvm;

        public StmasImportProgressDialog(MainForm main_form, List<Stmas> stmas)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.stmas = stmas;
        }

        private void ProgressBarDialog_Load(object sender, EventArgs e)
        {
            var istab = MainForm.LoadIstabFromDBF(this.main_form.config);
            this.stkgrp = istab.Where(i => i.tabtyp.Trim() == ((int)ISTAB_TABTYP.STKGRP).ToString()).ToList();
            this.qucod = istab.Where(i => i.tabtyp.Trim() == ((int)ISTAB_TABTYP.QUCOD).ToString()).ToList();

            this.stmasvm = this.stmas.ToViewModel(this.stkgrp, this.qucod);
        }
    }
}