using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;

namespace EPS.IDAL
{
    public interface INews
    {
        IEnumerable<NewsEntry> GetList(PageSqlModel model);

        IEnumerable<NewsEntry> GetPhotoList(PageSqlModel model);

        NewsEntry GetAboutUs(int moduleId);
        NewsEntry GetById(int newsId);
        int Add(NewsEntry entry);
        int Update(NewsEntry entry);
        int Delete(int newsId);
        int Delete(string ids);
    }
}
