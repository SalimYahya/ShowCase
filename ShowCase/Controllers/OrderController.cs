using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Models.Specials;
using ShowCase.Models.Temp;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Specifications;
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
        private readonly ILogger<OrderController> _logger;
        private readonly IUserRepository _userRepository;
        private readonly IProductRepository _productRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IAuthorizationService _authorizationService;

        public OrderController(ILogger<OrderController> logger,
            IUserRepository userRepository,
            IProductRepository productRepository,
            UserManager<ApplicationUser> userManager, 
            IAuthorizationService authorizationService)
        {
            _logger = logger;
            _userRepository = userRepository;
            _productRepository = productRepository;
            _userManager = userManager;
            _authorizationService = authorizationService;
        }

        [Authorize(Roles = "SuperAdmin, Supervisor, Customer")]
        public async Task<IActionResult> Index()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var isUserInAdminstrativeRole = User.IsInRole("SuperAdmin") || User.IsInRole("Admin") || User.IsInRole("Supervisor");

            if (User.IsInRole("Customer") && !isUserInAdminstrativeRole)
            {
                var userInvoiceList = await _userRepository.GetUserInvoiceListDescendingOrder(userId);
                return View(userInvoiceList);
            }

            var invoiceList = await _userRepository.GetInvoiceListDescendingOrder();
            return View(invoiceList);
        }

        [Authorize(Roles = "SuperAdmin, Supervisor, Customer")]
        public async Task<IActionResult> Details(int? id)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userRepository.GetByIdAsync(userId);
            Invoice invoice = await _userRepository.GetInvoiceByIdAsync(id);

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, invoice, CRUD.Read);

            if (authorizationResult.Succeeded)
            {
                var productList = _userRepository.GetInvoiceProductInfo(invoice.Id);
                OrderDetailsViewModel odvModel = new OrderDetailsViewModel
                {
                    ApplicationUser = user,
                    ProductInfo = productList.Result,
                    Invoice = invoice
                };

                return View(odvModel);
            }
            else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
            else { return new ChallengeResult(); }
        }

        [HttpPost]
        [Authorize(Roles = "Customer")]
        [ValidateAntiForgeryToken]
        public async Task<JsonResult> OrderNow([FromBody] List<CartItem> shoppingCart)
        {
            string userId = _userManager.GetUserId(HttpContext.User);

            List<Product> products = new List<Product>();
            foreach (var item in shoppingCart)
            {
                var product = await _productRepository.GetProductWithOwner(item.id);
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

                await _userRepository.AddInvoiceAsync(newInvoice);
                await _userRepository.SaveAsync();

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


                await _userRepository.AddRangeOfProductsToInvoiceAsync(invoiceProductsList);
                await _userRepository.SaveAsync();

                // Update Invoice table
                totalIncludeVat = (vat * totalExcludeVat / 100) + totalExcludeVat;

                newInvoice.TotalItems = totalItem;
                newInvoice.TotalExcludeVat = Math.Round(totalExcludeVat, 2, MidpointRounding.AwayFromZero);
                newInvoice.TotalIncludeVat = Math.Round(totalIncludeVat, 2, MidpointRounding.AwayFromZero);

                 _userRepository.UpdateInvoiceAsync(newInvoice);
                await _userRepository.SaveAsync();
            }
            else 
            {
                authResultMessage += "Create Order: Failed to Create Order!";
            }


            var response = new { 
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
            ApplicationUser user = await _userRepository.GetUserInformationAsync(userId);
            Invoice invoice = await _userRepository.GetInvoiceByIdAsync(invoiceId);

            string responseMessage = "";
            string childNullId = "";
            string redirectIfFailed = "";
            var SuccessStatus = false;
            dynamic jsonResponse;

            if (user.Address == null)
            {
                responseMessage += "Add Address";
                childNullId += "address";
                redirectIfFailed += "/Profile/UserInformation";

                jsonResponse = new {
                    Success = SuccessStatus,
                    Message = responseMessage,
                    Invoice = invoice.IsConfirmed,
                    ChildNullId = childNullId,
                    Redirect = redirectIfFailed
                };
                return Json(jsonResponse);
            }

            if (user.PaymentMethod == null)
            {
                responseMessage += "Add PaymetMethod";
                childNullId += "payment-method";
                redirectIfFailed += "/Profile/UserInformation";

                jsonResponse = new {
                    Success = SuccessStatus,
                    Message = responseMessage,
                    Invoice = invoice.IsConfirmed,
                    ChildNullId = childNullId,
                    Redirect = redirectIfFailed
                };
                return Json(jsonResponse);
            }


            var authorizationResult = await _authorizationService.AuthorizeAsync(User, invoice, CRUD.Update);
            if (authorizationResult.Succeeded)
            {
                try
                {
                    invoice.IsConfirmed = true;
                    _userRepository.UpdateInvoiceAsync(invoice);
                    await _userRepository.SaveAsync();

                    responseMessage += "Order Confirmed";
                    SuccessStatus = true;
                }
                catch (DbUpdateException ex)
                {
                    responseMessage += "Confirm Failed! Due to " + ex.InnerException.ToString();
                }

                jsonResponse = new
                {
                    Success = SuccessStatus,
                    Message = responseMessage,
                    Invoice = invoice.IsConfirmed,
                    ChildNullId = childNullId
                };

                return Json(jsonResponse);
            }
            else if (User.Identity.IsAuthenticated) { return Json(new ForbidResult()); }
            else { return Json(new ChallengeResult()); }
        }
    }
}
