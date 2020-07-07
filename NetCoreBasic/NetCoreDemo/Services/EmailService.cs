using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreDemo.Services
{
    public class EmailService : IMessageServices
    {
        public string Send()
        {
            return "EMail";
        }
    }
}
