using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
using ShowCaseAPI.DTO;
using ShowCaseAPI.DTO.Product;
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
    [AllowAnonymous]
    public class MainController : ControllerBase
    {
        private readonly ILogger<MainController> _logger;
        private readonly AppDbContext _appDbContext;

        public MainController(ILogger<MainController> logger, AppDbContext appDbContext)
        {
            _logger = logger;
            _appDbContext = appDbContext;
        }


        // Get Everything: Brands with thier products
        // GET: api/<MainController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var stopWatch = Stopwatch.StartNew();
            var mainProducts = await _appDbContext.Brands
                .Include(p => p.Products)
                .Select(b => new BrandDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Products = b.Products.Select(p => new ProductDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Username = p.ApplicationUser.UserName,
                        CreatedAt = p.CreatedAt
                    }).OrderByDescending(p => p.CreatedAt)
                     .Take(5)
                     .ToList()
                }).ToListAsync();

            stopWatch.Stop();
            _logger.LogInformation($"Fethcing All Brands with 5 Products each using (Include) in, {stopWatch.Elapsed}");

            //"2021-06-14T17:04:00.6817506"
            DateTime date1 = Convert.ToDateTime("2021-06-14T17:04:00.6817506");
            _logger.LogInformation($"date1: {date1}");

            long dataLong = (long)date1.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds;

            _logger.LogInformation($"Test: {date1.ToUniversalTime().Subtract(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalMilliseconds}");
            
            return Ok(mainProducts);
        }

        // Get: Specific Brand with it's products
        // GET: api/<MainController>
        [HttpGet]
        [Route("Brand/{id}/Products")]
        public async Task<IActionResult> GetBrandWithProducts(int id)
        {
            var brandWithProducts = await _appDbContext.Brands
                .Include(b => b.Products)
                .Where(b => b.Id == id)
                .Select(b => new BrandDTO
                {
                    Id = b.Id,
                    Name = b.Name,
                    Products = b.Products.Select(p => new ProductDTO
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Description = p.Description,
                        Price = p.Price,
                        Username = p.ApplicationUser.UserName,
                        CreatedAt = p.CreatedAt
                    }).OrderByDescending(p => p.CreatedAt)
                     .Take(5)
                     .ToList()
                }).ToListAsync();

            return Ok(brandWithProducts);
        }


        // Get Specific Brand
        // GET: api/<MainController/Brand/{id}>
        [HttpGet]
        [Route("Brand/{id}")]
        public async Task<ActionResult<BrandDTO>> GetBrandById(int id)
        {
            //var brand = await _appDbContext.Brands.Include(b => b.Products).Where(b => b.Id == id).ToListAsync();

            var brand = await _appDbContext.Brands.Where(b => b.Id == id)
                .Select(b => new BrandDTO { Id= b.Id, Name = b.Name }).FirstOrDefaultAsync();

            //var brand = await _appDbContext.Brands.FindAsync(id);

            return Ok(brand);
        }
    }
}
