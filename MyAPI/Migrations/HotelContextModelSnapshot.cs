﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using MyAPI.Data;

namespace MyAPI.Migrations
{
    [DbContext(typeof(HotelContext))]
    partial class HotelContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("MyAPI.Data.Hotel", b =>
                {
                    b.Property<int>("HotelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cuisine")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LocationId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("HotelId");

                    b.HasIndex("LocationId");

                    b.ToTable("Hotels");

                    b.HasData(
                        new
                        {
                            HotelId = 22,
                            Cuisine = "Indian",
                            LocationId = 55,
                            Name = "Royal TN"
                        },
                        new
                        {
                            HotelId = 23,
                            Cuisine = "Italian",
                            LocationId = 56,
                            Name = "Ashoka"
                        },
                        new
                        {
                            HotelId = 1,
                            Cuisine = "Colombian",
                            LocationId = 100,
                            Name = "Chill Thund"
                        });
                });

            modelBuilder.Entity("MyAPI.Data.Location", b =>
                {
                    b.Property<int>("LocationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LocationId");

                    b.ToTable("Locations");

                    b.HasData(
                        new
                        {
                            LocationId = 55,
                            Name = "Philly"
                        },
                        new
                        {
                            LocationId = 56,
                            Name = "Louisville"
                        },
                        new
                        {
                            LocationId = 100,
                            Name = "Alaska"
                        });
                });

            modelBuilder.Entity("MyAPI.Data.Hotel", b =>
                {
                    b.HasOne("MyAPI.Data.Location", "Location")
                        .WithMany()
                        .HasForeignKey("LocationId");
                });
#pragma warning restore 612, 618
        }
    }
}
