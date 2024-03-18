﻿// <auto-generated />
using System;
using DGII_Taxpayers.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DGII_Taxpayers.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("DGII_Taxpayers.Domain.Entitites.PersonType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("TypeName")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("TypeName")
                        .IsUnique();

                    b.ToTable("PersonType");
                });

            modelBuilder.Entity("DGII_Taxpayers.Domain.Entitites.TaxPayer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PersonTypeId")
                        .HasColumnType("int");

                    b.Property<string>("RncID")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PersonTypeId");

                    b.HasIndex("RncID")
                        .IsUnique();

                    b.ToTable("TaxPayer");
                });

            modelBuilder.Entity("DGII_Taxpayers.Domain.Entitites.TaxReceipt", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("Amount")
                        .HasColumnType("float");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<double>("Itbis18")
                        .HasColumnType("float");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("NCF")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("TaxPayerId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("NCF")
                        .IsUnique();

                    b.HasIndex("TaxPayerId");

                    b.ToTable("TaxReceipt");
                });

            modelBuilder.Entity("DGII_Taxpayers.Domain.Entitites.TaxPayer", b =>
                {
                    b.HasOne("DGII_Taxpayers.Domain.Entitites.PersonType", "PersonType")
                        .WithMany("TaxPayers")
                        .HasForeignKey("PersonTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PersonType");
                });

            modelBuilder.Entity("DGII_Taxpayers.Domain.Entitites.TaxReceipt", b =>
                {
                    b.HasOne("DGII_Taxpayers.Domain.Entitites.TaxPayer", "TaxPayer")
                        .WithMany("TaxReceipts")
                        .HasForeignKey("TaxPayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TaxPayer");
                });

            modelBuilder.Entity("DGII_Taxpayers.Domain.Entitites.PersonType", b =>
                {
                    b.Navigation("TaxPayers");
                });

            modelBuilder.Entity("DGII_Taxpayers.Domain.Entitites.TaxPayer", b =>
                {
                    b.Navigation("TaxReceipts");
                });
#pragma warning restore 612, 618
        }
    }
}