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
    [TableName("Modules")]
    [PrimaryKey("ModuleId")]
    [Serializable]
    public class ModuleEntry
    {
        public ModuleEntry()
        {
            Children = new List<ModuleEntry>();
        }
        [Column("ModuleId")]
        public int ModuleId { get; set; }
        [Column("ParentId")]
        public int ParentId { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("Module Code")]
        [LocalizedRemote("CheckCode", "Modules", ErrorMessage = "{0} already used, please select another.")]
        [Column("ModuleCode")]
        public string ModuleCode { get; set; }

        [LocalizedRequired]
        [LocalizedDisplay("Display Name")]
        [Column("DisplayName")]
        public string DisplayName { get; set; }

        [LocalizedDisplay("Display As Menu")]
        [Column("DisplayAsMenu")]
        public bool DisplayAsMenu { get; set; }

        [LocalizedDisplay("Display As Website Front Menu")]
        [Column("WebsiteFrontMenu")]
        public bool WebsiteFrontMenu { get; set; }

        [LocalizedDisplay("Make it as a article type?")]
        [Column("Article")]
        public bool Article { get; set; }

        [LocalizedDisplay("Class Name")]
        [Column("ClassName")]
        public string ClassName { get; set; }

        [LocalizedDisplay("URL of Admin")]
        [Column("Url")]
        public string Url { get; set; }

        [LocalizedDisplay("URL of Website")]
        [Column("FrontUrl")]
        public string FrontUrl { get; set; }

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

        [LocalizedDisplay("Parent Name")]
        [Ignore]
        public string NonParent { get; set; }

        [Ignore]
        public List<ModuleEntry> Children { get; private set; }

        [Ignore]
        public bool IsActived { get; set; }
    }
}
