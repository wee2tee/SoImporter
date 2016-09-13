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
using Newtonsoft.Json;

namespace SoImporter.SubForm
{
    public partial class AddUserDialog : DevExpress.XtraEditors.XtraForm
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

        public AddUserDialog()
        {
            InitializeComponent();
        }

        public AddUserDialog(MainForm main_form) : this()
        {
            this.main_form = main_form;
            this.form_mode = FORM_MODE.ADD;
        }

        public AddUserDialog(MainForm main_form, InternalUsers user = null) : this()
        {
            this.main_form = main_form;
            this.form_mode = FORM_MODE.EDIT;
            this.user = user;
        }

        private void AddUserDialog_Load(object sender, EventArgs e)
        {
            this.cbDepartment.DataSource = Enum.GetValues(typeof(InternalUsers.DEPARTMENT));
            this.cbStatus.DataSource = Enum.GetValues(typeof(InternalUsers.STATUS));

            if (this.user != null)
            {
                this.txtUserName.Text = this.user.UserName;
                this.txtFullName.Text = this.user.FullName;
                this.cbDepartment.Text = this.user.Department;
                this.cbStatus.Text = this.user.Status;
            }
            else
            {
                this.user = new InternalUsers();
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
            this.user.Department = ((System.Windows.Forms.ComboBox)sender).Text;
        }

        private void cbStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.user.Status = ((System.Windows.Forms.ComboBox)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (this.form_mode)
            {
                case FORM_MODE.ADD:
                    string url = this.main_form.config.ApiUrl + "users/";

                    string json_data = JsonConvert.SerializeObject(
                        new ApiAccessibilities
                        {
                            API_KEY = this.main_form.config.ApiKey,
                            internalUsers = new InternalUsers
                            {
                                UserName = this.user.UserName,
                                Email = "",
                                PasswordHash = "123abc",
                                FullName = this.user.FullName,
                                Department = this.user.Department,
                                Status = this.user.Status,
                                CreDate = DateTime.Now
                            }
                        });
                    //Console.WriteLine(" .. >> json_data : " + json_data);

                    APIResult result = APIClient.POST(url, json_data);
                    InternalUsers user;
                    if (result.Success)
                    {
                        user = JsonConvert.DeserializeObject<InternalUsers>(result.ReturnValue);
                        Console.WriteLine("... >> " + user.FullName);
                    }
                    else
                    {
                        MessageBox.Show(result.ErrorMessage);
                    }
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                    break;
                case FORM_MODE.EDIT:

                    break;
                default:
                    break;
            }
        }
    }
}