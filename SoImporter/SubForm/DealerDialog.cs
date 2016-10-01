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
    public partial class DealerDialog : DevExpress.XtraEditors.XtraForm
    {
        public MainForm main_form;
        private List<DealerVM> dealers;
        private List<StpriVM> stpris;
        private List<DlvProfileVM> dlv_profiles;
        private BindingSource bs_dealer;
        
        public DealerDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void DealerDialog_Load(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            this.stpris = this.LoadStpriFromServer();
            this.dlv_profiles = this.LoadDlvProfileFromServer();

            this.bs_dealer = new BindingSource();
            this.dealers = this.LoadDealersFromServer();
            this.bs_dealer.DataSource = this.dealers;
            this.gridControl1.DataSource = this.bs_dealer;

            this.splashScreenManager1.CloseWaitForm();
        }

        public DealerVM LoadSingerDealerFromServer(string dealer_id)
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Dealers/GetDealerAt", this.main_form.config.ApiKey, "&id=" + dealer_id);

            if (get.Success)
            {
                DealerVM dealer = JsonConvert.DeserializeObject<DealerVM>(get.ReturnValue);
                return dealer;
            }
            else
            {
                if (MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadSingerDealerFromServer(dealer_id);
                }
                else
                {
                    return null;
                }
            }
        }

        public List<DealerVM> LoadDealersFromServer()
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "Dealers/GetDealer", this.main_form.config.ApiKey);

            if (get.Success)
            {
                List<DealerVM> dealers = JsonConvert.DeserializeObject<List<DealerVM>>(get.ReturnValue);
                foreach (var d in dealers)
                {
                    d._DlvProfile = this.dlv_profiles.Where(dlv => dlv.Id == d.DlvProfile).First().TypCod;
                }
                return dealers;
            }
            else
            {
                MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        public List<DlvProfileVM> LoadDlvProfileFromServer()
        {
            APIResult get = APIClient.GET(this.main_form.config.ApiUrl + "DlvProfile/GetDlvProfile", this.main_form.config.ApiKey);

            if (get.Success)
            {
                List<DlvProfileVM> dlv_profile = JsonConvert.DeserializeObject<List<DlvProfileVM>>(get.ReturnValue);
                return dlv_profile;
            }
            else
            {
                MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void gridViewDealer_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (((GridView)sender).GetRow(e.FocusedRowHandle) == null)
            {
                this.btnEdit.Enabled = false;
                return;
            }

            this.btnEdit.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (this.gridViewDealer.GetRow(this.gridViewDealer.FocusedRowHandle) == null)
                return;

            var dealer = this.dealers.Where(d => d.Id == (string)this.gridViewDealer.GetRowCellValue(this.gridViewDealer.FocusedRowHandle, this.colId)).ToList().FirstOrDefault();

            if (dealer == null)
                return;

            DealerEditDialog edit = new DealerEditDialog(this, dealer, this.stpris, this.dlv_profiles);
            if(edit.ShowDialog() == DialogResult.OK)
            {
                this.dealers = this.LoadDealersFromServer();
                this.bs_dealer.ResetBindings(true);
                this.bs_dealer.DataSource = this.dealers;
            }
        }

        private void gridViewDealer_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_edit = new MenuItem();
                mnu_edit.Text = "แก้ไข/ดูรายละเอียด";
                mnu_edit.Click += delegate { this.btnEdit.PerformClick(); };

                cm.MenuItems.Add(mnu_edit);
                cm.Show(this.gridControl1, new Point(e.X, e.Y));
                e.Handled = true;
            }

            if(e.Button == MouseButtons.Left && e.Clicks == 2) // Double clicks with left button
            {
                this.btnEdit.PerformClick();
                e.Handled = true;
            }
        }
    }
}