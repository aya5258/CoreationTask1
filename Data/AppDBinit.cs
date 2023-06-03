using Microsoft.AspNetCore.Identity;
using ProductCustomer.Models;
using System;
using System.Xml.Linq;

namespace ProductCustomer.Data
{
    public class AppDBinit
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<PCContex>();
                 
                context.Database.EnsureCreated();

                //Customer
                if (!context.customers.Any())
                {
                    context.customers.AddRange(new List<Customer>()
                    {
                        new Customer()
                        {
                        FullName="Aia kamel ezz",
                        Mobile="01020874798",
                        address="mansoura"
                        },
                        new Customer()
                        {
                        FullName="zeniab",
                        Mobile="01076243984",
                        address="mansoura"
                        },
                        new Customer()
                        {
                             FullName="kamel",
                        Mobile="01067533894",
                        address="dumiatt"
                        },
                        new Customer()
                        {
                         FullName="Adrsh",
                        Mobile="01087543786",
                        address="sherbin"
                        },
                        new Customer()
                        {
                         FullName="osama",
                        Mobile="01020874798",
                        address="mansoura"
                        },
                    });
                    context.SaveChanges();
                }
                //Products
                if (!context.products.Any())
                {
                    context.products.AddRange(new List<Product>()
                    {
                        new Product()
                        {
                        Name="carpet",
                        Price=2000

                        },
                        new Product()
                        {
                              Name="TV",
                        Price=9000
                        },
                        new Product()
                        {
                          Name="fan",
                        Price=600
                        },
                        new Product()
                        {
                              Name="cups",
                        Price=500
                        },
                        new Product()
                        {
                             Name="watch",
                        Price=800
                        }
                    });
                    context.SaveChanges();
                }
           
              
          
            }

        }

        public static async Task SeedUsersAndRolesAsync(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {

                //Roles
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                if (!await roleManager.RoleExistsAsync(UserRoles.User))
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                //Users
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();
                string adminUserEmail = "admin@PC.com";

                var adminUser = await userManager.FindByEmailAsync(adminUserEmail);
                if (adminUser == null)
                {
                    var newAdminUser = new ApplicationUser()
                    {
             
                        UserName = "admin-user",
                        Email = adminUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAdminUser, "Admin123");
                    await userManager.AddToRoleAsync(newAdminUser, UserRoles.Admin);
                }


                string appUserEmail = "user@PC.com";

                var appUser = await userManager.FindByEmailAsync(appUserEmail);
                if (appUser == null)
                {
                    var newAppUser = new ApplicationUser()
                    {
          
                        UserName = "app-user",
                        Email = appUserEmail,
                        EmailConfirmed = true
                    };
                    await userManager.CreateAsync(newAppUser, "User123");
                    await userManager.AddToRoleAsync(newAppUser, UserRoles.User);
                }
            }
        }
    }

}
