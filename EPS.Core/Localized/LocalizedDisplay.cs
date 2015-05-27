using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;

namespace Framework.Core.Localized
{
    public class LocalizedDisplay : DisplayNameAttribute
    {
        private string _nameOrKey = string.Empty;

        public LocalizedDisplay(string nameOrKey)
        {
            _nameOrKey = nameOrKey;
        }

        public override string DisplayName
        {
            get
            {
                return Localization.GetLang(_nameOrKey);
            }
        }
    }
}
