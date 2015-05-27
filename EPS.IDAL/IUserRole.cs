using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;

namespace EPS.IDAL
{
    public interface IUserRole
    {
        IEnumerable<UserRoleEntry> GetList();
        IEnumerable<UserRoleEntry> GetList(int userId);
        int Add(UserRoleEntry entry);
        int Add(IEnumerable<UserRoleEntry> list);
        int Update(UserRoleEntry entry);
        int Update(IEnumerable<UserRoleEntry> list);
    }
}
