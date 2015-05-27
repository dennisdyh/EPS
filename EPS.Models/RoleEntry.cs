using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Framework;
using Framework.Core.Localized;
using Framework.Data;

namespace EPS.Models
{
    [TableName("Roles")]
    [PrimaryKey("RoleId")]
    public class RoleEntry
    {
        [Column("RoleId")]
        public int RoleId { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("Role Code")]
        [LocalizedRemote("CheckCode", "Roles", ErrorMessage = "{0} already used, please select another.")]
        [Column("RoleCode")]
        public string RoleCode { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("Display Name")]
        [Column("DisplayName")]
        public string DisplayName { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("Grade")]
        [Column("SeqNo")]
        //mono中不能启用
        //[RegularExpression(@"^[0-9]+$", ErrorMessage = "Please enter a valid number.")]
        public int SeqNo { get; set; }

        [LocalizedDisplay("Description")]
        [Column("Description")]
        public string Description { get; set; }
        [Column("CreatedBy")]
        public string CreatedBy { get; set; }
        [Column("CreatedTime")]
        public DateTime? CreatedTime { get; set; }
        [Column("ChangedBy")]
        public string ChangedBy { get; set; }
        [Column("ChangedTime")]
        public DateTime? ChangedTime { get; set; }
    }
}
