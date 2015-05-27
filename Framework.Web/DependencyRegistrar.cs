using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Hosting;
using Autofac;
using Autofac.Integration.Mvc;
using EPS.DAL;
using EPS.IDAL;
using Framework.Core.Basic;
using Framework.Core.Caching;
using Framework.Data;


namespace Framework.Web
{
    public class DependencyRegistrar : IDependencyRegistrar
    {
        public void Register(ContainerBuilder builder)
        {
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
            builder.RegisterType<ModuleRepository>().As<EPS.IDAL.IModule>();
            builder.RegisterType<RoleRepository>().As<IRole>();
            builder.RegisterType<ActionModuleRepository>().As<IActionModule>();
            builder.RegisterType<UserRoleRepository>().As<IUserRole>();
            builder.RegisterType<RoleRightRepository>().As<IRoleRight>();
            builder.RegisterType<NewsRepository>().As<INews>();
            builder.RegisterType<PhotoRepository>().As<IPhoto>();
            builder.RegisterType<BasicRepository>().As<IBasic>();

            builder.RegisterModule(new ModuleRegister());

            var assemblies = new DirectoryInfo(HostingEnvironment.MapPath("~/bin/")).GetFiles("*.dll")
                .Select(r => Assembly.LoadFrom(r.FullName)).ToArray();
            var list = AppDomain.CurrentDomain.GetAssemblies();
            builder.RegisterControllers(list);
        }

        public int Order
        {
            get { return 0; }
        }
    }
}