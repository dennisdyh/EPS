using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;

namespace EPS.IDAL
{
    public interface IBasic
    {
        IEnumerable<BasicEntry> GetList();

        BasicEntry GetByKey(string key);

        int Update(BasicEntry model);

        int Update(IEnumerable<BasicEntry> list);

        Hashtable GetRecords(int newsTypeId, int casesTypeId, int productsTypeId);

    }
}
