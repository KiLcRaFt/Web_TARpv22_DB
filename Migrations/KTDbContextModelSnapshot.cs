﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Web_TARpv22.Migrations
{
    [DbContext(typeof(KTDbContext))]
    partial class KTDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Web_TARpv22.Models.Kasutaja", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Nimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Perenimi")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Kasutajad");
                });

            modelBuilder.Entity("Web_TARpv22.Models.KasutajaToode", b =>
                {
                    b.Property<int>("KasutajaId")
                        .HasColumnType("int");

                    b.Property<int>("ToodeId")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .HasColumnType("int");

                    b.Property<int>("Kokku")
                        .HasColumnType("int");

                    b.HasKey("KasutajaId", "ToodeId");

                    b.HasIndex("ToodeId");

                    b.ToTable("KasutajaToode");
                });

            modelBuilder.Entity("Web_TARpv22.Models.Toode", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Tooded");
                });

            modelBuilder.Entity("Web_TARpv22.Models.KasutajaToode", b =>
                {
                    b.HasOne("Web_TARpv22.Models.Kasutaja", "Kasutaja")
                        .WithMany("KasutajaToode")
                        .HasForeignKey("KasutajaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Web_TARpv22.Models.Toode", "Toode")
                        .WithMany("KasutajaToode")
                        .HasForeignKey("ToodeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Kasutaja");

                    b.Navigation("Toode");
                });

            modelBuilder.Entity("Web_TARpv22.Models.Kasutaja", b =>
                {
                    b.Navigation("KasutajaToode");
                });

            modelBuilder.Entity("Web_TARpv22.Models.Toode", b =>
                {
                    b.Navigation("KasutajaToode");
                });
#pragma warning restore 612, 618
        }
    }
}
