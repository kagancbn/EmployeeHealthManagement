using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using HealthManagement.Models;

#nullable disable

namespace HealthManagement.Data
{
    public partial class DenemeDBContext : DbContext
    {
        public DenemeDBContext()
        {
        }

        public DenemeDBContext(DbContextOptions<DenemeDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Asi> Asis { get; set; }
        public virtual DbSet<Belirti> Belirtis { get; set; }
        public virtual DbSet<CovidDurumu> CovidDurumus { get; set; }
        public virtual DbSet<Egitim> Egitims { get; set; }
        public virtual DbSet<Eleman> Elemen { get; set; }
        public virtual DbSet<HastalikKaydi> HastalikKaydis { get; set; }
        public virtual DbSet<Hastaliklar> Hastaliklars { get; set; }
        public virtual DbSet<KanGrubu> KanGrubus { get; set; }
        public virtual DbSet<Recete> Recetes { get; set; }
        public virtual DbSet<Sehir> Sehirs { get; set; }
        public virtual DbSet<Semptom> Semptoms { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=DESKTOP-4U8LR72;Database=DenemeDB;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Turkish_CI_AS");

            modelBuilder.Entity<Asi>(entity =>
            {
                entity.Property(e => e.AsiIsim).IsUnicode(false);
            });

            modelBuilder.Entity<Belirti>(entity =>
            {
                entity.Property(e => e.BelirtiIsim).IsUnicode(false);
            });

            modelBuilder.Entity<CovidDurumu>(entity =>
            {
                entity.HasKey(e => new { e.CovidDurumuId, e.ElemanId });

                entity.Property(e => e.CovidDurumuId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Asi)
                    .WithMany(p => p.CovidDurumus)
                    .HasForeignKey(d => d.AsiId)
                    .HasConstraintName("FK_CovidDurumu_Asi");

                entity.HasOne(d => d.Belirti)
                    .WithMany(p => p.CovidDurumus)
                    .HasForeignKey(d => d.BelirtiId)
                    .HasConstraintName("FK_CovidDurumu_Belirti");

                entity.HasOne(d => d.Eleman)
                    .WithMany(p => p.CovidDurumus)
                    .HasForeignKey(d => d.ElemanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CovidDurumu_Eleman");
            });

            modelBuilder.Entity<Egitim>(entity =>
            {
                entity.Property(e => e.EgitimDuzeyi).IsUnicode(false);
            });

            modelBuilder.Entity<Eleman>(entity =>
            {
                entity.Property(e => e.Hobiler).IsUnicode(false);

                entity.Property(e => e.Isim).IsUnicode(false);

                entity.Property(e => e.Maas).IsUnicode(false);

                entity.Property(e => e.Pozisyon).IsUnicode(false);

                entity.Property(e => e.Soyisim).IsUnicode(false);

                entity.HasOne(d => d.Egitim)
                    .WithMany(p => p.Elemen)
                    .HasForeignKey(d => d.EgitimId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eleman_Egitim");

                entity.HasOne(d => d.KanGrubu)
                    .WithMany(p => p.Elemen)
                    .HasForeignKey(d => d.KanGrubuId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Eleman_KanGrubu");

                entity.HasOne(d => d.Sehir)
                    .WithMany(p => p.Elemen)
                    .HasForeignKey(d => d.SehirId)
                    .HasConstraintName("FK_Eleman_Sehir");
            });

            modelBuilder.Entity<HastalikKaydi>(entity =>
            {
                entity.HasKey(e => new { e.HastalikKaydiId, e.ElemanId });

                entity.Property(e => e.HastalikKaydiId).ValueGeneratedOnAdd();

                entity.HasOne(d => d.Eleman)
                    .WithMany(p => p.HastalikKaydis)
                    .HasForeignKey(d => d.ElemanId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HastalikKaydi_Eleman");

                entity.HasOne(d => d.Hastalik)
                    .WithMany(p => p.HastalikKaydis)
                    .HasForeignKey(d => d.HastalikId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HastalikKaydi_Hastaliklar");

                entity.HasOne(d => d.Ilac)
                    .WithMany(p => p.HastalikKaydis)
                    .HasForeignKey(d => d.IlacId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HastalikKaydi_Recete");

                entity.HasOne(d => d.Semptom)
                    .WithMany(p => p.HastalikKaydis)
                    .HasForeignKey(d => d.SemptomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HastalikKaydi_Semptom");
            });

            modelBuilder.Entity<Hastaliklar>(entity =>
            {
                entity.Property(e => e.HastalikIsim).IsUnicode(false);
            });

            modelBuilder.Entity<KanGrubu>(entity =>
            {
                entity.Property(e => e.KanGrubu1).IsUnicode(false);
            });

            modelBuilder.Entity<Recete>(entity =>
            {
                entity.Property(e => e.IlacDoz).IsUnicode(false);

                entity.Property(e => e.IlacIsim).IsUnicode(false);
            });

            modelBuilder.Entity<Sehir>(entity =>
            {
                entity.Property(e => e.Sehirİsim).IsUnicode(false);
            });

            modelBuilder.Entity<Semptom>(entity =>
            {
                entity.Property(e => e.SemptomIsim).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
