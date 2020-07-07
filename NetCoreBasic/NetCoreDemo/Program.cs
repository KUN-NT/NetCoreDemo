using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace NetCoreDemo
{
    public class Programho
    {
        public static void Main(string[] args)
        {
            //���������м��ַ�ʽ�����ϲ鿴
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            //����Ĭ������������
            Host.CreateDefaultBuilder(args)
                //����Ĭ��web����
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    //����web����
                    /*
                     - ������� ConfigureXXXX
                     - ���������� UseXXX
                        - ��������(launchSettings)<Ӳ����<Ӧ������(appsettings)<�����в���
                     */
                    webBuilder.UseStartup<Startup>();
                    //Ӳ����
                    webBuilder.UseUrls("http://localhost:8000");
                });
    }
}
