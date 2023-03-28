using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TransportManagement.Models.db
{
    public partial class ApplicationOilStationContext : DbContext
    {
        public ApplicationOilStationContext()
        {
        }

        public ApplicationOilStationContext(DbContextOptions<ApplicationOilStationContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MasterAppType> MasterAppTypes { get; set; } = null!;
        public virtual DbSet<TransectionOil> TransectionOils { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.99;Database=ApplicationOilStation;User Id=sa;Password=dogthaiP@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MasterAppType>(entity =>
            {
                entity.HasKey(e => e.MstAutoId)
                    .HasName("PK__MasterAp__F6D4FBAABFC6CF97");

                entity.ToTable("MasterAppType");

                entity.Property(e => e.MstCreateBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MstCreateDate).HasColumnType("datetime");

                entity.Property(e => e.MstDetail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MstEditBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MstEditDate).HasColumnType("datetime");

                entity.Property(e => e.MstImage)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.MstStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.MstTypeId)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TransectionOil>(entity =>
            {
                entity.HasKey(e => e.TrAutoId)
                    .HasName("PK__Transect__164A1D70448BA1C7");

                entity.ToTable("TransectionOil");

                entity.Property(e => e.DistrictEn)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DistrictEN");

                entity.Property(e => e.DistrictTh)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("DistrictTH");

                entity.Property(e => e.DriverCardId)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DriverFullName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.DriverPersonalCard)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GpsIdDtc).HasColumnName("GpsIdDTC");

                entity.Property(e => e.MstTypeId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ProvinceEn)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ProvinceEN");

                entity.Property(e => e.ProvinceTh)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ProvinceTH");

                entity.Property(e => e.StationId)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("StationID");

                entity.Property(e => e.StationName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.SubdistrictEn)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SubdistrictEN");

                entity.Property(e => e.SubdistrictTh)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("SubdistrictTH");

                entity.Property(e => e.Time)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.TrCreateBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrCreateDate).HasColumnType("datetime");

                entity.Property(e => e.TrDocument)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrEditBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrEditDate).HasColumnType("datetime");

                entity.Property(e => e.TrRegistration)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
