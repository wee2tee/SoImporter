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
using System.Globalization;

namespace SoImporter
{

    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        public ConfigValue config;
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

        private OleDbConnection createConnection()
        {
            return new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + this.config.ExpressDataPath + @"\");
        }

        private void btnRecSO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            try
            {
                List<Oeso> oeso = this.OesoToList();

                if (oeso == null)
                {
                    return;
                }

                string last_sonum = oeso.OrderByDescending(o => o.sonum).First().sonum;
                string next_sonum = last_sonum.Substring(0, 2) + (Convert.ToInt32(last_sonum.Substring(2, last_sonum.Trim().Length - 2)) + 1).ToString().FillZeroLeft(7);

                if (File.Exists(this.config.ExpressDataPath + @"\OESO.DBF"))
                    File.Copy(this.config.ExpressDataPath + @"\OESO.DBF", this.config.ExpressDataPath + @"\OESO.DBF.BAK", true);

                if (File.Exists(this.config.ExpressDataPath + @"\OESOIT.DBF"))
                    File.Copy(this.config.ExpressDataPath + @"\OESOIT.DBF", this.config.ExpressDataPath + @"\OESOIT.DBF.BAK", true);

                using (OleDbConnection conn = this.createConnection())
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        string empty_date = "CTOD('  /  /  ')";

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert Into Oeso ([sorectyp],[sonum],[sodat],[flgvat],[depcod],[slmcod],[cuscod],[shipto],[youref],[rff],[areacod],[paytrm],[dlvdat],[dlvtim],[dlvdat_it],[nxtseq],[amount],[disc],[discamt],[total],[amtrat0],[vatrat],[vatamt],[netamt],[netval],[cmpldat],[docstat],[dlvby],[userid],[chgdat],[userprn],[prndat],[prncnt],[prntim],[authid],[approve],[billto],[orgnum]) Values ";
                        cmd.CommandText += "('0', "; // sorectyp
                        cmd.CommandText += "'" + next_sonum + "',"; // sonum
                        cmd.CommandText += "CTOD('" + DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "'),"; // sodat
                        cmd.CommandText += "'2',"; // flgvat
                        cmd.CommandText += "'',"; // depcod
                        cmd.CommandText += "'',"; // slmcod
                        cmd.CommandText += "'',"; // cuscod
                        cmd.CommandText += "'',"; //shipto
                        cmd.CommandText += "'',"; // youref
                        cmd.CommandText += "'',"; // rff
                        cmd.CommandText += "'',"; // areacod
                        cmd.CommandText += "0,"; // paytrm
                        cmd.CommandText += empty_date + ","; // dlvdat
                        cmd.CommandText += "'',"; // dlvtim
                        cmd.CommandText += "'',"; // dlvdat_it
                        cmd.CommandText += "'',"; // nxtseq
                        cmd.CommandText += "14500,"; // amount
                        cmd.CommandText += "'',"; // disc
                        cmd.CommandText += "0,"; // discamt
                        cmd.CommandText += "14500,"; // total
                        cmd.CommandText += "0,"; // amtrat0
                        cmd.CommandText += "7,"; // vatrat
                        cmd.CommandText += "1015,"; // vatamt
                        cmd.CommandText += "15515,"; // netamt
                        cmd.CommandText += "15515,"; // netval
                        cmd.CommandText += empty_date + ","; // cmpldat
                        cmd.CommandText += "'N',"; // docstat
                        cmd.CommandText += "'EM',"; // dlvby
                        cmd.CommandText += "'BIT5',"; // userid
                        cmd.CommandText += empty_date + ","; // chgdat
                        cmd.CommandText += "'',"; // userprn
                        cmd.CommandText += empty_date + ","; // prndat
                        cmd.CommandText += "0,"; // prncnt
                        cmd.CommandText += "'',"; // prntim
                        cmd.CommandText += "'',"; // authid
                        cmd.CommandText += empty_date + ","; // approve
                        cmd.CommandText += "'',"; // billto
                        cmd.CommandText += "0)"; // orgnum

                        cmd.Connection = conn;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            Console.WriteLine(" .. >> insert oeso successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        public List<Oeso> OesoToList()
        {
            if (!File.Exists(this.config.ExpressDataPath + @"\OESO.DBF") || !File.Exists(this.config.ExpressDataPath + @"\OESOIT.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            DataTable dt = new DataTable();

            using (OleDbConnection conn = this.createConnection())
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "select * from OESO";  // dbf table name

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }

            return dt.ToList<Oeso>();
        }

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Console.WriteLine(" .. >> checked : " + ((GridView)sender).SelectedRowsCount);
            this.btnRecSO.Enabled = (((GridView)sender).SelectedRowsCount > 0 && File.Exists(this.config.ExpressDataPath + @"\oeso.dbf")) ? true : false;
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            string url = this.config.ApiUrl + "users/";

            string json_data = JsonConvert.SerializeObject(
                new ApiAccessibilities { API_KEY = this.config.ApiKey,
                    internalUsers = new InternalUsers {
                        UserName = "WeeTee",
                        Email = "weetee@gmail.com",
                        PasswordHash = "123456abcdef",
                        FullName = "วีรวัฒน์ ตรุเจตนารมย์",
                        Department = "Admin",
                        Status = "N",
                        CreDate = DateTime.Now
                    }
                });
            //Console.WriteLine(" .. >> json_data : " + json_data);

            APIResult result = APIClient.POST(url, json_data);
            InternalUsers user;
            if (result.Success)
            {
                user = JsonConvert.DeserializeObject<InternalUsers>(result.ReturnValue);
                Console.WriteLine("... >> " + user.FullName);
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }


        }

        private void btnApiUrl_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            ApiUrlDialog api = new ApiUrlDialog(this);
            if(api.ShowDialog() == DialogResult.OK)
            {
                this.config.ApiUrl = api.api_url;
                this.config.ApiKey = api.api_key;
                this.config.Save();
            }
        }

        private void btnUsers_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            UsersDialog users = new UsersDialog(this);
            users.ShowDialog();
        }
    }
}
