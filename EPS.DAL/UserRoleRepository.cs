using System;
using System.Collections.Generic;
using System.Linq;
using Framework.Core;
using EPS.IDAL;
using EPS.Models;
using Framework.Data;

namespace EPS.DAL
{
    public class UserRoleRepository : IUserRole
    {
        private readonly DataProvider _provider;
        public UserRoleRepository(DataProvider provider)
        {
            _provider = provider;
        }

        public IEnumerable<UserRoleEntry> GetList()
        {
            return _provider.Database.Query<UserRoleEntry>("").ToList();
        }

        public int Add(UserRoleEntry entry)
        {
            return DataCast.Get<int>(_provider.Database.Insert(entry));
        }

        public int Add(IEnumerable<UserRoleEntry> list)
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

        public int Update(UserRoleEntry entry)
        {
            return _provider.Database.Update(entry);
        }

        public int Update(IEnumerable<UserRoleEntry> list)
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


        public IEnumerable<UserRoleEntry> GetList(int userId)
        {
            return _provider.Database.Query<UserRoleEntry>("WHERE userid = @0", userId).ToList();
        }
    }
}
