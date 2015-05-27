using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPS.Models
{
    public class PageModel
    {
        public PageModel()
        {
            Params = new object[] {};
        }

        public int PageSize { get; set; }
        public long PageIndex { get; set; }
        public string Filter { get; set; }
        public long PageCount { get; set; }
        public long Records { get; set; }

        public object[] Params
        {
            get;
            set;
        }

    }
}
