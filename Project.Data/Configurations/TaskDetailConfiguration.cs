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
    internal class TaskDetailConfiguration : IEntityTypeConfiguration<TaskDetail>
    {
        public void Configure(EntityTypeBuilder<TaskDetail> builder)
        {
            builder.ToTable("TaskDetails");
            builder.HasKey(x => new { x.Id, x.UserComment});
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Status).IsRequired();
            builder.Property(x => x.Rating).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(c => c.TaskDetails).HasForeignKey(c => c.UserComment);
            //builder.HasOne(x => x.Task).WithMany(c => c.TaskDetails).HasForeignKey(c => c.IdTask);
        }
    }
}
