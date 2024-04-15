using Microsoft.EntityFrameworkCore;
using TechnicalTest.Models;

namespace TechnicalTest.Repository;

public partial class TechnicalTestContext : DbContext
{
    public TechnicalTestContext()
    {
    }

    public TechnicalTestContext(DbContextOptions<TechnicalTestContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Area> Areas { get; set; }

    public virtual DbSet<DocumentType> DocumentTypes { get; set; }

    public virtual DbSet<Employee> Employees { get; set; }

    public virtual DbSet<ExtraHour> ExtraHours { get; set; }

    public virtual DbSet<RejectedExtraHour> RejectedExtraHours { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => base.OnConfiguring(optionsBuilder);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Area>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Areas__3214EC074CF8C14F");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Document__3214EC07B5775D08");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Employee>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Employee__3214EC07D29A69CE");

            entity.HasIndex(e => e.Email, "UQ_Employees_Email").IsUnique();

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Surname)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Area).WithMany(p => p.Employees)
                .HasForeignKey(d => d.AreaId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Areas");

            entity.HasOne(d => d.DocumentType).WithMany(p => p.Employees)
                .HasForeignKey(d => d.DocumentTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_DocumentTypes");

            entity.HasOne(d => d.Leader).WithMany(p => p.InverseLeader)
                .HasForeignKey(d => d.LeaderId)
                .HasConstraintName("FK_Employees_Employees");

            entity.HasOne(d => d.Rol).WithMany(p => p.Employees)
                .HasForeignKey(d => d.RolId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employees_Roles");
        });

        modelBuilder.Entity<ExtraHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ExtraHou__3214EC07C346BF7E");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.Employee).WithMany(p => p.ExtraHours)
                .HasForeignKey(d => d.EmployeeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ExtraHours_Employees");
        });

        modelBuilder.Entity<RejectedExtraHour>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Rejected__3214EC074056B9DF");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);

            entity.HasOne(d => d.ExtraHour).WithMany(p => p.RejectedExtraHours)
                .HasForeignKey(d => d.ExtraHourId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_RejectedExtraHours_ExtraHours");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Roles__3214EC07FA64ED3C");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
