using Microsoft.EntityFrameworkCore;
using System;
using Web_TARpv22.Models;

public class KTDbContext : DbContext
{
    public KTDbContext(DbContextOptions<KTDbContext> options) : base(options) { }

    public DbSet<Kasutaja> Kasutajad { get; set; }
    public DbSet<Toode> Tooded { get; set; }
    public DbSet<KasutajaToode> KasutajaToode { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<KasutajaToode>()
            .HasKey(ci => new { ci.KasutajaId, ci.ToodeId });

        modelBuilder.Entity<KasutajaToode>()
            .HasOne(ci => ci.Kasutaja)
            .WithMany(k => k.KasutajaToode)
            .HasForeignKey(ci => ci.KasutajaId);

        modelBuilder.Entity<KasutajaToode>()
            .HasOne(ci => ci.Toode)
            .WithMany(t => t.KasutajaToode)
            .HasForeignKey(ci => ci.ToodeId);
    }
}
