using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class ApiAccessibilities
    {
        public string API_KEY { get; set; }
        public InternalUsers internalUsers { get; set; }
        public InternalUsersVM changePasswordModel { get; set; }
        public PopritVM poprit { get; set; }
    }
}
