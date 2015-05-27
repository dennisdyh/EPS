using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using System.Web;
using System.Web.Mvc;
using EPS.IDAL;
using EPS.Models;
using Framework.Core.Basic;
using Framework.Core.Caching;

namespace EPS.Web.Controllers
{
    public class BaseController : Controller
    {
        private IBasic _basic;
        public IBasic Basic
        {
            get { return _basic; }
            set
            {
                _basic = value;
                if (_basic != null)
                {
                    var instance = Singleton<IEngine>.Instance;
                    var cache = instance.Resolve<ICacheManager>();
                    var module = instance.Resolve<IModule>();

                    var list = cache.Get(Constants.CACHE_KEY_BASIC, () => _basic.GetList());
                    var modules = cache.Get(Constants.CACHE_KEY_MODULES, module.GetList);

                    var dic = new Hashtable();
                    foreach (var item in list)
                    {
                        dic[item.Key] = item.Value;
                    }

                    ViewBag.Hashtable = dic;
                    ViewBag.ModuleList = modules;
                }
            }
        }
    }
}
