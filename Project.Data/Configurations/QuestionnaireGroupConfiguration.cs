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
    public class QuestionnaireGroupConfiguration : IEntityTypeConfiguration<QuestionnaireGroup>
    {
        public void Configure(EntityTypeBuilder<QuestionnaireGroup> builder)
        {
            builder.ToTable("QuestionnaireGroups");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired().HasMaxLength(30);
        }
    }
}
