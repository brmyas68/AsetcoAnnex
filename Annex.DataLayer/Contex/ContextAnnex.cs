


using Annex.ClassDomain.Domains;
using Annex.FluentAPI.Configures;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Annex.DataLayer.Contex
{
    public class ContextAnnex : DbContext
    {
        public DbSet<Annexs> Annexs { get; set; }
        public DbSet<AnnexSetting> AnnexSetting { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Change Table Name
            modelBuilder.Entity<Annexs>().ToTable("Annex_Annexs");
            modelBuilder.Entity<AnnexSetting>().ToTable("Annex_AnnexSetting");

            // Indexs
            //modelBuilder.Entity<Annexs>().HasIndex(A => new { A.Annex_ReferenceID, A.Annex_AnnexSettingID })
            //     .HasDatabaseName("Index_AnnexRefSetting").IsUnique();

            //Set  Configuration
            modelBuilder.ApplyConfiguration(new ConfigureAnnexs());
            modelBuilder.ApplyConfiguration(new ConfigureAnnexSetting());

        }
        public ContextAnnex(DbContextOptions<ContextAnnex> options)
       : base(options)
        { }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var Configuration = new ConfigurationBuilder()
                              .SetBasePath(Directory.GetCurrentDirectory())
                              .AddJsonFile("appsettings.json")
                              .Build();

            var SqlConnectionString = Configuration.GetConnectionString("AppDbAnnex");
            optionsBuilder.UseSqlServer(SqlConnectionString);
        }
    }
}
