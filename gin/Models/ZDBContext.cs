using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace gin.Models
{
    public partial class ZDBContext : DbContext
    {
        public ZDBContext()
        {
        }

        public ZDBContext(DbContextOptions<ZDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AProduct> AProducts { get; set; } = null!;
        public virtual DbSet<AProduct2> AProduct2s { get; set; } = null!;
        public virtual DbSet<AProductMachine> AProductMachines { get; set; } = null!;
        public virtual DbSet<AProductQuality> AProductQualities { get; set; } = null!;
        public virtual DbSet<AProductQuality2> AProductQuality2s { get; set; } = null!;
        public virtual DbSet<AProductShipDatum> AProductShipData { get; set; } = null!;
        public virtual DbSet<AProductShipMapping> AProductShipMappings { get; set; } = null!;
        public virtual DbSet<AProductShipMessage> AProductShipMessages { get; set; } = null!;
        public virtual DbSet<DespatchName> DespatchNames { get; set; } = null!;
        public virtual DbSet<Factory> Factories { get; set; } = null!;
        public virtual DbSet<FactoryMill> FactoryMills { get; set; } = null!;
        public virtual DbSet<FactoryState> FactoryStates { get; set; } = null!;
        public virtual DbSet<FtyPhoto> FtyPhotos { get; set; } = null!;
        public virtual DbSet<GAirComp> GAirComps { get; set; } = null!;
        public virtual DbSet<GAirCompH> GAirCompHs { get; set; } = null!;
        public virtual DbSet<GAirCompMapping> GAirCompMappings { get; set; } = null!;
        public virtual DbSet<GMachine> GMachines { get; set; } = null!;
        public virtual DbSet<GMachineAccess> GMachineAccesses { get; set; } = null!;
        public virtual DbSet<GMachineCidKeyWord> GMachineCidKeyWords { get; set; } = null!;
        public virtual DbSet<GMachineKeyword> GMachineKeywords { get; set; } = null!;
        public virtual DbSet<GMachineMtbf> GMachineMtbfs { get; set; } = null!;
        public virtual DbSet<GMachineRepair> GMachineRepairs { get; set; } = null!;
        public virtual DbSet<GMachineWorkHour> GMachineWorkHours { get; set; } = null!;
        public virtual DbSet<GMachingWorkValue30m> GMachingWorkValue30ms { get; set; } = null!;
        public virtual DbSet<GMaintainLog> GMaintainLogs { get; set; } = null!;
        public virtual DbSet<GMillingMachine> GMillingMachines { get; set; } = null!;
        public virtual DbSet<GMillingMachineMapping> GMillingMachineMappings { get; set; } = null!;
        public virtual DbSet<GMillingMachineMin> GMillingMachineMins { get; set; } = null!;
        public virtual DbSet<GMillingPMachine> GMillingPMachines { get; set; } = null!;
        public virtual DbSet<GMillingPMap> GMillingPMaps { get; set; } = null!;
        public virtual DbSet<GPower> GPowers { get; set; } = null!;
        public virtual DbSet<GPowerBill> GPowerBills { get; set; } = null!;
        public virtual DbSet<GPowerCalender> GPowerCalenders { get; set; } = null!;
        public virtual DbSet<GPowerD> GPowerDs { get; set; } = null!;
        public virtual DbSet<GPowerH> GPowerHs { get; set; } = null!;
        public virtual DbSet<GPowerH1> GPowerH1s { get; set; } = null!;
        public virtual DbSet<GPowerM> GPowerMs { get; set; } = null!;
        public virtual DbSet<GPowerMapping> GPowerMappings { get; set; } = null!;
        public virtual DbSet<GPowerPeakDate> GPowerPeakDates { get; set; } = null!;
        public virtual DbSet<GSe> GSes { get; set; } = null!;
        public virtual DbSet<GSeD> GSeDs { get; set; } = null!;
        public virtual DbSet<GSeH> GSeHs { get; set; } = null!;
        public virtual DbSet<GSeM> GSeMs { get; set; } = null!;
        public virtual DbSet<GTpc> GTpcs { get; set; } = null!;
        public virtual DbSet<GTpcD> GTpcDs { get; set; } = null!;
        public virtual DbSet<GTpcH> GTpcHes { get; set; } = null!;
        public virtual DbSet<GTpcM> GTpcMs { get; set; } = null!;
        public virtual DbSet<GWeighingH> GWeighingHs { get; set; } = null!;
        public virtual DbSet<GWeighingMapping> GWeighingMappings { get; set; } = null!;
        public virtual DbSet<LocalhostCpuRam> LocalhostCpuRams { get; set; } = null!;
        public virtual DbSet<LogErrorMsg> LogErrorMsgs { get; set; } = null!;
        public virtual DbSet<MillWorkdataView> MillWorkdataViews { get; set; } = null!;
        public virtual DbSet<OccDespatch> OccDespatches { get; set; } = null!;
        public virtual DbSet<RMonthCondition> RMonthConditions { get; set; } = null!;
        public virtual DbSet<RMonthReoprt> RMonthReoprts { get; set; } = null!;
        public virtual DbSet<TagGroup> TagGroups { get; set; } = null!;
        public virtual DbSet<TagList> TagLists { get; set; } = null!;
        public virtual DbSet<TagNameDesc> TagNameDescs { get; set; } = null!;
        public virtual DbSet<ValueDaily> ValueDailies { get; set; } = null!;
        public virtual DbSet<ValueHour> ValueHours { get; set; } = null!;
        public virtual DbSet<ValueMin> ValueMins { get; set; } = null!;
        public virtual DbSet<WLoginGroup> WLoginGroups { get; set; } = null!;
        public virtual DbSet<WLoginGroupRight> WLoginGroupRights { get; set; } = null!;
        public virtual DbSet<WLoginLogfile> WLoginLogfiles { get; set; } = null!;
        public virtual DbSet<WLoginRight> WLoginRights { get; set; } = null!;
        public virtual DbSet<WLoginUser> WLoginUsers { get; set; } = null!;
        public virtual DbSet<WSubPage> WSubPages { get; set; } = null!;
        public virtual DbSet<WWebPage> WWebPages { get; set; } = null!;
        public virtual DbSet<WeatherDay> WeatherDays { get; set; } = null!;
        public virtual DbSet<WeatherHour> WeatherHours { get; set; } = null!;
        
        public DbSet<GMMins> GMMs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AProduct>(entity =>
            {
                entity.HasKey(e => e.ProductId)
                    .HasName("PK_Product");

                entity.ToTable("A_Product");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(50);
            });

            modelBuilder.Entity<AProduct2>(entity =>
            {
                entity.HasKey(e => e.ProductId);

                entity.ToTable("A_Product2");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.Property(e => e.Proportion)
                    .HasColumnType("decimal(3, 2)")
                    .HasColumnName("proportion");
            });

            modelBuilder.Entity<AProductMachine>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.MillId, e.Dtime });

                entity.ToTable("A_Product_Machine");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("Factory_ID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.DeviceValue1Mill)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Device_Value_1_Mill");

                entity.Property(e => e.DeviceValue1Pressure)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Device_Value_1_pressure");

                entity.Property(e => e.DeviceValue2Mill)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Device_Value_2_Mill");

                entity.Property(e => e.DeviceValue2Pressure)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Device_Value_2_pressure");

                entity.Property(e => e.DeviceValueBlower)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Device_Value_blower");

                entity.Property(e => e.DeviceValueCarrier)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Device_Value_Carrier");

                entity.Property(e => e.Moisture).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .HasColumnName("ProductID");

                entity.Property(e => e.ResidualOnSieve)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Residual_On_Sieve");

                entity.Property(e => e.SpecificSurface)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Specific_Surface");
            });

            modelBuilder.Entity<AProductQuality>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.MillId, e.Dtime, e.DateTime, e.ProductId });

                entity.ToTable("A_Product_Quality");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .HasColumnName("ProductID");

                entity.Property(e => e.ClientInfo)
                    .HasMaxLength(255)
                    .HasColumnName("Client_Info");

                entity.Property(e => e.Moisture).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ResidualOnSieve)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Residual_On_Sieve");

                entity.Property(e => e.SpecificSurface)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Specific_Surface");

                entity.Property(e => e.Visible).HasMaxLength(1);
            });

            modelBuilder.Entity<AProductQuality2>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.MillId, e.Dtime, e.DateTime, e.ProductId, e.ClientInfo, e.Laboratory });

                entity.ToTable("A_Product_Quality2");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.DateTime).HasColumnType("datetime");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .HasColumnName("ProductID");

                entity.Property(e => e.ClientInfo)
                    .HasMaxLength(255)
                    .HasColumnName("Client_Info");

                entity.Property(e => e.Laboratory).HasMaxLength(15);

                entity.Property(e => e.Moisture).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.ResidualOnSieve)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Residual_On_Sieve");

                entity.Property(e => e.SpecificSurface)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Specific_Surface");

                entity.Property(e => e.Visible).HasMaxLength(1);
            });

            modelBuilder.Entity<AProductShipDatum>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.DataDate, e.Dhour, e.LibraryClass });

                entity.ToTable("A_Product_Ship_data");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.Dhour).HasColumnName("DHour");

                entity.Property(e => e.LibraryClass).HasColumnName("Library_Class");

                entity.Property(e => e.Value).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<AProductShipMapping>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.BarrelTank })
                    .HasName("PK_A_Product_Ship_Mapping_1");

                entity.ToTable("A_Product_Ship_Mapping");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.BarrelTank).HasColumnName("Barrel_tank");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(10)
                    .HasColumnName("ProductID");

                entity.Property(e => e.Proportion)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("proportion");

                entity.Property(e => e.TotalHeight)
                    .HasColumnType("decimal(5, 2)")
                    .HasColumnName("Total_Height");
            });

            modelBuilder.Entity<AProductShipMessage>(entity =>
            {
                entity.HasKey(e => new { e.Dtime, e.Dhour, e.FactoryId })
                    .HasName("PK_A_Product_Ship_Message_1");

                entity.ToTable("A_Product_Ship_Message");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.Dhour).HasColumnName("DHour");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(20)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Message)
                    .HasMaxLength(200)
                    .HasColumnName("message");
            });

            modelBuilder.Entity<DespatchName>(entity =>
            {
                entity.HasKey(e => e.ProdId);

                entity.ToTable("Despatch_Name");

                entity.Property(e => e.ProdId)
                    .HasMaxLength(2)
                    .HasColumnName("PROD_ID")
                    .IsFixedLength();

                entity.Property(e => e.Cpackage)
                    .HasMaxLength(5)
                    .HasColumnName("CPACKAGE")
                    .IsFixedLength();

                entity.Property(e => e.ProdName)
                    .HasMaxLength(50)
                    .HasColumnName("PROD_NAME")
                    .IsFixedLength();
            });

            modelBuilder.Entity<Factory>(entity =>
            {
                entity.ToTable("Factory");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.AOrder).HasColumnName("aOrder");

                entity.Property(e => e.FactoryName).HasMaxLength(10);

                entity.Property(e => e.ServerIp)
                    .HasMaxLength(50)
                    .HasColumnName("ServerIP");

                entity.Property(e => e.TpcAct)
                    .HasMaxLength(20)
                    .HasColumnName("Tpc_act");

                entity.Property(e => e.TpcPwd)
                    .HasMaxLength(20)
                    .HasColumnName("Tpc_pwd");
            });

            modelBuilder.Entity<FactoryMill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Factory_Mill");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");
            });

            modelBuilder.Entity<FactoryState>(entity =>
            {
                entity.HasKey(e => new { e.Dtime, e.Host1, e.Host2 });

                entity.ToTable("Factory_State");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.Host1).HasMaxLength(20);

                entity.Property(e => e.Host2).HasMaxLength(20);

                entity.Property(e => e.Message).HasColumnName("message");
            });

            modelBuilder.Entity<FtyPhoto>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.FactoryId });

                entity.ToTable("Fty_Photo");

                entity.Property(e => e.Id)
                    .HasMaxLength(20)
                    .HasColumnName("ID");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Dust).HasMaxLength(5);

                entity.Property(e => e.Lane).HasMaxLength(10);

                entity.Property(e => e.LicenseId)
                    .HasMaxLength(10)
                    .HasColumnName("LicenseID");

                entity.Property(e => e.OrderId1)
                    .HasMaxLength(11)
                    .HasColumnName("ORDER_ID1");

                entity.Property(e => e.Remark).HasMaxLength(255);

                entity.Property(e => e.Time1).HasColumnType("datetime");

                entity.Property(e => e.Time2).HasColumnType("datetime");

                entity.Property(e => e.UnsafetyHat)
                    .HasMaxLength(5)
                    .HasColumnName("Unsafety_hat");

                entity.Property(e => e.UnsafetyPerson)
                    .HasMaxLength(5)
                    .HasColumnName("Unsafety_Person");

                entity.Property(e => e.WorkId)
                    .HasMaxLength(11)
                    .HasColumnName("WORK_ID");
            });

            modelBuilder.Entity<GAirComp>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Mid, e.DataDate });

                entity.ToTable("G_Air_Comp");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Mid)
                    .HasMaxLength(10)
                    .HasColumnName("MID");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.AirAcc01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Air_acc_01");

                entity.Property(e => e.AirAcc02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Air_acc_02");

                entity.Property(e => e.AirConsumption)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Air_Consumption");

                entity.Property(e => e.GetDateTime).HasColumnType("datetime");

                entity.Property(e => e.Power01)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_01");

                entity.Property(e => e.Power02)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_02");

                entity.Property(e => e.Power03)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_03");

                entity.Property(e => e.Power04)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_04");

                entity.Property(e => e.Power05)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_05");

                entity.Property(e => e.PowerC)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C");

                entity.Property(e => e.PowerC01)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_01");

                entity.Property(e => e.PowerC02)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_02");

                entity.Property(e => e.PowerC03)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_03");

                entity.Property(e => e.PowerC04)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_04");

                entity.Property(e => e.PowerC05)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_05");

                entity.Property(e => e.PowerCh01)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_01");

                entity.Property(e => e.PowerCh02)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_02");

                entity.Property(e => e.PowerCh03)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_03");

                entity.Property(e => e.PowerCh04)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_04");

                entity.Property(e => e.PowerCh05)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_05");

                entity.Property(e => e.SpecificPower)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Specific_Power");

                entity.Property(e => e.WorkTime01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_01");

                entity.Property(e => e.WorkTime02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_02");

                entity.Property(e => e.WorkTime03)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_03");

                entity.Property(e => e.WorkTime04)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_04");

                entity.Property(e => e.WorkTime05)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_05");
            });

            modelBuilder.Entity<GAirCompH>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Mid, e.Dtime });

                entity.ToTable("G_Air_Comp_H");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Mid)
                    .HasMaxLength(10)
                    .HasColumnName("MID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.AirAcc01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Air_acc_01");

                entity.Property(e => e.AirAcc02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Air_acc_02");

                entity.Property(e => e.AirConsumption)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Air_Consumption");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.Dhour).HasColumnName("DHour");

                entity.Property(e => e.Power01)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_01");

                entity.Property(e => e.Power02)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_02");

                entity.Property(e => e.Power03)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_03");

                entity.Property(e => e.Power04)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_04");

                entity.Property(e => e.Power05)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_05");

                entity.Property(e => e.PowerC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C");

                entity.Property(e => e.PowerC01)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_01");

                entity.Property(e => e.PowerC02)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_02");

                entity.Property(e => e.PowerC03)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_03");

                entity.Property(e => e.PowerC04)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_04");

                entity.Property(e => e.PowerC05)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_05");

                entity.Property(e => e.PowerCh01)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_01");

                entity.Property(e => e.PowerCh02)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_02");

                entity.Property(e => e.PowerCh03)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_03");

                entity.Property(e => e.PowerCh04)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_04");

                entity.Property(e => e.PowerCh05)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_CH_05");

                entity.Property(e => e.SpecificPower)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Specific_Power");

                entity.Property(e => e.WorkTime01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_01");

                entity.Property(e => e.WorkTime02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_02");

                entity.Property(e => e.WorkTime03)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_03");

                entity.Property(e => e.WorkTime04)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_04");

                entity.Property(e => e.WorkTime05)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_05");
            });

            modelBuilder.Entity<GAirCompMapping>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Mid });

                entity.ToTable("G_Air_Comp_Mapping");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Mid)
                    .HasMaxLength(10)
                    .HasColumnName("MID");

                entity.Property(e => e.AirAcc01)
                    .HasMaxLength(50)
                    .HasColumnName("Air_acc_01");

                entity.Property(e => e.AirAcc02)
                    .HasMaxLength(50)
                    .HasColumnName("Air_acc_02");

                entity.Property(e => e.Power01)
                    .HasMaxLength(50)
                    .HasColumnName("Power_01");

                entity.Property(e => e.Power02)
                    .HasMaxLength(50)
                    .HasColumnName("Power_02");

                entity.Property(e => e.Power03)
                    .HasMaxLength(50)
                    .HasColumnName("Power_03");

                entity.Property(e => e.Power04)
                    .HasMaxLength(50)
                    .HasColumnName("Power_04");

                entity.Property(e => e.Power05)
                    .HasMaxLength(50)
                    .HasColumnName("Power_05");

                entity.Property(e => e.WorkTime01)
                    .HasMaxLength(50)
                    .HasColumnName("WorkTime_01");

                entity.Property(e => e.WorkTime02)
                    .HasMaxLength(50)
                    .HasColumnName("WorkTime_02");

                entity.Property(e => e.WorkTime03)
                    .HasMaxLength(50)
                    .HasColumnName("WorkTime_03");

                entity.Property(e => e.WorkTime04)
                    .HasMaxLength(50)
                    .HasColumnName("WorkTime_04");

                entity.Property(e => e.WorkTime05)
                    .HasMaxLength(50)
                    .HasColumnName("WorkTime_05");
            });

            modelBuilder.Entity<GMachine>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.DeviceNum });

                entity.ToTable("G_Machine");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(30)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.DeviceNum)
                    .HasMaxLength(20)
                    .HasColumnName("Device_Num");

                entity.Property(e => e.Bach).HasColumnName("bach");

                entity.Property(e => e.ClassName)
                    .HasMaxLength(50)
                    .HasColumnName("Class_Name");

                entity.Property(e => e.CountTag)
                    .HasMaxLength(20)
                    .HasColumnName("Count_Tag");

                entity.Property(e => e.CountTotalTag)
                    .HasMaxLength(30)
                    .HasColumnName("Count_Total_Tag");

                entity.Property(e => e.MachineNum).HasColumnName("Machine_num");

                entity.Property(e => e.Par).HasColumnName("par");
            });

            modelBuilder.Entity<GMachineAccess>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK_G_Machine_Access_1");

                entity.ToTable("G_Machine_Access");

                entity.Property(e => e.Cid)
                    .HasMaxLength(20)
                    .HasColumnName("CID");

                entity.Property(e => e.AccessCount)
                    .HasMaxLength(25)
                    .HasColumnName("Access_Count");

                entity.Property(e => e.AccessName)
                    .HasMaxLength(25)
                    .HasColumnName("Access_Name");

                entity.Property(e => e.AccessSpec).HasColumnName("Access_Spec");

                entity.Property(e => e.AssetsNum)
                    .HasMaxLength(30)
                    .HasColumnName("Assets_Num");

                entity.Property(e => e.ClassName).HasMaxLength(20);

                entity.Property(e => e.DeviceNum)
                    .HasMaxLength(20)
                    .HasColumnName("Device_Num");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(30)
                    .HasColumnName("Factory_ID");

                entity.Property(e => e.FilePath)
                    .HasMaxLength(150)
                    .HasColumnName("File_Path");

                entity.Property(e => e.LinkTag)
                    .HasMaxLength(30)
                    .HasColumnName("Link_Tag");

                entity.Property(e => e.MaterialsNum)
                    .HasMaxLength(30)
                    .HasColumnName("Materials_Num");

                entity.Property(e => e.NextDatePm).HasColumnName("Next_Date_PM");

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(20)
                    .HasColumnName("Object_ID");

                entity.Property(e => e.Stop).HasMaxLength(1);
            });

            modelBuilder.Entity<GMachineCidKeyWord>(entity =>
            {
                entity.HasKey(e => e.Cid);

                entity.ToTable("G_Machine_CID_KeyWord");

                entity.Property(e => e.Cid)
                    .HasMaxLength(20)
                    .HasColumnName("CID");

                entity.Property(e => e.KeyWordName)
                    .HasMaxLength(50)
                    .HasColumnName("KeyWord_Name");
            });

            modelBuilder.Entity<GMachineKeyword>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("G_Machine_Keyword");

                entity.Property(e => e.KeyWordName)
                    .HasMaxLength(50)
                    .HasColumnName("KeyWord_Name");
            });

            modelBuilder.Entity<GMachineMtbf>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.ObjectId });

                entity.ToTable("G_Machine_MTBF");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(30)
                    .HasColumnName("Factory_ID");

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(20)
                    .HasColumnName("Object_ID");

                entity.Property(e => e.ClassName).HasMaxLength(20);

                entity.Property(e => e.LinkTag)
                    .HasMaxLength(30)
                    .HasColumnName("Link_Tag");

                entity.Property(e => e.StopFlag)
                    .HasMaxLength(2)
                    .HasColumnName("Stop_Flag");

                entity.Property(e => e.StopTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Stop_Time");
            });

            modelBuilder.Entity<GMachineRepair>(entity =>
            {
                entity.HasKey(e => new { e.Cid, e.RepairNum });

                entity.ToTable("G_Machine_Repair");

                entity.Property(e => e.Cid)
                    .HasMaxLength(20)
                    .HasColumnName("CID");

                entity.Property(e => e.RepairNum)
                    .HasMaxLength(30)
                    .HasColumnName("Repair_Num");

                entity.Property(e => e.CaculateWorkTime)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Caculate_Work_Time");

                entity.Property(e => e.CalculateChangeDate)
                    .HasColumnType("date")
                    .HasColumnName("Calculate_Change_Date");

                entity.Property(e => e.ChangeDate)
                    .HasColumnType("date")
                    .HasColumnName("Change_Date");

                entity.Property(e => e.ChangeNum).HasColumnName("Change_Num");

                entity.Property(e => e.ChangePerson)
                    .HasMaxLength(3)
                    .HasColumnName("Change_Person");

                entity.Property(e => e.ChangeReason)
                    .HasMaxLength(20)
                    .HasColumnName("Change_Reason");

                entity.Property(e => e.CountFlag)
                    .HasMaxLength(1)
                    .HasColumnName("Count_Flag");

                entity.Property(e => e.CreateAccount)
                    .HasMaxLength(20)
                    .HasColumnName("Create_Account");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(30)
                    .HasColumnName("Factory_ID");

                entity.Property(e => e.MarkLable)
                    .HasMaxLength(15)
                    .HasColumnName("Mark_Lable");

                entity.Property(e => e.Note).HasMaxLength(100);

                entity.Property(e => e.ObjectId)
                    .HasMaxLength(20)
                    .HasColumnName("Object_ID");

                entity.Property(e => e.PartsDetail)
                    .HasMaxLength(50)
                    .HasColumnName("Parts_Detail");

                entity.Property(e => e.PartsName)
                    .HasMaxLength(25)
                    .HasColumnName("Parts_Name");

                entity.Property(e => e.ServiceLife).HasColumnName("Service_Life");

                entity.Property(e => e.StopAccount)
                    .HasMaxLength(20)
                    .HasColumnName("Stop_Account");

                entity.Property(e => e.StopTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Stop_Time");

                entity.Property(e => e.UpdateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Update_Time");

                entity.Property(e => e.WorkTime)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Work_Time");
            });

            modelBuilder.Entity<GMachineWorkHour>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.TagName, e.Ddate });

                entity.ToTable("G_Machine_WorkHour");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.TagName).HasMaxLength(20);

                entity.Property(e => e.Ddate)
                    .HasColumnType("date")
                    .HasColumnName("DDate");

                entity.Property(e => e.WorkHour).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<GMachingWorkValue30m>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.TagName, e.Mdate });

                entity.ToTable("G_Maching_WorkValue_30M");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(30)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.TagName).HasMaxLength(15);

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.Mname)
                    .HasMaxLength(15)
                    .HasColumnName("MName");

                entity.Property(e => e.Mvalue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("MValue");

                entity.Property(e => e.TotalMvalue)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Total_MValue");
            });

            modelBuilder.Entity<GMaintainLog>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.TagName, e.MaintainDate, e.Ver });

                entity.ToTable("G_Maintain_Log");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.TagName).HasMaxLength(20);

                entity.Property(e => e.MaintainDate).HasColumnType("date");

                entity.Property(e => e.CreatDate).HasColumnType("date");

                entity.Property(e => e.MaintainDesc).HasMaxLength(100);

                entity.Property(e => e.MaintainDetil).HasMaxLength(100);
            });

            modelBuilder.Entity<GMillingMachine>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.MillId, e.Ddate, e.DataTime });

                entity.ToTable("G_Milling_Machine");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.Ddate)
                    .HasColumnType("date")
                    .HasColumnName("DDate");

                entity.Property(e => e.DataTime).HasColumnType("datetime");

                entity.Property(e => e.BagColletcotM1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_M1");

                entity.Property(e => e.BagColletcotM2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_M2");

                entity.Property(e => e.BagColletcotS)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_S");

                entity.Property(e => e.BucketElevatorA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bucket_Elevator_A");

                entity.Property(e => e.BucketElevatorB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bucket_Elevator_B");

                entity.Property(e => e.Dtime).HasColumnName("DTime");

                entity.Property(e => e.MotorCurrentA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_Current_A");

                entity.Property(e => e.MotorCurrentB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_Current_B");

                entity.Property(e => e.MotorPowerKwA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_PowerKW_A");

                entity.Property(e => e.MotorPowerKwB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_PowerKW_B");

                entity.Property(e => e.OpBcM1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_M1");

                entity.Property(e => e.OpBcM2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_M2");

                entity.Property(e => e.OpBcS)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_S");

                entity.Property(e => e.OsepaCurrent)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OSEPA_Current");

                entity.Property(e => e.OsepaRpm)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OSEPA_RPM");

                entity.Property(e => e.RpmBcM1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("RPM_BC_M1");

                entity.Property(e => e.RpmBcM2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("RPM_BC_M2");

                entity.Property(e => e.RpmBcS)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("RPM_BC_S");

                entity.Property(e => e.TeMillAirA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Air_A");

                entity.Property(e => e.TeMillAirB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Air_B");

                entity.Property(e => e.TeMillBearingInA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_In_A");

                entity.Property(e => e.TeMillBearingInB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_In_B");

                entity.Property(e => e.TeMillBearingOilInA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Oil_In_A");

                entity.Property(e => e.TeMillBearingOilInB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Oil_In_B");

                entity.Property(e => e.TeMillBearingOilOutA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Oil_Out_A");

                entity.Property(e => e.TeMillBearingOilOutB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Oil_Out_B");

                entity.Property(e => e.TeMillBearingOutA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Out_A");

                entity.Property(e => e.TeMillBearingOutB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Out_B");

                entity.Property(e => e.TeMillRawA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_RAW_A");

                entity.Property(e => e.TeMillRawB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_RAW_B");

                entity.Property(e => e.TeMotor1A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_1_A");

                entity.Property(e => e.TeMotor1B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_1_B");

                entity.Property(e => e.TeMotor2A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_2_A");

                entity.Property(e => e.TeMotor2B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_2_B");

                entity.Property(e => e.TeMotor3A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_3_A");

                entity.Property(e => e.TeMotor3B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_3_B");

                entity.Property(e => e.TeMotor4A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_4_A");

                entity.Property(e => e.TeMotor4B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_4_B");

                entity.Property(e => e.TeMotor5A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_5_A");

                entity.Property(e => e.TeMotor5B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_5_B");

                entity.Property(e => e.TeMotor6A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_6_A");

                entity.Property(e => e.TeMotor6B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_6_B");

                entity.Property(e => e.TeProduct)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Product");

                entity.Property(e => e.TeSIn)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_S_In");

                entity.Property(e => e.WM1AC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_A_C");

                entity.Property(e => e.WM1AP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_A_P");

                entity.Property(e => e.WM1AQ)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_A_Q");

                entity.Property(e => e.WM1BC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_B_C");

                entity.Property(e => e.WM1BP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_B_P");

                entity.Property(e => e.WM1BQ)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_B_Q");

                entity.Property(e => e.WM2AC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_A_C");

                entity.Property(e => e.WM2AP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_A_P");

                entity.Property(e => e.WM2AQ)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_A_Q");

                entity.Property(e => e.WM2BC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_B_C");

                entity.Property(e => e.WM2BP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_B_P");

                entity.Property(e => e.WM2BQ)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_B_Q");

                entity.Property(e => e.WpBcSDiff)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_BC_S_Diff");

                entity.Property(e => e.WpBcSIn)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_BC_S_IN");

                entity.Property(e => e.WpMillA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_Mill_A");

                entity.Property(e => e.WpMillB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_Mill_B");

                entity.Property(e => e.WpOsepa)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_OSEPA");
            });

            modelBuilder.Entity<GMillingMachineMapping>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.MillId });

                entity.ToTable("G_Milling_Machine_Mapping");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.BagColletcotM1)
                    .HasMaxLength(50)
                    .HasColumnName("Bag_Colletcot_M1");

                entity.Property(e => e.BagColletcotM2)
                    .HasMaxLength(50)
                    .HasColumnName("Bag_Colletcot_M2");

                entity.Property(e => e.BagColletcotS)
                    .HasMaxLength(50)
                    .HasColumnName("Bag_Colletcot_S");

                entity.Property(e => e.BucketElevatorA)
                    .HasMaxLength(50)
                    .HasColumnName("Bucket_Elevator_A");

                entity.Property(e => e.BucketElevatorB)
                    .HasMaxLength(50)
                    .HasColumnName("Bucket_Elevator_B");

                entity.Property(e => e.MotorCurrentA)
                    .HasMaxLength(50)
                    .HasColumnName("Motor_Current_A");

                entity.Property(e => e.MotorCurrentB)
                    .HasMaxLength(50)
                    .HasColumnName("Motor_Current_B");

                entity.Property(e => e.MotorPowerKwA)
                    .HasMaxLength(50)
                    .HasColumnName("Motor_PowerKW_A");

                entity.Property(e => e.MotorPowerKwB)
                    .HasMaxLength(50)
                    .HasColumnName("Motor_PowerKW_B");

                entity.Property(e => e.OpBcM1)
                    .HasMaxLength(50)
                    .HasColumnName("OP_BC_M1");

                entity.Property(e => e.OpBcM2)
                    .HasMaxLength(50)
                    .HasColumnName("OP_BC_M2");

                entity.Property(e => e.OpBcS)
                    .HasMaxLength(50)
                    .HasColumnName("OP_BC_S");

                entity.Property(e => e.OsepaCurrent)
                    .HasMaxLength(50)
                    .HasColumnName("OSEPA_Current");

                entity.Property(e => e.OsepaRpm)
                    .HasMaxLength(50)
                    .HasColumnName("OSEPA_RPM");

                entity.Property(e => e.RpmBcM1)
                    .HasMaxLength(50)
                    .HasColumnName("RPM_BC_M1");

                entity.Property(e => e.RpmBcM2)
                    .HasMaxLength(50)
                    .HasColumnName("RPM_BC_M2");

                entity.Property(e => e.RpmBcS)
                    .HasMaxLength(50)
                    .HasColumnName("RPM_BC_S");

                entity.Property(e => e.TeMillAirA)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Air_A");

                entity.Property(e => e.TeMillAirB)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Air_B");

                entity.Property(e => e.TeMillBearingInA)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Bearing_In_A");

                entity.Property(e => e.TeMillBearingInB)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Bearing_In_B");

                entity.Property(e => e.TeMillBearingOilInA)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Bearing_Oil_In_A");

                entity.Property(e => e.TeMillBearingOilInB)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Bearing_Oil_In_B");

                entity.Property(e => e.TeMillBearingOilOutA)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Bearing_Oil_Out_A");

                entity.Property(e => e.TeMillBearingOilOutB)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Bearing_Oil_Out_B");

                entity.Property(e => e.TeMillBearingOutA)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Bearing_Out_A");

                entity.Property(e => e.TeMillBearingOutB)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Bearing_Out_B");

                entity.Property(e => e.TeMillRawA)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_RAW_A");

                entity.Property(e => e.TeMillRawB)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_RAW_B");

                entity.Property(e => e.TeMotor1A)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_1_A");

                entity.Property(e => e.TeMotor1B)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_1_B");

                entity.Property(e => e.TeMotor2A)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_2_A");

                entity.Property(e => e.TeMotor2B)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_2_B");

                entity.Property(e => e.TeMotor3A)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_3_A");

                entity.Property(e => e.TeMotor3B)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_3_B");

                entity.Property(e => e.TeMotor4A)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_4_A");

                entity.Property(e => e.TeMotor4B)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_4_B");

                entity.Property(e => e.TeMotor5A)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_5_A");

                entity.Property(e => e.TeMotor5B)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_5_B");

                entity.Property(e => e.TeMotor6A)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_6_A");

                entity.Property(e => e.TeMotor6B)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Motor_6_B");

                entity.Property(e => e.TeProduct)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Product");

                entity.Property(e => e.TeSIn)
                    .HasMaxLength(50)
                    .HasColumnName("TE_S_In");

                entity.Property(e => e.WM1AC)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_A_C");

                entity.Property(e => e.WM1AC2)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_A_C2");

                entity.Property(e => e.WM1AP)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_A_P");

                entity.Property(e => e.WM1AQ)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_A_Q");

                entity.Property(e => e.WM1BC)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_B_C");

                entity.Property(e => e.WM1BC2)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_B_C2");

                entity.Property(e => e.WM1BP)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_B_P");

                entity.Property(e => e.WM1BQ)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_B_Q");

                entity.Property(e => e.WM2AC)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_A_C");

                entity.Property(e => e.WM2AC2)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_A_C2");

                entity.Property(e => e.WM2AP)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_A_P");

                entity.Property(e => e.WM2AQ)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_A_Q");

                entity.Property(e => e.WM2BC)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_B_C");

                entity.Property(e => e.WM2BC2)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_B_C2");

                entity.Property(e => e.WM2BP)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_B_P");

                entity.Property(e => e.WM2BQ)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_B_Q");

                entity.Property(e => e.WpBcSDiff)
                    .HasMaxLength(50)
                    .HasColumnName("WP_BC_S_Diff");

                entity.Property(e => e.WpBcSIn)
                    .HasMaxLength(50)
                    .HasColumnName("WP_BC_S_IN");

                entity.Property(e => e.WpMillA)
                    .HasMaxLength(50)
                    .HasColumnName("WP_Mill_A");

                entity.Property(e => e.WpMillB)
                    .HasMaxLength(50)
                    .HasColumnName("WP_Mill_B");

                entity.Property(e => e.WpOsepa)
                    .HasMaxLength(50)
                    .HasColumnName("WP_OSEPA");
            });

            modelBuilder.Entity<GMillingMachineMin>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.MillId, e.DataTime })
                    .HasName("PK_G_Milling_Machine_Min_1");

                entity.ToTable("G_Milling_Machine_Min");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.DataTime).HasColumnType("datetime");

                entity.Property(e => e.BagColletcotM1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_M1");

                entity.Property(e => e.BagColletcotM2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_M2");

                entity.Property(e => e.BagColletcotS)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_S");

                entity.Property(e => e.BucketElevatorA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bucket_Elevator_A");

                entity.Property(e => e.BucketElevatorB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bucket_Elevator_B");

                entity.Property(e => e.MotorCurrentA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_Current_A");

                entity.Property(e => e.MotorCurrentB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_Current_B");

                entity.Property(e => e.MotorPowerKwA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_PowerKW_A");

                entity.Property(e => e.MotorPowerKwB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_PowerKW_B");

                entity.Property(e => e.OpBcM1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_M1");

                entity.Property(e => e.OpBcM2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_M2");

                entity.Property(e => e.OpBcS)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_S");

                entity.Property(e => e.OsepaCurrent)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OSEPA_Current");

                entity.Property(e => e.OsepaRpm)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OSEPA_RPM");

                entity.Property(e => e.RpmBcM1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("RPM_BC_M1");

                entity.Property(e => e.RpmBcM2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("RPM_BC_M2");

                entity.Property(e => e.RpmBcS)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("RPM_BC_S");

                entity.Property(e => e.TeMillAirA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Air_A");

                entity.Property(e => e.TeMillAirB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Air_B");

                entity.Property(e => e.TeMillBearingInA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_In_A");

                entity.Property(e => e.TeMillBearingInB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_In_B");

                entity.Property(e => e.TeMillBearingOilInA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Oil_In_A");

                entity.Property(e => e.TeMillBearingOilInB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Oil_In_B");

                entity.Property(e => e.TeMillBearingOilOutA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Oil_Out_A");

                entity.Property(e => e.TeMillBearingOilOutB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Oil_Out_B");

                entity.Property(e => e.TeMillBearingOutA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Out_A");

                entity.Property(e => e.TeMillBearingOutB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Bearing_Out_B");

                entity.Property(e => e.TeMillRawA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_RAW_A");

                entity.Property(e => e.TeMillRawB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_RAW_B");

                entity.Property(e => e.TeMotor1A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_1_A");

                entity.Property(e => e.TeMotor1B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_1_B");

                entity.Property(e => e.TeMotor2A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_2_A");

                entity.Property(e => e.TeMotor2B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_2_B");

                entity.Property(e => e.TeMotor3A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_3_A");

                entity.Property(e => e.TeMotor3B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_3_B");

                entity.Property(e => e.TeMotor4A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_4_A");

                entity.Property(e => e.TeMotor4B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_4_B");

                entity.Property(e => e.TeMotor5A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_5_A");

                entity.Property(e => e.TeMotor5B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_5_B");

                entity.Property(e => e.TeMotor6A)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_6_A");

                entity.Property(e => e.TeMotor6B)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Motor_6_B");

                entity.Property(e => e.TeProduct)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Product");

                entity.Property(e => e.TeSIn)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_S_In");

                entity.Property(e => e.WM1AC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_A_C");

                entity.Property(e => e.WM1AP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_A_P");

                entity.Property(e => e.WM1AQ)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_A_Q");

                entity.Property(e => e.WM1BC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_B_C");

                entity.Property(e => e.WM1BP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_B_P");

                entity.Property(e => e.WM1BQ)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_B_Q");

                entity.Property(e => e.WM2AC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_A_C");

                entity.Property(e => e.WM2AP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_A_P");

                entity.Property(e => e.WM2AQ)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_A_Q");

                entity.Property(e => e.WM2BC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_B_C");

                entity.Property(e => e.WM2BP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_B_P");

                entity.Property(e => e.WM2BQ)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_B_Q");

                entity.Property(e => e.WpBcSDiff)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_BC_S_Diff");

                entity.Property(e => e.WpBcSIn)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_BC_S_IN");

                entity.Property(e => e.WpMillA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_Mill_A");

                entity.Property(e => e.WpMillB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_Mill_B");

                entity.Property(e => e.WpOsepa)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_OSEPA");
            });

            modelBuilder.Entity<GMillingPMachine>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.MillId, e.Ddate, e.DataTime });

                entity.ToTable("G_Milling_P_Machine");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.Ddate)
                    .HasColumnType("date")
                    .HasColumnName("DDate");

                entity.Property(e => e.DataTime).HasColumnType("datetime");

                entity.Property(e => e.BagColletcotM1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_M1");

                entity.Property(e => e.BagColletcotM2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_M2");

                entity.Property(e => e.BagColletcotS)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bag_Colletcot_S");

                entity.Property(e => e.BucketElevatorA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bucket_Elevator_A");

                entity.Property(e => e.Dtime).HasColumnName("DTime");

                entity.Property(e => e.MotorPowerKwA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_PowerKW_A");

                entity.Property(e => e.MotorPowerKwB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Motor_PowerKW_B");

                entity.Property(e => e.OpBcM1)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_M1");

                entity.Property(e => e.OpBcM2)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_M2");

                entity.Property(e => e.OpBcS)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OP_BC_S");

                entity.Property(e => e.OsepaCurrent)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OSEPA_Current");

                entity.Property(e => e.OsepaRpm)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("OSEPA_RPM");

                entity.Property(e => e.TeMillAirA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Air_A");

                entity.Property(e => e.TeMillAirB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_Air_B");

                entity.Property(e => e.TeMillRawA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_RAW_A");

                entity.Property(e => e.TeMillRawB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_Mill_RAW_B");

                entity.Property(e => e.TeSIn)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("TE_S_In");

                entity.Property(e => e.WM1AP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_A_P");

                entity.Property(e => e.WM1BP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M1_B_P");

                entity.Property(e => e.WM2AP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_A_P");

                entity.Property(e => e.WM2BP)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("W_M2_B_P");

                entity.Property(e => e.WpBcSDiff)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_BC_S_DIFF");

                entity.Property(e => e.WpBcSIn)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_BC_S_IN");

                entity.Property(e => e.WpMillA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_Mill_A");

                entity.Property(e => e.WpMillB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_Mill_B");

                entity.Property(e => e.WpOsepa)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("WP_OSEPA");
            });

            modelBuilder.Entity<GMillingPMap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("G_Milling_P_Map");

                entity.Property(e => e.BagColletcotM1)
                    .HasMaxLength(50)
                    .HasColumnName("Bag_Colletcot_M1");

                entity.Property(e => e.BagColletcotM2)
                    .HasMaxLength(50)
                    .HasColumnName("Bag_Colletcot_M2");

                entity.Property(e => e.BagColletcotS)
                    .HasMaxLength(50)
                    .HasColumnName("Bag_Colletcot_S");

                entity.Property(e => e.BucketElevatorA)
                    .HasMaxLength(50)
                    .HasColumnName("Bucket_Elevator_A");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.MotorPowerKwA)
                    .HasMaxLength(50)
                    .HasColumnName("Motor_PowerKW_A");

                entity.Property(e => e.MotorPowerKwB)
                    .HasMaxLength(50)
                    .HasColumnName("Motor_PowerKW_B");

                entity.Property(e => e.OpBcM1)
                    .HasMaxLength(50)
                    .HasColumnName("OP_BC_M1");

                entity.Property(e => e.OpBcM2)
                    .HasMaxLength(50)
                    .HasColumnName("OP_BC_M2");

                entity.Property(e => e.OpBcS)
                    .HasMaxLength(50)
                    .HasColumnName("OP_BC_S");

                entity.Property(e => e.OsepaCurrent)
                    .HasMaxLength(50)
                    .HasColumnName("OSEPA_Current");

                entity.Property(e => e.OsepaRpm)
                    .HasMaxLength(50)
                    .HasColumnName("OSEPA_RPM");

                entity.Property(e => e.TeMillAirA)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Air_A");

                entity.Property(e => e.TeMillAirB)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_Air_B");

                entity.Property(e => e.TeMillRawA)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_RAW_A");

                entity.Property(e => e.TeMillRawB)
                    .HasMaxLength(50)
                    .HasColumnName("TE_Mill_RAW_B");

                entity.Property(e => e.TeSIn)
                    .HasMaxLength(50)
                    .HasColumnName("TE_S_In");

                entity.Property(e => e.WM1AP)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_A_P");

                entity.Property(e => e.WM1BP)
                    .HasMaxLength(50)
                    .HasColumnName("W_M1_B_P");

                entity.Property(e => e.WM2AP)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_A_P");

                entity.Property(e => e.WM2BP)
                    .HasMaxLength(50)
                    .HasColumnName("W_M2_B_P");

                entity.Property(e => e.WpBcSDiff)
                    .HasMaxLength(50)
                    .HasColumnName("WP_BC_S_DIFF");

                entity.Property(e => e.WpBcSIn)
                    .HasMaxLength(50)
                    .HasColumnName("WP_BC_S_IN");

                entity.Property(e => e.WpMillA)
                    .HasMaxLength(50)
                    .HasColumnName("WP_Mill_A");

                entity.Property(e => e.WpMillB)
                    .HasMaxLength(50)
                    .HasColumnName("WP_Mill_B");

                entity.Property(e => e.WpOsepa)
                    .HasMaxLength(50)
                    .HasColumnName("WP_OSEPA");
            });

            modelBuilder.Entity<GPower>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.DataDate });

                entity.ToTable("G_Power");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.GetDateTime).HasColumnType("datetime");

                entity.Property(e => e.PowerC01)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_01");

                entity.Property(e => e.PowerC02)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_02");

                entity.Property(e => e.PowerC03)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_03");

                entity.Property(e => e.PowerC04)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_04");

                entity.Property(e => e.PowerC05)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_05");

                entity.Property(e => e.PowerC06)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_06");

                entity.Property(e => e.PowerC07)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_07");

                entity.Property(e => e.PowerC08)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_08");

                entity.Property(e => e.PowerCA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_A");

                entity.Property(e => e.PowerCB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_B");

                entity.Property(e => e.PowerCC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_C");

                entity.Property(e => e.PowerCTotal)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_C_Total");

                entity.Property(e => e.PowerKwh01)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_01");

                entity.Property(e => e.PowerKwh02)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_02");

                entity.Property(e => e.PowerKwh03)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_03");

                entity.Property(e => e.PowerKwh04)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_04");

                entity.Property(e => e.PowerKwh05)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_05");

                entity.Property(e => e.PowerKwh06)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_06");

                entity.Property(e => e.PowerKwh07)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_07");

                entity.Property(e => e.PowerKwh08)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_08");

                entity.Property(e => e.PowerKwhA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_A");

                entity.Property(e => e.PowerKwhB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_B");

                entity.Property(e => e.PowerKwhC)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_C");

                entity.Property(e => e.PowerKwhTotal)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH_Total");
            });

            modelBuilder.Entity<GPowerBill>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.DataDate, e.Mid });

                entity.ToTable("G_Power_Bill");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.Mid)
                    .HasMaxLength(10)
                    .HasColumnName("MID");

                entity.Property(e => e.BillHalfPeak)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bill_Half_Peak");

                entity.Property(e => e.BillOffPeak)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bill_Off_Peak");

                entity.Property(e => e.BillPeak)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bill_Peak");

                entity.Property(e => e.BillTotal)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Bill_Total");

                entity.Property(e => e.GetDateTime).HasColumnType("datetime");

                entity.Property(e => e.PowerHalfPeak)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_Half_Peak");

                entity.Property(e => e.PowerKwh)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_KWH");

                entity.Property(e => e.PowerOffPeak)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_Off_Peak");

                entity.Property(e => e.PowerPeak)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Power_Peak");
            });

            modelBuilder.Entity<GPowerCalender>(entity =>
            {
                entity.HasKey(e => e.PDate);

                entity.ToTable("G_Power_Calender");

                entity.Property(e => e.PDate)
                    .HasColumnType("date")
                    .HasColumnName("P_Date");

                entity.Property(e => e.HalfPeak).HasColumnName("Half_Peak");

                entity.Property(e => e.OffPeak).HasColumnName("Off_Peak");

                entity.Property(e => e.PWeekDay)
                    .HasMaxLength(1)
                    .HasColumnName("P_WeekDay")
                    .IsFixedLength();

                entity.Property(e => e.PYear)
                    .HasMaxLength(4)
                    .HasColumnName("P_Year")
                    .IsFixedLength();
            });

            modelBuilder.Entity<GPowerD>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.DataDate });

                entity.ToTable("G_Power_D");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.PowerC01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_01");

                entity.Property(e => e.PowerC02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_02");

                entity.Property(e => e.PowerC03)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_03");

                entity.Property(e => e.PowerC04)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_04");

                entity.Property(e => e.PowerC05)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_05");

                entity.Property(e => e.PowerC06)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_06");

                entity.Property(e => e.PowerC07)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_07");

                entity.Property(e => e.PowerC08)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_08");

                entity.Property(e => e.PowerCA)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_A");

                entity.Property(e => e.PowerCB)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_B");

                entity.Property(e => e.PowerCC)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_C");

                entity.Property(e => e.PowerCTotal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_Total");

                entity.Property(e => e.PowerKwh01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_01");

                entity.Property(e => e.PowerKwh02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_02");

                entity.Property(e => e.PowerKwh03)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_03");

                entity.Property(e => e.PowerKwh04)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_04");

                entity.Property(e => e.PowerKwh05)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_05");

                entity.Property(e => e.PowerKwh06)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_06");

                entity.Property(e => e.PowerKwh07)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_07");

                entity.Property(e => e.PowerKwh08)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_08");

                entity.Property(e => e.PowerKwhA)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_A");

                entity.Property(e => e.PowerKwhB)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_B");

                entity.Property(e => e.PowerKwhC)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_C");

                entity.Property(e => e.PowerKwhTotal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_Total");
            });

            modelBuilder.Entity<GPowerH>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.DataDate, e.Dtime });

                entity.ToTable("G_Power_h");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.PowerC01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_01");

                entity.Property(e => e.PowerC02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_02");

                entity.Property(e => e.PowerC03)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_03");

                entity.Property(e => e.PowerC04)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_04");

                entity.Property(e => e.PowerC05)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_05");

                entity.Property(e => e.PowerC06)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_06");

                entity.Property(e => e.PowerC07)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_07");

                entity.Property(e => e.PowerC08)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_08");

                entity.Property(e => e.PowerCA)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_A");

                entity.Property(e => e.PowerCB)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_B");

                entity.Property(e => e.PowerCC)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_C");

                entity.Property(e => e.PowerCTotal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_C_Total");

                entity.Property(e => e.PowerKwh01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_01");

                entity.Property(e => e.PowerKwh02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_02");

                entity.Property(e => e.PowerKwh03)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_03");

                entity.Property(e => e.PowerKwh04)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_04");

                entity.Property(e => e.PowerKwh05)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_05");

                entity.Property(e => e.PowerKwh06)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_06");

                entity.Property(e => e.PowerKwh07)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_07");

                entity.Property(e => e.PowerKwh08)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_08");

                entity.Property(e => e.PowerKwhA)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_A");

                entity.Property(e => e.PowerKwhB)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_B");

                entity.Property(e => e.PowerKwhC)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_C");

                entity.Property(e => e.PowerKwhTotal)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Power_KWH_Total");
            });

            modelBuilder.Entity<GPowerH1>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.TimeKey })
                    .HasName("PK_G_Power_H1_1");

                entity.ToTable("G_Power_H1");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.TimeKey).HasMaxLength(14);

                entity.Property(e => e.Ddate)
                    .HasColumnType("date")
                    .HasColumnName("DDate");

                entity.Property(e => e.Etime)
                    .HasColumnType("datetime")
                    .HasColumnName("ETime");

                entity.Property(e => e.Kwh)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("KWH");

                entity.Property(e => e.OffPeak)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Off_Peak");

                entity.Property(e => e.PartialPeak)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Partial_Peak");

                entity.Property(e => e.PartialPeakSat)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Partial_Peak_SAT");

                entity.Property(e => e.Peak).HasColumnType("decimal(18, 2)");

                entity.Property(e => e.PowerKwh)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Power_KWH");

                entity.Property(e => e.Stime)
                    .HasColumnType("datetime")
                    .HasColumnName("STime");
            });

            modelBuilder.Entity<GPowerM>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Dmonth })
                    .HasName("PK_G_Power_M_1");

                entity.ToTable("G_Power_M");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Dmonth)
                    .HasMaxLength(6)
                    .HasColumnName("DMonth");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.PowerC01)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_01");

                entity.Property(e => e.PowerC02)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_02");

                entity.Property(e => e.PowerC03)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_03");

                entity.Property(e => e.PowerC04)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_04");

                entity.Property(e => e.PowerC05)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_05");

                entity.Property(e => e.PowerC06)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_06");

                entity.Property(e => e.PowerC07)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_07");

                entity.Property(e => e.PowerC08)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_08");

                entity.Property(e => e.PowerCA)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_A");

                entity.Property(e => e.PowerCB)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_B");

                entity.Property(e => e.PowerCC)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_C");

                entity.Property(e => e.PowerCTotal)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_C_Total");

                entity.Property(e => e.PowerKwh01)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_01");

                entity.Property(e => e.PowerKwh02)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_02");

                entity.Property(e => e.PowerKwh03)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_03");

                entity.Property(e => e.PowerKwh04)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_04");

                entity.Property(e => e.PowerKwh05)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_05");

                entity.Property(e => e.PowerKwh06)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_06");

                entity.Property(e => e.PowerKwh07)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_07");

                entity.Property(e => e.PowerKwh08)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_08");

                entity.Property(e => e.PowerKwhA)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_A");

                entity.Property(e => e.PowerKwhB)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_B");

                entity.Property(e => e.PowerKwhC)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_C");

                entity.Property(e => e.PowerKwhTotal)
                    .HasColumnType("decimal(18, 1)")
                    .HasColumnName("Power_KWH_Total");

                entity.Property(e => e.WorkTime01)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_01");

                entity.Property(e => e.WorkTime02)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_02");

                entity.Property(e => e.WorkTime03)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_03");

                entity.Property(e => e.WorkTime04)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_04");

                entity.Property(e => e.WorkTime05)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_05");

                entity.Property(e => e.WorkTime06)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_06");

                entity.Property(e => e.WorkTime07)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_07");

                entity.Property(e => e.WorkTime08)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("WorkTime_08");
            });

            modelBuilder.Entity<GPowerMapping>(entity =>
            {
                entity.HasKey(e => e.FactoryId);

                entity.ToTable("G_Power_Mapping");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Dnote)
                    .HasMaxLength(50)
                    .HasColumnName("DNOTE");

                entity.Property(e => e.PowerKwh01)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_01");

                entity.Property(e => e.PowerKwh011)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_011");

                entity.Property(e => e.PowerKwh02)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_02");

                entity.Property(e => e.PowerKwh021)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_021");

                entity.Property(e => e.PowerKwh03)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_03");

                entity.Property(e => e.PowerKwh031)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_031");

                entity.Property(e => e.PowerKwh04)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_04");

                entity.Property(e => e.PowerKwh041)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_041");

                entity.Property(e => e.PowerKwh05)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_05");

                entity.Property(e => e.PowerKwh051)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_051");

                entity.Property(e => e.PowerKwh06)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_06");

                entity.Property(e => e.PowerKwh061)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_061");

                entity.Property(e => e.PowerKwh07)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_07");

                entity.Property(e => e.PowerKwh071)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_071");

                entity.Property(e => e.PowerKwh08)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_08");

                entity.Property(e => e.PowerKwh081)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_081");

                entity.Property(e => e.PowerKwhA)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_A");

                entity.Property(e => e.PowerKwhA1)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_A1");

                entity.Property(e => e.PowerKwhB)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_B");

                entity.Property(e => e.PowerKwhB1)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_B1");

                entity.Property(e => e.PowerKwhC)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_C");

                entity.Property(e => e.PowerKwhC1)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_C1");

                entity.Property(e => e.PowerKwhTotal)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_Total");

                entity.Property(e => e.PowerKwhTotal1)
                    .HasMaxLength(50)
                    .HasColumnName("Power_KWH_Total1");
            });

            modelBuilder.Entity<GPowerPeakDate>(entity =>
            {
                entity.HasKey(e => e.PeakDate);

                entity.ToTable("G_Power_Peak_Date");

                entity.Property(e => e.PeakDate)
                    .HasColumnType("date")
                    .HasColumnName("Peak_Date");
            });

            modelBuilder.Entity<GSe>(entity =>
            {
                entity.HasKey(e => e.SeId);

                entity.ToTable("G_SE");

                entity.Property(e => e.SeId)
                    .HasMaxLength(20)
                    .HasColumnName("SE_ID");

                entity.Property(e => e.BuildVolumeKwh)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Build_Volume_kwh");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");
            });

            modelBuilder.Entity<GSeD>(entity =>
            {
                entity.HasKey(e => new { e.SeId, e.Ddate });

                entity.ToTable("G_SE_D");

                entity.Property(e => e.SeId)
                    .HasMaxLength(20)
                    .HasColumnName("SE_ID");

                entity.Property(e => e.Ddate)
                    .HasColumnType("date")
                    .HasColumnName("DDate");

                entity.Property(e => e.KwhAvg)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("kwh_avg");

                entity.Property(e => e.LostPower).HasColumnName("Lost_Power");

                entity.Property(e => e.PowerGeneration)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Power_Generation");
            });

            modelBuilder.Entity<GSeH>(entity =>
            {
                entity.HasKey(e => new { e.SeId, e.Dtime });

                entity.ToTable("G_SE_H");

                entity.Property(e => e.SeId)
                    .HasMaxLength(20)
                    .HasColumnName("SE_ID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.KwhAvg)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("kwh_avg");

                entity.Property(e => e.PowerGeneration)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Power_Generation");
            });

            modelBuilder.Entity<GSeM>(entity =>
            {
                entity.HasKey(e => new { e.SeId, e.Ddate });

                entity.ToTable("G_SE_M");

                entity.Property(e => e.SeId)
                    .HasMaxLength(20)
                    .HasColumnName("SE_ID");

                entity.Property(e => e.Ddate)
                    .HasColumnType("date")
                    .HasColumnName("DDate");

                entity.Property(e => e.KwhAvg)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("kwh_avg");

                entity.Property(e => e.LostPower).HasColumnName("Lost_Power");

                entity.Property(e => e.PowerGeneration)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("Power_Generation");
            });

            modelBuilder.Entity<GTpc>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Dtime, e.ElectricityPeriod });

                entity.ToTable("G_TPC");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.ElectricityPeriod)
                    .HasMaxLength(20)
                    .HasColumnName("Electricity_period");

                entity.Property(e => e.PowerKw).HasColumnName("Power_KW");
            });

            modelBuilder.Entity<GTpcD>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Dtime, e.ElectricityPeriod });

                entity.ToTable("G_TPC_D");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("date")
                    .HasColumnName("DTime");

                entity.Property(e => e.ElectricityPeriod)
                    .HasMaxLength(20)
                    .HasColumnName("Electricity_period");

                entity.Property(e => e.PowerKw).HasColumnName("Power_KW");
            });

            modelBuilder.Entity<GTpcH>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Dtime, e.ElectricityPeriod })
                    .HasName("PK_TPC_H");

                entity.ToTable("G_TPC_H");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.ElectricityPeriod)
                    .HasMaxLength(20)
                    .HasColumnName("Electricity_period");

                entity.Property(e => e.PowerKw).HasColumnName("Power_KW");
            });

            modelBuilder.Entity<GTpcM>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Dtime, e.ElectricityPeriod });

                entity.ToTable("G_TPC_M");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Dtime)
                    .HasColumnType("date")
                    .HasColumnName("DTime");

                entity.Property(e => e.ElectricityPeriod)
                    .HasMaxLength(20)
                    .HasColumnName("Electricity_period");

                entity.Property(e => e.PowerKw).HasColumnName("Power_KW");
            });

            modelBuilder.Entity<GWeighingH>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.DataDate, e.Dtime });

                entity.ToTable("G_Weighing_H");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID")
                    .IsFixedLength();

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.M01).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.M01A)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M01_A");

                entity.Property(e => e.M01A1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M01_A1_C");

                entity.Property(e => e.M01B)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M01_B");

                entity.Property(e => e.M01B1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M01_B1_C");

                entity.Property(e => e.M02).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.M02A)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M02_A");

                entity.Property(e => e.M02A1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M02_A1_C");

                entity.Property(e => e.M02B)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M02_B");

                entity.Property(e => e.M02B1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M02_B1_C");

                entity.Property(e => e.M03).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.M03A)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M03_A");

                entity.Property(e => e.M03A1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M03_A1_C");

                entity.Property(e => e.M03B)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M03_B");

                entity.Property(e => e.M03B1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M03_B1_C");

                entity.Property(e => e.M04).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.M04A)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M04_A");

                entity.Property(e => e.M04A1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M04_A1_C");

                entity.Property(e => e.M04B)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M04_B");

                entity.Property(e => e.M04B1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M04_B1_C");

                entity.Property(e => e.M05).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.M05A)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M05_A");

                entity.Property(e => e.M05A1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M05_A1_C");

                entity.Property(e => e.M05B)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M05_B");

                entity.Property(e => e.M05B1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M05_B1_C");

                entity.Property(e => e.M06).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.M06A)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M06_A");

                entity.Property(e => e.M06A1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M06_A1_C");

                entity.Property(e => e.M06B)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M06_B");

                entity.Property(e => e.M06B1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M06_B1_C");

                entity.Property(e => e.M07).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.M07A)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M07_A");

                entity.Property(e => e.M07A1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M07_A1_C");

                entity.Property(e => e.M07B)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M07_B");

                entity.Property(e => e.M07B1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M07_B1_C");

                entity.Property(e => e.M08).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.M08A)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M08_A");

                entity.Property(e => e.M08A1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M08_A1_C");

                entity.Property(e => e.M08B)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M08_B");

                entity.Property(e => e.M08B1C)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("M08_B1_C");
            });

            modelBuilder.Entity<GWeighingMapping>(entity =>
            {
                entity.HasKey(e => e.FactoryId);

                entity.ToTable("G_Weighing_Mapping");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID")
                    .IsFixedLength();

                entity.Property(e => e.M01A)
                    .HasMaxLength(50)
                    .HasColumnName("M01_A");

                entity.Property(e => e.M01B)
                    .HasMaxLength(50)
                    .HasColumnName("M01_B");

                entity.Property(e => e.M02A)
                    .HasMaxLength(50)
                    .HasColumnName("M02_A");

                entity.Property(e => e.M02B)
                    .HasMaxLength(50)
                    .HasColumnName("M02_B");

                entity.Property(e => e.M03A)
                    .HasMaxLength(50)
                    .HasColumnName("M03_A");

                entity.Property(e => e.M03B)
                    .HasMaxLength(50)
                    .HasColumnName("M03_B");

                entity.Property(e => e.M04A)
                    .HasMaxLength(50)
                    .HasColumnName("M04_A");

                entity.Property(e => e.M04B)
                    .HasMaxLength(50)
                    .HasColumnName("M04_B");

                entity.Property(e => e.M05A)
                    .HasMaxLength(50)
                    .HasColumnName("M05_A");

                entity.Property(e => e.M05B)
                    .HasMaxLength(50)
                    .HasColumnName("M05_B");

                entity.Property(e => e.M06A)
                    .HasMaxLength(50)
                    .HasColumnName("M06_A");

                entity.Property(e => e.M06B)
                    .HasMaxLength(50)
                    .HasColumnName("M06_B");

                entity.Property(e => e.M07A)
                    .HasMaxLength(50)
                    .HasColumnName("M07_A");

                entity.Property(e => e.M07B)
                    .HasMaxLength(50)
                    .HasColumnName("M07_B");

                entity.Property(e => e.M08A)
                    .HasMaxLength(50)
                    .HasColumnName("M08_A");

                entity.Property(e => e.M08B)
                    .HasMaxLength(50)
                    .HasColumnName("M08_B");
            });

            modelBuilder.Entity<LocalhostCpuRam>(entity =>
            {
                entity.HasKey(e => e.Dtime);

                entity.ToTable("localhost_CPU_RAM");

                entity.Property(e => e.Dtime).HasColumnType("datetime");

                entity.Property(e => e.Cpu).HasColumnName("CPU");

                entity.Property(e => e.Ram).HasColumnName("RAM");
            });

            modelBuilder.Entity<LogErrorMsg>(entity =>
            {
                entity.HasKey(e => e.Ddtime);

                entity.ToTable("LogErrorMsg");

                entity.Property(e => e.Ddtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DDtime");

                entity.Property(e => e.ErrorMessage).HasMaxLength(1000);

                entity.Property(e => e.MsgLog).HasMaxLength(1000);
            });

            modelBuilder.Entity<MillWorkdataView>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("MILL_WORKDATA_VIEW");

                entity.Property(e => e.DeptEngSname)
                    .HasMaxLength(2)
                    .HasColumnName("Dept_Eng_SName");

                entity.Property(e => e.FeedTotal).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.FeedValue).HasColumnType("decimal(38, 2)");

                entity.Property(e => e.Mdate)
                    .HasColumnType("datetime")
                    .HasColumnName("MDate");

                entity.Property(e => e.MillNum).HasMaxLength(2);

                entity.Property(e => e.WorkSecond).HasColumnType("decimal(18, 2)");
            });

            modelBuilder.Entity<OccDespatch>(entity =>
            {
                entity.HasKey(e => e.WorkId);

                entity.ToTable("OCC_Despatch");

                entity.Property(e => e.WorkId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("WORK_ID")
                    .IsFixedLength();

                entity.Property(e => e.CarId)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("CAR_ID")
                    .IsFixedLength();

                entity.Property(e => e.CustId)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("CUST_ID")
                    .IsFixedLength();

                entity.Property(e => e.CustName)
                    .HasMaxLength(40)
                    .HasColumnName("CUST_NAME")
                    .IsFixedLength();

                entity.Property(e => e.DeliWt)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("DELI_WT");

                entity.Property(e => e.Delivery)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("DELIVERY");

                entity.Property(e => e.DeptId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("DEPT_ID")
                    .IsFixedLength();

                entity.Property(e => e.Gross)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("GROSS");

                entity.Property(e => e.ITime)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("I_TIME")
                    .IsFixedLength();

                entity.Property(e => e.ODate)
                    .HasColumnType("date")
                    .HasColumnName("O_DATE");

                entity.Property(e => e.OTime)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("O_TIME")
                    .IsFixedLength();

                entity.Property(e => e.OrderId1)
                    .HasMaxLength(11)
                    .IsUnicode(false)
                    .HasColumnName("ORDER_ID1")
                    .IsFixedLength();

                entity.Property(e => e.Package)
                    .HasMaxLength(10)
                    .HasColumnName("PACKAGE")
                    .IsFixedLength();

                entity.Property(e => e.PrintSn)
                    .HasMaxLength(7)
                    .IsUnicode(false)
                    .HasColumnName("PRINT_SN")
                    .IsFixedLength();

                entity.Property(e => e.ProdId)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PROD_ID")
                    .IsFixedLength();

                entity.Property(e => e.ScaleNo)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SCALE_NO")
                    .IsFixedLength();

                entity.Property(e => e.Tare)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("TARE");
            });

            modelBuilder.Entity<RMonthCondition>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.MillId, e.Product })
                    .HasName("PK_R_Mon_Condition");

                entity.ToTable("R_Month_Condition");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.Product).HasMaxLength(10);

                entity.Property(e => e.OsepaMax).HasColumnName("OSEPA_Max");

                entity.Property(e => e.OsepaMin).HasColumnName("OSEPA_Min");

                entity.Property(e => e.WeightMax).HasColumnName("Weight_Max");

                entity.Property(e => e.WeightMin).HasColumnName("Weight_Min");
            });

            modelBuilder.Entity<RMonthReoprt>(entity =>
            {
                entity.HasKey(e => new { e.FactoryId, e.Month, e.MillId, e.Product });

                entity.ToTable("R_Month_Reoprt");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(10)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.Month).HasColumnType("date");

                entity.Property(e => e.MillId)
                    .HasMaxLength(10)
                    .HasColumnName("Mill_ID");

                entity.Property(e => e.Product).HasMaxLength(10);

                entity.Property(e => e.ProductionHourA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Production_Hour_A");

                entity.Property(e => e.ProductionHourB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Production_Hour_B");

                entity.Property(e => e.ProductionTotalA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Production_Total_A");

                entity.Property(e => e.ProductionTotalB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Production_Total_B");

                entity.Property(e => e.RunHourA)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Run_Hour_A");

                entity.Property(e => e.RunHourB)
                    .HasColumnType("decimal(18, 4)")
                    .HasColumnName("Run_Hour_B");
            });

            modelBuilder.Entity<TagGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("Tag_group");

                entity.Property(e => e.GroupId)
                    .HasMaxLength(10)
                    .HasColumnName("Group_ID");

                entity.Property(e => e.GroupDesc)
                    .HasMaxLength(20)
                    .HasColumnName("Group_DESC");

                entity.Property(e => e.GroupSort).HasColumnName("Group_Sort");
            });

            modelBuilder.Entity<TagList>(entity =>
            {
                entity.HasKey(e => new { e.ServerName, e.TagName });

                entity.ToTable("TagList");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(50)
                    .HasComment("FactoryID");

                entity.Property(e => e.TagName).HasMaxLength(50);

                entity.Property(e => e.RepHour).HasColumnName("Rep_Hour");

                entity.Property(e => e.RepLive).HasColumnName("Rep_Live");

                entity.Property(e => e.RepMin).HasColumnName("Rep_Min");

                entity.Property(e => e.SourceTag).HasMaxLength(50);

                entity.Property(e => e.TagDesc).HasMaxLength(200);

                entity.Property(e => e.TagOrder)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Tag_Order");
            });

            modelBuilder.Entity<TagNameDesc>(entity =>
            {
                entity.HasKey(e => new { e.TagGroup, e.ServerName, e.TagName, e.SourceTag });

                entity.ToTable("Tag_Name_Desc");

                entity.Property(e => e.TagGroup)
                    .HasMaxLength(10)
                    .HasColumnName("Tag_Group");

                entity.Property(e => e.ServerName).HasMaxLength(50);

                entity.Property(e => e.TagName).HasMaxLength(50);

                entity.Property(e => e.SourceTag).HasMaxLength(50);

                entity.Property(e => e.TagDesc)
                    .HasMaxLength(200)
                    .HasColumnName("Tag_Desc");

                entity.Property(e => e.TagMid)
                    .HasMaxLength(10)
                    .HasColumnName("Tag_MID");

                entity.Property(e => e.TagSort).HasColumnName("Tag_Sort");
            });

            modelBuilder.Entity<ValueDaily>(entity =>
            {
                entity.HasKey(e => new { e.DataDateTime, e.ServerName, e.TagName });

                entity.ToTable("Value_Daily");

                entity.Property(e => e.DataDateTime).HasColumnType("datetime");

                entity.Property(e => e.ServerName)
                    .HasMaxLength(50)
                    .HasComment("FactoryID");

                entity.Property(e => e.TagName).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<ValueHour>(entity =>
            {
                entity.HasKey(e => new { e.DataDateTime, e.SourceServer, e.TagName });

                entity.ToTable("Value_Hour");

                entity.Property(e => e.DataDateTime).HasColumnType("datetime");

                entity.Property(e => e.SourceServer)
                    .HasMaxLength(50)
                    .HasComment("FactoryID");

                entity.Property(e => e.TagName).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<ValueMin>(entity =>
            {
                entity.HasKey(e => new { e.DataDateTime, e.SourceServer, e.TagName });

                entity.ToTable("Value_Min");

                entity.Property(e => e.DataDateTime).HasColumnType("datetime");

                entity.Property(e => e.SourceServer).HasMaxLength(50);

                entity.Property(e => e.TagName).HasMaxLength(50);

                entity.Property(e => e.Value).HasColumnType("decimal(18, 4)");
            });

            modelBuilder.Entity<WLoginGroup>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("W_Login_Group");

                entity.Property(e => e.GroupName).HasMaxLength(50);
            });

            modelBuilder.Entity<WLoginGroupRight>(entity =>
            {
                entity.HasKey(e => e.GroupId);

                entity.ToTable("W_Login_GroupRight");

                entity.Property(e => e.GroupId).HasColumnName("Group_ID");

                entity.Property(e => e.Account).HasMaxLength(50);

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(50)
                    .HasColumnName("FactoryID");

                entity.Property(e => e.RightId).HasColumnName("Right_ID");

                entity.Property(e => e.SubId)
                    .HasMaxLength(50)
                    .HasColumnName("SubID");
            });

            modelBuilder.Entity<WLoginLogfile>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("W_Login_Logfile");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("User_Name");
            });

            modelBuilder.Entity<WLoginRight>(entity =>
            {
                entity.HasKey(e => e.RightId);

                entity.ToTable("W_Login_Right");

                entity.Property(e => e.RightId)
                    .ValueGeneratedNever()
                    .HasColumnName("Right_ID");

                entity.Property(e => e.RightName)
                    .HasMaxLength(50)
                    .HasColumnName("Right_Name");
            });

            modelBuilder.Entity<WLoginUser>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK_W_Login_User_1");

                entity.ToTable("W_Login_User");

                entity.Property(e => e.UserId).HasColumnName("User_ID");

                entity.Property(e => e.Account).HasMaxLength(20);

                entity.Property(e => e.CreateTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Create_Time");

                entity.Property(e => e.FactoryId)
                    .HasMaxLength(20)
                    .HasColumnName("Factory_ID");

                entity.Property(e => e.StopTime)
                    .HasColumnType("datetime")
                    .HasColumnName("Stop_Time");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("User_Name");
            });

            modelBuilder.Entity<WSubPage>(entity =>
            {
                entity.HasKey(e => e.SubId);

                entity.ToTable("W_Sub_Page");

                entity.Property(e => e.SubId).HasMaxLength(100);

                entity.Property(e => e.Num)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("num");

                entity.Property(e => e.SubName).HasMaxLength(50);

                entity.Property(e => e.WebId).HasMaxLength(50);

                entity.HasOne(d => d.Web)
                    .WithMany(p => p.WSubPages)
                    .HasForeignKey(d => d.WebId)
                    .HasConstraintName("FK_W_Sub_Page_W_Web_Page");
            });

            modelBuilder.Entity<WWebPage>(entity =>
            {
                entity.HasKey(e => e.WebId);

                entity.ToTable("W_Web_Page");

                entity.Property(e => e.WebId)
                    .HasMaxLength(50)
                    .HasColumnName("WebID");

                entity.Property(e => e.Num)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("num");

                entity.Property(e => e.WebName).HasMaxLength(50);
            });

            modelBuilder.Entity<WeatherDay>(entity =>
            {
                entity.HasKey(e => new { e.DataDate, e.Area })
                    .HasName("PK_Weather");

                entity.ToTable("Weather_Day");

                entity.Property(e => e.DataDate).HasColumnType("date");

                entity.Property(e => e.Area).HasMaxLength(10);

                entity.Property(e => e.Uv).HasColumnName("UV");
            });

            modelBuilder.Entity<WeatherHour>(entity =>
            {
                entity.HasKey(e => new { e.Dtime, e.Area })
                    .HasName("PK_Weather_Hour_1");

                entity.ToTable("Weather_Hour");

                entity.Property(e => e.Dtime)
                    .HasColumnType("datetime")
                    .HasColumnName("DTime");

                entity.Property(e => e.Area).HasMaxLength(10);

                entity.Property(e => e.Uv).HasColumnName("UV");
            });

            modelBuilder.Entity<GMMins>(entity =>
            {
                entity.ToTable("History"); // set the table name
                entity.HasKey(e => new { e.DateTime, e.TagName }); // set the primary key
                                                                   // configure other entity properties
                entity.Property(e => e.DateTime).HasColumnName("DateTime");
                entity.Property(e => e.TagName).HasColumnName("TagName");
                entity.Property(e => e.Value).HasColumnName("Value");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
