using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Data;

namespace EPS.Models
{
    [TableName("ActionModules")]
    [PrimaryKey("ActionModuleId")]
    public class ActionModuleEntry
    {
        [Column("ActionModuleId")]
        public int ActionModuleId { get; set; }
        [Column("ActionId")]
        public int ActionId { get; set; }
        [Column("ModuleId")]
        public int ModuleId { get; set; }
        [Column("Status")]
        public bool Status { get; set; }
    }
}
