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
    internal class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");
            builder.HasKey(x => new { x.Id, x.UserId});
            builder.Property(x => x.Title).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Header).IsRequired().HasMaxLength(60);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(200);
            builder.Property(x => x.Display).IsRequired();
            builder.HasOne(x => x.AppUser).WithMany(c => c.Posts).HasForeignKey(c => c.UserId);
        }
    }
}
