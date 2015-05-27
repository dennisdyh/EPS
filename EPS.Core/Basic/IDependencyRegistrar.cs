using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Autofac;

namespace Framework.Core.Basic
{
    public interface IDependencyRegistrar
    {
        /// <summary>
        /// 注册类型
        /// </summary>
        /// <param name="builder">实现为组件注册容器</param>
        void Register(ContainerBuilder builder);
        /// <summary>
        /// 排序序号，表示那个先注册依赖
        /// </summary>
        int Order { get; }
    }
}
