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

        public virtual DbSet<Exam> Exam { get; set; }
        public virtual DbSet<Lokacija> Lokacija { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserRole> UserRole { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseMySQL("server=localhost;port=3306;user=root;password=vujke1996;database=mis");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Exam>(entity =>
            {
                entity.ToTable("exam");

                entity.HasIndex(e => e.DoctorId)
                    .HasName("fk_doktor_idx");

                entity.HasIndex(e => e.LocationId)
                    .HasName("fk_lokacija_idx");

                entity.HasIndex(e => e.PacijentId)
                    .HasName("fk_pacijent_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Anameza).HasColumnName("anameza");

                entity.Property(e => e.Datetime).HasColumnName("datetime");

                entity.Property(e => e.DiscountPrice).HasColumnName("discount_price");

                entity.Property(e => e.DoctorId)
                    .HasColumnName("doctor_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.ExamType)
                    .IsRequired()
                    .HasColumnName("exam_type")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.LocationId)
                    .HasColumnName("location_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.PacijentId)
                    .HasColumnName("pacijent_id")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Price).HasColumnName("price");

                entity.Property(e => e.Taken)
                    .HasColumnName("taken")
                    .HasDefaultValueSql("'0'");

                entity.Property(e => e.Zakljucak).HasColumnName("zakljucak");

                entity.HasOne(d => d.Doctor)
                    .WithMany(p => p.ExamDoctor)
                    .HasForeignKey(d => d.DoctorId)
                    .HasConstraintName("fk_doktor");

                entity.HasOne(d => d.Location)
                    .WithMany(p => p.Exam)
                    .HasForeignKey(d => d.LocationId)
                    .HasConstraintName("fk_lokacija");

                entity.HasOne(d => d.Pacijent)
                    .WithMany(p => p.ExamPacijent)
                    .HasForeignKey(d => d.PacijentId)
                    .HasConstraintName("fk_pacijent");
            });

            modelBuilder.Entity<Lokacija>(entity =>
            {
                entity.ToTable("lokacija");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Aktivan).HasColumnName("aktivan");

                entity.Property(e => e.Naziv)
                    .HasColumnName("naziv")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("role");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Uloga)
                    .IsRequired()
                    .HasColumnName("uloga")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("user");

                entity.HasIndex(e => new { e.Username, e.Email })
                    .HasName("username_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Adresa)
                    .HasColumnName("adresa")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.AktivacioniToken)
                    .IsRequired()
                    .HasColumnName("aktivacioni_token")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Aktivan).HasColumnName("aktivan");

                entity.Property(e => e.Drzava)
                    .HasColumnName("drzava")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasColumnName("email")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Grad)
                    .HasColumnName("grad")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Ime)
                    .HasColumnName("ime")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Lbo)
                    .IsRequired()
                    .HasColumnName("lbo")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasColumnName("password")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Prezime)
                    .HasColumnName("prezime")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Telefon)
                    .HasColumnName("telefon")
                    .HasMaxLength(45)
                    .IsUnicode(false);

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasColumnName("username")
                    .HasMaxLength(45)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserRole>(entity =>
            {
                entity.ToTable("user_role");

                entity.HasIndex(e => e.RoleId)
                    .HasName("FK_role_idx");

                entity.HasIndex(e => e.UserId)
                    .HasName("FK_user_idx");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.RoleId).HasColumnName("role_id");

                entity.Property(e => e.UserId).HasColumnName("user_id");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_role");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserRole)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_user");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
