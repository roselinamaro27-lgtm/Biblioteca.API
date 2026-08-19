using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
	public class LibroRepository : ILibroRepository
	{
		private readonly BibliotecaDbContext _context;

		public LibroRepository(BibliotecaDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Libro>> ObtenerTodosAsync()
		{
			return await _context.Libros.ToListAsync();
		}

		public async Task<Libro?> ObtenerPorIdAsync(int id)
		{
			return await _context.Libros.FindAsync(id);
		}

		public async Task AgregarAsync(Libro libro)
		{
			await _context.Libros.AddAsync(libro);
			await _context.SaveChangesAsync();
		}

		public void Actualizar(Libro libro)
		{
			_context.Libros.Update(libro);
			_context.SaveChanges();
		}

		public void Eliminar(Libro libro)
		{
			_context.Libros.Remove(libro);
			_context.SaveChanges();
		}

		public async Task<IEnumerable<Libro>> BuscarPorTituloAsync(string titulo)
		{
			return await _context.Libros
				.Where(l => l.Titulo.Contains(titulo))
				.ToListAsync();
		}

		public async Task<IEnumerable<Libro>> BuscarPorAutorAsync(int autorId)
		{
			return await _context.Libros
				.Where(l => l.AutorId == autorId)
				.ToListAsync();
		}

		public async Task<IEnumerable<Libro>> ObtenerDisponiblesAsync()
		{
			return await _context.Libros.ToListAsync();
		}
	}
}