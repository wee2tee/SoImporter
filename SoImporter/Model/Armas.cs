using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class Armas
    {
        public string cuscod { get; set; }
        public string custyp { get; set; }
        public string prenam { get; set; }
        public string cusnam { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
        public string telnum { get; set; }
        public string contact { get; set; }
        public string cusnam2 { get; set; }
        public string taxid { get; set; }
        public int orgnum { get; set; }
        public string taxtyp { get; set; }
        public int taxrat { get; set; }
        public string taxgrp { get; set; }
        public string taxcond { get; set; }
        public string shipto { get; set; }
        public string slmcod { get; set; }
        public string areacod { get; set; }
        public int paytrm { get; set; }
        public string paycond { get; set; }
        public string payer { get; set; }
        public string tabpr { get; set; }
        public string disc { get; set; }
        public double balance { get; set; }
        public double chqrcv { get; set; }
        public double crline { get; set; }
        public DateTime? lasivc { get; set; }
        public string accnum { get; set; }
        public string remark { get; set; }
        public string dlvby { get; set; }
        public string tracksal { get; set; }
        public string creby { get; set; }
        public DateTime? credat { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }

        public Armas()
        {

        }

        public Armas(bool with_init_value) : this()
        {
            this.cuscod = string.Empty;
            this.custyp = string.Empty;
            this.prenam = string.Empty;
            this.cusnam = string.Empty;
            this.addr01 = string.Empty;
            this.addr02 = string.Empty;
            this.addr03 = string.Empty;
            this.zipcod = string.Empty;
            this.telnum = string.Empty;
            this.contact = string.Empty;
            this.cusnam2 = string.Empty;
            this.taxid = string.Empty;
            this.orgnum = 0;
            this.taxtyp = string.Empty;
            this.taxrat = 0;
            this.taxgrp = string.Empty;
            this.taxcond = string.Empty;
            this.shipto = string.Empty;
            this.slmcod = string.Empty;
            this.areacod = string.Empty;
            this.paytrm = 0;
            this.paycond = string.Empty;
            this.payer = string.Empty;
            this.tabpr = string.Empty;
            this.disc = string.Empty;
            this.balance = 0d;
            this.chqrcv = 0d;
            this.crline = 0d;
            this.lasivc = null;
            this.accnum = string.Empty;
            this.remark = string.Empty;
            this.dlvby = string.Empty;
            this.tracksal = string.Empty;
            this.creby = string.Empty;
            this.credat = null;
            this.userid = string.Empty;
            this.chgdat = null;
            this.status = string.Empty;
            this.inactdat = null;
        }
    }
}
