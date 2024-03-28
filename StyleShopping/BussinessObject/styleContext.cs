using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BussinessObject
{
    public partial class styleContext : DbContext
    {
        public styleContext()
        {
        }

        public styleContext(DbContextOptions<styleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; } = null!;
        public virtual DbSet<Blog> Blogs { get; set; } = null!;
        public virtual DbSet<Category> Categories { get; set; } = null!;
        public virtual DbSet<Interior> Interiors { get; set; } = null!;
        public virtual DbSet<Order> Orders { get; set; } = null!;
        public virtual DbSet<OrderDetail> OrderDetails { get; set; } = null!;
        public virtual DbSet<Project> Projects { get; set; } = null!;
        public virtual DbSet<Quotation> Quotations { get; set; } = null!;
        public virtual DbSet<QuotationDetail> QuotationDetails { get; set; } = null!;
        public virtual DbSet<Style> Styles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=localhost;Database=style;Trusted_Connection=True;uid=sa;pwd=123456;Trust Server Certificate=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .HasMaxLength(100)
                    .HasColumnName("address");

                entity.Property(e => e.Password)
                    .HasMaxLength(100)
                    .HasColumnName("password");

                entity.Property(e => e.Phone)
                    .HasMaxLength(100)
                    .HasColumnName("phone");

                entity.Property(e => e.Role).HasColumnName("role");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Username)
                    .HasMaxLength(100)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Blog>(entity =>
            {
                entity.ToTable("Blog");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("createDate");

                entity.Property(e => e.Detail)
                    .HasColumnType("ntext")
                    .HasColumnName("detail");

                entity.Property(e => e.Image)
                    .HasColumnType("ntext")
                    .HasColumnName("image");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .HasColumnName("title");

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Blogs)
                    .HasForeignKey(d => d.AccountId)
                    .HasConstraintName("FK__Blog__account_id__2B3F6F97");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Interior>(entity =>
            {
                entity.ToTable("Interior");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.CateId).HasColumnName("cate_id");

                entity.Property(e => e.Detail)
                    .HasColumnType("ntext")
                    .HasColumnName("detail");

                entity.Property(e => e.Image)
                    .HasColumnType("ntext")
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.HasOne(d => d.Cate)
                    .WithMany(p => p.Interiors)
                    .HasForeignKey(d => d.CateId)
                    .HasConstraintName("FK__Interior__cate_i__267ABA7A");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Address)
                    .HasColumnType("ntext")
                    .HasColumnName("address");

                entity.Property(e => e.Note)
                    .HasColumnType("ntext")
                    .HasColumnName("note");

                entity.Property(e => e.OrderDate)
                    .HasColumnType("date")
                    .HasColumnName("orderDate");

                entity.Property(e => e.Phone)
                    .HasColumnType("ntext")
                    .HasColumnName("phone");

                entity.Property(e => e.Square).HasColumnName("square");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.StyleId).HasColumnName("style_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Style)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.StyleId)
                    .HasConstraintName("FK_Orders_Style");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.ToTable("OrderDetail");

                entity.Property(e => e.OrderDetailId).HasColumnName("order_detail_id");

                entity.Property(e => e.InteriorId).HasColumnName("interior_id");

                entity.Property(e => e.OrderId).HasColumnName("order_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.HasOne(d => d.Interior)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.InteriorId)
                    .HasConstraintName("FK__OrderDeta__inter__3A81B327");

                entity.HasOne(d => d.Order)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OrderId)
                    .HasConstraintName("FK__OrderDeta__order__398D8EEE");
            });

            modelBuilder.Entity<Project>(entity =>
            {
                entity.ToTable("Project");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.CompleteYear).HasColumnName("completeYear");

                entity.Property(e => e.Detail)
                    .HasColumnType("ntext")
                    .HasColumnName("detail");

                entity.Property(e => e.Image)
                    .HasColumnType("ntext")
                    .HasColumnName("image");

                entity.Property(e => e.Information)
                    .HasColumnType("ntext")
                    .HasColumnName("information");

                entity.Property(e => e.Location)
                    .HasColumnType("ntext")
                    .HasColumnName("location");

                entity.Property(e => e.Result)
                    .HasColumnType("ntext")
                    .HasColumnName("result");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.Value).HasColumnName("value");
            });

            modelBuilder.Entity<Quotation>(entity =>
            {
                entity.ToTable("Quotation");

                entity.Property(e => e.QuotationId).HasColumnName("quotation_id");

                entity.Property(e => e.AccountId).HasColumnName("account_id");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("date")
                    .HasColumnName("createDate");

                entity.Property(e => e.Height).HasColumnName("height");

                entity.Property(e => e.Length).HasColumnName("length");

                entity.Property(e => e.QuotationStatus)
                    .HasMaxLength(100)
                    .HasColumnName("quotation_status");

                entity.Property(e => e.Square).HasColumnName("square");

                entity.Property(e => e.StyleId).HasColumnName("style_id");

                entity.Property(e => e.Width).HasColumnName("width");
            });

            modelBuilder.Entity<QuotationDetail>(entity =>
            {
                entity.ToTable("QuotationDetail");

                entity.Property(e => e.QuotationDetailId).HasColumnName("quotation_detail_id");

                entity.Property(e => e.InteriorId).HasColumnName("interior_id");

                entity.Property(e => e.Quantity).HasColumnName("quantity");

                entity.Property(e => e.QuotationId).HasColumnName("quotation_id");

                entity.HasOne(d => d.Interior)
                    .WithMany(p => p.QuotationDetails)
                    .HasForeignKey(d => d.InteriorId)
                    .HasConstraintName("FK__Quotation__inter__34C8D9D1");

                entity.HasOne(d => d.Quotation)
                    .WithMany(p => p.QuotationDetails)
                    .HasForeignKey(d => d.QuotationId)
                    .HasConstraintName("FK__Quotation__quota__33D4B598");
            });

            modelBuilder.Entity<Style>(entity =>
            {
                entity.ToTable("Style");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Detail)
                    .HasColumnType("ntext")
                    .HasColumnName("detail");

                entity.Property(e => e.Image)
                    .HasColumnType("ntext")
                    .HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .HasColumnName("name");

                entity.Property(e => e.PricePerSquare).HasColumnName("pricePerSquare");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
