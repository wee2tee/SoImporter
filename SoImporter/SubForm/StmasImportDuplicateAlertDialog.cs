using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace SoImporter.SubForm
{
    public partial class StmasImportDuplicateAlertDialog : DevExpress.XtraEditors.XtraForm
    {
        private string stkcod;


        public StmasImportDuplicateAlertDialog(string stkcod)
        {
            InitializeComponent();
            this.stkcod = stkcod;
        }

        private void StmasImportDuplicateAlertDialog_Load(object sender, EventArgs e)
        {
            this.lblWarnning.Text = "รหัสสินค้า '" + this.stkcod + "' มีข้อมูลอยู่แล้ว,\nท่านต้องการปฏิบัติอย่างไรกับข้อมูลสินค้านี้";
        }
    }
}