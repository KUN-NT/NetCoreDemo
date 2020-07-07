using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NetCoreDemo
{
    public class Programho
    {
        public static void Main(string[] args)
        {
            //主机启动有几种方式，网上查看
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //创建默认主机生成器
            Host.CreateDefaultBuilder(args)
                //创建默认web主机
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //配置web主机
                    /*
                     - 组件配置 ConfigureXXXX
                     - 主机配置项 UseXXX
                        - 环境变量(launchSettings)<硬编码<应用配置(appsettings)<命令行参数
                     */
                    webBuilder.UseStartup<Startup>();
                    //硬编码
                    webBuilder.UseUrls("http://localhost:8000");
                });
    }
}
