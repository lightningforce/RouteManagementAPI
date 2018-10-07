﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using RouteAPI.Data;
using System;

namespace RouteAPI.Migrations
{
    [DbContext(typeof(DataContext))]
    [Migration("20181005072335_EditDataType")]
    partial class EditDataType
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.3-rtm-10026")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RouteAPI.Models.Car", b =>
                {
                    b.Property<string>("carCode")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("driverName")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("status")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("zoneId");

                    b.HasKey("carCode");

                    b.HasIndex("zoneId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("RouteAPI.Models.Customer", b =>
                {
                    b.Property<string>("cusCode")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("building")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("city")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("cusCond")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("cusType")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("day")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<int>("depBottle");

                    b.Property<string>("district")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("firstName")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("gps")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("houseNo")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("lastName")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("portalCode")
                        .HasColumnType("NVARCHAR(5)");

                    b.Property<string>("road")
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<string>("soi")
                        .HasColumnType("NVARCHAR(30)");

                    b.Property<string>("status")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<string>("subDistrict")
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("title")
                        .HasColumnType("NVARCHAR(10)");

                    b.Property<string>("zoneId")
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("cusCode");

                    b.HasIndex("zoneId")
                        .IsUnique()
                        .HasFilter("[zoneId] IS NOT NULL");

                    b.ToTable("Customer");
                });

            modelBuilder.Entity("RouteAPI.Models.Delivery", b =>
                {
                    b.Property<string>("deliveryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("CustomercusCode");

                    b.Property<string>("carCode");

                    b.Property<int>("quantity");

                    b.Property<string>("status")
                        .HasColumnType("NVARCHAR(20)");

                    b.Property<DateTime>("transDate");

                    b.HasKey("deliveryId");

                    b.HasIndex("CustomercusCode");

                    b.HasIndex("carCode");

                    b.ToTable("Delivery");
                });

            modelBuilder.Entity("RouteAPI.Models.Warehouse", b =>
                {
                    b.Property<string>("warehouseId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("gps");

                    b.Property<string>("warehouseName")
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("warehouseId");

                    b.ToTable("Warehouse");
                });

            modelBuilder.Entity("RouteAPI.Models.Zone", b =>
                {
                    b.Property<string>("zoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("NVARCHAR(50)");

                    b.Property<string>("warehouseId");

                    b.Property<string>("zoneName")
                        .HasColumnType("NVARCHAR(50)");

                    b.HasKey("zoneId");

                    b.HasIndex("warehouseId");

                    b.ToTable("Zone");
                });

            modelBuilder.Entity("RouteAPI.Models.Car", b =>
                {
                    b.HasOne("RouteAPI.Models.Zone")
                        .WithMany("cars")
                        .HasForeignKey("zoneId");
                });

            modelBuilder.Entity("RouteAPI.Models.Customer", b =>
                {
                    b.HasOne("RouteAPI.Models.Zone", "zone")
                        .WithOne("customer")
                        .HasForeignKey("RouteAPI.Models.Customer", "zoneId");
                });

            modelBuilder.Entity("RouteAPI.Models.Delivery", b =>
                {
                    b.HasOne("RouteAPI.Models.Customer")
                        .WithMany("deliveries")
                        .HasForeignKey("CustomercusCode");

                    b.HasOne("RouteAPI.Models.Car")
                        .WithMany("deliveries")
                        .HasForeignKey("carCode");
                });

            modelBuilder.Entity("RouteAPI.Models.Zone", b =>
                {
                    b.HasOne("RouteAPI.Models.Warehouse")
                        .WithMany("zones")
                        .HasForeignKey("warehouseId");
                });
#pragma warning restore 612, 618
        }
    }
}
