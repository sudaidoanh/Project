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
    public class SubmitedSurveyedAnswerConfiguration : IEntityTypeConfiguration<SubmitedSurveyedAnswer>
    {
        public void Configure(EntityTypeBuilder<SubmitedSurveyedAnswer> builder)
        {
            builder.ToTable("SubmitedSurveyedAnswers");
            builder.HasKey(x => new { x.SubmitedSurveyedId, x.QuestionnaireDetailId });
            builder.Property(x => x.Answer).IsRequired();
            builder.HasOne(x => x.QuestionnaireDetail).WithMany(c => c.SubmitedSurveyedAnswers).HasForeignKey(x => x.QuestionnaireDetailId);
            builder.HasOne(x => x.SubmitedSurveyed).WithMany(c => c.SubmitedSurveyedAnswer).HasForeignKey(x => x.SubmitedSurveyedId);
        }
    }
}
