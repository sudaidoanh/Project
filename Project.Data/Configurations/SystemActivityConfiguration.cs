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
    internal class SystemActivityConfiguration : IEntityTypeConfiguration<SystemActivity>
    {
        public void Configure(EntityTypeBuilder<SystemActivity> builder)
        {
            builder.ToTable("SystemActivities");
            builder.HasKey(x => new { x.Id, x.UserId });
            builder.Property(x => x.ActionName).IsRequired().HasMaxLength(50);
            builder.Property(x => x.ClientIP).IsRequired().HasMaxLength(20);
            builder.Property(x => x.Device).IsRequired().HasMaxLength(10);
            builder.HasOne(x => x.AppUser).WithMany(c => c.SystemActivities).HasForeignKey(x => x.UserId);
        }
    }
}
