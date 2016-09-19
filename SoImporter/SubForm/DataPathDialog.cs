using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using SoImporter.Model;
using SoImporter.MiscClass;
using DevExpress.XtraEditors.Controls;

namespace SoImporter.SubForm
{
    public partial class DataPathDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private List<Isrun> isrun;

        public string selected_path = string.Empty;
        public string selected_doc = string.Empty;

        public DataPathDialog()
        {
            InitializeComponent();
        }

        public DataPathDialog(MainForm main_form, string default_path, string doc_prefix) : this()
        {
            this.main_form = main_form;
            this.selected_path = default_path;
            this.selected_doc = doc_prefix;
        }

        private void DataPathDialog_Load(object sender, EventArgs e)
        {
            this.isrun = MainForm.LoadIsrunFromDBF(this.main_form.config).Where(i => i.doctyp == "SO").OrderBy(i => i.prefix).ToList();
            foreach (var item in this.isrun)
            {
                this.cbSoNum.Properties.Items.Add(item);
            }

            this.txtPath.Text = this.selected_path;

            var doc = this.isrun.Where(i => i.prefix == this.selected_doc).FirstOrDefault();
            this.cbSoNum.Text = (doc != null ? "[" + doc.prefix + "] " + doc.posdes : "");
        }

        private void DataPathDialog_Shown(object sender, EventArgs e)
        {
            this.txtPath.SelectionStart = this.txtPath.Text.Length;
        }

        private void txtPath_TextChanged(object sender, EventArgs e)
        {
            this.selected_path = ((TextEdit)sender).Text;
        }

        private void cbSoNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selected_doc = ((Isrun)((ComboBoxEdit)sender).SelectedItem).prefix;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                Description = "เลือกโฟลเดอร์ที่เก็บข้อมูล(โปรแกรม Express)",
                RootFolder = Environment.SpecialFolder.MyComputer,
                SelectedPath = (Directory.Exists(this.selected_path) ? this.selected_path : string.Empty)
            };

            if(fol.ShowDialog() == DialogResult.OK)
            {
                this.txtPath.Text = fol.SelectedPath;
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtPath.Text.Trim().Length > 0)
            {
                if (Directory.Exists(this.txtPath.Text))
                {
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
                else
                {
                    MessageBox.Show("กรุณาระบุที่เก็บข้อมูลให้ถูกต้อง");
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if(keyData == Keys.Escape)
            {
                this.btnCancel.PerformClick();
                return true;
            }

            if(keyData == Keys.F6)
            {
                this.btnBrowse.PerformClick();
                return true;
            }

            if(keyData == Keys.F9)
            {
                this.btnOK.PerformClick();
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}