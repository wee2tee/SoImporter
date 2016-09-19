using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class Oeso
    {
        public string sorectyp { get; set; }
        public string sonum { get; set; }
        public DateTime sodat { get; set; }
        public string flgvat { get; set; }
        public string depcod { get; set; }
        public string slmcod { get; set; }
        public string cuscod { get; set; }
        public string shipto { get; set; }
        public string youref { get; set; }
        public string rff { get; set; }
        public string areacod { get; set; }
        public int paytrm { get; set; }
        public DateTime? dlvdat { get; set; }
        public string dlvtim { get; set; }
        public string dlvdat_it { get; set; }
        public string nxtseq { get; set; }
        public double amount { get; set; }
        public string disc { get; set; }
        public double discamt { get; set; }
        public double total { get; set; }
        public double amtrat0 { get; set; }
        public int vatrat { get; set; }
        public double vatamt { get; set; }
        public double netamt { get; set; }
        public double netval { get; set; }
        public DateTime? cmpldat { get; set; }
        public string docstat { get; set; }
        public string dlvby { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string userprn { get; set; }
        public DateTime? prndat { get; set; }
        public int prncnt { get; set; }
        public string prntim { get; set; }
        public string authid { get; set; }
        public DateTime? approve { get; set; }
        public string billto { get; set; }
        public int orgnum { get; set; }

    }

    //public interface Oeso
    //{
    //     string sorectyp { get; set; }
    //     string sonum { get; set; }
    //     DateTime sodat { get; set; }
    //     string flgvat { get; set; }
    //     string depcod { get; set; }
    //     string slmcod { get; set; }
    //     string cuscod { get; set; }
    //     string shipto { get; set; }
    //     string youref { get; set; }
    //     string rff { get; set; }
    //     string areacod { get; set; }
    //     int paytrm { get; set; }
    //     DateTime dlvdat { get; set; }
    //     string dlvtim { get; set; }
    //     string dlvdat_it { get; set; }
    //     string nxtseq { get; set; }
    //     double amount { get; set; }
    //     string disc { get; set; }
    //     double discamt { get; set; }
    //     double total { get; set; }
    //     double amtrat0 { get; set; }
    //     int vatrat { get; set; }
    //     double vatamt { get; set; }
    //     double netamt { get; set; }
    //     double netval { get; set; }
    //     DateTime cmpldat { get; set; }
    //     string docstat { get; set; }
    //     string dlvby { get; set; }
    //     string userid { get; set; }
    //     DateTime chgdat { get; set; }
    //     string userprn { get; set; }
    //     DateTime prndat { get; set; }
    //     int prncnt { get; set; }
    //     string prntim { get; set; }
    //     string authid { get; set; }
    //     DateTime approve { get; set; }
    //     string billto { get; set; }
    //     int orgnum { get; set; }

    //}
}
