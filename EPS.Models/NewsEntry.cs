using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Framework;
using Framework.Core.Localized;
using Framework.Data;

namespace EPS.Models
{
    [TableName("News")]
    [PrimaryKey("NewsId")]
    public class NewsEntry
    {
        [Column("NewsId")]
        public int NewsId { get; set; }
        [Column("ParentId")]
        public int ParentId { get; set; }
        [LocalizedDisplay("Type")]
        [LocalizedRequired]
        [Column("ModuleId")]
        public int ModuleId { get; set; }
        [LocalizedDisplay("Title")]
        [LocalizedRequired]
        [Column("Title")]
        public string Title { get; set; }
        [LocalizedDisplay("Author")]
        [Column("Author")]
        public string Author { get; set; }
        [LocalizedDisplay("Source")]
        [Column("Source")]
        public string Source { get; set; }
        [LocalizedDisplay("Brief")]
        [Column("Brief")]
        public string Brief { get; set; }

        [LocalizedDisplay("Content")]
        [Column("Content")]
        public string Content { get; set; }
        [LocalizedDisplay("Count")]
        [LocalizedRequired]
        [Range(0, int.MaxValue, ErrorMessage = "请输入大于等于0的数")]
        [Column("Count")]
        public int Count { get; set; }
        [Column("CreatedBy")]
        public string CreatedBy { get; set; }
        [Column("CreatedTime")]
        public DateTime? CreatedTime { get; set; }
        [Column("ChangedBy")]
        public string ChangedBy { get; set; }
        [Column("ChangedTime")]
        public DateTime? ChangedTime { get; set; }

        [Ignore]
        public string Category { get; set; }
    }
}
