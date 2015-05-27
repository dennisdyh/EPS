using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework;
using Framework.Data;

namespace EPS.Models
{
    public class PageSqlModel
    {
        public int PageSize { get; set; }
        public long PageIndex { get; set; }
        public long PageCount { get; set; }
        public long Records { get; set; }
        public Sql Sql { get; set; }
    }
}
