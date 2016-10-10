using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;
using SoImporter.Model;
using System.Collections.Generic;
using System.Linq;

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
            List<PopritVM> db = (List<PopritVM>)this.DataSource;

            this.lblDealerCode.Text = db.First().DealerCode;
        }
    }
}
