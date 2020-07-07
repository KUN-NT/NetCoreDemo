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
        // ע�����
        public void ConfigureServices(IServiceCollection services)
        {
            // �������� -> IOC����

            #region ���÷���
            // ��ӶԿ�������API��ع��ܵ�֧�� ����֧����ͼ��ҳ�� WEBAPI
            //services.AddControllers();

            //��ӶԿ�������API����ͼ��ع��ܵ�֧��
            //ASP.NET CORE 3.X MVCģ��Ĭ��ʹ��
            //services.AddControllersWithViews();
            //��Ӷ�Razor Pages����С��������֧��
            //services.AddRazorPages();

            //ASP.NET CORE 2.X MVCʹ��
            //services.AddMvc();

            //����֧��
            //services.AddCors() 
            #endregion

            #region ����������
            //����:EF Core ��־��� Swagger (��Ҫ�����õ��������)

            #endregion

            #region �Զ������
            /*  
                ������������:
                - ˲ʱ    ÿ�δӷ����������������ʵ��ʱ ���ᴴ��һ���µ�ʵ��
                - ������  �̵߳��� ��ͬһ���߳�(����)�� ֻʵ����һ��
                - ����    ȫ�ֵ��� ÿһ�ζ���ʹ����ͬ��ʵ��

                services.AddTransient()
                services.AddScoped()
                services.AddSingleton()
             */
            //������ͬע���� ֻ�к���Ļ���Ч
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

        // �����м��
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env,IMessageServices messageServices)
        {
            //Use��Next
            app.Use(async (content, next) =>
            {
                await content.Response.WriteAsync("Middleware Begin\r\n");
                await next();
                await content.Response.WriteAsync("Middleware End\r\n");
            });

            //ͨ������м���ķ���
            //app.UseMiddleware<TestMiddleware>();
            //��װ�õ�
            app.UseTest();

            //run���� ��û��next �ն��м��
            // ר��������·����ܵ� �Ƿ���������
            app.Run(async content =>
            {
                await content.Response.WriteAsync("Hello Run\r\n");
            });
            //if (env.IsDevelopment())
            //{
            //    ������Ա�쳣ҳ���м��
            //    app.UseDeveloperExceptionPage();
            //}

            //�ս��·���м��
            //ASP.NET CORE 2.X�� ��û���������
            //ASP.NET CORE 3.X�� �����
            //ƥ��·����Ϣ
            //app.UseRouting();

            //�ս���м��(����·�ɺ��м��֮���ϵ)
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
