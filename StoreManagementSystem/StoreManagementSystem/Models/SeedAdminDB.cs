using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using StoreManagementSystem.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreManagementSystem.Models
{
    public class SeedAdminDB
    {
        public static void IntializaitonAdmin(IServiceProvider serviceProvider)
        {
            using (var context = new MyDbContext(serviceProvider.GetRequiredService<DbContextOptions<MyDbContext>>()))
            {
                if (context.Users.Any())
                {
                    return;
                }
                context.Users.Add(
                    new User
                    {
                        UserName = "Admin",
                        Password = "1234",
                        ConfirmPassword = "1234",
                        UserRole = "Admin",
                        Active = true,
                        LastActionDateTime = DateTime.UtcNow

                    }
                        );
                context.SaveChanges();
            }
        }
    }
}
