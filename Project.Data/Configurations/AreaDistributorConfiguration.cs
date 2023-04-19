using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Configuations
{
    public class AreaDistributorConfiguration : IEntityTypeConfiguration<AreaDistributor>
    {
        public void Configure(EntityTypeBuilder<AreaDistributor> builder)
        {
            builder.ToTable("AreaDistributors");
            builder.HasKey(x => new { x.AreaId, x.DistributorId });

            builder.HasOne(x => x.Area).WithMany(c => c.AreaDistributors).HasForeignKey(c => c.AreaId);
            builder.HasOne(x => x.Distributor).WithMany(c => c.AreaDistributors).HasForeignKey(c => c.DistributorId);

        }
    }
}
