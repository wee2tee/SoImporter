using System;
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
using System.Data.OleDb;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

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
            this.btnImport.Enabled = Directory.Exists(this.config.ExpressDataPath) ? true : false;
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

                this.btnImport.Enabled = Directory.Exists(this.config.ExpressDataPath) ? true : false;
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

            //try
            //{
            //    using (FileStream fs = new FileStream(this.config.ExpressDataPath + @"\oeso.dbf", FileMode.Open, FileAccess.Read, FileShare.Read))
            //    {
            //        using (DBFReader dr = new DBFReader(fs))
            //        {
            //            dr.CharEncoding = Encoding.GetEncoding("windows-874");
            //            //Console.WriteLine(" >>> fields[0].name = " + dr.Fields[0].Name);
            //            IEnumerable<Oeso> oeso = dr.AllRecords<Oeso>();
            //            foreach (Oeso item in oeso)
            //            {
            //                //Console.WriteLine(" >> " + item.sonum + " " + item.sodat + " " + item.cuscod);
            //            }

            //            //Console.WriteLine(" >> last oeso is : " + oeso.OrderByDescending(o => o.sonum).First().sonum);
            //            gridControl2.DataSource = oeso.ToList();
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

            Console.WriteLine(" ... >> lastest so is : " + this.OesoToList().OrderByDescending(o => o.sonum).First().sonum);
        }

        //public DataTable GetYourData()
        //{
        //    DataTable YourResultSet = new DataTable();

        //    OleDbConnection yourConnectionHandler = new OleDbConnection(
        //        @"Provider=VFPOLEDB.1;Data Source=" + this.config.ExpressDataPath + @"\");

        //    // if including the full dbc (database container) reference, just tack that on
        //    //      OleDbConnection yourConnectionHandler = new OleDbConnection(
        //    //          "Provider=VFPOLEDB.1;Data Source=C:\\SomePath\\NameOfYour.dbc;" );


        //    // Open the connection, and if open successfully, you can try to query it
        //    yourConnectionHandler.Open();

        //    if (yourConnectionHandler.State == ConnectionState.Open)
        //    {
        //        string mySQL = "select * from OESO";  // dbf table name

        //        OleDbCommand MyQuery = new OleDbCommand(mySQL, yourConnectionHandler);
        //        OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);

        //        DA.Fill(YourResultSet);

        //        yourConnectionHandler.Close();
        //    }

        //    return YourResultSet;
        //}

        public List<Oeso> OesoToList()
        {
            DataTable YourResultSet = new DataTable();

            OleDbConnection yourConnectionHandler = new OleDbConnection(
                @"Provider=VFPOLEDB.1;Data Source=" + this.config.ExpressDataPath + @"\");


            // Open the connection, and if open successfully, you can try to query it
            yourConnectionHandler.Open();

            if (yourConnectionHandler.State == ConnectionState.Open)
            {
                string mySQL = "select * from OESO";  // dbf table name

                OleDbCommand MyQuery = new OleDbCommand(mySQL, yourConnectionHandler);
                OleDbDataAdapter DA = new OleDbDataAdapter(MyQuery);

                DA.Fill(YourResultSet);

                yourConnectionHandler.Close();
            }

            return YourResultSet.ToList<Oeso>();
        }

        private void btnTestWrite_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //try
            //{
            //    File.Copy(this.config.ExpressDataPath + @"\OESO.DBF", this.config.ExpressDataPath + @"\OESO.DBF.BAK", true);
            //    using (Stream fs = File.Open(this.config.ExpressDataPath + @"\oeso.dbf", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            //    //using (FileStream fs = new FileStream(this.config.ExpressDataPath + @"\oesox.dbf", FileMode.Open, FileAccess.ReadWrite, FileShare.ReadWrite))
            //    {
            //        using (DBFWriter dw = new DBFWriter(fs))
            //        {
            //            //var sorectyp = new DBFField("sorectyp", NativeDbType.Char, 1);
            //            //var sonum = new DBFField("sonum", NativeDbType.Char, 12);
            //            //dw.Fields = new[] { sorectyp, sonum };

            //            dw.WriteRecord(
            //                "2",
            //                "SO99999",
            //                DateTime.Now,
            //                "2",
            //                "dep01",
            //                "สามารถ",
            //                "สบายใจ",
            //                "ship01",
            //                "youref01",
            //                "QT99999",
            //                "ar01",
            //                45,
            //                null,
            //                "0935",
            //                "Y",
            //                "1",
            //                12500.75d,
            //                "10%",
            //                1250.08d,
            //                11250.67d,
            //                0d,
            //                7,
            //                787.55d,
            //                12038.22d,
            //                12038.22d,
            //                null,
            //                "N",
            //                "EM",
            //                "BIT9",
            //                null,
            //                "",
            //                null,
            //                0,
            //                "",
            //                "",
            //                null,
            //                "",
            //                0
            //            );
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}

        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Console.WriteLine(" .. >> checked : " + ((GridView)sender).SelectedRowsCount);
            this.btnRecSO.Enabled = (((GridView)sender).SelectedRowsCount > 0 && File.Exists(this.config.ExpressDataPath + @"\oeso.dbf")) ? true : false;
        }
    }
}
