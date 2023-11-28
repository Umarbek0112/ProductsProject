﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using ProductsProject.Data.DbContex;

#nullable disable

namespace ProductsProject.Data.Migrations
{
    [DbContext(typeof(ProductsProjectDbContex))]
    [Migration("20231125102122_ProjectRepository")]
    partial class ProjectRepository
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("ProductsProject.Domain.Entities.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("Opisaniya")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<decimal>("Price")
                        .HasColumnType("numeric");

                    b.Property<decimal>("PriceScitka")
                        .HasColumnType("numeric");

                    b.Property<int>("ProductTypeId")
                        .HasColumnType("integer");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex("ProductTypeId");

                    b.HasIndex(new[] { "Price", "Name" }, "Index_Price_Name");

                    b.HasIndex(new[] { "Id" }, "Index_Product")
                        .IsUnique();

                    b.ToTable("Products");
                });

            modelBuilder.Entity("ProductsProject.Domain.Entities.ProductImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Path")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Id" }, "Index_ProductImage")
                        .IsUnique();

                    b.ToTable("ProductImages");
                });

            modelBuilder.Entity("ProductsProject.Domain.Entities.ProductType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer");

                    NpgsqlPropertyBuilderExtensions.UseIdentityByDefaultColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("ImageId")
                        .HasColumnType("integer");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("UpdateAt")
                        .HasColumnType("timestamp with time zone");

                    b.HasKey("Id");

                    b.HasIndex("ImageId");

                    b.HasIndex(new[] { "Id" }, "Index_ProductType")
                        .IsUnique();

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("ProductsProject.Domain.Entities.Product", b =>
                {
                    b.HasOne("ProductsProject.Domain.Entities.ProductImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProductsProject.Domain.Entities.ProductType", "ProductType")
                        .WithMany()
                        .HasForeignKey("ProductTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");

                    b.Navigation("ProductType");
                });

            modelBuilder.Entity("ProductsProject.Domain.Entities.ProductType", b =>
                {
                    b.HasOne("ProductsProject.Domain.Entities.ProductImage", "Image")
                        .WithMany()
                        .HasForeignKey("ImageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Image");
                });
#pragma warning restore 612, 618
        }
    }
}
