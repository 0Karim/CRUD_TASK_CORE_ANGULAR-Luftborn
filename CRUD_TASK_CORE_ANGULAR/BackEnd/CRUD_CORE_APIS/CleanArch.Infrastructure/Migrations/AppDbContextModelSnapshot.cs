﻿// <auto-generated />
using System;
using CleanArch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CleanArch.Infrastructure.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.1");

            modelBuilder.Entity("CleanArch.Domain.Entities.AddressInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("BuildingNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CityId")
                        .HasColumnType("int");

                    b.Property<int?>("GovId")
                        .HasColumnType("int");

                    b.Property<string>("Street")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CityId");

                    b.HasIndex("GovId");

                    b.ToTable("AddressInfo");
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.City", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("CityName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("City");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CityName = "Cairo"
                        },
                        new
                        {
                            Id = 2,
                            CityName = "Alex"
                        },
                        new
                        {
                            Id = 3,
                            CityName = "Assuit"
                        });
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.Governate", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("GovName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Governate");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            GovName = "Egypt"
                        },
                        new
                        {
                            Id = 2,
                            GovName = "Saudi"
                        },
                        new
                        {
                            Id = 3,
                            GovName = "France"
                        });
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.User", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int?>("AddressId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MobileNumber")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AddressId")
                        .IsUnique()
                        .HasFilter("[AddressId] IS NOT NULL");

                    b.ToTable("User");
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.AddressInfo", b =>
                {
                    b.HasOne("CleanArch.Domain.Entities.City", "City")
                        .WithMany()
                        .HasForeignKey("CityId");

                    b.HasOne("CleanArch.Domain.Entities.Governate", "Governate")
                        .WithMany()
                        .HasForeignKey("GovId");

                    b.Navigation("City");

                    b.Navigation("Governate");
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.User", b =>
                {
                    b.HasOne("CleanArch.Domain.Entities.AddressInfo", "UserAddress")
                        .WithOne("Users")
                        .HasForeignKey("CleanArch.Domain.Entities.User", "AddressId");

                    b.Navigation("UserAddress");
                });

            modelBuilder.Entity("CleanArch.Domain.Entities.AddressInfo", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}