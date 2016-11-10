using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Runtime.InteropServices;
using SoImporter.Model;
using DevExpress.XtraEditors;

namespace SoImporter.MiscClass
{
    public enum EXPRESS_TABLE_NAME : int
    {
        APBAL = 1,
        APBIL = 2,
        APMAS = 3,
        APRCPCQ = 4,
        APRCPIT = 5,
        APTRN = 6,
        ARBAL = 7,
        ARBIL = 8,
        ARMAS = 9,
        ARRCPCQ = 10,
        ARRCPIT = 11,
        ARSHIP = 12,
        ARTRN = 13,
        ARTRNRM = 14,
        BKMAS = 15,
        BKTRN = 16,
        BKTRNIT = 17,
        FAMAS = 18,
        GLACC = 19,
        GLBAL = 20,
        GLBUD = 21,
        GLINV = 22,
        GLJNL = 23,
        GLJNLIT = 24,
        GLPTT = 25,
        GLPTTIT = 26,
        GLREP = 27,
        GLREPIT = 28,
        GLTPL = 29,
        GLTPLIT = 30,
        ISACC = 31,
        ISFIXCOD = 32,
        ISREP = 33,
        ISRUN = 34,
        ISSN = 35,
        ISSNIT = 36,
        ISTAB = 37,
        ISTAX = 38,
        ISVAT = 39,
        JBLIST = 40,
        JBMAS = 41,
        OESLM = 42,
        OESO = 43,
        OESOIT = 44,
        POPR = 45,
        POPRIT = 46,
        STBOM = 47,
        STCOD = 48,
        STCRD = 49,
        STLOC = 50,
        STMAS = 51,
        STMIN = 52,
        STPRI = 53,
        STTAK = 54,
        STTRN = 55,
    }

    public enum DEALER_TYPE : int
    {
        ไม่ระบุ = 0,
        ตัวแทนจำหน่ายทั่วไป = 1,
        ตัวแทนจำหน่ายรายใหญ่ = 2,
        สำนักงานบัญชีไฮเทค = 3
    }

    public enum TABPR : int
    {
        ราคาขายล่าสุด = 0,
        ราคาขายที่_1 = 1,
        ราคาขายที่_2 = 2,
        ราคาขายที่_3 = 3,
        ราคาขายที่_4 = 4,
        ราคาขายที่_5 = 5,
    }

    public enum IS_PERCENT
    {
        Y_เปอร์เซ็นต์,
        N_บาท
    }

    public enum DEALER_STATUS
    {
        A_ปกติ,
        X_ห้ามใช้
    }

    public enum ISTAB_TABTYP : int
    {
        QUCOD = 20,
        LOCCOD = 21,
        STKGRP = 22,
        DLVBY = 41,
        DEPCOD = 50,
        YOUREF_AR = 12
    }

    public enum STKTYP : int
    {
        STOCK = 0,
        SET_ORDINARY = 1,
        SET_SPECIAL = 2,
        SERVICE = 3,
        REVENUE = 4,
        EXPENSE = 5
    }

    public enum RECORD_NAVIGATION
    {
        FIRST,
        PREVIOUS,
        NEXT,
        LAST
    }

    public class DealerTypeObj
    {
        public string Desc { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return this.Value.ToString() + " : " + this.Desc;
        }
    }

    public class TabPrObj
    {
        public string Desc { get; set; }
        public int Value { get; set; }

        public override string ToString()
        {
            return this.Value + " : " + this.Desc;
        }
    }

    public class IsPercentObj
    {
        public string Desc { get; set; }
        public bool Value { get; set; }

        public override string ToString()
        {
            return this.Desc;
        }
    }

    public class DealerStatusObj
    {
        public string Desc { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return this.Value + " : " + this.Desc;
        }
    }

    public class ExpressTableName
    {
        public string seq { get; set; }
        public string name { get; set; }

        public override string ToString()
        {
            return this.name;
        }
    }

    public static class Helper
    {
        private const uint SW_RESTORE = 0X09;

        [DllImport("user32.dll")]
        private static extern int ShowWindow(IntPtr hWnd, uint Msg);

        public static void RestoreWindows(this XtraForm form)
        {
            if(form.WindowState == System.Windows.Forms.FormWindowState.Minimized)
            {
                ShowWindow(form.Handle, SW_RESTORE);
            }
        }

