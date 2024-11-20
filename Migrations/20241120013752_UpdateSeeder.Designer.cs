﻿// <auto-generated />
using CRUDTechTest.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUDTechTest.Migrations
{
    [DbContext(typeof(TechTestTapebringContext))]
    [Migration("20241120013752_UpdateSeeder")]
    partial class UpdateSeeder
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("CRUDTechTest.Entities.Kendaraan", b =>
                {
                    b.Property<string>("NomorRegistrasi")
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Alamat")
                        .HasColumnType("text");

                    b.Property<string>("BahanBakar")
                        .HasColumnType("longtext");

                    b.Property<int>("KapasitasSilinder")
                        .HasColumnType("int");

                    b.Property<string>("MerkKendaraan")
                        .HasColumnType("longtext");

                    b.Property<string>("NamaPemilik")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TahunPembuatan")
                        .HasColumnType("int");

                    b.Property<string>("WarnaKendaraan")
                        .HasColumnType("longtext");

                    b.HasKey("NomorRegistrasi");

                    b.ToTable("Kendaraan");

                    b.HasData(
                        new
                        {
                            NomorRegistrasi = "B1234ABC",
                            Alamat = "Jl. Sudirman No. 123, Pemalang",
                            BahanBakar = "Hitam",
                            KapasitasSilinder = 2000,
                            MerkKendaraan = "Toyota",
                            NamaPemilik = "Ahmad Kurniawan",
                            TahunPembuatan = 2020,
                            WarnaKendaraan = "Putih"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}