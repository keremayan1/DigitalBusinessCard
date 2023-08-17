﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebAPI.Persistance.Contexts;

#nullable disable

namespace WebAPI.Migrations
{
    [DbContext(typeof(MySQLDbContext))]
    [Migration("20230817201141_inital")]
    partial class inital
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebAPI.Domain.Entities.Crypto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<string>("CryptoName")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("crypto_name");

                    b.HasKey("Id");

                    b.ToTable("cryptos", (string)null);
                });

            modelBuilder.Entity("WebAPI.Domain.Entities.CryptoImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CryptoId")
                        .HasColumnType("int")
                        .HasColumnName("crypto_id");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime(6)")
                        .HasColumnName("date");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("image_path");

                    b.HasKey("Id");

                    b.HasIndex("CryptoId")
                        .IsUnique();

                    b.ToTable("crypto_images", (string)null);
                });

            modelBuilder.Entity("WebAPI.Domain.Entities.UserCyrpto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id");

                    b.Property<int>("CryptoId")
                        .HasColumnType("int")
                        .HasColumnName("crypto_id");

                    b.Property<string>("CryptoUrl")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("crypto_url");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("longtext")
                        .HasColumnName("user_id");

                    b.HasKey("Id");

                    b.HasIndex("CryptoId");

                    b.ToTable("user_crypto", (string)null);
                });

            modelBuilder.Entity("WebAPI.Domain.Entities.CryptoImage", b =>
                {
                    b.HasOne("WebAPI.Domain.Entities.Crypto", "Crypto")
                        .WithOne("CryptoImage")
                        .HasForeignKey("WebAPI.Domain.Entities.CryptoImage", "CryptoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crypto");
                });

            modelBuilder.Entity("WebAPI.Domain.Entities.UserCyrpto", b =>
                {
                    b.HasOne("WebAPI.Domain.Entities.Crypto", "Crypto")
                        .WithMany("UserCyrptos")
                        .HasForeignKey("CryptoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Crypto");
                });

            modelBuilder.Entity("WebAPI.Domain.Entities.Crypto", b =>
                {
                    b.Navigation("CryptoImage");

                    b.Navigation("UserCyrptos");
                });
#pragma warning restore 612, 618
        }
    }
}