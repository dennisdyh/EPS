using System.Collections.Generic;
using EPS.Models;

namespace EPS.IDAL
{
    public interface IRoleRight
    {
        IEnumerable<RoleRightEntry> GetList(int roleId);
        RoleRightEntry GetById(int roleRightId);
        int Add(RoleRightEntry entry);
        int Add(IEnumerable<RoleRightEntry> list);
        int Update(RoleRightEntry entry);
        int Update(IEnumerable<RoleRightEntry> list);
    }
}
