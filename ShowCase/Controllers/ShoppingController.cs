using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShowCase.Data;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    public class ShoppingController : Controller
    {
        private readonly AppDbContext _dbContext;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingController(AppDbContext dbContext, UserManager<ApplicationUser> userManager)
        {
            _dbContext = dbContext;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<JsonResult> AddToCartAsync(string ItemId, string ItemQty)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            //Product product = _dbContext.Products.SingleOrDefault(model => model.Id.ToString() == ItemId);
            Product product = _dbContext.Products.Find(int.Parse(ItemId));

            // To Be Used: To Create new || To Update exsiting
            /************************************************/
            ShoppingCart shoppingCart;

            
            bool isExists = _dbContext.ShoppingCart
                                    .Any(model => (model.ApplicationUserID == user.Id)
                                               && (model.ProductId == product.Id));

            if ( isExists )
            {
                /* Update Qty */
                shoppingCart = _dbContext.ShoppingCart
                                    .Single(model => (model.ApplicationUserID == user.Id)
                                               && (model.ProductId == product.Id));
                shoppingCart.Qty = shoppingCart.Qty + int.Parse(ItemQty);
                _dbContext.ShoppingCart.Update(shoppingCart);
                _dbContext.SaveChanges();
            }
            else
            {
                /* Create new */
                shoppingCart = new ShoppingCart
                {
                    ApplicationUserID = userId,
                    ProductId = product.Id,
                    Qty = int.Parse(ItemQty)
                };

                _dbContext.ShoppingCart.Add(shoppingCart);
                _dbContext.SaveChanges();
            }

            var cartCount = _dbContext.ShoppingCart.Count();

            /*-------------------------*/
            /* Try to Add Session here */
            /*-------------------------*/

            HttpContext.Session.SetString("CartCount", cartCount.ToString());
            /*-------------------------*/


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
}
