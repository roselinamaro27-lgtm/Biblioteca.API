using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

using Biblioteca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Data
{
	public class BibliotecaDbContext : DbContext
	{
		public BibliotecaDbContext(DbContextOptions<BibliotecaDbContext> options)
			: base(options)
		{
		}

		public DbSet<Libro> Libros { get; set; }
		public DbSet<Autor> Autores { get; set; }
		public DbSet<Usuario> Usuarios { get; set; }
		public DbSet<Prestamo> Prestamos { get; set; }
		public DbSet<Categoria> Categorias { get; set; }
		public DbSet<DetallePrestamo> DetallesPrestamo { get; set; }
		public DbSet<Persona> Personas { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			// Relación Libro -> Autor
			modelBuilder.Entity<Libro>()
				.HasOne(l => l.Autor)
				.WithMany()
				.HasForeignKey(l => l.AutorId)
				.OnDelete(DeleteBehavior.Restrict);

			// Relación Libro -> Categoria
			modelBuilder.Entity<Libro>()
				.HasOne(l => l.Categoria)
				.WithMany()
				.HasForeignKey(l => l.CategoriaId)
				.OnDelete(DeleteBehavior.Restrict);

			// Relación Prestamo -> Usuario
			modelBuilder.Entity<Prestamo>()
				.HasOne(p => p.Usuario)
				.WithMany()
				.HasForeignKey(p => p.UsuarioId)
				.OnDelete(DeleteBehavior.Restrict);
		}
	}
}