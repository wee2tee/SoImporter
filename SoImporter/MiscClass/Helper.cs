using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using SoImporter.Model;

namespace SoImporter.MiscClass
{
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
        DEPCOD = 50
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

    public static class Helper
    {
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
            var p = poprits.Where(p1 => p1.SoNum != null).GroupBy(p1 => p1.SoNum);
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

        //public static string formatErrorData(this WebExceptionStatus exception_status)
        //{
        //    switch (exception_status)
        //    {
        //        case WebExceptionStatus.CacheEntryNotFound:
        //            return "CACHE_ENTRY_NOT_FOUND";
        //        case WebExceptionStatus.ConnectFailure:
        //            return "CONNECT_FAILURE";
        //        case WebExceptionStatus.ConnectionClosed:
        //            return "CONNECTION_CLOSED";
        //        case WebExceptionStatus.KeepAliveFailure:
        //            return "KEEP_ALIVE_FAILURE";
        //        case WebExceptionStatus.MessageLengthLimitExceeded:
        //            return "MESSAGE_LENGTH_LIMIT_EXCEEDED";
        //        case WebExceptionStatus.NameResolutionFailure:
        //            return "NAME_RESOLUTION_FAILURE";
        //        case WebExceptionStatus.Pending:
        //            return "PENDING";
        //        case WebExceptionStatus.PipelineFailure:
        //            return "PIPE_LINE_FAILURE";
        //        case WebExceptionStatus.ProtocolError:
        //            return "PROTOCOL_ERROR";
        //        case WebExceptionStatus.ProxyNameResolutionFailure:
        //            return "PROXY_NAME_RESOLUTION_FAILURE";
        //        case WebExceptionStatus.ReceiveFailure:
        //            return "RECEIVE_FAILURE";
        //        case WebExceptionStatus.RequestCanceled:
        //            return "REQUEST_CANCEL";
        //        case WebExceptionStatus.RequestProhibitedByCachePolicy:
        //            return "REQUEST_PROHIBITED_BY_CACHE_POLICY";
        //        case WebExceptionStatus.RequestProhibitedByProxy:
        //            return "REQUEST_PROHIBITED_BY_PROXY";
        //        case WebExceptionStatus.SecureChannelFailure:
        //            return "SECURE_CHANNEL_FAILURE";
        //        case WebExceptionStatus.SendFailure:
        //            return "SEND_FAILURE";
        //        case WebExceptionStatus.ServerProtocolViolation:
        //            return "SERVER_PROTOCOL_VIOLATION";
        //        case WebExceptionStatus.Success:
        //            return "SUCCESS";
        //        case WebExceptionStatus.Timeout:
        //            return "TIME_OUT";
        //        case WebExceptionStatus.TrustFailure:
        //            return "TRUST_FAILURE";
        //        case WebExceptionStatus.UnknownError:
        //            return "UNKNOWN_ERROR";
        //        default:
        //            return "UNKNOWN_ERROR";
        //    }
        //}
    }
}
