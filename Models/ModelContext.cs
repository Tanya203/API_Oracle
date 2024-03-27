using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace API.Models;

public partial class ModelContext : DbContext
{
    public ModelContext()
    {
    }

    public ModelContext(DbContextOptions<ModelContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Benefit> Benefits { get; set; }

    public virtual DbSet<BenefitDetail> BenefitDetails { get; set; }

    public virtual DbSet<ContractType> ContractTypes { get; set; }

    public virtual DbSet<CountBenefit> CountBenefits { get; set; }

    public virtual DbSet<DayOffUsed> DayOffUseds { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<DepartmentDetail> DepartmentDetails { get; set; }

    public virtual DbSet<Position> Positions { get; set; }

    public virtual DbSet<PositionDetail> PositionDetails { get; set; }

    public virtual DbSet<Shift> Shifts { get; set; }

    public virtual DbSet<ShiftDetail> ShiftDetails { get; set; }

    public virtual DbSet<ShiftType> ShiftTypes { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    public virtual DbSet<StaffBenefitDetail> StaffBenefitDetails { get; set; }

    public virtual DbSet<StaffInfo> StaffInfos { get; set; }

    public virtual DbSet<StaffTimeKeeping> StaffTimeKeepings { get; set; }

    public virtual DbSet<StaffWorkScheduleDetail> StaffWorkScheduleDetails { get; set; }

    public virtual DbSet<TimeKeeping> TimeKeepings { get; set; }

    public virtual DbSet<TimeKeepingMethod> TimeKeepingMethods { get; set; }

    public virtual DbSet<WorkSchedule> WorkSchedules { get; set; }

    public virtual DbSet<WorkScheduleDetail> WorkScheduleDetails { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseOracle("Data Source=localhost:1521/orcl; User Id=CUOIKY; Password=12345; Validate Connection=true;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .HasDefaultSchema("CUOIKY")
            .UseCollation("USING_NLS_COMP");

        modelBuilder.Entity<Benefit>(entity =>
        {
            entity.HasKey(e => e.BnId).HasName("BENEFIT_PK");

            entity.ToTable("BENEFIT");

            entity.HasIndex(e => e.BenefitName, "UK_BENEFIT_NAME").IsUnique();

            entity.Property(e => e.BnId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("BN_ID");
            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(38,3)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.BenefitName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BENEFIT_NAME");
        });

        modelBuilder.Entity<BenefitDetail>(entity =>
        {
            entity.HasKey(e => new { e.BnId, e.StaffId }).HasName("BENEFIT_DETAIL_PK");

            entity.ToTable("BENEFIT_DETAIL");

            entity.Property(e => e.BnId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BN_ID");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NOTE");

            entity.HasOne(d => d.Bn).WithMany(p => p.BenefitDetails)
                .HasForeignKey(d => d.BnId)
                .HasConstraintName("FK_BN_ID");

            entity.HasOne(d => d.Staff).WithMany(p => p.BenefitDetails)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_STAFFID");
        });

        modelBuilder.Entity<ContractType>(entity =>
        {
            entity.HasKey(e => e.CtId).HasName("CONTRACT_TYPE_PK");

            entity.ToTable("CONTRACT_TYPE");

            entity.HasIndex(e => e.ContractTypeName, "UK_CONTRACT_TYPE_NAME").IsUnique();

            entity.Property(e => e.CtId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("CT_ID");
            entity.Property(e => e.ContractTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRACT_TYPE_NAME");
            entity.Property(e => e.TkmId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("TKM_ID");

            entity.HasOne(d => d.Tkm).WithMany(p => p.ContractTypes)
                .HasForeignKey(d => d.TkmId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("CONTRACT_TYPE_FK1");
        });

        modelBuilder.Entity<CountBenefit>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("COUNT_BENEFIT");

            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(38,3)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.BenefitName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BENEFIT_NAME");
            entity.Property(e => e.BnId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BN_ID");
            entity.Property(e => e.StaffQuantity)
                .HasColumnType("NUMBER")
                .HasColumnName("STAFF_QUANTITY");
            entity.Property(e => e.Totalamount)
                .HasColumnType("NUMBER")
                .HasColumnName("TOTALAMOUNT");
        });

        modelBuilder.Entity<DayOffUsed>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DAY_OFF_USED");

            entity.Property(e => e.DateOff)
                .HasPrecision(1)
                .HasColumnName("DATE_OFF");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_NAME");
            entity.Property(e => e.FullName)
                .HasMaxLength(152)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NOTE");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSITION_NAME");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.WorkDate)
                .HasColumnType("DATE")
                .HasColumnName("WORK_DATE");
            entity.Property(e => e.WsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WS_ID");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DpId).HasName("DEPARTMENT_PK");

            entity.ToTable("DEPARTMENT");

            entity.HasIndex(e => e.DepartmentName, "UK_DEPARTMENT_NAME").IsUnique();

            entity.Property(e => e.DpId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("DP_ID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_NAME");
        });

        modelBuilder.Entity<DepartmentDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("DEPARTMENT_DETAIL");

            entity.Property(e => e.Count)
                .HasColumnType("NUMBER")
                .HasColumnName("COUNT");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_NAME");
            entity.Property(e => e.DpId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DP_ID");
        });

        modelBuilder.Entity<Position>(entity =>
        {
            entity.HasKey(e => e.PsId).HasName("POSITION_PK");

            entity.ToTable("POSITION");

            entity.HasIndex(e => e.PositionName, "UK_POSITION_NAME").IsUnique();

            entity.Property(e => e.PsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PS_ID");
            entity.Property(e => e.DpId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("DP_ID");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSITION_NAME");

            entity.HasOne(d => d.Dp).WithMany(p => p.Positions)
                .HasForeignKey(d => d.DpId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_DP_ID");
        });

        modelBuilder.Entity<PositionDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("POSITION_DETAIL");

            entity.Property(e => e.Count)
                .HasColumnType("NUMBER")
                .HasColumnName("COUNT");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_NAME");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSITION_NAME");
            entity.Property(e => e.PsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("PS_ID");
        });

        modelBuilder.Entity<Shift>(entity =>
        {
            entity.HasKey(e => e.ShiftId).HasName("SHIFT_PK");

            entity.ToTable("SHIFT");

            entity.HasIndex(e => e.ShiftName, "UK_SHIFT_NAME").IsUnique();

            entity.Property(e => e.ShiftId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("SHIFT_ID");
            entity.Property(e => e.BeginTime)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("BEGIN_TIME");
            entity.Property(e => e.EndTime)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("END_TIME");
            entity.Property(e => e.ShiftName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SHIFT_NAME");
            entity.Property(e => e.StId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ST_ID");

            entity.HasOne(d => d.St).WithMany(p => p.Shifts)
                .HasForeignKey(d => d.StId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_ST_ID");
        });

        modelBuilder.Entity<ShiftDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("SHIFT_DETAIL");

            entity.Property(e => e.BeginTime)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("BEGIN_TIME");
            entity.Property(e => e.EndTime)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("END_TIME");
            entity.Property(e => e.ShiftId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SHIFT_ID");
            entity.Property(e => e.ShiftName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SHIFT_NAME");
            entity.Property(e => e.ShiftTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SHIFT_TYPE_NAME");
        });

        modelBuilder.Entity<ShiftType>(entity =>
        {
            entity.HasKey(e => e.StId).HasName("SHIFT_TYPE_PK");

            entity.ToTable("SHIFT_TYPE");

            entity.HasIndex(e => e.ShiftTypeName, "UK_SHIFT_TYPE_NAME").IsUnique();

            entity.Property(e => e.StId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("ST_ID");
            entity.Property(e => e.SalaryCoefficient)
                .HasColumnType("NUMBER")
                .HasColumnName("SALARY_COEFFICIENT");
            entity.Property(e => e.ShiftTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SHIFT_TYPE_NAME");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("STAFF_PK");

            entity.ToTable("STAFF");

            entity.HasIndex(e => e.Account, "UK_ACCOUNT").IsUnique();

            entity.HasIndex(e => e.Email, "UK_EMAIL").IsUnique();

            entity.HasIndex(e => e.Id, "UK_ID").IsUnique();

            entity.HasIndex(e => e.Phone, "UK_PHONE").IsUnique();

            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.Account)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ACCOUNT");
            entity.Property(e => e.BasicSalary)
                .HasDefaultValueSql("0 ")
                .HasColumnType("NUMBER")
                .HasColumnName("BASIC_SALARY");
            entity.Property(e => e.ContractDuration)
                .HasColumnType("DATE")
                .HasColumnName("CONTRACT_DURATION");
            entity.Property(e => e.CtId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("CT_ID");
            entity.Property(e => e.DateOfBrith)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("DATE_OF_BRITH");
            entity.Property(e => e.DayOff)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DAY_OFF");
            entity.Property(e => e.District)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DISTRICT");
            entity.Property(e => e.EducationLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDUCATION_LEVEL");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EntryDate)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("ENTRY_DATE");
            entity.Property(e => e.FirstName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("FIRST_NAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.HouseNumber)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("HOUSE_NUMBER");
            entity.Property(e => e.Id)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.LastName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("LAST_NAME");
            entity.Property(e => e.LockDate)
                .HasColumnType("DATE")
                .HasColumnName("LOCK_DATE");
            entity.Property(e => e.MiddleName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("MIDDLE_NAME");
            entity.Property(e => e.Password)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("PASSWORD");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.Picture)
                .HasColumnType("BLOB")
                .HasColumnName("PICTURE");
            entity.Property(e => e.ProviceCity)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PROVICE_CITY");
            entity.Property(e => e.PsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("PS_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");
            entity.Property(e => e.Street)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STREET");
            entity.Property(e => e.Ward)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("WARD");

            entity.HasOne(d => d.Ct).WithMany(p => p.Staff)
                .HasForeignKey(d => d.CtId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_CT_ID");

            entity.HasOne(d => d.Ps).WithMany(p => p.Staff)
                .HasForeignKey(d => d.PsId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PS_ID");
        });

        modelBuilder.Entity<StaffBenefitDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("STAFF_BENEFIT_DETAIL");

            entity.Property(e => e.Amount)
                .HasColumnType("NUMBER(38,3)")
                .HasColumnName("AMOUNT");
            entity.Property(e => e.BenefitName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("BENEFIT_NAME");
            entity.Property(e => e.BnId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("BN_ID");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_NAME");
            entity.Property(e => e.FullName)
                .HasMaxLength(152)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NOTE");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSITION_NAME");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STAFF_ID");
        });

        modelBuilder.Entity<StaffInfo>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("STAFF_INFO");

            entity.Property(e => e.Account)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("ACCOUNT");
            entity.Property(e => e.Address)
                .HasMaxLength(317)
                .IsUnicode(false)
                .HasColumnName("ADDRESS");
            entity.Property(e => e.BasicSalary)
                .HasColumnType("NUMBER")
                .HasColumnName("BASIC_SALARY");
            entity.Property(e => e.Benefit)
                .HasColumnType("NUMBER")
                .HasColumnName("BENEFIT");
            entity.Property(e => e.ContractDuration)
                .HasColumnType("DATE")
                .HasColumnName("CONTRACT_DURATION");
            entity.Property(e => e.ContractTypeName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CONTRACT_TYPE_NAME");
            entity.Property(e => e.DateOfBrith)
                .HasColumnType("DATE")
                .HasColumnName("DATE_OF_BRITH");
            entity.Property(e => e.DayOff)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DAY_OFF");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_NAME");
            entity.Property(e => e.EducationLevel)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EDUCATION_LEVEL");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("EMAIL");
            entity.Property(e => e.EntryDate)
                .HasColumnType("DATE")
                .HasColumnName("ENTRY_DATE");
            entity.Property(e => e.FullName)
                .HasMaxLength(152)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("GENDER");
            entity.Property(e => e.Id)
                .HasMaxLength(12)
                .IsUnicode(false)
                .HasColumnName("ID");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("PHONE");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSITION_NAME");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("STATUS");
        });

        modelBuilder.Entity<StaffTimeKeeping>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("STAFF_TIME_KEEPING");

            entity.Property(e => e.CheckIn)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("CHECK_IN");
            entity.Property(e => e.CheckOut)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("CHECK_OUT");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_NAME");
            entity.Property(e => e.FullName)
                .HasMaxLength(152)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSITION_NAME");
            entity.Property(e => e.ShiftName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("SHIFT_NAME");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.WorkDate)
                .HasColumnType("DATE")
                .HasColumnName("WORK_DATE");
            entity.Property(e => e.WsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WS_ID");
        });

        modelBuilder.Entity<StaffWorkScheduleDetail>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("STAFF_WORK_SCHEDULE_DETAIL");

            entity.Property(e => e.DateOff)
                .HasPrecision(1)
                .HasColumnName("DATE_OFF");
            entity.Property(e => e.DayOff)
                .HasColumnType("NUMBER(38)")
                .HasColumnName("DAY_OFF");
            entity.Property(e => e.DepartmentName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("DEPARTMENT_NAME");
            entity.Property(e => e.FullName)
                .HasMaxLength(152)
                .IsUnicode(false)
                .HasColumnName("FULL_NAME");
            entity.Property(e => e.PositionName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("POSITION_NAME");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.WorkDate)
                .HasColumnType("DATE")
                .HasColumnName("WORK_DATE");
            entity.Property(e => e.WsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("WS_ID");
        });

        modelBuilder.Entity<TimeKeeping>(entity =>
        {
            entity.HasKey(e => new { e.WsId, e.StaffId, e.ShiftId }).HasName("TIME_KEEPING_PK");

            entity.ToTable("TIME_KEEPING");

            entity.Property(e => e.WsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("WS_ID");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.ShiftId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("SHIFT_ID");
            entity.Property(e => e.CheckIn)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("CHECK_IN");
            entity.Property(e => e.CheckOut)
                .HasColumnType("INTERVAL DAY(2) TO SECOND(6)")
                .HasColumnName("CHECK_OUT");

            entity.HasOne(d => d.Shift).WithMany(p => p.TimeKeepings)
                .HasForeignKey(d => d.ShiftId)
                .HasConstraintName("FK_SHIFT_ID");

            entity.HasOne(d => d.WorkScheduleDetail).WithMany(p => p.TimeKeepings)
                .HasForeignKey(d => new { d.WsId, d.StaffId })
                .HasConstraintName("FK_WS_ID_STAFF_ID");
        });

        modelBuilder.Entity<TimeKeepingMethod>(entity =>
        {
            entity.HasKey(e => e.TkmId).HasName("TIME_KEEPING_METHOD_PK");

            entity.ToTable("TIME_KEEPING_METHOD");

            entity.HasIndex(e => e.TimeKeepingMethodName, "UK_TIME_KEEPING_METHOD_NAME").IsUnique();

            entity.Property(e => e.TkmId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("TKM_ID");
            entity.Property(e => e.TimeKeepingMethodName)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("TIME_KEEPING_METHOD_NAME");
        });

        modelBuilder.Entity<WorkSchedule>(entity =>
        {
            entity.HasKey(e => e.WsId).HasName("WORK_SCHEDULE_PK");

            entity.ToTable("WORK_SCHEDULE");

            entity.HasIndex(e => e.WorkDate, "UK_WORK_DATE").IsUnique();

            entity.Property(e => e.WsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("WS_ID");
            entity.Property(e => e.WorkDate)
                .ValueGeneratedOnAdd()
                .HasColumnType("DATE")
                .HasColumnName("WORK_DATE");
        });

        modelBuilder.Entity<WorkScheduleDetail>(entity =>
        {
            entity.HasKey(e => new { e.WsId, e.StaffId }).HasName("WORK_SCHEDULE_DETAIL_PK");

            entity.ToTable("WORK_SCHEDULE_DETAIL");

            entity.Property(e => e.WsId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("WS_ID");
            entity.Property(e => e.StaffId)
                .HasMaxLength(20)
                .IsUnicode(false)
                .ValueGeneratedOnAdd()
                .HasColumnName("STAFF_ID");
            entity.Property(e => e.DateOff)
                .HasPrecision(1)
                .ValueGeneratedOnAdd()
                .HasDefaultValueSql("0")
                .HasColumnName("DATE_OFF");
            entity.Property(e => e.Note)
                .HasMaxLength(1000)
                .IsUnicode(false)
                .HasColumnName("NOTE");

            entity.HasOne(d => d.Staff).WithMany(p => p.WorkScheduleDetails)
                .HasForeignKey(d => d.StaffId)
                .HasConstraintName("FK_STAFF_ID");

            entity.HasOne(d => d.Ws).WithMany(p => p.WorkScheduleDetails)
                .HasForeignKey(d => d.WsId)
                .HasConstraintName("FK_WS_ID");
        });
        modelBuilder.HasSequence("AUTO_ID_BENEFIT");
        modelBuilder.HasSequence("AUTO_ID_CONTRACT_TYPE");
        modelBuilder.HasSequence("AUTO_ID_DEPARTMENT");
        modelBuilder.HasSequence("AUTO_ID_POSITION");
        modelBuilder.HasSequence("AUTO_ID_SHIFT");
        modelBuilder.HasSequence("AUTO_ID_SHIFT_TYPE");
        modelBuilder.HasSequence("AUTO_ID_STAFF");
        modelBuilder.HasSequence("AUTO_ID_TIME_KEEPING_METHOD");
        modelBuilder.HasSequence("AUTO_ID_WORK_SCHEDULE");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
