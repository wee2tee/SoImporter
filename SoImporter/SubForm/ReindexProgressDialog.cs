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
        private List<ExpressTableName> table_names;

        public ReindexProgressDialog()
        {
            InitializeComponent();
        }

        public ReindexProgressDialog(MainForm main_form, bool all_tables)
            : this()
        {
            this.main_form = main_form;
            this.table_names = this.GetExpressTableName();
        }

        public ReindexProgressDialog(MainForm main_form, List<ExpressTableName> table_names)
            : this()
        {
            this.main_form = main_form;
            this.table_names = table_names;
        }

        private void ReindexProgressDialog_Load(object sender, EventArgs e)
        {
            
        }

        private void ReindexProgressDialog_Shown(object sender, EventArgs e)
        {
            this.PerformReindex(this.table_names, 0);
            //foreach (ExpressTableName tb in this.table_names)
            //{
            //    using (BackgroundWorker worker = new BackgroundWorker())
            //    {
            //        this.lblFileName.Text = tb.name;
            //        worker.DoWork += delegate
            //        {
            //            Reindex reindex = new Reindex(this.main_form);
            //            reindex.CreateIndex();
            //        };
            //        worker.RunWorkerCompleted += delegate
            //        {

            //        };
            //        worker.RunWorkerAsync();
            //    }
            //}
        }

        private void PerformReindex(List<ExpressTableName> tables_list, int index/*, int try_count = 1*/)
        {
            if(index >= tables_list.Count)
            {
                this.btnOK.Text = "เรียบร้อย";
                this.btnOK.Enabled = true;
                return;
            }

            this.lblFileName.Text = tables_list[index].name;
            //this.lblTryCount.Text = try_count.ToString();

            using(BackgroundWorker worker = new BackgroundWorker())
            {
                bool result = false;

                worker.DoWork += delegate
                {
                    Reindex r = new Reindex(this.main_form, tables_list[index]);
                    r.CreateIndex();
                    result = r.Result;
                };
                worker.RunWorkerCompleted += delegate
                {
                    //Console.WriteLine(" .. >> Reindex for " + this.main_form.config.ExpressDataPath + @"\" + table_names[index].name + " result is " + result);
                    if(result == true)
                    {
                        this.PerformReindex(tables_list, ++index);
                    }
                    else
                    {
                        Thread.Sleep(2000);
                        this.PerformReindex(tables_list, index/*, ++try_count*/);
                    }
                };
                worker.RunWorkerAsync();
            }
        }
    }

    //public class ProcessResult
    //{
    //    public bool Success { get; set; }
    //    public string Output { get; set; }
    //}

}