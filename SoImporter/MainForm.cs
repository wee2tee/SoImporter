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
        private BindingSource bs_po;
        private BindingSource bs_so;
        private BindingSource bs_iv;
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
            this.bs_po = new BindingSource();
            //this.bs_po.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_NEW.ToString());
            this.gridControl1.DataSource = this.bs_po;

            this.bs_so = new BindingSource();
            //this.bs_so.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_CONVERTED.ToString());
            this.gridControl2.DataSource = this.bs_so;

            this.bs_iv = new BindingSource();
            //this.bs_iv.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_INVOICED.ToString());
            this.gridControl3.DataSource = this.bs_iv;
            
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
            this.gridViewPO.VisibleColumns[0].Width = 45;
        }

        public static OleDbConnection createConnection(ConfigValue config)
        {
            return new OleDbConnection(@"Provider=VFPOLEDB.1;Data Source=" + config.ExpressDataPath + @"\");
        }

        private void btnRecSO_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Oeso so = new Oeso();
            List<Oesoit> soit = new List<Oesoit>();
            if (this.PrepareInsertItem(so, soit) == false)
            {
                return;
            }

            this.splashScreenManager1.ShowWaitForm();
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
                                if(InsertArtrnrm(this.config, item, "อ้างถึง " + item.ponum))
                                {
                                    if(this.UpdateSoNum2Po(item.poprit_id, item.sonum.PadRight(12) + "-" + item.seqnum.PadLeft(3), item.sodat, this.logedin_user.Id, so.youref) == true)
                                    {
                                        this.splashScreenManager1.CloseWaitForm();
                                        this.btnRetrieveData.PerformClick();
                                    }
                                }
                            }
                        }
                        MessageBox.Show("บันทึกเป็นใบสั่งขายหมายเลข \"" + so.sonum + "\" เรียบร้อย");
                    }
                }
            }
            catch (Exception ex)
            {
                this.splashScreenManager1.CloseWaitForm();
                MessageBox.Show(ex.Message, "Error");
            }
        }

        private bool PrepareInsertItem(Oeso oeso, List<Oesoit> oesoits)
        {
            #region collecting selected row
            List<PopritVM> poprit = new List<PopritVM>();
            foreach (int row_handle in this.gridViewPO.GetSelectedRows())
            {
                if(this.gridViewPO.GetRowCellValue(row_handle, colId) != null)
                {
                    int id = (int)this.gridViewPO.GetRowCellValue(row_handle, colId);
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
                    ponum = item.PoNum,
                    poprit_id = item.Id
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
                    SoBy = so_by,
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
                MessageBox.Show(put.ErrorMessage);
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
                    IvBy = iv_by
                }
            };

            APIResult put = APIClient.PUT(this.config.ApiUrl + "poprit/UpdateIvNum", acc);
            if (put.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show(put.ErrorMessage);
            }
            return false;
        }

        public bool UpdateEmsTracking(string ivnum, string ems_tracking_number)
        {
            ApiAccessibilities acc = new ApiAccessibilities
            {
                API_KEY = this.config.ApiKey,
                poprit = new PopritVM
                {
                    IvNum = ivnum,
                    EmsTracking = ems_tracking_number
                }
            };

            APIResult put = APIClient.PUT(this.config.ApiUrl + "poprit/UpdateEmsTracking", acc);
            if (put.Success)
            {
                return true;
            }
            else
            {
                MessageBox.Show(put.ErrorMessage);
            }
            return false;
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

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if(this.logedin_user == null)
            {
                LoginDialog login = new LoginDialog(this);
                if(login.ShowDialog() == DialogResult.OK)
                {
                    this.logedin_user = login.user;
                    this.btnRetrieveData.PerformClick();
                }
                else
                {
                    this.Close();
                }
            }
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

                this.bs_po.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_NEW.ToString());
                this.bs_po.ResetBindings(true);
                this.gridControl1.DataSource = this.bs_po;

                this.bs_so.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_CONVERTED.ToString()).ToOesoVM().OrderBy(o => o.SoNum);
                this.bs_so.ResetBindings(true);
                this.gridControl2.DataSource = this.bs_so;

                this.bs_iv.DataSource = this.poprit.Where(p => p.Status == POPR_STATUS.PO_INVOICED.ToString()).ToArtrnVM().OrderBy(o => o.IvNum);
                this.bs_iv.ResetBindings(true);
                this.gridControl3.DataSource = this.bs_iv;
            }
            else
            {
                MessageBox.Show(result.ErrorMessage);
            }
            this.splashScreenManager1.CloseWaitForm();
        }

        private void gridViewPO_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (((GridView)sender).GetRow(e.RowHandle) == null)
                return;

            if(e.Column == this.col_ViewAttachment)
            {
                int id = (int)((GridView)sender).GetRowCellValue(e.RowHandle, this.colId);

                PopritVM poprit = this.poprit.Where(p => p.Id == id).FirstOrDefault();
                if (poprit == null)
                    return;

                ViewAttachFileDialog view = new ViewAttachFileDialog(this, poprit);
                view.ShowDialog();
            }
        }

        private void gridViewSO_RowCellClick(object sender, RowCellClickEventArgs e)
        {
            if (((GridView)sender).GetRow(e.RowHandle) == null)
                return;

            if(e.Column == this.gc2_Iv)
            {
                string sonum = (string)((GridView)sender).GetRowCellValue(e.RowHandle, this.gc2_SoNum);
                RecIvNoDialog reciv = new RecIvNoDialog(this, sonum);
                if (reciv.ShowDialog() == DialogResult.OK)
                {
                    this.btnRetrieveData.PerformClick();
                }
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

            if(e.Column.Name == this.gc3_EmsTrackingNo.Name)
            {
                string ivnum = (string)((GridView)sender).GetRowCellValue(e.RowHandle, this.gc3_IvNum);
                RecEmsTrackingDialog rec_ems = new RecEmsTrackingDialog(this, ivnum);
                if (rec_ems.ShowDialog() == DialogResult.OK)
                {
                    this.btnRetrieveData.PerformClick();
                }
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
            int[] row_handle = this.gridViewSO.GetSelectedRows();
            if (row_handle.Count() == 0 || this.gridViewSO.GetRow(row_handle[0]) == null)
                return;

            string sonum = (string)this.gridViewSO.GetRowCellValue(row_handle[0], gc2_SoNum);

            RecIvNoDialog rec = new RecIvNoDialog(this, sonum);
            if(rec.ShowDialog() == DialogResult.OK)
            {
                this.btnRetrieveData.PerformClick();
            }
        }

        private void btnEmsTracking_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            int[] row_handle = this.gridViewIV.GetSelectedRows();
            if (row_handle.Count() == 0 || this.gridViewIV.GetRow(row_handle[0]) == null)
                return;

            string ivnum = (string)this.gridViewIV.GetRowCellValue(row_handle[0], gc3_IvNum);

            RecEmsTrackingDialog rec = new RecEmsTrackingDialog(this, ivnum);
            if (rec.ShowDialog() == DialogResult.OK)
            {
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

        }
    }
}
