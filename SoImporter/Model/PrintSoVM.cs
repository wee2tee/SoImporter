using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using SoImporter.SubForm;
using SoImporter.MiscClass;
using SoImporter.Model;

namespace SoImporter.Model
{
    public class PrintSoVM
    {
        public int Id { get; set; }
        public string PoNum { get; set; }
        public DateTime PoDat { get; set; }
        public string SoNum { get; set; }
        public DateTime? SoDat { get; set; }
        public string SeqNum { get; set; }
        public string PrintSeq { get; set; }
        public string IvNum { get; set; }
        public DateTime? IvDat { get; set; }
        public string FlgVat { get; set; }
        public string DlvBy { get; set; }
        public DateTime? DlvDat1 { get; set; }
        public DateTime? DlvDat2 { get; set; }
        public string DealerCode { get; set; }
        public string DealerPrename { get; set; }
        public string DealerName { get; set; }
        public string CustPrename { get; set; }
        public string CustName { get; set; }
        public string CustTaxID { get; set; }
        public string CustAddr01 { get; set; }
        public string CustAddr02 { get; set; }
        public string CustAddr03 { get; set; }
        public string CustZipCod { get; set; }
        public string CustTelNum { get; set; }
        public string CustFaxNum { get; set; }
        public string EmsTracking { get; set; }
        public int? SoBy_Id { get; set; }
        public string SoBy_Name { get; set; }
        public int? IvBy_Id { get; set; }
        public string IvBy_Name { get; set; }
        public string RemarkPO { get; set; }
        public string RemarkSO { get; set; }
        public string RemarkIV { get; set; }

        public string StkCod { get; set; }
        public string StkDes { get; set; }
        public decimal OrdQty { get; set; }
        public string TquCod { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal DiscAmt { get; set; }
        public decimal TrnVal { get; set; }
        public decimal VatAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal NetAmt { get; set; }

        /** Compound field **/
        public string _Dealer
        {
            get
            {
                return this.DealerCode + " / " + this.DealerPrename + " " + this.DealerName;
            }
        }

        public string _Sodat
        {
            get
            {
                return this.SoDat.HasValue ? this.SoDat.Value.ToString("dd/MM/yy", CultureInfo.GetCultureInfo("th-TH")) : "";
            }
        }

        public string _CustName
        {
            get
            {
                return this.CustPrename + " " + this.CustName;
            }
        }

        public string _CustAddr
        {
            get
            {
                return this.CustAddr01 + " " + this.CustAddr02 + " " + this.CustAddr03 + " " + this.CustZipCod;
            }
        }

        public string _DlvDat
        {
            get
            {
                var dlv1 = this.DlvDat1.HasValue ? this.DlvDat1.Value.ToString("dd/MM/yy", CultureInfo.GetCultureInfo("th-TH")) : "";
                var dlv2 = this.DlvDat2.HasValue ? this.DlvDat2.Value.ToString("dd/MM/yy", CultureInfo.GetCultureInfo("th-TH")) : "";

                var _dlvdat = dlv1 + (dlv1.Length > 0 && dlv2.Length > 0 ? ", " : "") + dlv2;
                return _dlvdat;
            }
        }

        public string _PoRef
        {
            get
            {
                return this.PoNum + " (" + this.PoDat.ToString("dd/MM/yy", CultureInfo.GetCultureInfo("th-TH")) + ")";
            }
        }

        public string _Stk
        {
            get
            {
                return this.StkCod + " / " + this.StkDes;
            }
        }

        public string _OrdQty
        {
            get
            {
                return string.Format("{0:#,#0.00}", this.OrdQty);
            }
        }

        public string _UnitPrice
        {
            get
            {
                return string.Format("{0:#,#0.00}", this.UnitPrice);
            }
        }

        public string _TrnVal
        {
            get
            {
                return string.Format("{0:#,#0.00}", this.TrnVal);
            }
        }

        public string _RemarkPO
        {
            get
            {
                if (this.RemarkPO == null)
                    return null;

                return "หมายเหตุ : " + this.RemarkPO;
            }
        }
    }
}
