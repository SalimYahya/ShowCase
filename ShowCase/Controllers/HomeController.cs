using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using ShowCase.Views.Shared.Components.SearchBar;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Localization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace ShowCase.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;
        private readonly IHtmlLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger, AppDbContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }


        private List<SelectListItem> GetPageSizes(int selectedPagesSize = 10)
        {
            var pagesSizes = new List<SelectListItem>();

            if (selectedPagesSize == 5)
                pagesSizes.Add(new SelectListItem("5", "5", true));
            else
                pagesSizes.Add(new SelectListItem("5", "5"));

            for (int lp = 10; lp <= 100; lp += 10)
            {
                if (lp == selectedPagesSize)
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString(), true));
                else
                    pagesSizes.Add(new SelectListItem(lp.ToString(), lp.ToString()));
            }

            return pagesSizes;
        }
        public IActionResult Index(string SearchText = "", int page = 1, int pageSize = 30)
        {
            _logger.LogInformation($"Total Products available {_dbContext.Products.Count()}");

            List<Product> products;

            if (SearchText != "" && SearchText != null)
            {
               _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                var stopWatch = Stopwatch.StartNew();

                products = _dbContext.Products
                    .Where(p => p.Name.Contains(SearchText))
                    .Include(u => u.ApplicationUser)
                    .OrderByDescending(p => p.CreatedAt)
                    .ToList();

                stopWatch.Stop();
                _logger.LogInformation($"Search and Fetch specific records in Records in, ${stopWatch.Elapsed}");
                //_dbContext.ChangeTracker.AutoDetectChangesEnabled = true;

            }
            else
            {
                //_dbContext.ChangeTracker.AutoDetectChangesEnabled = false;
                var stopWatchList = Stopwatch.StartNew();

                products = _dbContext.Products
                    .Include(u => u.ApplicationUser)
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(1000)
                    .ToList();

                stopWatchList.Stop();
                _logger.LogInformation($"1- Fethcing All Records using (Include) in, {stopWatchList.Elapsed}");
                //_dbContext.ChangeTracker.AutoDetectChangesEnabled = true;


                // Eager Loading using 'SELECT',
                // don’t need an 'Include' call anymore since Entity Framework “understands” from the Select call that we need a field
             
                /*
                 * var stopWatchVar = Stopwatch.StartNew();
                 * var varProducts = _dbContext.Products
                 *      .OrderByDescending(p => p.CreatedAt)
                 *       .Select(p => new { p.Id, p.Name, p.Description, p.Price, p.ApplicationUser.UserName })
                 *       .ToList();

                 * stopWatchVar.Stop();
                 *_logger.LogInformation($"2- Fethcing All Records using (Select)  in, {stopWatchVar.Elapsed}");
                 */
                
            }


            //int pageSize = 30;

            if (page < 1)
                page = 1;

            int countRecords = products.Count;
            int skipRecords = (page - 1) * pageSize;

            var modelList = products.Skip(skipRecords).Take(pageSize);

            SearchPager searchPager = new SearchPager(countRecords, page, pageSize)
            {
                Action = "Index",
                Controller = "Home",
                SearchText = SearchText
            };

            ViewBag.SearchPager = searchPager;
            ViewBag.PageSizes = GetPageSizes(pageSize);
            //_logger.LogInformation($"pageSize: {pageSize}");

            return View(modelList);
        }
        
        [HttpPost]
        public IActionResult CultureManagement(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTimeOffset.Now.AddDays(30)}
                );

            return LocalRedirect(returnUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
