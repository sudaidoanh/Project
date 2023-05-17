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
            var ADMIN_ROLE_ID = new Guid("6755B85D-9886-4E98-89DF-FE320E6FEBD7");

            var OWNER_ID = new Guid("DEABD869-B037-48F5-9201-052F23F01CA8");
            var OWNER_ROLE_ID = new Guid("BED15C1F-B73A-4301-97B8-65FB4F54D1A0");

            var GUEST_ROLE_ID = new Guid("240E615A-2FA4-468A-8728-C3C9C7D3DB58");
            var GUEST_ID = new Guid("0D80C014-4959-4D4D-B699-8C10192AFC15");

            modelBuilder.Entity<AppRole>().HasData(new AppRole()
            {
                Id = ADMIN_ROLE_ID,
                Name = "Adminstrator",
                NormalizedName = "Adminstrator",
                Description = "Adminstrator Role",
                Action = "Adminstrator",
            }) ;

            modelBuilder.Entity<AppRole>().HasData(new AppRole()
            {
                Id = OWNER_ROLE_ID,
                Name = "Owner",
                NormalizedName = "Owner",
                Description = "Manage all the system setting, include the user permission.",
                Action = "Owner",
            });

            modelBuilder.Entity<AppRole>().HasData(new AppRole()
            {
                Id = GUEST_ROLE_ID,
                Name = "Guest",
                NormalizedName = "Guest",
                Description = "Guest Role",
                Action = "Guest",
            });

            var hasher = new PasswordHasher<AppUser>();

            modelBuilder.Entity<AppUser>().HasData(new AppUser() {
                Id = ADMIN_ID,
                UserName = "admin", 
                NormalizedUserName = "admin",
                Email = "admin@domain.com",
                NormalizedEmail = "admin@domain.com",
                AccessFailedCount = 10,
                Status = Enums.Status.Active,
                PhoneNumber = "1234567890",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456a"),
                SecurityStamp = string.Empty,
                FullName = "Adminstrator",
                Address = "Ho Chi Minh City",
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = OWNER_ID,
                UserName = "onwer",
                NormalizedUserName = "owner",
                Email = "owner@domain.com",
                NormalizedEmail = "owner@domain.com",
                AccessFailedCount = 10,
                Status = Enums.Status.Active,
                PhoneNumber = "0122222222",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456a"),
                SecurityStamp = string.Empty,
                FullName = "Owner",
                Address = "Ho Chi Minh City",
            });

            modelBuilder.Entity<AppUser>().HasData(new AppUser()
            {
                Id = GUEST_ID,
                UserName = "doanh",
                NormalizedUserName = "doanh",
                Email = "sudaidoanh@gmail.com",
                NormalizedEmail = "sudaidoanh@gmail.com",
                AccessFailedCount = 10,
                Status = Enums.Status.Active,
                PhoneNumber = "0967145696",
                PhoneNumberConfirmed = true,
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "123456aA@"),
                SecurityStamp = string.Empty,
                FullName = "Su Dai Doanh",
                Address = "Dong Ha Quang Tri",
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = ADMIN_ROLE_ID,
                UserId = ADMIN_ID,
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = OWNER_ROLE_ID,
                UserId = OWNER_ID,
            });

            modelBuilder.Entity<IdentityUserRole<Guid>>().HasData(new IdentityUserRole<Guid>
            {
                RoleId = GUEST_ROLE_ID,
                UserId = GUEST_ID,
            });

            modelBuilder.Entity<Area>().HasData(new Area()
            {
                Id = 1,
                Name = "Area 1",
                Code = "COD1",
            });

            modelBuilder.Entity<Area>().HasData(new Area()
            {
                Id = 2,
                Name = "Area 2",
                Code = "COD2",
            });

            modelBuilder.Entity<Area>().HasData(new Area()
            {
                Id = 3,
                Name = "Area 3",
                Code = "COD3",
            });

            modelBuilder.Entity<AreaUser>().HasData(new AreaUser()
            {
                UserId = ADMIN_ID,
                AreaId = 1,
            });

            modelBuilder.Entity<AreaUser>().HasData(new AreaUser()
            {
                UserId = OWNER_ID,
                AreaId = 1,
            });

            modelBuilder.Entity<AreaUser>().HasData(new AreaUser()
            {
                UserId = GUEST_ID,
                AreaId = 3,
            });

            modelBuilder.Entity<Distributor>().HasData(new Distributor()
            {
                Id = 1,
                Address = "154 Hoa Binh, Hiep Tan, Tan Phu",
                Email = "email1@domain.com",
                Name = "Distributor 1",
                Phone = "0938387228"
            });

            modelBuilder.Entity<AreaDistributor>().HasData(new AreaDistributor()
            {
                AreaId = 1,
                DistributorId = 1
            });
        }
    }
}
