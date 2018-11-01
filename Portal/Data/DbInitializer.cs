using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Portal.Data;
using Portal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PortalAspCore.Data
{
    public class DbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serv = applicationBuilder.ApplicationServices.CreateScope())
            {
                ApplicationDbContext context = serv.ServiceProvider.GetService<ApplicationDbContext>();

                var roleManager = serv.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var userManager = serv.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();


                Task<IdentityResult> roleResult;
                string email = "Administrator@Hotmail.com";

                //Check that there is an Administrator role and create if not
                Task<bool> hasAdminRole = roleManager.RoleExistsAsync("Administrator");
                hasAdminRole.Wait();

                if (!hasAdminRole.Result)
                {
                    roleResult = roleManager.CreateAsync(new IdentityRole("Administrator"));
                    roleResult.Wait();
                }

                hasAdminRole = roleManager.RoleExistsAsync("User");
                hasAdminRole.Wait();

                if (!hasAdminRole.Result)
                {
                    roleResult = roleManager.CreateAsync(new IdentityRole("User"));
                    roleResult.Wait();
                }


                //Check if the admin user exists and create it if not
                //Add to the Administrator role

                Task<ApplicationUser> testUser = userManager.FindByEmailAsync(email);
                testUser.Wait();

                if (testUser.Result == null)
                {
                    ApplicationUser administrator = new ApplicationUser();
                    administrator.Email = email;
                    administrator.UserName = "Administrator";

                    Task<IdentityResult> newUser = userManager.CreateAsync(administrator, "Ab-123456");
                    newUser.Wait();

                    if (newUser.Result.Succeeded)
                    {
                        Task<IdentityResult> newUserRole = userManager.AddToRoleAsync(administrator, "Administrator");
                        newUserRole.Wait();
                    }
                }
                context.SaveChanges();
            }
        }

    }
}
