using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Security;
using EPS.IDAL;

namespace Framework.Web.Admission
{
    public class PermissionAttribute : FilterAttribute, IAuthorizationFilter
    {
        /// <summary>
        /// Module Code
        /// </summary>
        public string ModuleCode { get; set; }

        /// <summary>
        /// <para>如果要对多个进行检查请用|分割;</para>
        /// <para>例如: Add|Update, 两者当中有一个真，就是有权限.</para>
        /// </summary>
        public string ActionCode { get; set; }

        public void OnAuthorization(AuthorizationContext context)
        {
            if (context.HttpContext.User == null ||
                !context.HttpContext.User.Identity.IsAuthenticated ||
                !(context.HttpContext.User.Identity is FormsIdentity))
            {
                context.HttpContext.Response.Redirect("/Admin/Users/Login?type=timeout", true);
            }
        
            var hasRight = false;
            if (ActionCode.Contains("|"))
            {
                var codes = ActionCode.Split('|');
                foreach (var item in codes)
                {
                    var flag = Authority.CheckRight(ModuleCode, item);
                    if (flag)
                    {
                        hasRight = true;
                    }
                }
            }
            else
            {
                hasRight = Authority.CheckRight(ModuleCode, ActionCode);
            }

            if (!hasRight)
            {
                context.HttpContext.Response.Redirect("/Admin/Errors/Http403/", true);
            }
        }
    }
}
