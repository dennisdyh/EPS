using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using EPS.Models;
using Framework.Core.Localized;


namespace Framework.Web.Utils
{
    public class TreeUtils
    {
        public static ModuleEntry GetTree(IEnumerable<ModuleEntry> list, int currentId)
        {
            var root = new ModuleEntry
            {
                ModuleCode = "Root",
                DisplayName = Localization.GetLang("Root"),
                SeqNo = 1,
                ParentId = 0,
                ModuleId = 0
            };

            return GetSubItem(list, root, currentId);
        }

        private static ModuleEntry GetSubItem(IEnumerable<ModuleEntry> source, ModuleEntry parentNode, int currentId)
        {
            if (source == null || parentNode == null)
            {
                return null;
            }
            var list = source.Where(x => x.ParentId == parentNode.ModuleId).OrderBy(x => x.SeqNo);

            foreach (var item in list)
            {
                var child = Framework.Core.Utils.Dereference(item);
                child.IsActived = child.ModuleId == currentId;

                parentNode.Children.Add(GetSubItem(source, child, currentId));
                if (child.Children.Any(x => x.IsActived))
                {
                    child.IsActived = true;
                }
            }

            return parentNode;
        }
    }
}
