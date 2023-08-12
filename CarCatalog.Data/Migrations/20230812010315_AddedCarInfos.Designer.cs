﻿// <auto-generated />
using System;
using CarCatalog.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CarCatalog.Data.Migrations
{
    [DbContext(typeof(CarCatalogDbContext))]
    [Migration("20230812010315_AddedCarInfos")]
    partial class AddedCarInfos
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.21")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("CarCatalog.Data.Models.ApplicationUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasDefaultValue("Test");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)")
                        .HasDefaultValue("Testov");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Data.Models.Car", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ApplicationUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("BuyerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int?>("CarDealerId")
                        .HasColumnType("int");

                    b.Property<Guid>("CarInfoId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("SellerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ApplicationUserId");

                    b.HasIndex("BuyerId");

                    b.HasIndex("CarDealerId");

                    b.HasIndex("CarInfoId")
                        .IsUnique();

                    b.HasIndex("SellerId");

                    b.ToTable("Cars");
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarBuyer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CarBuyers");
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarDealer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.HasKey("Id");

                    b.ToTable("CarDealers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Address = "Pleven, Bulgaria",
                            Description = "Selling good cars in Pleven",
                            Name = "Pleven Auto House",
                            PhoneNumber = "+359877778888"
                        },
                        new
                        {
                            Id = 2,
                            Address = "Sofia, Bulgaria",
                            Description = "Selling cheap cars in Sofia",
                            Name = "Sofia Auto House",
                            PhoneNumber = "+359887778888"
                        },
                        new
                        {
                            Id = 3,
                            Address = "Burgas, Bulgaria",
                            Description = "Selling good cars in Burgas",
                            Name = "Burgas Auto House",
                            PhoneNumber = "+359897778888"
                        });
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Brand")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("CarType")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int>("Engine")
                        .HasColumnType("int");

                    b.Property<float>("EngineDisplacement")
                        .HasColumnType("real");

                    b.Property<float>("FuelConsumption")
                        .HasColumnType("real");

                    b.Property<int>("HorsePower")
                        .HasColumnType("int");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasMaxLength(2048)
                        .HasColumnType("nvarchar(2048)");

                    b.Property<int>("Mileage")
                        .HasColumnType("int");

                    b.Property<string>("Model")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<int>("PriceForSale")
                        .HasColumnType("int");

                    b.Property<int>("Transmission")
                        .HasColumnType("int");

                    b.Property<int>("Weight")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CarInfos");

                    b.HasData(
                        new
                        {
                            Id = new Guid("32350c4c-d4cc-4a9f-83c5-fba2f2593c7f"),
                            Brand = "Citroen",
                            CarType = "Minivan",
                            Description = "A really good family car with low fuel consumption.",
                            Engine = 1,
                            EngineDisplacement = 2f,
                            FuelConsumption = 5.5f,
                            HorsePower = 90,
                            ImageUrl = "https://cdn3.focus.bg/autodata/i/citroen/xsara/xsara-picasso-n68/large/93f808a9cfb5a399babc04e50f54eb36.jpg",
                            Mileage = 150000,
                            Model = "Xsara Picasso",
                            PriceForSale = 7000,
                            Transmission = 0,
                            Weight = 1300
                        },
                        new
                        {
                            Id = new Guid("0bf82f3b-bf1b-4c01-a77d-43dbfce6741d"),
                            Brand = "Subaru",
                            CarType = "Crossover",
                            Description = "A good offroad car.",
                            Engine = 0,
                            EngineDisplacement = 2f,
                            FuelConsumption = 8.5f,
                            HorsePower = 125,
                            ImageUrl = "https://cdn3.focus.bg/autodata/i/subaru/forester/forester-ii/large/a942a400b16a08d5b5788147fea6325c.jpg",
                            Mileage = 100000,
                            Model = "Forester",
                            PriceForSale = 15000,
                            Transmission = 0,
                            Weight = 1360
                        },
                        new
                        {
                            Id = new Guid("2b3ddeb5-446f-4afa-bb05-2162992fdfd2"),
                            Brand = "Toyota",
                            CarType = "Hatchback",
                            Description = "A small car ideal for the city.",
                            Engine = 0,
                            EngineDisplacement = 1.3f,
                            FuelConsumption = 7.5f,
                            HorsePower = 86,
                            ImageUrl = "https://www.auto-data.net/images/f106/Toyota-Corolla-Hatch-VIII-E110.jpg",
                            Mileage = 65000,
                            Model = "Corolla Hatch",
                            PriceForSale = 8500,
                            Transmission = 0,
                            Weight = 1060
                        },
                        new
                        {
                            Id = new Guid("4895d66c-5f7d-4464-a3b3-4b88257bbf60"),
                            Brand = "Audi",
                            CarType = "Sedan",
                            Description = "An old but fast classic sedan.",
                            Engine = 0,
                            EngineDisplacement = 2.6f,
                            FuelConsumption = 8.6f,
                            HorsePower = 150,
                            ImageUrl = "https://www.auto-data.net/images/f87/Audi-80-V-B4-Typ-8C.jpg",
                            Mileage = 200000,
                            Model = "80 B4",
                            PriceForSale = 16000,
                            Transmission = 0,
                            Weight = 1330
                        });
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarSeller", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("CarSellers");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("CarCatalog.Data.Models.Car", b =>
                {
                    b.HasOne("CarCatalog.Data.Models.ApplicationUser", null)
                        .WithMany("Cars")
                        .HasForeignKey("ApplicationUserId");

                    b.HasOne("CarCatalog.Data.Models.CarBuyer", "Buyer")
                        .WithMany("CarsBought")
                        .HasForeignKey("BuyerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CarCatalog.Data.Models.CarDealer", "Dealer")
                        .WithMany("RegisteredCars")
                        .HasForeignKey("CarDealerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("CarCatalog.Data.Models.CarInfo", "CarInfo")
                        .WithOne()
                        .HasForeignKey("CarCatalog.Data.Models.Car", "CarInfoId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("CarCatalog.Data.Models.CarSeller", "Seller")
                        .WithMany("CarsAvailable")
                        .HasForeignKey("SellerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Buyer");

                    b.Navigation("CarInfo");

                    b.Navigation("Dealer");

                    b.Navigation("Seller");
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarBuyer", b =>
                {
                    b.HasOne("CarCatalog.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarSeller", b =>
                {
                    b.HasOne("CarCatalog.Data.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("CarCatalog.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("CarCatalog.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole<System.Guid>", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("CarCatalog.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("CarCatalog.Data.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CarCatalog.Data.Models.ApplicationUser", b =>
                {
                    b.Navigation("Cars");
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarBuyer", b =>
                {
                    b.Navigation("CarsBought");
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarDealer", b =>
                {
                    b.Navigation("RegisteredCars");
                });

            modelBuilder.Entity("CarCatalog.Data.Models.CarSeller", b =>
                {
                    b.Navigation("CarsAvailable");
                });
#pragma warning restore 612, 618
        }
    }
}