using Annex.ClassDomain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Annex.FluentAPI.Configures
{
    public class ConfigureAnnexSetting : IEntityTypeConfiguration<AnnexSetting>
    {

        public void Configure(EntityTypeBuilder<AnnexSetting> builder)
        {
            builder.HasKey(AS => AS.AnnexSetting_ID);
            builder.Property(AS => AS.AnnexSetting_ID).IsRequired();
            builder.Property(AS => AS.AnnexSetting_TenantID).IsRequired();
            builder.Property(AS => AS.AnnexSetting_SystemTagID).IsRequired();
            builder.Property(AS => AS.AnnexSetting_TagsknowledgeID).IsRequired();
            builder.Property(AS => AS.AnnexSetting_KeyWord).HasMaxLength(100).IsRequired();
            builder.Property(AS => AS.AnnexSetting_ReferenceComment).HasMaxLength(250);
            builder.Property(AS => AS.AnnexSetting_Dec).HasMaxLength(350);

            builder.HasMany(A => A.Annexs)
           .WithOne(As => As.AnnexSetting);

        }
    }
}
