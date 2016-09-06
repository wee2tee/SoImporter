﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SoImporter.SubForm;
using System.IO;
using SoImporter.MiscClass;
using SoImporter.Model;
using Newtonsoft.Json;
using DotNetDBF;
using DotNetDBF.Enumerable;

namespace SoImporter
{

    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private ConfigValue config;
        private List<Order> orders;
        private BindingSource bs;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.config = ConfigValue.Load();
            this.lblDataPath.Caption = (this.config.ExpressDataPath.Trim().Length == 0 ? "[...]" : "[ " + this.config.ExpressDataPath + " ]");
            this.bs = new BindingSource();
            this.bs.DataSource = this.orders;
            this.gridControl1.DataSource = this.bs;
            //this.configInfo();
        }

        private void btnDataPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataPathDialog dlg = new DataPathDialog(this, this.config.ExpressDataPath);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                this.config.ExpressDataPath = dlg.selected_path;
                this.config.Save();
                this.lblDataPath.Caption = (this.config.ExpressDataPath.Trim().Length == 0 ? "[...]" : "[ " + this.config.ExpressDataPath + " ]");

                //this.configInfo();
            }
        }


        //private void configInfo()
        //{
        //    Console.WriteLine(" ... >> express_data_path : " + this.config.ExpressDataPath);
        //    Console.WriteLine(" ... >> lines : " + this.config.Lines);
        //}

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Text file|*.txt",
                CheckPathExists = true,
                CheckFileExists = true,
                RestoreDirectory = true,
                Multiselect = false,
                Title = "",
                SupportMultiDottedExtensions = true,
                InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            };
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                using (StreamReader sr = new StreamReader(dlg.FileName, Encoding.GetEncoding("windows-874")))
                {
                    string json = sr.ReadToEnd();
                    sr.Close();
                    this.orders = JsonConvert.DeserializeObject<List<Order>>(json);

                    this.bs.ResetBindings(true);
                    this.bs.DataSource = this.orders;
                }
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.gridView1.VisibleColumns[0].Width = 25;
        }

        private void btnRecSO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(this.config.ExpressDataPath + @"\oeso.dbf", FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    using (DBFReader dr = new DBFReader(fs))
                    {
                        dr.CharEncoding = Encoding.GetEncoding("windows-874");
                        //Console.WriteLine(" >>> fields[0].name = " + dr.Fields[0].Name);
                        IEnumerable<Oeso> oeso = dr.AllRecords<Oeso>();
                        foreach (Oeso item in oeso)
                        {
                            Console.WriteLine(" >> " + item.sonum + " " + item.sodat + " " + item.cuscod);
                        }

                        Console.WriteLine(" >> last oeso is : " + oeso.OrderByDescending(o => o.sonum).First().sonum );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTestWrite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream(this.config.ExpressDataPath + @"\oeso.dbf", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
                {
                    using (DBFWriter dw = new DBFWriter(fs))
                    {
                        //var sorectyp = new DBFField("sorectyp", NativeDbType.Char, 1);
                        //var sonum = new DBFField("sonum", NativeDbType.Char, 12);
                        //dw.Fields = new[] { sorectyp, sonum };

                        dw.WriteRecord("2", "SO99999");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
