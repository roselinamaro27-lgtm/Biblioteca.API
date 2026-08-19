using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
	public class AutorRepository : IAutorRepository
	{
		private readonly BibliotecaDbContext _context;

		public AutorRepository(BibliotecaDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Autor>> ObtenerTodosAsync()
		{
			return await _context.Autores.ToListAsync();
		}

		public async Task<Autor?> ObtenerPorIdAsync(int id)
		{
			return await _context.Autores.FindAsync(id);
		}

		public async Task AgregarAsync(Autor autor)
		{
			await _context.Autores.AddAsync(autor);
			await _context.SaveChangesAsync();
		}

		public void Actualizar(Autor autor)
		{
			_context.Autores.Update(autor);
			_context.SaveChanges();
		}

		public void Eliminar(Autor autor)
		{
			_context.Autores.Remove(autor);
			_context.SaveChanges();
		}

		public async Task<IEnumerable<Autor>> BuscarPorNombreAsync(string nombre)
		{
			return await _context.Autores
				.Where(a => a.Nombre.Contains(nombre))
				.ToListAsync();
		}
	}
}