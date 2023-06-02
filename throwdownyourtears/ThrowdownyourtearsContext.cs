using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Asn1.X509;

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

    public virtual DbSet<Generalsales> Generalsale { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Productshop> Productshops { get; set; }

    public virtual DbSet<Productsprovider> Productsproviders { get; set; }

    public virtual DbSet<Provider> Providers { get; set; }

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

        modelBuilder.Entity<Generalsales>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("generalsales");

            entity.Property(e => e.Generalgain)
                .HasMaxLength(255)
                .HasColumnName("generalgain");
            entity.Property(e => e.Generalgain2)
                .HasMaxLength(255)
                .HasColumnName("generalgain2");
            entity.Property(e => e.Generalbuys)
                .HasMaxLength(255)
                .HasColumnName("generalbuys");
            entity.Property(e => e.Generalquantity)
                .HasMaxLength(255)
                .HasColumnName("generalquantity");
            entity.Property(e => e.Id).HasColumnName("id");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("products");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Minimum)
                .HasMaxLength(255)
                .HasColumnName("minimum");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Price)
                .HasMaxLength(255)
                .HasColumnName("price");
            entity.Property(e => e.Productgain)
                .HasDefaultValueSql("'0'")
                .HasColumnName("productgain");
            entity.Property(e => e.Productsales)
                .HasDefaultValueSql("'0'")
                .HasColumnName("productsales");
            entity.Property(e => e.Productbuys)
                .HasDefaultValueSql("'0'")
                .HasColumnName("productbuys");
            entity.Property(e => e.Productgain2)
            .HasDefaultValueSql("'0'")
            .HasColumnName("productgain2");
            entity.Property(e => e.PurchasePrice).HasMaxLength(255);
            entity.Property(e => e.Quantity)
                 .HasDefaultValueSql("'0'")
                .HasColumnName("quantity");
        });

        modelBuilder.Entity<Productshop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productshop");

            entity.HasIndex(e => e.Productid, "FK_productshop_products_id");

            entity.HasIndex(e => e.Shopid, "FK_productshop_shop_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Productid).HasColumnName("productid");
            entity.Property(e => e.Shopid).HasColumnName("shopid");

            entity.HasOne(d => d.Product).WithMany(p => p.Productshops)
                .HasForeignKey(d => d.Productid)
                .HasConstraintName("FK_productshop_products_id");

            entity.HasOne(d => d.Shop).WithMany(p => p.Productshops)
                .HasForeignKey(d => d.Shopid)
                .HasConstraintName("FK_productshop_shop_id");
        });

        modelBuilder.Entity<Productsprovider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("productsprovider");

            entity.HasIndex(e => e.ProductsId, "FK_productsprovider_products_id");

            entity.HasIndex(e => e.ProviderId, "FK_productsprovider_provider_id");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ProductsId).HasColumnName("products_id");
            entity.Property(e => e.ProviderId).HasColumnName("provider_id");

            entity.HasOne(d => d.Products).WithMany(p => p.Productsproviders)
                .HasForeignKey(d => d.ProductsId)
                .HasConstraintName("FK_productsprovider_products_id");

            entity.HasOne(d => d.Provider).WithMany(p => p.Productsproviders)
                .HasForeignKey(d => d.ProviderId)
                .HasConstraintName("FK_productsprovider_provider_id");
        });

        modelBuilder.Entity<Provider>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("provider");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
            entity.Property(e => e.Telegramid)
                .HasMaxLength(255)
                .HasColumnName("telegramid");
        });

        modelBuilder.Entity<Shop>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("shop");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
