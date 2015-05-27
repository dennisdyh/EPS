using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.Caching
{
    /// <summary>
    /// 缓存管理接口
    /// </summary>
    public interface ICacheManager
    {
        /// <summary>
        /// 获取或者设置与指定的Key相关联的value
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">获取值所需要的key.</param>
        /// <returns>The value associated with the specified key.</returns>
        T Get<T>(string key);

        /// <summary>
        /// 添加一个指定的key和对象到缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">缓存时间</param>
        void Set(string key, object data, int cacheTime);

        /// <summary>
        /// 通过一个key从缓存中判断该缓存是否存在
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        bool Contains(string key);

        /// <summary>
        /// 指定一个key从缓存中移除相关数据
        /// </summary>
        /// <param name="key">/key</param>
        void Remove(string key);

        /// <summary>
        /// 通过匹配模式移除相关项
        /// </summary>
        /// <param name="pattern">pattern</param>
        void RemoveByPattern(string pattern);

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        void Clear();
    }
}
