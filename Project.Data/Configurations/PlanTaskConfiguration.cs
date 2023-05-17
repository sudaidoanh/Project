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
    public class PlanTaskConfiguration : IEntityTypeConfiguration<PlanTask>
    {
        public void Configure(EntityTypeBuilder<PlanTask> builder)
        {
            builder.ToTable("PlanTasks");
            builder.HasKey(x => new { x.PlanId, x.TaskId });
            builder.HasOne(x => x.Plan).WithMany(c => c.PlanTasks).HasForeignKey(x => x.PlanId);
            builder.HasOne(x => x.Task).WithMany(c => c.PlanTasks).HasForeignKey(x => x.TaskId);
        }
    }
}
