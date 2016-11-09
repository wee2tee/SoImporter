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

        public string selected_program_path = string.Empty;
        public string selected_data_path = string.Empty;
        public string selected_doc = string.Empty;

        public DataPathDialog()
        {
            InitializeComponent();
        }

        public DataPathDialog(MainForm main_form, string default_program_path, string default_data_path, string doc_prefix) : this()
        {
            this.main_form = main_form;

            if (default_program_path != null)
                this.selected_program_path = default_program_path;
            if (default_data_path != null)
                this.selected_data_path = default_data_path;

            this.selected_doc = doc_prefix;
        }

        private void DataPathDialog_Load(object sender, EventArgs e)
        {
            this.SetCbSonumSelection(this.main_form.config);
            this.txtProgramPath.Text = this.selected_program_path;
            this.txtDataPath.Text = this.selected_data_path;
        }

        private void SetCbSonumSelection(ConfigValue config)
        {
            if (File.Exists(config.ExpressDataPath + @"\isrun.dbf"))
            {
                this.isrun = MainForm.LoadIsrunFromDBF(config).Where(i => i.doctyp == "SO").OrderBy(i => i.prefix).ToList();
                
                this.cbSoNum.AddItem(this.isrun, true);
                var doc = this.isrun.Where(i => i.prefix == this.selected_doc).FirstOrDefault();
                this.cbSoNum.Text = (doc != null ? "[" + doc.prefix + "] " + doc.posdes : "");
            }
        }

        private void DataPathDialog_Shown(object sender, EventArgs e)
        {
            this.txtProgramPath.SelectionStart = this.txtProgramPath.Text.Length;
        }

        private void txtProgramPath_TextChanged(object sender, EventArgs e)
        {
            this.selected_program_path = ((TextEdit)sender).Text;
        }

        private void txtDataPath_TextChanged(object sender, EventArgs e)
        {
            this.selected_data_path = ((TextEdit)sender).Text;
        }

        private void cbSoNum_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.selected_doc = ((Isrun)((ComboBoxEdit)sender).SelectedItem).prefix;
        }

        private void btnBrowse1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                Description = "เลือกโฟลเดอร์ที่เก็บโปรแกรม Express",
                RootFolder = Environment.SpecialFolder.MyComputer,
                SelectedPath = (Directory.Exists(this.selected_program_path) ? this.selected_program_path : string.Empty)
            };

            if (fol.ShowDialog() == DialogResult.OK)
            {
                this.txtProgramPath.Text = fol.SelectedPath;
            }
        }

        private void btnBrowse2_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fol = new FolderBrowserDialog()
            {
                ShowNewFolderButton = false,
                Description = "เลือกโฟลเดอร์ที่เก็บข้อมูล(Express)",
                RootFolder = Environment.SpecialFolder.MyComputer,
                SelectedPath = (Directory.Exists(this.selected_data_path) ? this.selected_data_path : string.Empty)
            };

            if(fol.ShowDialog() == DialogResult.OK)
            {
                this.txtDataPath.Text = fol.SelectedPath;
                this.SetCbSonumSelection(new ConfigValue { ExpressDataPath = this.selected_data_path });

            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (this.txtDataPath.Text.Trim().Length > 0)
            {
                if (Directory.Exists(this.txtDataPath.Text))
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

            if(keyData == Keys.Enter && !(this.btnOK.Focused || this.btnCancel.Focused))
            {
                SendKeys.Send("{TAB}");
                return true;
            }

            if(keyData == Keys.F6 && this.txtDataPath.Focused)
            {
                this.btnBrowse2.PerformClick();
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