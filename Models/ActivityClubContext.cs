using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASPDotnetWebApplication.Models;

public partial class ActivityClubContext : DbContext
{
    public ActivityClubContext()
    {
    }

    public ActivityClubContext(DbContextOptions<ActivityClubContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<EventMember> EventMembers { get; set; }

    public virtual DbSet<Guide> Guides { get; set; }

    public virtual DbSet<GuideEvent> GuideEvents { get; set; }

    public virtual DbSet<GuideMember> GuideMembers { get; set; }

    public virtual DbSet<Member> Members { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-FOSSDE8\\SQLEXPRESS;Initial Catalog=ActivityClub;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Admins__3214EC07AFC651B8");

            entity.HasIndex(e => e.Email, "UQ__Admins__A9D10534B198FBCE").IsUnique();

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Events__3214EC0789F9DC8A");

            entity.Property(e => e.Category).HasMaxLength(100);
            entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.DateFrom).HasColumnType("datetime");
            entity.Property(e => e.DateTo).HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.Destination).HasMaxLength(100);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Status).HasMaxLength(50);
        });

        modelBuilder.Entity<EventMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__EventMem__3214EC07141AEF39");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Event).WithMany(p => p.EventMembers)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_Event");

            entity.HasOne(d => d.Member).WithMany(p => p.EventMembers)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_Member");
        });

        modelBuilder.Entity<Guide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Guides__3214EC076FCCEBFF");

            entity.HasIndex(e => e.Email, "UQ__Guides__A9D1053487079CAC").IsUnique();

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Profession).HasMaxLength(100);
        });

        modelBuilder.Entity<GuideEvent>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GuideEve__3214EC07FD3F354F");

            entity.Property(e => e.EventId).HasColumnName("EventID");
            entity.Property(e => e.GuideId).HasColumnName("GuideID");

            entity.HasOne(d => d.Event).WithMany(p => p.GuideEvents)
                .HasForeignKey(d => d.EventId)
                .HasConstraintName("FK_Event_Guide");

            entity.HasOne(d => d.Guide).WithMany(p => p.GuideEvents)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("FK_Guide");
        });

        modelBuilder.Entity<GuideMember>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__GuideMem__3214EC0717357434");

            entity.Property(e => e.GuideId).HasColumnName("GuideID");
            entity.Property(e => e.MemberId).HasColumnName("MemberID");

            entity.HasOne(d => d.Guide).WithMany(p => p.GuideMembers)
                .HasForeignKey(d => d.GuideId)
                .HasConstraintName("FK_GuideMem");

            entity.HasOne(d => d.Member).WithMany(p => p.GuideMembers)
                .HasForeignKey(d => d.MemberId)
                .HasConstraintName("FK_MemberGui");
        });

        modelBuilder.Entity<Member>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Members__3214EC07D63EE14B");

            entity.HasIndex(e => e.Email, "UQ__Members__A9D105342CA7F4C6").IsUnique();

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.EmergencyNumber).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(100);
            entity.Property(e => e.Gender).HasMaxLength(50);
            entity.Property(e => e.JoiningDate).HasColumnType("datetime");
            entity.Property(e => e.MobileNumber).HasMaxLength(50);
            entity.Property(e => e.Nationality).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Profession).HasMaxLength(100);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
