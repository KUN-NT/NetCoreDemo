using Microsoft.Extensions.DependencyInjection;

namespace NetCoreDemo.Services
{
    public class MessageServiceBuilder
    {
        //服务集合
        public IServiceCollection ServiceCollection { get; set; }

        public MessageServiceBuilder(IServiceCollection services)
        {
            ServiceCollection = services;
        }

        public void UseEmail()
        {
            ServiceCollection.AddSingleton<IMessageServices, EmailService>();
        }
        public void UseSms()
        {
            ServiceCollection.AddSingleton<IMessageServices, SmsService>();
        }
    }
}
