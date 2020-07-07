using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using ReadConfigDemo.SettingModel;

namespace ReadConfigDemo
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //注册配置选项的服务
            services.Configure<AppSetting>(_configuration);

            //自定义配置文件读取
            var config = new ConfigurationBuilder().AddJsonFile("jsonConfig.json").Build();
            //var name = config["Name"];
            services.Configure<JsonConfig>(config);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IOptions<AppSetting> appOptions, IOptions<JsonConfig> jsonOptions)
        {
            app.Run(async context =>
            {
                //通用读取方法
                var conStr = _configuration["ConnectionString"];
                var title = _configuration["WebSetting:Title"];

                //绑定配置模型对象
                var appSetting = new AppSetting();
                _configuration.Bind(appSetting);
                var maxCon = appSetting.WebSetting.Behavior.MaxConnection;
                //部分绑定
                var webSeting = new WebSetting();
                _configuration.GetSection("WebSetting").Bind(webSeting);

                //注册配置选项服务
                var a = appOptions.Value.WebSetting.Behavior.IsCheckIp;
                var b = jsonOptions.Value.Name;

                context.Response.WriteAsync(maxCon.ToString() + webSeting.WebName + a + b);
            });
        }
    }
}
