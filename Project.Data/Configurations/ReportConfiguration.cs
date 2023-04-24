using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Project.Data.Configurations
{
    internal class ReportConfiguration : IEntityTypeConfiguration<Report>
    {
        public void Configure(EntityTypeBuilder<Report> builder)
        {
            builder.ToTable("Reports");
            builder.HasKey(x => new { x.Id, x.UserId, x.Manager });
            builder.Property(x => x.Status).IsRequired().HasMaxLength(10);
            builder.HasOne(x => x.AppUser).WithMany(c => c.Reports).HasForeignKey(c => c.UserId);
            builder.HasOne(x => x.AppUser).WithMany(c => c.Reports).HasForeignKey(c => c.Manager);
        }
    }
}
