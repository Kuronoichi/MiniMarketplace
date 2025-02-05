using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pitpmlab4.Database.ssms.models;

namespace Pitpmlab4.Database.ssms;

public partial class SsmsContext : DbContext
{
    public SsmsContext()
    {
    }

    public SsmsContext(DbContextOptions<SsmsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserRole> UserRoles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WIN-5TMRGNOLPFU\\SQLEXPRESS;Database=MarketPlace;Trusted_Connection=True;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC278986BEF9");

            entity.HasIndex(e => e.ImagePath, "UQ__Products__67172E671C7A73A0").IsUnique();

            entity.HasIndex(e => e.Name, "UQ__Products__737584F6C6C7C7A3").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ImagePath).HasMaxLength(512);
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC27648091A3");

            entity.HasIndex(e => e.Login, "UQ__Users__5E55825BC0525442").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Login).HasMaxLength(255);
            entity.Property(e => e.UserRole).HasColumnName("User_Role");

            entity.HasOne(d => d.UserRoleNavigation).WithMany(p => p.Users)
                .HasForeignKey(d => d.UserRole)
                .HasConstraintName("FK__Users__User_Role__4D94879B");
        });

        modelBuilder.Entity<UserRole>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__User_Rol__3214EC276510AEAB");

            entity.ToTable("User_Roles");

            entity.HasIndex(e => e.Name, "UQ__User_Rol__737584F636D4E373").IsUnique();

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
