﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistance.Contexts;

#nullable disable

namespace Persistance.Migrations
{
    [DbContext(typeof(SQLDbContext))]
    [Migration("20230903194415_BankIbanAccount")]
    partial class BankIbanAccount
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Domain.Entities.Concrete.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("AddressDescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AddressDescription");

                    b.Property<string>("AddressName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("AddressName");

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId");

                    b.ToTable("Addresses", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Concrete.BankIbanAccount", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Code");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Country");

                    b.Property<int>("Length")
                        .HasColumnType("int")
                        .HasColumnName("Length");

                    b.HasKey("Id");

                    b.ToTable("BankIbanAccounts", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Concrete.BankIbanAccountImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("BankIbanAccountId")
                        .HasColumnType("int")
                        .HasColumnName("BankIbanAccountId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImagePath");

                    b.HasKey("Id");

                    b.HasIndex("BankIbanAccountId")
                        .IsUnique();

                    b.ToTable("BankIbanAccountImages", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Concrete.CompanyInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("CompanyEmail")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyEmail");

                    b.Property<string>("CompanyLogoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyLogoPath");

                    b.Property<string>("CompanyName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyName");

                    b.Property<string>("CompanyTelephoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyTelephoneNumber");

                    b.Property<string>("CompanyTitle")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyTitle");

                    b.Property<string>("CompanyWebSiteUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("CompanyWebsiteUrl");

                    b.Property<string>("Info")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("Info");

                    b.Property<int>("SectorId")
                        .HasColumnType("int")
                        .HasColumnName("SectorId");

                    b.Property<string>("TaxInfo")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TaxInfo");

                    b.Property<string>("TaxNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("TaxNumber");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("UserId");

                    b.HasKey("Id");

                    b.HasIndex("SectorId");

                    b.ToTable("CompanyInfos", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Concrete.CompanyInfoImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Id");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("CompanyId")
                        .HasColumnType("int")
                        .HasColumnName("CompanyId");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2")
                        .HasColumnName("Date");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("ImagePath");

                    b.HasKey("Id");

                    b.HasIndex("CompanyId")
                        .IsUnique();

                    b.ToTable("CompanyInfoImages", (string)null);
                });

            modelBuilder.Entity("Domain.Entities.Concrete.Sector", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("SectorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("Domain.Entities.Concrete.Address", b =>
                {
                    b.HasOne("Domain.Entities.Concrete.CompanyInfo", "Company")
                        .WithMany("Addresses")
                        .HasForeignKey("CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Company");
                });

            modelBuilder.Entity("Domain.Entities.Concrete.BankIbanAccountImage", b =>
                {
                    b.HasOne("Domain.Entities.Concrete.BankIbanAccount", "BankIbanAccount")
                        .WithOne("BankIbanAccountImage")
                        .HasForeignKey("Domain.Entities.Concrete.BankIbanAccountImage", "BankIbanAccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BankIbanAccount");
                });

            modelBuilder.Entity("Domain.Entities.Concrete.CompanyInfo", b =>
                {
                    b.HasOne("Domain.Entities.Concrete.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Sector");
                });

            modelBuilder.Entity("Domain.Entities.Concrete.CompanyInfoImage", b =>
                {
                    b.HasOne("Domain.Entities.Concrete.CompanyInfo", "CompanyInfo")
                        .WithOne("CompanyInfoImage")
                        .HasForeignKey("Domain.Entities.Concrete.CompanyInfoImage", "CompanyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CompanyInfo");
                });

            modelBuilder.Entity("Domain.Entities.Concrete.BankIbanAccount", b =>
                {
                    b.Navigation("BankIbanAccountImage");
                });

            modelBuilder.Entity("Domain.Entities.Concrete.CompanyInfo", b =>
                {
                    b.Navigation("Addresses");

                    b.Navigation("CompanyInfoImage");
                });
#pragma warning restore 612, 618
        }
    }
}
