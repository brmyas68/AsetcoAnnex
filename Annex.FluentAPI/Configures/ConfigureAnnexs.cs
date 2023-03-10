using Annex.ClassDomain.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace Annex.FluentAPI.Configures
{
    public class ConfigureAnnexs : IEntityTypeConfiguration<Annexs>
    {

        public void Configure(EntityTypeBuilder<Annexs> builder)
        {
            builder.HasKey(A => A.Annex_ID);
            builder.Property(A => A.Annex_ID).IsRequired();
            builder.Property(A => A.Annex_FileNamePhysicy).HasMaxLength(250).IsRequired();
            builder.Property(A => A.Annex_FileNameLogic).HasMaxLength(250).IsRequired();
            builder.Property(A => A.Annex_ReferenceID).IsRequired();
            builder.Property(A => A.Annex_Description).HasMaxLength(500);
            builder.Property(A => A.Annex_Path).HasMaxLength(500);
            builder.Property(A => A.Annex_FileExtension).HasMaxLength(50);
            builder.Property(A => A.Annex_ReferenceFolderName).HasMaxLength(250);
            builder.Property(A => A.Annex_AnnexSettingID).IsRequired();
            builder.Property(A => A.Annex_CreatedDate).IsRequired();


             builder.HasOne(AS => AS.AnnexSetting)
             .WithMany(A => A.Annexs).HasForeignKey(A => A.Annex_AnnexSettingID);

        }

    }

}
