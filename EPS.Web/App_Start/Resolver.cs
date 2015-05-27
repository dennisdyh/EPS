using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using EPS.Web.Controllers;
using Framework.Core.Caching;
using EPS.DAL;
using EPS.IDAL;
using Framework.Web.Admission;
using Admin = EPS.Web.Areas.Admin.Controllers;
using Framework.Core.Localized;
using Framework.Data;

namespace EPS.Web
{
    public class Resolver
    {
        public static void Init()
        {
            var builder = new ContainerBuilder();

            builder.Register(c => new HttpContextWrapper(HttpContext.Current) as HttpContextBase)
                .As<HttpContextBase>()
                .InstancePerLifetimeScope();
            //builder.Register(c => c.Resolve<HttpContextBase>().Request)
            //    .As<HttpRequestBase>()
            //    .InstancePerLifetimeScope();
            //builder.Register(c => c.Resolve<HttpContextBase>().Response)
            //    .As<HttpResponseBase>()
            //    .InstancePerLifetimeScope();
            //builder.Register(c => c.Resolve<HttpContextBase>().Server)
            //    .As<HttpServerUtilityBase>()
            //    .InstancePerLifetimeScope();
            //builder.Register(c => c.Resolve<HttpContextBase>().Session)
            //    .As<HttpSessionStateBase>()
            //    .InstancePerLifetimeScope();

            builder.RegisterType<MemoryCacheManager>().As<ICacheManager>().Named<ICacheManager>("dyh_cache_static").SingleInstance();
            builder.RegisterType<RequestCacheManager>().As<ICacheManager>().Named<ICacheManager>("dyh_cache_per_request").InstancePerLifetimeScope();

            builder.RegisterType<DataProvider>();
           
            builder.RegisterType<UserRepository>().As<IUser>();
            builder.RegisterType<ActionRepository>().As<IAction>();
            builder.RegisterType<ModuleRepository>().As<IDAL.IModule>();
            builder.RegisterType<RoleRepository>().As<IRole>();
            builder.RegisterType<ActionModuleRepository>().As<IActionModule>();
            builder.RegisterType<UserRoleRepository>().As<IUserRole>();
            builder.RegisterType<RoleRightRepository>().As<IRoleRight>();
            builder.RegisterType<NewsRepository>().As<INews>();
            builder.RegisterType<PhotoRepository>().As<IPhoto>();
            builder.RegisterType<BasicRepository>().As<IBasic>();

            //builder.Register(x => new Authority(x.Resolve<IUser>(), x.Resolve<ICacheManager>()))
            //    .InstancePerDependency();

            

            builder.RegisterModule(new ModuleRegister());

            var assemblies = Assembly.GetExecutingAssembly();
            var list = typeof(MvcApplication).Assembly;

            builder.RegisterControllers(list);

            builder.RegisterType<Admin.UsersController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.ActionsController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.ModulesController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.RolesController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.AboutController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.NewsController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
            builder.RegisterType<Admin.CasesController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));

            builder.RegisterType<HomeController>().WithParameter(ResolvedParameter.ForNamed<ICacheManager>("dyh_cache_static"));
          
            var container = builder.Build();

            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("zh-CN");
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("zh-CN");

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            Localization.Register();
        }
    }
}