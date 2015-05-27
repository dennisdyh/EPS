using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Framework;
using Framework.Data;
using Framework.Core.Localized;

namespace EPS.Models
{
    [TableName("actions")]
    [PrimaryKey("actionid")]
    public class ActionEntry
    {
        [Column("actionid")]
        public int ActionId { get; set; }

        [LocalizedDisplay("Action Code")]
        [LocalizedRequired]
        [LocalizedRemote("CheckCode", "Actions", ErrorMessage = "{0} already used, please select another.")]
        [Column("actioncode")]
        public string ActionCode { get; set; }

        [LocalizedDisplay("Display Name")]
        [LocalizedRequired]
        [Column("displayname")]
        public string DisplayName { get; set; }

        [LocalizedDisplay("Sequence")]
        [LocalizedRequired]
        [Column("SeqNo")]
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
