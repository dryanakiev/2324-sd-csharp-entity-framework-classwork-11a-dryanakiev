using System;
using System.Collections.Generic;
using GrocerySystem.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace GrocerySystem.DAL.Data;

public partial class LibraryContext : DbContext
{
    public LibraryContext()
    {
    }

    public LibraryContext(DbContextOptions<LibraryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Good> Goods { get; set; }

    public virtual DbSet<Grocery> Groceries { get; set; }

    public virtual DbSet<Shopper> Shoppers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TL011T\\SQLEXPRESS;Database=GrocerySystem;TrustServerCertificate=True;Integrated Security=true;");

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
