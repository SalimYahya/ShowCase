using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Security;
using ShowCaseAPI.DTO.Order;
using ShowCaseAPI.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ShowCaseAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class OrdersController : ControllerBase
    {
        private readonly ILogger<OrdersController> _logger;
        private readonly IAuthorizationService _authorizationService;
        private readonly AppDbContext _appDbContext;

        public OrdersController(ILogger<OrdersController> logger,
            IAuthorizationService authorizationService,
            AppDbContext appDbContext)
        {
            _logger = logger;
            _authorizationService = authorizationService;
            _appDbContext = appDbContext;
        }


        // GET: api/<OrdersController>
        [HttpGet]
        [Authorize(Roles = "SuperAdmin, Admin, Superviosr, Seller")]
        public async Task<IActionResult> Get()
        {

            string userId = HttpContext.GetUserId();
            var invoiceList = await _appDbContext.Invoices
                                .Include(i => i.ApplicationUser)
                                .OrderByDescending(i => i.CreatedAt)
                                .Select(i => new {
                                    i.ApplicationUserId,
                                    i.ApplicationUser.Email,
                                    i.Id,
                                    i.CreatedAt,
                                    i.TotalExcludeVat,
                                    i.TotalIncludeVat,
                                    i.IsConfirmed
                                }).ToListAsync();


            if (invoiceList != null)
            {
                dynamic jsonResponse = new
                {
                    Total = invoiceList.Count(),
                    InvoiceList = invoiceList
                };
                return Ok(jsonResponse);
            }

            return BadRequest("No orders Yet !!!");
        }

        // GETMYORDERS: api/<OrdersController>
        [HttpGet]
        [Route("/api/Order/MyList")]
        public async Task<IActionResult> GetMyOrders()
        {
            string userId = HttpContext.GetUserId();
            var invoiceList = await _appDbContext.Invoices
                                .Include(i => i.ApplicationUser)
                                .Where(i => i.ApplicationUserId == userId)
                                .OrderByDescending(i => i.CreatedAt)
                                .Select(i => new {
                                    i.Id,
                                    i.CreatedAt,
                                    i.TotalExcludeVat,
                                    i.TotalIncludeVat,
                                    i.IsConfirmed
                                }).ToListAsync();

            if (invoiceList != null)
            {
                dynamic jsonResponse = new
                {
                    Total = invoiceList.Count(),
                    InvoiceList = invoiceList
                };
                return Ok(jsonResponse);
            }

            return BadRequest("You Don't have any orders !!!");
        }

        // GET api/<OrdersController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Invoice invoice = await _appDbContext.Invoices
                                .Include(i => i.ApplicationUser)
                                .Where(i => i.Id == id)
                                .FirstOrDefaultAsync();

            if (invoice != null)
            {
                var authorizationResult = await _authorizationService
                                                .AuthorizeAsync(User, invoice, CRUD.Read);

                if (authorizationResult.Succeeded)
                {
                    // Should return Details of the Order==Invoice
                    var model = new {
                        invoice.Id,
                        invoice.ApplicationUser.Email,
                        invoice.CreatedAt,
                        invoice.TotalIncludeVat,
                        invoice.IsConfirmed
                    };

                    var productList = await _appDbContext.InvoiceProduct
                                               .Where(i => i.InvoiceId == invoice.Id)
                                               .Select(p => new {
                                                   p.ProductId,
                                                   p.Product.Name,
                                                   p.Product.Price,
                                                   p.Qty
                                               }).ToListAsync();

                    dynamic jsonResponse = new { Invoice = model, ProductList = productList };
                    return Ok(jsonResponse);
                }
                else if (User.Identity.IsAuthenticated) { return BadRequest("Forbiden"); }
                else { return BadRequest("You are no Logged in"); }
            }

            return BadRequest("Not Found !!!");
        }

        // POST api/<OrdersController>
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<IActionResult> Post([FromBody] List<CreateOrder> shoppingCart)
        {
            // Check with User Policy that can create Order/Invoice 

            // 1- Create new Invoice
            int vat = 15;
            Invoice newInvoice = new Invoice();

            newInvoice.ApplicationUserId = HttpContext.GetUserId();
            newInvoice.CreatedAt = DateTime.Now;
            newInvoice.Vat = vat;

            await _appDbContext.Invoices.AddAsync(newInvoice);
            await _appDbContext.SaveChangesAsync();

            // 2- Get Products from Shoppingcart & attach them to the invoice
            List<InvoiceProduct> invoiceProductsList = new List<InvoiceProduct>();
            int totalItem = 0;
            double totalExcludeVat = 0.00;
            double totalIncludeVat = 0.00;

            foreach (var item in shoppingCart) 
            {
                totalItem += item.count;
                totalExcludeVat += item.price;

                invoiceProductsList.Add(new InvoiceProduct { 
                    InvoiceId = newInvoice.Id,
                    ProductId = item.id,
                    Qty = item.count
                });
            }

            await _appDbContext.InvoiceProduct.AddRangeAsync(invoiceProductsList);
            await _appDbContext.SaveChangesAsync();

            // Update Invoice table
            totalIncludeVat = (vat * totalExcludeVat / 100) + totalExcludeVat;
            newInvoice.TotalItems = totalItem;
            newInvoice.TotalExcludeVat = Math.Round(totalExcludeVat, 2, MidpointRounding.AwayFromZero);
            newInvoice.TotalIncludeVat = Math.Round(totalIncludeVat, 2, MidpointRounding.AwayFromZero);

            var invoiceModel = _appDbContext.Invoices.Attach(newInvoice);
            invoiceModel.State = EntityState.Modified;
            await _appDbContext.SaveChangesAsync();

            return Ok(new { Status = "Ok", Invoice = newInvoice, List = invoiceProductsList.Select(ip => new { ip.ProductId , ip.Qty}) });
        }

        // PUT api/<OrdersController>/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id)
        {
            Invoice invoice = await _appDbContext.Invoices
                                            .Include(i => i.ApplicationUser)
                                            .Where(i => i.Id == id)
                                            .FirstOrDefaultAsync();

            if (invoice != null)
            {
                var authorizationResult = await _authorizationService
                                                .AuthorizeAsync(User, invoice, CRUD.Update);

                if (authorizationResult.Succeeded)
                {
                    invoice.IsConfirmed = true;
                    var model = _appDbContext.Invoices.Attach(invoice);
                    model.State = EntityState.Modified;

                    await _appDbContext.SaveChangesAsync();

                    dynamic jsonResponse = new { 
                        Invoice = new { 
                            invoice.Id, 
                            invoice.CreatedAt, 
                            invoice.TotalIncludeVat, 
                            invoice.TotalItems, 
                            invoice.IsConfirmed 
                    }};

                    return Ok(jsonResponse);
                }
                else if (User.Identity.IsAuthenticated) { return BadRequest("Forbiden"); }
                else { return BadRequest("You are no Logged in"); }
            }

            return BadRequest("Not Found !!!");
        }

        // DELETE api/<OrdersController>/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Invoice invoice = await _appDbContext.Invoices
                                            .Include(i => i.ApplicationUser)
                                            .Where(i => i.Id == id)
                                            .FirstOrDefaultAsync();

            if (invoice != null)
            {
                var authorizationResult = await _authorizationService
                                                .AuthorizeAsync(User, invoice, CRUD.Update);

                if (authorizationResult.Succeeded)
                {
                    if (!invoice.IsConfirmed)
                    {
                        _appDbContext.Invoices.Remove(invoice);
                        await _appDbContext.SaveChangesAsync();

                        dynamic jsonResponse = new
                        {
                            Invoice = new
                            {
                                invoice.Id,
                                invoice.CreatedAt,
                                invoice.TotalIncludeVat,
                                invoice.TotalItems,
                                invoice.IsConfirmed
                            }
                        };

                        return Ok(jsonResponse);
                    }

                    return BadRequest($"Invoice with id ({invoice.Id}) Cannot be deleted.");
                }
                else if (User.Identity.IsAuthenticated) { return BadRequest("Forbiden"); }
                else { return BadRequest("You are no Logged in"); }
            }

            return BadRequest("Not Found !!!");
        }
    }
}
