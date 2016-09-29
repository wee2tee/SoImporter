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

        /** A string to display in comboboxedit **/
        public override string ToString()
        {
            string str = this.TypCod + " : " + this.TypDesTh;
            //str += "[";
            //int cnt = 1;
            //foreach (var item in this.dlv)
            //{
            //    str += (cnt == 1 ? "" : ", ") + item.TypDesTh;
            //    cnt++;
            //}
            //str += "]";
            return str;
        }
    }
}
