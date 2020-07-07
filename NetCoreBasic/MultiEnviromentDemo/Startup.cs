using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

/// <summary>
/// 多环境配置
/// </summary>
namespace MultiEnviromentDemo
{
    // 查看当前环境:launchSetting.json - ASPNETCORE_ENVIRONMENT属性

    // 类级别约定
    // Demo环境下会执行此类中方法
    // 需要修改Program类中启动类
    public class StartupDemo
    {
        public void ConfigureServices(IServiceCollection services)
        {
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
        }
    }

    // 没找到才会执行默认的Startup类中方法
    public class Startup
    {
        // 方法级别约定
        // Demo环境下会优先执行此方法 而不是ConfigureServices
        public void ConfigureDemoServices(IServiceCollection services)
        {

        }

        // 没有找到对应环境方法才会执行此方法 
        // Configure方法也是如此
        public void ConfigureServices(IServiceCollection services)
        {

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            // 默认环境
            env.IsStaging();//预览
            env.IsDevelopment();//开发
            env.IsProduction();//生产
            // 其他环境
            env.IsEnvironment("Demo");
        }
    }
}