        public static List<T> ToList<T>(this DataTable table) where T : class, new()
        {
            try
            {
                List<T> list = new List<T>();

                foreach (var row in table.AsEnumerable())
                {
                    T obj = new T();

                    foreach (var prop in obj.GetType().GetProperties())
                    {
                        try
                        {
                            PropertyInfo propertyInfo = obj.GetType().GetProperty(prop.Name);
                            propertyInfo.SetValue(obj, Convert.ChangeType(row[prop.Name], propertyInfo.PropertyType), null);
                        }
                        catch
                        {
                            continue;
                        }
                    }

                    list.Add(obj);
                }

                return list;
            }
            catch
            {
                return null;
            }
        }

        public static List<Stmas> ToList(this DataTable stmas_dbf)
        {
            List<Stmas> stmas = new List<Stmas>();

            foreach (DataRow row in stmas_dbf.Rows)
            {
                //Console.WriteLine(" .. >> numelem is null : " + row.IsNull("numelem"));

                try
                {
                    Stmas s = new Stmas
                    {
                        stkcod = row.Field<string>("stkcod"),
                        stkdes = row.Field<string>("stkdes"),
                        stkdes2 = row.Field<string>("stkdes2"),
                        stktyp = row.Field<string>("stktyp"),
                        stklev = row.Field<string>("stklev"),
                        stkgrp = row.Field<string>("stkgrp"),
                        barcod = row.Field<string>("barcod"),
                        stkcods = row.Field<string>("stkcods"),
                        acccod = row.Field<string>("acccod"),
                        isinv = row.Field<string>("isinv"),
                        stkclass = row.Field<string>("stkclass"),
                        negallow = row.Field<string>("negallow"),
                        qucod = row.Field<string>("qucod"),
                        cqucod = row.Field<string>("cqucod"),
                        cfactor = row.Field<double>("cfactor"),
                        stnpr = row.Field<double>("stnpr"),
                        ispur = row.Field<string>("ispur"),
                        pqucod = row.Field<string>("pqucod"),
                        pfactor = row.Field<double>("pfactor"),
                        lpurqu = row.Field<string>("lpurqu"),
                        lpurfac = row.Field<double>("lpurfac"),
                        lpurpr = row.Field<double>("lpurpr"),
                        lpdisc = row.Field<string>("lpdisc"),
                        lpurdat = row.Field<DateTime?>("lpurdat"),
                        supcod = row.Field<string>("supcod"),
                        issal = row.Field<string>("issal"),
                        squcod = row.Field<string>("squcod"),
                        sfactor = row.Field<double>("sfactor"),
                        sellpr1 = row.Field<double>("sellpr1"),
                        sellpr2 = row.Field<double>("sellpr2"),
                        sellpr3 = row.Field<double>("sellpr3"),
                        sellpr4 = row.Field<double>("sellpr4"),
                        sellpr5 = row.Field<double>("sellpr5"),
                        tracksal = row.Field<string>("tracksal"),
                        vatcod = row.Field<string>("vatcod"),
                        iscom = row.Field<string>("iscom"),
                        comrat = row.Field<string>("comrat"),
                        lsellqu = row.Field<string>("lsellqu"),
                        lsellfac = row.Field<double>("lsellfac"),
                        lsellpr = row.Field<double>("lsellpr"),
                        lsdisc = row.Field<string>("lsdisc"),
                        lseldat = row.Field<DateTime?>("lseldat"),
                        numelem = row.Field<decimal?>("numelem") ,
                        totbal = row.Field<double>("totbal"),
                        totval = row.Field<double>("totval"),
                        totreo = row.Field<double>("totreo"),
                        totres = row.Field<double>("totres"),
                        opnbal = row.Field<double>("opnbal"),
                        unitpr = row.Field<double>("unitpr"),
                        opnval = row.Field<double>("opnval"),
                        lasupd = row.Field<DateTime?>("lasupd"),
                        packing = row.Field<string>("packing"),
                        mlotnum = row.Field<string>("mlotnum"),
                        mrembal = row.Field<double>("mrembal"),
                        mremval = row.Field<double>("mremval"),
                        remark = row.Field<string>("remark"),
                        dat1 = row.Field<DateTime?>("dat1"),
                        dat2 = row.Field<DateTime?>("dat2"),
                        num1 = row.Field<double>("num1"),
                        str1 = row.Field<string>("str1"),
                        str2 = row.Field<string>("str2"),
                        str3 = row.Field<string>("str3"),
                        str4 = row.Field<string>("str4"),
                        creby = row.Field<string>("creby"),
                        credat = row.Field<DateTime?>("credat"),
                        userid = row.Field<string>("userid"),
                        chgdat = row.Field<DateTime?>("chgdat"),
                        status = row.Field<string>("status"),
                        inactdat = row.Field<DateTime?>("inactdat")
                    };
                    stmas.Add(s);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error for stkcod : " + row.Field<string>("stkcod"));
                    Console.WriteLine(" ... >> " + ex.Message);
                    continue;
                }
            }

            return stmas;
        }

