using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Data;

namespace EPS.Models
{
    [TableName("Basics")]
    [PrimaryKey("Id")]
    public  class BasicEntry
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Key")]
        public string Key { get; set; }
        [Column("Value")]
        public string Value { get; set; }
    }
}
