using WebShop;
using WebShop.API.Helpers;
using WebShop.API.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebShop.API.Data
{
    public static class DefaultData
    {
        public static async Task PopulateAccounts(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApiDbContext>();
            var userMgr = serviceProvider.GetRequiredService<UserManager<ApiUser>>();
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!context.Users.Any())
            {
                var user = new ApiUser()
                {
                    UserName = "TestMail@gmail.com",
                    Email = "TestMail@gmail.com",
                    Name = "Matias Grimm",
                };

                await userMgr.CreateAsync(user, "P@ssw0rd1!");

                if (!await roleManager.RoleExistsAsync(AuthRoles.Admin))
                {
                    await roleManager.CreateAsync(new IdentityRole() { Name = AuthRoles.Admin });
                }

                await userMgr.AddToRolesAsync(user, new string[] { AuthRoles.Admin } );
            }
        }

        public static async Task PopulateTestData(IServiceProvider serviceProvider)
        {
            var context = serviceProvider.GetRequiredService<ApiDbContext>();
            if (!context.ShopItems.Any())
            {
                ShopItem[] itemsList = new ShopItem[12];
                itemsList[0] = new ShopItem(){
                    Title = "Product 1",
                    Description = "This is a test description",
                    Price = 250,
                    Stock = 7,
                    Bought = 373,
                    Discount = 5
                };
                itemsList[1] = new ShopItem()
                {
                    Title = "Product 2",
                    Description = "This is a test description",
                    Price = 225,
                    Stock = 2,
                    Bought = 255,
                    Discount = 7.5F
                };
                itemsList[2] = new ShopItem()
                {
                    Title = "Product 3",
                    Description = "This is a test description",
                    Price = 5551,
                    Stock = 3,
                    Bought = 358,
                    Discount = 10
                };
                itemsList[3] = new ShopItem()
                {
                    Title = "Product 4",
                    Description = "This is a test description",
                    Price = 1932,
                    Stock = 543,
                    Bought = 213,
                    Discount = 15
                };
                itemsList[4] = new ShopItem()
                {
                    Title = "Product 5",
                    Description = "This is a test description",
                    Price = 250,
                    Stock = 7,
                    Bought = 623,
                    Discount = 5
                };
                itemsList[5] = new ShopItem()
                {
                    Title = "Product 6",
                    Description = "This is a test description",
                    Price = 225,
                    Stock = 2,
                    Bought = 663,
                    Discount = 7.5F
                };
                itemsList[6] = new ShopItem()
                {
                    Title = "Product 7",
                    Description = "This is a test description",
                    Price = 5551,
                    Stock = 3,
                    Bought = 501,
                    Discount = 10
                };
                itemsList[7] = new ShopItem()
                {
                    Title = "Product 8",
                    Description = "This is a test description",
                    Price = 1932,
                    Stock = 543,
                    Bought = 772,
                    Discount = 15
                };
                itemsList[8] = new ShopItem()
                {
                    Title = "Product 9",
                    Description = "This is a test description",
                    Price = 250,
                    Stock = 7,
                    Bought = 824,
                    Discount = 5
                };
                itemsList[9] = new ShopItem()
                {
                    Title = "Product 10",
                    Description = "This is a test description",
                    Price = 225,
                    Stock = 2,
                    Bought = 627,
                    Discount = 7.5F
                };
                itemsList[10] = new ShopItem()
                {
                    Title = "Product 11",
                    Description = "This is a test description",
                    Price = 5551,
                    Stock = 3,
                    Bought = 893,
                    Discount = 10
                };
                itemsList[11] = new ShopItem()
                {
                    Title = "Product 12",
                    Description = "This is a test description",
                    Price = 1251,
                    Stock = 543,
                    Bought = 912,
                    Discount = 15
                };

                foreach (var item in itemsList)
                {
                    context.ShopItems.Add(item);
                }
                await context.SaveChangesAsync();
            }
        }
    }
}
