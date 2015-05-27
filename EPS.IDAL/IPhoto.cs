using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;
using Framework;
using Framework.Data;

namespace EPS.IDAL
{
    public interface IPhoto
    {
        PhotoEntry GetById(int photoId);

        IEnumerable<PhotoEntry> GetList(PageModel model);

        IEnumerable<PhotoEntry> GetList(int newsId);

        IEnumerable<dynamic> GetList(Sql sql);

        int Add(PhotoEntry model);

        int Update(PhotoEntry model);

        int Delete(string ids);

        int Delete(int id);
    }
}
