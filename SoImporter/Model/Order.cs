using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class Order
    {
        public string SoNum { get; set; }
        public DateTime SoDat { get; set; }
        public string PoNum { get; set; }
        public string DealerCode { get; set; }
        public string CustPreName { get; set; }
        public string CustName { get; set; }
        public string CustAddr01 { get; set; }
        public string CustAddr02 { get; set; }
        public string CustAddr03 { get; set; }
        public string CustZipCod { get; set; }
        public string CustTaxId { get; set; }
        public string CustTelNum { get; set; }
        public string CustFaxNum { get; set; }
        public string StkCod { get; set; }
        public decimal OrdQty { get; set; }
        public decimal TrnVal { get; set; }
        public decimal VatAmt { get; set; }
        public decimal TaxAmt { get; set; }
        public decimal NetAmt { get; set; }


        public string _CustFullName
        {
            get
            {
                return this.CustPreName + " " + this.CustName;
            }
        }

        public string _CustAddr
        {
            get
            {
                return this.CustAddr01 + " " + this.CustAddr02 + " " + this.CustAddr03 + " " + this.CustZipCod;
            }
        }

        public string _CustTelFax
        {
            get
            {
                return this.CustTelNum + (this.CustTelNum.Trim().Length > 0 && this.CustFaxNum.Trim().Length > 0 ? " / " + this.CustFaxNum : "");
            }
        }
    }
}
