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
    public partial class DlvProfileAddEditDialog : DevExpress.XtraEditors.XtraForm
    {
        private enum FORM_MODE
        {
            ADD,
            EDIT
        }

        private MainForm main_form;
        private DlvProfileDialog dlvprofile_dialog;
        private FORM_MODE form_mode;
        private DlvProfileVM dlvprofile;
        private List<IstabVM> dlvby;
        private List<IstabVM> dlvby_remain = new List<IstabVM>();
        //private List<IstabVM> dlvby_selected = new List<IstabVM>();
        private BindingSource bs_remain;
        private BindingSource bs_selected;

        public DlvProfileAddEditDialog(DlvProfileDialog dlvprofile_dialog, DlvProfileVM dlvprofile = null)
        {
            InitializeComponent();
            this.dlvprofile_dialog = dlvprofile_dialog;
            this.main_form = dlvprofile_dialog.main_form;
            this.form_mode = dlvprofile == null ? FORM_MODE.ADD : FORM_MODE.EDIT;
            this.dlvprofile = dlvprofile;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.gridViewDlvByRemain.VisibleColumns[0].Width = 25;
            this.gridViewDlvBySelected.VisibleColumns[0].Width = 25;
        }

        private void DlvProfileAddEditDialog_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            if(this.form_mode == FORM_MODE.ADD) // Add mode
            {
                this.Text = "เพิ่มกลุ่มวิธีการจัดส่ง";
                this.dlvprofile = new DlvProfileVM()
                {
                    TabTyp = "D0",
                    TypCod = string.Empty,
                    AbbreviateEn = string.Empty,
                    AbbreviateTh = string.Empty,
                    TypDesEn = string.Empty,
                    TypDesTh = string.Empty,
                    CreBy = this.main_form.logedin_user.Id,
                    dlv = new List<IstabVM>()
                };
            }
            else // Edit mode
            {
                this.Text = "แก้ไขกลุ่มวิธีการจัดส่ง";
                this.dlvprofile = this.dlvprofile_dialog.LoadSingleDlvProfileFromServer(this.dlvprofile.Id);
                this.txtTypcod.Enabled = false;
            }

            this.txtTypcod.Text = this.dlvprofile.TypCod;
            this.txtAbbrEn.Text = this.dlvprofile.AbbreviateEn;
            this.txtAbbrTh.Text = this.dlvprofile.AbbreviateTh;
            this.txtTypDesEn.Text = this.dlvprofile.TypDesEn;
            this.txtTypDesTh.Text = this.dlvprofile.TypDesTh;

            this.bs_remain = new BindingSource();
            this.bs_selected = new BindingSource();
            this.dlvby = this.dlvprofile_dialog.LoadDlvByFromServer();

            this.dlvby_remain = this.dlvby.ConvertAll<IstabVM>(new Converter<IstabVM, IstabVM>(IstabVM2IstabVM));
            foreach (var item in this.dlvprofile.dlv)
            {
                this.dlvby_remain.Remove(this.dlvby_remain.Where(d => d.Id == item.Id).FirstOrDefault());
            }
            this.bs_remain.DataSource = this.dlvby_remain;
            this.gridControl1.DataSource = this.bs_remain;

            //this.dlvby_selected = this.dlvprofile.dlv.ConvertAll<IstabVM>(new Converter<IstabVM, IstabVM>(IstabVM2IstabVM));
            //this.bs_selected.DataSource = this.dlvby_selected;
            this.bs_selected.DataSource = this.dlvprofile.dlv;
            this.gridControl2.DataSource = this.bs_selected;

            this.splashScreenManager1.CloseWaitForm();
        }

        public static IstabVM IstabVM2IstabVM(IstabVM istab)
        {
            return istab;
        }

        private void txtTypcod_EditValueChanged(object sender, EventArgs e)
        {
            this.dlvprofile.TypCod = ((TextEdit)sender).Text.Trim();
        }

        private void txtAbbrTh_EditValueChanged(object sender, EventArgs e)
        {
            this.dlvprofile.AbbreviateTh = ((TextEdit)sender).Text.Trim();
        }

        private void txtAbbrEn_EditValueChanged(object sender, EventArgs e)
        {
            this.dlvprofile.AbbreviateEn = ((TextEdit)sender).Text.Trim();
        }

        private void txtTypDesTh_EditValueChanged(object sender, EventArgs e)
        {
            this.dlvprofile.TypDesTh = ((TextEdit)sender).Text.Trim();
        }

        private void txtTypDesEn_EditValueChanged(object sender, EventArgs e)
        {
            this.dlvprofile.TypDesEn = ((TextEdit)sender).Text.Trim();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            if (this.gridViewDlvByRemain.SelectedRowsCount == 0)
                return;

            int[] row_handles = this.gridViewDlvByRemain.GetSelectedRows();
            List<int> ids = new List<int>();
            foreach (var item in row_handles)
            {
                ids.Add((int)this.gridViewDlvByRemain.GetRowCellValue(item, this.colRemainId));
            }

            foreach (var id in ids)
            {
                this.dlvprofile.dlv.Add(this.dlvby_remain.Where(d => d.Id == id).FirstOrDefault());
                this.dlvprofile.dlv = this.dlvprofile.dlv.OrderBy(d => d.TypCod).ToList();

                this.bs_selected.ResetBindings(true);
                this.bs_selected.DataSource = this.dlvprofile.dlv;

                this.dlvby_remain.Remove(this.dlvby_remain.Where(d => d.Id == id).FirstOrDefault());

                this.bs_remain.ResetBindings(true);
                this.bs_remain.DataSource = this.dlvby_remain;
            }
            this.btnIn.Enabled = false;
            this.btnOut.Enabled = false;
        }

        private void btnOut_Click(object sender, EventArgs e)
        {
            if (this.gridViewDlvBySelected.SelectedRowsCount == 0)
                return;

            int[] row_handles = this.gridViewDlvBySelected.GetSelectedRows();
            List<int> ids = new List<int>();
            foreach (var item in row_handles)
            {
                ids.Add((int)this.gridViewDlvBySelected.GetRowCellValue(item, this.colSelectedId));
            }

            foreach (var id in ids)
            {
                this.dlvby_remain.Add(this.dlvprofile.dlv.Where(d => d.Id == id).FirstOrDefault());
                this.dlvby_remain = this.dlvby_remain.OrderBy(d => d.TypCod).ToList();

                this.bs_remain.ResetBindings(true);
                this.bs_remain.DataSource = this.dlvby_remain;

                this.dlvprofile.dlv.Remove(this.dlvprofile.dlv.Where(d => d.Id == id).FirstOrDefault());

                this.bs_selected.ResetBindings(true);
                this.bs_selected.DataSource = this.dlvprofile.dlv;
            }
            this.btnIn.Enabled = false;
            this.btnOut.Enabled = false;
        }

        private void gridViewDlvByRemain_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if(((GridView)sender).SelectedRowsCount > 0)
            {
                this.btnIn.Enabled = true;
            }
            else
            {
                this.btnIn.Enabled = false;
            }
        }

        private void gridViewDlvBySelected_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            if(((GridView)sender).SelectedRowsCount > 0)
            {
                this.btnOut.Enabled = true;
            }
            else
            {
                this.btnOut.Enabled = false;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.dlvprofile.TypCod.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาป้อนรหัสกลุ่ม", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                this.txtTypcod.Focus();
                return;
            }

            this.splashScreenManager1.ShowWaitForm();

            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.main_form.config.ApiKey,
                dlvprofile = this.dlvprofile
            };

            if(this.form_mode == FORM_MODE.ADD)
            {
                APIResult post = APIClient.POST(this.main_form.config.ApiUrl + "DlvProfile/AddDlvProfile", acc);
                if (post.Success)
                {
                    this.splashScreenManager1.CloseWaitForm();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.splashScreenManager1.CloseWaitForm();
                    if(MessageBox.Show(post.ErrorMessage.RemoveBeginAndEndQuote(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnOK.PerformClick();
                    }
                }
            }

            if(this.form_mode == FORM_MODE.EDIT)
            {
                APIResult put = APIClient.PUT(this.main_form.config.ApiUrl + "DlvProfile/UpdateDlvProfile", acc);
                if (put.Success)
                {
                    this.splashScreenManager1.CloseWaitForm();
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    this.splashScreenManager1.CloseWaitForm();
                    if (MessageBox.Show(put.ErrorMessage.RemoveBeginAndEndQuote(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnOK.PerformClick();
                    }
                }
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && !(this.btnOK.Focused || this.btnCancel.Focused))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void gridViewDlvByRemain_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_use = new MenuItem();
                mnu_use.Text = "นำมาใช้กับกลุ่มนี้";
                mnu_use.Click += delegate
                {
                    this.gridViewDlvByRemain.SelectRows(e.RowHandle, e.RowHandle);
                    this.btnIn.PerformClick();
                };

                cm.MenuItems.Add(mnu_use);
                cm.Show(this.gridControl1, new Point(e.X, e.Y));
            }
        }

        private void gridViewDlvBySelected_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_unuse = new MenuItem();
                mnu_unuse.Text = "นำออกจากกลุ่มนี้";
                mnu_unuse.Click += delegate
                {
                    this.gridViewDlvBySelected.SelectRows(e.RowHandle, e.RowHandle);
                    this.btnOut.PerformClick();
                };

                cm.MenuItems.Add(mnu_unuse);
                cm.Show(this.gridControl2, new Point(e.X, e.Y));
            }
        }
    }
}