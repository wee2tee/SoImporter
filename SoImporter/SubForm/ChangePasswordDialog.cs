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

namespace SoImporter.SubForm
{
    public partial class ChangePasswordDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private InternalUsers user;
        private string old_password = string.Empty;
        private string new_password = string.Empty;
        private string conf_new_password = string.Empty;


        public ChangePasswordDialog(MainForm main_form, InternalUsers user)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.user = user;
        }

        private void ChangePasswordDialog_Load(object sender, EventArgs e)
        {
            this.txtUserName.Text = this.user.UserName;
        }

        private void txtOldPwd_TextChanged(object sender, EventArgs e)
        {
            this.old_password = ((TextEdit)sender).Text;
        }

        private void txtNewPwd_TextChanged(object sender, EventArgs e)
        {
            this.new_password = ((TextEdit)sender).Text;
        }

        private void txtConfNewPwd_TextChanged(object sender, EventArgs e)
        {
            this.conf_new_password = ((TextEdit)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.old_password.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาป้อนรหัสผ่านเดิม");
                this.txtUserName.Focus();
                return;
            }

            if (this.new_password.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาป้อนรหัสผ่านใหม่");
                this.txtNewPwd.Focus();
                return;
            }

            if (this.new_password != this.conf_new_password)
            {
                MessageBox.Show("กรุณายืนยันรหัสผ่านใหม่ให้ถูกต้อง");
                this.txtConfNewPwd.Focus();
                return;
            }

            if (this.ChangePassword(this.user.Id, this.old_password, this.new_password) == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        public bool ChangePassword(int user_id, string old_password, string new_password)
        {
            try
            {
                APIResult result = APIClient.POST(this.main_form.config.ApiUrl + "users/changepassword", new ApiAccessibilities
                {
                    API_KEY = this.main_form.config.ApiKey,
                    changePasswordModel = new InternalUsersVM
                    {
                        Id = user_id,
                        PasswordHash = old_password,
                        NewPassword = new_password
                    }
                });
                if (result.Success)
                {
                    return true;
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage);
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
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