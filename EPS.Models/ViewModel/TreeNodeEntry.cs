using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPS.Models.ViewModel
{
    public class TreeNodeEntry
    {
        public TreeNodeEntry()
        {
            Children = new List<TreeNodeEntry>();
        }

        public int Id { get; set; }
        public int ParentId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public bool IsActived { get; set; }
        public List<TreeNodeEntry> Children { get; private set; }
    }

    public class TreeNodeEntry<T> : TreeNodeEntry
    {
        public TreeNodeEntry()
        {
            Children = new List<TreeNodeEntry<T>>();
        }
       
        public T Entity { get; set; }

        public new List<TreeNodeEntry<T>> Children
        {
            get;
            private set;
        }
    }
}
