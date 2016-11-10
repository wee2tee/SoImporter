using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Diagnostics;
using SoImporter.Model;
using SoImporter.MiscClass;
using System.IO;
using System.Threading;

namespace SoImporter.SubForm
{
    public partial class ReindexProgressDialog : DevExpress.XtraEditors.XtraForm
    {
        private MainForm main_form;
        private List<EXPRESS_TABLE_NAME> table_names;

        public ReindexProgressDialog(MainForm main_form, List<EXPRESS_TABLE_NAME> table_names)
        {
            InitializeComponent();
            this.main_form = main_form;
            this.table_names = table_names;
        }

        private void ReindexProgressDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void ReindexProgressDialog_Shown(object sender, EventArgs e)
        {
            this.ReIndex(0, 1);
        }

        private void ReIndex(int list_index, int try_count)
        {
            if (list_index >= this.table_names.Count)
            {
                //this.btnCancel.Enabled = false;
                //this.btnCancel.SendToBack();
                //this.btnOK.Enabled = true;
                //this.btnOK.BringToFront();
                this.DialogResult = DialogResult.OK;
                this.Close();
                return;
            }

            ExpressTableName table = this.table_names[list_index].ToExpressTableName();
            if (table == null) // unknown table
            {
                MessageBox.Show("Unknown table", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.ReIndex(++list_index, 1);
            }

            this.lblFileName.Text = table.name;
            this.lblTryCount.Text = try_count.ToString();

            try
            {
                //FileStream fs = File.Open(this.main_form.config.ExpressDataPath + @"\" + table.name, FileMode.Append, FileAccess.Write, FileShare.Write);
                FileStream fs = File.Open(this.main_form.config.ExpressDataPath + @"\" + table.name, FileMode.Open, FileAccess.Read, FileShare.Read);

                if (fs.CanRead)
                {
                    Process p = new Process();
                    ProcessStartInfo info = new ProcessStartInfo();
                    info.FileName = "cmd.exe";
                    info.RedirectStandardInput = true;
                    info.UseShellExecute = false;
                    info.RedirectStandardOutput = true;
                    info.CreateNoWindow = true;

                    p.StartInfo = info;
                    fs.Close();
                    p.Start();

                    using (StreamWriter sw = p.StandardInput)
                    {
                        if (sw.BaseStream.CanWrite)
                        {
                            sw.WriteLine(this.main_form.config.ExpressProgramPath + @"\adm32 " + this.main_form.config.ExpressDataPath);
                            sw.WriteLine(table.seq);
                            //sw.WriteLine("");
                        }
                    }
                    //string output = p.StandardOutput.ReadToEnd();
                    p.WaitForExit();
                    this.ReIndex(++list_index, 1);
                }
                else
                {
                    Thread.Sleep(1000);
                    this.ReIndex(list_index, ++try_count);
                }

                return;
            }
            catch (Exception ex)
            {
                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    this.ReIndex(list_index, ++try_count);
                }
            }
        }
    }

    public class ProcessResult
    {
        public bool Success { get; set; }
        public string Output { get; set; }
    }

}