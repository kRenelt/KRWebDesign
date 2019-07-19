﻿// <auto-generated />
using System;
using KRWebDesign.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace KRWebDesign.Migrations
{
    [DbContext(typeof(KRWebDesignContext))]
    [Migration("20181207065502_ProductIdAdded")]
    partial class ProductIdAdded
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("KRWebDesign.Models.Beef", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Flavor");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Quantity");

                    b.HasKey("ID");

                    b.ToTable("Beef");
                });

            modelBuilder.Entity("KRWebDesign.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated");

                    b.Property<int>("ItemsInToCart");

                    b.Property<string>("OwnerID");

                    b.Property<decimal>("Price");

                    b.HasKey("ID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("KRWebDesign.Models.FavoriteSite", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<int?>("FavoriteWebSitesID");

                    b.Property<int>("Rating");

                    b.Property<string>("SiteURL");

                    b.HasKey("ID");

                    b.HasIndex("FavoriteWebSitesID");

                    b.ToTable("FavoriteSite");
                });

            modelBuilder.Entity("KRWebDesign.Models.FavoriteWebSites", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Category");

                    b.Property<string>("OwnerID");

                    b.Property<int>("Rating");

                    b.HasKey("ID");

                    b.ToTable("FavoriteWebSites");
                });

            modelBuilder.Entity("KRWebDesign.Models.Products", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CartID");

                    b.Property<string>("Flavor");

                    b.Property<string>("OwnerID");

                    b.Property<decimal>("Price");

                    b.Property<string>("ProductID");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("KRWebDesign.Models.FavoriteSite", b =>
                {
                    b.HasOne("KRWebDesign.Models.FavoriteWebSites")
                        .WithMany("SiteAddress")
                        .HasForeignKey("FavoriteWebSitesID");
                });

            modelBuilder.Entity("KRWebDesign.Models.Products", b =>
                {
                    b.HasOne("KRWebDesign.Models.Cart")
                        .WithMany("Products")
                        .HasForeignKey("CartID");
                });
#pragma warning restore 612, 618
        }
    }
}
