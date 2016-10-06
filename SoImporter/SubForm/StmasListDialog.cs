using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;
using SoImporter.Model;
using SoImporter.MiscClass;
using Newtonsoft.Json;

namespace SoImporter.SubForm
{
    public partial class StmasListDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private StmasDialog stmas_dialog;
        private List<StmasVM> stmas_list;
        private BindingSource bs;

        public StmasVM selected_stmas;

        public StmasListDialog(StmasDialog stmas_dialog, StmasVM stmas = null)
        {
            InitializeComponent();
            this.stmas_dialog = stmas_dialog;
            this.main_form = stmas_dialog.main_form;
            this.selected_stmas = stmas;
        }

        private void StmasListDialog_Load(object sender, EventArgs e)
        {
            this.stmas_list = this.stmas_dialog.LoadStmasFromServer();
            this.bs = new BindingSource();
            this.bs.DataSource = this.stmas_list;
            this.gridControl1.DataSource = this.bs;

            if (this.selected_stmas != null)
            {
                int ndx = this.stmas_list.IndexOf(this.stmas_list.Find(s => s.Id == this.selected_stmas.Id));
                this.gridViewStmas.FocusedRowHandle = ndx;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.gridViewStmas.GetRow(this.gridViewStmas.FocusedRowHandle) == null)
                return;

            this.selected_stmas = this.stmas_list.Where(s => s.Id == (int)this.gridViewStmas.GetRowCellValue(this.gridViewStmas.FocusedRowHandle, this.colId)).FirstOrDefault();

            if (this.selected_stmas == null)
                return;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void gridViewStmas_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                this.btnOK.PerformClick();
                e.Handled = true;
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Enter && !this.btnCancel.Focused)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}