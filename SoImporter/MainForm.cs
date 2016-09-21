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
using System.Net;
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
        private List<PopritVM> poprit;
        private BindingSource bs;
        public InternalUsers logedin_user;
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
            this.config = ConfigValue.Load();
            this.btnImport.Enabled = Directory.Exists(this.config.ExpressDataPath) ? true : false;
            this.lblDataPath.Caption = (this.config.ExpressDataPath.Trim().Length == 0 ? "[...]" : "[ " + this.config.ExpressDataPath + " ]");
            this.bs = new BindingSource();
            this.bs.DataSource = this.poprit;
            this.gridControl1.DataSource = this.bs;
            //this.configInfo();
        }

        private void btnDataPath_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            DataPathDialog dlg = new DataPathDialog(this, this.config.ExpressDataPath, this.config.DocPrefix);
            if(dlg.ShowDialog() == DialogResult.OK)
            {
                this.config.ExpressDataPath = dlg.selected_path;
                this.config.DocPrefix = dlg.selected_doc;
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
            this.gridView1.VisibleColumns[0].Width = 45;
        }

        public static OleDbConnection createConnection(ConfigValue config)
        {
            return new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + config.ExpressDataPath + @"\");
        }

        //private void btnRecSO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    try
        //    {
        //        List<Oeso> oeso = this.OesoToList();

        //        if (oeso == null)
        //        {
        //            return;
        //        }

        //        string last_sonum = oeso.OrderByDescending(o => o.sonum).First().sonum;
        //        string next_sonum = last_sonum.Substring(0, 2) + (Convert.ToInt32(last_sonum.Substring(2, last_sonum.Trim().Length - 2)) + 1).ToString().FillZeroLeft(7);

        //        if (File.Exists(this.config.ExpressDataPath + @"\OESO.DBF"))
        //            File.Copy(this.config.ExpressDataPath + @"\OESO.DBF", this.config.ExpressDataPath + @"\OESO.DBF.BAK", true);

        //        if (File.Exists(this.config.ExpressDataPath + @"\OESOIT.DBF"))
        //            File.Copy(this.config.ExpressDataPath + @"\OESOIT.DBF", this.config.ExpressDataPath + @"\OESOIT.DBF.BAK", true);

        //        using (OleDbConnection conn = this.createConnection())
        //        {
        //            using (OleDbCommand cmd = new OleDbCommand())
        //            {
        //                string empty_date = "CTOD('  /  /  ')";

        //                cmd.CommandType = CommandType.Text;
        //                cmd.CommandText = "Insert Into Oeso ([sorectyp],[sonum],[sodat],[flgvat],[depcod],[slmcod],[cuscod],[shipto],[youref],[rff],[areacod],[paytrm],[dlvdat],[dlvtim],[dlvdat_it],[nxtseq],[amount],[disc],[discamt],[total],[amtrat0],[vatrat],[vatamt],[netamt],[netval],[cmpldat],[docstat],[dlvby],[userid],[chgdat],[userprn],[prndat],[prncnt],[prntim],[authid],[approve],[billto],[orgnum]) Values ";
        //                cmd.CommandText += "('0', "; // sorectyp
        //                cmd.CommandText += "'" + next_sonum + "',"; // sonum
        //                cmd.CommandText += "CTOD('" + DateTime.Now.ToString("MM/dd/yyyy", CultureInfo.GetCultureInfo("en-US")) + "'),"; // sodat
        //                cmd.CommandText += "'2',"; // flgvat
        //                cmd.CommandText += "'',"; // depcod
        //                cmd.CommandText += "'',"; // slmcod
        //                cmd.CommandText += "'',"; // cuscod
        //                cmd.CommandText += "'',"; //shipto
        //                cmd.CommandText += "'',"; // youref
        //                cmd.CommandText += "'',"; // rff
        //                cmd.CommandText += "'',"; // areacod
        //                cmd.CommandText += "0,"; // paytrm
        //                cmd.CommandText += empty_date + ","; // dlvdat
        //                cmd.CommandText += "'',"; // dlvtim
        //                cmd.CommandText += "'',"; // dlvdat_it
        //                cmd.CommandText += "'',"; // nxtseq
        //                cmd.CommandText += "14500,"; // amount
        //                cmd.CommandText += "'',"; // disc
        //                cmd.CommandText += "0,"; // discamt
        //                cmd.CommandText += "14500,"; // total
        //                cmd.CommandText += "0,"; // amtrat0
        //                cmd.CommandText += "7,"; // vatrat
        //                cmd.CommandText += "1015,"; // vatamt
        //                cmd.CommandText += "15515,"; // netamt
        //                cmd.CommandText += "15515,"; // netval
        //                cmd.CommandText += empty_date + ","; // cmpldat
        //                cmd.CommandText += "'N',"; // docstat
        //                cmd.CommandText += "'EM',"; // dlvby
        //                cmd.CommandText += "'BIT5',"; // userid
        //                cmd.CommandText += empty_date + ","; // chgdat
        //                cmd.CommandText += "'',"; // userprn
        //                cmd.CommandText += empty_date + ","; // prndat
        //                cmd.CommandText += "0,"; // prncnt
        //                cmd.CommandText += "'',"; // prntim
        //                cmd.CommandText += "'',"; // authid
        //                cmd.CommandText += empty_date + ","; // approve
        //                cmd.CommandText += "'',"; // billto
        //                cmd.CommandText += "0)"; // orgnum

        //                cmd.Connection = conn;
        //                conn.Open();
        //                if (cmd.ExecuteNonQuery() > 0)
        //                {
        //                    Console.WriteLine(" .. >> insert oeso successfully");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show(ex.Message);
        //    }
        //}

        private void btnRecSO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Oeso so = new Oeso();
            List<Oesoit> soit = new List<Oesoit>();
            if (this.PrepareInsertItem(so, soit) == false)
                return;

            try
            {
                if (InsertOeso(this.config, so))
                {
                    if(UpdateIsrunDocnum(this.config, so.sonum))
                    {
                        foreach (var item in soit)
                        {
                            if(InsertOesoit(this.config, item))
                            {
                                InsertArtrnrm(this.config, item, "อ้างถึง " + item.ponum);
                            }
                        }
                        MessageBox.Show("บันทึกเป็นใบสั่งขายหมายเลข \"" + so.sonum + "\" เรียบร้อย");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private bool PrepareInsertItem(Oeso oeso, List<Oesoit> oesoits)
        {
            #region collecting selected row
            List<PopritVM> poprit = new List<PopritVM>();
            foreach (int row_handle in this.gridView1.GetSelectedRows())
            {
                if(this.gridView1.GetRowCellValue(row_handle, colId) != null)
                {
                    int id = (int)this.gridView1.GetRowCellValue(row_handle, colId);
                    poprit.Add(
                        this.poprit.Where(p => p.Id == id).FirstOrDefault()
                    );
                }
            };
            #endregion collecting selected row

            #region preparing Sonum
            List<Isrun> isrun = LoadIsrunFromDBF(this.config);
            if (isrun.Count() == 0)
            {
                MessageBox.Show("กรุณาระบุที่เก็บข้อมูล Express ให้ถูกต้อง", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }

            string next_sonum = this.config.DocPrefix + isrun.Where(i => i.doctyp == this.config.DocPrefix).FirstOrDefault().docnum.Trim();
            if (LoadOesoFromDBF(this.config).Where(s => s.sonum.Trim() == next_sonum).Count() > 0)
            {
                do
                {
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
                    ponum = item.PoNum
                });
                seq++;
            }
            #endregion preparing oesoit

            if (poprit.GroupBy(d => d.CreBy).Distinct().Count() > 1)  // เลือกตัวแทนมากกว่า 1 ราย
            {
                MessageBox.Show("รายการที่เลือกต้องมาจากตัวแทนจำหน่ายรายเดียวกันเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }
            else if(poprit.GroupBy(d => d.FlgVat).Distinct().Count() > 1) // เลือกรายการที่มี flgvat ต่างกัน
            {
                MessageBox.Show("รายการที่เลือกมีประเภทราคาต่างกัน, กรุณาเลือกรายการที่มีประเภทราคาเดียวกัน", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }
            else if(poprit.First().DealerType == (int)DEALER_TYPE.สำนักงานบัญชีไฮเทค && poprit.Count() > 1) // เลือกรายการของ สนง.ไฮเทคมากกว่า 1 รายการ
            {
                MessageBox.Show("รายการสั่งซื้อจาก \"สำนักงานบัญชีไฮเทค\" ต้องเลือกครั้งละ 1 รายการเท่านั้น", "Error", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                oeso = null;
                oesoits = null;
                return false;
            }
            else
            {
                #region confirm so
                OesoConfirmDialog conf = new OesoConfirmDialog(this, oeso, oesoits, poprit.First());
                if (conf.ShowDialog() != DialogResult.OK)
                {
                    oeso = null;
                    oesoits = null;
                    return false;
                }

                Console.WriteLine(".. >> " + oeso.cuscod);

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

        private void gridView1_SelectionChanged(object sender, DevExpress.Data.SelectionChangedEventArgs e)
        {
            //Console.WriteLine(" .. >> checked : " + ((GridView)sender).SelectedRowsCount);
            this.btnRecSO.Enabled = (((GridView)sender).SelectedRowsCount > 0 && File.Exists(this.config.ExpressDataPath + @"\oeso.dbf")) ? true : false;
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

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if(this.logedin_user == null)
            {
                LoginDialog login = new LoginDialog(this);
                if(login.ShowDialog() == DialogResult.OK)
                {
                    this.logedin_user = login.user;
                    
                }
                else
                {
                    this.Close();
                }
            }
        }

        private void btnRetrieveData_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            this.splashScreenManager1.ShowWaitForm();
            APIResult result = APIClient.GET(this.config.ApiUrl + "poprit/GetOrder", this.config.ApiKey);

            if (result.Success && result.ReturnValue != null)
            {
                this.poprit = JsonConvert.DeserializeObject<List<PopritVM>>(result.ReturnValue);
                this.bs.DataSource = this.poprit;
                this.bs.ResetBindings(true);
                this.gridControl1.DataSource = this.bs;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
            this.splashScreenManager1.CloseWaitForm();
        }

        private void gridView1_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (this.gridView1.GetRow(e.RowHandle) == null)
                return;

            int id = (int)this.gridView1.GetRowCellValue(e.RowHandle, colId);

            PopritVM poprit = this.poprit.Where(p => p.Id == id).FirstOrDefault();
            if (poprit == null)
                return;

            if(e.Column == this.col_ViewAttachment)
            {
                ViewAttachFileDialog view = new ViewAttachFileDialog(this, poprit);
                view.ShowDialog();
            }
        }
    }
}
