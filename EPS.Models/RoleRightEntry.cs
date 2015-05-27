using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Data;

namespace EPS.Models
{
    [TableName("RoleRights")]
    [PrimaryKey("RightId")]
    public class RoleRightEntry
    {
        [Column("RightId")]
        public int RightId { get; set; }
        [Column("RoleId")]
        public int RoleId { get; set; }
        [Column("ActionModuleId")]
        public int ActionModuleId { get; set; }
        [Column("Status")]
        public bool Status { get; set; }
    }
}
