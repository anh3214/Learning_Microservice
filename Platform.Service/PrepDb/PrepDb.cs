using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Platform.Domain;
using Platform.Service.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform.Service.PrepDb
{
    public static class PrepDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("----> Seeding Data...!");
                context.Platforms.AddRange(
                    new PlatformModel() { Name = "Dot Net", Publisher = "Microsoft", Cost = "Free" },
                    new PlatformModel() { Name = "SQL Server Express", Publisher = "Microsoft", Cost = "Free" },
                    new PlatformModel() { Name = "Kubernetes", Publisher = "Clound Native Computing Foundation", Cost = "Free" });
                context.SaveChanges();
            }
        }
    }
}
