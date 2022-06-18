using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using mvc_ticket_theater.Data.Static;
using mvc_ticket_theater.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mvc_ticket_theater.Data
{
    public class AppDbInit
    {
        public static async Task SeedUsersAndRolesAdync(IApplicationBuilder appBuilder)
        {
            using (var serviceScope = appBuilder.ApplicationServices.CreateScope())
            {
                var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                if (!await roleManager.RoleExistsAsync(UserRoles.Admin))
                
                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.Admin));
                                   
                }
                if (!await roleManager.RoleExistsAsync(UserRoles.User))

                {
                    await roleManager.CreateAsync(new IdentityRole(UserRoles.User));

                }

                //Users
                #region admin user 
                var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
                string AdminMail = "zuhal@sahnedenevar.com";
                var adminUser = await userManager.FindByEmailAsync(AdminMail);
                if (adminUser == null)
                {
                    var newAdmin = new AppUser()
                    {
                        FullName = "Zuhal ALANLAR",
                        UserName = "Zuhal",
                        Email = AdminMail,
                        EmailConfirmed = true

                    };

                    await userManager.CreateAsync(newAdmin, "zuhal123?");
                    await userManager.AddToRoleAsync(newAdmin, UserRoles.Admin);

                }

                #endregion

       
                string userMail = "user@sahnedenevar.com";
                var User = await userManager.FindByEmailAsync(userMail);
                if (User == null)
                {
                    var newUser = new AppUser()
                    {
                        FullName = "User User",
                        UserName = "User",
                        Email = userMail,
                        EmailConfirmed = true

                    };

                    await userManager.CreateAsync(newUser, "zuhal123?");
                    await userManager.AddToRoleAsync(newUser, UserRoles.User);

                }



            }






        }

    }
}
