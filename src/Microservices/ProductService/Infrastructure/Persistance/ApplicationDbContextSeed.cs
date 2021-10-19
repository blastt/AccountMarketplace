using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistance
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SeedSampleDataAsync(ApplicationDbContext context)
        {
            // Seed, if necessary
            if (!context.Products.Any())
            {
                context.Products.Add(new Product
                {
                    Header = "Test header",
                    Description = "Test description",
                    Login = "mylogin111",
                    Price = 1000
                });

                await context.SaveChangesAsync();
            }
        }
    }
}
