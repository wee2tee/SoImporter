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
            this.Text = this.tabtyp.GetDescription();
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

        private void gridViewIstab_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
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
            if (this.gridViewIstab.GetRow(this.gridViewIstab.FocusedRowHandle) == null)
                return;

            IstabVM istab = this.istab.Where(i => i.Id == (int)this.gridViewIstab.GetRowCellValue(this.gridViewIstab.FocusedRowHandle, this.colId)).FirstOrDefault();

            if (istab == null)
                return;

            IstabAddEditDialog edit = new IstabAddEditDialog(this, this.tabtyp, istab);
            if(edit.ShowDialog() == DialogResult.OK)
            {
                this.istab = this.LoadIstabFromServer();
                this.bs.ResetBindings(true);
                this.bs.DataSource = this.istab;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (this.gridViewIstab.GetRow(this.gridViewIstab.FocusedRowHandle) == null)
                return;

            IstabVM istab = this.istab.Where(i => i.Id == (int)this.gridViewIstab.GetRowCellValue(this.gridViewIstab.FocusedRowHandle, this.colId)).FirstOrDefault();

            if (istab == null)
                return;

            if(MessageBox.Show("ลบรหัส \"" + istab.TypCod + "\" ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.splashScreenManager1.ShowWaitForm();

                ApiAccessibilities acc = new ApiAccessibilities
                {
                    API_KEY = this.main_form.config.ApiKey,
                    istab = istab
                };
                APIResult delete = APIClient.DELETE(this.main_form.config.ApiUrl + "Istab/DeleteIstab", acc);
                if (delete.Success)
                {
                    this.istab = this.LoadIstabFromServer();
                    this.bs.ResetBindings(true);
                    this.bs.DataSource = this.istab;
                    this.splashScreenManager1.CloseWaitForm();
                }
                else
                {
                    this.splashScreenManager1.CloseWaitForm();
                    if(MessageBox.Show(delete.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnDelete.PerformClick();
                    }
                }
            }
        }

        private void gridViewIstab_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem();
                mnu_add.Text = "เพิ่ม";
                mnu_add.Click += delegate
                {
                    this.btnAdd.PerformClick();
                };
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

                cm.MenuItems.Add(mnu_add);
                cm.MenuItems.Add(mnu_edit);
                cm.MenuItems.Add(mnu_delete);

                cm.Show(this.gridControl1, new Point(e.X, e.Y));

                e.Handled = true;
            }

            if(e.Button == MouseButtons.Left && e.Clicks == 2) // Double click with left button
            {
                this.btnEdit.PerformClick();
                e.Handled = true;
            }
        }
    }
}