using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Configurations
{
    internal class AppUserRoleConfiguration : IEntityTypeConfiguration<AppUserRole>
    {
        public void Configure(EntityTypeBuilder<AppUserRole> builder)
        {
            builder.HasOne( x => x.User).WithMany(c => c.AppUserRoles).HasForeignKey(x => x.UserId);
            builder.HasOne( x => x.Role).WithMany(c => c.AppUserRoles).HasForeignKey(x => x.RoleId);

        }
    }
}
