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
    internal class SurveyConfiguration : IEntityTypeConfiguration<Survey>
    {
        public void Configure(EntityTypeBuilder<Survey> builder)
        {
            builder.ToTable("Surveys");
            builder.HasKey(x => new { x.Id, x.UserCreate });
            builder.Property(x => x.Title).IsRequired().HasMaxLength(60);
            builder.HasOne(x => x.AppUser).WithMany(c => c.Surveyes).HasForeignKey(c => c.UserCreate);
        }
    }
}
