using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Italika_Ramiro.Models
{
    public partial class ItalikaContext : DbContext
    {
        //public ItalikaContext()
        //{
        //}

        public ItalikaContext(DbContextOptions<ItalikaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Moto> Moto { get; set; }
        public virtual DbSet<Tipo> Tipo { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //    }
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Moto>(entity =>
            {
                entity.HasKey(e => e.IdMoto);

                entity.Property(e => e.IdMoto).HasColumnName("idMoto");

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Fert)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Modelo)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.NumeroSerie)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Sku)
                    .HasColumnName("SKU")
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.HasOne(d => d.IdTipoNavigation)
                    .WithMany(p => p.Moto)
                    .HasForeignKey(d => d.IdTipo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Moto_Tipo");
            });

            modelBuilder.Entity<Tipo>(entity =>
            {
                entity.HasKey(e => e.IdTipo);

                entity.Property(e => e.IdTipo).HasColumnName("idTipo");

                entity.Property(e => e.Tipo1)
                    .IsRequired()
                    .HasColumnName("Tipo")
                    .HasMaxLength(500)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
