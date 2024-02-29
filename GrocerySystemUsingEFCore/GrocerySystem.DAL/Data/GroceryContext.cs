﻿using System;
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

    public virtual DbSet<Goods> Goods { get; set; }

    public virtual DbSet<Groceries> Groceries { get; set; }

    public virtual DbSet<Shoppers> Shoppers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=TL011T\\SQLEXPRESS;Database=GrocerySystem;TrustServerCertificate=True;Integrated Security=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Goods>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Goods__3214EC075B8C3B6C");
        });

        modelBuilder.Entity<Groceries>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Grocerie__3214EC07B92F0B3A");

            entity.HasOne(d => d.Goods).WithMany(p => p.Groceries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groceries_Goods");

            entity.HasOne(d => d.Shoppers).WithMany(p => p.Groceries)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Groceries_Shoppers");
        });

        modelBuilder.Entity<Shoppers>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Shoppers__3214EC07534A16C2");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
