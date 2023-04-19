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
    internal class AreaUserConfiguration : IEntityTypeConfiguration<AreaUser>
    {
        public void Configure(EntityTypeBuilder<AreaUser> builder)
        {
            builder.ToTable("AreaUsers");
            builder.HasKey(x => new { x.AreaId });

            builder.HasOne(x => x.Area).WithMany(c => c.AreaUsers).HasForeignKey(c => c.AreaId);
        }
    }
}
