using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

namespace Framework.Core.Basic
{
    public class EpsEngine : IEngine
    {
        private ContainerManager _containerManager;
        public ContainerManager ContainerManager
        {
            get { return _containerManager; }
        }

        public void Initialize()
        {
            var builder = new ContainerBuilder();
            var container = builder.Build();

            //we create new instance of ContainerBuilder
            //because Build() or Update() method can only be called once on a ContainerBuilder.


            //dependencies
            builder = new ContainerBuilder();
            builder.RegisterInstance(this).As<IEngine>().SingleInstance();
            builder.Update(container);

            //register dependencies provided by other assemblies
            builder = new ContainerBuilder();

            var list = AppDomain.CurrentDomain.GetAssemblies();

            var drTypes = FindClassesOfType(typeof(IDependencyRegistrar), list);
            var drInstances = new List<IDependencyRegistrar>();
            foreach (var drType in drTypes)
                drInstances.Add((IDependencyRegistrar)Activator.CreateInstance(drType));
            //sort
            drInstances = drInstances.AsQueryable().OrderBy(t => t.Order).ToList();
            foreach (var dependencyRegistrar in drInstances)
                dependencyRegistrar.Register(builder);

            builder.Update(container);


            this._containerManager = new ContainerManager(container);

            //set dependency resolver
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }

        /// <summary>
        /// 默认获取给定的程序集中的所有的公开实体类型，因为onlyConcreteClasses=true。
        /// </summary>
        /// <param name="assignTypeFrom">父类型，或者说是子类的扩展类型</param>
        /// <param name="assemblies">给定的程序集集合</param>
        /// <param name="onlyConcreteClasses">是否是只获取实体体的类，即该类不是抽象类或者接口</param>
        /// <returns></returns>
        public IEnumerable<Type> FindClassesOfType(Type assignTypeFrom, IEnumerable<Assembly> assemblies, bool onlyConcreteClasses = true)
        {
            //返回实体类型
            var result = new List<Type>();
            try
            {
                //遍历给定的程序集集合
                foreach (var a in assemblies)
                {
                    Type[] types = null;
                    try
                    {
                        //获取给定程序集里面的所有的公开类型
                        types = a.GetTypes();
                    }
                    catch
                    {
                       
                    }
                    if (types != null)
                    {
                        //遍历每一个类型
                        foreach (var t in types.Where(t => assignTypeFrom.IsAssignableFrom(t) || (assignTypeFrom.IsGenericTypeDefinition && DoesTypeImplementOpenGeneric(t, assignTypeFrom))).Where(t => !t.IsInterface))
                        {
                            //如果该类型是一个具体的类
                            if (onlyConcreteClasses)
                            {
                                //t 是一个类，并且t 不是抽象类
                                if (t.IsClass && !t.IsAbstract)
                                {
                                    result.Add(t);
                                }
                            }
                            else
                            {
                                result.Add(t);
                            }
                        }
                    }
                }
            }
            catch (ReflectionTypeLoadException ex)
            {
                var msg = string.Empty;
                foreach (var e in ex.LoaderExceptions)
                    msg += e.Message + Environment.NewLine;

                var fail = new Exception(msg, ex);
               

                throw fail;
            }
            return result;
        }

        /// <summary>
        /// Does type implement generic?
        /// 确认指定的类型是否扩展自给定的泛型
        /// </summary>
        /// <param name="type">给定的类型</param>
        /// <param name="openGeneric">开放式的泛型， 例如：List&lt;&gt; 尖括号中没有给定类型</param>
        /// <returns></returns>
        protected bool DoesTypeImplementOpenGeneric(Type type, Type openGeneric)
        {
            try
            {
                var genericTypeDefinition = openGeneric.GetGenericTypeDefinition();
                foreach (var implementedInterface in type.FindInterfaces((objType, objCriteria) => true, null))
                {
                    if (!implementedInterface.IsGenericType)
                        continue;

                    var isMatch = genericTypeDefinition.IsAssignableFrom(implementedInterface.GetGenericTypeDefinition());
                    return isMatch;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// <para>对给定的类型解决依赖</para>
        /// Resolve dependency
        /// </summary>
        /// <typeparam name="T">T 类型占位符</typeparam>
        /// <returns></returns>
        public T Resolve<T>() where T : class
        {
            return ContainerManager.Resolve<T>();
        }

        /// <summary>
        /// <para>对给定的类型解决依赖</para>
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        public object Resolve(Type type)
        {
            return ContainerManager.Resolve(type);
        }

        /// <summary>
        /// <para>对给定的类型解决依赖</para>
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        public T[] ResolveAll<T>()
        {
            return ContainerManager.ResolveAll<T>();
        }
    }
}
