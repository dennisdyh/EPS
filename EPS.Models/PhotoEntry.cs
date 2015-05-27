using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Core.Localized;
using Framework.Data;

namespace EPS.Models
{
    [TableName("Photos")]
    [PrimaryKey("PhotoId")]
    public class PhotoEntry
    {
        [Column("PhotoId")]
        public int PhotoId { get; set; }
        [Column("NewsId")]
        public int NewsId { get; set; }
        [Column("Thumbnail")]
        public string Thumbnail { get; set; }
        [Column("Original")]
        public string Original { get; set; }

        [LocalizedDisplay("Publish to home page")]
        [Column("PublishHome")]
        public bool PublishHome { get; set; }

        [LocalizedDisplay("Description")]
        [Column("Description")]
        public string Description { get; set; }
    }
}
