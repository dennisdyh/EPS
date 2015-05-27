using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.IDAL;
using EPS.Models;
using Framework.Core.Caching;

namespace EPS.Web.Controllers
{
   
    public class AboutController : BaseController
    {
        private readonly INews _news;
        private readonly IModule _module;
        private readonly ICacheManager _cache;

        public AboutController(INews news, IModule module, ICacheManager cache)
        {
            _news = news;
            _module = module;
            _cache = cache;
        }

        public ActionResult Index(int ModuleId)
        {
            var info = _news.GetAboutUs(ModuleId);
            var list = _cache.Get(Constants.CACHE_KEY_MODULES, () => _module.GetList());
            var module = list.FirstOrDefault(x => x.ModuleId == ModuleId);
            if (module != null)
            {
                ViewBag.Title = module.DisplayName;
            }

            return View(info);
        }
    }
}
