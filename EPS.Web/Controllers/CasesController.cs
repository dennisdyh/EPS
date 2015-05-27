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
    public class CasesController : BaseController
    {
        private readonly INews _news;
        private readonly IPhoto _photo;
        private readonly IModule _module;
        private readonly ICacheManager _cache;

        public CasesController(INews news, IPhoto photo, IModule module, ICacheManager cache)
        {
            _news = news;
            _photo = photo;
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

            var sql = Sql.Builder.Append("SELECT  A.* ,");
            sql.Append("        B.Thumbnail, B.Description");
            sql.Append(" FROM    News A");
            sql.Append("         JOIN (");
            sql.Append("               SELECT   A1.*");
            sql.Append("               FROM     Photos A1");
            sql.Append("                        JOIN (");
            sql.Append("                               SELECT   NewsID ,");
            sql.Append("                                       MIN(PhotoId) AS PhotoId");
            sql.Append("                               FROM     Photos");
            sql.Append("                               GROUP BY NewsID ) B1");
            sql.Append("                             ON A1.PhotoId = B1.PhotoID ) B");
            sql.Append("             ON A.NewsId = B.NewsId");
            sql.Append(" WHERE   A.ParentId = @0", ParentId);
            if (ModuleId != 0)
            {
                sql.Append(" AND A.ModuleId = @0", ModuleId);
            }

            var model = new PageSqlModel
            {
                PageIndex = page,
                PageSize = Utility.PageSize,
                Sql = sql
            };

            var list = _news.GetPhotoList(model);
            Pagination.NewPager(this, page, (int)model.Records);

            return View(list);
        }

        public ActionResult Details(int id)
        {
            var info = _news.GetById(id);
            var list = _photo.GetList(id);

            ViewBag.News = info;

            return View(list);
        }
    }
}
