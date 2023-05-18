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
    public class SubmitSurveyedConfiguration : IEntityTypeConfiguration<SubmitedSurveyed>
    {
        public void Configure(EntityTypeBuilder<SubmitedSurveyed> builder)
        {
            builder.ToTable("SubmitedSurveyeds");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.QuestionnaireDetailId).IsRequired();
            builder.Property(x => x.SurveyedId).IsRequired();
            builder.Property(x => x.Email).IsRequired();
            builder.Property(x => x.Answer).IsRequired();

        }
    }
}
