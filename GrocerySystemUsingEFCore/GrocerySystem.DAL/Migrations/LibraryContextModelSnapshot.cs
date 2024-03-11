﻿// <auto-generated />
using GrocerySystem.DAL.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GrocerySystem.DAL.Migrations
{
    [DbContext(typeof(GroceryContext))]
    partial class LibraryContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.16")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("GrocerySystem.DAL.Models.Good", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(5, 2)");

                    b.Property<decimal>("Weight")
                        .HasColumnType("decimal(5, 2)");

                    b.HasKey("Id")
                        .HasName("PK__Goods__3214EC075B8C3B6C");

                    b.ToTable("Goods");
                });

            modelBuilder.Entity("GrocerySystem.DAL.Models.Grocery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("GoodsId")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("ShoppersId")
                        .HasColumnType("int");

                    b.HasKey("Id")
                        .HasName("PK__Grocerie__3214EC07B92F0B3A");

                    b.HasIndex("GoodsId");

                    b.HasIndex("ShoppersId");

                    b.ToTable("Groceries");
                });

            modelBuilder.Entity("GrocerySystem.DAL.Models.Shopper", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Shoppers__3214EC07534A16C2");

                    b.ToTable("Shoppers");
                });

            modelBuilder.Entity("GrocerySystem.DAL.Models.Grocery", b =>
                {
                    b.HasOne("GrocerySystem.DAL.Models.Good", "Goods")
                        .WithMany("Groceries")
                        .HasForeignKey("GoodsId")
                        .IsRequired()
                        .HasConstraintName("FK_Groceries_Goods");

                    b.HasOne("GrocerySystem.DAL.Models.Shopper", "Shoppers")
                        .WithMany("Groceries")
                        .HasForeignKey("ShoppersId")
                        .IsRequired()
                        .HasConstraintName("FK_Groceries_Shoppers");

                    b.Navigation("Goods");

                    b.Navigation("Shoppers");
                });

            modelBuilder.Entity("GrocerySystem.DAL.Models.Good", b =>
                {
                    b.Navigation("Groceries");
                });

            modelBuilder.Entity("GrocerySystem.DAL.Models.Shopper", b =>
                {
                    b.Navigation("Groceries");
                });
#pragma warning restore 612, 618
        }
    }
}
