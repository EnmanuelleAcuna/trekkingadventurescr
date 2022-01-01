using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace trekkingadventurescr.Models.Data.EntityFramework
{
    public partial class trekkingadventurescr_DB_Context : DbContext
    {
        public trekkingadventurescr_DB_Context()
        {
        }

        public trekkingadventurescr_DB_Context(DbContextOptions<trekkingadventurescr_DB_Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Tours> Tours { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySql("server=217.71.206.171;uid=trekkingadventurescr;pwd=costa2020;database=trekkingadventurescr;sslmode=Preferred;treattinyasboolean=False", x => x.ServerVersion("8.0.27-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tours>(entity =>
            {
                entity.ToTable("TOURS");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.DescripcionBreve)
                    .IsRequired()
                    .HasColumnName("descripcion_breve")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.DescripcionCompleta)
                    .IsRequired()
                    .HasColumnName("descripcion_completa")
                    .HasColumnType("varchar(8000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.FechaRegistro)
                    .HasColumnName("fecha_registro")
                    .HasColumnType("datetime");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasColumnType("varchar(1000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");

                entity.Property(e => e.Precio)
                    .HasColumnName("precio")
                    .HasColumnType("decimal(10,0)");

                entity.Property(e => e.TourDestacado).HasColumnName("tour_destacado");

                entity.Property(e => e.UrlImagenEncabezado)
                    .IsRequired()
                    .HasColumnName("url_imagen_encabezado")
                    .HasColumnType("varchar(2000)")
                    .HasCharSet("utf8mb4")
                    .HasCollation("utf8mb4_0900_ai_ci");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
