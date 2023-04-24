using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            var ADMIN_ID = new Guid("D49CAD19-8D64-44FE-88AD-3E98FC3376EC");
            var ROLE_ID = new Guid("6755B85D-9886-4E98-89DF-FE320E6FEBD7");

            modelBuilder.Entity<AppRole>().HasData(new AppRole()
            {
                Id = ROLE_ID,
                Name = "admin",
                NormalizedName = "admin",
                Description = "Adminstrator Role",
                Action = "Admin",
            }) ;

            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(new AppUser() {
                Id = ADMIN_ID,
                UserName = "admin", 
                NormalizedUserName = "admin",
                Email = "sudaidoanh@gmail.com",
                NormalizedEmail = "sudaidoanh@gmail.com",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456a"),
                SecurityStamp = string.Empty,
                FullName = "admin",
                Address = "Ho Chi Minh City",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID,
            });
        }
    }
}
