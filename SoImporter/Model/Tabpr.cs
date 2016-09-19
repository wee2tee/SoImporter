using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class Tabpr
    {
        public string tabdesc { get; set; }
        public string tabval { get; set; }

        public override string ToString()
        {
            return tabdesc;
        }
    }
}
