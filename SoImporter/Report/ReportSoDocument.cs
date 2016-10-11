using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SoImporter.Model;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace SoImporter.Report
{
    public partial class ReportSoDocument : DevExpress.XtraReports.UI.XtraReport
    {
        public ReportSoDocument()
        {
            InitializeComponent();
        }

        private void ReportSoDocument_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            List<PrintSoVM> db = (List<PrintSoVM>)this.DataSource;
            this.lblTotal.Text = string.Format("{0:#,#0.00}", db.Sum(i => i.TrnVal));
            this.lblVatAmt.Text = string.Format("{0:#,#0.00}", db.Sum(i => i.VatAmt));
            this.lblTaxAmt.Text = string.Format("{0:#,#0.00}", db.Sum(i => i.TaxAmt));
            this.lblNetAmt.Text = string.Format("{0:#,#0.00}", db.Sum(i => i.NetAmt));
            this.lblPrintTime.Text = DateTime.Now.ToString("dd/MM/yy HH:mm:ss", CultureInfo.GetCultureInfo("th-TH"));
        }
    }
}
