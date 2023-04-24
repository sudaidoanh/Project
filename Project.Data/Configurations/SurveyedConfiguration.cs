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
    internal class SurveyedConfiguration : IEntityTypeConfiguration<Surveyed>
    {
        public void Configure(EntityTypeBuilder<Surveyed> builder)
        {
            builder.ToTable("Surveyeds");
            builder.HasKey(x => new {x.Id, x.SurveyId, x.UserId});
            builder.Property(x => x.Status).IsRequired().HasMaxLength(20);
            builder.HasOne(x => x.AppUser).WithMany(c => c.Surveyeds).HasForeignKey(c => c.UserId);
        }
    }
}
