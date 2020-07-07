using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace RoutingDemo
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        // 运行主机时,执行一次，把中间件添加到管道中
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ASP.NET CORE 3.X 里成对出现 3.0新增的两个中间件Routing\Endpoints
            // webapi、mvc公用这一套路由

            // 负责匹配路由与终结点(端点)的
            // 把请求解析成路由,写进HttpContext，传给下一个中间件
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var ep = context.GetEndpoint();
                await next();
            });

            // 根据路由信息来选择一个端点
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context =>
                {
                    await context.Response.WriteAsync("Hello World!");
                });
                endpoints.MapGet("/home", async context =>
                {
                    await context.Response.WriteAsync("Hello Home!");
                });
            });

            // ASP.NET CORE 2.X 没有这两个中间件 mvc、webapi各自实现路由 3.0后将路由拆出
        }
    }
}
