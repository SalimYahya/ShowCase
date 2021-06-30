using Microsoft.AspNetCore.Identity;
using ShowCase.Models;
using ShowCase.Models.Specials;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowCase.Repository.Contracts
{
    public interface IUserRepository : IRepositoryBase<ApplicationUser, string>
    {
        //
        // Summary:
        //     Get User with Adderss & PaymentMethod information.
        //
        // Parameters:
        //    String userId.
        //
        // Returns:
        //     User Information, Adderss Information, PaymentMethod Information.
        Task<ApplicationUser> GetUserInformationAsync(string userId);
        Task<IdentityResult> AddUserAsync(ApplicationUser user, string password);
        //Task EditUserAsync(ApplicationUser user, string password);
        //Task<IdentityResult> DeleteUserAsync(ApplicationUser user, string password);
        
        Task<IdentityResult> AddUserToRole(ApplicationUser user, string role);
        Task<IdentityResult> AddUserToRoles(ApplicationUser user, IEnumerable<string> roles);
        Task<IdentityResult> RemoveUserFromRole(ApplicationUser user, string role);
        Task<IdentityResult> RemoveUserFromRoles(ApplicationUser user, IEnumerable<string> roles);


        Task UserSignInAsync(ApplicationUser user, bool isPersistent, string authenticationMethod = null);
        Task<SignInResult> UserPasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure);
        Task UserSignOutAsync();


        // Invoice
        Task<Invoice> GetInvoiceByIdAsync(int? id);
        Task<Invoice> AddInvoiceAsync(Invoice invoice);
        void UpdateInvoiceAsync(Invoice invoice);

        Task<IEnumerable<Invoice>> GetInvoiceListInAscendingOrder();
        Task<IEnumerable<Invoice>> GetInvoiceListDescendingOrder();
        Task<IEnumerable<Invoice>> GetUserInvoiceListInAscendingOrder(string userId);
        Task<IEnumerable<Invoice>> GetUserInvoiceListDescendingOrder(string userId);


        // InvoiceProduct
        Task<IEnumerable<InvoiceProductInfo>> GetInvoiceProductInfo(int id);
        Task AddProductToInvoiceAsync(InvoiceProduct entity);
        Task AddRangeOfProductsToInvoiceAsync(List<InvoiceProduct> entities);
    }
}
