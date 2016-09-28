using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SoImporter.MiscClass;

namespace SoImporter.Model
{
    public class DealerVM
    {
        public string Id { get; set; }

        // รหัสตัวแทน
        public string DealerCode { get; set; }
        // ประเภท
        public int? DealerType { get; set; }
        // รหัสผู้ใช้
        public string UserName { get; set; }
        // S/N
        public string SerNum { get; set; }
        // คำนำหน้าชื่อ
        public string PreName { get; set; }
        // ชื่อ
        public string FullName { get; set; }
        // เลขประจำตัวผู้เสียภาษี
        public string TaxId { get; set; }
        // ที่อยู่ 1
        public string Addr01 { get; set; }
        // ที่อยู่ 2
        public string Addr02 { get; set; }
        // ที่อยู่ 3
        public string Addr03 { get; set; }
        // รหัสไปรษณีย์
        public string ZipCod { get; set; }
        // โทรศัพท์
        public string TelNum { get; set; }
        // โทรสาร
        public string FaxNum { get; set; }
        // ตารางราคา
        public string PriceCode { get; set; }
        // กลุ่มวิธีการจัดส่ง
        public int? DlvProfile { get; set; }
        public string _DlvProfile { get; set; }
        // ส่วนลด 1
        public decimal? Disc { get; set; }
        public bool? DiscPerc { get; set; }
        // ส่วนลด 2
        public decimal? Disc2 { get; set; }
        public bool? DiscPerc2 { get; set; }
        // สถานะ
        public string Status { get; set; }
        // แก้ไขล่าสุดโดย
        public string ChgBy { get; set; }
        // แก้ไขล่าสุดเมื่อ
        public DateTime? ChgDate { get; set; }

        public string _DealerType
        {
            get
            {
                return this.DealerType.GetDealerTypeString();
            }
        }

        public string _FullName
        {
            get
            {
                return this.PreName.Trim() + " " + this.FullName.Trim();
            }
        }

        public string _Addr
        {
            get
            {
                return (this.Addr01.Trim() + " " + this.Addr02.Trim() + " " + this.Addr03.Trim()).Trim() + this.ZipCod.Trim();
            }
        }

        public string _TelAndFax
        {
            get
            {
                return this.TelNum.Trim() + " / " + this.FaxNum.Trim();
            }
        }
    }
}
