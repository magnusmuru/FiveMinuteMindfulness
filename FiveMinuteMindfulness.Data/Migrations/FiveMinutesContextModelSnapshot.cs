﻿// <auto-generated />
using System;
using FiveMinuteMindfulness.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace FiveMinuteMindfulness.Data.Migrations
{
    [DbContext(typeof(FiveMinutesContext))]
    partial class FiveMinutesContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("AssignmentSection", b =>
                {
                    b.Property<Guid>("AssignmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("SectionsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssignmentsId", "SectionsId");

                    b.HasIndex("SectionsId");

                    b.ToTable("AssignmentSection");
                });

            modelBuilder.Entity("AssignmentUser", b =>
                {
                    b.Property<Guid>("AssignmentsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssignmentsId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("AssignmentUser");
                });

            modelBuilder.Entity("ChapterUser", b =>
                {
                    b.Property<Guid>("ChaptersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UsersId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ChaptersId", "UsersId");

                    b.HasIndex("UsersId");

                    b.ToTable("ChapterUser");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Application.Notification", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("NotificationType")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Application.Theme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ColorPallete")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Themes");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Assignment", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("CategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.ToTable("Assignments");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Category", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Chapter", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AssignmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Author")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ChapterType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsCompleted")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<Guid>("TranscriptionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("AssignmentId");

                    b.HasIndex("TranscriptionId")
                        .IsUnique();

                    b.ToTable("Chapters");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Section", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Sections");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Transcription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Transcriptions");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Journal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("CreatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<DateTime>("UpdatedAt")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("UpdatedBy")
                        .HasMaxLength(32)
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Journals");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ThemeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.HasIndex("ThemeId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("AssignmentSection", b =>
                {
                    b.HasOne("FiveMinuteMindfulness.Core.Models.Assignments.Assignment", null)
                        .WithMany()
                        .HasForeignKey("AssignmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiveMinuteMindfulness.Core.Models.Assignments.Section", null)
                        .WithMany()
                        .HasForeignKey("SectionsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("AssignmentUser", b =>
                {
                    b.HasOne("FiveMinuteMindfulness.Core.Models.Assignments.Assignment", null)
                        .WithMany()
                        .HasForeignKey("AssignmentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiveMinuteMindfulness.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ChapterUser", b =>
                {
                    b.HasOne("FiveMinuteMindfulness.Core.Models.Assignments.Chapter", null)
                        .WithMany()
                        .HasForeignKey("ChaptersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiveMinuteMindfulness.Core.Models.User", null)
                        .WithMany()
                        .HasForeignKey("UsersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Application.Notification", b =>
                {
                    b.HasOne("FiveMinuteMindfulness.Core.Models.User", "User")
                        .WithMany("Notifications")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Assignment", b =>
                {
                    b.HasOne("FiveMinuteMindfulness.Core.Models.Assignments.Category", "Category")
                        .WithMany("Assignments")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Category");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Chapter", b =>
                {
                    b.HasOne("FiveMinuteMindfulness.Core.Models.Assignments.Assignment", "Assignment")
                        .WithMany("Chapters")
                        .HasForeignKey("AssignmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiveMinuteMindfulness.Core.Models.Assignments.Transcription", "Transcription")
                        .WithOne("Chapter")
                        .HasForeignKey("FiveMinuteMindfulness.Core.Models.Assignments.Chapter", "TranscriptionId");

                    b.Navigation("Assignment");

                    b.Navigation("Transcription");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Journal", b =>
                {
                    b.HasOne("FiveMinuteMindfulness.Core.Models.User", "User")
                        .WithMany("Journals")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.User", b =>
                {
                    b.HasOne("FiveMinuteMindfulness.Core.Models.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("FiveMinuteMindfulness.Core.Models.Application.Theme", "Theme")
                        .WithMany("Users")
                        .HasForeignKey("ThemeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");

                    b.Navigation("Theme");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Application.Theme", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Assignment", b =>
                {
                    b.Navigation("Chapters");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Category", b =>
                {
                    b.Navigation("Assignments");
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.Assignments.Transcription", b =>
                {
                    b.Navigation("Chapter")
                        .IsRequired();
                });

            modelBuilder.Entity("FiveMinuteMindfulness.Core.Models.User", b =>
                {
                    b.Navigation("Journals");

                    b.Navigation("Notifications");
                });
#pragma warning restore 612, 618
        }
    }
}
