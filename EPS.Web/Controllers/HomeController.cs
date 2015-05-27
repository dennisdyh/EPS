using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EPS.IDAL;
using EPS.Models;
using Framework;
using Framework.Core;
using Framework.Core.Caching;
using Framework.Data;
using Framework.Web.Utils;

namespace EPS.Web.Controllers
{
    public class HomeController : BaseController
    {
        private readonly IModule _module;
        private readonly ICacheManager _cache;
        private readonly INews _news;
        private readonly IPhoto _photo;

        public HomeController(INews news, IModule module, IPhoto photo, ICacheManager cache)
        {
            _news = news;
            _module = module;
            _cache = cache;
            _photo = photo;
        }

        [ChildActionOnly]
        public ActionResult Menu()
        {
            var id = DataCast.Get<int>(ViewBag.CurrentMenuID);
            var list = _cache.Get(Constants.CACHE_KEY_MODULES, () => _module.GetList());
            var filters = list.Where(x => x.WebsiteFrontMenu);
            var model = TreeUtils.GetTree(filters, id);

            return View(model);
        }

        [ChildActionOnly]
        public ActionResult SideMenu(int ModuleId = 0, int ParentId = 0)
        {
            ViewBag.ModuleId = ModuleId;
            var list = _cache.Get(Constants.CACHE_KEY_MODULES, () => _module.GetList());
            var filters = list.Where(x => x.WebsiteFrontMenu).ToList();

            var parent = filters.FirstOrDefault(x => x.ModuleId == ParentId);
            string parentName = string.Empty;
            if (parent != null)
            {
                parentName = parent.DisplayName;
            }
            ViewBag.ParentName = parentName;

            list = filters.Where(x => x.ParentId == ParentId).ToList();

            return View(list);
        }

        [ChildActionOnly]
        public ActionResult Breadcrumb(int ParentId = 0)
        {
            ViewBag.ParentId = ParentId;
            var list = _cache.Get(Constants.CACHE_KEY_MODULES, () => _module.GetList());
            var filters = list.Where(x => x.WebsiteFrontMenu).ToList();

            var parent = filters.FirstOrDefault(x => x.ModuleId == ParentId);
            ViewBag.Parent = parent;

            var module = filters.Where(x => x.ParentId == ParentId).OrderBy(x => x.ModuleId).FirstOrDefault();
            ViewBag.Module = module;

            return View();
        }

        //
        // GET: /Web/Home/
        public ActionResult Index()
        {
            //about us => moduleid = 8
            //news => moduleid = 16, parentid = 9
            //cases => parentid = 10
            //products => parentid = 11

            var info = _news.GetAboutUs(8);
            ViewBag.Introduce = info == null ? "" : info.Content;

            var sql =
                Sql.Builder.Append(
                    "SELECT news.*, modules.displayname FROM news JOIN modules ON news.moduleid = modules.moduleid");
            sql.Append("WHERE news.parentid = @0", 9);
            sql.Append(" AND news.moduleid = @0", 16);

            var model = new PageSqlModel
            {
                PageIndex = 1,
                PageSize = 8,
                Sql = sql
            };

            var companyNews = _news.GetList(model);

            ViewBag.CompanyNews = companyNews;

            var sqlCases = Sql.Builder.Append("SELECT  a.* ,");
            sqlCases.Append("b.moduleid ,");
            sqlCases.Append("b.parentid");
            sqlCases.Append("FROM    photos a");
            sqlCases.Append("JOIN news b");
            sqlCases.Append("ON a.newsid = b.newsid");
            sqlCases.Append("WHERE   a.publishhome = true and b.parentid = 10");

            ViewBag.Cases = _photo.GetList(sqlCases);

            var sqlProds = Sql.Builder.Append("SELECT  a.* ,");
            sqlProds.Append("b.moduleid ,");
            sqlProds.Append("b.parentid");
            sqlProds.Append("FROM    photos a");
            sqlProds.Append("JOIN news b");
            sqlProds.Append("ON a.newsid = b.newsid");
            sqlProds.Append("WHERE   a.publishhome = true and b.parentid = 11");

            ViewBag.Products = _photo.GetList(sqlProds);

            return View();
        }

    }
}
