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
using Newtonsoft.Json;
using SoImporter.MiscClass;
using SoImporter.Model;

namespace SoImporter.SubForm
{
    public partial class UsersDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private List<InternalUsers> users;
        private BindingSource bs;

        public UsersDialog()
        {
            InitializeComponent();
        }

        public UsersDialog(MainForm main_form) : this()
        {
            this.main_form = main_form;
        }

        private void UsersDialog_Load(object sender, EventArgs e)
        {
            this.users = new List<InternalUsers>();
            this.bs = new BindingSource();
            this.bs.DataSource = this.users;
        }

        private void UsersDialog_Shown(object sender, EventArgs e)
        {
            this.RefreshGridUsers();
        }

        private void RefreshGridUsers()
        {
            splashScreenManager1.ShowWaitForm();
            this.users = this.LoadUsersList();
            this.bs.ResetBindings(true);
            this.gridControl1.DataSource = this.users;
            splashScreenManager1.CloseWaitForm();
        }

        private List<InternalUsers> LoadUsersList()
        {
            List<InternalUsers> users = null;
            //string url = this.main_form.config.ApiUrl + "users/" + "?api_key=" + this.main_form.config.ApiKey;
            APIResult result = APIClient.GET(this.main_form.config.ApiUrl + "users/", this.main_form.config.ApiKey);

            if (result.Success && result.ReturnValue != null)
            {
                try
                {
                    users = JsonConvert.DeserializeObject<List<InternalUsers>>(result.ReturnValue);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            return users;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            GridView gridview = sender as GridView;
            if(gridview.GetRow(e.FocusedRowHandle) != null)
            {
                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;
            }
            else
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddEditUserDialog add = new AddEditUserDialog(this.main_form);
            if (add.ShowDialog() == DialogResult.OK)
            {
                this.RefreshGridUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int row_id = (int)this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, colId);

            try
            {
                APIResult result = APIClient.GET(this.main_form.config.ApiUrl + "users/", this.main_form.config.ApiKey, "&id=" + row_id);

                if (result.Success && result.ReturnValue != null)
                {
                    InternalUsers user = JsonConvert.DeserializeObject<InternalUsers>(result.ReturnValue);
                    AddEditUserDialog edit = new AddEditUserDialog(this.main_form, user);
                    edit.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {

        }
    }
}