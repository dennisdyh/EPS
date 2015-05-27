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
    public class ModuleRepository : IModule
    {
        private readonly DataProvider _provider;
        public ModuleRepository(DataProvider provider)
        {
            _provider = provider;
        }

        public ModuleEntry GetByCode(string moduleCode)
        {
            return _provider.Database.FirstOrDefault<ModuleEntry>("WHERE modulecode = @0", moduleCode);
        }

        public ModuleEntry GetById(int moduleId)
        {
            return _provider.Database.FirstOrDefault<ModuleEntry>("WHERE moduleid = @0", moduleId);
        }

        public IEnumerable<ModuleEntry> GetList()
        {
            return _provider.Database.Query<ModuleEntry>("").ToList();
        }

        public int Add(ModuleEntry entry)
        {
            return DataCast.Get<int>(_provider.Database.Insert(entry));
        }

        public int Update(ModuleEntry entry)
        {
            return _provider.Database.Update(entry);
        }

        public int Delete(int moduleId)
        {
            //PSQL
            //var sql = Sql.Builder.Append("WITH RECURSIVE cte AS ( ");
            //sql.Append("SELECT * FROM modules WHERE moduleid = @0", moduleId);
            //sql.Append("UNION ALL");
            //sql.Append("SELECT a.* FROM modules a inner join cte b on b.moduleid = a.parentid ");
            //sql.Append(")");

            //sql.Append("DELETE FROM modules");
            //sql.Append("WHERE EXISTS ( SELECT moduleid");
            //sql.Append("FROM cte");
            //sql.Append("WHERE cte.moduleid = modules.moduleid )");

            var sql = Sql.Builder.Append("WITH Temp AS (");
            sql.Append("SELECT * FROM Modules WHERE ModuleID = @0", moduleId);
            sql.Append("UNION ALL");
            sql.Append("SELECT B.* FROM Temp A , Modules B WHERE A.ModuleID = B.ParentID )");
            sql.Append("DELETE  FROM Modules");
            sql.Append("WHERE EXISTS ( SELECT ModuleID");
            sql.Append("FROM Temp");
            sql.Append("WHERE Temp.ModuleID = Modules.ModuleID )");

            return _provider.Database.Execute(sql);
        }
    }
}
