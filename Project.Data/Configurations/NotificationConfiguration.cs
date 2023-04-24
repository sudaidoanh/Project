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
    internal class NotificationConfiguration : IEntityTypeConfiguration<Notification>
    {
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.ToTable("Notifications");
            builder.HasKey(x => new { x.Id, x.SenderId});
            builder.Property(x => x.Header).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Status).IsRequired().HasMaxLength(20);
            builder.HasOne(x => x.AppUser).WithMany(c => c.Notifications).HasForeignKey(c => c.SenderId);


        }
    }
}
