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
    public partial class StmasImportDialog : DevExpress.XtraEditors.XtraForm
    {
        public MainForm main_form;
        private List<Stmas> stmas_dbf;
        private BindingSource bs;

        public StmasImportDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void StmasImportDialog_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            this.stmas_dbf = MainForm.LoadStmasFromDBF(this.main_form.config);
            this.bs = new BindingSource();
            this.bs.DataSource = this.stmas_dbf;
            this.gridControl1.DataSource = this.bs;

            this.splashScreenManager1.CloseWaitForm();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.gridViewStmas.VisibleColumns[0].Width = 25;
        }

        private void btnBeginImport_Click(object sender, EventArgs e)
        {
            List<Stmas> stmas = new List<Stmas>();
            foreach (var row_handel in this.gridViewStmas.GetSelectedRows())
            {
                stmas.Add(this.stmas_dbf.Where(s => s.stkcod == (string)this.gridViewStmas.GetRowCellValue(row_handel, this.colStkCod)).FirstOrDefault());
            }

            StmasImportProgressDialog import = new StmasImportProgressDialog(this.main_form, stmas);
            import.ShowDialog();
        }
    }
}