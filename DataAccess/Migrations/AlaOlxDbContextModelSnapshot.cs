﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using OLX_Ala.Data;

#nullable disable

namespace OLXAla.Migrations
{
    [DbContext(typeof(AlaOlxDbContext))]
    partial class AlaOlxDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DataAccess.Data.Entities.Announcement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CategoryId")
                        .HasColumnType("int");

                    b.Property<string>("ContactName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Discount")
                        .HasColumnType("int");

                    b.Property<string>("ImageURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("InStock")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RegionId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("RegionId");

                    b.ToTable("Announcements");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CategoryId = 7,
                            ContactName = "Dasha",
                            Description = "The kitten is looking for a family!",
                            ImageURL = "https://ireland.apollo.olxcdn.com/v1/files/nska4awhvbf5-UA/image",
                            InStock = true,
                            Name = "Cat",
                            Phone = "0685062142",
                            Price = 30m,
                            RegionId = 15
                        },
                        new
                        {
                            Id = 2,
                            CategoryId = 7,
                            ContactName = "Dasha",
                            Description = "The puppy is looking for a family!",
                            ImageURL = "https://ireland.apollo.olxcdn.com/v1/files/giu39aqm2mrq1-UA/image",
                            InStock = false,
                            Name = "Dog",
                            Phone = "0683552144",
                            Price = 20m,
                            RegionId = 13
                        },
                        new
                        {
                            Id = 3,
                            CategoryId = 7,
                            ContactName = "Dasha",
                            Description = "The rat is looking for a family!",
                            ImageURL = "https://ireland.apollo.olxcdn.com/v1/files/1xbhsqtzmnmo-UA/image",
                            InStock = true,
                            Name = "Rat",
                            Phone = "0685062142",
                            Price = 10m,
                            RegionId = 16
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Categorys");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Help"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Children's world"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Real estate"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Car"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Spare parts"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Work"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Animals"
                        },
                        new
                        {
                            Id = 8,
                            Name = "House and garden"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Electronics"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Business and services"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Rent and hire"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Fashion and style"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Hobbies, recreation and sports"
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Region", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Regions");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Vinnitsa"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Dnipro"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Donetsk"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Zhytomyr"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Zaporizhzhia"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Ivano-Frankivsk"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Kyiv"
                        },
                        new
                        {
                            Id = 8,
                            Name = "Kropyvnytskyi"
                        },
                        new
                        {
                            Id = 9,
                            Name = "Luhansk"
                        },
                        new
                        {
                            Id = 10,
                            Name = "Lutsk"
                        },
                        new
                        {
                            Id = 11,
                            Name = "Lviv"
                        },
                        new
                        {
                            Id = 12,
                            Name = "Mykolaiv"
                        },
                        new
                        {
                            Id = 13,
                            Name = "Odesa"
                        },
                        new
                        {
                            Id = 14,
                            Name = "Poltava"
                        },
                        new
                        {
                            Id = 15,
                            Name = "Rivne"
                        },
                        new
                        {
                            Id = 16,
                            Name = "Sumy"
                        },
                        new
                        {
                            Id = 17,
                            Name = "Ternopil"
                        },
                        new
                        {
                            Id = 18,
                            Name = "Uzhhorod"
                        },
                        new
                        {
                            Id = 19,
                            Name = "Kharkiv"
                        },
                        new
                        {
                            Id = 20,
                            Name = "Kherson"
                        },
                        new
                        {
                            Id = 21,
                            Name = "Khmelnytskyi"
                        },
                        new
                        {
                            Id = 22,
                            Name = "Cherkasy"
                        },
                        new
                        {
                            Id = 23,
                            Name = "Chernivtsi"
                        },
                        new
                        {
                            Id = 24,
                            Name = "Chernihiv"
                        });
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Announcement", b =>
                {
                    b.HasOne("DataAccess.Data.Entities.Category", "category")
                        .WithMany("Announcements")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("DataAccess.Data.Entities.Region", "region")
                        .WithMany("Announcements")
                        .HasForeignKey("RegionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("category");

                    b.Navigation("region");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Category", b =>
                {
                    b.Navigation("Announcements");
                });

            modelBuilder.Entity("DataAccess.Data.Entities.Region", b =>
                {
                    b.Navigation("Announcements");
                });
#pragma warning restore 612, 618
        }
    }
}
