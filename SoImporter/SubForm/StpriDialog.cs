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
    public partial class StpriDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private BindingSource bs;
        public List<StpriVM> stpri;
        public StpriVM selected_stpri;

        public StpriDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void StpriDialog_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            this.bs = new BindingSource();
            this.stpri = this.LoadStpriFromServer();
            this.bs.DataSource = this.stpri;
            this.gridControl1.DataSource = this.bs;

            this.splashScreenManager1.CloseWaitForm();
        }

        public StpriVM LoadSingleStpriFromServer(int id)
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Stpri/GetStpriAt", this.main_form.config.ApiKey, "&id=" + id);
            if (get.Success)
            {
                StpriVM stpri = JsonConvert.DeserializeObject<StpriVM>(get.ReturnValue);

                return stpri;
            }
            else
            {
                if (MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return LoadSingleStpriFromServer(id);
                }

                return null;
            }
        }

        public List<StpriVM> LoadStpriFromServer()
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Stpri/GetStpri", this.main_form.config.ApiKey);
            if (get.Success)
            {
                List<StpriVM> stpri = JsonConvert.DeserializeObject<List<StpriVM>>(get.ReturnValue);

                return stpri;
            }
            else
            {
                if(MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                     return LoadStpriFromServer();
                }

                return null;
            }
        }
    }
}