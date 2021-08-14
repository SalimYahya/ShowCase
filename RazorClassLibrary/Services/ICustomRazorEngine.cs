using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorClassLibrary.Services
{
    public interface ICustomRazorEngine
    {
        string RazorViewToHtmlAsync<TModel>(string viewName, TModel model);
    }
}
