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
    public class PostImageConfiguration : IEntityTypeConfiguration<PostImage>
    {
        public void Configure(EntityTypeBuilder<PostImage> builder)
        {
            builder.ToTable("PostImages");
            builder.HasKey(x => new { x.Id, x.PostId });
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Post).WithMany(c => c.PostImages).HasForeignKey(x => x.PostId);
            builder.Property(x => x.ImagePath).HasMaxLength(256);
        }
    }
}
