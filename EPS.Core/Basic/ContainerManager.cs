using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Autofac;
using Autofac.Core.Lifetime;
using Autofac.Integration.Mvc;

namespace Framework.Core.Basic
{
    public class ContainerManager
    {
        private readonly IContainer _container;

        /// <summary>
        /// 容器管理
        /// </summary>
        /// <param name="container">实现了IContainer的容器对象</param>
        public ContainerManager(IContainer container)
        {
            _container = container;
        }

        /// <summary>
        /// 取得容器对象
        /// </summary>
        public IContainer Container
        {
            get { return _container; }
        }

        /// <summary>
        /// 解决依赖关系
        /// </summary>
        /// <typeparam name="T">类型占位符</typeparam>
        /// <param name="key">与服务对应的key</param>
        /// <param name="scope">对象生命周期</param>
        /// <returns></returns>
        public T Resolve<T>(string key = "", ILifetimeScope scope = null) where T : class
        {
            if (scope == null)
            {
                //no scope specified
                scope = Scope();
            }
            if (string.IsNullOrEmpty(key))
            {
                return scope.Resolve<T>();
            }
            return scope.ResolveKeyed<T>(key);
        }
        /// <summary>
        /// 解决依赖关系
        /// </summary>
        /// <param name="type">类型</param>
        /// <param name="scope">对象生命周期</param>
        /// <returns></returns>
        public object Resolve(Type type, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                //no scope specified
                scope = Scope();
            }
            return scope.Resolve(type);
        }
        /// <summary>
        /// 从上下文中返回指定类型的服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key">与服务对应的 key</param>
        /// <param name="scope">对象生命周期</param>
        /// <returns></returns>
        public T[] ResolveAll<T>(string key = "", ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                //no scope specified
                scope = Scope();
            }
            if (string.IsNullOrEmpty(key))
            {
                return scope.Resolve<IEnumerable<T>>().ToArray();
            }
            return scope.ResolveKeyed<IEnumerable<T>>(key).ToArray();
        }
        /// <summary>
        /// 从上下文中返回指定类型的服务,为未注册的类型
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="scope">对象生命周期</param>
        /// <returns></returns>
        public T ResolveUnregistered<T>(ILifetimeScope scope = null) where T : class
        {
            return ResolveUnregistered(typeof(T), scope) as T;
        }

        public object ResolveUnregistered(Type type, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                //no scope specified
                scope = Scope();
            }
            //返回该类型的所有的公开的构造函数
            var constructors = type.GetConstructors();
            //遍历每一个公开的构造函数
            foreach (var constructor in constructors)
            {
                try
                {
                    //获取构造函数中的所有参数
                    var parameters = constructor.GetParameters();
                    var parameterInstances = new List<object>();
                    //遍历构造函数中的所有参数
                    foreach (var parameter in parameters)
                    {

                        var service = Resolve(parameter.ParameterType, scope);
                        if (service == null) throw new Exception("Unkown dependency");
                        parameterInstances.Add(service);
                    }
                    return Activator.CreateInstance(type, parameterInstances.ToArray());
                }
                catch (Exception ex)
                {

                }
            }
            throw new Exception("No contructor was found that had all the dependencies satisfied.");
        }

        public bool TryResolve(Type serviceType, ILifetimeScope scope, out object instance)
        {
            if (scope == null)
            {
                //no scope specified
                scope = Scope();
            }
            return scope.TryResolve(serviceType, out instance);
        }

        public bool IsRegistered(Type serviceType, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                //no scope specified
                scope = Scope();
            }
            return scope.IsRegistered(serviceType);
        }

        public object ResolveOptional(Type serviceType, ILifetimeScope scope = null)
        {
            if (scope == null)
            {
                //no scope specified
                scope = Scope();
            }
            return scope.ResolveOptional(serviceType);
        }

        /// <summary>
        /// 创建对象的生命周期
        /// </summary>
        /// <returns></returns>
        public ILifetimeScope Scope()
        {
            try
            {
                //如果Http上下文不存在
                if (HttpContext.Current != null)
                    //该生命周期就是HTTP Request 的生命周期
                    return AutofacDependencyResolver.Current.RequestLifetimeScope;

                //when such lifetime scope is returned, you should be sure that it'll be disposed once used (e.g. in schedule tasks)
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
            catch (Exception exc)
            {
                //we can get an exception here if RequestLifetimeScope is already disposed
                //for example, requested in or after "Application_EndRequest" handler
                //but note that usually it should never happen

                //when such lifetime scope is returned, you should be sure that it'll be disposed once used (e.g. in schedule tasks)
                return Container.BeginLifetimeScope(MatchingScopeLifetimeTags.RequestLifetimeScopeTag);
            }
        }
    }
}
