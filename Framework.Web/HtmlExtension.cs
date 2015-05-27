using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using EPS.Models;
using Framework.Core.Localized;

namespace Framework.Web
{
    public static class HtmlExtension
    {
        public static string Lang(this HtmlHelper htmlHelper, string key)
        {
            var value = Localization.GetLang(key);
            if (string.IsNullOrEmpty(value))
            {
                return key;
            }
            return value;
        }

        public static string Lang(this HtmlHelper htmlHelper, string key, string defaultValue)
        {
            var value = Localization.GetLang(key);
            if (string.IsNullOrEmpty(value))
            {
                return defaultValue;
            }
            return value;
        }

        public static MvcHtmlString Pager(this HtmlHelper html, PageEntry model, string url)
        {
            var sbHtml = new StringBuilder();

            if(model == null)
                return MvcHtmlString.Create(sbHtml.ToString());

            if (model.PageCount <= 1) return MvcHtmlString.Create(sbHtml.ToString());

            var containerId = string.Empty;
            if (!string.IsNullOrEmpty(model.ContainerId))
            {
                containerId = String.Format("id=\"{0}\"", model.ContainerId);
            }

            sbHtml.AppendFormat("<div class=\"pagination\" {0}>", containerId);
            sbHtml.Append("<ul>");
            if (model.Current == 1)
            {
                sbHtml.Append("<li class=\"disabled\"><span><i class=\"fa fa-angle-double-left\"></i></span></li>");
            }
            else
            {
                sbHtml.AppendFormat("<li><a href=\"{0}\" title=\"First\"><i class=\"fa fa-angle-double-left\"></i></a></li>", (url + model.First));
            }

            if (model.Prev <= 0)
            {
                sbHtml.Append("<li class=\"disabled\"><span><i class=\"fa fa-angle-left\"></i></span></li>");
            }
            else
            {
                sbHtml.AppendFormat("<li> <a href=\"{0}\" title=\"Previous\"><i class=\"fa fa-angle-left\"></i></a></li>", (url + model.Prev));
            }
            var showButtons = model.ShowButtons;

            var begin = showButtons / 2;

            var start = model.Current - begin;
            if (start > model.PageCount - showButtons)
            {
                start = model.PageCount - showButtons;
            }
            if (start <= 0)
            {
                start = 1;
            }

            var end = start + showButtons;
            if (end > model.PageCount)
            {
                end = model.PageCount;
            }

            for (var i = start; i <= end; i++)
            {
                if (i == model.Current)
                {
                    sbHtml.AppendFormat("<li class=\"active\"><span>{0}</span></li>", i);
                }
                else
                {
                    sbHtml.AppendFormat("<li><a href=\"{0}\">{1}</a></li>", (url + i), i);
                }
            }

            if (model.Next > model.Last)
            {
                sbHtml.Append("<li class=\"disabled\"><span><i class=\"fa fa-angle-right\"></i></span></li>");
            }
            else
            {
                sbHtml.AppendFormat("<li><a href=\"{0}\" title=\"Next\"><i class=\"fa fa-angle-right\"></i></a></li>", (url + model.Next));
            }
            if (model.PageCount  == model.Current)
            {
                sbHtml.Append("<li class=\"disabled\"><span><i class=\"fa fa-angle-double-right\"></i></span></li>");
            }
            else
            {
                sbHtml.AppendFormat("<li><a href=\"{0}\" title=\"Last\"><i class=\"fa fa-angle-double-right\"></i></a></li>", (url + model.Last));
            }

            sbHtml.Append("</ul>");
            sbHtml.Append("</div>");

            return MvcHtmlString.Create(sbHtml.ToString());
        }
    }
}
