using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Framework.Core.Caching
{
    public static class CacheExtensions
    {
        /// <summary>
        /// 获取一个缓存，如果该缓存不存在，那么缓存它（缓存时间为60分钟），最后返回缓存值本身
        /// </summary>
        /// <typeparam name="T">需要缓存的数据的数据类型</typeparam>
        /// <param name="cacheManager">实现了ICacheManager的缓存管理对象</param>
        /// <param name="key">缓存需要的key</param>
        /// <param name="acquire">匿名函数，封装一个不具有参数但却返回指定类型值的方法</param>
        /// <returns>Cached item</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, Func<T> acquire)
        {
            return Get(cacheManager, key, 60, acquire);
        }

        /// <summary>
        /// 获取一个缓存，如果该缓存不存在，那么缓存它（如果缓存时间不为0），最后返回缓存值本身
        /// </summary>
        /// <typeparam name="T">需要缓存的数据的数据类型</typeparam>
        /// <param name="cacheManager">实现了ICacheManager的缓存管理对象</param>
        /// <param name="key">缓存需要的key</param>
        /// <param name="cacheTime">缓存时间，单位是分钟，如果是0， 则表示不缓存， 直接返回需要缓存的数据</param>
        /// <param name="acquire">匿名函数，封装一个不具有参数但却返回指定类型值的方法</param>
        /// <returns>Cached item</returns>
        public static T Get<T>(this ICacheManager cacheManager, string key, int cacheTime, Func<T> acquire)
        {
            //判断缓存是否已经缓存过，并且存在，如果缓存存在则直接返回
            if (cacheManager.Contains(key))
            {
                return cacheManager.Get<T>(key);
            }
            else
            {
                //匿名函数，封装一个不具有参数但却返回 指定类型值的方法；
                var result = acquire();
                //如果缓存时间大于0
                if (cacheTime > 0)
                    //将需要缓存的对象缓存
                    cacheManager.Set(key, result, cacheTime);

                return result;
            }
        }
    }
}
