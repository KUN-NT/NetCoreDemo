using Microsoft.Extensions.DependencyInjection;
using System;

namespace NetCoreDemo.Services
{
    public static class MessageServiceExtension
    {
        public static void AddMessage(this IServiceCollection services,Action<MessageServiceBuilder> configure)
        {
            var builder = new MessageServiceBuilder(services);
            configure(builder);
        }
    }
}
