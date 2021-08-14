using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Providers
{
    public interface IMailHelper
    {
       Task SendEmailAsync(string to, string subject, string content);
    }
}
