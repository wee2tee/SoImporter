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
    public partial class StmasDialog : DevExpress.XtraEditors.XtraForm
    {
        public MainForm main_form;
        public List<StmasVM> stmas;

        public StmasDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void StmasDialog_Load(object sender, EventArgs e)
        {
            this.stmas = this.LoadStmasFromServer();

        }

        public List<StmasVM> LoadStmasFromServer()
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Stmas/GetStmas", this.main_form.config.ApiKey);
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

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Perform add");
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            MessageBox.Show("Perform edit");
        }
    }
}