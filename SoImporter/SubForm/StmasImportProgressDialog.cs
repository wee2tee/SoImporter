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
    public partial class StmasImportProgressDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private List<Stmas> stmas;
        private List<Istab> stkgrp;
        private List<Istab> qucod;
        private List<StmasImportVM> stmasvm;
        private BackgroundWorker work;

        public StmasImportProgressDialog(MainForm main_form, List<Stmas> stmas)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.stmas = stmas;
        }

        private void ProgressBarDialog_Load(object sender, EventArgs e)
        {
            var istab = MainForm.LoadIstabFromDBF(this.main_form.config);
            this.stkgrp = istab.Where(i => i.tabtyp.Trim() == ((int)ISTAB_TABTYP.STKGRP).ToString()).ToList();
            this.qucod = istab.Where(i => i.tabtyp.Trim() == ((int)ISTAB_TABTYP.QUCOD).ToString()).ToList();

            this.stmasvm = this.stmas.ToViewModel(this.stkgrp, this.qucod);
            this.lblCounter.Text = "[1/" + this.stmasvm.Count.ToString() + "]";
            this.progressBar1.Properties.Maximum = this.stmasvm.Count;
            this.BeginImport();
        }

        private void BeginImport()
        {
            this.lblStkCod.Text = this.stmasvm.First().Stkcod;
            this.work = new BackgroundWorker();
            this.work.DoWork += new DoWorkEventHandler(this.ImportDowork);
            this.work.ProgressChanged += new ProgressChangedEventHandler(this.ImportProgressChanged);
            this.work.RunWorkerCompleted += new RunWorkerCompletedEventHandler(this.ImportCompleted);
            this.work.WorkerSupportsCancellation = true;
            this.work.WorkerReportsProgress = true;
            this.work.RunWorkerAsync();
        }

        private void ImportDowork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            var i = 0;
            foreach (var stmas in this.stmasvm)
            {
                i++;
                if (worker.CancellationPending)
                {
                    e.Cancel = true;
                    return;
                }
                else
                {
                    StmasImportVM st_exist = null;
                    APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Stmas/GetImportModelForCheckExist", this.main_form.config.ApiKey, "&stkcod=" + stmas.Stkcod.Trim());
                    if (get.Success)
                    {
                        st_exist = JsonConvert.DeserializeObject<StmasImportVM>(get.ReturnValue);
                    }

                    if(st_exist != null) // is exist importing stkcod
                    {
                        StmasImportDuplicateAlertDialog alert = new StmasImportDuplicateAlertDialog(st_exist.Stkcod.Trim());
                        if (alert.ShowDialog() == DialogResult.OK) // replace with new data (Update)
                        {
                            stmas.Id = st_exist.Id;
                            if(this.ImportData(stmas, true))
                            {
                                worker.ReportProgress(i);
                            }
                            else
                            {
                                worker.CancelAsync();
                            }
                        }
                        else // skip duplicate data
                        {
                            worker.ReportProgress(i);
                        }
                    }
                    else // is not exist
                    {
                        if (this.ImportData(stmas, false))
                        {
                            worker.ReportProgress(i);
                        }
                        else
                        {
                            worker.CancelAsync();
                        }
                    }
                }
            }
        }

        private void ImportProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.lblStkCod.Text = e.ProgressPercentage < this.stmasvm.Count ? this.stmasvm[e.ProgressPercentage].Stkcod : this.stmasvm.Last().Stkcod;
            this.progressBar1.EditValue = e.ProgressPercentage;
            int trans_cnt = e.ProgressPercentage + 1 <= this.stmasvm.Count ? e.ProgressPercentage + 1 : this.stmasvm.Count;
            this.lblCounter.Text = "[" + trans_cnt.ToString() + "/" + this.stmasvm.Count.ToString() + "]";
        }

        private void ImportCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Cancelled)
            {
                MessageBox.Show("ยกเลิกการนำเข้าข้อมูลแล้ว");
            }
            else if(e.Error != null)
            {
                MessageBox.Show(e.Error.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("การนำเข้าข้อมูลเสร็จสมบูรณ์");
            }
        }

        private bool ImportData(StmasImportVM stmas, bool update_existing)
        {
            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.main_form.config.ApiKey,
                USER_ID = this.main_form.logedin_user.Id,
                stmas_import = stmas
            };

            APIResult post;
            if(update_existing == false) // add mode
            {
                post = APIClient.POST(this.main_form.config.ApiUrl + "Stmas/ImportAdd", acc);
            }
            else // edit mode
            {
                post = APIClient.POST(this.main_form.config.ApiUrl + "Stmas/ImportUpdate", acc);
            }

            if (post.Success)
            {
                return true;
            }
            else
            {
                if(MessageBox.Show(post.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.ImportData(stmas, update_existing);
                }
                return false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (this.work.WorkerSupportsCancellation)
                this.work.CancelAsync();
        }
    }
}