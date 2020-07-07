using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Services
{
    public class SmsService : IMessageServices
    {
        public string Send()
        {
            return "Sms";
        }
    }
}
