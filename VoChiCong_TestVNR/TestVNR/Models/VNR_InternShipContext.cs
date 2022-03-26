using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace TestVNR.Models
{
    public partial class VNR_InternShipContext : DbContext
    {
        public VNR_InternShipContext()
        {
        }

        public VNR_InternShipContext(DbContextOptions<VNR_InternShipContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KhoaHoc> KhoaHoc { get; set; }
        public virtual DbSet<MonHoc> MonHoc { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=MSI\\SQLEXPRESS;Initial Catalog=VNR_InternShip;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<KhoaHoc>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.TenKhoaHoc).HasMaxLength(30);
            });

            modelBuilder.Entity<MonHoc>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KhoaHocId).HasColumnName("KhoaHocID");

                entity.Property(e => e.MoTa).HasMaxLength(100);

                entity.Property(e => e.TenMonHoc).HasMaxLength(100);

                entity.HasOne(d => d.KhoaHoc)
                    .WithMany(p => p.MonHoc)
                    .HasForeignKey(d => d.KhoaHocId)
                    .HasConstraintName("FK_dbo.BaiHat_dbo.TheLoai_TheLoaiID");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
