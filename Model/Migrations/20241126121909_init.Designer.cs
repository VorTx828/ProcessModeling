﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Model.Data;

#nullable disable

namespace Model.Migrations
{
    [DbContext(typeof(TeploobmenContext))]
    [Migration("20241126121909_init")]
    partial class init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.11");

            modelBuilder.Entity("Model.Data.Variants", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<double>("C_gas")
                        .HasColumnType("REAL");

                    b.Property<double>("C_material")
                        .HasColumnType("REAL");

                    b.Property<double>("G")
                        .HasColumnType("REAL");

                    b.Property<double>("Height")
                        .HasColumnType("REAL");

                    b.Property<double>("T_gas")
                        .HasColumnType("REAL");

                    b.Property<double>("T_material")
                        .HasColumnType("REAL");

                    b.Property<double>("W")
                        .HasColumnType("REAL");

                    b.Property<double>("av")
                        .HasColumnType("REAL");

                    b.Property<double>("d")
                        .HasColumnType("REAL");

                    b.Property<double>("step")
                        .HasColumnType("REAL");

                    b.HasKey("Id");

                    b.ToTable("Variants");
                });
#pragma warning restore 612, 618
        }
    }
}
