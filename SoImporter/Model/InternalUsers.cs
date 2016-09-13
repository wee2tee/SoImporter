using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class InternalUsers
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public DateTime CreDate { get; set; }


        public enum STATUS
        {
            N,
            X
        }

        public enum DEPARTMENT
        {
            Marketting,
            Accounting,
            Administrative
        }

        //public const string STATUS_NORMAL = "N";
        //public const string STATUS_DENIED = "X";

        //public const string DEPARTMENT_MKT = "Marketting";
        //public const string DEPARTMENT_ACT = "Accounting";
        //public const string DEPARTMENT_ADMIN = "Administrative";
    }
}
