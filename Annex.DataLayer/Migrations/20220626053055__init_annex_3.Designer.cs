﻿// <auto-generated />
using Annex.DataLayer.Contex;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Annex.DataLayer.Migrations
{
    [DbContext(typeof(ContextAnnex))]
    [Migration("20220626053055__init_annex_3")]
    partial class _init_annex_3
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Annex.ClassDomain.Domains.Annexs", b =>
                {
                    b.Property<long>("Annex_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Annex_ID"), 1L, 1);

                    b.Property<int>("Annex_AnnexSettingID")
                        .HasColumnType("int");

                    b.Property<string>("Annex_Description")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Annex_FileNameLogic")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Annex_FileNamePhysicy")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Annex_Path")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("Annex_ReferenceFolderName")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("Annex_ReferenceID")
                        .HasColumnType("int");

                    b.HasKey("Annex_ID");

                    b.HasIndex("Annex_ReferenceID", "Annex_AnnexSettingID")
                        .IsUnique()
                        .HasDatabaseName("Index_AnnexRefSetting");

                    b.ToTable("Annex_Annexs", (string)null);
                });

            modelBuilder.Entity("Annex.ClassDomain.Domains.AnnexSetting", b =>
                {
                    b.Property<int>("AnnexSetting_ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AnnexSetting_ID"), 1L, 1);

                    b.Property<string>("AnnexSetting_ReferenceComment")
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("AnnexSetting_SystemTagID")
                        .HasColumnType("int");

                    b.Property<int>("AnnexSetting_TagsknowledgeID")
                        .HasColumnType("int");

                    b.Property<int>("AnnexSetting_TenantID")
                        .HasColumnType("int");

                    b.HasKey("AnnexSetting_ID");

                    b.ToTable("Annex_AnnexSetting", (string)null);
                });
#pragma warning restore 612, 618
        }
    }
}
