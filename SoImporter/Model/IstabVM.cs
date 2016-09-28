using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class IstabVM
    {
        public int Id { get; set; }

        // TabTyp
        public string TabTyp { get; set; }

        // รหัส
        public string TypCod { get; set; }

        // ชื่อย่อ (ไทย)
        public string AbbreviateTh { get; set; }

        // ชื่อย่อ (Eng.)
        public string AbbreviateEn { get; set; }

        // ชื่อเต็ม (ไทย)
        public string TypDesTh { get; set; }

        // ชื่อเต็ม (Eng.)
        public string TypDesEn { get; set; }

        // อัตรา
        public decimal? Rate { get; set; }

        public int CreBy { get; set; }
        public DateTime CreDate { get; set; }

        public int? ChgBy { get; set; }
        public DateTime? ChgDate { get; set; }

        /** CONSTANT VALUE **/
        public const string TABTYP_QUCOD = "20";
        public const string TABTYP_LOCCOD = "21";
        public const string TABTYP_STKGRP = "22";
        public const string TABTYP_DLVBY = "41";
        public const string TABTYP_DEPCOD = "50";
        public const string TABTYP_DLVPROFILE = "D0";
    }
}
