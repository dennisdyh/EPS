using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Data;

namespace EPS.Models
{
    [TableName("UserRoles")]
    [PrimaryKey("UserRoleId")]
    public class UserRoleEntry
    {
        [Column("UserRoleId")]
        public int UserRoleId { get; set; }
        [Column("UserId")]
        public int UserId { get; set; }
        [Column("RoleId")]
        public int RoleId { get; set; }
        [Column("Status")]
        public bool Status { get; set; }
    }
}
