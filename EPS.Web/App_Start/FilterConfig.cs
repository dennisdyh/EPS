using System.Web;
using System.Web.Mvc;
//susing DYH.Web.Framework.Filter;
using Framework.Web.Filter;

namespace EPS.Web
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new GlobalFilterAttribute());
        }
    }
}