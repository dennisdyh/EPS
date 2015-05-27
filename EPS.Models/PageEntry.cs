using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPS.Models
{
    [Serializable]
    public class PageEntry
    {
        /// <summary>
        /// 总页数
        /// </summary>
        public int PageCount { get; set; }
        /// <summary>
        /// 第一页
        /// </summary>
        public int First { get; set; }
        /// <summary>
        /// 最后一页
        /// </summary>
        public int Last { get; set; }
        /// <summary>
        /// 前一页
        /// </summary>
        public int Prev { get; set; }
        /// <summary>
        /// 后一页
        /// </summary>
        public int Next { get; set; }
        /// <summary>
        /// 当前页
        /// </summary>
        public int Current { get; set; }
        /// <summary>
        /// 需要显示的分页按钮数
        /// </summary>
        public int ShowButtons { get; set; }
        /// <summary>
        /// 容器ID，包裹分页按钮的容器
        /// </summary>
        public string ContainerId { get; set; }
        /// <summary>
        /// 当前页的记录数
        /// </summary>
        public int RecordsOfCurrentPage { get; set; }
    }
}
