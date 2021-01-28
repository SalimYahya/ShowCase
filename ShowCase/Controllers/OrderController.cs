using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Models.Temp;
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

        public OrderController(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            string user_id = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(user_id);

            var invoiceList = _dbContext.Invoices.Where(u => u.ApplicationUserId == user_id);
            
           
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

        /*public async Task<IActionResult> IndexAsync()
        {
            IEnumerable<ShoppingCart> modelList = _dbContext.ShoppingCart
                                                            .Where(user => user.ApplicationUserID.Contains(userId));

            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            var productList = _dbContext.ShoppingCart
                          .Where(u => u.ApplicationUserID.Contains(userId))
                          .Select(p => p.Product);

            var shoppingCartList = _dbContext.ShoppingCart
                                             .Where(u => u.ApplicationUserID.Contains(userId))
                                             .Select(up => up);

            SHPViewModel viewModel = new SHPViewModel
            {
                ApplicationUser = user,
                Products = productList.ToList(),
                ShoppingCarts = shoppingCartList.ToList()
            };

            return View(viewModel);
        }*/


        [HttpPost]
        public JsonResult OrderNow([FromBody] List<CartItem> shoppingCart)
        {

            string userId = _userManager.GetUserId(HttpContext.User);
            //ApplicationUser user = await _userManager.FindByIdAsync(userId);


            // 1- Create New Invoice & save it to the database
            // Vat = 15%
            int vat = 15;
            Invoice newInvoice = new Invoice { 
                ApplicationUserId = userId,
                CreateedAt = DateTime.Now,
                Vat = vat
            };

            _dbContext.Invoices.Add(newInvoice);
            _dbContext.SaveChanges();


            // 2- Create Multiple InvoiceProduct objects 
            // & Update vat, totalItems, totalExclude & totalInclude
            // values in invoice table

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

            _dbContext.InvoiceProduct.AddRange(invoiceProductsList);
            _dbContext.SaveChanges();


            // Update Invoice table
            totalIncludeVat = (vat * totalExcludeVat / 100) + totalExcludeVat;

            newInvoice.TotalItems = totalItem;
            newInvoice.TotalExcludeVat = totalExcludeVat;
            newInvoice.TotalIncludeVat = totalIncludeVat;

            var updatedInvoice = _dbContext.Invoices.Attach(newInvoice);
            updatedInvoice.State = Microsoft.EntityFrameworkCore.EntityState.Modified;

            _dbContext.SaveChanges();

            var response = new
            {
                Success = true,
                Message = "Order confirmed succefully", 
                Redirect = "/order/details",
                InvoiceId = newInvoice.Id
        };

            var jsonResult = Json(response);

            return jsonResult;
        }

        /*[HttpPost]
        public async Task<JsonResult> AddToCartAsync(string ItemId, string ItemQty)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            Product product = _dbContext.Products.SingleOrDefault(model => model.Id.ToString() == ItemId);
            Product product = _dbContext.Products.Find(int.Parse(ItemId));


            ShoppingCart shoppingCart;

            
            bool isExists = _dbContext.ShoppingCart
                                    .Any(model => (model.ApplicationUserID == user.Id)
                                               && (model.ProductId == product.Id));

            if ( isExists )
            {
                shoppingCart = _dbContext.ShoppingCart
                                    .Single(model => (model.ApplicationUserID == user.Id)
                                               && (model.ProductId == product.Id));
                shoppingCart.Qty = shoppingCart.Qty + int.Parse(ItemQty);
                _dbContext.ShoppingCart.Update(shoppingCart);
                _dbContext.SaveChanges();
            }
            else
            {
                shoppingCart = new ShoppingCart
                {
                    ApplicationUserID = userId,
                    ProductId = product.Id,
                    Qty = int.Parse(ItemQty)
                };

                _dbContext.ShoppingCart.Add(shoppingCart);
                _dbContext.SaveChanges();
            }

            var cartCount = _dbContext.ShoppingCart
                                        .Where(u => u.ApplicationUserID == userId)
                                        .Count();



            HttpContext.Session.SetString("CartCount", cartCount.ToString());
            


            var response = new { 
                Success = true, 
                Message = "Item Added Succesfully", 
                Product = new { 
                    product.Name,
                    product.Description,
                    product.Price
                },  
                CartCount = cartCount
            };

            var jsonResult = Json(response);
            
            return jsonResult;
            
        }*/
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

}
