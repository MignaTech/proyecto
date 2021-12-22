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
        public virtual DbSet<Comprar> Comprars { get; set; }
        public virtual DbSet<Editorial> Editorials { get; set; }
        public virtual DbSet<Entradaproduc> Entradaproducs { get; set; }
        public virtual DbSet<Libro> Libros { get; set; }
        public virtual DbSet<NivelUser> NivelUsers { get; set; }
        public virtual DbSet<Persona> Personas { get; set; }
        public virtual DbSet<Precompra> Precompras { get; set; }
        public virtual DbSet<Proveedor> Proveedors { get; set; }
        public virtual DbSet<Temporal> Temporals { get; set; }
        public virtual DbSet<Total> Totals { get; set; }
        public virtual DbSet<Usuario> Usuarios { get; set; }
        public virtual DbSet<Verentradum> Verentrada { get; set; }
        public virtual DbSet<Verlibro> Verlibros { get; set; }
        public virtual DbSet<Verpersona> Verpersonas { get; set; }
        public virtual DbSet<Verprecompra> Verprecompras { get; set; }
        public virtual DbSet<Verproveedor> Verproveedors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySql("server=localhost;port=3306;user=root;database=proyecto2", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.26-mysql"));
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

                entity.HasIndex(e => e.IdEmpleado, "IdEmpleado");

                entity.Property(e => e.Fecha)
                    .HasColumnType("date")
                    .HasDefaultValueSql("'2021-12-20'");

                entity.HasOne(d => d.IdEmpleadoNavigation)
                    .WithMany(p => p.Compras)
                    .HasForeignKey(d => d.IdEmpleado)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("compra_ibfk_1");
            });

            modelBuilder.Entity<Comprar>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("comprar");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PrecioUnitario).HasPrecision(9, 2);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);
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

                entity.Property(e => e.Precio)
                    .HasPrecision(9, 2)
                    .HasComputedColumnSql("`Costo` * 1.16", true);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);

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

                entity.HasIndex(e => e.IdCompra, "precompra_compra");

                entity.HasIndex(e => e.IdLibro, "precompra_libro");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Precompras)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("precompra_compra");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Precompras)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("precompra_libro");
            });

            modelBuilder.Entity<Proveedor>(entity =>
            {
                entity.HasKey(e => e.IdProv)
                    .HasName("PRIMARY");

                entity.ToTable("proveedor");

                entity.HasCharSet("utf8mb4")
                    .UseCollation("utf8mb4_0900_ai_ci");

                entity.HasIndex(e => e.IdEditorial, "proveedor_editorial");

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

                entity.HasIndex(e => e.IdCompra, "temporal_compra");

                entity.HasIndex(e => e.IdLibro, "temporal_libro");

                entity.Property(e => e.Estado).HasDefaultValueSql("'1'");

                entity.HasOne(d => d.IdCompraNavigation)
                    .WithMany(p => p.Temporals)
                    .HasForeignKey(d => d.IdCompra)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("temporal_compra");

                entity.HasOne(d => d.IdLibroNavigation)
                    .WithMany(p => p.Temporals)
                    .HasForeignKey(d => d.IdLibro)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("temporal_libro");
            });

            modelBuilder.Entity<Total>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("total");

                entity.Property(e => e.Total1)
                    .HasPrecision(32)
                    .HasColumnName("Total");
            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("usuarios");

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.Property(e => e.Token).HasMaxLength(255);

                entity.Property(e => e.Usuario1)
                    .HasMaxLength(50)
                    .HasColumnName("Usuario");
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

                entity.Property(e => e.Precio).HasPrecision(9, 2);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);
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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Telefono).HasMaxLength(10);

                entity.Property(e => e.Usuario)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Verprecompra>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("verprecompra");

                entity.Property(e => e.Estado)
                    .IsRequired()
                    .HasMaxLength(8)
                    .HasDefaultValueSql("''");

                entity.Property(e => e.PrecioUnitario).HasPrecision(9, 2);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);
            });

            modelBuilder.Entity<Verproveedor>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("verproveedor");

                entity.Property(e => e.Correo)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb4_0900_ai_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Direccion)
                    .HasMaxLength(50)
                    .UseCollation("utf8mb4_0900_ai_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Editorial)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Nombre)
                    .IsRequired()
                    .HasMaxLength(50)
                    .UseCollation("utf8mb4_0900_ai_ci")
                    .HasCharSet("utf8mb4");

                entity.Property(e => e.Telefono)
                    .IsRequired()
                    .HasMaxLength(10)
                    .UseCollation("utf8mb4_0900_ai_ci")
                    .HasCharSet("utf8mb4");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
