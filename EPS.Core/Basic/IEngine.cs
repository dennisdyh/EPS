using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.Basic
{
    public interface IEngine
    {
        /// <summary>
        /// <para>容器管理者</para>
        /// </summary>
        ContainerManager ContainerManager { get; }

        /// <summary>
        /// 利用配置文件对插件和组件进行初始化
        /// </summary>
        void Initialize();

        /// <summary>
        /// <para>对给定的类型解决依赖</para>
        /// </summary>
        /// <typeparam name="T">T 类型占位符</typeparam>
        /// <returns></returns>
        T Resolve<T>() where T : class;

        /// <summary>
        /// <para>对给定的类型解决依赖</para>
        /// </summary>
        /// <param name="type">Type</param>
        /// <returns></returns>
        object Resolve(Type type);

        /// <summary>
        /// <para>对给定的类型解决依赖</para>
        /// </summary>
        /// <typeparam name="T">T</typeparam>
        /// <returns></returns>
        T[] ResolveAll<T>();
    }
}
