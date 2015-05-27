using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EPS.Models.ViewModel
{
    [Serializable]
    public class LoginModel
    {
        /// <summary>
        /// 用户 ID
        /// </summary>
        public int UserId { get; set; }
        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 是否记住登录
        /// </summary>
        public string Remember { get; set; }
        /// <summary>
        /// 客户端时区
        /// </summary>
        public string ClientTimeZone { get; set; }
        /// <summary>
        /// Session ID
        /// </summary>
        public string SessionID { get; set; }
        /// <summary>
        /// 语言
        /// </summary>
        public string Language { get; set; }

        public string RoleIDs { get; set; }
    }
}
