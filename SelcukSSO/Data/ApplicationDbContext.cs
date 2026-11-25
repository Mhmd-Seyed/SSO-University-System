
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SelcukSSO.Models.Entities;
using SelcukSSO.Models.Identity;

namespace SelcukSSO.Data;

public class ApplicationDbContext : IdentityDbContext<
    ApplicationUser,
    ApplicationRole,
    string,
    IdentityUserClaim<string>,
    ApplicationUserRole,
    IdentityUserLogin<string>,
    IdentityRoleClaim<string>,
    IdentityUserToken<string>>
{
    public ApplicationDbContext(
        DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    // Projemize özel tablolar
    public DbSet<Application> Applications => Set<Application>();
    public DbSet<Permission> Permissions => Set<Permission>();
    public DbSet<RolePermission> RolePermissions => Set<RolePermission>();
    public DbSet<SSOSession> SSOSessions => Set<SSOSession>();
    public DbSet<LoginHistory> LoginHistories => Set<LoginHistory>();
    public DbSet<AuditLog> AuditLogs => Set<AuditLog>();

    protected override void OnModelCreating(ModelBuilder builder)
    {
        // Identity'nin hazır PK, FK ve tablo yapılandırmaları
        base.OnModelCreating(builder);

        // ==========================================
        // 1. ASP.NET CORE IDENTITY TABLOLARI
        // ==========================================

        builder.Entity<ApplicationUser>(entity =>
        {
            entity.ToTable("AspNetUsers");

            entity.Property(x => x.FirstName)
                .HasMaxLength(100);

            entity.Property(x => x.LastName)
                .HasMaxLength(100);
        });

        builder.Entity<ApplicationRole>(entity =>
        {
            entity.ToTable("AspNetRoles");

            entity.Property(x => x.Code)
                .HasMaxLength(100);

            entity.Property(x => x.DisplayName)
                .HasMaxLength(150);

            // AspNetRoles.ApplicationId
            // → Applications.Id
            entity.HasOne<Application>()
                .WithMany()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(x => new
            { x.ApplicationId, x.Code })
                .IsUnique();
        });

        builder.Entity<ApplicationUserRole>(entity =>
        {
            entity.ToTable("AspNetUserRoles");

            // UserId ve RoleId:
            // PK ve FK ilişkileri Identity'den gelir.
        });

        builder.Entity<IdentityUserClaim<string>>()
            .ToTable("AspNetUserClaims");

        builder.Entity<IdentityRoleClaim<string>>()
            .ToTable("AspNetRoleClaims");

        builder.Entity<IdentityUserLogin<string>>()
            .ToTable("AspNetUserLogins");

        builder.Entity<IdentityUserToken<string>>()
            .ToTable("AspNetUserTokens");


        // ==========================================
        // 2. APPLICATIONS TABLOSU
        // ==========================================

        builder.Entity<Application>(entity =>
        {
            entity.ToTable("Applications");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Code)
                .HasMaxLength(50);

            entity.Property(x => x.Name)
                .HasMaxLength(150);

            entity.Property(x => x.BaseUrl)
                .HasMaxLength(500);

            entity.HasIndex(x => x.Code)
                .IsUnique();
        });


        // ==========================================
        // 3. PERMISSIONS TABLOSU
        // ==========================================

        builder.Entity<Permission>(entity =>
        {
            entity.ToTable("Permissions");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Code)
                .HasMaxLength(200);

            entity.Property(x => x.Description)
                .HasMaxLength(500);

            // Permissions.ApplicationId
            // → Applications.Id
            entity.HasOne<Application>()
                .WithMany()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // Aynı uygulamada aynı yetki kodu olamaz.
            entity.HasIndex(x => new
            { x.ApplicationId, x.Code })
                .IsUnique();
        });


        // ==========================================
        // 4. ROLEPERMISSIONS TABLOSU
        // ==========================================

        builder.Entity<RolePermission>(entity =>
        {
            entity.ToTable("RolePermissions");

            // Composite Primary Key
            entity.HasKey(x => new
            { x.RoleId, x.PermissionId });

            // RolePermissions.RoleId
            // → AspNetRoles.Id
            entity.HasOne<ApplicationRole>()
                .WithMany()
                .HasForeignKey(x => x.RoleId)
                .OnDelete(DeleteBehavior.Restrict);

            // RolePermissions.PermissionId
            // → Permissions.Id
            entity.HasOne<Permission>()
                .WithMany()
                .HasForeignKey(x => x.PermissionId)
                .OnDelete(DeleteBehavior.Restrict);
        });


        // ==========================================
        // 5. SSOSESSIONS TABLOSU
        // ==========================================

        builder.Entity<SSOSession>(entity =>
        {
            entity.ToTable("SSOSessions");

            entity.HasKey(x => x.SessionId);

            // SSOSessions.UserId
            // → AspNetUsers.Id
            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // SSOSessions.ApplicationId
            // → Applications.Id
            entity.HasOne<Application>()
                .WithMany()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            // SSOSessions.ActiveRoleId
            // → AspNetRoles.Id
            entity.HasOne<ApplicationRole>()
                .WithMany()
                .HasForeignKey(x => x.ActiveRoleId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(x => new
            { x.UserId, x.ApplicationId });
        });


        // ==========================================
        // 6. LOGINHISTORY TABLOSU
        // ==========================================

        builder.Entity<LoginHistory>(entity =>
        {
            entity.ToTable("LoginHistory");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.IpAddress)
                .HasMaxLength(45);

            entity.Property(x => x.FailureCode)
                .HasMaxLength(100);

            // LoginHistory.UserId
            // → AspNetUsers.Id
            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            // LoginHistory.ApplicationId
            // → Applications.Id
            entity.HasOne<Application>()
                .WithMany()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(x => x.LoginAt);
        });


        // ==========================================
        // 7. AUDITLOGS TABLOSU
        // ==========================================

        builder.Entity<AuditLog>(entity =>
        {
            entity.ToTable("AuditLogs");

            entity.HasKey(x => x.Id);

            entity.Property(x => x.Action)
                .HasMaxLength(100);

            entity.Property(x => x.EntityName)
                .HasMaxLength(100);

            entity.Property(x => x.EntityId)
                .HasMaxLength(450);

            entity.Property(x => x.Details)
                .HasMaxLength(4000);

            // İşlemi yapan kullanıcı
            // AuditLogs.ActorUserId
            // → AspNetUsers.Id
            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.ActorUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // İşlemden etkilenen kullanıcı
            // AuditLogs.TargetUserId
            // → AspNetUsers.Id
            entity.HasOne<ApplicationUser>()
                .WithMany()
                .HasForeignKey(x => x.TargetUserId)
                .OnDelete(DeleteBehavior.Restrict);

            // AuditLogs.ApplicationId
            // → Applications.Id
            entity.HasOne<Application>()
                .WithMany()
                .HasForeignKey(x => x.ApplicationId)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasIndex(x => x.CreatedAt);
        });
    }
}

