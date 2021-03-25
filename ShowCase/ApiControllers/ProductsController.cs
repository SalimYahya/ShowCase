using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowCase.Data;
using ShowCase.Models;
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
        private readonly AppDbContext _dbContext;

        public ProductsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // GET: api/<ProductsController>
        [HttpGet]
        public async Task<IActionResult> Get()
        {
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

            var existProduct = await _dbContext.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existProduct == null) return NotFound();

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
