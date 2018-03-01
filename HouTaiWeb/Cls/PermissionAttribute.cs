using BT.Common.Helper;
using BT.Model;
using HouTaiWeb.Cls;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HouTaiWeb
{
    public class PermissionAttribute : ActionFilterAttribute
    {
        private readonly string _name;
        private readonly string _value;
        public PermissionAttribute(string name, string value)
        {
            _name = name;
            _value = value;
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            //context.HttpContext.Response.Headers.Add(_name, new string[] { _value });
            //判断权限
            string SessionName = ConfigurationService.GetConfigValue("SessionName");
            var s= HttpContext.Current.Session.Get<CookieCredential>(SessionName);
            
            base.OnActionExecuting(context);
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            base.OnActionExecuted(context);
        }
    }
}
