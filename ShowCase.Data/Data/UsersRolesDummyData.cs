using Microsoft.AspNetCore.Identity;
using ShowCase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShowCase.Data
{
    public class UsersRolesDummyData
    {
        public static async Task Initilize(AppDbContext appDbContext, 
            UserManager<ApplicationUser> userManager, 
            RoleManager<IdentityRole> roleManager) 
        {
            appDbContext.Database.EnsureCreated();
           
            // Seed Role Table
            var roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name="SuperAdmin",
                    NormalizedName ="SUPERADMIN"
                },
                new IdentityRole
                {
                    Name="Admin",
                    NormalizedName ="ADMIN"
                },
                new IdentityRole
                {
                    Name="Supervisor",
                    NormalizedName ="SUPERVISOR"
                },
                new IdentityRole
                {
                    Name="Customer",
                    NormalizedName="CUSTOMER"
                },
                new IdentityRole
                {
                    Name="Seller",
                    NormalizedName="SELLER"
                }
            };

            foreach (var role in roles)
            {
                await roleManager.CreateAsync(role);
            }


            // Seed User Table
            string password = "123456";

            var users = new List<ApplicationUser> {
                new ApplicationUser{
                    FirstName = "Salim",
                    LastName = "Yahya",
                    Email = "salim@yahya.com",
                    UserName = "salim@yahya.com",
                },
                new ApplicationUser{
                    FirstName = "Ali",
                    LastName = "Yahya",
                    Email = "ali@yahya.com",
                    UserName = "ali@yahya.com",
                },
                new ApplicationUser{
                    FirstName = "John",
                    LastName = "Doe",
                    Email = "john@doe.com",
                    UserName = "john@doe.com",
                },
                new ApplicationUser{
                    FirstName = "Jane",
                    LastName = "Doe",
                    Email = "jane@doe.com",
                    UserName = "jane@doe.com",
                },
                new ApplicationUser{
                    FirstName = "Juan",
                    LastName = "Doe",
                    Email = "juan@doe.com",
                    UserName = "juan@doe.com",
                }
            };

            // assign  password for each user
            foreach (var user in users)
            {
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    foreach (var role in roles)
                    {
                        await userManager.AddToRoleAsync(user, role.Name);
                    }
                }
            }

            ApplicationUser sellerUser1 = await userManager.FindByEmailAsync("john@doe.com");
            ApplicationUser sellerUser2 = await userManager.FindByEmailAsync("jane@doe.com");
            ApplicationUser sellerUser3 = await userManager.FindByEmailAsync("juan@doe.com");

            string[] userId = {sellerUser1.Id, sellerUser2.Id, sellerUser3.Id };

            Random random = new Random();

            var products = appDbContext.Products;

            foreach (var model in products)
            {
                model.ApplicationUserId = userId[random.Next(userId.Length)];

                var product = appDbContext.Products.Attach(model);
                product.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            }

            appDbContext.SaveChanges();
        }
    }
}
