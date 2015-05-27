using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Autofac;
using Autofac.Core;
using EPS.Web.Controllers;
using Framework.Core.Basic;
using Framework.Core.Caching;
using Admin = EPS.Web.Areas.Admin.Controllers;

namespace EPS.Web
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
            builder.RegisterType<Admin.UsersController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.ActionsController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.ModulesController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.RolesController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.AboutController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.NewsController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.CasesController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.DashboardController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<HomeController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
        }


        public int Order
        {
            get { return 1; }
        }
    }
}