        public static string FillZeroLeft(this string target_string, int result_digit)
        {
            string result = target_string;

            for (int i = 1; i <= result_digit - target_string.Trim().Length; i++)
            {
                result = "0" + result;
            }

            return result;
        }

        public static string GetDealerTypeString(this int? dealer_type_value)
        {
            if (dealer_type_value == null)
                return DEALER_TYPE.ไม่ระบุ.ToString();

            foreach (var item in Enum.GetValues(typeof(DEALER_TYPE)))
            {
                if (dealer_type_value == (int)item)
                {
                    return item.ToString();
                }
            }
            
            return DEALER_TYPE.ไม่ระบุ.ToString();
        }

        public static List<OesoVM> ToOesoVM(this IEnumerable<PopritVM> poprits)
        {
            List<OesoVM> oeso = new List<OesoVM>();
            var p = poprits.Where(p1 => p1.SoNum != null).GroupBy(p1 => p1.SoNum.Substring(0, 12).Trim());
            foreach (var item in p)
            {
                PopritVM poprit = item.First();
                oeso.Add(new OesoVM
                {
                    SoNum = poprit.SoNum.Substring(0, 12).Trim(),
                    SoDat = poprit.SoDat,
                    DealerName = poprit.CreBy,
                    DealerType = poprit.DealerType,
                    CustPreName = poprit.cust.First().PreName,
                    CustName = poprit.cust.First().Name,
                    CustAddr01 = poprit.cust.First().Addr01,
                    CustAddr02 = poprit.cust.First().Addr02,
                    CustAddr03 = poprit.cust.First().Addr03,
                    CustZipCod = poprit.cust.First().ZipCod,
                    CustTaxId = poprit.cust.First().TaxId,
                    CustTelNum = poprit.cust.First().TelNum,
                    CustFaxNum = poprit.cust.First().FaxNum,
                    Remark = poprit.SoRemark,
                    Amount = (double)poprits.Where(po => po.SoNum != null).Where(po => po.SoNum.Substring(0, 12).Trim() == poprit.SoNum.Substring(0, 12).Trim()).Sum(po => po.TrnVal),
                    Disc = poprits.Where(po => po.SoNum != null).Where(po => po.SoNum.Substring(0, 12).Trim() == poprit.SoNum.Substring(0, 12).Trim()).Sum(po => po.DiscAmt).ToString(),
                    DiscAmt = (double)poprits.Where(po => po.SoNum != null).Where(po => po.SoNum.Substring(0, 12).Trim() == poprit.SoNum.Substring(0, 12).Trim()).Sum(po => po.DiscAmt),
                    TaxAmt = (double)poprits.Where(po => po.SoNum != null).Where(po => po.SoNum.Substring(0, 12).Trim() == poprit.SoNum.Substring(0, 12).Trim()).Sum(po => po.TaxAmt),
                    VatAmt = (double)poprits.Where(po => po.SoNum != null).Where(po => po.SoNum.Substring(0, 12).Trim() == poprit.SoNum.Substring(0, 12).Trim()).Sum(po => po.VatAmt),
                    NetAmt = (double)poprits.Where(po => po.SoNum != null).Where(po => po.SoNum.Substring(0, 12).Trim() == poprit.SoNum.Substring(0, 12).Trim()).Sum(po => po.NetAmt),
                    po = poprits.Where(po => po.SoNum != null).Where(po => po.SoNum.Substring(0, 12).Trim() == poprit.SoNum.Substring(0, 12).Trim()).ToList()
                });
            }

            return oeso;
        }

