using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Providers
{
    public interface ITemplateHelper
    {
        Task<string> GetTemplateHtmlAsStringAsync<T>(string viewName, T model);
    }
}
