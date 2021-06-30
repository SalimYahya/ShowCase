using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ShowCase.Data;
using ShowCase.Models;
using ShowCase.Models.Specials;
using ShowCase.Repository.Contracts;
using ShowCase.Repository.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Repository.Implementation
{
    public class UserRepository : RepositoryBase<ApplicationUser, string>, IUserRepository
    {

        private readonly AppDbContext _appDbContext;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public UserRepository(AppDbContext appDbContext,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager)
            : base(appDbContext)
        {
            _appDbContext = appDbContext;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        public async Task<ApplicationUser> GetUserInformationAsync(string userId)
        {
            return await _appDbContext.ApplicationUsers
                               .Where(u => u.Id == userId)
                               .Include(u => u.Address)
                               .Include(u => u.PaymentMethod)
                               .FirstOrDefaultAsync();
        }
        public async Task<IdentityResult> AddUserAsync(ApplicationUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }
        public async Task<IdentityResult> AddUserToRole(ApplicationUser user, string role)
        {
            return await _userManager.AddToRoleAsync(user, role);
        }
        public async Task<IdentityResult> AddUserToRoles(ApplicationUser user, IEnumerable<string> roles)
        {
            return await _userManager.AddToRolesAsync(user, roles);
        }
        public async Task<IdentityResult> RemoveUserFromRole(ApplicationUser user, string role)
        {
            return await _userManager.RemoveFromRoleAsync(user, role);
        }
        public Task<IdentityResult> RemoveUserFromRoles(ApplicationUser user, IEnumerable<string> roles)
        {
            return _userManager.RemoveFromRolesAsync(user, roles);
        }
        public async Task<SignInResult> UserPasswordSignInAsync(string userName, string password, bool isPersistent, bool lockoutOnFailure)
        {
            return await _signInManager.PasswordSignInAsync(userName, password, isPersistent, lockoutOnFailure);
        }
        public async Task UserSignInAsync(ApplicationUser user, bool isPersistent, string authenticationMethod = null)
        {
            await _signInManager.SignInAsync(user, false);
        }
        public async Task UserSignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        // Invoice
        public async Task<Invoice> GetInvoiceByIdAsync(int? id)
        {
            return await _appDbContext.Invoices
                                .Include(i => i.ApplicationUser)
                                .Where(i => i.Id == id)
                                .FirstOrDefaultAsync();
        }
        public async Task<Invoice> AddInvoiceAsync(Invoice invoice)
        {
            await _appDbContext.Invoices.AddAsync(invoice);
            return invoice;
        }
        public void UpdateInvoiceAsync(Invoice invoice)
        {
            _appDbContext.Set<Invoice>().Attach(invoice);
            _appDbContext.Entry(invoice).State = EntityState.Modified;
        }
        public async Task<IEnumerable<Invoice>> GetInvoiceListDescendingOrder()
        {
            return await _appDbContext.Invoices
                    .Include(i => i.ApplicationUser)
                    .OrderByDescending(p => p.CreatedAt)
                    .ToListAsync();
        }
        public async Task<IEnumerable<Invoice>> GetInvoiceListInAscendingOrder()
        {
            return await _appDbContext.Invoices
                    .Include(i => i.ApplicationUser)
                    .OrderBy(p => p.CreatedAt)
                    .ToListAsync();
        }
        public async Task<IEnumerable<Invoice>> GetUserInvoiceListDescendingOrder(string userId)
        {
            return await _appDbContext.Invoices
                    .Include(i => i.ApplicationUser)
                    .Where(i => i.ApplicationUserId == userId)
                    .OrderByDescending(p => p.CreatedAt)
                    .ToListAsync();
        }
        public async Task<IEnumerable<Invoice>> GetUserInvoiceListInAscendingOrder(string userId)
        {
            return await _appDbContext.Invoices
                    .Include(i => i.ApplicationUser)
                    .Where(i => i.ApplicationUserId == userId)
                    .OrderBy(p => p.CreatedAt)
                    .ToListAsync();
        }

        // InvoiceProduct
        public async Task AddProductToInvoiceAsync(InvoiceProduct entity)
        {
            await _appDbContext.InvoiceProduct.AddAsync(entity);
        }
        public async Task AddRangeOfProductsToInvoiceAsync(List<InvoiceProduct> entities)
        {
            await _appDbContext.InvoiceProduct.AddRangeAsync(entities);
        }
        public async Task<IEnumerable<InvoiceProductInfo>> GetInvoiceProductInfo(int id)
        {
            var result = _appDbContext.InvoiceProduct
                            .Where(i => i.InvoiceId == id)
                            .Select(P => new InvoiceProductInfo
                            {
                                Product = P.Product,
                                Qty = P.Qty,
                                Invoice = P.Invoice
                            });

            return await result.ToListAsync();
        }
    }
}
