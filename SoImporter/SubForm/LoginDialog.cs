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
    public partial class LoginDialog : DevExpress.XtraEditors.XtraForm
    {
        public InternalUsers user;

        private MainForm main_form;
        private string user_name = string.Empty;
        private string password = string.Empty;

        public LoginDialog()
        {
            InitializeComponent();
        }

        public LoginDialog(MainForm main_form) : this()
        {
            this.main_form = main_form;
        }


        private void txtUserName_TextChanged(object sender, EventArgs e)
        {
            this.user_name = ((TextEdit)sender).Text;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            this.password = ((TextEdit)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            try
            {
                APIResult result = APIClient.POST(this.main_form.config.ApiUrl + "users/signin", new ApiAccessibilities { API_KEY = this.main_form.config.ApiKey, internalUsers = new InternalUsers { UserName = (string)this.txtUserName.EditValue, PasswordHash = (string)this.txtPassword.EditValue, CreDate = DateTime.Now, Department = "", Email = "", FullName = "", Id = 0, Status = "" } });

                if (result.Success && result.ReturnValue != null)
                {
                    InternalUsers user = JsonConvert.DeserializeObject<InternalUsers>(result.ReturnValue);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    //MessageBox.Show(result.ErrorMessage);
                    MessageBox.Show("รหัสผู้ใช้/รหัสผ่าน ไม่ถูกต้อง");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}