using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace BPGamification
{
    public partial class DatabaseContext : DbContext
    {
        public DatabaseContext()
        {
        }

        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Coin> Coins { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Item> Items { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<Task> Tasks { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserBage> UserBages { get; set; }
        public virtual DbSet<UserTask> UserTasks { get; set; }
        public virtual DbSet<WorksHistory> WorksHistories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
          
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Coin>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("coin_pkey");

                entity.ToTable("coin");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.Coin)
                    .HasForeignKey<Coin>(d => d.UserId)
                    .HasConstraintName("coin_userId_fkey");
            });

            modelBuilder.Entity<Division>(entity =>
            {
                entity.HasKey(e => e.Code)
                    .HasName("division_pkey");

                entity.ToTable("division");

                entity.Property(e => e.Code).HasColumnName("code");

                entity.Property(e => e.City)
                    .HasColumnType("character varying")
                    .HasColumnName("city");

                entity.Property(e => e.Information)
                    .HasColumnType("character varying")
                    .HasColumnName("information");

                entity.Property(e => e.Name)
                    .HasColumnType("character varying")
                    .HasColumnName("name");
            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.Image)
                    .HasColumnType("character varying")
                    .HasColumnName("image");

                entity.Property(e => e.Info)
                    .HasColumnType("character varying")
                    .HasColumnName("info");

                entity.Property(e => e.Price).HasColumnName("price");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.ItemId).HasColumnName("itemId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Item)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.ItemId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Purchases_itemId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("Purchases_userId_fkey");
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.Property(e => e.Award).HasColumnName("award");

                entity.Property(e => e.NeedCnt).HasColumnName("NeedCNT");

                entity.Property(e => e.NeedKpi).HasColumnName("NeedKPI");

                entity.Property(e => e.TaskInfo)
                    .HasColumnType("character varying")
                    .HasColumnName("taskInfo");

                entity.Property(e => e.TaskName)
                    .HasColumnType("character varying")
                    .HasColumnName("taskName");

                entity.Property(e => e.TaskType)
                    .HasColumnType("character varying")
                    .HasColumnName("taskType");

                entity.Ignore(e => e.result);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DivisionCode).HasColumnName("division_code");

                entity.Property(e => e.Email)
                    .HasColumnType("character varying")
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasColumnType("character varying")
                    .HasColumnName("full_name");

                entity.Property(e => e.PasswordHash)
                    .HasColumnType("character varying")
                    .HasColumnName("passwordHash");

                entity.Property(e => e.Role)
                    .HasColumnType("character varying")
                    .HasColumnName("role");

                entity.HasOne(d => d.DivisionCodeNavigation)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.DivisionCode)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("users_division_code_fkey");
            });

            modelBuilder.Entity<UserBage>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("UserBages_pkey");

                entity.Property(e => e.UserId)
                    .ValueGeneratedNever()
                    .HasColumnName("userId");

                entity.Property(e => e.Count).HasColumnName("count");

                entity.Property(e => e.TaskType)
                    .HasColumnType("character varying")
                    .HasColumnName("taskType");

                entity.HasOne(d => d.User)
                    .WithOne(p => p.UserBage)
                    .HasForeignKey<UserBage>(d => d.UserId)
                    .HasConstraintName("UserBages_userId_fkey");
            });

            modelBuilder.Entity<UserTask>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TaskId).HasColumnName("taskId");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.TaskId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UserTasks_taskId_fkey");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserTasks)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("UserTasks_userId_fkey");
            });

            modelBuilder.Entity<WorksHistory>(entity =>
            {
                entity.ToTable("WorksHistory");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserId).HasColumnName("userId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.WorksHistories)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.Cascade)
                    .HasConstraintName("WorksHistory_userId_fkey");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
