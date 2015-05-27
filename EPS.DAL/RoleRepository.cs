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
    public class RoleRepository : IRole
    {
        private readonly DataProvider _provider;
        public RoleRepository(DataProvider provider)
        {
            _provider = provider;
        }

        public IEnumerable<RoleEntry> GetList()
        {
            return _provider.Database.Query<RoleEntry>("").OrderByDescending(x => x.SeqNo).ToList();
        }

        public RoleEntry GetById(int id)
        {
            return _provider.Database.FirstOrDefault<RoleEntry>("where roleid = @0", id);
        }

        public RoleEntry GetByCode(string code)
        {
            return _provider.Database.FirstOrDefault<RoleEntry>("where rolecode = @0", code);
        }

        public int Add(RoleEntry entry)
        {
            return DataCast.Get<int>(_provider.Database.Insert(entry));
        }

        public int Update(RoleEntry entry)
        {
            return _provider.Database.Update(entry);
        }

        public int Delete(int id)
        {
            return _provider.Database.Delete("roles", "roleid", null, id);
        }

        public int Delete(string ids)
        {
            int iVal = _provider.Database.Delete<ActionEntry>(Sql.Builder.WhereIn("roleid", ids.Split(',')));
            return iVal;
        }
    }
}
