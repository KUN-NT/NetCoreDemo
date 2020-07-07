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

        // ��������ʱ,ִ��һ�Σ����м����ӵ��ܵ���
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // ASP.NET CORE 3.X ��ɶԳ��� 3.0�����������м��Routing\Endpoints
            // webapi��mvc������һ��·��

            // ����ƥ��·�����ս��(�˵�)��
            // �����������·��,д��HttpContext��������һ���м��
            app.UseRouting();

            app.Use(async (context, next) =>
            {
                var ep = context.GetEndpoint();
                await next();
            });

            // ����·����Ϣ��ѡ��һ���˵�
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

            // ASP.NET CORE 2.X û���������м�� mvc��webapi����ʵ��·�� 3.0��·�ɲ��
        }
    }
}
