using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPS.Models
{
    public class UserRightEntry
    {
        public int RoleId { get; set; }
        public int ModuleId { get; set; }
        public int ActionId { get; set; }
        public string ActionCode { get; set; }
        public bool Status { get; set; }
        public string ModuleCode { get; set; }
        public string DisplayName { get; set; }
    }
}
