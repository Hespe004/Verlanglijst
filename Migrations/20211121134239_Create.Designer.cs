﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Site.Migrations
{
    [DbContext(typeof(MijnContext))]
    [Migration("20211121134239_Create")]
    partial class Create
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("src.Models.BR_Lijst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Titel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<int>("Waarde")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("BR_Lijsts");
                });

            modelBuilder.Entity("src.Models.Overig_Lijst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Titel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<int>("Waarde")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Overig_Lijsts");
                });

            modelBuilder.Entity("src.Models.PS_Lijst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Gen")
                        .HasColumnType("TEXT");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Titel")
                        .HasColumnType("TEXT");

                    b.Property<int>("Waarde")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("PS_Lijsts");
                });

            modelBuilder.Entity("src.Models.Verzamel_Lijst", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Link")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<string>("Titel")
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .HasColumnType("TEXT");

                    b.Property<int>("Waarde")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Verzamel_Lijsts");
                });
#pragma warning restore 612, 618
        }
    }
}