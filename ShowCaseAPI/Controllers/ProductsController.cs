using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Repository.Contracts;
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
        private readonly IProductRepository _productRepository;
        private readonly AppDbContext _appDbContext;

        public ProductsController(ILogger<ProductsController> logger,
            IProductRepository productRepository, 
            AppDbContext appDbContext)
        {
            _logger = logger;
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

            //var productList = await _appDbContext.Products
            //    .OrderByDescending(p => p.CreatedAt)
            //    .Select(p => new { p.Id, p.Name, p.Description, p.Price, p.ApplicationUser.UserName })
            //    .Take(50)
            //    .ToListAsync();
            stopWatch.Stop();
            _logger.LogInformation($"1- Fethcing All Records using (Include) in, {stopWatch.Elapsed}");
            
            return Ok(productList);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductsController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
