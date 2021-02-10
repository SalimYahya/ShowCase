using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Models.Temp;
using ShowCase.ViewModel.Order;
using ShowCase.ViewModel.Profile;
using ShowCase.ViewModel.Role;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Controllers
{
    public class ProfileController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly AppDbContext _appDbContext;

        public ProfileController(UserManager<ApplicationUser> userManager, AppDbContext appDbContext)
        {
            _userManager = userManager;
            _appDbContext = appDbContext;
        }

        public async Task<IActionResult> UserInformation()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);
            var address = user.Address;
            var payment = user.PaymentMethod;

            ProfileEditUserViewModel model = new ProfileEditUserViewModel
            {
                User = user,
                Address = address,
                PaymentMethod = payment
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditUserInformation(ProfileEditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.User.Id);

                user.FirstName = model.User.FirstName;
                user.LastName = model.User.LastName;
                user.UpdatedAt = DateTime.Now;

                await _userManager.UpdateAsync(user);

                return RedirectToAction("UserInformation", "Profile");
            }

            return RedirectToAction("UserInformation", new { ProfileEditUserViewModel = model });

        }

        [HttpPost]
        public async Task<IActionResult> EditUserAddress(ProfileEditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = await _userManager.FindByIdAsync(model.User.Id);

                user.Address.District = model.Address.District;
                user.Address.Street = model.Address.Street;
                user.Address.City = model.Address.City;
                user.Address.ZipCode = model.Address.ZipCode;
                user.Address.POBox = model.Address.POBox;

                await _userManager.UpdateAsync(user);

                return RedirectToAction("UserInformation", "Profile");
            }

            return RedirectToAction("UserInformation", new { ProfileEditUserViewModel = model });

        }
        public async Task<IActionResult> UserOrders()
        {
            string userId = _userManager.GetUserId(HttpContext.User);
            ApplicationUser user = await _userManager.FindByIdAsync(userId);

            var invoiceList = _appDbContext.Invoices.Include(u => u.ApplicationUser)
                                                    .Where(i=> i.ApplicationUserId == userId)
                                                    .OrderByDescending(d => d.CreateedAt);
            
            var orderDetailsViewModelList = new List<OrderDetailsViewModel>();

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
        public IActionResult ConfirmOrder(string Id)
        {
            int invoice_id = int.Parse(Id);
            string userId = _userManager.GetUserId(HttpContext.User);

            var invoice = _appDbContext.Invoices.Single(i => i.ApplicationUserId == userId && i.Id == invoice_id);
            
            if (invoice == null)
            {
                return NotFound();
            }

            invoice.IsConfirmed = true;

            var inv = _appDbContext.Invoices.Attach(invoice);
            inv.State = EntityState.Modified;

            _appDbContext.SaveChanges();

            return RedirectToAction("UserOrders", "Profile");
        }
    }
}