        public static List<ArtrnVM> ToArtrnVM(this IEnumerable<PopritVM> poprits)
        {
            List<ArtrnVM> artrn = new List<ArtrnVM>();

            var p = poprits.Where(p1 => p1.IvNum != null).GroupBy(p1 => p1.IvNum);
            //Console.WriteLine(" .. >> x.count = " + p.Count());
            foreach (var item in p)
            {
                PopritVM poprit = item.First();
                artrn.Add(new ArtrnVM
                {
                    IvNum = poprit.IvNum,
                    IvDat = poprit.IvDat,
                    SoNum = poprit.SoNum.Substring(0, 12).Trim(),
                    SoDat = poprit.SoDat,
                    DealerName = poprit.CreBy,
                    DealerType = poprit.DealerType,
                    CustPreName = poprit.cust.First().PreName,
                    CustName = poprit.cust.First().Name,
                    CustAddr01 = poprit.cust.First().Addr01,
                    CustAddr02 = poprit.cust.First().Addr02,
                    CustAddr03 = poprit.cust.First().Addr03,
                    CustZipCod = poprit.cust.First().ZipCod,
                    CustTaxId = poprit.cust.First().TaxId,
                    CustTelNum = poprit.cust.First().TelNum,
                    CustFaxNum = poprit.cust.First().FaxNum,
                    Remark = poprit.IvRemark,
                    Amount = (double)poprits.Where(po => po.IvNum != null).Where(po => po.IvNum.Trim() == poprit.IvNum.Trim()).Sum(po => po.TrnVal),
                    Disc = poprits.Where(po => po.IvNum != null).Where(po => po.IvNum.Trim() == poprit.IvNum.Trim()).Sum(po => po.DiscAmt).ToString(),
                    DiscAmt = (double)poprits.Where(po => po.IvNum != null).Where(po => po.IvNum.Trim() == poprit.IvNum.Trim()).Sum(po => po.DiscAmt),
                    TaxAmt = (double)poprits.Where(po => po.IvNum != null).Where(po => po.IvNum.Trim() == poprit.IvNum.Trim()).Sum(po => po.TaxAmt),
                    VatAmt = (double)poprits.Where(po => po.IvNum != null).Where(po => po.IvNum.Trim() == poprit.IvNum.Trim()).Sum(po => po.VatAmt),
                    NetAmt = (double)poprits.Where(po => po.IvNum != null).Where(po => po.IvNum.Trim() == poprit.IvNum.Trim()).Sum(po => po.NetAmt),
                    EmsTracking = poprit.EmsTracking,
                    po = poprits.Where(po => po.IvNum != null).Where(po => po.IvNum.Trim() == poprit.IvNum.Trim()).ToList()
                });
            }

            return artrn;
        }

        public static string GetDescription(this ISTAB_TABTYP tabtyp)
        {
            switch (tabtyp)
            {
                case ISTAB_TABTYP.QUCOD:
                    return "หน่วยนับ";
                case ISTAB_TABTYP.LOCCOD:
                    return "คลังสินค้า";
                case ISTAB_TABTYP.STKGRP:
                    return "หมวดสินค้า";
                case ISTAB_TABTYP.DLVBY:
                    return "ขนส่งโดย";
                case ISTAB_TABTYP.DEPCOD:
                    return "แผนก";
                case ISTAB_TABTYP.YOUREF_AR:
                    return "อ้างอิง/หมายเหตุ ใบสั่งขาย";
                default:
                    return "";
            }
        }

        public static List<DealerTypeObj> GetDealerTypeObject(this Object obj)
        {
            List<DealerTypeObj> d = new List<DealerTypeObj>();
            foreach (var item in Enum.GetValues(typeof(DEALER_TYPE)))
            {
                d.Add(new DealerTypeObj
                {
                    Desc = item.ToString(),
                    Value = (int)item
                });
            }
            return d;
        }

        public static List<TabPrObj> GetTabPrObject(this Object obj)
        {
            List<TabPrObj> t = new List<TabPrObj>();
            foreach (var item in Enum.GetValues(typeof(TABPR)))
            {
                t.Add(new TabPrObj
                {
                    Desc = item.ToString().Replace("_", " "),
                    Value = (int)item
                });
            }
            return t;
        }

