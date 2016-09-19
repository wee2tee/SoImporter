using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class Istab
    {
        public string tabtyp { get; set; }
        public string typcod { get; set; }
        public string shortnam { get; set; }
        public string shortnam2 { get; set; }
        public string typdes { get; set; }
        public string typdes2 { get; set; }
        public string fld01 { get; set; }
        public double fld02 { get; set; }
        public string depcod { get; set; }
        public string status { get; set; }


        public override string ToString()
        {
            return this.typdes;
        }
    }
}
