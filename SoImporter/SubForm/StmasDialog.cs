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
using FileUpload;
using Newtonsoft.Json;
using System.Net.Http;
using System.IO;
using System.Net;

namespace SoImporter.SubForm
{
    public partial class StmasDialog : DevExpress.XtraEditors.XtraForm
    {
        private enum FORM_MODE
        {
            READ,
            ADD,
            EDIT
        }
        public MainForm main_form;
        public List<StmasVM> stmas_list; // for display in list dialog
        public List<IstabVM> stkgrp;
        public List<IstabVM> qucod;
        public StmasVM current_stmas;
        public StmasVM backup_stmas; // storing stmas before add/edit state

        private FORM_MODE form_mode;
        private IstabDialog istab_dialog_stkgrp; // for load stkgrp data from server
        private IstabDialog istab_dialog_qucod; // for load qucod data from server
        private string img_file_path = string.Empty; // for storing image file path (before upload)
        private string find_keyword = string.Empty; // for storing find keyword

        public StmasDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void StmasDialog_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            this.form_mode = FORM_MODE.READ;

            istab_dialog_stkgrp = new IstabDialog(this.main_form, ISTAB_TABTYP.STKGRP);
            istab_dialog_qucod = new IstabDialog(this.main_form, ISTAB_TABTYP.QUCOD);
            this.stkgrp = this.istab_dialog_stkgrp.LoadIstabFromServer();
            this.qucod = this.istab_dialog_qucod.LoadIstabFromServer();

            this.cbStkGrp.AddItem<IstabVM>(this.stkgrp);
            this.cbQucod.AddItem<IstabVM>(this.qucod);

            this.current_stmas = this.LoadSingleStmasFromServer(RECORD_NAVIGATION.LAST);
            this.FillForm(this.current_stmas);

            this.splashScreenManager1.CloseWaitForm();
        }

        private void FillForm(StmasVM stmas)
        {
            if (stmas == null)
                return;

            this.txtStkcod.Text = stmas.Stkcod;
            this.txtStkdesTh.Text = stmas.StkDesTh;
            this.txtStkdesEn.Text = stmas.StkDesEn;
            this.cbStkGrp.SelectedIndex = this.cbStkGrp.Properties.Items.Cast<IstabVM>().Where(i => i.Id == stmas.StkGrp).Count() > 0 ? this.cbStkGrp.Properties.Items.IndexOf(this.cbStkGrp.Properties.Items.Cast<IstabVM>().Where(i => i.Id == stmas.StkGrp).FirstOrDefault()) : -1;
            this.cbQucod.SelectedIndex = this.cbQucod.Properties.Items.Cast<IstabVM>().Where(i => i.Id == stmas.Qucod).Count() > 0 ? this.cbQucod.Properties.Items.IndexOf(this.cbQucod.Properties.Items.Cast<IstabVM>().Where(i => i.Id == stmas.Qucod).FirstOrDefault()) : -1;
            this.txtSellpr1.EditValue = stmas.Sellpr1;
            this.txtSellpr2.EditValue = stmas.Sellpr2;
            this.txtSellpr3.EditValue = stmas.Sellpr3;
            this.txtSellpr4.EditValue = stmas.Sellpr4;
            this.txtSellpr5.EditValue = stmas.Sellpr5;
            this.img_file_path = stmas.ProductImg == null || stmas.ProductImg.Trim().Length == 0 ? "" : this.main_form.config.ApiUrl.ToLower().Replace("/api/", "") + "/Images/Product/" + stmas.ProductImg;
            if(this.img_file_path.Length == 0)
            {
                this.picProductImg.Image = null; // SoImporter.Properties.Resources.NO_PICTURE;
            }
            else
            {
                this.picProductImg.LoadAsync(this.img_file_path);
            }
        }

        public StmasVM LoadSingleStmasFromServer(int? id)
        {
            if (!id.HasValue)
                return null;

            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Stmas/GetAt", this.main_form.config.ApiKey, "&id=" + id);
            if (get.Success)
            {
                return JsonConvert.DeserializeObject<StmasVM>(get.ReturnValue);
            }
            else
            {
                if (MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadSingleStmasFromServer(id);
                }
            }

            return null;
        }

        public StmasVM LoadSingleStmasFromServer(RECORD_NAVIGATION nav, int? current_id = null)
        {
            string url = this.main_form.config.ApiUrl;
            switch (nav)
            {
                case RECORD_NAVIGATION.FIRST:
                    url += "Stmas/GetFirst";
                    break;
                case RECORD_NAVIGATION.PREVIOUS:
                    url += "Stmas/GetPrevious";
                    break;
                case RECORD_NAVIGATION.NEXT:
                    url += "Stmas/GetNext";
                    break;
                case RECORD_NAVIGATION.LAST:
                    url += "Stmas/GetLast";
                    break;
                default:
                    url += "Stmas/GetLast";
                    break;
            }

            var id_args = current_id.HasValue ? "&current_id=" + current_id : "";
            APIResult get = APIClient.GET(url, this.main_form.config.ApiKey, id_args);
            if (get.Success)
            {
                return JsonConvert.DeserializeObject<StmasVM>(get.ReturnValue);
            }
            else
            {
                if(MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadSingleStmasFromServer(nav);
                }
            }

            return null;
        }

