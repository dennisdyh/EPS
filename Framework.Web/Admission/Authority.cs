using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using EPS.DAL;
using EPS.IDAL;
using EPS.Models;
using Framework.Core;
using Framework.Core.Basic;
using Framework.Core.Caching;

namespace Framework.Web.Admission
{
    public class Authority
    {
        public static bool CheckRight(string moduleCode, string actionCode)
        {
            string roleIDs;
            if (HttpContext.Current != null)
            {
                if (HttpContext.Current.Session["____RoleIDs"] != null)
                {
                    roleIDs = HttpContext.Current.Session["____RoleIDs"].ToString();
                }
                else
                {
                    roleIDs = Utils.Utility.CurrentLoginModel.RoleIDs;
                    HttpContext.Current.Session["____RoleIDs"] = roleIDs;
                }
            }
            else
            {
                roleIDs = Utils.Utility.CurrentLoginModel.RoleIDs;
            }

            var value = System.Configuration.ConfigurationManager.AppSettings["NoNeedCheckRightRole"];
           
            if (roleIDs.Split(',').Contains(value))
            {
                return true;
            }

            var instance = Singleton<IEngine>.Instance;
            var user = instance.Resolve<IUser>();
            var cache = instance.Resolve<ICacheManager>();

            var list = cache.Get(Constants.CACHE_KEY_USER_RIGHT_PREFIX + roleIDs, () => user.GetList(roleIDs));
            return list.Any(x => x.ModuleCode == moduleCode && x.ActionCode == actionCode && x.Status);
        }
    }
}
