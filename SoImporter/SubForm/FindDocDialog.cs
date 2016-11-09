using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using SoImporter.MiscClass;
using SoImporter.Model;

namespace SoImporter.SubForm
{
    public partial class FindDocDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        public FindField.FIELD? selected_field = null;
        public string docnum = string.Empty;

        public FindDocDialog(MainForm main_form)
        {
            InitializeComponent();
            this.main_form = main_form;
        }

        private void FindDocDialog_Load(object sender, EventArgs e)
        {
            this.cbFindField.AddItem(FindField.GetField(), true);
        }

        private void cbFindField_SelectedIndexChanged(object sender, EventArgs e)
        {
            FindField selected = (FindField)((ComboBoxEdit)sender).SelectedItem;

            this.selected_field = selected.field;
        }

        private void txtDocNum_EditValueChanged(object sender, EventArgs e)
        {
            this.docnum = ((TextEdit)sender).Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(this.selected_field == null)
            {
                MessageBox.Show("กรุณาเลือกประเภทการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.cbFindField.Focus();
                return;
            }

            if(this.docnum.Trim().Length == 0)
            {
                MessageBox.Show("กรุณาป้อนเลขที่เอกสารที่ต้องการค้นหา", "", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.txtDocNum.Focus();
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.Enter && !(this.btnOK.Focused || this.btnCancel.Focused))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            if(keyData == Keys.F6 && this.cbFindField.Focused)
            {
                SendKeys.Send("{F4}");
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }

    public class FindField
    {
        public enum FIELD : int
        {
            PO = 0,
            SO = 1,
            IV = 2,
            EMS = 3
        }

        public string description { get; set; }
        public string prefix { get; set; }
        public FIELD field { get; set; }
        public override string ToString()
        {
            return this.description + (prefix.Trim().Length > 0 ? " (" + this.prefix + ")" : "");
        }

        public static List<FindField> GetField()
        {
            List<FindField> list = new List<FindField>();
            list.Add(new FindField
            {
                prefix = "PO",
                description = "รายการสั่งซื้อ",
                field = FIELD.PO
            });
            list.Add(new FindField
            {
                prefix = "SO",
                description = "ใบสั่งขาย",
                field = FIELD.SO
            });
            list.Add(new FindField
            {
                prefix = "IV",
                description = "ใบแจ้งหนี้",
                field = FIELD.IV
            });
            list.Add(new FindField
            {
                prefix = "",
                description = "EMS Tracking No.",
                field = FIELD.EMS
            });

            return list;
        }
    }
}