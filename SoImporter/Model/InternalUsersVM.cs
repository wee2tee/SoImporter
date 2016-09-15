using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SoImporter.Model
{
    public class InternalUsersVM
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Status { get; set; }
        public DateTime CreDate { get; set; }

        public string NewPassword { get; set; }
    }
}
