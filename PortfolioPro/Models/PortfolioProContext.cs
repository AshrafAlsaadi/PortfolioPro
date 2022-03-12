using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace PortfolioPro.Models
{
    public partial class PortfolioProContext : DbContext
    {
        public PortfolioProContext()
        {
        }

        public PortfolioProContext(DbContextOptions<PortfolioProContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAbout> TbAbouts { get; set; }
        public virtual DbSet<TbFooter> TbFooters { get; set; }
        public virtual DbSet<TbService> TbServices { get; set; }
        public virtual DbSet<TbSlider> TbSliders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAbout>(entity =>
            {
                entity.ToTable("TbAbout");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .HasColumnName("phone");

                entity.Property(e => e.Profile)
                    .HasMaxLength(50)
                    .HasColumnName("profile");
            });

            modelBuilder.Entity<TbFooter>(entity =>
            {
                entity.ToTable("TbFooter");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Description).HasColumnName("description");

                entity.Property(e => e.Message).HasColumnName("message");

                entity.Property(e => e.Subject)
                    .HasMaxLength(50)
                    .HasColumnName("subject");

                entity.Property(e => e.YourEmail)
                    .HasMaxLength(50)
                    .HasColumnName("your_email");

                entity.Property(e => e.YourName)
                    .HasMaxLength(50)
                    .HasColumnName("your_name");
            });

            modelBuilder.Entity<TbService>(entity =>
            {
                entity.ToTable("TbService");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.ServiceDescription).HasColumnName("service_description");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .HasColumnName("service_name");
            });

            modelBuilder.Entity<TbSlider>(entity =>
            {
                entity.ToTable("TbSlider");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Image).HasColumnName("image");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
