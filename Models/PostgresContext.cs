                               using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace colol2.Models;

public partial class PostgresContext : DbContext
{
    public PostgresContext()
    {
    }

    public PostgresContext(DbContextOptions<PostgresContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Gender> Genders { get; set; }

    public virtual DbSet<LoginUser> LoginUsers { get; set; }

    public virtual DbSet<PersonalityQuality> PersonalityQualities { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<UserQuality> UserQualities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("pg_catalog", "adminpack");

        modelBuilder.Entity<Gender>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("gender_pk");

            entity.ToTable("gender");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Gender1)
                .HasColumnType("character varying")
                .HasColumnName("gender");
        });

        modelBuilder.Entity<LoginUser>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("newtable_pk");

            entity.ToTable("login_user");

            entity.HasIndex(e => e.Login, "newtable_unique").IsUnique();

            entity.HasIndex(e => e.Password, "newtable_unique_1").IsUnique();

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Login)
                .HasColumnType("character varying")
                .HasColumnName("login");
            entity.Property(e => e.Password)
                .HasColumnType("character varying")
                .HasColumnName("password");
        });

        modelBuilder.Entity<PersonalityQuality>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("personality_quality_pk");

            entity.ToTable("personality_quality");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NameQuality)
                .HasColumnType("character varying")
                .HasColumnName("name_quality");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("user_pk");

            entity.ToTable("user");

            entity.Property(e => e.Id)
                .ValueGeneratedOnAdd()
                .HasColumnName("id");
            entity.Property(e => e.Birthday).HasColumnName("birthday");
            entity.Property(e => e.GenderId).HasColumnName("gender_id");
            entity.Property(e => e.Name)
                .HasColumnType("character varying")
                .HasColumnName("name");
            entity.Property(e => e.Patronymic)
                .HasColumnType("character varying")
                .HasColumnName("patronymic");
            entity.Property(e => e.Surname)
                .HasColumnType("character varying")
                .HasColumnName("surname");

            entity.HasOne(d => d.Gender).WithMany(p => p.Users)
                .HasForeignKey(d => d.GenderId)
                .HasConstraintName("user_gender_fk");

            entity.HasOne(d => d.IdNavigation).WithOne(p => p.User)
                .HasForeignKey<User>(d => d.Id)
                .HasConstraintName("user_login_user_fk");
        });

        modelBuilder.Entity<UserQuality>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("user_quality");

            entity.Property(e => e.IdQuality).HasColumnName("id_quality");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdQualityNavigation).WithMany()
                .HasForeignKey(d => d.IdQuality)
                .HasConstraintName("user_quality_personality_quality_fk");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("user_quality_user_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
