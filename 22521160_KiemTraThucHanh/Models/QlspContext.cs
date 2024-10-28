using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace _22521160_KiemTraThucHanh.Models;

public partial class QlspContext : DbContext
{
    public QlspContext()
    {
    }

    public QlspContext(DbContextOptions<QlspContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=BICHPHUONG;Initial Catalog=QLSP;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.IdType).HasName("PK__CATEGORY__274CEC828D0F7E31");

            entity.ToTable("CATEGORY");

            entity.Property(e => e.IdType).HasColumnName("ID_TYPE");
            entity.Property(e => e.NameType)
                .HasMaxLength(20)
                .HasColumnName("NAME_TYPE");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.IdProduct).HasName("PK__PRODUCT__69B20C2023D61150");

            entity.ToTable("PRODUCT");

            entity.Property(e => e.IdProduct)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ID_PRODUCT");
            entity.Property(e => e.Description)
                .HasMaxLength(1000)
                .HasColumnName("DESCRIPTION");
            entity.Property(e => e.IdType).HasColumnName("ID_TYPE");
            entity.Property(e => e.MImage)
                .HasMaxLength(100)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("M_IMAGE");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("NAME");
            entity.Property(e => e.Price)
                .HasColumnType("money")
                .HasColumnName("PRICE");
            entity.Property(e => e.Weight).HasColumnName("WEIGHT");

            entity.HasOne(d => d.IdTypeNavigation).WithMany(p => p.Products)
                .HasForeignKey(d => d.IdType)
                .HasConstraintName("FK_PRO_TYPE");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__USERS__3214EC275AAD23A6");

            entity.ToTable("USERS");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Username)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("USERNAME");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
