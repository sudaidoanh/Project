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
    internal class PlanConfiguration : IEntityTypeConfiguration<Plan>
    {
        public void Configure(EntityTypeBuilder<Plan> builder)
        {
            builder.ToTable("Plans");
            builder.HasKey(x => new { x.Id, x.UserId, x.DistributorId, x.Invited});
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Name).IsRequired().HasMaxLength(100).IsUnicode(false);
            builder.Property(x => x.TypeDate).IsRequired().HasMaxLength(20).IsUnicode(false);
            builder.Property(x => x.TypeUser).IsRequired().HasMaxLength(30).IsUnicode(false);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(10);
            builder.HasOne(x => x.AppUser).WithMany(c => c.Plans).HasForeignKey(c => c.UserId);
            builder.HasOne(x => x.AppUser).WithMany(c => c.Plans).HasForeignKey(c => c.Invited);
            builder.HasOne(x => x.Distributor).WithMany(c => c.Plans).HasForeignKey(c => c.DistributorId);

        }
    }
}
