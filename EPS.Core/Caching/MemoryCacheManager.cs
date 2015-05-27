using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Caching;
using System.Text;
using System.Text.RegularExpressions;

namespace Framework.Core.Caching
{
    /// <summary>
    /// 表示一个对MemoryCache的缓存管理 （长期的缓存）
    /// </summary>
    public class MemoryCacheManager : ICacheManager
    {
        /// <summary>
        /// 获取对默认 MemoryCache 实例的引用, MemoryCache 继承自ObjectCache
        /// </summary>
        protected ObjectCache Cache
        {
            get
            {
                return MemoryCache.Default;
            }
        }

        /// <summary>
        /// 获取或者设置与指定的Key相关联的value
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">获取值所需要的key.</param>
        /// <returns>与指定键关联的值</returns>
        public virtual T Get<T>(string key)
        {
            return (T)Cache[key];
        }

        /// <summary>
        /// 添加一个指定的key和对象到缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">缓存时间</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            if (data == null)
                return;
            //定义缓存策略，该缓存什么时候过期，应该被清除
            var policy = new CacheItemPolicy();
            //获取或设置一个值，该值指示是否应在指定持续时间过后逐出某个缓存项, 指定缓存多长时间
            policy.AbsoluteExpiration = DateTime.Now + TimeSpan.FromMinutes(cacheTime);
            //添加缓存
            Cache.Add(new CacheItem(key, data), policy);
        }

        /// <summary>
        /// 通过一个key从缓存中判断该缓存是否存在
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public virtual bool Contains(string key)
        {
            return (Cache.Contains(key));
        }

        /// <summary>
        /// 指定一个key从缓存中移除相关数据
        /// </summary>
        /// <param name="key">/key</param>
        public virtual void Remove(string key)
        {
            Cache.Remove(key);
        }

        /// <summary>
        /// 通过正则表达式移除相关项
        /// </summary>
        /// <param name="pattern">正则表达式</param>
        public virtual void RemoveByPattern(string pattern)
        {
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = (from item in Cache where regex.IsMatch(item.Key) select item.Key).ToList();

            foreach (string key in keysToRemove)
            {
                Remove(key);
            }
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public virtual void Clear()
        {
            foreach (var item in Cache)
                Remove(item.Key);
        }
    }
}
