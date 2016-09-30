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
    public partial class StpriDialog : DevExpress.XtraEditors.XtraForm
    {
        public MainForm main_form;
        private BindingSource bs;
        public List<StpriVM> stpri;
        public StpriVM selected_stpri;

        public StpriDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void StpriDialog_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            this.bs = new BindingSource();
            this.stpri = this.LoadStpriFromServer();
            this.bs.DataSource = this.stpri;
            this.gridControl1.DataSource = this.bs;

            this.splashScreenManager1.CloseWaitForm();
        }

        public StpriVM LoadSingleStpriFromServer(int id)
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Stpri/GetStpriAt", this.main_form.config.ApiKey, "&id=" + id);
            if (get.Success)
            {
                StpriVM stpri = JsonConvert.DeserializeObject<StpriVM>(get.ReturnValue);

                return stpri;
            }
            else
            {
                if (MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return LoadSingleStpriFromServer(id);
                }

                return null;
            }
        }

        public List<StpriVM> LoadStpriFromServer()
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Stpri/GetStpri", this.main_form.config.ApiKey);
            if (get.Success)
            {
                List<StpriVM> stpri = JsonConvert.DeserializeObject<List<StpriVM>>(get.ReturnValue);

                return stpri;
            }
            else
            {
                if(MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                     return LoadStpriFromServer();
                }

                return null;
            }
        }

        private void gridViewStpri_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (((GridView)sender).GetRow(e.FocusedRowHandle) == null)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
            else
            {
                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            StpriAddEditDialog st = new StpriAddEditDialog(this);
            if (st.ShowDialog() == DialogResult.OK)
            {
                this.stpri = this.LoadStpriFromServer();
                this.bs.ResetBindings(true);
                this.bs.DataSource = this.stpri;
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.gridViewStpri.GetRow(this.gridViewStpri.FocusedRowHandle) == null)
                return;

            StpriVM stpri = this.stpri.Where(s => s.Id == (int)this.gridViewStpri.GetRowCellValue(this.gridViewStpri.FocusedRowHandle, this.colId)).FirstOrDefault();

            StpriAddEditDialog st = new StpriAddEditDialog(this, stpri);
            if(st.ShowDialog() == DialogResult.OK)
            {
                this.stpri = this.LoadStpriFromServer();
                this.bs.ResetBindings(true);
                this.bs.DataSource = this.stpri;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.gridViewStpri.GetRow(this.gridViewStpri.FocusedRowHandle) == null)
                return;

            StpriVM stpri = this.stpri.Where(s => s.Id == (int)this.gridViewStpri.GetRowCellValue(this.gridViewStpri.FocusedRowHandle, this.colId)).FirstOrDefault();

            if (MessageBox.Show("ลบรหัส \"" + stpri.PriceCode + "\" ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
                return;

            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.main_form.config.ApiKey,
                stpri = stpri
            };

            APIResult delete = APIClient.DELETE(this.main_form.config.ApiUrl + "Stpri/DeleteStpri", acc);
            if (delete.Success)
            {
                this.stpri = this.LoadStpriFromServer();
                this.bs.ResetBindings(true);
                this.bs.DataSource = this.stpri;
            }
            else
            {
                if(MessageBox.Show(delete.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    this.btnDelete.PerformClick();
                }
            }
        }

        private void gridViewStpri_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_edit = new MenuItem();
                mnu_edit.Text = "แก้ไข";
                mnu_edit.Click += delegate
                {
                    this.btnEdit.PerformClick();
                };
                MenuItem mnu_delete = new MenuItem();
                mnu_delete.Text = "ลบ";
                mnu_delete.Click += delegate
                {
                    this.btnDelete.PerformClick();
                };

                cm.MenuItems.Add(mnu_edit);
                cm.MenuItems.Add(mnu_delete);
                cm.Show(this.gridControl1, new Point(e.X, e.Y));
            }
        }
    }
}