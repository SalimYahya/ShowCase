using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    public class ShoppingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult AddToCart(string ItemId)
        {
            
            if (!string.IsNullOrEmpty(ItemId))
            {
                return Json(new { Success = true, Message = "recieved" });
            }
            else
            {

                return Json(new { Success = false, Message = "Not recieved" });
            }
        }
    }
}
