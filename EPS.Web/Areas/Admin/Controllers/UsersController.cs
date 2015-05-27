using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Framework.Core;
using Framework.Core.Caching;
using EPS.IDAL;
using EPS.Models;
using EPS.Models.ViewModel;
using Framework.Core.Localized;
using Framework.Web;
using Framework.Web.Admission;
using Framework.Web.Utils;
using WebGrease.Css.Extensions;

namespace EPS.Web.Areas.Admin.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUser _user;
        private readonly IRole _role;
        private readonly IUserRole _userRole;
        private readonly ICacheManager _cache;
        private readonly IBasic _basic;

        public UsersController(IUser user, IRole role, IUserRole userRole, IBasic basic, ICacheManager cache)
        {
            _user = user;
            _role = role;
            _userRole = userRole;
            _cache = cache;
            _basic = basic;
        }

        [HttpGet]
        public ActionResult Login(string type, string ReturnUrl)
        {
            Utility.GetModelState(this);

            var model = new LoginViewModel();
            model.ReturnUrl = ReturnUrl;
            var cookie = Request.Cookies["DYH.COOKIES"];
            if (cookie != null)
            {
                model.Remember = "on";
                model.UserName = cookie["UserName"];
            }

            ViewBag.ReturnUrl = ReturnUrl;
            if (Utility.IsLogin)
            {
                if (!string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect(ReturnUrl);
                }
            }

            if (type == "timeout")
            {
                return View(model);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserName))
            {
                ModelState.AddModelError("", "Please enter user name");
            }

            if (string.IsNullOrEmpty(model.Password))
            {
                ModelState.AddModelError("", "Please enter password");
            }

            if (ModelState.IsValid)
            {
                var info = _user.GetUserByName(model.UserName);
                string pwd = Security.PwdMd5(model.Password);
                if (info.Password == pwd)
                {
                    var cookie = Request.Cookies["DYH.COOKIES"];
                    string langKey = "en-US";
                    if (string.IsNullOrEmpty(info.Language))
                    {
                        //从浏览器获取首选语言
                        var firstLangOfBrowser = Request.UserLanguages != null ? Request.UserLanguages[0] : "en-US";
                        if (!string.IsNullOrEmpty(firstLangOfBrowser))
                        {
                            langKey = firstLangOfBrowser;
                        }
                    }
                    else
                        langKey = info.Language;

                    var list = _userRole.GetList(info.UserId);
                    var sb = new StringBuilder();
                    list.ForEach(x => sb.Append(x.RoleId + ","));

                    var roleids = Utils.RemoveLastStr(sb.ToString(), ",");
                    var login = new LoginModel()
                    {
                        UserId = info.UserId,
                        UserName = info.UserName,
                        SessionID = Session.SessionID,
                        Remember = model.Remember,
                        Language = langKey,
                        RoleIDs = roleids,
                        ClientTimeZone = model.TimezoneOffset
                    };

                    var isRemember = model.Remember == "on";
                    if (isRemember)
                    {
                        if (cookie == null)
                        {
                            cookie = new HttpCookie("DYH.COOKIES") { HttpOnly = true };
                            cookie.Values.Add("UserName", model.UserName);
                            cookie.Values.Add("Language", langKey);
                            cookie.Expires = DateTime.Now.AddDays(7.0);
                            Response.Cookies.Add(cookie);
                        }
                        else if (cookie["UserName"] != null)
                        {
                            if (model.UserName != cookie["UserName"])
                            {
                                Response.Cookies.Remove("DYH.COOKIES");
                                cookie["UserName"] = model.UserName;
                                cookie.Expires = DateTime.Now.AddDays(7.0);
                                Response.Cookies.Add(cookie);
                            }
                        }
                    }
                    else
                    {
                        if (cookie == null)
                        {
                            cookie = new HttpCookie("DYH.COOKIES") { HttpOnly = true };
                            cookie.Values.Add("UserName", model.UserName);
                            cookie.Values.Add("Language", langKey);
                            Response.Cookies.Add(cookie);
                        }
                        else if (cookie["UserName"] != null)
                        {
                            if (model.UserName != cookie["UserName"])
                            {
                                Response.Cookies.Remove("DYH.COOKIES");
                                cookie["UserName"] = model.UserName;
                                cookie["Language"] = langKey;
                                Response.Cookies.Add(cookie);
                            }
                        }
                    }

                    var serialize = Newtonsoft.Json.JsonConvert.SerializeObject(login);
                    FormsAuthentication.SetAuthCookie(serialize, false);

                    var returnUrl = model.ReturnUrl;
                    return Redirect(!string.IsNullOrEmpty(returnUrl) ? returnUrl : "~/Admin/Dashboard/Index");
                }

                ModelState.AddModelError("", "Bad user name or password");
                Utility.SetErrorModelState(this);
            }
            else
            {
                Utility.SetErrorModelState(this);
            }

            return Redirect("~/Admin/Users/Login");
        }

        [Authorize]
        public ActionResult Logout()
        {
            if (Utility.IsLogin)
            {
                FormsAuthentication.SignOut();
            }

            return Redirect("~/Admin/Users/Login");
        }

        private void SetFooter()
        {
            var keyValuse = _cache.Get(Constants.CACHE_KEY_BASIC, () => _basic.GetList());
            var dic = new Dictionary<string, string>();
            foreach (var item in keyValuse)
            {
                dic[item.Key] = item.Value;
            }

            ViewBag.Dictionary = dic;
        }

        [Permission(ActionCode = "Display", ModuleCode = "Users")]
        public ActionResult Index(int page = 1, string SearchBy = "", string SearchContent = "")
        {
            Utility.GetModelState(this);
            ViewBag.SearchBy = SearchBy;
            ViewBag.SearchContext = SearchContent;

            SetFooter();

            var sbFilter = new StringBuilder();
            if (SearchBy == "UserName")
            {
                sbFilter.AppendFormat("AND username LIKE '%{0}%'", SearchContent);
            }
            else if (SearchBy == "FirstName")
            {
                sbFilter.AppendFormat("AND firstname LIKE '%{0}%'", SearchContent);
            }
            else if (SearchBy == "LastName")
            {
                sbFilter.AppendFormat("AND lastname LIKE '%{0}%'", SearchContent);
            }

            var model = new PageModel
            {
                Filter = "Where 1=1 " + sbFilter.ToString(),
                PageIndex = page,
                PageSize = Utility.PageSize
            };

            var list = _user.GetList(model);
            Pagination.NewPager(this, page, (int)model.Records);
            return View(list);
        }

        [Permission(ActionCode = "Add", ModuleCode = "Users")]
        public ActionResult Create()
        {
            var roles = _cache.Get(Constants.CACHE_KEY_ROLES, () => _role.GetList());
            ViewBag.Roles = roles;
            SetFooter();

            return View();
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Permission(ActionCode = "Add", ModuleCode = "Users")]
        public ActionResult Create(UserEntry model, FormCollection collection)
        {
            if (_user.GetUserByName(model.UserName) != null)
            {
                ModelState.AddModelError("", string.Format("{0} has been used, please change one.", model.UserName));
            }

            if (_user.GetUserByEmail(model.Email) != null)
            {
                ModelState.AddModelError("", string.Format("{0} has been used, please change one.", model.Email));
            }

            if (ModelState.IsValid)
            {
                var info = Utility.CurrentLoginModel;
                model.Password = Security.PwdMd5(model.Password);
                model.CreatedBy = info.UserName;
                model.CreatedTime = DateTime.Now;

                if (Utility.Language != null)
                    model.Language = Utility.Language;

                Utility.Operate(this, Operations.Add, () =>
                {
                    int userId = _user.Add(model);
                    _cache.Remove(Constants.CACHE_KEY_USERROLE);
                    if (userId > 0)
                    {
                        var list = SetUserRoles(collection, userId);
                        _userRole.Add(list);
                    }

                    return userId;
                }, model.UserName);
            }
            else
            {
                Utility.SetErrorModelState(this);
            }

            return Redirect("~/Admin/Users/Index");
        }

        [Permission(ActionCode = "Edit", ModuleCode = "Users")]
        public ActionResult Edit(int id)
        {
            var info = _user.GetUserById(id);
            var roles = _cache.Get(Constants.CACHE_KEY_ROLES, () => _role.GetList());
            ViewBag.Roles = roles;

            var userRoles = _cache.Get(Constants.CACHE_KEY_USERROLE, () => _userRole.GetList());
            ViewBag.UserRoles = userRoles;
            SetFooter();
            return View(info);
        }

        [HttpPost, ValidateAntiForgeryToken]
        [Permission(ActionCode = "Edit", ModuleCode = "Users")]
        public ActionResult Edit(FormCollection collection)
        {
            var email = collection["Email"];
            var info = _user.GetUserById(DataCast.Get<int>(collection["UserId"]));
            var chkEmail = _user.GetUserByEmail(email);

            if (!Validator.IsEmail(email))
            {
                ModelState.AddModelError(string.Empty, "Please enter a valid email.");
            }

            if (chkEmail != null && info.Email != email && !string.IsNullOrEmpty(chkEmail.Email))
            {
                ModelState.AddModelError(string.Empty, string.Format("{0} has been used, please change one.", email));
            }
            else
            {
                if (!string.IsNullOrEmpty(info.Email))
                {
                    info.Email = email;
                }
            }

            if (ModelState.IsValid)
            {
                var password = collection["Password"];
                if (!string.IsNullOrEmpty(password))
                {
                    var md5Pwd = Security.PwdMd5(password);
                    if (info.Password != null && info.Password != md5Pwd)
                    {
                        info.Password = md5Pwd;
                    }
                }

                var first = collection["FirstName"];
                var last = collection["LastName"];

                if (!string.IsNullOrEmpty(first))
                {
                    info.FirstName = first;
                }

                if (!string.IsNullOrEmpty(last))
                {
                    info.LastName = last;
                }

                info.ChangedBy = Utility.CurrentUserName;
                info.ChangedTime = DateTime.UtcNow;

                Utility.Operate(this, Operations.Update, () =>
                {
                    _cache.Remove(Constants.CACHE_KEY_USERROLE);

                    var list = SetUserRoles(collection, info.UserId);
                    var adds = list.Where(x => x.UserRoleId == 0);
                    if (adds.Any())
                        _userRole.Add(adds);

                    var updates = list.Where(x => x.UserRoleId != 0);
                    if (updates.Any())
                        _userRole.Update(updates);

                    return _user.Update(info);
                }, info.UserName);
            }
            else
            {
                Utility.SetErrorModelState(this);
            }

            return Redirect("~/Admin/Users/Index");
        }

        [Permission(ActionCode = "Delete", ModuleCode = "Users")]
        public ActionResult Delete(string id)
        {
            var iVal = 0;
            Utility.Operate(this, Operations.Delete, () =>
            {
                iVal = _user.Delete(id);
                return iVal;
            });

            var page = Pagination.CheckPageIndexWhenDeleted(this, iVal);
            return Redirect(string.Format("~/Admin/Users/Index?page={0}", page));
        }


        private List<UserRoleEntry> SetUserRoles(FormCollection collection, int userId)
        {
            var roles = _cache.Get(Constants.CACHE_KEY_ROLES, () => _role.GetList());
            var list = new List<UserRoleEntry>();
            foreach (var item in roles)
            {
                var chkName = "Role_" + item.RoleId;
                var chkVal = collection[chkName];
                var userRoleIdKey = "UserRole_" + item.RoleId;

                string userRoleIdValue = collection[userRoleIdKey];
                var userRoleId = string.IsNullOrEmpty(userRoleIdValue) ? 0 : DataCast.Get<int>(userRoleIdValue);

                var model = new UserRoleEntry()
                {
                    RoleId = item.RoleId,
                    UserId = userId,
                    UserRoleId = userRoleId,
                    Status = chkVal == "on"
                };

                list.Add(model);
            }

            return list;

            //return (from item in roles
            //        let chkName = "Role_" + item.RoleId
            //        let chkVal = collection[chkName]
            //        let userRoleIdKey = "UserRole_" + item.RoleId
            //        let userRoleIdValue = collection[userRoleIdKey]
            //        let userRoleId = (string.IsNullOrEmpty(userRoleIdValue) ? 0 : DataCast.Get<int>(userRoleIdValue))
            //        select new UserRoleEntry()
            //        {
            //            RoleId = item.RoleId,
            //            UserId = userId,
            //            UserRoleId = userRoleId,
            //            Status = chkVal == "on"
            //        }).ToList();
        }

        [Authorize]
        public ActionResult Profile()
        {
            var id = Utility.CurrentLoginModel.UserId;
            var roles = _role.GetList();
            ViewBag.Roles = roles;
            SetFooter();
            var list = _userRole.GetList(id);
            ViewBag.UserRoles = list;
            if (Request.UrlReferrer != null)
                ViewBag.LastUrl = Request.UrlReferrer.PathAndQuery;

            var info = _user.GetUserById(id);
            return View(info);
        }


        [HttpPost,Authorize]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(FormCollection collection)
        {
            var email = collection["Email"];
            var info = _user.GetUserById(DataCast.Get<int>(collection["UserId"]));
            var chkEmail = _user.GetUserByEmail(email);

            if (!Validator.IsEmail(email))
            {
                ModelState.AddModelError(string.Empty, Localization.GetLang("Email is invaild."));
            }

            if (chkEmail != null && info.Email != email && !string.IsNullOrEmpty(chkEmail.Email))
            {
                ModelState.AddModelError(string.Empty, Localization.GetLang(string.Format("{0} already used, please select another.", email)));
            }
            else
            {
                if (!string.IsNullOrEmpty(info.Email))
                {
                    info.Email = email;
                }
            }
           
            if (ModelState.IsValid)
            {
                var password = collection["Password"];
                if (!string.IsNullOrEmpty(password))
                {
                    var md5Pwd = Security.PwdMd5(password);
                    if (info.Password != null && info.Password != md5Pwd)
                    {
                        info.Password = md5Pwd;
                    }
                }
                var first = collection["FirstName"];
                var last = collection["LastName"];

                if (!string.IsNullOrEmpty(first))
                {
                    info.FirstName = first;
                }

                if (!string.IsNullOrEmpty(last))
                {
                    info.LastName = last;
                }

                info.Language = collection["Language"];
                Utility.Language = info.Language;
            }
            else
            {
                Utility.SetErrorModelState(this);
            }

            return Redirect(Request.UrlReferrer != null ? Request.UrlReferrer.PathAndQuery : collection["LastUrl"]);
        }


        [Authorize]
        public JsonResult CheckUserName(string userName)
        {
            var flag = true;
            var info = _user.GetUserByName(userName);
            if (info != null)
            {
                flag = false;
            }

            return Json(flag, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public JsonResult CheckEmail(string email)
        {
            var flag = true;
            var info = _user.GetUserByEmail(email);
            if (info != null)
            {
                flag = false;
            }

            return Json(flag, JsonRequestBehavior.AllowGet);
        }

    }
}
