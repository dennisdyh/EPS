using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Framework.Core;

using EPS.IDAL;
using EPS.Models;
using Framework;
using Framework.Data;

namespace EPS.DAL
{
    public class UserRepository : IUser
    {
        private readonly DataProvider _provider;
        public UserRepository(DataProvider provider)
        {
            _provider = provider;
        }

        public UserEntry GetUserById(int userId)
        {
            return _provider.Database.FirstOrDefault<UserEntry>("WHERE userid = @0", userId);
        }

        public UserEntry GetUserByName(string userName)
        {
            return _provider.Database.FirstOrDefault<UserEntry>("WHERE username = @0", userName);
        }

        public UserEntry GetUserByEmail(string email)
        {
            return _provider.Database.FirstOrDefault<UserEntry>("WHERE email = @0", email);
        }

        public int Add(UserEntry entry)
        {
            return DataCast.Get<int>(_provider.Database.Insert(entry));
        }

        public int Update(UserEntry entry)
        {
            return _provider.Database.Update(entry);
        }

        public int Delete(int id)
        {
            return _provider.Database.Delete("users", "userid", null, id);
        }

        public int Delete(string ids)
        {
            //int iVal = _provider.Database.Delete<UserEntry>("WHERE userid in (" + ids + ") ");

            int iVal = _provider.Database.Delete<UserEntry>(Sql.Builder.WhereIn("userid", ids.Split(',')));

            return iVal;
        }

        public List<UserEntry> GetList(PageModel model)
        {
            var page = _provider.Database.Page<UserEntry>(model.PageIndex, model.PageSize, model.Filter, model.Params);
            model.Records = (int)page.TotalItems;
            model.PageCount = page.TotalPages;

            return page.Items;
        }

        public IEnumerable<UserRightEntry> GetList(string roleIds)
        {
            var sql = Sql.Builder.Append("SELECT  * ");
            sql.Append("FROM    (");
            sql.Append("SELECT    B.RoleID ,");
            sql.Append("D.ModuleID ,");
            sql.Append("D.ModuleCode ,");
            sql.Append("D.DisplayName ,");
            sql.Append("E.ActionID ,");
            sql.Append("E.ActionCode ,");
            sql.Append("B.Status");
            sql.Append("FROM UserRoles A");
            sql.Append("JOIN RoleRights B");
            sql.Append("ON A.RoleID = B.RoleID");
            sql.Append("JOIN ActionModules C");
            sql.Append("ON B.ActionModuleID = C.ActionModuleID");
            sql.Append("AND C.Status = true");
            sql.Append("JOIN Modules D");
            sql.Append("ON C.ModuleID = D.ModuleID");
            sql.Append("JOIN Actions E");
            sql.Append("ON C.ActionID = E.ActionID ) T");
            sql.WhereIn("RoleId", roleIds.Split(','));

            return _provider.Database.Query<UserRightEntry>(sql);
        }
    }
}
