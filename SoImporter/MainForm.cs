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
using System.Net;
using System.Net.Mail;
using SoImporter.MiscClass;
using SoImporter.Model;
using Newtonsoft.Json;
using System.Data.OleDb;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using System.Globalization;
using DevExpress.XtraBars.Alerter;
using System.Drawing.Printing;
using SoImporter.Report;
using DevExpress.XtraReports.UI;
using DBFHelper;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System.Diagnostics;

namespace SoImporter
{

    public partial class MainForm : DevExpress.XtraBars.Ribbon.RibbonForm
    {

        private List<PopritVM> poprit;
        private BindingSource bs_po;
        private BindingSource bs_so;
        private BindingSource bs_iv;
        private Timer timer;

        public ConfigValue config;
        public InternalUsers logedin_user;
        public AlertControl alert;
        public static Color express_theme_color
        {
            get
            {
                return Color.FromArgb(254, 226, 187);
            }
        }

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.alert = new AlertControl();
            this.alert.AlertClick += Alert_AlertClick;
            this.timer = new Timer()
            {
                Interval = 60000,
                Enabled = true
            };
            this.timer.Tick += delegate
            {
                if (this.logedin_user == null) // if not login yet
                    return;

                var new_order = this.GetNewOrderFromServer();

                if (new_order == null)
                    return;

                if(new_order.Count() > 0)
                {
                    this.alert.Show(this, "มีรายการสั่งซื้อใหม่", "จำนวน " + new_order.Count().ToString() + " รายการ");
                }
            };

            this.config = ConfigValue.Load();
            this.btnImport.Enabled = Directory.Exists(this.config.ExpressDataPath) ? true : false;
            this.lblDataPath.Caption = (this.config.ExpressDataPath.Trim().Length == 0 ? "[...]" : "[ " + this.config.ExpressDataPath + " ]");

            this.bs_po = new BindingSource();
            this.gridControl1.DataSource = this.bs_po;

            this.bs_so = new BindingSource();
            this.gridControl2.DataSource = this.bs_so;

            this.bs_iv = new BindingSource();
            this.gridControl3.DataSource = this.bs_iv;

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (this.logedin_user == null)
            {
                LoginDialog login = new LoginDialog(this);
                if (login.ShowDialog() == DialogResult.OK)
                {
                    this.logedin_user = login.user;
                    this.btnRetrieveData.PerformClick();
                    this.SetRibbonButtonState();
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void SetRibbonButtonState()
        {
            this.btnApiUrl.Enabled = this.logedin_user != null && this.logedin_user.Department == InternalUsers.DEPARTMENT.Administrative.ToString() ? true : false;
            this.btnDataPath.Enabled = this.logedin_user != null && this.logedin_user.Department == InternalUsers.DEPARTMENT.Administrative.ToString() ? true : false;
        }

        private void Alert_AlertClick(object sender, AlertClickEventArgs e)
        {
            this.RestoreWindows();
            this.xtraTabControl1.SelectedTabPage = this.tabPagePo;
            this.btnRetrieveData.PerformClick();
        }

        private List<PopritVM> GetNewOrderFromServer()
        {
            APIResult result = new APIResult();
            try
            {
                result = APIClient.GET(this.config.ApiUrl + "poprit/GetOrderByStatus", this.config.ApiKey, "&status=" + POPR_STATUS.PO_NEW.ToString());
                
                List<PopritVM> poprit = JsonConvert.DeserializeObject<List<PopritVM>>(result.ReturnValue);
                return poprit;
            }
            catch (Exception ex)
            {
                if(MessageBox.Show(result.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.GetNewOrderFromServer();
                }
            }
            return null;
        }

        private void btnDataPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataPathDialog dlg = new DataPathDialog(this, this.config.ExpressProgramPath, this.config.ExpressDataPath, this.config.DocPrefix);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                this.config.ExpressProgramPath = dlg.selected_program_path;
                this.config.ExpressDataPath = dlg.selected_data_path;
                this.config.DocPrefix = dlg.selected_doc;
                this.config.Save();
                this.lblDataPath.Caption = (this.config.ExpressDataPath.Trim().Length == 0 ? "[...]" : "[ " + this.config.ExpressDataPath + " ]");

                this.btnImport.Enabled = Directory.Exists(this.config.ExpressDataPath) ? true : false;
            }
        }

        private void btnImport_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //ArMasDialog armas = new ArMasDialog(this);
            //armas.ShowDialog();
            //OpenFileDialog dlg = new OpenFileDialog()
            //{
            //    Filter = "Text file|*.txt",
            //    CheckPathExists = true,
            //    CheckFileExists = true,
            //    RestoreDirectory = true,
            //    Multiselect = false,
            //    Title = "",
            //    SupportMultiDottedExtensions = true,
            //    InitialDirectory = AppDomain.CurrentDomain.BaseDirectory
            //};
            //if(dlg.ShowDialog() == DialogResult.OK)
            //{
            //    using (StreamReader sr = new StreamReader(dlg.FileName, Encoding.GetEncoding("windows-874")))
            //    {
            //        string json = sr.ReadToEnd();
            //        sr.Close();
            //        this.orders = JsonConvert.DeserializeObject<List<Order>>(json);

            //        this.bs.ResetBindings(true);
            //        this.bs.DataSource = this.orders;
            //    }
            //}
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.gridViewPO.VisibleColumns[0].Width = 45;
        }

        public static OleDbConnection createConnection(ConfigValue config)
        {
            return new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + config.ExpressDataPath + @"\");
        }

        private void btnRecSO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();

            string email_to = (string)this.gridViewPO.GetRowCellValue(this.gridViewPO.GetSelectedRows().First(), "DealerEmail");

