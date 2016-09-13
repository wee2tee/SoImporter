using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddUserDialog add = new AddUserDialog(this.main_form);
            if(add.ShowDialog() == DialogResult.OK)
            {
                this.RefreshGridUsers();
            }
        }
    }
}