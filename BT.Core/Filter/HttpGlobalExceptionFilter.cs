﻿using log4net;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace BT.Core.Filter
{
    #region 全局异常类log4net--不可以放在单独类中
    public class HttpGlobalExceptionFilter : IExceptionFilter
    {
        private ILog log = LogManager.GetLogger(GlobalConfig.Log4netRepositoryName, typeof(HttpGlobalExceptionFilter));

        public void OnException(ExceptionContext context)
        {
            log.Error(context.Exception);
        }
    }
    #endregion

    #region 全局异常类 Nlog-可放在单独的类库中
    ///// <summary>
    ///// 全局异常过滤器
    ///// </summary>
    //public class HttpGlobalExceptionFilter : IExceptionFilter
    //{
    //    readonly ILoggerFactory _loggerFactory;
    //    readonly IHostingEnvironment _env;

    //    public HttpGlobalExceptionFilter(ILoggerFactory loggerFactory, IHostingEnvironment env)
    //    {
    //        _loggerFactory = loggerFactory;
    //        _env = env;
    //    }

    //    public void OnException(ExceptionContext context)
    //    {
    //        var logger = _loggerFactory.CreateLogger(context.Exception.TargetSite.ReflectedType);

    //        logger.LogError(new EventId(context.Exception.HResult),
    //        context.Exception,
    //        context.Exception.Message);

    //        var json = new ErrorResponse("未知错误,请重试");

    //        if (_env.IsDevelopment()) json.DeveloperMessage = context.Exception;

    //        context.Result = new ApplicationErrorResult(json);
    //        context.HttpContext.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

    //        context.ExceptionHandled = true;
    //    }
    //}
    //public class ApplicationErrorResult : ObjectResult
    //{
    //    public ApplicationErrorResult(object value) : base(value)
    //    {
    //        StatusCode = (int)HttpStatusCode.InternalServerError;
    //    }
    //}

    //public class ErrorResponse
    //{
    //    public ErrorResponse(string msg)
    //    {
    //        Message = msg;
    //    }
    //    public string Message { get; set; }
    //    public object DeveloperMessage { get; set; }
    //}
    #endregion
}
