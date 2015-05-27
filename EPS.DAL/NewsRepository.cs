using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Core;
using EPS.IDAL;
using EPS.Models;
using Framework;
using Framework.Data;

namespace EPS.DAL
{
    public class NewsRepository : INews
    {
        private readonly DataProvider _provider;
        public NewsRepository(DataProvider provider)
        {
            _provider = provider;
        }

        public IEnumerable<NewsEntry> GetList(PageSqlModel model)
        {
            var page = _provider.Database.Page<dynamic>(model.PageIndex, model.PageSize, model.Sql);
            model.Records = (int)page.TotalItems;
            model.PageCount = page.TotalPages;

            var list = page.Items.Select(a => new NewsEntry
            {
                Author = a.author,
                Brief = a.brief,
                Category = a.displayname,
                ChangedBy = a.changedby,
                ChangedTime = a.changedtime,
                Content = a.content,
                Count = a.count,
                CreatedBy = a.createdby,
                CreatedTime = a.createdtime,
                ModuleId = a.moduleid,
                NewsId = a.newsid,
                ParentId = a.parentid,
                Source = a.source,
                Title = a.title
            });

            return list;
        }

        public IEnumerable<NewsEntry> GetPhotoList(PageSqlModel model)
        {
            var page = _provider.Database.Page<dynamic>(model.PageIndex, model.PageSize, model.Sql);
            model.Records = (int)page.TotalItems;
            model.PageCount = page.TotalPages;

            var list = page.Items.Select(a => new NewsEntry
            {
                Brief = a.thumbnail,
                Content = a.description,
                ModuleId = a.moduleid,
                NewsId = a.newsid,
                ParentId = a.parentid,
                Title = a.title
            });

            return list;
        }

        public NewsEntry GetById(int newsId)
        {
            return _provider.Database.FirstOrDefault<NewsEntry>("where newsid = @0", newsId);
        }

        public int Add(NewsEntry entry)
        {
            var nums = _provider.Database.Insert(entry);
            return DataCast.Get<int>(nums);
        }

        public int Update(NewsEntry entry)
        {
            return _provider.Database.Update(entry);
        }

        public int Delete(int newsId)
        {
            return _provider.Database.Delete("news", "newsid", null, newsId);
        }

        public int Delete(string ids)
        {
            int iVal = _provider.Database.Delete<NewsEntry>(Sql.Builder.WhereIn("newsid", ids.Split(',')));
            return iVal;
        }

        public NewsEntry GetAboutUs(int moduleId)
        {
            return _provider.Database.FirstOrDefault<NewsEntry>("where moduleid = @0", moduleId);
        }
    }
}
