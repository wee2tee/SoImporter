using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class StpriVM
    {
        public int Id { get; set; }

        // รหัส
        public string PriceCode { get; set; }

        // รายละเอียด
        public string Description { get; set; }

        // ใช้ราคาขายที่
        public int TabPr { get; set; }

        // ส่วนลดตามเป้า
        public decimal? Disc1 { get; set; }

        public bool? DiscPerc1 { get; set; }

        // ส่วนลดตัวแทนต่างจังหวัด
        public decimal? Disc2 { get; set; }

        public bool? DiscPerc2 { get; set; }

        // เพิ่มโดย
        public int CreBy { get; set; }

        // เพิ่มเมือ
        public System.DateTime CreDate { get; set; }

        // แก้ไขล่าสุดโดย
        public int? ChgBy { get; set; }

        // แก้ไขล่าสุดเมื่อ
        public DateTime? ChgDate { get; set; }

        /** Display in gridview **/
        public string _TabPr
        {
            get
            {
                if (this.TabPr == 0)
                    return "ราคาขายล่าสุด";

                return "ราคาขายที่ " + this.TabPr.ToString();
            }
        }

        public string _Disc1
        {
            get
            {
                string str = this.Disc1 == null || this.Disc1 == 0m ? "-".PadRight(5) : String.Format("{0:#,#0.00}", this.Disc1) + " " + (this.DiscPerc1.Value ? "%" : "บาท");
                return str;
            }
        }

        public string _Disc2
        {
            get
            {
                string str = this.Disc2 == null || this.Disc2 == 0m ? "-".PadRight(5) : String.Format("{0:#,#0.00}", this.Disc2) + " " + (this.DiscPerc2.Value ? "%" : "บาท");
                return str;
            }
        }

        /** A string to display in comboboxedit **/
        public override string ToString()
        {
            return this.PriceCode;
        }
    }
}
