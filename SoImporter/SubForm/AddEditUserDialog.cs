using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoImporter.MiscClass;
using SoImporter.Model;
using Crypto;
using Newtonsoft.Json;

namespace SoImporter.SubForm
{
    public partial class AddEditUserDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        //private string user_name, full_name, department, status;
        private InternalUsers user = null;
        private FORM_MODE form_mode;

        public enum FORM_MODE
        {
            ADD,
            EDIT
        }

        public AddEditUserDialog()
        {
            InitializeComponent();
        }

        public AddEditUserDialog(MainForm main_form) : this()
        {
            this.main_form = main_form;
            this.form_mode = FORM_MODE.ADD;
        }

        public AddEditUserDialog(MainForm main_form, InternalUsers user = null) : this()
        {
            this.main_form = main_form;
            this.form_mode = FORM_MODE.EDIT;
            this.user = user;
        }

        private void AddUserDialog_Load(object sender, EventArgs e)
        {
            switch (this.form_mode)
            {
                case FORM_MODE.ADD:
                    this.Text = "Add User";
                    break;
                case FORM_MODE.EDIT:
                    this.Text = "Edit User";
                    break;
                default:
                    this.Text = "Add User";
                    break;
            }

            foreach (var item in Enum.GetValues(typeof(InternalUsers.DEPARTMENT)))
            {
                this.cbDepartment.Properties.Items.Add(item);
            }
            foreach (var item in Enum.GetValues(typeof(InternalUsers.STATUS)))
            {
                this.cbStatus.Properties.Items.Add(item);
            }

            if (this.user != null)
            {
                this.txtUserName.Enabled = false;
                this.txtUserName.Text = this.user.UserName;
                this.txtFullName.Text = this.user.FullName;
                this.cbDepartment.Text = this.user.Department;
                this.cbStatus.Text = this.user.Status;
            }
            else
            {
                this.user = new InternalUsers();
                this.cbDepartment.SelectedIndex = 0;
                this.cbStatus.SelectedIndex = 0;
            }
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.user.UserName = ((TextEdit)sender).Text;
        }

        private void txtFullName_TextChanged(object sender, EventArgs e)
        {
            this.user.FullName = ((TextEdit)sender).Text;
        }

        private void cbDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.user.Department = ((ComboBoxEdit)sender).Text;
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.user.Status = ((ComboBoxEdit)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (this.form_mode)
            {
                case FORM_MODE.ADD:
                    this.Add();
                    break;
                case FORM_MODE.EDIT:
                    this.Edit();
                    break;
                default:
                    break;
            }
        }

        private void Add()
        {
            string url = this.main_form.config.ApiUrl + "users/Add";

            var api_acc = new ApiAccessibilities
            {
                API_KEY = this.main_form.config.ApiKey,
                internalUsers = new InternalUsers
                {
                    UserName = this.user.UserName,
                    Email = "",
                    PasswordHash = "",
                    FullName = this.user.FullName,
                    Department = this.user.Department,
                    Status = this.user.Status,
                    CreDate = DateTime.Now
                }
            };

            APIResult result = APIClient.POST(url, api_acc);
            InternalUsers user;
            if (result.Success)
            {
                user = JsonConvert.DeserializeObject<InternalUsers>(result.ReturnValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
                this.txtUserName.Focus();
            }
        }

        private void Edit()
        {
            string url = this.main_form.config.ApiUrl + "users/Edit";

            var api_acc = new ApiAccessibilities
            {
                API_KEY = this.main_form.config.ApiKey,
                internalUsers = new InternalUsers
                {
                    Id = this.user.Id,
                    UserName = this.user.UserName,
                    Email = "",
                    PasswordHash = "",
                    FullName = this.user.FullName,
                    Department = this.user.Department,
                    Status = this.user.Status,
                }
            };

            APIResult result = APIClient.PUT(url, api_acc);
            InternalUsers user;
            if (result.Success)
            {
                user = JsonConvert.DeserializeObject<InternalUsers>(result.ReturnValue);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
                this.txtUserName.Focus();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && !(this.btnOK.Focused || this.btnCancel.Focused))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}