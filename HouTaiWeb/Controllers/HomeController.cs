using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BT.Model;
using BT.Core;
using Microsoft.EntityFrameworkCore;
using BT.Core.Service.AccountService;
using BT.Model.ViewModel.Account;
using Microsoft.Extensions.Logging;

namespace HouTaiWeb.Controllers
{
    public class HomeController : BaseController
    {
        #region 函数注入
        private readonly IAccountService AccountService;

        private readonly HouTaiDbContext dbContext;

        private readonly ILogger<HomeController> Logger;


        public HomeController(HouTaiDbContext _dataContext, IAccountService _accountService, ILogger<HomeController> _logger)
        {
            dbContext = _dataContext;
            AccountService = _accountService;
            Logger = _logger;
        } 
        #endregion

        [Permission("admin", "view")]
        public IActionResult Index()
        {
            Logger.LogInformation("111111");
            var account = new AccountEntity
            {
                UserName = "admin",
                Password = "123456"
            };
            ViewBag.startTime = DateTime.Now.ToString();
            ViewBag.endTime = DateTime.Now.ToString();
            ViewBag.count = 1;
            return View();
        }


        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
            //return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
