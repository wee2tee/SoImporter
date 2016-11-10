using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using SoImporter.Model;
using SoImporter.MiscClass;
using System.IO;
using System.Threading;

namespace SoImporter.MiscClass
{
    public class Reindex
    {
        private MainForm main_form;
        private List<ExpressTableName> table_names;
        public bool Result = false;

        // Reindex for all express table
        public Reindex(MainForm main_form)
        {
            this.main_form = main_form;
            this.table_names = this.GetExpressTableName();
        }

        // Reindex for specified express table
        public Reindex(MainForm main_form, List<EXPRESS_TABLE_NAME> tables)
        {
            this.main_form = main_form;
            this.table_names = new List<ExpressTableName>();
            foreach (var t in tables)
            {
                this.table_names.Add(t.ToExpressTableName());
            }
        }

        public void CreateIndex()
        {
            this.Indexing(0, 1);
        }

        private void Indexing(int list_index, int try_count)
        {
            if (list_index >= this.table_names.Count)
            {
                //this.btnCancel.Enabled = false;
                //this.btnCancel.SendToBack();
                //this.btnOK.Enabled = true;
                //this.btnOK.BringToFront();
                return;
            }

            ExpressTableName table = this.table_names[list_index];
            if (table == null) // unknown table
            {
                MessageBox.Show("Unknown table", "", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.Indexing(++list_index, 1);
            }

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
                        }
                    }

                    p.WaitForExit();
                    this.Result = true;
                    this.Indexing(++list_index, 1);
                }
                else
                {
                    this.Result = false;
                    if (MessageBox.Show("ไม่สามารถสร้างแฟ้มดัชนี, เนื่องจากแฟ้ม " + table.name + " มีผู้อื่นใช้งานอยู่", "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        this.Indexing(list_index, ++try_count);
                    }
                }
                return;
            }
            catch (Exception ex)
            {
                this.Result = false;

                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    this.Indexing(list_index, ++try_count);
                }
            }
        }
    }
}
