using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace SmartMotor.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CfgRole> CfgRoles { get; set; }
        public virtual DbSet<TGpsInfo> TGpsInfos { get; set; }
        public virtual DbSet<TPaymentSummary> TPaymentSummaries { get; set; }
        public virtual DbSet<TPolicyInfo> TPolicyInfos { get; set; }
        public virtual DbSet<TbLog> TbLogs { get; set; }
        public virtual DbSet<TbRedBookSmt> TbRedBookSmts { get; set; }
        public virtual DbSet<TbRegister> TbRegisters { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<VwGpsStatus> VwGpsStatuses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=10.132.158.31;Initial Catalog=DB_SmartMotor;Persist Security Info=True;User ID=WEBAppDB;Password=Fci@WEB*1709");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Thai_CI_AS");

            modelBuilder.Entity<CfgRole>(entity =>
            {
                entity.HasKey(e => e.RoleId)
                    .HasName("PK__CfgRole__8AFACE3AC990A85D");

                entity.ToTable("CfgRole");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TGpsInfo>(entity =>
            {
                entity.HasKey(e => e.Sid);

                entity.ToTable("T_Gps_Info");

                entity.Property(e => e.Sid).HasColumnName("SID");

                entity.Property(e => e.GpsId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.GpsRegister)
                    .HasColumnType("datetime")
                    .HasColumnName("Gps_Register");

                entity.Property(e => e.GpsStatus)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')");

                entity.Property(e => e.ModifiedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Modified_By");

                entity.Property(e => e.ModifiedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Modified_Date");

                entity.Property(e => e.OrderPerfixId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OrderPerfixID")
                    .HasDefaultValueSql("('')");

                entity.Property(e => e.StoreCard)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.UseDate).HasColumnType("date");
            });

            modelBuilder.Entity<TPaymentSummary>(entity =>
            {
                entity.HasKey(e => e.Pid)
                    .HasName("PK_T_Payment_Summary_1");

                entity.ToTable("T_Payment_Summary");

                entity.HasComment("สรุปยอดรายเดือน");

                entity.Property(e => e.Pid).HasColumnName("pid");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CurrentDistance)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("current_distance")
                    .HasComment("ระยะทางรวมใน Period");

                entity.Property(e => e.DateValue)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasComputedColumnSql("(right(replace([FileName],'.csv',''),(8)))", true);

                entity.Property(e => e.EndBillDate)
                    .HasColumnType("date")
                    .HasColumnName("end_bill_date")
                    .HasComment("วันที่ตัดยอด ");

                entity.Property(e => e.FileName)
                    .HasMaxLength(400)
                    .IsUnicode(false);

                entity.Property(e => e.GpsId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gps_id")
                    .HasComment("เลขอุปกรณ์");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("invoice_no")
                    .HasComment("เลขที่ใบเรียกเก็บเงิน ");

                entity.Property(e => e.PaidDate)
                    .HasColumnType("date")
                    .HasColumnName("paid_date")
                    .HasComment("วันที่ชำระ ");

                entity.Property(e => e.PaymentChannel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("payment_channel")
                    .HasComment("ช่องทางการจ่ายเงิน ");

                entity.Property(e => e.PaymentDueDate)
                    .HasColumnType("date")
                    .HasColumnName("payment_due_date")
                    .HasComment("ต้องชำระเงินไม่เกินวันที่ ");

                entity.Property(e => e.PaymentStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_status")
                    .HasComment("สถานะการชำระ ");

                entity.Property(e => e.PaymentType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("payment_type")
                    .HasComment("วิธีการชำระ");

                entity.Property(e => e.PaymentUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("payment_url")
                    .HasComment("Payment Link เพื่อส่งให้ลูกค้า");

                entity.Property(e => e.PeriodNo)
                    .HasColumnName("period_no")
                    .HasComment("รอบที่");

                entity.Property(e => e.PolicyNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("policy_no")
                    .HasComment("หมายเลขกรมธรรม์");

                entity.Property(e => e.PremiumPerKm)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("premium_per_km")
                    .HasComment("เบี้ยประกันต่อระยะทาง 1 กิโล");

                entity.Property(e => e.PreviousDistance)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("previous_distance")
                    .HasComment("ระยะทางที่ยกมาจาก Period");

                entity.Property(e => e.StartBillDate)
                    .HasColumnType("date")
                    .HasColumnName("start_bill_date")
                    .HasComment("วันที่เริ่มคำนวณยอด ");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.TaxInvoiceUrl)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("tax_invoice_url")
                    .HasComment("Link ใบเสร็จ/ ใบกำกับภาษี");

                entity.Property(e => e.TotalAmount)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("total_amount")
                    .HasComment("ค่าใช้จ่ายใน Period นั้นๆ ที่");

                entity.Property(e => e.TotalAmountInsurer)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("total_amount_insurer")
                    .HasComment("ค่าใช้จ่ายใน Period นั้นๆ จาก");

                entity.Property(e => e.TotalDiscount)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("total_discount")
                    .HasComment("ส่วนลดที่ทาง FCI มีให้ลูกค้า ");

                entity.Property(e => e.TotalDistance)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("total_distance")
                    .HasComment("ระยะทางรวมใน Period นั้นๆ ");
            });

            modelBuilder.Entity<TPolicyInfo>(entity =>
            {
                entity.HasKey(e => e.RnPolicy);

                entity.ToTable("T_Policy_Info");

                entity.HasComment("ตารางกรมธรรม์");

                entity.Property(e => e.RnPolicy).HasColumnName("rnPolicy");

                entity.Property(e => e.AssuredName)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("assuredName")
                    .HasComment("ชื่อผู้ถือกรมธรรม");

                entity.Property(e => e.CapMaxMonth)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("capMaxMonth")
                    .HasComment("ค่าเบี้ยสูงสุดต่อเดือน");

                entity.Property(e => e.CapMaxYear)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("capMaxYear")
                    .HasComment("ค่าเบี้ยสูงสุดต่อป");

                entity.Property(e => e.CarModel)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("carModel")
                    .HasComment("รุ่นรถ");

                entity.Property(e => e.CarRegistrationNo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("carRegistrationNo")
                    .HasComment("ระเบียนรถ");

                entity.Property(e => e.FlagSend).HasDefaultValueSql("((0))");

                entity.Property(e => e.GpsId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("gpsId")
                    .HasComment("เลขอุปกรณ์");

                entity.Property(e => e.PolicyBasePremium)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("policyBasePremium")
                    .HasComment("เบี้ยประกัน");

                entity.Property(e => e.PolicyEndDate)
                    .HasColumnType("date")
                    .HasColumnName("policyEndDate")
                    .HasComment("วันสิ้นสุดความคุ้มครอง\r\nกรมธรรม์ ภาคสมัครใจ");

                entity.Property(e => e.PolicyNo)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("policyNo")
                    .HasComment("หมายเลขกรมธรรม");

                entity.Property(e => e.PolicyPremiumPerKm)
                    .HasColumnType("numeric(8, 2)")
                    .HasColumnName("policyPremiumPerKm")
                    .HasComment("เบี้ยประกันต่อระยะทาง 1 กิโล\r\nเมคร");

                entity.Property(e => e.PolicyStartDate)
                    .HasColumnType("date")
                    .HasColumnName("policyStartDate")
                    .HasComment("วันเริ่มต้นความคุ้มครอง\r\nกรมธรรม์ ภาคสมัครใจ");

                entity.Property(e => e.PolicyStatus)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('Active')")
                    .HasComment("Active, Inactvie");

                entity.Property(e => e.PolicyType)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasComment("“New” = Policy ใหม่\r\n“Renew” = ต่ออายุกรมธรรม์\r\n“Endorsement” = แก้ไขข้อมูล\r\n“TransferOut” = เปลี่ยนชื่อ\r\nออกจากผู้ถือกรมธรรม์\r\n“TransferIn” = เปลี่ยนชื่อเข้า\r\nเป็นผู้ถือกรมธรรม์\r\n“Cancel” = ยกเลิกกรมธรรม์");

                entity.Property(e => e.PreviousPolicy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("previousPolicy")
                    .HasComment("Policy ก่อนหน้านี้ (ใช้ในกรณี \r\nRenew)");

                entity.Property(e => e.ProvinceCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("provinceCode")
                    .HasComment("รหัสจังหวัดของป้ายทะเบียน\r\nรถยนต");

                entity.Property(e => e.SendDate).HasColumnType("datetime");

                entity.Property(e => e.TransferInDate)
                    .HasColumnType("date")
                    .HasColumnName("transferInDate")
                    .HasComment("วันที่เริ่มต้นการคิดกรรมธรรม");

                entity.Property(e => e.TransferOutDate)
                    .HasColumnType("date")
                    .HasColumnName("transferOutDate")
                    .HasComment("วันที่สิ้นสุดการคิดกรรมธรรม");

                entity.Property(e => e.UserIdentity)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("userIdentity")
                    .HasComment("ค่าที่ใช้ Identify ลูกค้า หรือ\r\nหมายเลขลูกค้า");
            });

            modelBuilder.Entity<TbLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.ToTable("TB_Logs");

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PolicyType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusCode).HasColumnName("Status_Code");
            });

            modelBuilder.Entity<TbRedBookSmt>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("TB_RedBookSMT");

                entity.HasIndex(e => e.Make, "IX_TB_RedBookSMT_001");

                entity.HasIndex(e => new { e.Make, e.Model }, "IX_TB_RedBookSMT_002");

                entity.Property(e => e.AnnualPremium).HasColumnName("Annual Premium");

                entity.Property(e => e.BailBond).HasColumnName("Bail Bond");

                entity.Property(e => e.BaseLower)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Base Lower");

                entity.Property(e => e.BaseUpper)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Base Upper");

                entity.Property(e => e.BasicPremium)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Basic Premium");

                entity.Property(e => e.Capacity)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Capacity1).HasColumnName("Capacity %");

                entity.Property(e => e.Cc).HasColumnName("CC");

                entity.Property(e => e.Cctv)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV %");

                entity.Property(e => e.CctvAmount)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Amount");

                entity.Property(e => e.CctvFirstPremium)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV First Premium");

                entity.Property(e => e.CctvPremium10000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Premium_10000");

                entity.Property(e => e.CctvPremium5000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Premium_5000");

                entity.Property(e => e.CctvPremium7500)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Premium_7500");

                entity.Property(e => e.CctvStampDuty)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Stamp Duty");

                entity.Property(e => e.CctvStampDuty10000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Stamp Duty_10000");

                entity.Property(e => e.CctvStampDuty5000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Stamp Duty_5000");

                entity.Property(e => e.CctvStampDuty7500)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Stamp Duty_7500");

                entity.Property(e => e.CctvTotalPremium)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Total Premium");

                entity.Property(e => e.CctvTotalPremium10000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Total Premium_10000");

                entity.Property(e => e.CctvTotalPremium5000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Total Premium_5000");

                entity.Property(e => e.CctvTotalPremium7500)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Total Premium_7500");

                entity.Property(e => e.CctvVat)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV VAT");

                entity.Property(e => e.CctvVat10000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Vat_10000");

                entity.Property(e => e.CctvVat5000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Vat_5000");

                entity.Property(e => e.CctvVat7500)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("CCTV Vat_7500");

                entity.Property(e => e.Class)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DeductibleOd).HasColumnName("Deductible (OD)");

                entity.Property(e => e.Discount75).HasColumnName("Discount 75%");

                entity.Property(e => e.FirstPremium).HasColumnName("First Premium");

                entity.Property(e => e.Fleet).HasColumnName("Fleet %");

                entity.Property(e => e.FleetBaht).HasColumnName("Fleet [Baht]");

                entity.Property(e => e.GwpAfterDiscount)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("GWP after Discount");

                entity.Property(e => e.GwpAfterPv)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("GWP after PV");

                entity.Property(e => e.GwpBeforeDD)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("GWP before D/D");

                entity.Property(e => e.GwpBeforeDiscount).HasColumnName("GWP before Discount");

                entity.Property(e => e.Make)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MaxBase)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Max Base");

                entity.Property(e => e.Med).HasColumnName("MED");

                entity.Property(e => e.MinBase)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Min Base");

                entity.Property(e => e.Model)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Ncb).HasColumnName("NCB %");

                entity.Property(e => e.NcbBaht).HasColumnName("NCB [Baht]");

                entity.Property(e => e.Other).HasColumnName("Other %");

                entity.Property(e => e.OtherBaht).HasColumnName("Other [Baht]");

                entity.Property(e => e.Pa).HasColumnName("PA");

                entity.Property(e => e.PlanName)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Plan Name");

                entity.Property(e => e.Premium).HasColumnType("decimal(8, 2)");

                entity.Property(e => e.Premium10000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Premium_10000");

                entity.Property(e => e.Premium5000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Premium_5000");

                entity.Property(e => e.Premium7500)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Premium_7500");

                entity.Property(e => e.PremiumPerKm)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Premium per km");

                entity.Property(e => e.PremiumVoluntary)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Premium Voluntary");

                entity.Property(e => e.PvPremium).HasColumnName("PV Premium");

                entity.Property(e => e.PvSumInsured).HasColumnName("PV Sum Insured");

                entity.Property(e => e.Reparing)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SI).HasColumnName("S/I %");

                entity.Property(e => e.StampDuty).HasColumnName("Stamp Duty");

                entity.Property(e => e.StampDuty10000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Stamp Duty_10000");

                entity.Property(e => e.StampDuty5000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Stamp Duty_5000");

                entity.Property(e => e.StampDuty7500)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Stamp Duty_7500");

                entity.Property(e => e.SubModel)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Sub Model");

                entity.Property(e => e.SumInsured)
                    .HasColumnType("decimal(8, 0)")
                    .HasColumnName("Sum Insured");

                entity.Property(e => e.Tba).HasColumnName("TBA %");

                entity.Property(e => e.TbaBaht).HasColumnName("TBA [Baht]");

                entity.Property(e => e.TotalDiscount).HasColumnName("Total Discount");

                entity.Property(e => e.TotalPremium)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Total Premium");

                entity.Property(e => e.TotalPremium10000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Total Premium_10000");

                entity.Property(e => e.TotalPremium5000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Total Premium_5000");

                entity.Property(e => e.TotalPremium7500)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Total Premium_7500");

                entity.Property(e => e.TpbiARate).HasColumnName("TPBI: A Rate");

                entity.Property(e => e.TpbiAccident)
                    .HasColumnType("decimal(8, 0)")
                    .HasColumnName("TPBI: Accident");

                entity.Property(e => e.TpbiPRate).HasColumnName("TPBI: P Rate");

                entity.Property(e => e.TpbiPerson)
                    .HasColumnType("decimal(8, 0)")
                    .HasColumnName("TPBI: Person");

                entity.Property(e => e.TppdAccident)
                    .HasColumnType("decimal(8, 0)")
                    .HasColumnName("TPPD: Accident");

                entity.Property(e => e.TppdRate).HasColumnName("TPPD Rate");

                entity.Property(e => e.Usage).HasColumnName("Usage %");

                entity.Property(e => e.Vat)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("VAT");

                entity.Property(e => e.Vat10000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Vat_10000");

                entity.Property(e => e.Vat5000)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Vat_5000");

                entity.Property(e => e.Vat7500)
                    .HasColumnType("decimal(8, 2)")
                    .HasColumnName("Vat_7500");

                entity.Property(e => e.VehAge1).HasColumnName("VehAge %");

                entity.Property(e => e.VehGroup1).HasColumnName("VehGroup %");
            });

            modelBuilder.Entity<TbRegister>(entity =>
            {
                entity.HasKey(e => e.RnNo)
                    .HasName("PK__TB_Regis__85EF70572B1BA303");

                entity.ToTable("TB_Register");

                entity.Property(e => e.RnNo).HasColumnName("rnNo");

                entity.Property(e => e.CarRegisYear).HasColumnName("CarRegis_Year");

                entity.Property(e => e.CarYear).HasComputedColumnSql("(case when (datepart(year,[Created])-[CarRegis_Year])=(0) then (1) else datepart(year,[Created])-[CarRegis_Year] end)", true);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Email)
                    .HasMaxLength(40)
                    .HasColumnName("email");

                entity.Property(e => e.FirstName).HasMaxLength(100);

                entity.Property(e => e.IsFci).HasColumnName("IsFCI");

                entity.Property(e => e.LastName).HasMaxLength(100);

                entity.Property(e => e.PolicyExpiry)
                    .HasColumnType("date")
                    .HasColumnName("Policy_Expiry");

                entity.Property(e => e.Telephone).HasMaxLength(20);

                entity.Property(e => e.Title).HasMaxLength(40);

                entity.Property(e => e.VehicleBrand)
                    .HasMaxLength(20)
                    .HasColumnName("Vehicle_Brand");

                entity.Property(e => e.VehicleCc).HasColumnName("Vehicle_CC");

                entity.Property(e => e.VehicleModel)
                    .HasMaxLength(50)
                    .HasColumnName("Vehicle_Model");

                entity.Property(e => e.VehicleSubModel)
                    .HasMaxLength(100)
                    .HasColumnName("Vehicle_SubModel");

                entity.Property(e => e.VehicleYear).HasColumnName("Vehicle_Year");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("UserID");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DisplayName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("displayName");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("email");

                entity.Property(e => e.GroupAgent)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("groupAgent");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.IsRole).HasDefaultValueSql("((0))");

                entity.Property(e => e.LogonName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("logonName");

                entity.Property(e => e.Position)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Updated).HasColumnType("datetime");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<VwGpsStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("vw_gpsStatus");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.StatusCode)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Status_Code");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
