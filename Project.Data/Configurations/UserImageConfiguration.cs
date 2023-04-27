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
    internal class UserImageConfiguration : IEntityTypeConfiguration<UserImage>
    {
        public void Configure(EntityTypeBuilder<UserImage> builder)
        {
            builder.ToTable("UserImages");
            builder.HasKey(x => new { x.Id, x.UserId });
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.User).WithMany(c => c.UserImages).HasForeignKey(x => x.UserId);
            builder.Property(x => x.ImagePath).HasMaxLength(256);

        }
    }
}
