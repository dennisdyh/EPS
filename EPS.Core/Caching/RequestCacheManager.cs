using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;

namespace Framework.Core.Caching
{
    public class RequestCacheManager : ICacheManager
    {
        private readonly HttpContextBase _context;

        /// <summary>
        /// Http上下文缓存管理构造函数
        /// </summary>
        /// <param name="context">用作包含有关某个 HTTP 请求的 HTTP 特定信息的类的基类</param>
        public RequestCacheManager(HttpContextBase context)
        {
            this._context = context;
        }
        
        /// <summary>
        /// 在派生类中重写时，获取一个键/值集合，该集合在 HTTP 请求过程中可以用于在模块与处理程序之间组织和共享数据
        /// </summary>
        protected virtual IDictionary GetItems()
        {
            if (_context != null)
                return _context.Items;

            return null;
        }

        /// <summary>
        /// 获取或者设置与指定的Key相关联的value
        /// </summary>
        /// <typeparam name="T">值类型</typeparam>
        /// <param name="key">获取值所需要的key.</param>
        /// <returns>与指定键关联的值</returns>
        public virtual T Get<T>(string key)
        {
            var items = GetItems();
            if (items == null)
                return default(T);

            return (T)items[key];
        }

        /// <summary>
        /// 添加一个指定的key和对象到缓存
        /// </summary>
        /// <param name="key">key</param>
        /// <param name="data">Data</param>
        /// <param name="cacheTime">缓存时间</param>
        public virtual void Set(string key, object data, int cacheTime)
        {
            //是否支持Http上下文缓存
            var items = GetItems();
            if (items == null)
                return;

            if (data != null)
            {
                //如果缓存存在，则更新，否则添加
                if (items.Contains(key))
                    items[key] = data;
                else
                    items.Add(key, data);
            }
        }

        /// <summary>
        /// 通过一个key从缓存中判断该缓存是否存在
        /// </summary>
        /// <param name="key">key</param>
        /// <returns>Result</returns>
        public virtual bool Contains(string key)
        {
            var items = GetItems();
            if (items == null)
                return false;

            return items.Contains(key);
        }

        /// <summary>
        /// 指定一个key从缓存中移除相关数据
        /// </summary>
        /// <param name="key">/key</param>
        public virtual void Remove(string key)
        {
            var items = GetItems();
            if (items == null)
                return;

            items.Remove(key);
        }

        /// <summary>
        /// 通过正则表达式移除相关项
        /// </summary>
        /// <param name="pattern">正则表达式</param>
        public virtual void RemoveByPattern(string pattern)
        {
            var items = GetItems();
            if (items == null)
                return;

            var enumerator = items.GetEnumerator();
            var regex = new Regex(pattern, RegexOptions.Singleline | RegexOptions.Compiled | RegexOptions.IgnoreCase);
            var keysToRemove = new List<String>();
            while (enumerator.MoveNext())
            {
                if (regex.IsMatch(enumerator.Key.ToString()))
                {
                    keysToRemove.Add(enumerator.Key.ToString());
                }
            }

            foreach (string key in keysToRemove)
            {
                items.Remove(key);
            }
        }

        /// <summary>
        /// 清除所有缓存
        /// </summary>
        public virtual void Clear()
        {
            var items = GetItems();
            if (items == null)
                return;

            var enumerator = items.GetEnumerator();
            var keysToRemove = new List<String>();
            while (enumerator.MoveNext())
            {
                keysToRemove.Add(enumerator.Key.ToString());
            }

            foreach (string key in keysToRemove)
            {
                items.Remove(key);
            }
        }
    }
}
