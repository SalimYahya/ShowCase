using Microsoft.AspNetCore.Mvc;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    public class ProductController : Controller
    {
        private readonly AppDbContext _dbContext;

        public ProductController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> modelList = _dbContext.Products;

            return View(modelList);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateViewModel model)
        {
            if (ModelState.IsValid)
            {
                Product product = new Product {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price
                };

                _dbContext.Products.Add(product);
                _dbContext.SaveChanges();


                return RedirectToAction("Details", new { id = product.Id});
            }

            return View(model);
        }


        [HttpGet]
        public IActionResult Details(int? id)
        {
            var model = _dbContext.Products.Find(id);

            if ( model != null)
            {
                return View(model);
            }

            return NotFound();
        }
    }
}
