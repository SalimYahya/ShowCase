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
                    Name="Admin",
                    NormalizedName ="ADMIN"
                },
                new IdentityRole
                {
                    Name="Customer",
                    NormalizedName="CUSTOMER"
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
                }
            };

            // assign  password for each user
            foreach (var user in users)
            {
                var result = await userManager.CreateAsync(user);
                if (result.Succeeded)
                {
                    await userManager.AddPasswordAsync(user, password);
                    await userManager.AddToRoleAsync(user, roles[1].Name);
                }
            }
        }
    }
}
