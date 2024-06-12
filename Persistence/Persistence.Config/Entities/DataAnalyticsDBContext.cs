using System;
using System.Collections;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal;

namespace Persistence.Config.Entities
{
    public partial class DataAnalyticsDBContext : DbContext
    {
        private static string _connectionString;
        public DataAnalyticsDBContext()
        {
        }

        public DataAnalyticsDBContext(DbContextOptions<DataAnalyticsDBContext> options)
            : base(options)
        {
            //  _connectionString = ((Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal.SqlServerOptionsExtension)options.Extensions.First()).ConnectionString;
            var sqlServerOptionsExtension =
                        options.FindExtension<SqlServerOptionsExtension>();
            if (sqlServerOptionsExtension != null)
            {
                _connectionString = sqlServerOptionsExtension.ConnectionString;
            }

        }

        public virtual DbSet<Bookmark> Bookmarks { get; set; } = null!;
        public virtual DbSet<CustomerTenant> CustomerTenants { get; set; } = null!;
        public virtual DbSet<CustomerUser> CustomerUsers { get; set; } = null!;
        public virtual DbSet<CustomerUserAssignGroup> CustomerUserAssignGroups { get; set; } = null!;
        public virtual DbSet<CustomerUserGroup> CustomerUserGroups { get; set; } = null!;
        public virtual DbSet<CustomerUserGroupRole> CustomerUserGroupRoles { get; set; } = null!;
        public virtual DbSet<CustomerUserRole> CustomerUserRoles { get; set; } = null!;
        public virtual DbSet<Idea> Ideas { get; set; } = null!;
        public virtual DbSet<IdeaImage> IdeaImages { get; set; } = null!;
        public virtual DbSet<IdeaVoteDetail> IdeaVoteDetails { get; set; } = null!;
        public virtual DbSet<Like> Likes { get; set; } = null!;
        public virtual DbSet<ReportBug> ReportBugs { get; set; } = null!;
        public virtual DbSet<ReportInDashboard> ReportInDashboards { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserReportCardImage> UserReportCardImages { get; set; } = null!;
        public virtual DbSet<UserThemeSetting> UserThemeSettings { get; set; } = null!;
        public virtual DbSet<UserTrack> UserTracks { get; set; } = null!;
        public virtual DbSet<UserVault> UserVaults { get; set; } = null!;
        public virtual DbSet<UserVaultAppDetail> UserVaultAppDetails { get; set; } = null!;
        public virtual DbSet<SystemName> SystemNames { get; set; } = null!;
        public virtual DbSet<DatasetGovernance> DatasetGovernance { get; set; } = null!;
        public virtual DbSet<AppProfile> Profiles { get; set; }
        public virtual DbSet<ServicePrincipalTenant> ServicePrincipalTenants { get; set; }
        public virtual DbSet<Logs> Logs { get; set; }
        public virtual DbSet<TableListHistory> TableListHistory { get; set; }
        public virtual DbSet<ReportThemes> ReportThemes { get; set; }
        public virtual DbSet<SalesForceTable> SalesForceTable { get; set; }
        public virtual DbSet<UserVaultSalesForceTable> UserVaultSalesForceTable { get; set; }




        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var data = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString,
                    builder => builder.EnableRetryOnFailure());
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bookmark>(entity =>
            {
                entity.ToTable("Bookmark");

                entity.HasIndex(e => e.ReportDbid, "IX_Bookmark_reportDBID");

                entity.HasIndex(e => e.UserId, "IX_Bookmark_userID");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ReportDbid).HasColumnName("reportDBID");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.ReportDb)
                    .WithMany(p => p.Bookmarks)
                    .HasForeignKey(d => d.ReportDbid)
                    .HasConstraintName("FK__Bookmark__reportDBID__114A936A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bookmarks)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Bookmark__userID__10566F31");
            });

            modelBuilder.Entity<CustomerTenant>(entity =>
            {
                entity.ToTable("CustomerTenant");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerUser>(entity =>
            {
                entity.ToTable("CustomerUser");

                entity.Property(e => e.DateCreated)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.UserName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerUserAssignGroup>(entity =>
            {
                entity.ToTable("CustomerUserAssignGroup");

                entity.HasOne(d => d.CustomerUserGroup)
                    .WithMany(p => p.CustomerUserAssignGroups)
                    .HasForeignKey(d => d.CustomerUserGroupId)
                    .HasConstraintName("FK_CustomerUserAssignGroup_CustomerUserGroup");

                entity.HasOne(d => d.CustomerUser)
                    .WithMany(p => p.CustomerUserAssignGroups)
                    .HasForeignKey(d => d.CustomerUserId)
                    .HasConstraintName("FK_CustomerUserAssignGroup_CustomerUser");
            });

            modelBuilder.Entity<CustomerUserGroup>(entity =>
            {
                entity.ToTable("CustomerUserGroup");

                entity.Property(e => e.GroupName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ViewAllReport).HasDefaultValueSql("((0))");

                entity.HasOne(d => d.CustomerTenant)
                    .WithMany(p => p.CustomerUserGroups)
                    .HasForeignKey(d => d.CustomerTenantId)
                    .HasConstraintName("FK_CustomerUserGroup_CustomerTenant");
            });

            modelBuilder.Entity<CustomerUserGroupRole>(entity =>
            {
                entity.ToTable("CustomerUserGroupRole");

                entity.HasOne(d => d.CustomerUserGroup)
                    .WithMany(p => p.CustomerUserGroupRoles)
                    .HasForeignKey(d => d.CustomerUserGroupId)
                    .HasConstraintName("FK_CustomerUserGroupRole_CustomerUserGroup");

                entity.HasOne(d => d.CustomerUserRole)
                    .WithMany(p => p.CustomerUserGroupRoles)
                    .HasForeignKey(d => d.CustomerUserRoleId)
                    .HasConstraintName("FK_CustomerUserGroupRole_CustomerUserRole");
            });

            modelBuilder.Entity<CustomerUserRole>(entity =>
            {
                entity.ToTable("CustomerUserRole");

                entity.Property(e => e.Code)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleName)
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });
            modelBuilder.Entity<DatasetGovernance>(entity =>
            {
                entity.ToTable("DatasetGovernance");
            });
            modelBuilder.Entity<AppProfile>(entity =>
            {
                entity.ToTable("AppProfile");
            });
            modelBuilder.Entity<ServicePrincipalTenant>(entity =>
            {
                entity.ToTable("ServicePrincipalTenant");
            });
            modelBuilder.Entity<Idea>(entity =>
            {
                entity.ToTable("Idea");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.SubmittedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Title).HasMaxLength(2000);
            });

            modelBuilder.Entity<IdeaImage>(entity =>
            {
                entity.ToTable("IdeaImage");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.FileName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ImageBlobUrl).HasColumnName("ImageBlobURL");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IdeaVoteDetail>(entity =>
            {
                entity.ToTable("IdeaVoteDetail");

                entity.Property(e => e.DateVoted).HasColumnType("datetime");

                entity.Property(e => e.VotedBy)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Idea)
                    .WithMany(p => p.IdeaVoteDetails)
                    .HasForeignKey(d => d.IdeaId)
                    .HasConstraintName("FK_IdeaVoteDetail_Idea");
            });

            modelBuilder.Entity<Like>(entity =>
            {
                entity.ToTable("Like");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CustomerTenantId).HasColumnName("CustomerTenantID");

                entity.Property(e => e.ReportDbid).HasColumnName("reportDBID");

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.ReportDb)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.ReportDbid)
                    .HasConstraintName("FK__Like__reportDBID__114A936A");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Likes)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Like__userID__10566F31");
            });

            modelBuilder.Entity<ReportBug>(entity =>
            {
                entity.ToTable("ReportBug");

                entity.Property(e => e.DateReported).HasColumnType("datetime");

                entity.Property(e => e.ReportedBy).HasMaxLength(200);

                entity.Property(e => e.Title).HasMaxLength(2000);
            });

            modelBuilder.Entity<ReportInDashboard>(entity =>
            {
                entity.HasKey(e => e.ReportDbid)
                    .HasName("PK__ReportIn__EA8D83C87673B0AE");

                entity.ToTable("ReportInDashboard");

                entity.HasIndex(e => e.ReportPowerBiId, "UC_ReportInDashboard_ReportPowerBiId")
                    .IsUnique();

                entity.HasIndex(e => e.UserRoleCode, "UC_ReportInDashboard_UserRoleCode")
                    .IsUnique();

                entity.Property(e => e.ReportDbid).HasColumnName("reportDBID");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.Tags)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserRoleCode)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<UserReportCardImage>(entity =>
            {
                entity.ToTable("UserReportCardImage");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.DateUpdated).HasColumnType("datetime");

                entity.Property(e => e.ImageBlobUrl)
                    .IsUnicode(false)
                    .HasColumnName("ImageBlobURL");

                entity.Property(e => e.ReportDbid).HasColumnName("ReportDBID");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserThemeSetting>(entity =>
            {
                entity.ToTable("UserThemeSetting");

                entity.Property(e => e.BackgroundColorHex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BackgroundFontColorHex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BackgroundImageLogoUrl).IsUnicode(false);

                entity.Property(e => e.DashboardColorHex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DashboardFontColorHex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.HeaderImageLogoUrl).IsUnicode(false);

                entity.Property(e => e.NavigationColorHex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NavigationFontColorHex)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.SwitchTheme)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserTrack>(entity =>
            {
                entity.HasKey(e => e.TrackId)
                    .HasName("PK__UserTrac__55B5F9B2E2BBC971");

                entity.ToTable("UserTrack");

                entity.Property(e => e.TrackId).HasColumnName("trackID");

                entity.Property(e => e.Browser)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("browser");

                entity.Property(e => e.DateTimeLog)
                    .HasColumnType("datetime")
                    .HasColumnName("dateTimeLog");

                entity.Property(e => e.Ip)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("IP");

                entity.Property(e => e.Page)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("page");

                entity.Property(e => e.ReportName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("reportName");

                entity.Property(e => e.UserEmail)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userEmail");

                entity.Property(e => e.UserName)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("userName");
            });

            modelBuilder.Entity<UserVault>(entity =>
            {
                entity.ToTable("UserVault");

                entity.Property(e => e.ContentType).HasMaxLength(1000);

                entity.Property(e => e.CustomerTenantId).HasColumnName("CustomerTenantID");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");
            });


            modelBuilder.Entity<UserVaultAppDetail>(entity =>
            {
                entity.Property(e => e.AccessToken).IsUnicode(false);

                entity.Property(e => e.ClientId)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ClientSecret)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DateTokenExpiredUtc)
                    .HasColumnType("datetime")
                    .HasColumnName("DateTokenExpiredUTC");

                entity.Property(e => e.RefreshToken).IsUnicode(false);
            });

            modelBuilder.Entity<SystemName>(entity =>
            {
                entity.ToTable("SystemName");
                entity.Property(e => e.Name).HasMaxLength(255);
            });
            modelBuilder.Entity<ReportThemes>(entity =>
            {
                entity.ToTable("ReportThemes");
            });

            OnModelCreatingPartial(modelBuilder);
        }
   

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
