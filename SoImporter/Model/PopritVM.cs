using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoImporter.MiscClass;

namespace SoImporter.Model
{
    public enum POPR_STATUS : int
    {
        PO_PREPARE = 0,
        PO_NEW = 1,
        PO_CONVERTED = 2,
        PO_INVOICED = 3,
        PO_COMPLETED = 4,
        PO_DELIVERED = 5,
        PO_CANCELED = 6
    }

    public class PopritVM
    {
        public int Id { get; set; }
        public string PoNum { get; set; }
        public DateTime PoDat { get; set; }
        public string SoNum { get; set; }
        public DateTime? SoDat { get; set; }
        public int? SoBy_Id { get; set; }
        public string SoBy_Name { get; set; }
        public string SoRemark { get; set; }
        public string IvNum { get; set; }
        public DateTime? IvDat { get; set; }
        public int? IvBy_Id { get; set; }
        public string IvBy_Name { get; set; }
        public string IvRemark { get; set; }
        public string EmsTracking { get; set; }
        public string FlgVat { get; set; }
        public string DlvBy { get; set; }
        public DateTime? DlvDat1 { get; set; }
        public DateTime? DlvDat2 { get; set; }
        public string Remark { get; set; }
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
        public string CreBy { get; set; }
        public DateTime CreDate { get; set; }
        public string DealerCode { get; set; }
        public string DealerPreName { get; set; }
        public string DealerName { get; set; }
        public int? DealerType { get; set; }
        public string _DealerType
        {
            get
            {
                return this.DealerType.GetDealerTypeString();
            }
        }
        //public string CustPreName { get; set; }
        //public string CustName { get; set; }
        //public string CustAddr01 { get; set; }
        //public string CustAddr02 { get; set; }
        //public string CustAddr03 { get; set; }
        //public string CustZipCod { get; set; }
        //public string CustTelNum { get; set; }
        //public string CustFaxNum { get; set; }
        //public string CustTaxId { get; set; }
        public string Status { get; set; }
        public string SlipFileName { get; set; }
        public string TaxFileName { get; set; }

        public List<CustVM> cust { get; set; }


        /** fake field value **/
        public string _ViewAttachment
        {
            get
            {
                return "View";
            }
        }
    }
}
