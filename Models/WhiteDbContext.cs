using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace backend.Models;

public partial class WhiteDbContext : DbContext
{
    public WhiteDbContext()
    {
    }

    public WhiteDbContext(DbContextOptions<WhiteDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AbStudent> AbStudents { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder){}

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AbStudent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AbStuden__3213E83F2A20B226");

            entity.ToTable("AbStudent");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Age)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ContactNumber)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Grade)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.StudentsName)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
