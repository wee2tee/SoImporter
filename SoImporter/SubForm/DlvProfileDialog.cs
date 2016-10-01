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
    public partial class DlvProfileDialog : DevExpress.XtraEditors.XtraForm
    {
        public MainForm main_form;
        private List<DlvProfileVM> dlvprofile;
        private BindingSource bs;

        public DlvProfileDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DlvProfileDialog_Load(object sender, EventArgs e)
        {
            this.dlvprofile = this.LoadDlvProfileFromServer();
            this.bs = new BindingSource();
            this.bs.DataSource = this.dlvprofile;
            this.gridControl1.DataSource = this.bs;
        }

        public DlvProfileVM LoadSingleDlvProfileFromServer(int id)
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "DlvProfile/GetDlvProfileAt", this.main_form.config.ApiKey, "&id=" + id);
            if (get.Success)
            {
                DlvProfileVM dlvprofile = JsonConvert.DeserializeObject<DlvProfileVM>(get.ReturnValue);
                return dlvprofile;
            }
            else
            {
                if (MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadSingleDlvProfileFromServer(id);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<DlvProfileVM> LoadDlvProfileFromServer()
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "DlvProfile/GetDlvProfile", this.main_form.config.ApiKey);
            if (get.Success)
            {
                List<DlvProfileVM> dlvprofile = JsonConvert.DeserializeObject<List<DlvProfileVM>>(get.ReturnValue);
                return dlvprofile;
            }
            else
            {
                if(MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadDlvProfileFromServer();
                }
                else
                {
                    return null;
                }
            }
        }

        private void gridViewDlvProfile_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if(((GridView)sender).GetRow(((GridView)sender).FocusedRowHandle) == null)
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
            else
            {
                this.btnEdit.Enabled = true;
                this.btnEdit.Enabled = true;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.gridViewDlvProfile.GetRow(this.gridViewDlvProfile.FocusedRowHandle) == null)
                return;

            DlvProfileVM dlvprofile = this.dlvprofile.Where(d => d.Id == (int)this.gridViewDlvProfile.GetRowCellValue(this.gridViewDlvProfile.FocusedRowHandle, this.colProfileId)).FirstOrDefault();

            if (dlvprofile == null)
                return;

            Console.WriteLine(" .. >> selected profile is " + dlvprofile.Id + " : " + dlvprofile.TypCod);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }

        private void gridViewDlvProfile_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_add = new MenuItem();
                mnu_add.Text = "เพิ่ม";
                mnu_add.Click += delegate { this.btnAdd.PerformClick(); };

                MenuItem mnu_edit = new MenuItem();
                mnu_edit.Text = "แก้ไข";
                mnu_edit.Click += delegate { this.btnEdit.PerformClick(); };

                MenuItem mnu_delete = new MenuItem();
                mnu_delete.Text = "ลบ";
                mnu_delete.Click += delegate { this.btnDelete.PerformClick(); };

                cm.MenuItems.Add(mnu_add);
                cm.MenuItems.Add(mnu_edit);
                cm.MenuItems.Add(mnu_delete);

                cm.Show(this.gridControl1, new Point(e.X, e.Y));
            }
        }
    }
}