        public List<StmasVM> LoadStmasFromServer()
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Stmas/GetAll", this.main_form.config.ApiKey);
            if (get.Success)
            {
                List<StmasVM> stmas = JsonConvert.DeserializeObject<List<StmasVM>>(get.ReturnValue);
                return stmas;
            }
            else
            {
                if(MessageBox.Show(get.ErrorMessage.RemoveBeginAndEndQuote(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadStmasFromServer();
                }
            }
            return null;
        }

        private void btnAdd_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.backup_stmas = this.current_stmas.Clone();
            this.current_stmas = new StmasVM
            {
                Id = -1,
                Stkcod = string.Empty,
                StkDesTh = string.Empty,
                StkDesEn = string.Empty,
                Barcod = string.Empty,
                StkTyp = "0",
                StkGrp = -1,
                Qucod = -1,
                Sellpr1 = 0,
                Sellpr2 = 0,
                Sellpr3 = 0,
                Sellpr4 = 0,
                Sellpr5 = 0,
                ProductImg = string.Empty,
                CreBy = this.main_form.logedin_user.Id,
                CreDate = DateTime.Now
            };
            this.FillForm(this.current_stmas);
            this.form_mode = FORM_MODE.ADD;
            this.txtStkcod.Focus();
        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.backup_stmas = this.current_stmas.Clone();
        }

        private void btnStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(MessageBox.Show("ยกเลิกการเพิ่ม/แก้ไข, ใช่หรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                this.form_mode = FORM_MODE.READ;
                this.current_stmas = this.backup_stmas.Clone();
                this.FillForm(this.current_stmas);
            }
        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.main_form.config.ApiKey,
                stmas = this.current_stmas
            };

            APIResult add_edit;
            if(this.form_mode == FORM_MODE.ADD) // Add mode
            {
                add_edit = APIClient.POST(this.main_form.config.ApiUrl + "Stmas/AddStmas", acc);
            }
            else // Edit mode
            {
                add_edit = APIClient.PUT(this.main_form.config.ApiUrl + "Stmas/UpdateStmas", acc);
            }

