using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Views.Shared.Components.SearchBar
{
    public class SearchBarViewComponent : ViewComponent
    {
        public SearchBarViewComponent()
        {
                
        }

        public IViewComponentResult Invoke(SearchPager SearchPager, bool BottomBar = false)
        {
            if (BottomBar == true)
                return View("bottomBar", SearchPager);
            else
                return View("Default", SearchPager);
        }
    }
}
