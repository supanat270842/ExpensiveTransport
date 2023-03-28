using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TransportManagement.Models.dbIGuard
{
    public partial class DataIGuardContext : DbContext
    {
        public DataIGuardContext()
        {
        }

        public DataIGuardContext(DbContextOptions<DataIGuardContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MappingAssetAndDtc> MappingAssetAndDtcs { get; set; } = null!;
        public virtual DbSet<TbApprove> TbApproves { get; set; } = null!;
        public virtual DbSet<TbAsset> TbAssets { get; set; } = null!;
        public virtual DbSet<TbAsset22> TbAsset22s { get; set; } = null!;
        public virtual DbSet<TbAssetTrn> TbAssetTrns { get; set; } = null!;
        public virtual DbSet<TbAssetType> TbAssetTypes { get; set; } = null!;
        public virtual DbSet<TbAuthorize> TbAuthorizes { get; set; } = null!;
        public virtual DbSet<TbDbtruckCcp> TbDbtruckCcps { get; set; } = null!;
        public virtual DbSet<TbDevice> TbDevices { get; set; } = null!;
        public virtual DbSet<TbLocation> TbLocations { get; set; } = null!;
        public virtual DbSet<TbNumber> TbNumbers { get; set; } = null!;
        public virtual DbSet<TbPic> TbPics { get; set; } = null!;
        public virtual DbSet<TbPicBack1> TbPicBack1s { get; set; } = null!;
        public virtual DbSet<TbPicBack2> TbPicBack2s { get; set; } = null!;
        public virtual DbSet<TbTransection> TbTransections { get; set; } = null!;
        public virtual DbSet<TbTransectionBack> TbTransectionBacks { get; set; } = null!;
        public virtual DbSet<TbTransectionBack1> TbTransectionBack1s { get; set; } = null!;
        public virtual DbSet<TbType> TbTypes { get; set; } = null!;
        public virtual DbSet<ViewPic> ViewPics { get; set; } = null!;
        public virtual DbSet<ViewTransection> ViewTransections { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.9;Database=DataIGuard;User Id=sa;Password=dogthaiP@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CS_AS_KS_WS");

            modelBuilder.Entity<MappingAssetAndDtc>(entity =>
            {
                entity.HasKey(e => e.MadautoId)
                    .HasName("PK__MappingA__8CB31DC8ABA97178");

                entity.ToTable("MappingAssetAndDTC");

                entity.Property(e => e.MadautoId).HasColumnName("MADAutoId");

                entity.Property(e => e.AssetId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetID");

                entity.Property(e => e.MadeditBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MADEditBy");

                entity.Property(e => e.MadeditDate)
                    .HasColumnType("date")
                    .HasColumnName("MADEditDate");

                entity.Property(e => e.Madgpsid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MADGPSId");

                entity.Property(e => e.Madremark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MADRemark");

                entity.Property(e => e.Madstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MADStatus");
            });

            modelBuilder.Entity<TbApprove>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Approve");

                entity.Property(e => e.ApproveId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ApproveID");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAsset>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Asset");

                entity.Property(e => e.AssetId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetID");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmpID");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAsset22>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Asset22");

                entity.Property(e => e.AssetId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetID");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmpID");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAssetTrn>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_AssetTRN");

                entity.Property(e => e.AssetId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetID");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmpID");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAssetType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_AssetType");

                entity.Property(e => e.AssetNonePic)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetNonePicOut)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetTypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetTypeID");

                entity.Property(e => e.AssetTypeName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAuthorize>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Authorizes");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmpID");

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeEdit)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbDbtruckCcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_DBTruckCCP");

                entity.Property(e => e.AutoId).ValueGeneratedOnAdd();

                entity.Property(e => e.DbtruckCcp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DBTruckCCP");

                entity.Property(e => e.Fac)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbDevice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Device");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DeviceId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Location");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbNumber>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Number");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.Number)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbPic>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Pic");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTran)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<TbPicBack1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_PicBack1");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTran)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<TbPicBack2>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_PicBack2");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTran)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<TbTransection>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Transection");

                entity.Property(e => e.ApproveId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ApproveID");

                entity.Property(e => e.AssetId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetID");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DetailOut)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusEdc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("StatusEDC");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbTransectionBack>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_TransectionBack");

                entity.Property(e => e.ApproveId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ApproveID");

                entity.Property(e => e.AssetId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetID");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DetailOut)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbTransectionBack1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_TransectionBack1");

                entity.Property(e => e.ApproveId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ApproveID");

                entity.Property(e => e.AssetId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetID");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Detail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DetailOut)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_Type");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.Pin)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PIn");

                entity.Property(e => e.Pout)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("POut");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ViewPic>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Pic");

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeId)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTran)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Url)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("URL");
            });

            modelBuilder.Entity<ViewTransection>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_Transection");

                entity.Property(e => e.ApproveId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ApproveID");

                entity.Property(e => e.AssetId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AssetID");

                entity.Property(e => e.AssetType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.AssetTypeName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CheckIn).HasColumnType("datetime");

                entity.Property(e => e.CheckOut).HasColumnType("datetime");

                entity.Property(e => e.CreateBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.Description)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Detail)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DetailOut)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EditBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Editdate).HasColumnType("datetime");

                entity.Property(e => e.LocationId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("locationID");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusEdc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("StatusEDC");

                entity.Property(e => e.Version)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
