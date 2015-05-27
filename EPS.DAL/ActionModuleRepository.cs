using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Framework.Core;
using EPS.IDAL;
using EPS.Models;
using Framework.Data;

namespace EPS.DAL
{
    public class ActionModuleRepository : IActionModule
    {
        private readonly DataProvider _provider;
        public ActionModuleRepository(DataProvider provider)
        {
            _provider = provider;
        }

        public IEnumerable<ActionModuleEntry> GetList()
        {
            return _provider.Database.Query<ActionModuleEntry>("").ToList();
        }

        public int Add(ActionModuleEntry entry)
        {
            return DataCast.Get<int>(_provider.Database.Insert(entry));
        }

        public int Update(ActionModuleEntry entry)
        {
            return _provider.Database.Update(entry);
        }

        public int Add(IEnumerable<ActionModuleEntry> list)
        {
            var db = _provider.Database;
            int i = 0;
            using (var tran = db.GetTransaction())
            {
                foreach (var item in list)
                {
                    db.Insert(item);
                    i++;
                }

                tran.Complete();
            }

            if (i == list.Count())
                return 1;

            return 0;
        }

        public int Update(IEnumerable<ActionModuleEntry> list)
        {
            var db = _provider.Database;
            int i = 0;
            using (var tran = db.GetTransaction())
            {
                foreach (var item in list)
                {
                    db.Update(item);
                    i++;
                }

                tran.Complete();
            }

            if (i == list.Count())
                return 1;

            return 0;
        }
    }
}
