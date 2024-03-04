using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Planner.Server.Models;

public partial class PlannerDbContext : DbContext
{
    public PlannerDbContext()
    {
    }

    public PlannerDbContext(DbContextOptions<PlannerDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<TaskDetail> TaskDetails { get; set; }

    public virtual DbSet<UserMaster> UserMasters { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=PlannerDB;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<TaskDetail>(entity =>
        {
            entity.HasKey(e => e.TdTaskId).HasName("PK__TaskDeta__D4D23031E751D6A1");

            entity.Property(e => e.TdTaskId)
                .ValueGeneratedNever()
                .HasColumnName("TD_taskID");
            entity.Property(e => e.TdCreatedDate)
                .HasColumnType("datetime")
                .HasColumnName("TD_createdDate");
            entity.Property(e => e.TdDescription)
                .HasMaxLength(5000)
                .IsUnicode(false)
                .HasColumnName("TD_description");
            entity.Property(e => e.TdDueDate)
                .HasColumnType("datetime")
                .HasColumnName("TD_dueDate");
            entity.Property(e => e.TdModifiedDate)
                .HasColumnType("datetime")
                .HasColumnName("TD_modifiedDate");
            entity.Property(e => e.TdProgress)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TD_progress");
            entity.Property(e => e.TdStartDate)
                .HasColumnType("datetime")
                .HasColumnName("TD_startDate");
            entity.Property(e => e.TdTitle)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("TD_title");
            entity.Property(e => e.TdUmUserId).HasColumnName("TD_UM_userID");

            entity.HasOne(d => d.TdTask).WithOne(p => p.TaskDetail)
                .HasForeignKey<TaskDetail>(d => d.TdTaskId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TaskDetai__TD_ta__267ABA7A");
        });

        modelBuilder.Entity<UserMaster>(entity =>
        {
            entity.HasKey(e => e.UmUserId).HasName("PK__User_Mas__786FA7C04415CE38");

            entity.ToTable("User_Master");

            entity.Property(e => e.UmUserId)
                .ValueGeneratedNever()
                .HasColumnName("UM_userID");
            entity.Property(e => e.UmCreatedOn)
                .HasColumnType("datetime")
                .HasColumnName("UM_createdOn");
            entity.Property(e => e.UmEmail)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("UM_email");
            entity.Property(e => e.UmFirstName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UM_firstName");
            entity.Property(e => e.UmIsActive).HasColumnName("UM_isActive");
            entity.Property(e => e.UmLastName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("UM_lastName");
            entity.Property(e => e.UmModifiedOn)
                .HasColumnType("datetime")
                .HasColumnName("UM_modifiedOn");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
