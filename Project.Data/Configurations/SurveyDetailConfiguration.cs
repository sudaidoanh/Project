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
    internal class SurveyDetailConfiguration : IEntityTypeConfiguration<SurveyDetail>
    {
        public void Configure(EntityTypeBuilder<SurveyDetail> builder)
        {
            builder.ToTable("SurveyDetails");
            builder.HasKey(x => new { x.Id, x.SurveyId });
            builder.Property(x => x.Question).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Answers).IsRequired().HasMaxLength(300);

        }
    }
}
