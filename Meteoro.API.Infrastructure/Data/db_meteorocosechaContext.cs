using Meteoro.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Meteoro.API.Infrastructure.Data
{
    public partial class db_meteorocosechaContext : DbContext
    {
        public db_meteorocosechaContext()
        {
        }

        public db_meteorocosechaContext(DbContextOptions<db_meteorocosechaContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Tbladmin> Tbladmin { get; set; }
        public virtual DbSet<Tblarea> Tblarea { get; set; }
        public virtual DbSet<Tblaseguradorempleado> Tblaseguradorempleado { get; set; }
        public virtual DbSet<Tblcosecha> Tblcosecha { get; set; }
        public virtual DbSet<Tblempleado> Tblempleado { get; set; }
        public virtual DbSet<Tblempresa> Tblempresa { get; set; }
        public virtual DbSet<Tblmodalidad> Tblmodalidad { get; set; }
        public virtual DbSet<Tblregistro> Tblregistro { get; set; }
        public virtual DbSet<Tblsemana> Tblsemana { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Tbladmin>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__tbladmin__40F9A207099C8435");

                entity.ToTable("tbladmin");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.FechaUpdate)
                    .HasColumnName("fechaUpdate")
                    .HasColumnType("date");

                entity.Property(e => e.NovedadUpdate)
                    .HasColumnName("novedadUpdate")
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.VersionActual)
                    .IsRequired()
                    .HasColumnName("versionActual")
                    .HasMaxLength(15)
                    .IsFixedLength();

                entity.Property(e => e.VersionAnterior)
                    .IsRequired()
                    .HasColumnName("versionAnterior")
                    .HasMaxLength(15)
                    .IsFixedLength();
            });

            modelBuilder.Entity<Tblarea>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__tblarea__40F9A207A0D922AA");

                entity.ToTable("tblarea");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblaseguradorempleado>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__tblasegu__40F9A207F58EC7A5");

                entity.ToTable("tblaseguradorempleado");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Asegurador)
                    .HasColumnName("asegurador")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Empleado)
                    .HasColumnName("empleado")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.Revisiones).HasColumnName("revisiones");

                entity.Property(e => e.Sync).HasColumnName("sync");
            });

            modelBuilder.Entity<Tblcosecha>(entity =>
            {
                entity.ToTable("tblcosecha");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Asegurador)
                    .IsRequired()
                    .HasColumnName("asegurador")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Año).HasColumnName("año");

                entity.Property(e => e.Conteo).HasColumnName("conteo");

                entity.Property(e => e.Cortos).HasColumnName("cortos");

                entity.Property(e => e.Cubiertos).HasColumnName("cubiertos");

                entity.Property(e => e.Empaque).HasColumnName("empaque");

                entity.Property(e => e.Empleado)
                    .IsRequired()
                    .HasColumnName("empleado")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasColumnName("empresa")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Fecha)
                    .HasColumnName("fecha")
                    .HasColumnType("datetime");

                entity.Property(e => e.HBajeras).HasColumnName("hBajeras");

                entity.Property(e => e.Hojas).HasColumnName("hojas");

                entity.Property(e => e.Largos).HasColumnName("largos");

                entity.Property(e => e.Maximo).HasColumnName("maximo");

                entity.Property(e => e.Modalidad).HasColumnName("modalidad");

                entity.Property(e => e.Poda).HasColumnName("poda");

                entity.Property(e => e.Podado).HasColumnName("podado");

                entity.Property(e => e.Revision).HasColumnName("revision");

                entity.Property(e => e.Semana).HasColumnName("semana");

                entity.Property(e => e.Tocon).HasColumnName("tocon");

                entity.HasOne(d => d.EmpleadoNavigation)
                    .WithMany(p => p.Tblcosecha)
                    .HasForeignKey(d => d.Empleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblcosecha_tblempleado");

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.Tblcosecha)
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblcosecha_tblempresa");

                entity.HasOne(d => d.ModalidadNavigation)
                    .WithMany(p => p.Tblcosecha)
                    .HasForeignKey(d => d.Modalidad)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblcosecha_tblmodalidad");
            });

            modelBuilder.Entity<Tblempleado>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__tblemple__40F9A2071D04D29F");

                entity.ToTable("tblempleado");

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.Area).HasColumnName("area");

                entity.Property(e => e.DocId)
                    .IsRequired()
                    .HasColumnName("docId")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Empresa)
                    .IsRequired()
                    .HasColumnName("empresa")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Estado).HasColumnName("estado");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(60)
                    .IsUnicode(false);

                entity.Property(e => e.Pass)
                    .IsRequired()
                    .HasColumnName("pass")
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Periodo).HasColumnName("periodo");

                entity.HasOne(d => d.AreaNavigation)
                    .WithMany(p => p.Tblempleado)
                    .HasForeignKey(d => d.Area)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblempleado_tblarea");

                entity.HasOne(d => d.EmpresaNavigation)
                    .WithMany(p => p.Tblempleado)
                    .HasForeignKey(d => d.Empresa)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblempleado_tblempresa");
            });

            modelBuilder.Entity<Tblempresa>(entity =>
            {
                entity.HasKey(e => e.CodEmpresa);

                entity.ToTable("tblempresa");

                entity.Property(e => e.CodEmpresa)
                    .HasColumnName("codEmpresa")
                    .HasMaxLength(3)
                    .IsUnicode(false);

                entity.Property(e => e.Codigo)
                    .HasColumnName("codigo")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(70)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblmodalidad>(entity =>
            {
                entity.HasKey(e => e.Codigo)
                    .HasName("PK__tblmodal__40F9A20767BA832E");

                entity.ToTable("tblmodalidad");

                entity.Property(e => e.Codigo).HasColumnName("codigo");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasColumnName("nombre")
                    .HasMaxLength(40)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Tblregistro>(entity =>
            {
                entity.HasKey(e => e.Consecutivo)
                    .HasName("PK__tblregis__F6E9842748297EFC");

                entity.ToTable("tblregistro");

                entity.Property(e => e.Consecutivo).HasColumnName("consecutivo");

                entity.Property(e => e.Empleado)
                    .IsRequired()
                    .HasColumnName("empleado")
                    .HasMaxLength(7)
                    .IsUnicode(false);

                entity.Property(e => e.FechaDesconexion)
                    .HasColumnName("fechaDesconexion")
                    .HasColumnType("datetime");

                entity.Property(e => e.FechaIngreso)
                    .HasColumnName("fechaIngreso")
                    .HasColumnType("datetime");
            });

            modelBuilder.Entity<Tblsemana>(entity =>
            {
                entity.HasKey(e => e.Consecutiv)
                    .HasName("PK__tblseman__20976D6DBE914955");

                entity.ToTable("tblsemana");

                entity.Property(e => e.Consecutiv).HasColumnName("consecutiv");

                entity.Property(e => e.Año).HasColumnName("año");

                entity.Property(e => e.Fechafin)
                    .HasColumnName("fechafin")
                    .HasColumnType("date");

                entity.Property(e => e.Fechaini)
                    .HasColumnName("fechaini")
                    .HasColumnType("date");

                entity.Property(e => e.Semana).HasColumnName("semana");
            });

        }

    }
}
