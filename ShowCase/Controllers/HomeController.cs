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

namespace ShowCase.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _dbContext;

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
                //_dbContext.ChangeTracker.AutoDetectChangesEnabled = false;

                var stopWatch = Stopwatch.StartNew();

                products = _dbContext.Products
                    .Where(p => p.Name.Contains(SearchText))
                    .Include(u => u.ApplicationUser)
                    //.OrderByDescending(p => p.CreatedAt)
                    .ToList();


                _logger.LogInformation($"Search and Fetch specific records in Records in, ${stopWatch.Elapsed}");

            }
            else
            {
                _dbContext.ChangeTracker.AutoDetectChangesEnabled = false;

                var stopWatch1 = Stopwatch.StartNew();

                products = _dbContext.Products
                    .Include(u => u.ApplicationUser)
                    //.OrderByDescending(p => p.CreatedAt)
                    .Take(10000)
                    .ToList();


                stopWatch1.Stop();
                _logger.LogInformation($"Fethcing All Records in, {stopWatch1.Elapsed}");
                _dbContext.ChangeTracker.AutoDetectChangesEnabled = true;

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
