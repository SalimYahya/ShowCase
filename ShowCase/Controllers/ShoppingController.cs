using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

            /*-------------------------*/
            /* Try to Add Session here */
            /*-------------------------*/
            

            if (!string.IsNullOrEmpty(ItemId))
            {
                return Json(new { 
                    Success = true, 
                    Message = "recieved", 
                    Product_id = product.Id, 
                    item_id = ItemId,
                    item_qty = ItemQty,
                    CartCounter = _dbContext.ShoppingCart.Count()
                });
            }
            else
            {

                return Json(new { Success = false, Message = "Not recieved"});
            }
        }
    }
}
