using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.IDAL;
using EPS.Models;
using Framework;
using Framework.Data;

namespace EPS.DAL
{
    public class BasicRepository : IBasic
    {
        private readonly DataProvider _provider;
        public BasicRepository(DataProvider provider)
        {
            _provider = provider;
        }

        public IEnumerable<BasicEntry> GetList()
        {
            return _provider.Database.Query<BasicEntry>("").ToList();
        }

        public BasicEntry GetByKey(string key)
        {
            return _provider.Database.FirstOrDefault<BasicEntry>("where key = @0", key);
        }

        public int Update(BasicEntry model)
        {
            int ival = _provider.Database.Update(model);
            return ival;
        }
        public int Update(IEnumerable<BasicEntry> list)
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


        public System.Collections.Hashtable GetRecords(int newsTypeId, int casesTypeId, int productsTypeId)
        {
            var sql1 = Sql.Builder.Append("SELECT COUNT(1) AS Records FROM users;");
            var sql2 = Sql.Builder.Append("SELECT COUNT(1) AS Records FROM news WHERE parentid = @0;", newsTypeId);
            var sql3 = Sql.Builder.Append("SELECT COUNT(1) AS Records FROM news WHERE parentid = @0;", casesTypeId);
            var sql4 = Sql.Builder.Append("SELECT COUNT(1) AS Records FROM news WHERE parentid = @0;", productsTypeId);
            var db = _provider.Database;

            var table = new Hashtable();
            using (var tran = db.GetTransaction())
            {
                table["Users"] = db.ExecuteScalar<int>(sql1);
                table["News"] = db.ExecuteScalar<int>(sql2);
                table["Cases"] = db.ExecuteScalar<int>(sql3);
                table["Products"] = db.ExecuteScalar<int>(sql4);
                tran.Complete();
            }

            return table;
        }
    }
}
