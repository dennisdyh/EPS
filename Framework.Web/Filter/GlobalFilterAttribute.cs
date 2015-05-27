using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Framework.Web.Filter
{
    public class GlobalFilterAttribute : FilterAttribute, IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var context = filterContext.HttpContext;

            var cookie = context.Request.Cookies["MenuID"];
            var menuId = context.Request.QueryString["MenuID"];
            if (!string.IsNullOrEmpty(menuId))
            {
                if (cookie != null && cookie.Value != menuId)
                {
                    context.Response.Cookies["MenuID"].Value = menuId;
                }
                else
                {
                    cookie = new HttpCookie("MenuID") { Value = menuId };
                    context.Response.Cookies.Add(cookie);
                }
            }
            else
            {
                menuId = cookie != null ? cookie.Value : "";
            }

            filterContext.Controller.ViewBag.CurrentMenuID = menuId;
        }
    }
}