        public static List<IsPercentObj> GetIsPercentObject(this Object obj)
        {
            List<IsPercentObj> p = new List<IsPercentObj>();
            foreach (var item in Enum.GetValues(typeof(IS_PERCENT)))
            {
                p.Add(new IsPercentObj
                {
                    Desc = item.ToString().Substring(2, item.ToString().Length - 2),
                    Value = item.ToString().Substring(0, 1) == "Y" ? true : false
                });
            }
            return p;
        }

        public static List<DealerStatusObj> GetDealerStatusObject(this Object obj)
        {
            List<DealerStatusObj> d = new List<DealerStatusObj>();
            foreach (var item in Enum.GetValues(typeof(DEALER_STATUS)))
            {
                d.Add(new DealerStatusObj
                {
                    Desc = item.ToString().Substring(2, item.ToString().Length - 2),
                    Value = item.ToString().Substring(0, 1)
                });
            }
            return d;
        }

        public static List<ExpressTableName> GetExpressTableName(this Object obj)
        {
            List<ExpressTableName> l = new List<ExpressTableName>();
            foreach (var item in Enum.GetValues(typeof(EXPRESS_TABLE_NAME)))
            {
                l.Add(new ExpressTableName
                {
                    seq = ((int)item).ToString(),
                    name = item.ToString() + ".DBF"
                });
            }
            return l;
        }

        public static ExpressTableName ToExpressTableName(this EXPRESS_TABLE_NAME table)
        {
            foreach (var item in Enum.GetValues(typeof(EXPRESS_TABLE_NAME)))
            {
                if(item.ToString().ToLower() == table.ToString().ToLower())
                {
                    ExpressTableName tb = new ExpressTableName
                    {
                        seq = ((int)item).ToString(),
                        name = item.ToString() + ".DBF"
                    };
                    return tb;
                }
            }

            return null;
        }

        public static void AddItem<T>(this ComboBoxEdit combobox, List<T> list_object, bool clear_exist_before = false)
        {
            if (clear_exist_before)
            {
                combobox.Properties.Items.Clear();
            }

            foreach (var item in list_object)
            {
                combobox.Properties.Items.Add(item);
            }
        }

        public static string RemoveBeginAndEndQuote(this string string_source)
        {
            return string_source.Trim('"');
        }

        /** Convert Model to View-Model **/
        public static InternalUsersVM ToViewModel(this InternalUsers user)
        {
            InternalUsersVM user_vm = new InternalUsersVM
            {
                Id = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                PasswordHash = user.PasswordHash,
                FullName = user.FullName,
                Department = user.Department,
                Status = user.Status,
                CreDate = user.CreDate,
                NewPassword = string.Empty
            };
            return user_vm;
        }

        public static StmasImportVM ToViewModel(this Stmas stmas, List<Istab> stkgrp_list, List<Istab> qucod_list)
        {
            if (stmas == null)
                return null;

            var grp = stkgrp_list.Where(i => i.typcod.Trim() == stmas.stkgrp.Trim()).FirstOrDefault();
            var stkgrp = new IstabVM
            {
                TabTyp = ((int)ISTAB_TABTYP.STKGRP).ToString(),
                TypCod = stmas.stkgrp.Trim()
            };
            if (grp != null)
            {
                stkgrp.AbbreviateTh = grp.shortnam.Trim();
                stkgrp.AbbreviateEn = grp.shortnam2.Trim();
                stkgrp.TypDesTh = grp.typdes.Trim();
                stkgrp.TypDesEn = grp.typdes2.Trim();
            }
            else
            {
                stkgrp.AbbreviateTh = "";
                stkgrp.AbbreviateEn = "";
                stkgrp.TypDesTh = "";
                stkgrp.TypDesEn = "";
            }

            var qu = qucod_list.Where(i => i.typcod.Trim() == stmas.qucod.Trim()).FirstOrDefault();
            var qucod = new IstabVM
            {
                TabTyp = ((int)ISTAB_TABTYP.QUCOD).ToString(),
                TypCod = stmas.qucod.Trim()
            };
            if (qu != null)
            {
                qucod.AbbreviateTh = qu.shortnam.Trim();
                qucod.AbbreviateEn = qu.shortnam2.Trim();
                qucod.TypDesTh = qu.typdes.Trim();
                qucod.TypDesEn = qu.typdes2.Trim();
            }
            else
            {
                qucod.AbbreviateTh = "";
                qucod.AbbreviateEn = "";
                qucod.TypDesTh = "";
                qucod.TypDesEn = "";
            }

            StmasImportVM st = new StmasImportVM
            {
                Stkcod = stmas.stkcod,
                StkDesTh = stmas.stkdes,
                StkDesEn = stmas.stkdes2,
                Barcod = stmas.barcod,
                StkTyp = stmas.stktyp,
                //StkGrp = stmas.StkGrp,
                //Qucod = stmas.Qucod,
                Sellpr1 = (decimal)stmas.sellpr1,
                Sellpr2 = (decimal)stmas.sellpr2,
                Sellpr3 = (decimal)stmas.sellpr3,
                Sellpr4 = (decimal)stmas.sellpr4,
                Sellpr5 = (decimal)stmas.sellpr5,
                //ProductImg = stmas.ProductImg,
                _StkGrp = stkgrp,
                _QuCod = qucod
            };
            return st;
        }

