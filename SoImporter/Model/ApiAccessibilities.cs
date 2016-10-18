using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class ApiAccessibilities
    {
        public string API_KEY { get; set; }
        public int USER_ID { get; set; }
        public InternalUsers internalUsers { get; set; }
        public InternalUsersVM changePasswordModel { get; set; }
        public PopritVM poprit { get; set; }
        public DealerVM dealer { get; set; }
        public DlvProfileVM dlvprofile { get; set; }
        public IstabVM istab { get; set; }
        public StpriVM stpri { get; set; }
        public StmasVM stmas { get; set; }
        public StmasImportVM stmas_import { get; set; }
    }
}
