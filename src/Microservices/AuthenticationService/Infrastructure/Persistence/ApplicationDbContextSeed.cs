using Infrastructure.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedDefaultUserAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            var administratorRole = new IdentityRole("Administrator");
            var sellerRole = new IdentityRole("Seller");
            var buyerRole = new IdentityRole("Buyer");

            if (roleManager.Roles.All(r => r.Name != administratorRole.Name))
            {
                await roleManager.CreateAsync(administratorRole);
                await roleManager.CreateAsync(sellerRole);
                await roleManager.CreateAsync(buyerRole);
            }

            var administrator = new ApplicationUser { UserName = "admin", Email = "administrator@localhost" };
            var seller = new ApplicationUser { UserName = "seller", Email = "seller@localhost" };
            var buyer = new ApplicationUser { UserName = "buyer", Email = "buyer@localhost" };

            if (userManager.Users.All(u => u.UserName != administrator.UserName))
            {
                await userManager.CreateAsync(administrator, "Administrator1@");
                await userManager.AddToRolesAsync(administrator, new[] { administratorRole.Name });

                await userManager.CreateAsync(seller, "Seller1@");
                await userManager.AddToRolesAsync(seller, new[] { sellerRole.Name });

                await userManager.CreateAsync(buyer, "Buyer1@");
                await userManager.AddToRolesAsync(buyer, new[] { buyerRole.Name });
            }
        }
    }
}
