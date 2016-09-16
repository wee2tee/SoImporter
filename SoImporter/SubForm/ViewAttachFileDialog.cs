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
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using System.Drawing.Printing;
using DevExpress.XtraReports.UI;
using SoImporter.Report;
using System.IO;

namespace SoImporter.SubForm
{
    public partial class ViewAttachFileDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private PopritVM poprit;
        private List<object> slip_file_name = new List<object>();
        private List<object> tax_file_name = new List<object>();
        private string selected_slip = string.Empty;
        private string selected_tax = string.Empty;

        public ViewAttachFileDialog(MainForm main_form, PopritVM poprit)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.poprit = poprit;
        }

        private void ViewAttachFileDialog_Load(object sender, EventArgs e)
        {
            foreach (string item in this.poprit.SlipFileName.Split(','))
            {
                this.slip_file_name.Add(new { FileName = item });
            }
            foreach (string item in this.poprit.TaxFileName.Split(','))
            {
                this.tax_file_name.Add(new { FileName = item });
            }

            this.gridControl2.DataSource = this.tax_file_name;
            this.gridControl1.DataSource = this.slip_file_name;
        }

        private void gridView_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            if(((GridView)sender) == this.gridViewSlip)
            {
                var row = ((GridView)sender).GetRow(e.FocusedRowHandle);
                if (row == null)
                    return;

                this.selected_slip = (string)((GridView)sender).GetRowCellValue(e.FocusedRowHandle, ((GridView)sender).Columns[0]);
            }

            if (((GridView)sender) == this.gridViewTax)
            {
                var row = ((GridView)sender).GetRow(e.FocusedRowHandle);
                if (row == null)
                    return;

                this.selected_tax = (string)((GridView)sender).GetRowCellValue(e.FocusedRowHandle, ((GridView)sender).Columns[0]);
            }

            string img_folder = (string)((GridView)sender).Tag;
            string file_name = ((GridView)sender) == this.gridViewSlip ? this.selected_slip : this.selected_tax;

            string img_url = "http://52.187.65.15/OrderManager/Images/" + img_folder + file_name;
            if (APIClient.CheckUrlFileExist(img_url))
            {
                this.pictureEdit1.LoadAsync(img_url);
                this.pictureEdit1.Tag = file_name;
            }
            else
            {
                this.pictureEdit1.Image = SoImporter.Properties.Resources.NO_PICTURE;
                this.pictureEdit1.Tag = "";
            }

            this.splashScreenManager1.CloseWaitForm();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
        {
            if(((XtraTabControl)sender).SelectedTabPage == this.tabPageSlip)
            {
                this.LoadImage(this.gridViewSlip);
            }

            if (((XtraTabControl)sender).SelectedTabPage == this.tabPageTax)
            {
                this.LoadImage(this.gridView2);
            }
        }

        private void LoadImage(GridView gridview)
        {
            this.splashScreenManager1.ShowWaitForm();

            string file_name = gridview == this.gridViewSlip ? this.selected_slip : this.selected_tax;
            string img_folder = gridview == this.gridViewSlip ? "Slip/" : "Tax/";
            string img_url = "http://52.187.65.15/OrderManager/Images/" + img_folder + file_name;
            if (APIClient.CheckUrlFileExist(img_url))
            {
                this.pictureEdit1.LoadAsync(img_url);
                this.pictureEdit1.Tag = file_name;
            }
            else
            {
                this.pictureEdit1.Image = SoImporter.Properties.Resources.NO_PICTURE;
                this.pictureEdit1.Tag = "";
            }

            this.splashScreenManager1.CloseWaitForm();
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            ReportAttachImage report = new ReportAttachImage();
            report.xrPictureBox1.Image = this.pictureEdit1.Image;
            report.xrLabelPoNum.Text = this.poprit.PoNum + "  [ file name : " + (string)this.pictureEdit1.Tag + " ]";
            report.ShowPreview();

            this.splashScreenManager1.CloseWaitForm();
        }
    }
}