using Meteoro.Corte.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meteoro.Corte.API.Infrastructure.Data
{
    public partial class db_MeteoroCorteContext : DbContext
    {
        public db_MeteoroCorteContext()
        {
        }

        public db_MeteoroCorteContext(DbContextOptions<db_MeteoroCorteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TbAdmin> TbAdmin { get; set; }
        public virtual DbSet<TbArea> TbArea { get; set; }
        public virtual DbSet<TbAseguradorEmpleado> TbAseguradorEmpleado { get; set; }
        public virtual DbSet<TbCategoria> TbCategoria { get; set; }
        public virtual DbSet<TbCorte> TbCorte { get; set; }
        public virtual DbSet<TbEmpleado> TbEmpleado { get; set; }
        public virtual DbSet<TbEmpresa> TbEmpresa { get; set; }
        public virtual DbSet<TbSemana> TbSemana { get; set; }   

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TbAdmin>(entity =>
            {
                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Novedad)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.VersionAct)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.VersionAnt)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength();
            });

            modelBuilder.Entity<TbArea>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbAseguradorEmpleado>(entity =>
            {
                entity.Property(e => e.Asegurador)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Empleado)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");
            });

            modelBuilder.Entity<TbCategoria>(entity =>
            {
                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbCorte>(entity =>
            {
                entity.Property(e => e.Asegurador)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Empleado)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha).HasColumnType("datetime");

                entity.Property(e => e.Ftallo).HasColumnName("FTallo");

                entity.HasOne(d => d.CategoriaNavigation)
                    .WithMany(p => p.TbCorte)
                    .HasForeignKey(d => d.Categoria)
                    .HasConstraintName("FK_TbCorte_TbCategoria");

                entity.HasOne(d => d.EmpleadoNavigation)
                    .WithMany(p => p.TbCorte)
                    .HasForeignKey(d => d.Empleado)
                    .HasConstraintName("FK_TbCorte_TbEmpleado");
            });

            modelBuilder.Entity<TbEmpleado>(entity =>
            {
                entity.HasKey(e => e.Codigo);

                entity.Property(e => e.Codigo)
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.DocId)
                    .IsRequired()
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.TbEmpleado)
                    .HasForeignKey(d => d.Area)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbEmpleado_TbArea");

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.TbEmpleado)
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TbEmpleado_TbEmpresa");
            });

            modelBuilder.Entity<TbEmpresa>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TbSemana>(entity =>
            {
                entity.Property(e => e.FechaFin).HasColumnType("date");

                entity.Property(e => e.FechaIni).HasColumnType("date");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
