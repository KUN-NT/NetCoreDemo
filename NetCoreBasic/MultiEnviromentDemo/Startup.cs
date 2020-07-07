using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
/// �໷������
/// </summary>
namespace MultiEnviromentDemo
{
    // �鿴��ǰ����:launchSetting.json - ASPNETCORE_ENVIRONMENT����

    // �༶��Լ��
    // Demo�����»�ִ�д����з���
    // ��Ҫ�޸�Program����������
    public class StartupDemo
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }

    // û�ҵ��Ż�ִ��Ĭ�ϵ�Startup���з���
    public class Startup
    {
        // ��������Լ��
        // Demo�����»�����ִ�д˷��� ������ConfigureServices
        public void ConfigureDemoServices(IServiceCollection services)
        {

        }

        // û���ҵ���Ӧ���������Ż�ִ�д˷��� 
        // Configure����Ҳ�����
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            // Ĭ�ϻ���
            env.IsStaging();//Ԥ��
            env.IsDevelopment();//����
            env.IsProduction();//����
            // ��������
            env.IsEnvironment("Demo");
        }
    }
}
