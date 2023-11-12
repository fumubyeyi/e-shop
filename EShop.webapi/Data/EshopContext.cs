using System;
using System.Collections.Generic;
using EShop.webapi.Models;
using Microsoft.EntityFrameworkCore;

namespace EShop.webapi.Data;

public partial class EshopContext : DbContext
{
    public EshopContext()
    {
    }

    public EshopContext(DbContextOptions options)
        : base(options)
    {
    }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductDescription> ProductDescriptions { get; set; }

    public virtual DbSet<ProductModel> ProductModels { get; set; }

    public virtual DbSet<ProductModelProductDescription> ProductModelProductDescriptions { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK_Product_ProductID");

            entity.ToTable("Product", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_Product_Name").IsUnique();

            entity.HasIndex(e => e.ProductNumber, "AK_Product_ProductNumber").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_Product_rowguid").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Color).HasMaxLength(15);
            entity.Property(e => e.DiscontinuedDate).HasColumnType("datetime");
            entity.Property(e => e.ListPrice).HasColumnType("money");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ProductNumber).HasMaxLength(25);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
            entity.Property(e => e.SellEndDate).HasColumnType("datetime");
            entity.Property(e => e.SellStartDate).HasColumnType("datetime");
            entity.Property(e => e.Size).HasMaxLength(5);
            entity.Property(e => e.StandardCost).HasColumnType("money");
            entity.Property(e => e.ThumbnailPhotoFileName).HasMaxLength(50);
            entity.Property(e => e.Weight).HasColumnType("decimal(8, 2)");

            entity.HasOne(d => d.ProductCategory).WithMany(p => p.Products).HasForeignKey(d => d.ProductCategoryId);

            entity.HasOne(d => d.ProductModel).WithMany(p => p.Products).HasForeignKey(d => d.ProductModelId);
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity.HasKey(e => e.ProductCategoryId).HasName("PK_ProductCategory_ProductCategoryID");

            entity.ToTable("ProductCategory", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_ProductCategory_Name").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_ProductCategory_rowguid").IsUnique();

            entity.Property(e => e.ProductCategoryId).HasColumnName("ProductCategoryID");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.ParentProductCategoryId).HasColumnName("ParentProductCategoryID");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.ParentProductCategory).WithMany(p => p.InverseParentProductCategory)
                .HasForeignKey(d => d.ParentProductCategoryId)
                .HasConstraintName("FK_ProductCategory_ProductCategory_ParentProductCategoryID_ProductCategoryID");
        });

        modelBuilder.Entity<ProductDescription>(entity =>
        {
            entity.HasKey(e => e.ProductDescriptionId).HasName("PK_ProductDescription_ProductDescriptionID");

            entity.ToTable("ProductDescription", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_ProductDescription_rowguid").IsUnique();

            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");
            entity.Property(e => e.Description).HasMaxLength(400);
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductModel>(entity =>
        {
            entity.HasKey(e => e.ProductModelId).HasName("PK_ProductModel_ProductModelID");

            entity.ToTable("ProductModel", "SalesLT");

            entity.HasIndex(e => e.Name, "AK_ProductModel_Name").IsUnique();

            entity.HasIndex(e => e.Rowguid, "AK_ProductModel_rowguid").IsUnique();

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.CatalogDescription).HasColumnType("xml");
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");
        });

        modelBuilder.Entity<ProductModelProductDescription>(entity =>
        {
            entity.HasKey(e => new { e.ProductModelId, e.ProductDescriptionId, e.Culture }).HasName("PK_ProductModelProductDescription_ProductModelID_ProductDescriptionID_Culture");

            entity.ToTable("ProductModelProductDescription", "SalesLT");

            entity.HasIndex(e => e.Rowguid, "AK_ProductModelProductDescription_rowguid").IsUnique();

            entity.Property(e => e.ProductModelId).HasColumnName("ProductModelID");
            entity.Property(e => e.ProductDescriptionId).HasColumnName("ProductDescriptionID");
            entity.Property(e => e.Culture)
                .HasMaxLength(6)
                .IsFixedLength();
            entity.Property(e => e.ModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Rowguid)
                .HasDefaultValueSql("(newid())")
                .HasColumnName("rowguid");

            entity.HasOne(d => d.ProductDescription).WithMany(p => p.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductDescriptionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            entity.HasOne(d => d.ProductModel).WithMany(p => p.ProductModelProductDescriptions)
                .HasForeignKey(d => d.ProductModelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        });
        modelBuilder.HasSequence<int>("SalesOrderNumber", "SalesLT");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
