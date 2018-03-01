using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using BT.Core;
using BT.Model;
using System.Reflection;
using BT.Core.Service;
using BT.Core.Service.AccountService;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using NLog.Extensions.Logging;
using Microsoft.Extensions.Logging;
using System.Text;
using NLog.Web;
using Microsoft.AspNetCore.Authentication.Cookies;
using BT.Model.ViewModel.PermissionMiddleware;
using HouTaiWeb.Cls;
using BT.Common.Helper;
using log4net.Repository;
using log4net;
using System.IO;
using log4net.Config;
using BT.Core.Filter;

namespace HouTaiWeb
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer ApplicationContainer { get; private set; }

        //log4net日志
        public static ILoggerRepository Repository { get; set; }

        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddDbContextPool<HouTaiDbContext>(options => options.UseMySQL(Configuration.GetConnectionString("MySqlConn")));

            //配置cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                    {
                        options.LoginPath = "/Login";
                        options.LogoutPath = "/LoginOut";
                    }
                );
            
            services.AddMvc(options =>
            {
                options.Filters.Add<HttpGlobalExceptionFilter>();//增加全局异常过滤器
            });
            services.AddAutoMapper();


            //log4net
            Repository = log4net.LogManager.CreateRepository(GlobalConfig.Log4netRepositoryName);
            XmlConfigurator.Configure(Repository, new FileInfo("log4net.config"));
            //BasicConfigurator.Configure(Repository);

            //获取配置项
            services.Configure<BasicConfigureViewModel>(Configuration.GetSection("AppSettings"));
            //设置session
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(10);
                options.Cookie.HttpOnly = true;
            });


            services.AddHttpContextAccessor();
            #region autofac注入
            //autofac注入
            var builder = new ContainerBuilder();
            var assemblys = AppDomain.CurrentDomain.GetAssemblies().Where(e => e.FullName.Contains("BT.Core")).ToList();
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => t.Name.EndsWith("ServiceImpl")).AsImplementedInterfaces().InstancePerLifetimeScope().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies);
            builder.RegisterGeneric(typeof(BaseServiceImpl<>)).As(typeof(InterfaceBaseService<>)).InstancePerLifetimeScope().PropertiesAutowired();
            builder.RegisterType<UserCredential>().As<UserCredential>().InstancePerRequest().PropertiesAutowired();

            builder.Populate(services);
            this.ApplicationContainer = builder.Build();

            return new AutofacServiceProvider(this.ApplicationContainer);
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            //TODO:注意：这里会出现问题，启动项目直接失败，原因没有使用最新的nlog的版本
            loggerFactory.ConfigureNLog("nlog.config");
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
            loggerFactory.AddNLog();//添加NLog

            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseSession();
            app.UseStaticHttpContext();

            app.UseAuthentication();
            ////添加权限中间件, 一定要放在app.UseAuthentication后
            //app.UserPermission(new PermissionMiddlewareOptionViewModel
            //{
            //    LoginAction = "/Login",
            //    NoPermissionAction = "/Login",
            //    //这个集合从数据库中查出所有用户的全部权限
            //    UserPerssion = new List<UserPermissionViewModel>
            //    {
            //        new UserPermissionViewModel {  Url="/", UserName="libin"},
            //        new UserPermissionViewModel {  Url="/home/permissionadd", UserName="libin"},
            //        new UserPermissionViewModel {  Url="/", UserName="libin"},
            //        new UserPermissionViewModel {  Url="/home/contact", UserName="libin"}
            //    }
            //});

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
