using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Utilities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

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
        
        public IActionResult Index(int page = 1)
        {
            List<Product> products = _dbContext.Products.Include(u => u.ApplicationUser).ToList();
            
            if (page < 0)
                page = 1;

            int pageSize = 25;
            int countRecords = products.Count;
            var pager = new Pager(countRecords, page, pageSize);
            int skipRecords = (page - 1) * pageSize;

            var modelList = _dbContext.Products.Include(u => u.ApplicationUser)
                                                .Skip(skipRecords)
                                                .Take(pager.PageSize);

            ViewData["TotalPages"] = pager.TotalPages;
            ViewData["Products"] = products.Count;
            ViewData["ModelList"] = modelList.Count();


            ViewBag.Pager = pager;

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
