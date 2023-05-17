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
    public class PlanDetailConfiguration : IEntityTypeConfiguration<PlanDetail>
    {
        public void Configure(EntityTypeBuilder<PlanDetail> builder)
        {
            builder.ToTable("PlanDetails");
            builder.HasKey( x => new { x.Id, x.PlanId });
            builder.Property(x => x.Status).IsRequired();
            builder.HasOne(x => x.Plan).WithMany(c => c.PlanDetails).HasForeignKey(x => x.PlanId);
        }
    }
}
