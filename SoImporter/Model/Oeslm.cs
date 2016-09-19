using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class Oeslm
    {
        public string slmcod { get; set; }
        public string slmnam { get; set; }
        public string slmtyp { get; set; }
        public int comrate { get; set; }
        public string areacod { get; set; }
        public string taxid { get; set; }
        public string positn { get; set; }
        public string socialid { get; set; }
        public string addr01 { get; set; }
        public string addr02 { get; set; }
        public string addr03 { get; set; }
        public string zipcod { get; set; }
        public string telnum { get; set; }
        public double tar1 { get; set; }
        public double tar2 { get; set; }
        public double tar3 { get; set; }
        public double tar4 { get; set; }
        public double tar5 { get; set; }
        public double tar6 { get; set; }
        public double tar7 { get; set; }
        public double tar8 { get; set; }
        public double tar9 { get; set; }
        public double tar10 { get; set; }
        public double tar11 { get; set; }
        public double tar12 { get; set; }
        public double tar1ny { get; set; }
        public double tar2ny { get; set; }
        public double tar3ny { get; set; }
        public double tar4ny { get; set; }
        public double tar5ny { get; set; }
        public double tar6ny { get; set; }
        public double tar7ny { get; set; }
        public double tar8ny { get; set; }
        public double tar9ny { get; set; }
        public double tar10ny { get; set; }
        public double tar11ny { get; set; }
        public double tar12ny { get; set; }
        public string userid { get; set; }
        public DateTime? chgdat { get; set; }
        public DateTime create { get; set; }
        public string status { get; set; }
        public DateTime? inactdat { get; set; }


        public override string ToString()
        {
            return "[" + this.slmcod.Trim() + "] " + this.slmnam;
        }
    }
}
