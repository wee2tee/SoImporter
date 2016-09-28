using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class DlvProfileVM
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

        public int CreBy { get; set; }
        public DateTime CreDate { get; set; }

        public int? ChgBy { get; set; }
        public DateTime? ChgDate { get; set; }

        /** dlv member **/
        public List<IstabVM> dlv { get; set; }
    }
}
