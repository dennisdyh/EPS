using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;

namespace EPS.IDAL
{
    public interface IModule
    {
        ModuleEntry GetByCode(string moduleCode);
        ModuleEntry GetById(int moduleId);
        IEnumerable<ModuleEntry> GetList();
        int Add(ModuleEntry entry);
        int Update(ModuleEntry entry);
        int Delete(int moduleId);
    }
}
