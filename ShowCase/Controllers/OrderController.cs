using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Models.Temp;
using ShowCase.Security;
using ShowCase.ViewModel.Order;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    [Authorize]
    public class OrderController : Controller

    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public OrderController(AppDbContext dbContext, UserManager<ApplicationUser> userManager, IAuthorizationService authorizationService)
        {
            _dbContext = dbContext;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        [Authorize(Roles = "SuperAdmin, Supervisor, Customer")]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            var invoiceList = await _dbContext.Invoices.Include(u => u.ApplicationUser).ToListAsync();
            
            if(User.IsInRole("Customer"))
            {
                var userInvoices = invoiceList.Where(u => u.ApplicationUserId == userId).ToList();
                return View(userInvoices);
            }

            return View(invoiceList);
        }


        public async Task<IActionResult> Details(int? id)
        {
            string user_id = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(user_id);

            Invoice invoice = _dbContext.Invoices.Find(id);


            var productList = _dbContext.InvoiceProduct
                                        .Where(i => i.InvoiceId == invoice.Id)
                                        .Select(p => new InvoiceProductInfo { 
                                            Product = p.Product,
                                            Qty= p.Qty, 
                                            Invoice = p.Invoice
                                        });
            

            OrderDetailsViewModel odvModel = new OrderDetailsViewModel { 
                ApplicationUser = user,
                ProductInfo = productList.ToList(),
                Invoice = invoice
            };


            return View(odvModel);
        }


        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OrderNow([FromBody] List<CartItem> shoppingCart)
        {

            string userId = _userManager.GetUserId(HttpContext.User);
            //ApplicationUser user = await _userManager.FindByIdAsync(userId);

            List<Product> products = new List<Product>();
            foreach (var item in shoppingCart)
            {
                var product = await _dbContext.Products
                    .Include(u => u.ApplicationUser)
                    .Where(p => p.Id == item.id)
                    .FirstOrDefaultAsync();
                
                if (product != null)
                {
                    products.Add(product);
                }
            }

            int vat = 15;
            Invoice newInvoice = new Invoice();

            // Authorization: check if user is eleigible to create Invoice ==> Order
            string authResultMessage = "";
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, products, CRUD.Create);

            if (authorizationResult.Succeeded) 
            { 
                authResultMessage += "Create Order: Successfully Created";

                // 1- Create New Invoice & save it to the database
                newInvoice.ApplicationUserId = userId;
                newInvoice.CreatedAt = DateTime.Now;
                newInvoice.Vat = vat;

                await _dbContext.Invoices.AddAsync(newInvoice);
                await _dbContext.SaveChangesAsync();

                int totalItem = 0;
                double totalExcludeVat = 0.00;
                double totalIncludeVat = 0.00;

                List<InvoiceProduct> invoiceProductsList = new List<InvoiceProduct>();

                foreach (var item in shoppingCart)
                {
                    totalItem += item.count;
                    totalExcludeVat += item.price;

                    invoiceProductsList.Add(new InvoiceProduct
                    {
                        InvoiceId = newInvoice.Id,
                        ProductId = item.id,
                        Qty = item.count
                    });
                }


                await _dbContext.InvoiceProduct.AddRangeAsync(invoiceProductsList);
                await _dbContext.SaveChangesAsync();

                // Update Invoice table
                totalIncludeVat = (vat * totalExcludeVat / 100) + totalExcludeVat;

                newInvoice.TotalItems = totalItem;
                newInvoice.TotalExcludeVat = Math.Round(totalExcludeVat, 2, MidpointRounding.AwayFromZero);
                newInvoice.TotalIncludeVat = Math.Round(totalIncludeVat, 2, MidpointRounding.AwayFromZero);

                var updatedInvoice = _dbContext.Invoices.Attach(newInvoice);
                updatedInvoice.State = EntityState.Modified;

                await _dbContext.SaveChangesAsync();
            }
            else 
            {
                authResultMessage += "Create Order: Failed to Create Order!";
            }



            var response = new
            {
                Success = true,
                Message = authResultMessage, 
                Redirect = "/Profile/UserOrders",
                InvoiceId = newInvoice.Id
            };

            var jsonResult = Json(response);

            return jsonResult;
        }

        
        [HttpPost]
        [Authorize(Roles = "Customer")]
        public async Task<JsonResult> ConfirmOrder(string Invoice_Id)
        {
            int invoiceId = int.Parse(Invoice_Id);
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            
            /*
            var SuccessStatus = false;
            string message = "";
            var InvoiceIsConfirmed = false;
            */

            if (user.PaymentMethod == null)
            {
               
            }
            
            // Get Invoice which invoiceId == id & belongs to the current user
            Invoice invoice = await _dbContext.Invoices.SingleAsync(i => i.ApplicationUserId == userId && i.Id == invoiceId);
            invoice.IsConfirmed = true;
            
            var inv = _dbContext.Invoices.Attach(invoice);
            inv.State = EntityState.Modified;

            await _dbContext.SaveChangesAsync();


            var response = new
            {
                Success = true,
                Message = "Order confirmed succefully",
                Invoice = invoice.IsConfirmed
            };

            var jsonResult = Json(response);

            return jsonResult;
        }
    }


    /*
     *   Anothor Example to show Data
     * ------------------------------------------
     *   var response = new { 
     *       Success = true, 
     *       Message = "Item Added Succesfully", 
     *       Product = new { 
     *            product.Name,
     *            product.Description,
     *            product.Price
     *         },  
     *       CartCount = _dbContext.ShoppingCart.Count()
     *    };
     */


    /*   Way# 1: EF Conding Related 
     * -------------------------------------------
     * IEnumerable<ShoppingCart> modelList = _dbContext.ShoppingCart
     *                                           .Where(user => user.ApplicationUserID == userId)
     *                                           .Select(product => product.Product);
     */


    /*
     *   Way# 2: Similar to SQL 
     * -------------------------------------------- 
     * var modelList = ( from product in _dbContext.Products
     *                   where product.ShoppingCarts.Any(user => user.ApplicationUserID == userId)
     *                   select product ).ToList();
     */



    //  Usefull Query functions for Details Controller
    /*--------------------------------------------------*


   /*  
    *  Way# 2: Similar to SQL 
    * -------------------------------------------- 
    *  var productList = (from product in _dbContext.Products
    *                     where product.InvoiceProducts.Any(i => i.InvoiceId ==  invoice.Id)
    *                     select product).ToList();
    *
    */

    /*
     * var productList = (from product in _dbContext.Products
     *                   where product.InvoiceProducts.Any(i => i.InvoiceId == invoice.Id)
     *                  select new InvoiceProductInfo {
     *                      Product = product,
     *                      Qty = product.InvoiceProducts.Where(p => p.ProductId == product.Id).Select(q=>q.Qty),
     *                      Invoice = invoice
     *                  }).ToList();
     */


    /*
     * var invoice = _dbContext.Invoices.Where(i => i.ApplicationUserId == userId && i.Id == invoiceId);
     */

}
