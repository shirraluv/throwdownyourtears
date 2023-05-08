using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace throwdownyourtears;

public partial class ThrowdownyourtearsContext : DbContext
{
    public ThrowdownyourtearsContext()
    {
    }

    public ThrowdownyourtearsContext(DbContextOptions<ThrowdownyourtearsContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

    public virtual DbSet<Quantityofsale> Quantityofsales { get; set; }

    public virtual DbSet<Shop> Shops { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#pragma warning disable CS1030 // #warning: "To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.'
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;user=root;password=1234512345;database=throwdownyourtears", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.32-mysql"));
#pragma warning restore CS1030 // #warning: "To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.'

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Minimum)
                .HasMaxLength(255)
                .HasColumnName("minimum");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasMaxLength(255)
                .HasColumnName("price");
            entity.Property(e => e.PurchasePrice)
                .HasMaxLength(255)
                .HasColumnName("PurchasePrice");
            entity.Property(e => e.Quantity)
                .HasMaxLength(255)
                .HasColumnName("quantity");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Product)
                .HasForeignKey<Product>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id1).HasName("PRIMARY");

            entity.ToTable("provider");

            entity.Property(e => e.Id1).HasColumnName("id1");
            entity.Property(e => e.Name1)
                .HasMaxLength(255)
                .HasColumnName("name");
            entity.Property(e => e.Telegramid)
                .HasMaxLength(255)
                .HasColumnName("telegramid");
        });

        modelBuilder.Entity<Quantityofsale>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("quantityofsales");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gain)
                .HasMaxLength(255)
                .HasColumnName("gain");
            entity.Property(e => e.Quantity2)
                .HasMaxLength(255)
                .HasColumnName("quantity2");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shop");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.Shop)
                .HasForeignKey<Shop>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.Id1).WithOne(p => p.Shop)
                .HasForeignKey<Shop>(d => d.Id)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
