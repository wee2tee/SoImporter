using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public interface Oeso
    {
         string sorectyp { get; set; }
         string sonum { get; set; }
         DateTime sodat { get; set; }
         string flgvat { get; set; }
         string depcod { get; set; }
         string slmcod { get; set; }
         string cuscod { get; set; }
         string shipto { get; set; }
         string youref { get; set; }
         string rff { get; set; }
         string areacod { get; set; }
         int paytrm { get; set; }
         DateTime dlvdat { get; set; }
         string dlvtim { get; set; }
         string dlvdat_it { get; set; }
         string nxtseq { get; set; }
         double amount { get; set; }
         string disc { get; set; }
         double discamt { get; set; }
         double total { get; set; }
         double amtrat0 { get; set; }
         int vatrat { get; set; }
         double vatamt { get; set; }
         double netamt { get; set; }
         double netval { get; set; }
         DateTime cmpldat { get; set; }
         string docstat { get; set; }
         string dlvby { get; set; }
         string userid { get; set; }
         DateTime chgdat { get; set; }
         string userprn { get; set; }
         DateTime prndat { get; set; }
         int prncnt { get; set; }
         string prntim { get; set; }
         string authid { get; set; }
         DateTime approve { get; set; }
         string billto { get; set; }
         int orgnum { get; set; }

    }
}
