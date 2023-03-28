using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace TransportManagement.Models.db
{
    public partial class TransportCCPCPSContext : DbContext
    {
        public TransportCCPCPSContext()
        {
        }

        public TransportCCPCPSContext(DbContextOptions<TransportCCPCPSContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ConfigExpenseTransportCcp> ConfigExpenseTransportCcps { get; set; } = null!;
        public virtual DbSet<ConfigPersonnel> ConfigPersonnel { get; set; } = null!;
        public virtual DbSet<ConfigShippingPrice> ConfigShippingPrices { get; set; } = null!;
        public virtual DbSet<ExpenseTransportCcp> ExpenseTransportCcps { get; set; } = null!;
        public virtual DbSet<ExpenseTransportCcplog> ExpenseTransportCcplogs { get; set; } = null!;
        public virtual DbSet<GiCcp> GiCcps { get; set; } = null!;
        public virtual DbSet<GiCp> GiCps { get; set; } = null!;
        public virtual DbSet<GroupTrnCcp> GroupTrnCcps { get; set; } = null!;
        public virtual DbSet<GroupTrnCp> GroupTrnCps { get; set; } = null!;
        public virtual DbSet<HeaderCcp> HeaderCcps { get; set; } = null!;
        public virtual DbSet<HeaderCcpLog> HeaderCcpLogs { get; set; } = null!;
        public virtual DbSet<HeaderCp> HeaderCps { get; set; } = null!;
        public virtual DbSet<HeaderCpsLog> HeaderCpsLogs { get; set; } = null!;
        public virtual DbSet<IdPayroll> IdPayrolls { get; set; } = null!;
        public virtual DbSet<ItemCcp> ItemCcps { get; set; } = null!;
        public virtual DbSet<ItemCcpLog> ItemCcpLogs { get; set; } = null!;
        public virtual DbSet<ItemCp> ItemCps { get; set; } = null!;
        public virtual DbSet<ItemCpsLog> ItemCpsLogs { get; set; } = null!;
        public virtual DbSet<Log> Logs { get; set; } = null!;
        public virtual DbSet<LogPrintCcp> LogPrintCcps { get; set; } = null!;
        public virtual DbSet<LogPrintCp> LogPrintCps { get; set; } = null!;
        public virtual DbSet<MasterPriceByTransportZone> MasterPriceByTransportZones { get; set; } = null!;
        public virtual DbSet<MasterTruckType> MasterTruckTypes { get; set; } = null!;
        public virtual DbSet<PriceTruck> PriceTrucks { get; set; } = null!;
        public virtual DbSet<PriceTruck1> PriceTruck1s { get; set; } = null!;
        public virtual DbSet<PriceTruckT> PriceTruckTs { get; set; } = null!;
        public virtual DbSet<SpecailTransportZoneCcp> SpecailTransportZoneCcps { get; set; } = null!;
        public virtual DbSet<TblMapemp> TblMapemps { get; set; } = null!;
        public virtual DbSet<ViewCcp> ViewCcps { get; set; } = null!;
        public virtual DbSet<ViewCcpSodomonthNow> ViewCcpSodomonthNows { get; set; } = null!;
        public virtual DbSet<ViewCp> ViewCps { get; set; } = null!;
        public virtual DbSet<ViewCpsSodomonthNow> ViewCpsSodomonthNows { get; set; } = null!;
        public virtual DbSet<ViewGroupCcp> ViewGroupCcps { get; set; } = null!;
        public virtual DbSet<ViewGroupCp> ViewGroupCps { get; set; } = null!;
        public virtual DbSet<ViewHi> ViewHis { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=192.168.0.99;Database=TransportCCPCPS;User Id=sa;Password=dogthaiP@ssw0rd");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("Thai_CS_AS_KS_WS");

            modelBuilder.Entity<ConfigExpenseTransportCcp>(entity =>
            {
                entity.HasKey(e => e.CfautoId)
                    .HasName("PK__ConfigEx__DE25A660DC873C15");

                entity.ToTable("ConfigExpenseTransportCCP");

                entity.Property(e => e.CfautoId).HasColumnName("CFAutoID");

                entity.Property(e => e.CfeditBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CFEditBy");

                entity.Property(e => e.CfeditDate)
                    .HasColumnType("date")
                    .HasColumnName("CFEditDate");

                entity.Property(e => e.Cfname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CFName");

                entity.Property(e => e.Cfprice).HasColumnName("CFPrice");

                entity.Property(e => e.Cfstatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CFStatus");
            });

            modelBuilder.Entity<ConfigPersonnel>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Personnelno)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ConfigShippingPrice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ConfigShippingPrice");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.Price)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpenseTransportCcp>(entity =>
            {
                entity.HasKey(e => e.EtautoId)
                    .HasName("PK__ExpenseT__968F280DBD641839");

                entity.ToTable("ExpenseTransportCCP");

                entity.Property(e => e.EtautoId).HasColumnName("ETAutoID");

                entity.Property(e => e.ActualGidateSap)
                    .HasColumnType("date")
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.Etamount).HasColumnName("ETAmount");

                entity.Property(e => e.Etcfprice).HasColumnName("ETCFPrice");

                entity.Property(e => e.EteditBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ETEditBy");

                entity.Property(e => e.EteditDate)
                    .HasColumnType("date")
                    .HasColumnName("ETEditDate");

                entity.Property(e => e.Etfactory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ETFactory");

                entity.Property(e => e.Etmptprice).HasColumnName("ETMPTPrice");

                entity.Property(e => e.EtshipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ETShipTo");

                entity.Property(e => e.EtshipToName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ETShipToName");

                entity.Property(e => e.Etstatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ETStatus");

                entity.Property(e => e.EttransportZone)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ETTransportZone");

                entity.Property(e => e.EttransportZoneName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("ETTransportZoneName");

                entity.Property(e => e.ShippingName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExpenseTransportCcplog>(entity =>
            {
                entity.HasKey(e => e.LautoId)
                    .HasName("PK__ExpenseT__7611EC4AD00D1CFA");

                entity.ToTable("ExpenseTransportCCPLog");

                entity.Property(e => e.LautoId).HasColumnName("LAutoID");

                entity.Property(e => e.ActualGidateSap)
                    .HasColumnType("date")
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.Lamount).HasColumnName("LAmount");

                entity.Property(e => e.Lcfprice).HasColumnName("LCFPrice");

                entity.Property(e => e.LeditBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LEditBy");

                entity.Property(e => e.LeditDate)
                    .HasColumnType("date")
                    .HasColumnName("LEditDate");

                entity.Property(e => e.Lfactory)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LFactory");

                entity.Property(e => e.Lmptprice).HasColumnName("LMPTPrice");

                entity.Property(e => e.LshipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LShipTo");

                entity.Property(e => e.LshipToName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LShipToName");

                entity.Property(e => e.Lstatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LStatus");

                entity.Property(e => e.LtransportZone)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LTransportZone");

                entity.Property(e => e.LtransportZoneName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("LTransportZoneName");

                entity.Property(e => e.ShippingName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoldToName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GiCcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GI_CCP");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Number");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GiCp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GI_CPS");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Number");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<GroupTrnCcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GroupTRN_CCP");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusJoin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrnNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRN_Number");
            });

            modelBuilder.Entity<GroupTrnCp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GroupTRN_CPS");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.Company)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusJoin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TrnNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRN_Number");
            });

            modelBuilder.Entity<HeaderCcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Header_CCP");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.ActualGidateSap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionShipToiTrading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOiTrading");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransportGi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PriceTransport_GI");

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");
            });

            modelBuilder.Entity<HeaderCcpLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Header_CCP_Log");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDatetimelog)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");
            });

            modelBuilder.Entity<HeaderCp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Header_CPS");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.ActualGidateSap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionShipToiTrading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOiTrading");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransportGi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PriceTransport_GI");

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");
            });

            modelBuilder.Entity<HeaderCpsLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Header_CPS_Log");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDatetimelog)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");
            });

            modelBuilder.Entity<IdPayroll>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IdPayroll");

                entity.Property(e => e.AutoId).ValueGeneratedOnAdd();

                entity.Property(e => e.GruopPayroll)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.IdPayroll1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IdPayroll");

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Text)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ItemCcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Item_CCP");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.Driver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Plant)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StgeLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STGE_LOC");

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WeightItemDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightItemDO");
            });

            modelBuilder.Entity<ItemCcpLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Item_CCP_Log");

                entity.Property(e => e.AutoId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AutoID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.Driver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Plant)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StgeLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STGE_LOC");

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WeightItemDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightItemDO");
            });

            modelBuilder.Entity<ItemCp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Item_CPS");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.Driver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Plant)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StgeLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STGE_LOC");

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WeightItemDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightItemDO");
            });

            modelBuilder.Entity<ItemCpsLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Item_CPS_Log");

                entity.Property(e => e.AutoId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AutoID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.Driver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDatetime)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Plant)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StgeLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STGE_LOC");

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WeightItemDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightItemDO");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Log");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Doc)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(200)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogPrintCcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LogPrint_CCP");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportOut)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<LogPrintCp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("LogPrint_CPS");

                entity.Property(e => e.AutoId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AutoID");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportOut)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<MasterPriceByTransportZone>(entity =>
            {
                entity.HasKey(e => e.MptautoId)
                    .HasName("PK__MasterPr__F6BEB05C5B3AA43B");

                entity.ToTable("MasterPriceByTransportZone");

                entity.Property(e => e.MptautoId).HasColumnName("MPTAutoID");

                entity.Property(e => e.MpteditBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MPTEditBy");

                entity.Property(e => e.MpteditDate)
                    .HasColumnType("date")
                    .HasColumnName("MPTEditDate");

                entity.Property(e => e.Mptprice).HasColumnName("MPTPrice");

                entity.Property(e => e.Mptremark)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MPTRemark");

                entity.Property(e => e.Mptstatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MPTStatus");

                entity.Property(e => e.MpttransportZoneId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("MPTTransportZoneID");

                entity.Property(e => e.MpttransportZoneName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("MPTTransportZoneName");
            });

            modelBuilder.Entity<MasterTruckType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MasterTruckType");

                entity.Property(e => e.AutoId).ValueGeneratedOnAdd();

                entity.Property(e => e.IdTruck)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTruck)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PriceTruck>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PriceTruck");

                entity.Property(e => e.AutoId).ValueGeneratedOnAdd();

                entity.Property(e => e.Max)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("max");

                entity.Property(e => e.Min)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("min");

                entity.Property(e => e.Price)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("price");

                entity.Property(e => e.Trucktype)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("trucktype");
            });

            modelBuilder.Entity<PriceTruck1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PriceTruck1");

                entity.Property(e => e.AutoId)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Max)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("max");

                entity.Property(e => e.Min)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("min");

                entity.Property(e => e.Price)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("price");

                entity.Property(e => e.Trucktype)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("trucktype");
            });

            modelBuilder.Entity<PriceTruckT>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PriceTruckT");

                entity.Property(e => e.AutoId).ValueGeneratedOnAdd();

                entity.Property(e => e.Max)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("max");

                entity.Property(e => e.Min)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("min");

                entity.Property(e => e.Price)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("price");

                entity.Property(e => e.Trucktype)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("trucktype");
            });

            modelBuilder.Entity<SpecailTransportZoneCcp>(entity =>
            {
                entity.HasKey(e => e.StzautoId)
                    .HasName("PK__SpecailT__595CB4BEF08DFC01");

                entity.ToTable("SpecailTransportZoneCCP");

                entity.Property(e => e.StzautoId).HasColumnName("STZAutoID");

                entity.Property(e => e.StzeditBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STZEditBy");

                entity.Property(e => e.StzeditDate)
                    .HasColumnType("date")
                    .HasColumnName("STZEditDate");

                entity.Property(e => e.Stzprice).HasColumnName("STZPrice");

                entity.Property(e => e.Stzstatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STZStatus");

                entity.Property(e => e.StztransportZoneId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STZTransportZoneID");

                entity.Property(e => e.StztransportZoneName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STZTransportZoneName");
            });

            modelBuilder.Entity<TblMapemp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("tbl_mapemp");

                entity.Property(e => e.AutoId).ValueGeneratedOnAdd();

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmpID");

                entity.Property(e => e.EmpSap)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EmpSAP");
            });

            modelBuilder.Entity<ViewCcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CCP");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.ActualGidateSap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionShipToiTrading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOiTrading");

                entity.Property(e => e.Driver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.Plant)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransportGi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PriceTransport_GI");

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StgeLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STGE_LOC");

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");

                entity.Property(e => e.WeightItemDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightItemDO");
            });

            modelBuilder.Entity<ViewCcpSodomonthNow>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CCP_SODOMonthNow");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Expr1).HasColumnName("EXPR1");

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");
            });

            modelBuilder.Entity<ViewCp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CPS");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.ActualGidateSap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionShipToiTrading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOiTrading");

                entity.Property(e => e.Driver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.Plant)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransportGi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PriceTransport_GI");

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StgeLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STGE_LOC");

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");

                entity.Property(e => e.WeightItemDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightItemDO");
            });

            modelBuilder.Entity<ViewCpsSodomonthNow>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_CPS_SODOMonthNow");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");
            });

            modelBuilder.Entity<ViewGroupCcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewGroup_CCP");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.ActualGidateSap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionShipToiTrading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOiTrading");

                entity.Property(e => e.Driver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.Plant)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransportGi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PriceTransport_GI");

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Status_Group");

                entity.Property(e => e.StatusJoin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StgeLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STGE_LOC");

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrnNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRN_Number");

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");

                entity.Property(e => e.WeightItemDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightItemDO");
            });

            modelBuilder.Entity<ViewGroupCp>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("ViewGroup_CPS");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.ActualGidateSap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CarType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionShipToiTrading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOiTrading");

                entity.Property(e => e.Driver)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ItemNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Item_Number");

                entity.Property(e => e.Material)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.Plant)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.Price)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransportGi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PriceTransport_GI");

                entity.Property(e => e.QtyDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_DO");

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.QtySo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_SO");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StatusGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Status_Group");

                entity.Property(e => e.StatusJoin)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StgeLoc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("STGE_LOC");

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Transport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TrnNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRN_Number");

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");

                entity.Property(e => e.WeightItemDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightItemDO");
            });

            modelBuilder.Entity<ViewHi>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("View_HI");

                entity.Property(e => e.ActualGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate");

                entity.Property(e => e.ActualGidateSap)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ActualGIDate_SAP");

                entity.Property(e => e.Amphoe)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AutoId).HasColumnName("AutoID");

                entity.Property(e => e.CreateDate).HasColumnType("datetime");

                entity.Property(e => e.CreateUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DeliveryDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DescriptionShipToiTrading)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Distance)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DistanceiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Date");

                entity.Property(e => e.DoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DO_Number");

                entity.Property(e => e.DocumentDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.DoiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("DOiTrading");

                entity.Property(e => e.EditDate)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EditUser)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.GiDate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("GI_Date");

                entity.Property(e => e.Incoterms)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PlannedGidate)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PlannedGIDate");

                entity.Property(e => e.PlantDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Plant_DO");

                entity.Property(e => e.Ponumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PONumber");

                entity.Property(e => e.PriceTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PriceTransportGi)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PriceTransport_GI");

                entity.Property(e => e.QtyItem)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QTY_Item");

                entity.Property(e => e.Remark)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SaleOrderType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShipToiTrading)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShippingType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SoNumber)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Number");

                entity.Property(e => e.SoTransport)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SO_Transport");

                entity.Property(e => e.SoldTo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Tel)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TransportZone)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TypeTransport)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WeightDo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WeightDO");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
