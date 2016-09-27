using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoImporter.MiscClass;
using SoImporter.Model;

namespace SoImporter.Model
{
    public class ArtrnVM
    {
        public string IvNum { get; set; }
        public DateTime? IvDat { get; set; }
        public String SoNum { get; set; }
        public DateTime? SoDat { get; set; }
        public string DealerName { get; set; }
        public int? DealerType { get; set; }
        public string CustPreName { get; set; }
        public string CustName { get; set; }
        public string CustAddr01 { get; set; }
        public string CustAddr02 { get; set; }
        public string CustAddr03 { get; set; }
        public string CustZipCod { get; set; }
        public string CustTelNum { get; set; }
        public string CustFaxNum { get; set; }
        public string CustTaxId { get; set; }
        public string Remark { get; set; }
        public double Amount { get; set; }
        public string Disc { get; set; }
        public double DiscAmt { get; set; }
        public double TaxAmt { get; set; }
        public double VatAmt { get; set; }
        public double NetAmt { get; set; }

        public List<PopritVM> po { get; set; }

        public string _DealerType
        {
            get
            {
                return this.DealerType.GetDealerTypeString();
            }
        }

        /** fake string **/
        public string _EmsTrackingNo
        {
            get
            {
                return "EMS Tracking...";
            }
        }
    }
}