            Oeso so = new Oeso();
            List<Oesoit> soit = new List<Oesoit>();
            if (this.PrepareInsertItem(so, soit) == false)
            {
                if(this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();

                //foreach (var row_handle in this.gridViewPO.GetSelectedRows())
                //{
                //    this.gridViewPO.UnselectRow(row_handle);
                //}
                return;
            }

            if (this.splashScreenManager1.IsSplashFormVisible)
                this.splashScreenManager1.CloseWaitForm();

            this.splashScreenManager1.ShowWaitForm();

            try
            {
                List<string> completed_ponum = new List<string>();

                if (InsertOeso(this.config, so))
                {
                    if(UpdateIsrunDocnum(this.config, so.sonum))
                    {
                        foreach (var item in soit)
                        {
                            if(InsertOesoit(this.config, item))
                            {
                                if(InsertArtrnrm(this.config, item, "อ้างถึง " + item.ponum))
                                {
                                    if(this.UpdateSoNum2Po(item.poprit_id, item.sonum.PadRight(12) + "-" + item.seqnum.PadLeft(3), item.sodat, this.logedin_user.Id, so.youref) == true)
                                    {
                                        completed_ponum.Add(item.ponum);
                                        continue;
                                    }
                                }
                            }
                        }

                        Reindex reindex = new Reindex(this, new List<EXPRESS_TABLE_NAME> { EXPRESS_TABLE_NAME.OESO, EXPRESS_TABLE_NAME.OESOIT, EXPRESS_TABLE_NAME.ARMAS });
                        reindex.CreateIndex();

                        string all_ponum = string.Empty;
                        foreach (string po_num in completed_ponum)
                        {
                            all_ponum += po_num == completed_ponum.First() ? po_num : "," + po_num;
                        }
                        EMail.Send(email_to, "ยืนยันคำสั่งซื้อหมายเลข " + all_ponum, "เราได้รับคำสั่งซื้อหมายเลข " + all_ponum + " ของคุณแล้ว, คุณจะได้รับอีเมล์อีกครั้งเมื่อสินค้าของคุณได้ถูกจัดส่ง");

                        if (this.splashScreenManager1.IsSplashFormVisible)
                            this.splashScreenManager1.CloseWaitForm();

                        if (MessageBox.Show("บันทึกเป็นใบสั่งขายหมายเลข " + so.sonum + " เรียบร้อย, ต้องการสั่งพิมพ์ใบสั่งขายนี้เลยหรือไม่?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            List<PrintSoVM> print_data = this.LoadPrintItemFromServer(so.sonum).ToPrintModel();
                            if(print_data == null)
                            {
                                MessageBox.Show("ค้นหาข้อมูลที่ท่านต้องการพิมพ์ไม่พบ");
                            }
                            else
                            {
                                this.PrintSo(print_data);
                            }
                        }
                        this.btnRetrieveData.PerformClick();
                    }
                }
            }
            catch (Exception ex)
            {
                if (this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private List<PopritVM> PreparingSelectedItem()
        {
            List<PopritVM> poprit = new List<PopritVM>();
            foreach (int row_handle in this.gridViewPO.GetSelectedRows())
            {
                if (this.gridViewPO.GetRowCellValue(row_handle, colId) != null)
                {
                    int id = (int)this.gridViewPO.GetRowCellValue(row_handle, colId);
                    poprit.Add(
                        this.poprit.Where(p => p.Id == id).FirstOrDefault()
                    );
                }
            };

            return poprit;
        }

        //private ProcessResult ReIndex(string table_name)
        //{
        //    try
        //    {


        //        Process p = new Process();
        //        ProcessStartInfo info = new ProcessStartInfo();
        //        info.FileName = "cmd.exe";
        //        info.RedirectStandardInput = true;
        //        info.UseShellExecute = false;
        //        info.RedirectStandardOutput = true;
        //        info.CreateNoWindow = true;
        //        //info.WorkingDirectory = this.config.ExpressProgramPath;

        //        p.StartInfo = info;
        //        p.Start();

        //        ExpressTableName express_tb = this.GetExpressTableName().Where(ex => ex.name.ToLower() == table_name.ToLower()).FirstOrDefault();

        //        if (express_tb == null) // unknown table
        //            return new ProcessResult() { Success = false, Output = "Table name is unknown." };

        //        using (StreamWriter sw = p.StandardInput)
        //        {
        //            if (sw.BaseStream.CanWrite)
        //            {
        //                sw.WriteLine(this.config.ExpressProgramPath + @"\adm32 " + this.config.ExpressDataPath);
        //                sw.WriteLine(express_tb.seq);
        //                sw.WriteLine("");
        //            }
        //        }
        //        string output = p.StandardOutput.ReadToEnd();
        //        p.WaitForExit();
        //        return new ProcessResult() { Success = true, Output = output };
        //    }
        //    catch (Exception ex)
        //    {
        //        if(MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
        //        {
        //            return this.ReIndex(table_name);
        //        }
        //        return new ProcessResult() { Success = false, Output = ex.Message };
        //    }
        //}

        private List<PopritVM> LoadPrintItemFromServer(string sonum)
        {
            try
            {
                APIResult get = APIClient.GET(this.config.ApiUrl + "Poprit/GetOrderBySonum", this.config.ApiKey, "&sonum=" + sonum);
                if (get.Success)
                {
                    List<PopritVM> print_item = JsonConvert.DeserializeObject<List<PopritVM>>(get.ReturnValue);
                    return print_item;
                }
                else
                {
                    if (MessageBox.Show(get.ErrorMessage, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                    {
                        return this.LoadPrintItemFromServer(sonum);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                if(MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.LoadPrintItemFromServer(sonum);
                }
                return null;
            }
        }

        private void PrintSo(string sonum, DateTime sodat, List<PopritVM> poprit)
        {
            ReportSoDocument rep = new ReportSoDocument();
            rep.DataSource = poprit;
            rep.ShowPreview();
        }

        private void PrintSo(List<PrintSoVM> print_model)
        {
            ReportSoDocument rep = new ReportSoDocument();
            rep.DataSource = print_model;
            rep.FillDataSource();
            rep.ShowPreview();
        }

        private bool PrepareInsertItem(Oeso oeso, List<Oesoit> oesoits)
        {
            #region collecting selected row
            List<PopritVM> poprit = this.PreparingSelectedItem();
            #endregion collecting selected row

            #region preparing Sonum
            List<Isrun> isrun = LoadIsrunFromDBF(this.config);
            if (isrun.Count() == 0)
            {
                if (this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();

                MessageBox.Show("กรุณาระบุที่เก็บข้อมูล Express ให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }

            string next_sonum = this.config.DocPrefix + isrun.Where(i => i.prefix == this.config.DocPrefix).FirstOrDefault().docnum.Trim();
            if (LoadOesoFromDBF(this.config).Where(s => s.sonum.Trim() == next_sonum).Count() > 0)
            {
                do
                {
                    if (this.splashScreenManager1.IsSplashFormVisible)
                        this.splashScreenManager1.CloseWaitForm();

                    MessageBox.Show("ใบสั่งขายเลขที่ \"" + next_sonum + "\" มีอยู่แล้ว", "Message", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                    next_sonum = this.config.DocPrefix + (Convert.ToInt32(next_sonum.Substring(2, next_sonum.Length - 2)) + 1).ToString().FillZeroLeft(7);
                }
                while (LoadOesoFromDBF(this.config).Where(s => s.sonum.Trim() == next_sonum).Count() > 0);
            }
            #endregion preparing Sonum

            #region preparing oeso
            oeso.sorectyp = "0";
            oeso.sonum = next_sonum;
            oeso.sodat = DateTime.Now;
            oeso.flgvat = poprit.First().FlgVat;
            oeso.depcod = "";
            oeso.slmcod = poprit.First().DealerCode;
            oeso.cuscod = "";
            oeso.shipto = "";
            oeso.youref = "";
            oeso.rff = "";
            oeso.areacod = "";
            oeso.paytrm = 0;
            oeso.dlvdat = null;
            oeso.dlvtim = "";
            oeso.dlvdat_it = "Y";
            oeso.nxtseq = poprit.Count.ToString().PadLeft(3);
            oeso.amount = (double)poprit.Sum(p => p.TrnVal);
            oeso.disc = "";
            oeso.discamt = 0d;
            oeso.total = (double)poprit.Sum(p => p.TrnVal) - oeso.discamt;
            oeso.amtrat0 = 0d;
            oeso.vatrat = poprit.First().VatAmt > 0 ? 7 : 0;
            oeso.vatamt = (double)poprit.Sum(p => p.VatAmt);
            oeso.netamt = oeso.total + oeso.vatamt;
            oeso.netval = oeso.netamt;
            oeso.cmpldat = null;
            oeso.docstat = "N";
            oeso.dlvby = "";
            oeso.userid = this.logedin_user.UserName;
            oeso.chgdat = null;
            oeso.userprn = "";
            oeso.prndat = null;
            oeso.prncnt = 0;
            oeso.prntim = "";
            oeso.authid = "";
            oeso.approve = null;
            oeso.billto = "";
            oeso.orgnum = 0;
            #endregion preparing oeso

            #region preparing oesoit
            int seq = 1;
            foreach (var item in poprit)
            {
                oesoits.Add(new Oesoit
                {
                    sorectyp = "0",
                    sonum = next_sonum,
                    seqnum = seq.ToString().PadLeft(3),
                    sodat = oeso.sodat,
                    dlvdat = (item.DlvDat1 != null ? item.DlvDat1 : item.DlvDat2),
                    cuscod = oeso.cuscod,
                    stkcod = item.StkCod,
                    loccod = "",
                    stkdes = item.StkDes,
                    depcod = "",
                    vatcod = "",
                    free = "",
                    ordqty = (double)item.OrdQty,
                    cancelqty = 0d,
                    canceltyp = "",
                    canceldat = null,
                    remqty = (double)item.OrdQty,
                    tfactor = 1d,
                    unitpr = (double)item.UnitPrice,
                    tqucod = item.TquCod,
                    disc = item.DiscAmt.ToString(),
                    discamt = (double)item.DiscAmt,
                    trnval = (double)item.TrnVal,
                    packing = "",
                    ponum = item.PoNum,
                    poprit_id = item.Id
                });
                seq++;
            }
            #endregion preparing oesoit

            if (poprit.GroupBy(d => d.CreBy).Distinct().Count() > 1)  // เลือกตัวแทนมากกว่า 1 ราย
            {
                if (this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();

                MessageBox.Show("รายการที่เลือกต้องมาจากตัวแทนจำหน่ายรายเดียวกันเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }
            else if(poprit.GroupBy(d => d.FlgVat).Distinct().Count() > 1) // เลือกรายการที่มี flgvat ต่างกัน
            {
                if (this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();

                MessageBox.Show("รายการที่เลือกมีประเภทราคาต่างกัน, กรุณาเลือกรายการที่มีประเภทราคาเดียวกัน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }
            else if (poprit.First().DealerType == (int)DEALER_TYPE.สำนักงานบัญชีไฮเทค && poprit.Count() > 1) // เลือกรายการของ สนง.ไฮเทคมากกว่า 1 รายการ
            {
                if (this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();

                MessageBox.Show("รายการสั่งซื้อจาก \"สำนักงานบัญชีไฮเทค\" ต้องเลือกครั้งละ 1 รายการเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }
            else if(poprit.GroupBy(d => d.DlvBy).Distinct().Count() > 1) // เลือกวิธีการรับ/ส่งสินค้า ต่างกัน
            {
                if (this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();

                MessageBox.Show("รายการที่เลือกมีวิธีการส่งสินค้าที่ต่างกัน, กรุณาเลือกรายการที่มีวิธีการส่งสินค้าแบบเดียวกัน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }
            else
            {
                #region confirm so
                if (this.splashScreenManager1.IsSplashFormVisible)
                    this.splashScreenManager1.CloseWaitForm();

                OesoConfirmDialog conf = new OesoConfirmDialog(this, oeso, oesoits, poprit.First());
                if (conf.ShowDialog() != DialogResult.OK)
                {
                    oeso = null;
                    oesoits = null;
                    return false;
                }

                return true;
                #endregion confirm so
            }
        }

        public static List<Oeso> LoadOesoFromDBF(ConfigValue config)
        {
            if (!File.Exists(config.ExpressDataPath + @"\OESO.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            DataTable dt = new DataTable();

            using (OleDbConnection conn = createConnection(config))
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "Select * From OESO";

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }

            return dt.ToList<Oeso>();
        }

        public static List<Isrun> LoadIsrunFromDBF(ConfigValue config)
        {
            if (!File.Exists(config.ExpressDataPath + @"\ISRUN.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            DataTable dt = new DataTable();

            using (OleDbConnection conn = createConnection(config))
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "Select * From ISRUN";

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }

            return dt.ToList<Isrun>();
        }

        public static List<Oesoit> LoadOesoitFromDBF(ConfigValue config)
        {
            if (!File.Exists(config.ExpressDataPath + @"\OESOIT.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            DataTable dt = new DataTable();

            using (OleDbConnection conn = createConnection(config))
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "Select * From OESOIT";

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }

            return dt.ToList<Oesoit>();
        }

        public static List<Armas> LoadArmasFromDBF(ConfigValue config)
        {
            if (!File.Exists(config.ExpressDataPath + @"\ARMAS.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            DataTable dt = new DataTable();

            using (OleDbConnection conn = createConnection(config))
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "Select * From ARMAS";

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }

            return dt.ToList<Armas>();
        }

        public static List<Oeslm> LoadOeslmFromDBF(ConfigValue config)
        {
            if (!File.Exists(config.ExpressDataPath + @"\OESLM.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            DataTable dt = new DataTable();

            using (OleDbConnection conn = createConnection(config))
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "Select * From OESLM";

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }

            return dt.ToList<Oeslm>();
        }

        public static List<Glacc> LoadGlaccFromDBF(ConfigValue config)
        {
            if (!File.Exists(config.ExpressDataPath + @"\GLACC.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            DataTable dt = new DataTable();

            using (OleDbConnection conn = createConnection(config))
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "Select * From GLACC";

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }

            return dt.ToList<Glacc>();
        }

        public static List<Istab> LoadIstabFromDBF(ConfigValue config)
        {
            if (!File.Exists(config.ExpressDataPath + @"\ISTAB.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            DataTable dt = new DataTable();

            using (OleDbConnection conn = createConnection(config))
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "Select * From ISTAB";

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }
            return dt.ToList<Istab>();
        }

        public static List<Stmas> LoadStmasFromDBF(ConfigValue config)
        {
            if (!File.Exists(config.ExpressDataPath + @"\STMAS.DBF"))
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูลโปรแกรม Express ให้ถูกต้อง");
                return null;
            }

            //DataTable stmas = DBFParse.ReadDBF(config.ExpressDataPath + @"\STMAS.DBF");

            DataTable dt = new DataTable();

            using (OleDbConnection conn = createConnection(config))
            {
                // Open the connection, and if open successfully, you can try to query it
                conn.Open();

                if (conn.State == ConnectionState.Open)
                {
                    string sql = "Select * From STMAS Where stktyp='0'";

                    OleDbCommand query = new OleDbCommand(sql, conn);
                    OleDbDataAdapter DA = new OleDbDataAdapter(query);

                    DA.Fill(dt);

                    conn.Close();
                }
            }

            return dt.ToList();
        }

        public static bool InsertOeso(ConfigValue config, Oeso oeso)
        {
            try
            {
                using (OleDbConnection conn = createConnection(config))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        string empty_date = "CTOD('  /  /  ')";

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert Into Oeso ([sorectyp],[sonum],[sodat],[flgvat],[depcod],[slmcod],[cuscod],[shipto],[youref],[rff],[areacod],[paytrm],[dlvdat],[dlvtim],[dlvdat_it],[nxtseq],[amount],[disc],[discamt],[total],[amtrat0],[vatrat],[vatamt],[netamt],[netval],[cmpldat],[docstat],[dlvby],[userid],[chgdat],[userprn],[prndat],[prncnt],[prntim],[authid],[approve],[billto],[orgnum]) Values ";
                        cmd.CommandText += "('" + oeso.sorectyp + "', "; // sorectyp
                        cmd.CommandText += "'" + oeso.sonum + "',"; // sonum
                        cmd.CommandText += "CTOD('" + oeso.sodat.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "'),"; // sodat
                        cmd.CommandText += "'" + oeso.flgvat + "',"; // flgvat
                        cmd.CommandText += "'" + oeso.depcod + "',"; // depcod
                        cmd.CommandText += "'" + oeso.slmcod + "',"; // slmcod
                        cmd.CommandText += "'" + oeso.cuscod + "',"; // cuscod
                        cmd.CommandText += "'" + oeso.shipto + "',"; //shipto
                        cmd.CommandText += "'" + oeso.youref + "',"; // youref
                        cmd.CommandText += "'" + oeso.rff + "',"; // rff
                        cmd.CommandText += "'" + oeso.areacod + "',"; // areacod
                        cmd.CommandText += oeso.paytrm + ","; // paytrm
                        cmd.CommandText += empty_date + ","; // dlvdat
                        cmd.CommandText += "'" + oeso.dlvtim + "',"; // dlvtim
                        cmd.CommandText += "'" + oeso.dlvdat_it + "',"; // dlvdat_it
                        cmd.CommandText += "'" + oeso.nxtseq + "',"; // nxtseq
                        cmd.CommandText += oeso.amount + ","; // amount
                        cmd.CommandText += "'" + oeso.disc + "',"; // disc
                        cmd.CommandText += oeso.discamt + ","; // discamt
                        cmd.CommandText += oeso.total + ","; // total
                        cmd.CommandText += oeso.amtrat0 + ","; // amtrat0
                        cmd.CommandText += oeso.vatrat + ","; // vatrat
                        cmd.CommandText += oeso.vatamt + ","; // vatamt
                        cmd.CommandText += oeso.netamt + ","; // netamt
                        cmd.CommandText += oeso.netval + ","; // netval
                        cmd.CommandText += empty_date + ","; // cmpldat
                        cmd.CommandText += "'" + oeso.docstat + "',"; // docstat
                        cmd.CommandText += "'" + oeso.dlvby + "',"; // dlvby
                        cmd.CommandText += "'" + oeso.userid + "',"; // userid
                        cmd.CommandText += empty_date + ","; // chgdat
                        cmd.CommandText += "'',"; // userprn
                        cmd.CommandText += empty_date + ","; // prndat
                        cmd.CommandText += oeso.prncnt + ","; // prncnt
                        cmd.CommandText += "'',"; // prntim
                        cmd.CommandText += "'',"; // authid
                        cmd.CommandText += empty_date + ","; // approve
                        cmd.CommandText += "'" + oeso.billto + "',"; // billto
                        cmd.CommandText += oeso.orgnum + ")"; // orgnum

                        cmd.Connection = conn;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool InsertOesoit(ConfigValue config, Oesoit oesoit)
        {
            try
            {
                using (OleDbConnection conn = createConnection(config))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        string empty_date = "CTOD('  /  /  ')";

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert Into Oesoit ([sorectyp],[sonum],[seqnum],[sodat],[dlvdat],[cuscod],[stkcod],[loccod],[stkdes],[depcod],[vatcod],[free],[ordqty],[cancelqty],[canceltyp],[canceldat],[remqty],[tfactor],[unitpr],[tqucod],[disc],[discamt],[trnval],[packing]) Values ";
                        cmd.CommandText += "('" + oesoit.sorectyp + "', "; // sorectyp
                        cmd.CommandText += "'" + oesoit.sonum + "', "; // sonum
                        cmd.CommandText += "'" + oesoit.seqnum + "', "; // seqnum
                        cmd.CommandText += "CTOD('" + oesoit.sodat.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "'),"; // sodat
                        cmd.CommandText += oesoit.dlvdat.HasValue ? "CTOD('" + oesoit.dlvdat.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "'), " : empty_date + ", "; // dlvdat
                        //"CTOD('" + oesoit.dlvdat.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "'),"; // dlvdat
                        cmd.CommandText += "'" + oesoit.cuscod + "', "; // cuscod
                        cmd.CommandText += "'" + oesoit.stkcod + "', "; // stkcod
                        cmd.CommandText += "'" + oesoit.loccod + "', "; // loccod
                        cmd.CommandText += "'" + oesoit.stkdes + "', "; //stkdes
                        cmd.CommandText += "'" + oesoit.depcod + "', "; // depcod
                        cmd.CommandText += "'" + oesoit.vatcod + "', "; // vatcod
                        cmd.CommandText += "'" + oesoit.free + "', "; // free
                        cmd.CommandText += oesoit.ordqty + ", "; // ordqty
                        cmd.CommandText += oesoit.cancelqty + ", "; // cancelqty
                        cmd.CommandText += "'" + oesoit.canceltyp + "',"; // canceltyp
                        cmd.CommandText += oesoit.canceldat.HasValue ? "CTOD('" + oesoit.canceldat.Value.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "'), " : empty_date + ", "; // canceldat
                        cmd.CommandText += oesoit.remqty + ", "; // remqty
                        cmd.CommandText += oesoit.tfactor + ", "; // tfactor
                        cmd.CommandText += oesoit.unitpr + ", "; // unitpr
                        cmd.CommandText += "'" + oesoit.tqucod + "', "; // tqucod
                        cmd.CommandText += "'" + oesoit.disc + "', "; // disc
                        cmd.CommandText += oesoit.discamt + ", "; // discamt
                        cmd.CommandText += oesoit.trnval + ", "; // trnval
                        cmd.CommandText += "'" + oesoit.packing + "')"; // packing

                        cmd.Connection = conn;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool InsertArtrnrm(ConfigValue config, Oesoit oesoit, string remark)
        {
            try
            {
                using (OleDbConnection conn = createConnection(config))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert Into Artrnrm ([docnum],[seqnum],[remark]) Values ";
                        cmd.CommandText += "('" + oesoit.sonum + "', "; // sonum
                        cmd.CommandText += "'" + oesoit.seqnum + "', "; // seqnum
                        cmd.CommandText += "'" + remark + "')"; // remark

                        cmd.Connection = conn;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool InsertArmas(ConfigValue config, Armas armas)
        {
            List<Armas> a = LoadArmasFromDBF(config);

            Armas last_cus = a.Where(ar => ar.cuscod.Trim().Substring(0,3) == "*X-").OrderByDescending(ar => ar.cuscod.Trim()).FirstOrDefault();
            armas.cuscod = last_cus == null ? "*X-0000001" : "*X-" + (Convert.ToInt32(last_cus.cuscod.Trim().Substring(3, last_cus.cuscod.Trim().Length - 3)) + 1).ToString().FillZeroLeft(7);

            if (a.Where(ar => ar.cuscod.Trim() == armas.cuscod.Trim()).FirstOrDefault() != null)
            {
                MessageBox.Show("รหัส \"" + armas.cuscod + "\" นี้มีอยู่แล้ว", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

            try
            {
                using (OleDbConnection conn = createConnection(config))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        string empty_date = "CTOD('  /  /  ')";

                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Insert Into Armas ([cuscod],[custyp],[prenam],[cusnam],[addr01],[addr02],[addr03],[zipcod],[telnum],[contact],[cusnam2],[taxid],[orgnum],[taxtyp],[taxrat],[taxgrp],[taxcond],[shipto],[slmcod],[areacod],[paytrm],[paycond],[payer],[tabpr],[disc],[balance],[chqrcv],[crline],[lasivc],[accnum],[remark],[dlvby],[tracksal],[creby],[credat],[userid],[chgdat],[status],[inactdat]) Values ";
                        cmd.CommandText += "('" + armas.cuscod + "', "; // cuscod
                        cmd.CommandText += "'" + armas.custyp + "', "; // custyp
                        cmd.CommandText += "'" + armas.prenam + "', "; // prenam
                        cmd.CommandText += "'" + armas.cusnam + "', "; // cusnam
                        cmd.CommandText += "'" + armas.addr01 + "', "; // addr01
                        cmd.CommandText += "'" + armas.addr02 + "', "; // addr02
                        cmd.CommandText += "'" + armas.addr03 + "', "; // addr03
                        cmd.CommandText += "'" + armas.zipcod + "', "; // zipcod
                        cmd.CommandText += "'" + armas.telnum + "', "; // telnum
                        cmd.CommandText += "'" + armas.contact + "', "; // contact
                        cmd.CommandText += "'" + armas.cusnam2 + "', "; // cusnam2
                        cmd.CommandText += "'" + armas.taxid + "', "; // taxid
                        cmd.CommandText += armas.orgnum + ", "; // orgnum
                        cmd.CommandText += "'" + armas.taxtyp + "', "; // taxtyp
                        cmd.CommandText += armas.taxrat + ", "; // taxrat
                        cmd.CommandText += "'" + armas.taxgrp + "', "; // taxgrp
                        cmd.CommandText += "'" + armas.taxcond + "', "; // taxcond
                        cmd.CommandText += "'" + armas.shipto + "', "; // shipto
                        cmd.CommandText += "'" + armas.slmcod + "', "; // slmcod
                        cmd.CommandText += "'" + armas.areacod + "', "; // areacod
                        cmd.CommandText += armas.paytrm + ", "; // paytrm
                        cmd.CommandText += "'" + armas.paycond + "', "; // paycond
                        cmd.CommandText += "'" + armas.payer + "', "; // payer
                        cmd.CommandText += "'" + armas.tabpr + "', "; // tabpr
                        cmd.CommandText += "'" + armas.disc + "', "; // disc
                        cmd.CommandText += armas.balance + ", "; // balance
                        cmd.CommandText += armas.chqrcv + ", "; // chqrcv
                        cmd.CommandText += armas.crline + ", "; // crline
                        cmd.CommandText += empty_date + ", "; // lasivc
                        cmd.CommandText += "'" + armas.accnum + "', "; // accnum
                        cmd.CommandText += "'" + armas.remark + "', "; // remark
                        cmd.CommandText += "'" + armas.dlvby + "', "; // dlvby
                        cmd.CommandText += "'" + armas.tracksal + "', "; // tracksal
                        cmd.CommandText += "'" + armas.creby + "', "; // creby
                        cmd.CommandText += empty_date + ", "; // credate
                        cmd.CommandText += "'" + armas.userid + "', "; // userid
                        cmd.CommandText += empty_date + ", "; // chgdat
                        cmd.CommandText += "'" + armas.status + "', "; // status
                        cmd.CommandText += empty_date + ")"; // inactdat

                        cmd.Connection = conn;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        public static bool UpdateIsrunDocnum(ConfigValue config, string last_sonum)
        {
            string doc_prefix = last_sonum.Substring(0, 2);
            string doc_num = (Convert.ToInt32(last_sonum.Substring(2, last_sonum.Trim().Length - 2)) + 1).ToString().FillZeroLeft(7);

            try
            {
                using (OleDbConnection conn = createConnection(config))
                {
                    using (OleDbCommand cmd = new OleDbCommand())
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "Update Isrun Set docnum = '" + doc_num + "' Where prefix = '" + doc_prefix + "'";
                        cmd.Connection = conn;
                        conn.Open();
                        if (cmd.ExecuteNonQuery() > 0)
                        {
                            return true;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return false;
        }

        private bool UpdateSoNum2Po(int poprit_id, string sonum_seq, DateTime sodat, int so_by, string so_remark = "")
        {
            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.config.ApiKey,
                poprit = new PopritVM
                {
                    Id = poprit_id,
                    SoNum = sonum_seq,
                    SoDat = sodat,
                    SoBy_Id = so_by,
                    SoRemark = so_remark
                }
            };
            APIResult put = APIClient.PUT(this.config.ApiUrl + "poprit/UpdateSoNum", acc);
            if (put.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show(put.ErrorMessage.RemoveBeginAndEndQuote());
            }
            return false;
        }

        public bool UpdateIvNum2Po(string sonum, string ivnum, DateTime ivdat, int iv_by)
        {
            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.config.ApiKey,
                poprit = new PopritVM
                {
                    SoNum = sonum,
                    IvNum = ivnum,
                    IvDat = ivdat,
                    IvBy_Id = iv_by
                }
            };

            APIResult put = APIClient.PUT(this.config.ApiUrl + "poprit/UpdateIvNum", acc);
            if (put.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show(put.ErrorMessage.RemoveBeginAndEndQuote());
            }
            return false;
        }

        public bool UpdateEmsTracking(string ivnum, string ems_tracking_number)
        {
            var poprit = this.poprit.Where(p => p.IvNum == ivnum).First();
            poprit.EmsTracking = ems_tracking_number;
            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.config.ApiKey,
                poprit = poprit
            };

            APIResult put = APIClient.PUT(this.config.ApiUrl + "poprit/UpdateEmsTracking", acc);
            if (put.Success)
            {
                return true;
            }
            else
            {
                if(MessageBox.Show(put.ErrorMessage.RemoveBeginAndEndQuote(), "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == DialogResult.Retry)
                {
                    return this.UpdateEmsTracking(ivnum, ems_tracking_number);
                }
                return false;
            }
        }

        private void gridViewPO_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            this.btnRecSO.Enabled = (((GridView)sender).SelectedRowsCount > 0 && File.Exists(this.config.ExpressDataPath + @"\oeso.dbf")) ? true : false;
        }

        private void gridViewSO_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            this.btnRecIvNum.Enabled = (((GridView)sender).SelectedRowsCount > 0 ? true : false);
        }

        private void gridViewIV_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            this.btnEmsTracking.Enabled = (((GridView)sender).SelectedRowsCount > 0 ? true : false);
            //int row_handle = ((GridView)sender).selecte
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

        private void btnRetrieveData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.btnRecSO.Enabled = false;
            this.btnRecIvNum.Enabled = false;

            this.splashScreenManager1.ShowWaitForm();
            APIResult result = APIClient.GET(this.config.ApiUrl + "poprit/GetOrder", this.config.ApiKey);

            if (result.Success && result.ReturnValue != null)
            {
                this.poprit = JsonConvert.DeserializeObject<List<PopritVM>>(result.ReturnValue);

                this.bs_po.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_NEW.ToString()).ToList();
                this.bs_po.ResetBindings(true);
                this.gridControl1.DataSource = this.bs_po;

                this.bs_so.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_CONVERTED.ToString()).ToOesoVM().OrderByDescending(o => o.SoNum).ToList();
                this.bs_so.ResetBindings(true);
                this.gridControl2.DataSource = this.bs_so;

                this.bs_iv.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_INVOICED.ToString() || p.Status == POPR_STATUS.PO_DELIVERED.ToString()).ToArtrnVM().OrderBy(o => o.IvNum).ToList();
                this.bs_iv.ResetBindings(true);
                this.gridControl3.DataSource = this.bs_iv;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage.RemoveBeginAndEndQuote());
            }
            this.splashScreenManager1.CloseWaitForm();
        }

        private void gridViewPO_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (((GridView)sender).GetRow(e.RowHandle) == null)
                return;

            if(e.Button == MouseButtons.Left && e.Clicks == 1 && e.Column == this.col_ViewAttachment)
            {
                int id = (int)((GridView)sender).GetRowCellValue(e.RowHandle, this.colId);

                PopritVM poprit = this.poprit.Where(p => p.Id == id).FirstOrDefault();
                if (poprit == null)
                    return;

                ViewAttachFileDialog view = new ViewAttachFileDialog(this, poprit);
                view.ShowDialog();
                e.Handled = true;
            }

            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_convert_to_so = new MenuItem();
                mnu_convert_to_so.Text = "แปลงรายการเป็นใบสั่งขาย";
                mnu_convert_to_so.Click += delegate
                {
                    ((GridView)sender).SelectRows(e.RowHandle, e.RowHandle);
                    this.btnRecSO.PerformClick();
                };

                cm.MenuItems.Add(mnu_convert_to_so);
                cm.Show(this.gridControl1, new Point(e.X, e.Y));
                e.Handled = true;
            }
        }

        private void gridViewSO_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (((GridView)sender).GetRow(e.RowHandle) == null)
                return;

            string sonum = (string)((GridView)sender).GetRowCellValue(e.RowHandle, this.gc2_SoNum);

            if (e.Button == MouseButtons.Left && e.Clicks == 1 && e.Column == this.gc2_Iv)
            {
                RecIvNoDialog reciv = new RecIvNoDialog(this, sonum);
                if (reciv.ShowDialog() == DialogResult.OK)
                {
                    this.btnRetrieveData.PerformClick();
                }
                e.Handled = true;
            }

            if(e.Button == MouseButtons.Left && e.Clicks == 1 && e.Column == this.gc2_Print)
            {
                List<PrintSoVM> print_model = this.LoadPrintItemFromServer(sonum).ToPrintModel();
                if (print_model == null)
                    return;

                this.PrintSo(print_model);
                e.Handled = true;
            }

            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_rec_ivnum = new MenuItem();
                mnu_rec_ivnum.Text = "ทำเครื่องหมายว่า \"เปิดอินวอยซ์แล้ว\"";
                mnu_rec_ivnum.Click += delegate
                {
                    ((GridView)sender).SelectRows(e.RowHandle, e.RowHandle);
                    this.btnRecIvNum.PerformClick();
                };

                cm.MenuItems.Add(mnu_rec_ivnum);
                cm.Show(this.gridControl2, new Point(e.X, e.Y));
                e.Handled = true;
            }
        }

        private void gridViewSO_PO_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (((GridView)sender).GetRow(e.RowHandle) == null)
                return;

            if (e.Column.Name == this.gc2_ViewAttachment.Name)
            {
                var poprit = this.poprit.Where(p => p.Id == (int)((GridView)sender).GetRowCellValue(e.RowHandle, gc2_PoId)).FirstOrDefault();

                if (poprit == null)
                    return;

                ViewAttachFileDialog view = new ViewAttachFileDialog(this, poprit);
                view.ShowDialog();
            }
        }

        private void gridViewIV_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (((GridView)sender).GetRow(e.RowHandle) == null)
                return;

            if(e.Button == MouseButtons.Left && e.Clicks == 1 && e.Column.Name == this.gc3_EmsTrackingNo.Name)
            {
                this.btnEmsTracking.PerformClick();
                e.Handled = true;
            }

            if(e.Button == MouseButtons.Right)
            {
                ContextMenu cm = new ContextMenu();
                MenuItem mnu_rec_ems = new MenuItem();
                mnu_rec_ems.Text = "ป้อนหมายเลข EMS Tracking";
                mnu_rec_ems.Click += delegate
                {
                    ((GridView)sender).SelectRows(e.RowHandle, e.RowHandle);
                    this.btnEmsTracking.PerformClick();
                };

                cm.MenuItems.Add(mnu_rec_ems);
                cm.Show(this.gridControl3, new Point(e.X, e.Y));
                e.Handled = true;
            }
        }

        private void gridViewIV_PO_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (((GridView)sender).GetRow(e.RowHandle) == null)
                return;

            if(e.Column.Name == this.gc3_ViewAttachment.Name)
            {
                var poprit = this.poprit.Where(p => p.Id == (int)((GridView)sender).GetRowCellValue(e.RowHandle, gc3_PoId)).FirstOrDefault();

                if (poprit == null)
                    return;

                ViewAttachFileDialog view = new ViewAttachFileDialog(this, poprit);
                view.ShowDialog();
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            this.btnRecSO.Enabled = false;
            this.btnRecIvNum.Enabled = false;
            this.btnEmsTracking.Enabled = false;

            if(e.Page == this.tabPagePo && this.gridViewPO.SelectedRowsCount > 0)
            {
                this.btnRecSO.Enabled = true;
                return;
            }

            if(e.Page == this.tabPageSo && this.gridViewSO.SelectedRowsCount > 0)
            {
                this.btnRecIvNum.Enabled = true;
                return;
            }

            if (e.Page == this.tabPageIv && this.gridViewIV.SelectedRowsCount > 0)
            {
                this.btnEmsTracking.Enabled = true;
                return;
            }
        }

        private void btnRecIvNum_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            //int[] row_handle = this.gridViewSO.GetSelectedRows();
            //if (row_handle.Count() == 0 || this.gridViewSO.GetRow(row_handle[0]) == null)
            //    return;

            //string sonum = (string)this.gridViewSO.GetRowCellValue(row_handle[0], gc2_SoNum);

            int row_h = this.gridViewSO.FocusedRowHandle;
            if (this.gridViewSO.GetRow(row_h) == null)
                return;

            string sonum = (string)this.gridViewSO.GetRowCellValue(row_h, gc2_SoNum);

            RecIvNoDialog rec = new RecIvNoDialog(this, sonum);
            if(rec.ShowDialog() == DialogResult.OK)
            {
                this.btnRetrieveData.PerformClick();
            }
        }

        private void btnEmsTracking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int row_h = this.gridViewIV.FocusedRowHandle;
            if (this.gridViewIV.GetRow(row_h) == null)
                return;

            string ivnum = (string)this.gridViewIV.GetRowCellValue(row_h, gc3_IvNum);
            string ems = (string)this.gridViewIV.GetRowCellValue(row_h, gc3_EmsTracking);

            EmsTrackingDialog rec = new EmsTrackingDialog(this, ivnum, ems);
            if (rec.ShowDialog() == DialogResult.OK)
            {
                string mail_to = this.poprit.Where(p => p.IvNum == ivnum).First().DealerEmail;
                string po_num = string.Empty;
                foreach (PopritVM po in this.poprit.Where(p => p.IvNum == ivnum))
                {
                    po_num += po.PoNum == this.poprit.Where(p => p.IvNum == ivnum).First().PoNum ? po.PoNum : ", " + po.PoNum;
                }
                EMail.Send(mail_to, "สินค้าตามคำสั่งซื้อหมายเลข " + po_num + " ได้รับการจัดส่งเรียบร้อยแล้ว", "สินค้าตามคำสั่งซื้อหมายเลข " + po_num + " ได้รับการจัดส่งเรียบร้อยแล้ว, หมายเลข EMS Tracking : " + rec.ems);

                this.btnRetrieveData.PerformClick();
            }
        }

        private void btnDealer_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DealerDialog dealer = new DealerDialog(this);
            dealer.ShowDialog();
        }

        private void btnQuCod_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IstabDialog istab = new IstabDialog(this, ISTAB_TABTYP.QUCOD);
            istab.ShowDialog();
        }

        private void btnStkGrp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IstabDialog istab = new IstabDialog(this, ISTAB_TABTYP.STKGRP);
            istab.ShowDialog();
        }

        private void btnDlvBy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IstabDialog istab = new IstabDialog(this, ISTAB_TABTYP.DLVBY);
            istab.ShowDialog();
        }

        private void btnDlvProfile_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DlvProfileDialog dlv = new DlvProfileDialog(this);
            dlv.ShowDialog();
        }

        private void btnStpri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StpriDialog stpri = new StpriDialog(this);
            stpri.ShowDialog();
        }

        private void btnStmas_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            StmasDialog stmas = new StmasDialog(this);
            stmas.ShowDialog();
        }

        private void gridViewPO_MouseMove(object sender, MouseEventArgs e)
        {
            GridHitInfo hi = ((GridView)sender).CalcHitInfo(new Point(e.X, e.Y));
            if(hi.InRowCell && hi.Column.Name == this.col_ViewAttachment.Name)
            {
                this.Cursor = Cursors.Hand;
            }
            else
            {
                this.Cursor = Cursors.Default;
            }
        }

        private void gridView_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if(e.RowHandle == ((GridView)sender).FocusedRowHandle)
            {
                //e.DefaultDraw();
                using(Pen p = new Pen(Color.Red))
                {
                    e.Graphics.DrawLine(p, new Point(e.Bounds.X - 2, e.Bounds.Y - 1), new Point(e.Bounds.X + e.Bounds.Width + 1, e.Bounds.Y - 1));

                    e.Graphics.DrawLine(p, new Point(e.Bounds.X - 2, e.Bounds.Y + e.Bounds.Height), new Point(e.Bounds.X + e.Bounds.Width + 1, e.Bounds.Y + e.Bounds.Height));
                }
                //e.Handled = true;
            }
        }

        private void btnYourefAr_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            IstabDialog dlg = new IstabDialog(this, ISTAB_TABTYP.YOUREF_AR);
            dlg.ShowDialog();
        }

        private void btnFind_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FindDocDialog find = new FindDocDialog(this);
            if(find.ShowDialog() == DialogResult.OK)
            {
                switch (find.selected_field)
                {
                    case FindField.FIELD.PO:
                        this.FindPO(find.docnum);
                        break;
                    case FindField.FIELD.SO:
                        this.FindSO(find.docnum);
                        break;
                    case FindField.FIELD.IV:
                        this.FindIV(find.docnum);
                        break;
                    case FindField.FIELD.EMS:
                        this.FindEMS(find.docnum);
                        break;
                    default:
                        break;
                }
            }
        }

        private void FindPO(string ponum)
        {
            PopritVM poprit = this.poprit.Where(p => p.PoNum.Trim() == ponum.Trim()).FirstOrDefault();
            if (poprit != null)
            {
                if (poprit.Status == POPR_STATUS.PO_NEW.ToString())
                {
                    this.xtraTabControl1.SelectedTabPage = this.tabPagePo;

                    for (int i = 0; i < this.gridViewPO.RowCount; i++)
                    {
                        int row_handle = this.gridViewPO.GetVisibleRowHandle(i);
                        if(((string)this.gridViewPO.GetRowCellValue(row_handle, this.colPoNum)).Trim() == ponum.Trim())
                        {
                            this.gridViewPO.FocusedRowHandle = row_handle;
                            break;
                        }
                    }
                    return;
                }
                else if(poprit.Status == POPR_STATUS.PO_CONVERTED.ToString())
                {
                    this.xtraTabControl1.SelectedTabPage = this.tabPageSo;
                    string sonum = poprit.SoNum.Substring(0, 12).Trim();

                    for (int i = 0; i < this.gridViewSO.RowCount; i++)
                    {
                        int row_handle = this.gridViewSO.GetVisibleRowHandle(i);
                        if(((string)this.gridViewSO.GetRowCellValue(row_handle, this.gc2_SoNum)).Trim() == sonum)
                        {
                            this.gridViewSO.SelectRow(row_handle);
                            this.gridViewSO.FocusedRowHandle = row_handle;
                            this.gridViewSO.ExpandMasterRow(row_handle);
                            break;
                        }
                    }
                    return;
                }
                else if (poprit.Status == POPR_STATUS.PO_INVOICED.ToString())
                {
                    this.xtraTabControl1.SelectedTabPage = this.tabPageIv;
                    string ivnum = poprit.IvNum.Trim();

                    for (int i = 0; i < this.gridViewIV.RowCount; i++)
                    {
                        int row_handle = this.gridViewIV.GetVisibleRowHandle(i);
                        if (((string)this.gridViewIV.GetRowCellValue(row_handle, this.gc3_IvNum)).Trim() == ivnum)
                        {
                            this.gridViewIV.SelectRow(row_handle);
                            this.gridViewIV.FocusedRowHandle = row_handle;
                            this.gridViewIV.ExpandMasterRow(row_handle);
                            break;
                        }
                    }
                    return;
                }
            }
            else
            {
                MessageBox.Show("ค้นหา " + ponum + " ไม่พบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FindSO(string sonum)
        {
            PopritVM poprit = this.poprit.Where(p => p.SoNum != null && p.SoNum.Substring(0, 12).Trim() == sonum.Trim()).FirstOrDefault();
            if(poprit != null)
            {
                if (poprit.Status == POPR_STATUS.PO_CONVERTED.ToString())
                {
                    this.xtraTabControl1.SelectedTabPage = this.tabPageSo;

                    for (int i = 0; i < this.gridViewSO.RowCount; i++)
                    {
                        int row_handle = this.gridViewSO.GetVisibleRowHandle(i);
                        if (((string)this.gridViewSO.GetRowCellValue(row_handle, this.gc2_SoNum)).Trim() == sonum)
                        {
                            this.gridViewSO.SelectRow(row_handle);
                            this.gridViewSO.FocusedRowHandle = row_handle;
                            break;
                        }
                    }
                    return;
                }
                else if (poprit.Status == POPR_STATUS.PO_INVOICED.ToString())
                {
                    this.xtraTabControl1.SelectedTabPage = this.tabPageIv;
                    string ivnum = poprit.IvNum.Trim();

                    for (int i = 0; i < this.gridViewIV.RowCount; i++)
                    {
                        int row_handle = this.gridViewIV.GetVisibleRowHandle(i);
                        if (((string)this.gridViewIV.GetRowCellValue(row_handle, this.gc3_IvNum)).Trim() == ivnum)
                        {
                            this.gridViewIV.SelectRow(row_handle);
                            this.gridViewIV.FocusedRowHandle = row_handle;
                            break;
                        }
                    }
                    return;
                }
            }
            else
            {
                MessageBox.Show("ค้นหา " + sonum + " ไม่พบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FindIV(string ivnum)
        {
            PopritVM poprit = this.poprit.Where(p => p.IvNum != null && p.IvNum.Trim() == ivnum.Trim()).FirstOrDefault();
            if(poprit != null)
            {
                this.xtraTabControl1.SelectedTabPage = this.tabPageIv;

                for (int i = 0; i < this.gridViewIV.RowCount; i++)
                {
                    int row_handle = this.gridViewIV.GetVisibleRowHandle(i);
                    if(((string)this.gridViewIV.GetRowCellValue(row_handle, this.gc3_IvNum)).Trim() == ivnum)
                    {
                        this.gridViewIV.SelectRow(row_handle);
                        this.gridViewIV.FocusedRowHandle = row_handle;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("ค้นหา " + ivnum + " ไม่พบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void FindEMS(string ems_tracking_no)
        {
            PopritVM poprit = this.poprit.Where(p => p.EmsTracking != null && p.EmsTracking.Trim() == ems_tracking_no.Trim()).FirstOrDefault();
            if (poprit != null)
            {
                this.xtraTabControl1.SelectedTabPage = this.tabPageIv;

                for (int i = 0; i < this.gridViewIV.RowCount; i++)
                {
                    int row_handle = this.gridViewIV.GetVisibleRowHandle(i);
                    if (((string)this.gridViewIV.GetRowCellValue(row_handle, this.gc3_EmsTrackingNo)).Trim() == ems_tracking_no)
                    {
                        this.gridViewIV.SelectRow(row_handle);
                        this.gridViewIV.FocusedRowHandle = row_handle;
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("ค้นหา " + ems_tracking_no + " ไม่พบ", "", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if(MessageBox.Show("จัดเรียงข้อมูลทุกระบบในโปรแกรม Express, ทำต่อหรือไม่?", "", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                //Reindex reindex = new Reindex(this);
                //reindex.CreateIndex();
                //if (reindex.Result == true)
                //{
                //    MessageBox.Show("Reindex completed.");
                //}
                ReindexProgressDialog rpd = new ReindexProgressDialog(this, true);
                rpd.ShowDialog();
            }
        }
    }
}
