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
    public partial class ArMasDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private List<Glacc> glacc;
        private List<Oeslm> oeslm;
        private List<Istab> istab;
        private List<Istab> prenam; // tabtyp = 51; typcod = 06
        private List<Istab> custyp; // tabtyp = 45
        private List<Istab> remark; // tabtyp = 51; typcod = 18
        private List<Istab> areacod; // tabtyp = 40
        private List<Istab> dlvby; // tabtyp = 41
        private List<Tabpr> tabpr = new List<Tabpr>
        {
            new Tabpr { tabval = "0", tabdesc = "ราคาขายล่าสุด" },
            new Tabpr { tabval = "1", tabdesc = "ราคาขายที่ 1" },
            new Tabpr { tabval = "2", tabdesc = "ราคาขายที่ 2" },
            new Tabpr { tabval = "3", tabdesc = "ราคาขายที่ 3" },
            new Tabpr { tabval = "4", tabdesc = "ราคาขายที่ 4" },
            new Tabpr { tabval = "5", tabdesc = "ราคาขายที่ 5" }
        };

        public Armas armas;
        private Armas pattern_ar;

        public ArMasDialog()
        {
            InitializeComponent();
        }

        public ArMasDialog(MainForm main_form, Armas armas) : this()
        {
            this.main_form = main_form;
            this.pattern_ar = armas;
        }

        private void ArMasDialog_Load(object sender, EventArgs e)
        {
            this.BackColor = MainForm.express_theme_color;
            this.armas = new Armas(true);
            this.splashScreenManager1.ShowWaitForm();

            this.cbPreNam.Text = this.pattern_ar.prenam;
            this.txtCusNam.Text = this.pattern_ar.cusnam;
            this.txtAddr01.Text = this.pattern_ar.addr01;
            this.txtAddr02.Text = this.pattern_ar.addr02;
            this.txtAddr03.Text = this.pattern_ar.addr03;
            this.txtZipCod.Text = this.pattern_ar.zipcod;
            this.txtTelNum.Text = this.pattern_ar.telnum;
            this.txtContact.Text = this.pattern_ar.contact;
            this.txtTaxId.Text = this.pattern_ar.taxid;
            this.txtOrgNum.Text = this.pattern_ar.orgnum.ToString();

            // get all istab
            this.istab = MainForm.LoadIstabFromDBF(this.main_form.config);

            this.prenam = this.istab.Where(i => i.tabtyp == "51" && i.typcod.Trim() == "06").ToList();
            this.custyp = this.istab.Where(i => i.tabtyp == "45").ToList();
            this.remark = this.istab.Where(i => i.tabtyp == "51" && i.typcod.Trim() == "18").ToList();
            this.areacod = this.istab.Where(i => i.tabtyp == "40").ToList();
            this.dlvby = this.istab.Where(i => i.tabtyp == "41").ToList();
            this.glacc = MainForm.LoadGlaccFromDBF(this.main_form.config);
            this.oeslm = MainForm.LoadOeslmFromDBF(this.main_form.config);

            foreach (var item in this.prenam)
            {
                this.cbPreNam.Properties.Items.Add(item);
            }
            foreach (var item in this.custyp)
            {
                this.cbCusTyp.Properties.Items.Add(item);
            }
            foreach (var item in this.remark)
            {
                this.cbRemark.Properties.Items.Add(item);
            }
            foreach (var item in this.areacod)
            {
                this.cbAreaCod.Properties.Items.Add(item);
            }
            foreach (var item in this.dlvby)
            {
                this.cbDlvBy.Properties.Items.Add(item);
            }
            foreach (var item in this.glacc)
            {
                this.cbAccNum.Properties.Items.Add(item);
            }
            foreach (var item in this.oeslm)
            {
                this.cbSlmCod.Properties.Items.Add(item);
            }
            foreach (var item in this.tabpr)
            {
                this.cbTabPr.Properties.Items.Add(item);
            }

            this.splashScreenManager1.CloseWaitForm();
        }

        private void txtCusCod_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.cuscod = ((TextEdit)sender).Text;
        }

        private void txtCusNam_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.cusnam = ((TextEdit)sender).Text;
        }

        private void cbPreNam_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.prenam = ((ComboBoxEdit)sender).Text;
        }

        private void txtAddr01_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.addr01 = ((TextEdit)sender).Text;
        }

        private void txtAddr02_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.addr02 = ((TextEdit)sender).Text;
        }

        private void txtAddr03_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.addr03 = ((TextEdit)sender).Text;
        }

        private void txtZipCod_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.zipcod = ((TextEdit)sender).Text;
        }

        private void txtTelNum_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.telnum = ((TextEdit)sender).Text;
        }

        private void txtContact_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.contact = ((TextEdit)sender).Text;
        }

        private void cbRemark_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.remark = ((ComboBoxEdit)sender).Text;
        }

        private void txtTaxId_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.taxid = ((TextEdit)sender).Text;
        }

        private void txtOrgNum_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.orgnum = Convert.ToInt32(((TextEdit)sender).Text.Replace(",", "")) < -1 ? -1 : Convert.ToInt32(((TextEdit)sender).Text.Replace(",", ""));
        }

        private void cbCusTyp_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.armas.custyp = (this.cbCusTyp.SelectedItem != null ? ((Istab)this.cbCusTyp.SelectedItem).typcod : "");
        }

        private void cbAccNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.armas.accnum = (this.cbAccNum.SelectedItem != null ? ((Glacc)this.cbAccNum.SelectedItem).accnum : "");
        }

        private void cbSlmCod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.armas.slmcod = (this.cbSlmCod.SelectedItem != null ? ((Oeslm)this.cbSlmCod.SelectedItem).slmcod : "");
        }

        private void cbAreaCod_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.armas.areacod = (this.cbAreaCod.SelectedItem != null ? ((Istab)this.cbAreaCod.SelectedItem).typcod : "");
        }

        private void cbDlvBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.armas.dlvby = (this.cbDlvBy.SelectedItem != null ? ((Istab)this.cbDlvBy.SelectedItem).typcod : "");
        }

        private void txtPayTrm_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.paytrm = Convert.ToInt32(((TextEdit)sender).Text.Replace(",", "")) < 0 ? 0 : Convert.ToInt32(((TextEdit)sender).Text.Replace(",", ""));
        }

        private void txtPayCond_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.paycond = ((TextEdit)sender).Text;
        }

        private void cbTabPr_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.armas.tabpr = (this.cbTabPr.SelectedItem != null ? ((Tabpr)this.cbTabPr.SelectedItem).tabval : "0");
        }

        private void txtDisc_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.disc = ((TextEdit)sender).Text.Contains("+") ? (((TextEdit)sender).Text.Trim() + "%").PadLeft(10) : ((TextEdit)sender).Text.Trim().PadLeft(10);
        }

        private void txtCrLine_EditValueChanged(object sender, EventArgs e)
        {
            this.armas.crline = Convert.ToDouble(((TextEdit)sender).Text.Replace(",", ""));
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (MainForm.InsertArmas(this.main_form.config, this.armas) == true)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}