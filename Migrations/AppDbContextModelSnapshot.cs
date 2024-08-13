﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using WEBAPP_ANGULAR_DOTNET.Data;

#nullable disable

namespace WEBAPP_ANGULAR_DOTNET.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("WEBAPP_ANGULAR_DOTNET.Data.Models.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.Property<int>("BookType")
                        .HasColumnType("integer");

                    b.Property<DateTime?>("DateEnd")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateRead")
                        .HasColumnType("timestamp with time zone");

                    b.Property<DateTime?>("DateStart")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("character varying(500)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasMaxLength(21)
                        .HasColumnType("character varying(21)");

                    b.Property<int>("PublisherId")
                        .HasColumnType("integer");

                    b.Property<double?>("Rate")
                        .HasColumnType("double precision");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("Id");

                    b.HasIndex("PublisherId");

                    b.ToTable("Books");

                    b.HasDiscriminator().HasValue("Book");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("WEBAPP_ANGULAR_DOTNET.Data.Models.Publisher", b =>
                {
                    b.Property<int>("PublisherId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("PublisherId"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("character varying(255)");

                    b.HasKey("PublisherId");

                    b.ToTable("Publisher");
                });

            modelBuilder.Entity("WEBAPP_ANGULAR_DOTNET.Data.Models.Categories.BiographyBook", b =>
                {
                    b.HasBaseType("WEBAPP_ANGULAR_DOTNET.Data.Models.Book");

                    b.Property<string>("Subject")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("TimePeriod")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("BiographyBook");
                });

            modelBuilder.Entity("WEBAPP_ANGULAR_DOTNET.Data.Models.Categories.CryptoCurrencyBook", b =>
                {
                    b.HasBaseType("WEBAPP_ANGULAR_DOTNET.Data.Models.Book");

                    b.Property<string>("CurrencyType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("MarketTrend")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("CryptoCurrencyBook");
                });

            modelBuilder.Entity("WEBAPP_ANGULAR_DOTNET.Data.Models.Categories.InvestmentBook", b =>
                {
                    b.HasBaseType("WEBAPP_ANGULAR_DOTNET.Data.Models.Book");

                    b.Property<string>("InvestmentType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Strategy")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasDiscriminator().HasValue("InvestmentBook");
                });

            modelBuilder.Entity("WEBAPP_ANGULAR_DOTNET.Data.Models.Book", b =>
                {
                    b.HasOne("WEBAPP_ANGULAR_DOTNET.Data.Models.Publisher", "Publisher")
                        .WithMany("Books")
                        .HasForeignKey("PublisherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Publisher");
                });

            modelBuilder.Entity("WEBAPP_ANGULAR_DOTNET.Data.Models.Publisher", b =>
                {
                    b.Navigation("Books");
                });
#pragma warning restore 612, 618
        }
    }
}
