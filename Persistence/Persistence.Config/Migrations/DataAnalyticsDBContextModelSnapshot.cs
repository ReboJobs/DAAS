﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Persistence.Config.Entities;

#nullable disable

namespace Persistence.Config.Migrations
{
    [DbContext(typeof(DataAnalyticsDBContext))]
    partial class DataAnalyticsDBContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Persistence.Config.Entities.Bookmark", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ReportDbid")
                        .HasColumnType("int")
                        .HasColumnName("reportDBID");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.HasKey("Id");

                    b.HasIndex("ReportDbid");

                    b.HasIndex("UserId");

                    b.ToTable("Bookmark");
                });

            modelBuilder.Entity("Persistence.Config.Entities.Idea", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("SubmittedBy")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.Property<string>("Title")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.ToTable("Idea", (string)null);
                });

            modelBuilder.Entity("Persistence.Config.Entities.IdeaVoteDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateVoted")
                        .HasColumnType("datetime");

                    b.Property<int?>("IdeaId")
                        .HasColumnType("int");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("VotedBy")
                        .HasMaxLength(200)
                        .IsUnicode(false)
                        .HasColumnType("varchar(200)");

                    b.HasKey("Id");

                    b.HasIndex("IdeaId");

                    b.ToTable("IdeaVoteDetail", (string)null);
                });

            modelBuilder.Entity("Persistence.Config.Entities.Like", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<bool?>("IsLike")
                        .HasColumnType("bit");

                    b.Property<int?>("ReportDbid")
                        .HasColumnType("int")
                        .HasColumnName("reportDBID");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("UserId")
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    b.HasKey("Id");

                    b.HasIndex("ReportDbid");

                    b.HasIndex("UserId");

                    b.ToTable("Like");
                });

            modelBuilder.Entity("Persistence.Config.Entities.ReportBug", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateReported")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("ReportedBy")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<string>("Title")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.HasKey("Id");

                    b.ToTable("ReportBug", (string)null);
                });

            modelBuilder.Entity("Persistence.Config.Entities.ReportInDashboard", b =>
                {
                    b.Property<int>("ReportDbid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("reportDBID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ReportDbid"), 1L, 1);

                    b.Property<string>("Tags")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<string>("Title")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.HasKey("ReportDbid")
                        .HasName("PK__ReportIn__EA8D83C87673B0AE");

                    b.ToTable("ReportInDashboard");
                });

            modelBuilder.Entity("Persistence.Config.Entities.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("userID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"), 1L, 1);

                    b.Property<string>("UserName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("userName");

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Persistence.Config.Entities.UserReportCardImage", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<DateTime?>("DateUpdated")
                        .HasColumnType("datetime");

                    b.Property<string>("ImageBlobURL")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<int?>("ReportDBID")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.HasKey("Id");

                    b.ToTable("UserReportCardImage", (string)null);
                });

            modelBuilder.Entity("Persistence.Config.Entities.UserThemeSetting", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("BackgroundColorHex")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BackgroundFontColorHex")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("BackgroundImageLogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DashboardColorHex")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("DashboardFontColorHex")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("HeaderImageLogoUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsBackgroundImage")
                        .HasColumnType("bit");

                    b.Property<string>("NavigationColorHex")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NavigationFontColorHex")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserThemeSetting", (string)null);
                });

            modelBuilder.Entity("Persistence.Config.Entities.UserTrack", b =>
                {
                    b.Property<int>("TrackId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("trackID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("TrackId"), 1L, 1);

                    b.Property<string>("Browser")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("browser");

                    b.Property<DateTime?>("DateTimeLog")
                        .HasColumnType("datetime")
                        .HasColumnName("dateTimeLog");

                    b.Property<string>("Ip")
                        .HasMaxLength(15)
                        .IsUnicode(false)
                        .HasColumnType("varchar(15)")
                        .HasColumnName("IP");

                    b.Property<string>("Page")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("page");

                    b.Property<string>("ReportName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("reportName");

                    b.Property<string>("UserName")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)")
                        .HasColumnName("userName");

                    b.HasKey("TrackId");

                    b.ToTable("UserTrack");
                });

            modelBuilder.Entity("Persistence.Config.Entities.UserVault", b =>
                {
                    b.Property<int?>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int?>("Id"), 1L, 1);

                    b.Property<string>("ContentType")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<byte?>("SystemId")
                        .HasColumnType("tinyint");

                    b.HasKey("Id");

                    b.ToTable("UserVault", (string)null);
                });

            modelBuilder.Entity("Persistence.Config.Entities.Bookmark", b =>
                {
                    b.HasOne("Persistence.Config.Entities.ReportInDashboard", "ReportDb")
                        .WithMany("Bookmarks")
                        .HasForeignKey("ReportDbid")
                        .HasConstraintName("FK__Bookmark__reportDBID__114A936A");

                    b.HasOne("Persistence.Config.Entities.User", "User")
                        .WithMany("Bookmarks")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Bookmark__userID__10566F31");

                    b.Navigation("ReportDb");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Persistence.Config.Entities.IdeaVoteDetail", b =>
                {
                    b.HasOne("Persistence.Config.Entities.Idea", "Idead")
                        .WithMany("IdeaVoteDetails")
                        .HasForeignKey("IdeaId")
                        .HasConstraintName("FK_IdeaVoteDetail_Idea");

                    b.Navigation("Idead");
                });

            modelBuilder.Entity("Persistence.Config.Entities.Like", b =>
                {
                    b.HasOne("Persistence.Config.Entities.ReportInDashboard", "ReportDb")
                        .WithMany("Likes")
                        .HasForeignKey("ReportDbid")
                        .HasConstraintName("FK__Like__reportDBID__114A936A");

                    b.HasOne("Persistence.Config.Entities.User", "User")
                        .WithMany("Likes")
                        .HasForeignKey("UserId")
                        .HasConstraintName("FK__Like__userID__10566F31");

                    b.Navigation("ReportDb");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Persistence.Config.Entities.Idea", b =>
                {
                    b.Navigation("IdeaVoteDetails");
                });

            modelBuilder.Entity("Persistence.Config.Entities.ReportInDashboard", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Likes");
                });

            modelBuilder.Entity("Persistence.Config.Entities.User", b =>
                {
                    b.Navigation("Bookmarks");

                    b.Navigation("Likes");
                });
#pragma warning restore 612, 618
        }
    }
}
