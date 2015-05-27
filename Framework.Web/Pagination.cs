using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Framework.Core;
using EPS.Models;
using Framework.Web.Utils;


namespace Framework.Web
{
    public class Pagination
    {
        /// <summary>
        /// 初始化分页实体类
        /// </summary>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="records">总记录数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="showButtons">需要显示的分页按钮数</param>
        /// <returns></returns>
        public static PageEntry NewPager(int pageIndex, int records, int pageSize = 0, int showButtons = 7)
        {
            var pm = GetPager(pageIndex, records, pageSize, showButtons);
            return pm;
        }
        /// <summary>
        /// 初始化分页实体类
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="pageIndex">当前页索引</param>
        /// <param name="records">总记录数</param>
        /// <param name="pageSize">每页记录数</param>
        /// <param name="showButtons">需要显示的分页按钮数</param>
        /// <returns></returns>
        public static PageEntry NewPager(Controller controller, int pageIndex, int records, int pageSize = 0, int showButtons = 7)
        {
            var pm = GetPager(pageIndex, records, pageSize, showButtons);
            controller.TempData["_PagerEntity"] = pm;
            controller.TempData["_PageIndex"] = pageIndex;
            controller.ViewBag.PageModel = pm;
            return pm;
        }

        private static PageEntry GetPager(int pageIndex, int records, int pageSize = 0, int showButtons = 7)
        {
            if (pageSize == 0)
            {
                pageSize = Utility.PageSize;
            }
            var pm = new PageEntry();

            if (records % pageSize == 0)
            {
                pm.PageCount = records / pageSize;
                pm.RecordsOfCurrentPage = records - ((pm.PageCount-1) * pageSize);
            }
            else
            {
                pm.PageCount = (records / pageSize) + 1;
                pm.RecordsOfCurrentPage = pageSize - ((pm.PageCount  * pageSize) - records);
            }

            pm.First = 1;
            pm.Last = pm.PageCount;
            pm.Next = pageIndex + 1;
            pm.Prev = pageIndex - 1;
            pm.Current = pageIndex;
            pm.ShowButtons = showButtons;

            return pm;
        }

        /// <summary>
        /// 当执行删除时检查页面的记录数，如果删除的条数等于当前页面的条数，需要将页面索引减1，否则当前页会是空白。
        /// </summary>
        /// <param name="controller">控制器</param>
        /// <param name="records">删除执行后受影响的记录数</param>
        /// <returns></returns>
        public static int CheckPageIndexWhenDeleted(Controller controller, int records)
        {
            var pageIndex = DataCast.Get<int>(controller.TempData["_PageIndex"]);
            var pm = controller.TempData["_PagerEntity"] as PageEntry;
            if (pm != null)
            {
                var recordsOfCurrentPage = pm.RecordsOfCurrentPage;
                if (recordsOfCurrentPage == records)
                {
                    pageIndex--;
                    if (pageIndex <= 0)
                    {
                        pageIndex = 1;
                    }
                }
            }

            if (pageIndex <= 0)
                pageIndex = 1;

            return pageIndex;
        }
    }
}
