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
    public class QuestionnaireDetailConfiguration : IEntityTypeConfiguration<QuestionnaireDetail>
    {
        public void Configure(EntityTypeBuilder<QuestionnaireDetail> builder)
        {
            builder.ToTable("QuestionnaireDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Question).IsRequired().HasMaxLength(100);
            builder.Property(x => x.Answers).IsRequired().HasMaxLength(300);
            builder.Property(x => x.TypeAnswer).IsRequired();
        }
    }
}
