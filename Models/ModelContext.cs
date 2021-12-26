using Microsoft.EntityFrameworkCore;
using System;

namespace Rating_App.Models
{
    class ModelContext : DbContext
    {
        public string DbPath { get; }
        public DbSet<ConfigModel> ConfigModel { get; set; }

        public DbSet<SlideModel> SlideModel { get; set; }

        public DbSet<RatingModel> RatingModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            _ = options.UseSqlite("FileName=cms.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Map table names
            modelBuilder.Entity<ConfigModel>().ToTable("Config");
            modelBuilder.Entity<ConfigModel>(entity =>
            {
                entity.HasKey(e => e.Key);
                entity.HasIndex(e => e.Value);
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SlideModel>().ToTable("Slide");
            modelBuilder.Entity<SlideModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Path);
                entity.HasIndex(e => e.Type);
                entity.HasIndex(e => e.Index);
            });
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<RatingModel>().ToTable("Rating");
            modelBuilder.Entity<RatingModel>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.HasIndex(e => e.Type);
                entity.HasIndex(e => e.State);
                entity.HasIndex(e => e.CreateAt);
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
