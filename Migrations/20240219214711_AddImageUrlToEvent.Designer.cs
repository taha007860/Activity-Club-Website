﻿// <auto-generated />
using System;
using ASPDotnetWebApplication.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ASPDotnetWebApplication.Migrations
{
    [DbContext(typeof(ActivityClubContext))]
    [Migration("20240219214711_AddImageUrlToEvent")]
    partial class AddImageUrlToEvent
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ASPDotnetWebApplication.Models.Admin", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Admins__3214EC07AFC651B8");

                    b.HasIndex(new[] { "Email" }, "UQ__Admins__A9D10534B198FBCE")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Admins");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.Event", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Category")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal?>("Cost")
                        .HasColumnType("decimal(10, 2)");

                    b.Property<DateTime?>("DateFrom")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateTo")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Destination")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("ImageUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Status")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id")
                        .HasName("PK__Events__3214EC0789F9DC8A");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.EventMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("MemberID");

                    b.HasKey("Id")
                        .HasName("PK__EventMem__3214EC07141AEF39");

                    b.HasIndex("EventId");

                    b.HasIndex("MemberId");

                    b.ToTable("EventMembers");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.Guide", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("JoiningDate")
                        .HasColumnType("datetime");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Profession")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Guides__3214EC076FCCEBFF");

                    b.HasIndex(new[] { "Email" }, "UQ__Guides__A9D1053487079CAC")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Guides");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.GuideEvent", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("EventID");

                    b.Property<int?>("GuideId")
                        .HasColumnType("int")
                        .HasColumnName("GuideID");

                    b.HasKey("Id")
                        .HasName("PK__GuideEve__3214EC07FD3F354F");

                    b.HasIndex("EventId");

                    b.HasIndex("GuideId");

                    b.ToTable("GuideEvents");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.GuideMember", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("GuideId")
                        .HasColumnType("int")
                        .HasColumnName("GuideID");

                    b.Property<int?>("MemberId")
                        .HasColumnType("int")
                        .HasColumnName("MemberID");

                    b.HasKey("Id")
                        .HasName("PK__GuideMem__3214EC0717357434");

                    b.HasIndex("GuideId");

                    b.HasIndex("MemberId");

                    b.ToTable("GuideMembers");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.Member", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("date");

                    b.Property<string>("Email")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("EmergencyNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("FullName")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Gender")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("JoiningDate")
                        .HasColumnType("datetime");

                    b.Property<string>("MobileNumber")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Nationality")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Password")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<byte[]>("Photo")
                        .HasColumnType("varbinary(max)");

                    b.Property<string>("Profession")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id")
                        .HasName("PK__Members__3214EC07D63EE14B");

                    b.HasIndex(new[] { "Email" }, "UQ__Members__A9D105342CA7F4C6")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Members");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.EventMember", b =>
                {
                    b.HasOne("ASPDotnetWebApplication.Models.Event", "Event")
                        .WithMany("EventMembers")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_Event");

                    b.HasOne("ASPDotnetWebApplication.Models.Member", "Member")
                        .WithMany("EventMembers")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_Member");

                    b.Navigation("Event");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.GuideEvent", b =>
                {
                    b.HasOne("ASPDotnetWebApplication.Models.Event", "Event")
                        .WithMany("GuideEvents")
                        .HasForeignKey("EventId")
                        .HasConstraintName("FK_Event_Guide");

                    b.HasOne("ASPDotnetWebApplication.Models.Guide", "Guide")
                        .WithMany("GuideEvents")
                        .HasForeignKey("GuideId")
                        .HasConstraintName("FK_Guide");

                    b.Navigation("Event");

                    b.Navigation("Guide");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.GuideMember", b =>
                {
                    b.HasOne("ASPDotnetWebApplication.Models.Guide", "Guide")
                        .WithMany("GuideMembers")
                        .HasForeignKey("GuideId")
                        .HasConstraintName("FK_GuideMem");

                    b.HasOne("ASPDotnetWebApplication.Models.Member", "Member")
                        .WithMany("GuideMembers")
                        .HasForeignKey("MemberId")
                        .HasConstraintName("FK_MemberGui");

                    b.Navigation("Guide");

                    b.Navigation("Member");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.Event", b =>
                {
                    b.Navigation("EventMembers");

                    b.Navigation("GuideEvents");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.Guide", b =>
                {
                    b.Navigation("GuideEvents");

                    b.Navigation("GuideMembers");
                });

            modelBuilder.Entity("ASPDotnetWebApplication.Models.Member", b =>
                {
                    b.Navigation("EventMembers");

                    b.Navigation("GuideMembers");
                });
#pragma warning restore 612, 618
        }
    }
}
