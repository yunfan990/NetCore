using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BT.Core.Service;
using BT.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BT.Model;
using BT.Common.Helper;
using BT.Core.Service.AccountService;
using BT.Model.ViewModel.Account;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Extensions.Options;
using HouTaiWeb.Cls;
using Microsoft.Extensions.Logging;
using log4net;

namespace HouTaiWeb.Controllers
{
    public class LoginController : Controller
    {
        #region 函数注入
        protected IAccountService AccountService;

        protected IOptions<BasicConfigureViewModel> AppSettings;
        //log4net
        ILog Logger = log4net.LogManager.GetLogger(GlobalConfig.Log4netRepositoryName, typeof(LoginController));
        public LoginController(IAccountService _accountService, IOptions<BasicConfigureViewModel> settings)//, UserCredential userCredential ILogger<LoginController> _logger
        {
            //throw new Exception("你好吗");


            AccountService = _accountService;
            AppSettings = settings;
            //Logger = _logger;
        }

        #endregion

        [AllowAnonymous]
        public ActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="loginEntity"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> UserLogin(AccountLoginEntity loginEntity)
        {
            var result = AccountService.UserLogin(loginEntity);
            if (result.Success)
            {
                var userIdentity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                userIdentity.AddClaim(new Claim(ClaimTypes.Sid, result.Result.UserName));
                userIdentity.AddClaim(new Claim(ClaimTypes.Name, result.Result.UserName));
                userIdentity.AddClaim(new Claim(ClaimTypes.Role, result.Result.UserName));
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(userIdentity));

                //写入session
                CookieCredential cookieCredential = new CookieCredential
                {
                    UserName = result.Result.UserName,
                    Password = result.Result.Password
                };
                UserCredential.SetSession(cookieCredential);

                //if (returnUrl == null)
                //    returnUrl = TempData["returnUrl"]?.ToString();
                //登录成功-加载权限

                Logger.Info(string.Format("用户：{0}登录成功", result.Result.UserName));

            }
            return Json(new ServiceResult<string> { Success = result.Success, ErrorMessage = result.ErrorMessage });
        }


        /// <summary>
        /// 登出
        /// </summary>
        /// <returns></returns>
        [AllowAnonymous]
        public async Task<IActionResult> LoginOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public ActionResult UserRegister()
        {
            return View();
        }
        /// <summary>
        /// 用户注册
        /// </summary>
        /// <param name="accountRegisterEntity"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        public ActionResult UserRegister(AccountRegisterEntity accountRegisterEntity)
        {
            var result = AccountService.UserRegister(accountRegisterEntity);
            return Json(new ServiceResult<string> { Success = result.Success, ErrorMessage = result.ErrorMessage });
        }
    }
}