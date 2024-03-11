using System;
using System.Collections.Generic;
using GrocerySystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GrocerySystem.DAL.Data;

public partial class GroceryContext : DbContext
{
    public GroceryContext()
    {
    }

    public GroceryContext(DbContextOptions<GroceryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<Grocery> Groceries { get; set; }

    public virtual DbSet<Shopper> Shoppers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) => optionsBuilder.UseSqlServer("Server=TL011T\\SQLEXPRESS;Database=GrocerySystem;TrustServerCertificate=True;Integrated Security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Good>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Goods__3214EC075B8C3B6C");
        });

        modelBuilder.Entity<Grocery>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grocerie__3214EC07B92F0B3A");

            entity.HasOne(d => d.Goods).WithMany(p => p.Groceries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groceries_Goods");

            entity.HasOne(d => d.Shoppers).WithMany(p => p.Groceries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groceries_Shoppers");
        });

        modelBuilder.Entity<Shopper>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shoppers__3214EC07534A16C2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
