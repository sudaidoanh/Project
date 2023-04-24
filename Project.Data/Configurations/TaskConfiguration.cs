using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Project.Data.Entities;

namespace Project.Data.Configurations
{
    internal class TaskConfiguration : IEntityTypeConfiguration<Entities.Task>
    {
        public void Configure(EntityTypeBuilder<Entities.Task> builder)
        {
            builder.ToTable("Tasks");
            builder.HasKey(x => new { x.Id, x.UserAskTaskId });
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.Title).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(300);
            builder.HasOne(x => x.AppUser).WithMany(c => c.Tasks).HasForeignKey(x => x.UserAskTaskId);
        }
    }
}
