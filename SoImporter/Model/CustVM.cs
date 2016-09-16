using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class CustVM
    {
        public string PreName { get; set; }
        public string Name { get; set; }
        public string Addr01 { get; set; }
        public string Addr02 { get; set; }
        public string Addr03 { get; set; }
        public string ZipCod { get; set; }
        public string TelNum { get; set; }
        public string FaxNum { get; set; }
        public string TaxId { get; set; }


        /** Compound getting var **/
        public string _CustName
        {
            get
            {
                return this.PreName + " " + this.Name;
            }
        }
        public string _CustAddr
        {
            get
            {
                return this.Addr01 + " " + this.Addr02 + " " + this.Addr03 + " " + this.ZipCod;
            }
        }
        public string _CustTelFax
        {
            get
            {
                return this.TelNum + (this.TelNum.Trim().Length > 0 && this.FaxNum.Trim().Length > 0 ? " / " + this.FaxNum : this.FaxNum);
            }
        }
    }
}
