using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;

namespace EPS.IDAL
{
    public interface IAction
    {
        IEnumerable<ActionEntry> GetList();
        ActionEntry GetById(int id);
        ActionEntry GetByCode(string code);
        int Add(ActionEntry entry);
        int Update(ActionEntry entry);
        int Delete(int id);
        int Delete(string ids);
    }
}
