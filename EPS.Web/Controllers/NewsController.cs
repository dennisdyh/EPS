using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.IDAL;
using EPS.Models;
using Framework;
using Framework.Core.Caching;
using Framework.Data;
using Framework.Web;
using Framework.Web.Utils;

namespace EPS.Web.Controllers
{
    public class NewsController : BaseController
    {
        private readonly INews _news;
        private readonly IModule _module;
        private readonly ICacheManager _cache;

        public NewsController(INews news, IModule module, ICacheManager cache)
        {
            _news = news;
            _module = module;
            _cache = cache;
        }

        public ActionResult Index(int page = 1, int ParentId = 0, int ModuleId = 0)
        {
            var modules = _cache.Get(Constants.CACHE_KEY_MODULES, () => _module.GetList());
            var module = modules.FirstOrDefault(x => x.ModuleId == ModuleId);
            if (module != null)
            {
                ViewBag.Title = module.DisplayName;
            }
            ViewBag.ParentId = ParentId;
            ViewBag.ModuleId = ModuleId;

            var sql =
                Sql.Builder.Append(
                    "SELECT News.*, Modules.DisplayName FROM News JOIN Modules ON News.ModuleId = Modules.ModuleId");
            sql.Append("WHERE News.ParentId = @0", ParentId);

            if (ModuleId != 0)
            {
                sql.Append(" AND News.ModuleId = @0", ModuleId);
            }
            
            var model = new PageSqlModel
            {
                PageIndex = page,
                PageSize = Utility.PageSize,
                Sql = sql
            };

            var list = _news.GetList(model);
            Pagination.NewPager(this, page, (int)model.Records);

            return View(list);
        }

        public ActionResult Details(int id)
        {
            var info = _news.GetById(id);
            return View(info);
        }
    }
}
