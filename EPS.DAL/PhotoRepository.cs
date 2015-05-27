using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.IDAL;
using EPS.Models;
using Framework;
using Framework.Core;
using Framework.Data;

namespace EPS.DAL
{
    public class PhotoRepository : IPhoto
    {
        private readonly DataProvider _provider;
        public PhotoRepository(DataProvider provider)
        {
            _provider = provider;
        }

        public PhotoEntry GetById(int photoId)
        {
            return _provider.Database.FirstOrDefault<PhotoEntry>("WHERE photoid = @0", photoId);
        }

        public IEnumerable<PhotoEntry> GetList(int newsId)
        {
            return _provider.Database.Query<PhotoEntry>("WHERE newsid = @0", newsId);
        }

        public IEnumerable<PhotoEntry> GetList(PageModel model)
        {
            var page = _provider.Database.Page<PhotoEntry>(model.PageIndex, model.PageSize, model.Filter, model.Params);
            model.Records = (int)page.TotalItems;
            model.PageCount = page.TotalPages;

            return page.Items;
        }

        public int Add(PhotoEntry model)
        {
            return DataCast.Get<int>(_provider.Database.Insert(model));
        }

        public int Update(PhotoEntry model)
        {
            return _provider.Database.Update(model);
        }

        public int Delete(string ids)
        {
            int iVal = _provider.Database.Delete<PhotoEntry>(Sql.Builder.WhereIn("photoid", ids.Split(',')));

            return iVal;
        }

        public int Delete(int id)
        {
            return _provider.Database.Delete("photos", "photoid", null, id);
        }

        public IEnumerable<dynamic> GetList(Sql sql)
        {
            return _provider.Database.Query<dynamic>(sql);
        }
    }
}
