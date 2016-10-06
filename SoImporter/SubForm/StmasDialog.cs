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
using System.Net.Http;
using System.IO;

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

        private FORM_MODE form_mode;
        private IstabDialog istab_dialog_stkgrp; // for load stkgrp data from server
        private IstabDialog istab_dialog_qucod; // for load qucod data from server

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
            //this.stmas_list = this.LoadStmasFromServer();

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
            this.txtProductImg.EditValue = stmas.ProductImg;
            this.picProductImg.LoadAsync(this.main_form.config.ApiUrl.ToLower().Replace("/api/", "") + "/Images/Product/" + stmas.ProductImg);
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

        }

        private void btnEdit_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnStop_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnSave_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnCancel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

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

        }

        private void btnList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StmasListDialog st_list = new StmasListDialog(this, this.current_stmas);
            if(st_list.ShowDialog() == DialogResult.OK)
            {
                this.current_stmas = st_list.selected_stmas;
                Console.WriteLine(" .. >>>> current_stmas = " + this.current_stmas.Stkcod);
                this.FillForm(this.current_stmas);
            }
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        private void btnBrowseImg_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                this.txtProductImg.Text = ofd.FileName;
            }
        }

        //private Stream Upload(string actionUrl, string paramString, Stream paramFileStream, byte[] paramFileBytes)
        private Stream Upload(string actionUrl, Stream paramFileStream)
        {
            //HttpContent stringContent = new StringContent(paramString);
            HttpContent fileStreamContent = new StreamContent(paramFileStream);
            //HttpContent bytesContent = new ByteArrayContent(paramFileBytes);
            using (var client = new HttpClient())
            using (var formData = new MultipartFormDataContent())
            {
                //formData.Add(stringContent, "param1", "param1");
                formData.Add(fileStreamContent, "file1", "file1");
                //formData.Add(bytesContent, "file2", "file2");
                var response = client.PostAsync(actionUrl, formData).Result;
                if (!response.IsSuccessStatusCode)
                {
                    return null;
                }
                return response.Content.ReadAsStreamAsync().Result;
            }
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Stream st = File.OpenRead(this.txtProductImg.Text);
            byte[] bt = File.ReadAllBytes(this.txtProductImg.Text);

            Stream result = this.Upload(this.main_form.config.ApiUrl + "FileUpload/PostImage", st);
            StreamReader sr = new StreamReader(result);
            MessageBox.Show(sr.ReadToEnd());
        }
    }
}