using System;
using Microsoft.EntityFrameworkCore;
using UrlShorter;
using UrlShorter.Models;

namespace UrlShorter.Data { }

public class UrlShortenerContext : DbContext
{
    public DbSet<XYZ> Urls { get; set; }
    public DbSet<Category> Categories { get; set; }
    public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<XYZ>()
            .HasOne(c => c.Category)
            .WithMany(u => u.Urls)
            .HasForeignKey(u => u.CategoryId);
               
        modelBuilder.Entity<Category>().HasData(
            new Category() { Id = 1, Name = "Heores", Description = "Super heores muy copados"},
            new Category() { Id = 2, Name = "Accion", Description = "Super Accion muy copados" },
            new Category() { Id = 3, Name = "Gatos", Description = "Super Gatos muy copados" }
        );

        base.OnModelCreating(modelBuilder);
    }
}

