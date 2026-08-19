using Biblioteca.Domain.Entities;
using Biblioteca.Domain.Interfaces;
using Biblioteca.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Infrastructure.Repositories
{
	public class PrestamoRepository : IPrestamoRepository
	{
		private readonly BibliotecaDbContext _context;

		public PrestamoRepository(BibliotecaDbContext context)
		{
			_context = context;
		}

		public async Task<IEnumerable<Prestamo>> ObtenerTodosAsync()
		{
			return await _context.Prestamos.ToListAsync();
		}

		public async Task<Prestamo?> ObtenerPorIdAsync(int id)
		{
			return await _context.Prestamos.FindAsync(id);
		}

		public async Task AgregarAsync(Prestamo prestamo)
		{
			await _context.Prestamos.AddAsync(prestamo);
			await _context.SaveChangesAsync();
		}

		public void Actualizar(Prestamo prestamo)
		{
			_context.Prestamos.Update(prestamo);
			_context.SaveChanges();
		}

		public void Eliminar(Prestamo prestamo)
		{
			_context.Prestamos.Remove(prestamo);
			_context.SaveChanges();
		}
	}
}