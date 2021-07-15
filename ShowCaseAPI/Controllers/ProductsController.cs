using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Repository.Contracts;
using ShowCase.Security;
using ShowCaseAPI.DTO.Product;
using ShowCaseAPI.Extensions;
using ShowCaseAPI.Response;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly IProductRepository _productRepository;
        private readonly AppDbContext _appDbContext;

        public ProductsController(ILogger<ProductsController> logger,
            IAuthorizationService authorizationService,
            IProductRepository productRepository, 
            AppDbContext appDbContext)
        {
            _logger = logger;
            _authorizationService = authorizationService;
            _productRepository = productRepository;
            _appDbContext = appDbContext;
        }


        // GET: api/<ProductsController>
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Get()
        {
            var stopWatch = Stopwatch.StartNew();
            var productList = await _appDbContext.Products
                .Include(p => p.ApplicationUser)
                .Select(p => new { p.Id, p.Name, p.Description, p.Price, p.ApplicationUser.UserName })
                .Take(50)
                .ToListAsync();

            stopWatch.Stop();
            _logger.LogInformation($"1- Fethcing All Records using (Include) in, {stopWatch.Elapsed}");
            
            return Ok(productList);
        }
        
        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        [AllowAnonymous]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _appDbContext.Products
                .Include(p => p.ApplicationUser)
                .Where(p => p.Id == id)
                .Select(p => new { p.Id, p.Name, p.Description, p.Price, p.ApplicationUser.UserName })
                .FirstOrDefaultAsync();

            if (product == null) 
            {
                return BadRequest(new OperationResponse() 
                {
                    Success = false,
                    Errors = new List<string>() { $"Product with id: {id}, Not Found !!!" }
                });   
            }

            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Post([FromBody] CreateProduct createProduct)
        {
            OperationResponse operationResponse = new OperationResponse();
            operationResponse.Success = false;

            if (ModelState.IsValid) 
            {
                string userId = HttpContext.GetUserId();
                Product product = new Product {
                    Name = createProduct.Name,
                    Description = createProduct.Description,
                    Price = createProduct.Price,
                    ApplicationUserId = userId,
                };

                var authorizationResult = await _authorizationService
                    .AuthorizeAsync(User, product, CRUD.Create);

                if (authorizationResult.Succeeded)
                {
                    await _appDbContext.Products.AddAsync(product);
                    await _appDbContext.SaveChangesAsync();
                    return Ok(product);
                }
                else if (User.Identity.IsAuthenticated) {
                    operationResponse.Errors = new List<string>() { "Forbidden" };
                    return BadRequest(operationResponse);
                }
                else{
                    operationResponse.Errors = new List<string>() { "You're not logged in !!!" };
                    return BadRequest(operationResponse);
                }

            }

            operationResponse.Errors = new List<string>();
            foreach (var error in ModelState)
            {
                operationResponse.Errors.Add(error.Value.Errors.ToString());
            }

            return BadRequest(operationResponse);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [Authorize(Roles = "Seller")]
        public async Task<IActionResult> Put(int id, [FromBody] UpdateProduct updateProduct)
        {
            OperationResponse operationResponse = new OperationResponse();
            operationResponse.Success = false;

            if (ModelState.IsValid) 
            {
                Product product = await _appDbContext.Products
                                        .Include(p => p.ApplicationUser)
                                        .Where(p => p.Id == id)
                                        .FirstOrDefaultAsync();

                if (product != null) {

                    var authorizationResult = await _authorizationService.AuthorizeAsync(User, product, CRUD.Update);
                    if (authorizationResult.Succeeded) 
                    {
                        product.Name = updateProduct.Name;
                        product.Description = updateProduct.Description;
                        product.Price = updateProduct.Price;

                        //_appDbContext.Products.Attach(product);
                        return Ok(product); 
                    }
                    else if (User.Identity.IsAuthenticated)
                    {
                        operationResponse.Errors = new List<string>() { "Forbidden" };
                        return BadRequest(operationResponse);
                    }
                    else
                    {
                        operationResponse.Errors = new List<string>() { "You're not logged in !!!" };
                        return BadRequest(operationResponse);
                    }
                }

            }

            operationResponse.Errors = new List<string>();
            foreach (var error in ModelState) 
            {
                operationResponse.Errors.Add(error.Value.Errors.ToString());
            }

            return BadRequest(operationResponse);
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            OperationResponse operationResponse = new OperationResponse();
            operationResponse.Success = false;

            Product product = await _appDbContext.Products
                                    .Include(p => p.ApplicationUser)
                                    .Where(p => p.Id == id)
                                    .FirstOrDefaultAsync();

            if (product != null) 
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, product, CRUD.Delete);
                if (authorizationResult.Succeeded) 
                {
                    _appDbContext.Products.Remove(product);
                    await _appDbContext.SaveChangesAsync();

                    return Ok("Product Deleted"); 
                }
                else if (User.Identity.IsAuthenticated)
                {
                    operationResponse.Errors = new List<string>() { "Forbidden" };
                    return BadRequest(operationResponse);
                }
                else
                {
                    operationResponse.Errors = new List<string>() { "You're not logged in !!!" };
                    return BadRequest(operationResponse);
                }
            }

            operationResponse.Errors = new List<string>() { "Product Not Found" };

            return BadRequest(operationResponse);
        }



        /*
         *  if (createProduct.Name == null) { ModelState.AddModelError("createProduct.Name ", "Required"); }
            if (createProduct.Name.Length < 50) { ModelState.AddModelError("createProduct.Name ", "Must be Greater than 50"); }

            if (createProduct.Description == null) { ModelState.AddModelError("createProduct.Description", "Required"); }
            if (createProduct.Description.Length < 150) { ModelState.AddModelError("createProduct.Description", "Must be Greater than 150"); }

            if (createProduct.Price.Equals("")) { ModelState.AddModelError("createProduct.Price", "Required"); }
            if (createProduct.Price <= 50) { ModelState.AddModelError("createProduct.Price", "Must be Greater than 0"); }


            return BadRequest(new OperationResponse()
            {
                Success = false,
                Errors = ModelState.Values.SelectMany(e => e.Errors.Select(er => er.ErrorMessage)).ToList()
            });
         */

        //var productList = await _appDbContext.Products
        //    .OrderByDescending(p => p.CreatedAt)
        //    .Select(p => new { p.Id, p.Name, p.Description, p.Price, p.ApplicationUser.UserName })
        //    .Take(50)
        //    .ToListAsync();
    }
}
