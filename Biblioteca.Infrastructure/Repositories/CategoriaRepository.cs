using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
	public class CategoriaRepository : IRepository<Categoria>
	{
		private readonly BibliotecaDbContext _context;

		public CategoriaRepository(BibliotecaDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Categoria>> ObtenerTodosAsync()
		{
			return await _context.Categorias.ToListAsync();
		}

		public async Task<Categoria?> ObtenerPorIdAsync(int id)
		{
			return await _context.Categorias.FindAsync(id);
		}

		public async Task AgregarAsync(Categoria categoria)
		{
			await _context.Categorias.AddAsync(categoria);
			await _context.SaveChangesAsync();
		}

		public void Actualizar(Categoria categoria)
		{
			_context.Categorias.Update(categoria);
			_context.SaveChanges();
		}

		public void Eliminar(Categoria categoria)
		{
			_context.Categorias.Remove(categoria);
			_context.SaveChanges();
		}
	}
}