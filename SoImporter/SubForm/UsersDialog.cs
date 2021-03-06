﻿using System;
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
            this.btnAdd.Visible = this.main_form.logedin_user.Department == InternalUsers.DEPARTMENT.Administrative.ToString() ? true : false;
            this.btnEdit.Visible = this.main_form.logedin_user.Department == InternalUsers.DEPARTMENT.Administrative.ToString() ? true : false;
            this.btnDelete.Visible = this.main_form.logedin_user.Department == InternalUsers.DEPARTMENT.Administrative.ToString() ? true : false;

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
            this.users = this.LoadUsersListFromServer();
            this.bs.ResetBindings(true);
            this.gridControl1.DataSource = this.users;
            splashScreenManager1.CloseWaitForm();
        }

        public InternalUsers LoadSingleUserFromServer(int? id)
        {
            if (!id.HasValue)
                return null;

            try
            {
                APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Users/GetUserById", this.main_form.config.ApiKey, "&id=" + id.ToString());
                if (get.Success)
                {
                    InternalUsers user = JsonConvert.DeserializeObject<InternalUsers>(get.ReturnValue);
                    return user;
                }
            }
            catch (Exception ex)
            {
                if(MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadSingleUserFromServer(id);
                }
            }

            return null;
        }

        public List<InternalUsers> LoadUsersListFromServer()
        {
            List<InternalUsers> users = null;
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
                int user_id = (int)gridview.GetRowCellValue(e.FocusedRowHandle, colId);
                this.btnEdit.Enabled = true;
                this.btnDelete.Enabled = true;
                this.btnChangePwd.Enabled = (this.main_form.logedin_user.Id == user_id ? true : false);
                this.btnResetPwd.Visible = (this.main_form.logedin_user.Department == InternalUsers.DEPARTMENT.Administrative.ToString() ? true : false);
            }
            else
            {
                this.btnEdit.Enabled = false;
                this.btnDelete.Enabled = false;
                this.btnChangePwd.Enabled = false;
                this.btnResetPwd.Visible = false;
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            UserAddEditDialog add = new UserAddEditDialog(this.main_form);
            if (add.ShowDialog() == DialogResult.OK)
            {
                this.RefreshGridUsers();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int user_id = (int)this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, colId);

            try
            {
                APIResult result = APIClient.GET(this.main_form.config.ApiUrl + "users/", this.main_form.config.ApiKey, "&id=" + user_id);

                if (result.Success && result.ReturnValue != null)
                {
                    InternalUsers user = JsonConvert.DeserializeObject<InternalUsers>(result.ReturnValue);
                    UserAddEditDialog edit = new UserAddEditDialog(this.main_form, user);
                    if(edit.ShowDialog() == DialogResult.OK)
                    {
                        this.RefreshGridUsers();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int user_id = (int)this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, colId);
            string user_name = (string)this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, colUserName);

            InternalUsers user = this.users.Where(u => u.Id == user_id).FirstOrDefault();

            if (user == null)
                return;

            if(MessageBox.Show("ลบรหัสผู้ใช้ \"" + user_name + "\"", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                try
                {
                    ApiAccessibilities acc = new ApiAccessibilities
                    {
                        API_KEY = this.main_form.config.ApiKey,
                        internalUsers = user
                    };

                    APIResult result = APIClient.DELETE(this.main_form.config.ApiUrl + "users/delete", acc);
                    if (result.Success)
                    {
                        this.RefreshGridUsers();
                    }
                    else
                    {
                        MessageBox.Show(result.ErrorMessage.RemoveBeginAndEndQuote());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void btnChangePwd_Click(object sender, EventArgs e)
        {
            int user_id = (int)this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, colId);
            InternalUsers user = this.users.Where(u => u.Id == user_id).FirstOrDefault();

            if (user == null)
                return;

            ChangePasswordDialog chg = new ChangePasswordDialog(this.main_form, user);
            if(chg.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show("เปลี่ยนรหัสผ่านของผู้ใช้รหัส \"" + user.UserName + "\" เรียบร้อย, กรุณาล็อกอินด้วยรหัสผ่านใหม่อีกคร้ง");
            }
        }

        private void btnResetPwd_Click(object sender, EventArgs e)
        {
            int user_id = (int)this.gridView1.GetRowCellValue(this.gridView1.FocusedRowHandle, colId);
            InternalUsers user = this.users.Where(u => u.Id == user_id).FirstOrDefault();

            if(MessageBox.Show("รีเซ็ตรหัสผ่านของรหัสผู้ใช้ \"" + user.UserName + "\", ดำเนินการต่อ?", "Reset Password",MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1) == DialogResult.OK)
            {
                if (user == null)
                    return;

                try
                {
                    APIResult result = APIClient.POST(this.main_form.config.ApiUrl + "users/resetpassword", new ApiAccessibilities
                    {
                        API_KEY = this.main_form.config.ApiKey,
                        internalUsers = new InternalUsers
                        {
                            Id = user_id,
                        }
                    });
                    if (result.Success)
                    {
                        MessageBox.Show("รีเซ็ตรหัสผ่านของรหัสผู้ใช้ \"" + user.UserName + "\" เป็น \"" + user.UserName + "\" เรียบร้อย");
                    }
                    else
                    {
                        MessageBox.Show(result.ErrorMessage.RemoveBeginAndEndQuote());
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
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
                e.Handled = true;
            }

            if(e.Button == MouseButtons.Left && e.Clicks == 2)
            {
                this.btnEdit.PerformClick();
                e.Handled = true;
            }
        }
    }
}