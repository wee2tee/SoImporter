using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class StmasVM
    {
        public int Id { get; set; }

        // รหัสสินค้า
        public string Stkcod { get; set; }

        // ชื่อ (ไทย)
        public string StkDesTh { get; set; }

        // ชื่อ (Eng.)
        public string StkDesEn { get; set; }

        // barcode
        public string Barcod { get; set; }

        // ประเภท (ทั่วไป,บริการ,ชุด,รายได้,ค่าใช้จ่าย)
        public string StkTyp { get; set; }

        // หมวด
        public int StkGrp { get; set; }

        // หน่วยนับ
        public int Qucod { get; set; }

        // ราคาขายที่ 1
        public decimal? Sellpr1 { get; set; }

        // ราคาขายที่ 2
        public decimal? Sellpr2 { get; set; }

        // ราคาขายที่ 3
        public decimal? Sellpr3 { get; set; }

        // ราคาขายที่ 4
        public decimal? Sellpr4 { get; set; }

        // ราคาขายที่ 5
        public decimal? Sellpr5 { get; set; }

        // รูปสินค้า
        public string ProductImg { get; set; }

        // บันทึกโดย
        public int CreBy { get; set; }

        // วันที่บันทึก
        public DateTime CreDate { get; set; }

        // แก้ไขล่าสุดโดย
        public int? ChgBy { get; set; }

        // วันที่แก้ไขล่าสุด
        public DateTime? ChgDate { get; set; }
    }
}
