using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;

namespace Framework.Core.Basic
{
    public class EngineContext
    {
        /// <summary>
        /// <para>初始化一个静态实例,该方法是线程同步的</para>
        /// </summary>
        /// <param name="forceRecreate">
        /// <para>如果是真，创建一个新的工厂实例即使该实例在之前已经被初始化过</para>
        /// </param>
        [MethodImpl(MethodImplOptions.Synchronized)]
        public static IEngine Initialize(bool forceRecreate)
        {

            if (Singleton<IEngine>.Instance == null //判断引擎是否已经初始化过
                || forceRecreate //强制初始化
                )
            {
                Singleton<IEngine>.Instance = new EpsEngine();
                Singleton<IEngine>.Instance.Initialize();
            }

            return Singleton<IEngine>.Instance;
        }
    }
}
