using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;

namespace EPS.IDAL
{
    public interface IActionModule
    {
        IEnumerable<ActionModuleEntry> GetList();
        int Add(ActionModuleEntry entry);
        int Add(IEnumerable<ActionModuleEntry> list);
        int Update(ActionModuleEntry entry);
        int Update(IEnumerable<ActionModuleEntry> list);
    }
}
