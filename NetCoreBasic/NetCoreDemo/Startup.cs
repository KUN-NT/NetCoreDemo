using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NetCoreDemo.Middleware;
using NetCoreDemo.Services;

namespace NetCoreDemo
{
    public class Startup
    {
        // 注册服务
        public void ConfigureServices(IServiceCollection services)
        {
            // 服务容器 -> IOC容器

            #region 内置服务
            // 添加对控制器和API相关功能的支持 但不支持视图和页面 WEBAPI
            //services.AddControllers();

            //添加对控制器、API、视图相关功能的支持
            //ASP.NET CORE 3.X MVC模板默认使用
            //services.AddControllersWithViews();
            //添加对Razor Pages和最小控制器的支持
            //services.AddRazorPages();

            //ASP.NET CORE 2.X MVC使用
            //services.AddMvc();

            //跨域支持
            //services.AddCors() 
            #endregion

            #region 第三方服务
            //例如:EF Core 日志框架 Swagger (需要先引用第三方组件)

            #endregion

            #region 自定义服务
            /*  
                服务生存周期:
                - 瞬时    每次从服务容器里进行请求实例时 都会创建一个新的实例
                - 作用域  线程单例 在同一个线程(请求)里 只实例化一次
                - 单例    全局单例 每一次都是使用相同的实例

                services.AddTransient()
                services.AddScoped()
                services.AddSingleton()
             */
            //服务相同注册多个 只有后面的会生效
            //services.AddSingleton<IMessageServices,EmailService>();
            //services.AddSingleton<IMessageServices,SmsService>();
            //services.AddMessage(p => p.UseEmail());
            services.AddMessage(Test);
            #endregion
        }
        public void Test(MessageServiceBuilder builder)
        {
            builder.UseSms();
        }

        // 配置中间件
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IMessageServices messageServices)
        {
            //Use有Next
            app.Use(async (content, next) =>
            {
                await content.Response.WriteAsync("Middleware Begin\r\n");
                await next();
                await content.Response.WriteAsync("Middleware End\r\n");
            });

            //通用添加中间件的方法
            //app.UseMiddleware<TestMiddleware>();
            //封装好的
            app.UseTest();

            //run方法 是没有next 终端中间件
            // 专门用来短路请求管道 是放在最后面的
            app.Run(async content =>
            {
                await content.Response.WriteAsync("Hello Run\r\n");
            });
            //if (env.IsDevelopment())
            //{
            //    开发人员异常页面中间件
            //    app.UseDeveloperExceptionPage();
            //}

            //终结点路由中间件
            //ASP.NET CORE 2.X里 是没有这个东西
            //ASP.NET CORE 3.X里 拆出来
            //匹配路由信息
            //app.UseRouting();

            //终结点中间件(配置路由和中间件之间关系)
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync(messageServices.Send());
            //    });
            //});
        }
    }
}
