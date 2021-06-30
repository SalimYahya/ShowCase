﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Extensions;
using ShowCase.Models;
using ShowCase.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowCase.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProductsController : ControllerBase
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly AppDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public ProductsController(ILogger<ProductsController> logger, AppDbContext dbContext, UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService)
        {
            _logger = logger;
            _dbContext = dbContext;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            string userId = HttpContext.GetUserId();
            _logger.LogInformation($"UserId: {userId} --- {HttpContext.User.Claims.Single(x => x.Type == "Id")}");
            _logger.LogInformation($"{HttpContext.User.Claims.Single(x=> x.Type == "Id")}");
            _logger.LogInformation($"User: {User}");

            var products = await _dbContext.Products.ToListAsync();
            return Ok(products);
        }

        // GET api/<ProductsController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync( p => p.Id == id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        public async Task<IActionResult> Post(Product product)
        {
            if (ModelState.IsValid)
            {
                await _dbContext.Products.AddAsync(product);
                await _dbContext.SaveChangesAsync();

                return CreatedAtAction("Get", new { product.Id}, product);
            }

            return new JsonResult("Something Went Wrong") {StatusCode = 500};
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Product product)
        {
            if (id != product.Id) return BadRequest();

            var existProduct = await _dbContext.Products
                                .Include(u => u.ApplicationUser)
                                .Where(p => p.Id == id)
                                .FirstOrDefaultAsync();

            _logger.LogInformation($"existProduct: {existProduct.ToString()}");

            if (existProduct == null) return NotFound();

            var authorizatoinResult = await _authorizationService
                .AuthorizeAsync(User, existProduct, CRUD.Update);
            _logger.LogInformation($"result: {authorizatoinResult}");

            if (authorizatoinResult.Succeeded)
            {
                existProduct.Name = product.Name;
                existProduct.Description = product.Description;
                existProduct.Price = product.Price;
                existProduct.UpdatedAt = DateTime.Now;

                var temp_product = _dbContext.Products.Attach(existProduct);
                temp_product.State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();

                //return NoContent(); 
                return Ok(existProduct);

            } 
            else 
            {
                return BadRequest(new { error = "you dont own this product"});
            }

        }

        // DELETE api/<ProductsController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var existProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existProduct == null) return NotFound();


            _dbContext.Products.Remove(existProduct);
            await _dbContext.SaveChangesAsync();

            return Ok(existProduct);
        }
    }
}
