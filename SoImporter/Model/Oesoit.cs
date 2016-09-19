using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class Oesoit
    {
        public string sorectyp { get; set; }
        public string sonum { get; set; }
        public string seqnum { get; set; }
        public DateTime sodat { get; set; }
        public DateTime dlvdat { get; set; }
        public string cuscod { get; set; }
        public string stkcod { get; set; }
        public string loccod { get; set; }
        public string stkdes { get; set; }
        public string depcod { get; set; }
        public string vatcod { get; set; }
        public string free { get; set; }
        public double ordqty { get; set; }
        public double candelqty { get; set; }
        public string canceltyp { get; set; }
        public DateTime canceldat { get; set; }
        public double remqty { get; set; }
        public double tfactor { get; set; }
        public double unitpr { get; set; }
        public string tqucod { get; set; }
        public string disc { get; set; }
        public double discamt { get; set; }
        public double trnval { get; set; }
        public string packing { get; set; }

    }
}
