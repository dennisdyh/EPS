using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.Basic
{
    /// <summary>
    /// 一个静态编译的单例用来存储整个应用程序域生命周期中的对象
    /// </summary>
    /// <typeparam name="T">存储对象的类型</typeparam>
    /// <remarks>对实例的访问时同步的</remarks>
    public class Singleton<T> : Singleton
    {
        static T instance;

        /// <summary>
        /// 获取或设置给定类型的单例实例，在当前实例列表中每一个类型只有一个实例
        /// </summary>
        public static T Instance
        {
            get { return instance; }
            set
            {
                instance = value;
                AllSingletons[typeof(T)] = value;
            }
        }
    }

    /// <summary>
    /// 对一个确定类型提供一个单例列表
    /// Provides a singleton list for a certain type.
    /// </summary>
    /// <typeparam name="T">The type of list to store.</typeparam>
    public class SingletonList<T> : Singleton<IList<T>>
    {
        static SingletonList()
        {
            Singleton<IList<T>>.Instance = new List<T>();
        }

        /// <summary>
        /// 获取给定类型的单例实例，在当前实例列表中每一个类型只有一个实例
        /// The singleton instance for the specified type T. Only one instance (at the time) of this list for each type of T.
        /// </summary>
        public new static IList<T> Instance
        {
            get { return Singleton<IList<T>>.Instance; }
        }
    }

    /// <summary>
    /// 为每一个确定的key和value类型提供一个访问单例模式的数据字典
    /// Provides a singleton dictionary for a certain key and vlaue type.
    /// </summary>
    /// <typeparam name="TKey">指定的Key类型</typeparam>
    /// <typeparam name="TValue">指定的value类型</typeparam>
    public class SingletonDictionary<TKey, TValue> : Singleton<IDictionary<TKey, TValue>>
    {
        static SingletonDictionary()
        {
            Singleton<Dictionary<TKey, TValue>>.Instance = new Dictionary<TKey, TValue>();
        }

        /// <summary>
        ///  获取给定类型的单例实例，在当前实例列表中每一个类型只有一个实例
        /// </summary>
        public new static IDictionary<TKey, TValue> Instance
        {
            get { return Singleton<Dictionary<TKey, TValue>>.Instance; }
        }
    }

    /// <summary>
    /// 提供一个访问所有单例实例的类
    /// Provides access to all "singletons" stored by <see cref="Singleton{T}"/>.
    /// </summary>
    public class Singleton
    {
        static Singleton()
        {
            allSingletons = new Dictionary<Type, object>();
        }
        /// <summary>
        /// 数据字典，用来存储单例对象
        /// </summary>
        static readonly IDictionary<Type, object> allSingletons;

        /// <summary>
        /// 获取所有的单例实例类型的数据字典
        /// </summary>
        public static IDictionary<Type, object> AllSingletons
        {
            get { return allSingletons; }
        }
    }
}