            if (add_edit.Success)
            {
                StmasVM added_item = JsonConvert.DeserializeObject<StmasVM>(add_edit.ReturnValue);

                if (this.img_file_path.Trim().Length > 0) // have image
                {
                    var upload = FIleUpload.Upload(this.main_form.config.ApiUrl + "Stmas/UploadImage", File.OpenRead(this.img_file_path), "file1", added_item.Id.ToString() + Path.GetExtension(this.img_file_path));

                    if (upload.Success)
                    {
                        acc.stmas = added_item;
                        acc.stmas.ProductImg = acc.stmas.Id.ToString() + Path.GetExtension(this.img_file_path);

                        APIResult update = APIClient.PUT(this.main_form.config.ApiUrl + "Stmas/UpdateStmas", acc);
                        if (!update.Success)
                        {
                            if (this.splashScreenManager1.IsSplashFormVisible)
                                this.splashScreenManager1.CloseWaitForm();

                            MessageBox.Show("บันทึกข้อมูลสำเร็จ, แต่การอัพโหลดรูปภาพล้มเหลว กรุณาอัพโหลดรูปภาพอีกครั้งในภายหลัง", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else
                    {
                        if (this.splashScreenManager1.IsSplashFormVisible)
                            this.splashScreenManager1.CloseWaitForm();

                        MessageBox.Show("บันทึกข้อมูลสำเร็จ, แต่การอัพโหลดรูปภาพล้มเหลว กรุณาอัพโหลดรูปภาพอีกครั้งในภายหลัง", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                    this.current_stmas = added_item;
                    this.FillForm(this.current_stmas);
                }
                else // don't have image
                {
                    this.current_stmas = added_item;
                    this.FillForm(this.current_stmas);
                }
            }
            else
            {
                if (this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();

                if(MessageBox.Show(add_edit.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    this.btnSave.PerformClick();
                }
                else
                {
                    this.current_stmas = this.backup_stmas.Clone();
                    this.FillForm(this.current_stmas);
                }
            }

            if (this.splashScreenManager1.IsSplashFormVisible)
                this.splashScreenManager1.CloseWaitForm();
        }

        private void btnDelete_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(MessageBox.Show("ลบรหัสสินค้า '" + this.current_stmas.Stkcod + "' ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                ApiAccessibilities acc = new ApiAccessibilities
                {
                    API_KEY = this.main_form.config.ApiKey,
                    stmas = this.current_stmas
                };

                APIResult delete = APIClient.DELETE(this.main_form.config.ApiUrl + "Stmas/DeleteStmas", acc);
                if (delete.Success)
                {
                    StmasVM stmas = JsonConvert.DeserializeObject<StmasVM>(delete.ReturnValue);
                    this.current_stmas = stmas;
                    this.FillForm(this.current_stmas);
                }
                else
                {
                    if(MessageBox.Show(delete.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.btnDelete.PerformClick();
                    }
                }
            }
        }

        private void btnFirst_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.current_stmas = this.LoadSingleStmasFromServer(RECORD_NAVIGATION.FIRST);
            this.FillForm(this.current_stmas);
        }

        private void btnPrev_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var stmas = this.LoadSingleStmasFromServer(RECORD_NAVIGATION.PREVIOUS, this.current_stmas.Id);
            if (stmas == null)
                return;

            this.current_stmas = stmas;
            this.FillForm(this.current_stmas);
        }

        private void btnNext_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var stmas = this.LoadSingleStmasFromServer(RECORD_NAVIGATION.NEXT, this.current_stmas.Id);
            if (stmas == null)
                return;

            this.current_stmas = stmas;
            this.FillForm(this.current_stmas);
        }

        private void btnLast_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.current_stmas = this.LoadSingleStmasFromServer(RECORD_NAVIGATION.LAST);
            this.FillForm(this.current_stmas);
        }

        private void btnFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FindDialog fd = new FindDialog("รหัสสินค้า", this.find_keyword);
            if(fd.ShowDialog() == DialogResult.OK)
            {
                this.find_keyword = fd.key_word;

                StmasVM find_result = this.FindByStkcod(this.find_keyword);
                if(find_result != null)
                {
                    this.current_stmas = find_result;
                    this.FillForm(this.current_stmas);
                }
                else
                {
                    MessageBox.Show("ค้นหารหัส '" + this.find_keyword + "' ไม่พบ", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private StmasVM FindByStkcod(string key_word)
        {
            APIResult find = APIClient.GET(this.main_form.config.ApiUrl + "Stmas/FindByStkcod", this.main_form.config.ApiKey, "&stkcod=" + key_word);
            if (find.Success)
            {
                StmasVM stmas = JsonConvert.DeserializeObject<StmasVM>(find.ReturnValue);
                return stmas;
            }
            else
            {
                if(MessageBox.Show(find.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.FindByStkcod(key_word);
                }
            }

            return null;
        }

        private void btnList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StmasListDialog st_list = new StmasListDialog(this, this.current_stmas);
            if(st_list.ShowDialog() == DialogResult.OK)
            {
                this.current_stmas = st_list.selected_stmas;
                this.FillForm(this.current_stmas);
            }
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StmasImportDialog import = new StmasImportDialog(this.main_form);
            import.ShowDialog();
        }

        private void btnBrowseImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.img_file_path = ofd.FileName;
                this.picProductImg.LoadAsync(this.img_file_path);
            }
        }

        private void btnCancelChangeImg_Click(object sender, EventArgs e)
        {
            this.img_file_path = this.current_stmas.ProductImg == null || this.current_stmas.ProductImg.Trim().Length == 0 ? "" : this.main_form.config.ApiUrl.ToLower().Replace("/api/", "") + "/Images/Product/" + this.current_stmas.ProductImg;
            if (this.img_file_path.Length == 0)
            {
                this.picProductImg.Image = null; // SoImporter.Properties.Resources.NO_PICTURE;
            }
            else
            {
                this.picProductImg.LoadAsync(this.img_file_path);
            }
        }

        private void txtStkcod_EditValueChanged(object sender, EventArgs e)
        {
            this.current_stmas.Stkcod = ((TextEdit)sender).Text.Trim();
        }

        private void txtStkdesTh_EditValueChanged(object sender, EventArgs e)
        {
            this.current_stmas.StkDesTh = ((TextEdit)sender).Text.Trim();
        }

        private void txtStkdesEn_EditValueChanged(object sender, EventArgs e)
        {
            this.current_stmas.StkDesEn = ((TextEdit)sender).Text.Trim();
        }

        private void cbStkGrp_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBoxEdit)sender).SelectedIndex > -1)
                this.current_stmas.StkGrp = ((IstabVM)((ComboBoxEdit)sender).SelectedItem).Id;
        }

        private void cbQucod_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (((ComboBoxEdit)sender).SelectedIndex > -1)
                this.current_stmas.Qucod = ((IstabVM)((ComboBoxEdit)sender).SelectedItem).Id;
        }

        private void txtSellpr1_EditValueChanged(object sender, EventArgs e)
        {
            this.current_stmas.Sellpr1 = (decimal)((TextEdit)sender).EditValue;
        }

        private void txtSellpr2_EditValueChanged(object sender, EventArgs e)
        {
            this.current_stmas.Sellpr2 = (decimal)((TextEdit)sender).EditValue;
        }

        private void txtSellpr3_EditValueChanged(object sender, EventArgs e)
        {
            this.current_stmas.Sellpr3 = (decimal)((TextEdit)sender).EditValue;
        }

        private void txtSellpr4_EditValueChanged(object sender, EventArgs e)
        {
            this.current_stmas.Sellpr4 = (decimal)((TextEdit)sender).EditValue;
        }

        private void txtSellpr5_EditValueChanged(object sender, EventArgs e)
        {
            this.current_stmas.Sellpr5 = (decimal)((TextEdit)sender).EditValue;
        }
    }
}