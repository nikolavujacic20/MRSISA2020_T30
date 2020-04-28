using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Api.mis
{
    public partial class misContext : DbContext
    {
        public misContext()
        {
        }

        public misContext(DbContextOptions<misContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Pacijent> Pacijent { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=root;database=mis");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Pacijent>(entity =>
            {
                entity.ToTable("pacijent");

                entity.HasIndex(e => e.Jmbg)
                    .HasName("jmbg_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Lbo)
                    .HasName("lbo_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasColumnType("int unsigned");

                entity.Property(e => e.Active).HasColumnName("active");

                entity.Property(e => e.Birth)
                    .HasColumnName("birth")
                    .HasColumnType("date");

                entity.Property(e => e.BloodType)
                    .HasColumnName("blood_type")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Jmbg)
                    .IsRequired()
                    .HasColumnName("jmbg")
                    .HasMaxLength(13)
                    .IsUnicode(false);

                entity.Property(e => e.Lbo)
                    .IsRequired()
                    .HasColumnName("lbo")
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Surname)
                    .IsRequired()
                    .HasColumnName("surname")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