        public static List<StmasImportVM> ToViewModel(this List<Stmas> stmas_list, List<Istab> stkgrp_list, List<Istab> qucod_list)
        {
            List<StmasImportVM> stmas = new List<StmasImportVM>();
            foreach (var item in stmas_list)
            {
                stmas.Add(item.ToViewModel(stkgrp_list, qucod_list));
            }

            return stmas;
        }

        /** Convert poprit to print_model(PrintSoVM) **/
        public static PrintSoVM ToPrintModel(this PopritVM item)
        {
            if (item == null)
                return null;

            PrintSoVM print_model = new PrintSoVM
            {
                Id = item.Id,
                PoNum = item.PoNum,
                PoDat = item.PoDat,
                SoNum = (item.SoNum != null ? item.SoNum.Substring(0, 12).Trim() : ""),
                SoDat = item.SoDat,
                SeqNum = (item.SoNum != null ? item.SoNum.Substring(13, 3).Trim() : ""),
                PrintSeq = string.Empty,
                IvNum = (item.IvNum != null ? item.IvNum : ""),
                IvDat = item.IvDat,
                FlgVat = item.FlgVat,
                DlvBy = item.DlvBy,
                DlvDat1 = item.DlvDat1,
                DlvDat2 = item.DlvDat2,
                DealerCode = item.DealerCode,
                DealerPrename = item.DealerPreName,
                DealerName = item.DealerName,
                CustPrename = item.cust.First().PreName,
                CustName = item.cust.First().Name,
                CustTaxID = item.cust.First().TaxId,
                CustAddr01 = item.cust.First().Addr01,
                CustAddr02 = item.cust.First().Addr02,
                CustAddr03 = item.cust.First().Addr03,
                CustZipCod = item.cust.First().ZipCod,
                CustTelNum = item.cust.First().TelNum,
                CustFaxNum = item.cust.First().FaxNum,
                EmsTracking = item.EmsTracking,
                SoBy_Id = item.SoBy_Id,
                SoBy_Name = item.SoBy_Name,
                IvBy_Id = item.IvBy_Id,
                IvBy_Name = item.IvBy_Name,
                RemarkPO = item.Remark,
                RemarkSO = item.SoRemark,
                RemarkIV = item.IvRemark,

                StkCod = item.StkCod,
                StkDes = item.StkDes,
                OrdQty = item.OrdQty,
                TquCod = item.TquCod,
                UnitPrice = item.UnitPrice,
                DiscAmt = item.DiscAmt,
                TrnVal = item.TrnVal,
                VatAmt = item.VatAmt,
                TaxAmt = item.TaxAmt,
                NetAmt = item.NetAmt
            };

            return print_model;
        }

        public static List<PrintSoVM> ToPrintModel(this List<PopritVM> source_list)
        {
            List<PrintSoVM> print_model = new List<PrintSoVM>();
            foreach (var item in source_list)
            {
                print_model.Add(item.ToPrintModel());
            }

            return print_model;
        }

        public static List<string> ToTypdesStringValue(this List<IstabVM> istab)
        {
            List<string> list = new List<string>();
            foreach (IstabVM item in istab)
            {
                list.Add(item.TypDesTh);
            }

            return list;
        }
    }
}
