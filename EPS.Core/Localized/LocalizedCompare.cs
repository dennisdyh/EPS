using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Framework.Core.Localized
{
    public class LocalizedCompare : CompareAttribute
    {
        public LocalizedCompare(string otherProperty)
            : base(otherProperty)
        {
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format(Localization.GetLang(base.ErrorMessage), base.OtherPropertyDisplayName, name);
        }
    }
}
