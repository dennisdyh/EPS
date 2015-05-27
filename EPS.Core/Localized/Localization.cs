using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Web;
using System.Configuration;
using System.IO;
using System.Web.Hosting;
using System.Web.Mvc;
using Newtonsoft.Json;

namespace Framework.Core.Localized
{
    public class Localization
    {
        public const string LanguageKey = "DYH.COOKIES";

        /// <summary>
        /// 读取语言文件
        /// </summary>
        /// <param name="langKey"></param>
        /// <returns></returns>
        public static List<DictionaryEntry> ReadLanguageSource(string langKey)
        {
            string path = string.Format(@"~/Languages/{0}.json", langKey);
            try
            {
                var reader = new StreamReader(HttpContext.Current.Server.MapPath(path));
                var languages = JsonConvert.DeserializeObject<List<DictionaryEntry>>(reader.ReadToEnd());
                reader.Close();
                return languages;
            }
            catch (Exception ex)
            {
                return null;
                throw ex;
            }

            //var cacheKey = "SCS_SYSTEM_LANGUAGE_" + langKey;
            //var cacheLanguage = ConfigurationManager.AppSettings["CacheLanguage"];
            //var isCacheLanguage = cacheLanguage == "1";

            //List<DictionaryEntry> list = null;
            //if (isCacheLanguage)
            //{
            //    list = DataCache.GetCache(cacheKey) as List<DictionaryEntry>;
            //    if (list == null)
            //    {
            //        list = GetList(langKey);
            //        DataCache.AddCache(cacheKey, list);
            //    }
            //}
            //else
            //{
            //    list = GetList(langKey);
            //}



            //return list;
        }

        private static List<DictionaryEntry> GetList(string langKey)
        {
            var list = new List<DictionaryEntry>();
            var languagePath = ConfigurationManager.AppSettings["LanguagePath"];
            if (string.IsNullOrEmpty(languagePath))
            {
                languagePath = string.Format("{0}Languages", AppDomain.CurrentDomain.BaseDirectory);
            }

            if (!Directory.Exists(languagePath))
            {
                throw new DirectoryNotFoundException("Not Found Language Path : " + languagePath);
            }

            var dirInfo = new DirectoryInfo(languagePath);
            var fileList = dirInfo.GetFiles("*.resources");
            var fullName = string.Empty;
            foreach (var item in fileList)
            {
                if (item.Name.ToLower().Contains(langKey.ToLower()))
                {
                    fullName = item.FullName;
                    break;
                }
            }

            if (string.IsNullOrEmpty(fullName))
            {
                return list;
            }
            using (var reader = new ResourceReader(fullName))
            {
                var dics = reader.Cast<DictionaryEntry>();
                list.AddRange(dics);
            }
            return list;
        }

        private static string Language
        {
            get
            {
                var langKey = "zh-CN";
                if (HttpContext.Current != null)
                {
                    var cookie = HttpContext.Current.Request.Cookies[LanguageKey];
                    if (cookie != null && !string.IsNullOrEmpty(cookie.Value))
                    {
                        langKey = cookie["Language"];
                    }
                }
                return langKey;
            }
        }

        public static DictionaryEntry Get(string key)
        {
            var langKey = Language;

            if (langKey == "en-US")
                return new DictionaryEntry() {Key = key, Value = key};

            var list = ReadLanguageSource(langKey);
            var lang = list.FirstOrDefault(x => x.Key.ToString() == key);

            return lang;
        }

        public static string GetLang(string key)
        {
            var dic = Get(key);
            if (DataCast.IsNull(dic.Value))
            {
                return key;
            }
            return Get(key).Value as string;
        }

        public static void Register()
        {
            //找出缺省的客户端数据验证类型
            var clientDataTypeValidator = ModelValidatorProviders.Providers.OfType<ClientDataTypeModelValidatorProvider>().FirstOrDefault();
            if (null != clientDataTypeValidator)
            {
                //如果有匹配删除该类型
                ModelValidatorProviders.Providers.Remove(clientDataTypeValidator);
            }
            //添加自定义的验证类型
            ModelValidatorProviders.Providers.Add(new FilterableClientDataTypeModelValidatorProvider());

            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedRequired), typeof(RequiredAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedStringLength), typeof(StringLengthAttributeAdapter));
            DataAnnotationsModelValidatorProvider.RegisterAdapter(typeof(LocalizedRegularExpression), typeof(RegularExpressionAttributeAdapter));
        }
    }
}
