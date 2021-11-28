using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Proyecto.Models
{
    public partial class proyectoContext : DbContext
    {
        public proyectoContext()
        {
        }

        public proyectoContext(DbContextOptions<proyectoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Autor> Autors { get; set; }
        public virtual DbSet<Categorium> Categoria { get; set; }
        public virtual DbSet<Compra> Compras { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Entradaproduc> Entradaproducs { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<NivelUser> NivelUsers { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Precompra> Precompras { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Temporal> Temporals { get; set; }
        public virtual DbSet<Verentradum> Verentrada { get; set; }
        public virtual DbSet<Verlibro> Verlibros { get; set; }
        public virtual DbSet<Verpersona> Verpersonas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=proyecto", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasCharSet("utf8")
                .UseCollation("utf8_general_ci");

            modelBuilder.Entity<Autor>(entity =>
            {
                entity.HasKey(e => e.IdAutor)
                    .HasName("PRIMARY");

                entity.ToTable("autor");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Categorium>(entity =>
            {
                entity.HasKey(e => e.IdCategoria)
                    .HasName("PRIMARY");

                entity.ToTable("categoria");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Compra>(entity =>
            {
                entity.HasKey(e => e.IdCompra)
                    .HasName("PRIMARY");

                entity.ToTable("compra");

                entity.Property(e => e.IdCompra).ValueGeneratedNever();

                entity.Property(e => e.Fecha).HasColumnType("date");
            });

            modelBuilder.Entity<Editorial>(entity =>
            {
                entity.HasKey(e => e.IdEditorial)
                    .HasName("PRIMARY");

                entity.ToTable("editorial");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Entradaproduc>(entity =>
            {
                entity.HasKey(e => e.IdProd)
                    .HasName("PRIMARY");

                entity.ToTable("entradaproduc");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.HasIndex(e => e.IdLibro, "entrada_libro");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Entradaproducs)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("entrada_libro");
            });

            modelBuilder.Entity<Libro>(entity =>
            {
                entity.HasKey(e => e.IdLibro)
                    .HasName("PRIMARY");

                entity.ToTable("libro");

                entity.HasIndex(e => e.IdAutor, "libro_Autor");

                entity.HasIndex(e => e.IdCategoria, "libro_Categoria");

                entity.HasIndex(e => e.IdEditorial, "libro_Editorial");

                entity.Property(e => e.Costo).HasPrecision(9, 2);

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.FechaPublicacion).HasColumnType("date");

                entity.Property(e => e.Precio)
                    .HasPrecision(9, 2)
                    .HasComputedColumnSql("`Costo` * 1.16", true);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ubicacion).HasMaxLength(50);

                entity.HasOne(d => d.IdAutorNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdAutor)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("libro_Autor");

                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("libro_Categoria");

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Libros)
                    .HasForeignKey(d => d.IdEditorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("libro_Editorial");
            });

            modelBuilder.Entity<NivelUser>(entity =>
            {
                entity.HasKey(e => e.IdNivelUser)
                    .HasName("PRIMARY");

                entity.ToTable("nivel_user");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Persona>(entity =>
            {
                entity.HasKey(e => e.IdPersona)
                    .HasName("PRIMARY");

                entity.ToTable("persona");

                entity.HasIndex(e => e.IdNivel, "persona_nivel");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(10);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdNivelNavigation)
                    .WithMany(p => p.Personas)
                    .HasForeignKey(d => d.IdNivel)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("persona_nivel");
            });

            modelBuilder.Entity<Precompra>(entity =>
            {
                entity.HasKey(e => e.IdPre)
                    .HasName("PRIMARY");

                entity.ToTable("precompra");

                entity.Property(e => e.IdPre).ValueGeneratedNever();

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProv)
                    .HasName("PRIMARY");

                entity.ToTable("proveedor");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.HasIndex(e => e.IdEditorial, "proveedor_editorial");

                entity.Property(e => e.IdProv).ValueGeneratedNever();

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10);

                entity.HasOne(d => d.IdEditorialNavigation)
                    .WithMany(p => p.Proveedors)
                    .HasForeignKey(d => d.IdEditorial)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("proveedor_editorial");
            });

            modelBuilder.Entity<Temporal>(entity =>
            {
                entity.HasKey(e => e.IdTem)
                    .HasName("PRIMARY");

                entity.ToTable("temporal");

                entity.Property(e => e.IdTem).ValueGeneratedNever();

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");
            });

            modelBuilder.Entity<Verentradum>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("verentrada");

                entity.Property(e => e.Fecha).HasColumnType("date");

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Verlibro>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("verlibro");

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Categoria)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Costo).HasPrecision(9, 2);

                entity.Property(e => e.Editorial)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.FechaPublicacion).HasColumnType("date");

                entity.Property(e => e.Precio).HasPrecision(9, 2);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Ubicacion).HasMaxLength(50);
            });

            modelBuilder.Entity<Verpersona>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("verpersona");

                entity.Property(e => e.Apellido)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Correo).HasMaxLength(50);

                entity.Property(e => e.Direccion).HasMaxLength(50);

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Nivel)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(10);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
