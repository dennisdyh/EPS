using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;

namespace EPS.IDAL
{
    public interface IRole
    {
        IEnumerable<RoleEntry> GetList();
        RoleEntry GetById(int id);
        RoleEntry GetByCode(string code);
        int Add(RoleEntry entry);
        int Update(RoleEntry entry);
        int Delete(int id);
        int Delete(string ids);
    }
}
