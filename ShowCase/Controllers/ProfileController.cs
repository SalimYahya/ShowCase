using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Models.Specials;
using ShowCase.Models.Temp;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Specifications;
using ShowCase.Security;
using ShowCase.ViewModel.Order;
using ShowCase.ViewModel.Profile;
using ShowCase.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly ILogger<ProfileController> _logger;

        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;
        private readonly IAuthorizationService _authorizationService;
        private readonly IUserRepository _userRepository;

        public ProfileController(ILogger<ProfileController> logger,
            UserManager<ApplicationUser> userManager, 
            AppDbContext appDbContext, 
            IAuthorizationService authorizationService,
            IUserRepository userRepository)
        {
            _logger = logger;
            _userManager = userManager;
            _appDbContext = appDbContext;
            _authorizationService = authorizationService;
            _userRepository = userRepository;
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> UserInformation(string text = null)
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userRepository.GetUserInformationAsync(userId);

            ProfileEditUserViewModel model = new ProfileEditUserViewModel
            {
                User = user,
                Address = user.Address,
                PaymentMethod = user.PaymentMethod
            };

            var authorizationResult = await _authorizationService.AuthorizeAsync(User, model.User, CRUD.Read);

            if (authorizationResult.Succeeded) 
            {
                return View(model);
            }
            else if (User.Identity.IsAuthenticated){ return new ForbidResult(); }
            else { return new ChallengeResult(); }

        }

        [HttpPost]
        public async Task<IActionResult> EditUserInformation(ProfileEditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, model.User, CRUD.Update);
                if (authorizationResult.Succeeded)
                {
                    ApplicationUser user = await _userRepository.GetByIdAsync(model.User.Id);

                    user.FirstName = model.User.FirstName;
                    user.LastName = model.User.LastName;
                    user.UpdatedAt = DateTime.Now;

                    _userRepository.Update(user);
                    await _userRepository.SaveAsync();
                    
                    return RedirectToAction("UserInformation", "Profile");
                }
                else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
                else { return new ChallengeResult(); }
            }

            return RedirectToAction("UserInformation", new { ProfileEditUserViewModel = model });

        }

        [HttpPost]
        public async Task<IActionResult> EditOrCreateUserAddress(ProfileEditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userRepository.GetUserInformationAsync(model.User.Id);
                //Address address = await _userRepository.GetUserAddressAsync(model.User.Id);

                if (user.Address != null)
                {
                    user.Address.District = model.User.Address.District;
                    user.Address.Street = model.User.Address.Street;
                    user.Address.City = model.User.Address.City;
                    user.Address.ZipCode = model.User.Address.ZipCode;
                    user.Address.POBox = model.User.Address.POBox;

                    var authResult = await _authorizationService.AuthorizeAsync(User, user.Address, CRUD.Update);
                    if (authResult.Succeeded)
                    {
                        _userRepository.UpdateUserAddress(user.Address);
                        await _userRepository.SaveAsync();
                    }
                    else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
                    else { return new ChallengeResult(); }
                }
                else
                {
                   Address address = new Address
                   {
                       Id = model.User.Id,
                       District = model.User.Address.District,
                       Street = model.User.Address.Street,
                       City = model.User.Address.City,
                       ZipCode = model.User.Address.ZipCode,
                       POBox = model.User.Address.POBox
                    };

                    var authResult = await _authorizationService.AuthorizeAsync(User, address, CRUD.Create);

                    if (authResult.Succeeded)
                    {
                        await _userRepository.AddAddressAsync(address);
                        await _userRepository.SaveAsync();

                        _logger.LogInformation($"EditOrCreateUserAddress, Address: {address.ToString()} Cretaed");
                    }
                    else if (User.Identity.IsAuthenticated){ return new ForbidResult(); }
                    else { return new ChallengeResult(); }

                }

                return RedirectToAction("UserInformation", "Profile");
            }

            return RedirectToAction("UserInformation", new { ProfileEditUserViewModel = model });
        }
         
        [HttpPost]
        public async Task<IActionResult> EditOrCreatePaymentMethod(ProfileEditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.User.Id);
                PaymentMethod paymentMethod = _appDbContext.PaymentMethods.Find(model.User.Id);

                if (paymentMethod != null)
                {
                    paymentMethod.Type = model.User.PaymentMethod.Type;
                    paymentMethod.HolderName = model.User.PaymentMethod.HolderName;
                    paymentMethod.CardNumber = model.User.PaymentMethod.CardNumber;
                    paymentMethod.CVCCode = model.User.PaymentMethod.CVCCode;
                    paymentMethod.ExpiresAt = model.User.PaymentMethod.ExpiresAt;

                    var authResult = await _authorizationService.AuthorizeAsync(User, user.PaymentMethod, CRUD.Update);
                    
                    if (authResult.Succeeded)
                    {
                        var tmp_paymentMethod = _appDbContext.PaymentMethods.Attach(paymentMethod);
                        tmp_paymentMethod.State = EntityState.Modified;

                        await _appDbContext.SaveChangesAsync();
                        _logger.LogInformation($"EditOrCreateUserAddress, Payment: {tmp_paymentMethod.ToString()} Updated");
                    }
                    else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
                    else { return new ChallengeResult(); }
                }
                else
                {
                    PaymentMethod new_paymentMethod = new PaymentMethod
                    {
                        Id = model.User.Id,
                        Type = model.User.PaymentMethod.Type,
                        HolderName = model.User.PaymentMethod.HolderName,
                        CardNumber = model.User.PaymentMethod.CardNumber,
                        CVCCode = model.User.PaymentMethod.CVCCode,
                        ExpiresAt = model.User.PaymentMethod.ExpiresAt
                    };

                    var authResult = await _authorizationService.AuthorizeAsync(User, new_paymentMethod, CRUD.Create);
                    if (authResult.Succeeded)
                    {
                        _appDbContext.PaymentMethods.Add(new_paymentMethod);
                        await _appDbContext.SaveChangesAsync();

                        _logger.LogInformation($"EditOrCreateUserAddress, Payment: {new_paymentMethod.ToString()} Created");
                    }
                    else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
                    else { return new ChallengeResult(); }
                }


                return RedirectToAction("UserInformation", "Profile");
            }

            return RedirectToAction("UserInformation", new { ProfileEditUserViewModel = model });

        }

        [Authorize(Roles = "SuperAdmin, Supervisor, Customer")]
        public async Task<IActionResult> UserOrders()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            var orderDetailsViewModelList = new List<OrderDetailsViewModel>();
            var isUserInAdminstrativeRole = User.IsInRole("SuperAdmin") || User.IsInRole("Admin") || User.IsInRole("Supervisor");
            //var spec = new InvoiceListByUserSpecification();
            //var invoiceList = _invoiceRepository.FindWithSpecificationPattern(spec);
        
            if (User.IsInRole("Customer") && !isUserInAdminstrativeRole)
            {
                var userInvoiceList = await _userRepository.GetUserInvoiceListDescendingOrder(userId);

                foreach (var invoice in userInvoiceList)
                {
                    var productList = _appDbContext.InvoiceProduct
                                                    .Where(i => i.InvoiceId == invoice.Id)
                                                    .Select(p => new InvoiceProductInfo
                                                    {
                                                        Product = p.Product,
                                                        Qty = p.Qty,
                                                        Invoice = p.Invoice
                                                    });

                    orderDetailsViewModelList.Add(new OrderDetailsViewModel
                    {
                        ApplicationUser = user,
                        ProductInfo = productList.ToList(),
                        Invoice = invoice
                    });
                }

                return View(orderDetailsViewModelList);
            }


            var invoiceList = await _userRepository.GetInvoiceListDescendingOrder();
            foreach (var invoice in invoiceList)
            {
                var productList = _appDbContext.InvoiceProduct
                                                .Where(i => i.InvoiceId == invoice.Id)
                                                .Select(p => new InvoiceProductInfo {
                                                    Product = p.Product,
                                                    Qty = p.Qty,
                                                    Invoice = p.Invoice
                                                });

                orderDetailsViewModelList.Add(new OrderDetailsViewModel { 
                        ApplicationUser = user,
                        ProductInfo = productList.ToList(),
                        Invoice = invoice
                });
            }
            
            return View(orderDetailsViewModelList);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmOrder(string Id)
        {
            int invoice_id = int.Parse(Id);
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            Address address = _appDbContext.Addresses.Find(userId);
            PaymentMethod paymentMethod = _appDbContext.PaymentMethods.Find(userId);

            /*
             * If Both Address and PaymentMethod are empty,
             * The customer will be redirected to his profile 
             * to fill address (For Shipping purpose),
             * and paymentMethod (For Invoice Payment)
             */
            if (address == null || paymentMethod == null)
            {   
                /* In the future, i should add message with redirection,
                 * to indicate what information to be filled
                 */
                return RedirectToAction("UserInformation", "Profile");
            }

            var invoice = _appDbContext.Invoices.Single(i => i.ApplicationUserId == userId && i.Id == invoice_id);
            
            if (invoice == null)
            {
                return NotFound();
            }


            var authResult = await _authorizationService.AuthorizeAsync(User, invoice, CRUD.Update);
            if (authResult.Succeeded)
            {
                invoice.IsConfirmed = true;

                var inv = _appDbContext.Invoices.Attach(invoice);
                inv.State = EntityState.Modified;

                await _appDbContext.SaveChangesAsync();

                // Implement: Product-Sold logic
                List<ProductSold> productSoldList = new List<ProductSold>();

                var productList = _appDbContext.InvoiceProduct
                                .Where(i => i.InvoiceId == invoice.Id)
                                .Select(p => new InvoiceProductInfo
                                {
                                    Product = p.Product,
                                    Qty = p.Qty,
                                    Invoice = p.Invoice
                                }).ToList();


                foreach (var product in productList)
                {
                    var sold = new Sold { Qty = product.Qty };
                    await _appDbContext.Solds.AddAsync(sold);
                    await _appDbContext.SaveChangesAsync();

                    var productSold = new ProductSold
                    {
                        SoldId = sold.Id,
                        ProductId = product.Product.Id
                    };

                    productSoldList.Add(productSold);
                }

                await _appDbContext.ProductSolds.AddRangeAsync(productSoldList);
                await _appDbContext.SaveChangesAsync();

                return RedirectToAction("UserOrders", "Profile");
            }
            else if (User.Identity.IsAuthenticated) { return new ForbidResult(); }
            else { return new ChallengeResult(); }
        }

        [HttpGet]
        public IActionResult UserInventory()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            var productList = _appDbContext.Products.Include(u => u.ApplicationUser)
                                                    .Where(p => p.ApplicationUserId == userId)
                                                    .OrderByDescending(d => d.CreatedAt);

            List<ProductInventoryInfo> productInventoryInfos = new List<ProductInventoryInfo>();

            foreach (var product in productList)
            {
                var sold = _appDbContext.ProductSolds.Where(p => p.ProductId == product.Id)
                                                     .Select(s => s.Sold);
                
                int qtySum = 0;
                if (sold != null)
                {
                    foreach (var s in sold)
                    {
                        qtySum += s.Qty;
                    }
                }

                productInventoryInfos.Add(new ProductInventoryInfo { Product = product, QtySold = qtySum});
            }

            UserInventoryModelView model = new UserInventoryModelView
            {
                ProductInventoryInfoList = productInventoryInfos
            };

            return View(model);
        }
    }

}
