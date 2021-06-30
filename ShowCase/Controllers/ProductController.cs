using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Repository.Contracts;
using ShowCase.Security;
using ShowCase.ViewModel.Product;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        private readonly IProductRepository _productRepository;
        public ProductController(ILogger<ProductController> logger, UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService, IProductRepository productRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _authorizationService = authorizationService;
            _productRepository = productRepository;
        }


        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            _logger.LogInformation($"UserId: {userId}");
            _logger.LogInformation($"User: {User}");

            if (User.IsInRole("SuperAdmin"))
            {
                IEnumerable<Product> adminModelList = await _productRepository.GetAllProductsOrderByDescendingAsync();
                return View(adminModelList);
            }

            IEnumerable<Product> sellerModelList = await _productRepository.GetAllProductsWithOwnersOrderByDescendingAsync(userId);

            return View(sellerModelList);
        }

        [HttpGet]
        [Authorize(Roles = "Seller")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Create(CreateViewModel model)
        {   
            if (ModelState.IsValid)
            {   
                // Get Current User Id
                string userId = _userManager.GetUserId(HttpContext.User);

                Product product = new Product {
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    ApplicationUserId = userId
                };

                var authorizationResult = await _authorizationService
                    .AuthorizeAsync(User, product, CRUD.Create);

                if (authorizationResult.Succeeded)
                {
                    await _productRepository.AddAsync(product);
                    await _productRepository.SaveAsync();
                    
                    return RedirectToAction("Index", "Product");
                }
                else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
                else { return new ChallengeResult(); }
            }

            return View(model);
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Details(int id)
        {
            var product = await _productRepository.GetProductWithOwner(id);

            if (product != null) { return View(product); }

            return NotFound();
        }

        [HttpGet]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Edit(int id)
        {
            var product = await _productRepository.GetProductWithOwner(id);

            if (product == null) { return new NotFoundResult(); }

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, product, CRUD.Update);

            if (authorizationResult.Succeeded) {

                EditProductViewModel model = new EditProductViewModel {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                return View(model);
            }
            else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
            else { return new ChallengeResult(); }
        }

        [HttpPost]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Edit(EditProductViewModel model)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            if (ModelState.IsValid)
            {
                Product product = new Product
                {
                    Id = model.Id,
                    Name = model.Name,
                    Description = model.Description,
                    Price = model.Price,
                    ApplicationUser = user
                };


                var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, product, CRUD.Update);

                if (authorizationResult.Succeeded) 
                {
                    _productRepository.Update(product);
                    await _productRepository.SaveAsync();

                    _logger.LogInformation($"Product: {product.ToString()}, has been Edited.");
                    return RedirectToAction("Details", new { id = product.Id });
                }
                else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
                else { return new ChallengeResult(); }
            }

            return View(model);
        }

        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Supervisor, Seller")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetProductWithOwner(id);

            if (product == null) { return new NotFoundResult(); }

           
            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, product, CRUD.Delete);
            if (authorizationResult.Succeeded)
            {
                DeleteProductViewModel model = new DeleteProductViewModel
                {
                    Id = product.Id,
                    Name = product.Name,
                    Description = product.Description,
                    Price = product.Price
                };

                return View(model);
            }
            else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
            else { return new ChallengeResult(); }

        }

        [HttpPost]
        [Authorize(Roles = "SuperAdmin, Supervisor, Seller")]
        public async Task<IActionResult> Delete(DeleteProductViewModel model)
        {
            var product = await _productRepository.GetProductWithOwner(model.Id);

            if (product == null) { return new NotFoundResult(); }

            var authorizationResult = await _authorizationService
                .AuthorizeAsync(User, product, CRUD.Delete);

            if (authorizationResult.Succeeded)
            {
                _productRepository.Remove(product);
                await _productRepository.SaveAsync();

                _logger.LogInformation($"Product: {product.ToString()}, has been Deleted.");
                return RedirectToAction("Index","Product"); 
            }
            else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
            else { return new ChallengeResult(); }
        }

        [HttpGet]
        public async Task<IActionResult> CreateMagicProducts()
        {
            /*
            var product = await _dbContext.Products
                .Include(u => u.ApplicationUser)
                .OrderBy(p => p.CreatedAt)
                .LastOrDefaultAsync();
            

            _logger.LogInformation($"Item.Name - {product.Name}");
            _logger.LogInformation($"Username - {product.ApplicationUser.UserName}");


            var authorizationResult = await _authorizationService.AuthorizeAsync(User, product, CRUD.Create);

            if (authorizationResult.Succeeded)
            {
                _logger.LogInformation($"100k records added !!!");
                _logger.LogInformation($"User: {User.Identity.Name}");
            }
            else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
            else { return new ChallengeResult(); }
            */


            return RedirectToAction("Index", "Home");


            /*Random random = new Random();
            *    int t = 47;
            *    List<Product> products = new List<Product>();
            *
            *    var stopWatch = Stopwatch.StartNew();
            *
            *    for (int i = 1; i <= 100000; i++)
            *    {
            *        t++;
            *        products.Add(new Product
            *        {
            *            Name = "Magic Product " + Convert.ToString(t),
            *             Description = "Lorem Ipsum is simply dummy text",
            *            Price = Math.Round(ModelBuilderExtension.RandomPriceGenerator(random, 50, 1000), 2, MidpointRounding.AwayFromZero),
            *            ApplicationUserId = product.ApplicationUserId
            *        }); ;
            *    }
            *
            *   await _dbContext.AddRangeAsync(products);
            *   await _dbContext.SaveChangesAsync();
            *
            *  stopWatch.Stop();
            *   _logger.LogInformation($"100k records added in, {stopWatch.Elapsed}");
            */
        }
    }
}
