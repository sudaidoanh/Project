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
    internal class MediaTaskConfiguration : IEntityTypeConfiguration<MediaTask>
    {
        public void Configure(EntityTypeBuilder<MediaTask> builder)
        {
            builder.ToTable("MediaTasks");
            builder.HasKey(x => new { x.Id, x.TaskId });
            builder.Property(x => x.Id).UseIdentityColumn();

            builder.Property(x => x.MediaType).IsRequired();
            builder.Property(x => x.SrcFile).IsRequired();

        }
    }
}
